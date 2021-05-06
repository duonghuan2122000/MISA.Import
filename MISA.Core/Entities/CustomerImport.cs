using MISA.Import.Core.Entities;
using System.Collections.Generic;

namespace MISA.Import.Core.Entites 
{ 
    /// <summary>
    /// Thông tin response khi trả về cho client.
    /// </summary>
    /// CreatedBy: dbhuan (06/05/2021)
    public class CustomerImport
    {
        /// <summary>
        /// Dữ liệu một khách hàng.
        /// </summary>
        public Customer Data { get; set; }

        /// <summary>
        /// Danh sách lỗi của một khách hàng.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}
