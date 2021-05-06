using MISA.Import.Core.Entites;
using MISA.Import.Core.Entities;

namespace MISA.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface repository của khách hàng.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Hàm kiểm tra có trùng mã khách hàng trên db.   
        /// </summary>
        /// <param name="customerCode">mã khách hàng cần kiểm tra.</param>
        /// <returns>Trùng hay không.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public bool CheckCustomerCodeExists(string customerCode);

        /// <summary>
        /// Hàm kiểm tra có trùng số điện thoại khách hàng trên db.
        /// </summary>
        /// <param name="phoneNumber">số điện thoại cần kiểm tra.</param>
        /// <returns>Trùng hay không.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public bool CheckPhoneNumberExists(string phoneNumber);

        /// <summary>
        /// Lấy thông tin một nhóm khách hàng trên db.
        /// </summary>
        /// <param name="customerGroupName">Tên nhóm khách cần lấy.</param>
        /// <returns>Thông tin một nhóm khách hàng.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public CustomerGroup GetCustomerGroup(string customerGroupName);

        /// <summary>
        /// Hàm insert một khách hàng vào db.
        /// </summary>
        /// <param name="customer">Thông tin khách hàng.</param>
        /// <returns>Số khách hàng thêm thành công.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public int InsertCustomer(Customer customer);
    }
}
