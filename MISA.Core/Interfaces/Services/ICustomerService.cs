using Microsoft.AspNetCore.Http;
using MISA.Import.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<List<CustomerImport>> ReadFromExcel(IFormFile file, CancellationToken cancellationToken);

        public int InsertCustomers(List<CustomerImport> customersImport);
    }
}
