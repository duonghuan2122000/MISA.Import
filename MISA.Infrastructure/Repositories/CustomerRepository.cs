using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Repositories;
using MISA.Import.Core.Entites;
using MISA.Import.Core.Entities;
using MySqlConnector;
using System.Data;

namespace MISA.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionDb");
        }

        /// <summary>
        /// Hàm kiểm tra trùng mã khách hàng trên db.   
        /// </summary>
        /// <param name="customerCode">mã khách hàng cần kiểm tra.</param>
        /// <returns>Trùng hay không.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public bool CheckCustomerCodeExists(string customerCode)
        {
            using var connection = new MySqlConnection(_connectionString);
            var p = new DynamicParameters();
            p.Add("customerCode", customerCode);
            bool isExists = connection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", p, commandType: CommandType.StoredProcedure);
            return isExists;
        }

        /// <summary>
        /// Hàm kiểm tra có trùng số điện thoại khách hàng trên db.
        /// </summary>
        /// <param name="phoneNumber">số điện thoại cần kiểm tra.</param>
        /// <returns>Trùng hay không.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public bool CheckPhoneNumberExists(string phoneNumber)
        {
            using var connection = new MySqlConnection(_connectionString);
            var p = new DynamicParameters();
            p.Add("phoneNumber", phoneNumber);
            bool isExists = connection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists", p, commandType: CommandType.StoredProcedure);
            return isExists;
        }

        /// <summary>
        /// Hàm insert một khách hàng vào db.
        /// </summary>
        /// <param name="customer">Thông tin khách hàng.</param>
        /// <returns>Số khách hàng thêm thành công.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public CustomerGroup GetCustomerGroup(string customerGroupName)
        {
            using var connection = new MySqlConnection(_connectionString);
            var p = new DynamicParameters();
            p.Add("customerGroupName", customerGroupName);
            var customerGroup = connection.QueryFirstOrDefault<CustomerGroup>("Proc_GetCustomerGroup", p, commandType: CommandType.StoredProcedure);
            return customerGroup;
        }

        /// <summary>
        /// Lấy thông tin một nhóm khách hàng trên db.
        /// </summary>
        /// <param name="customerGroupName">Tên nhóm khách cần lấy.</param>
        /// <returns>Thông tin một nhóm khách hàng.</returns>
        /// CreatedBy: dbhuan (06/05/2021)
        public int InsertCustomer(Customer customer)
        {
            using var connection = new MySqlConnection(_connectionString);
            var rowsAffect = connection.Execute("Proc_InsertCustomer", customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
