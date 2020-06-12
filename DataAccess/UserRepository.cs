using Dapper;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(string connectionString): base(connectionString) { 

        }

        public IEnumerable<UserList> UserPageList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<UserList>("spListaUsuarios", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Users ValidateUser(string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", email);
            parameters.Add("@password", password);
            using (var connection = new SqlConnection(_connectionString)) {
                return connection.QueryFirstOrDefault<Users>("spValidaLogin",parameters, 
                    commandType:System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
