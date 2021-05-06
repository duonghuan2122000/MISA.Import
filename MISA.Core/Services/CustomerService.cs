using Microsoft.AspNetCore.Http;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using MISA.Import.Core.Entites;
using MISA.Import.Core.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerImport>> ReadFromExcel(IFormFile formFile, CancellationToken cancellationToken)
        {
            var customersImport = new List<CustomerImport>();
            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);
                using var package = new ExcelPackage(stream);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int rowNumber = 3; rowNumber <= rowCount; rowNumber++)
                {
                    var customer = new Customer()
                    {
                        CustomerCode = GetValue(worksheet.Cells[rowNumber, 1].Value),
                        FullName = GetValue(worksheet.Cells[rowNumber, 2].Value),
                        MemberCardCode = GetValue(worksheet.Cells[rowNumber, 3].Value),
                        PhoneNumber = GetValue(worksheet.Cells[rowNumber, 4].Value),
                        DateOfBirth = ParseDate(worksheet.Cells[rowNumber, 6].Value),
                        CompanyName = GetValue(worksheet.Cells[rowNumber, 7].Value),
                        CompanyTaxCode = GetValue(worksheet.Cells[rowNumber, 8].Value),
                        Email = GetValue(worksheet.Cells[rowNumber, 9].Value),
                        Address = GetValue(worksheet.Cells[rowNumber, 10].Value),
                        Note = GetValue(worksheet.Cells[rowNumber, 11].Value)
                    };

                    var customerImport = new CustomerImport();

                    if (customersImport.Any())
                    {
                        // check valid.

                        // check customerCode exists on import.
                        var customerCodeExistsOnExcel = customersImport.Where(c => c.Data.CustomerCode == customer.CustomerCode).Any();

                        if (customerCodeExistsOnExcel == true)
                        {
                            customerImport.Errors.Add(Properties.Resources.MsgErrorCustomerCodeExistsOnImport);
                        }

                        // check phoneNumber exists on import.
                        var phoneNumberExistsOnExcel = customersImport.Where(c => c.Data.PhoneNumber == customer.PhoneNumber).Any();


                        if (phoneNumberExistsOnExcel == true)
                        {
                            customerImport.Errors.Add(Properties.Resources.MsgErrorPhoneNumberExistsOnImport);
                        }
                    }

                    // check customerCode tồn tại trên hệ thống.
                    var customerCodeExists = _customerRepository.CheckCustomerCodeExists(customer.CustomerCode);
                    if (customerCodeExists == true)
                    {
                        customerImport.Errors.Add(Properties.Resources.MsgErrorCustomerCodeExists);
                    }

                    // check phoneNumber tồn tại trên hệ thống.
                    var phoneNumberExists = _customerRepository.CheckPhoneNumberExists(customer.PhoneNumber);
                    if (phoneNumberExists == true)
                    {
                        customerImport.Errors.Add(Properties.Resources.MsgErrorPhoneNumberExists);
                    }

                    // check nhóm khách hàng có tồn tại trên hệ thống.
                    string customerGroupName = GetValue(worksheet.Cells[rowNumber, 5].Value);

                    var customerGroup = _customerRepository.GetCustomerGroup(customerGroupName);
                    if(customerGroup == null)
                    {
                        customerImport.Errors.Add(Properties.Resources.MsgErrorCustomerGroupNotExists);
                    } else
                    {
                        customer.CustomerGroupId = customerGroup.CustomerGroupId;
                        customer.CustomerGroupName = customerGroupName;
                    }

                    customerImport.Data = customer;
                    customersImport.Add(customerImport);
                }
            }
            return customersImport;
        }

        public int InsertCustomers(List<CustomerImport> customersImport)
        {
            int i = 0;
            foreach(var ci in customersImport)
            {
                if (!ci.Errors.Any())
                {
                    i++;
                    _customerRepository.InsertCustomer(ci.Data);
                }
            }
            return i;
        }

        private string GetValue(object valueObj)
        {
            if (valueObj is null)
            {
                return null;
            }
            return valueObj.ToString().Trim();
        }

        private DateTime? ParseDate(object valueObj)
        {
            string valueStr = GetValue(valueObj);
            if (valueObj is null)
            {
                return null;
            }
            return DateTime.ParseExact(s: valueStr, formats: new string[] { "dd/MM/yyyy", "MM/yyyy", "yyyy" }, provider: null);
        }

    }
}
