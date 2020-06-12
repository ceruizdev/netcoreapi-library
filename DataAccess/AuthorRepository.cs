using Dapper;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class AuthorRepository : Repository<Authors>, IAuthorRepository
    {
        public AuthorRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<AuthorList> AuthorPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<AuthorList>("spListaAutores", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }


    }
}
