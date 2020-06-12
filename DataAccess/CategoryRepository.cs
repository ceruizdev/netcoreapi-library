using Dapper;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CategoryRepository : Repository<Categories>, ICategoryRepository
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<CategoryList> CategoryPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CategoryList>("spListaCategorias", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
