using MISA.Import.Core.Entites;
using MISA.Import.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public bool CheckCustomerCodeExists(string customerCode);

        public bool CheckPhoneNumberExists(string phoneNumber);

        public CustomerGroup GetCustomerGroup(string customerGroupName);

        public int InsertCustomer(Customer customer);
    }
}
