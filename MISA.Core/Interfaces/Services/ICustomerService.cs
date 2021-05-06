using Microsoft.AspNetCore.Http;
using MISA.Import.Core.Entites;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Interface service khách hàng.
    /// </summary>
    /// CreatedBy: dbhuan (06/05/2021)
    public interface ICustomerService
    {
        /// <summary>
        /// Hàm đọc thông tin file excel.
        /// </summary>
        /// <param name="file">file excel.</param>
        /// <param name="cancellationToken">Token hủy</param>
        /// <returns>Danh sách các khách hàng và lỗi của từng khách hàng.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public Task<List<CustomerImport>> ReadFromExcel(IFormFile file, CancellationToken cancellationToken);

        /// <summary>
        /// Hàm thêm nhiều khách hàng không có lỗi vào db.
        /// </summary>
        /// <param name="customersImport">Danh sách các khách hàng và lỗi của từng khách hàng</param>
        /// <returns>Số khách hàng thêm thành công.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public int InsertCustomers(List<CustomerImport> customersImport);
    }
}
