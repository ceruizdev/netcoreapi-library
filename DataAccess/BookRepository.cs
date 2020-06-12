using Dapper;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    class BookRepository : Repository<Books>, IBookRepository
    {
        public BookRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<BookList> BookPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<BookList>("spListaLibros", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Books> FilterQuery(int type, string filter)
        {
            var sql = "";
            if (type == 1)
            {
                sql = "SELECT * FROM [Books] WHERE [Name] like '%" + filter + "%'";
            }
            else if (type == 2)
            {
                sql = "SELECT a.* FROM [Authors] b JOIN Books a ON a.AuthorFK = b.Id AND b.FirstName like '%" + filter + "%'";
            }
            else if (type == 3) {
                sql = "SELECT a.* FROM Categories c JOIN [Books] a ON a.CategoryFK = c.Id AND c.Name like '%" + filter + "%'";
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Books>(sql);
            }
        }
    }
}
