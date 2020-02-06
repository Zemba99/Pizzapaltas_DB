using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TypeLib;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace MsRepository
{
    public class Repository
    {
        IDbConnection Connection { get; set; }
        public Repository(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }
        public async Task<int> AddPizza(Pizza pizza)
        {
            return (await Connection.QueryAsync<int>("AddPizza", new { Name = pizza.Name }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<int> DeletePizza(Pizza pizza)
        {
            return (await Connection.QueryAsync<int>("DeletePizza", new { ID = pizza.ID }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<int> EditPizza(Pizza pizza)
        {
            return (await Connection.QueryAsync<int>("EditPizza", new { Name = pizza.Name }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<int> EmpAddOrEdit(Employee employee)
        {
            return (await Connection.QueryAsync<int>("EmpAddOrEdit", new { ID = employee.ID, Username = employee.Username, Password = employee.Password, Role = employee.Role }, commandType: CommandType.StoredProcedure)).First();
        }

        
    }
}
