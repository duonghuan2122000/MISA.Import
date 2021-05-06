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

        public bool CheckCustomerCodeExists(string customerCode)
        {
            using var connection = new MySqlConnection(_connectionString);
            var p = new DynamicParameters();
            p.Add("customerCode", customerCode);
            bool isExists = connection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", p, commandType: CommandType.StoredProcedure);
            return isExists;
        }

        public bool CheckPhoneNumberExists(string phoneNumber)
        {
            using var connection = new MySqlConnection(_connectionString);
            var p = new DynamicParameters();
            p.Add("phoneNumber", phoneNumber);
            bool isExists = connection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists", p, commandType: CommandType.StoredProcedure);
            return isExists;
        }

        public CustomerGroup GetCustomerGroup(string customerGroupName)
        {
            using var connection = new MySqlConnection(_connectionString);
            var p = new DynamicParameters();
            p.Add("customerGroupName", customerGroupName);
            var customerGroup = connection.QueryFirstOrDefault<CustomerGroup>("Proc_GetCustomerGroup", p, commandType: CommandType.StoredProcedure);
            return customerGroup;
        }

        public int InsertCustomer(Customer customer)
        {
            using var connection = new MySqlConnection(_connectionString);
            var rowsAffect = connection.Execute("Proc_InsertCustomer", customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
