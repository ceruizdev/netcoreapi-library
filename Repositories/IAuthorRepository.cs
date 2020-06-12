using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IAuthorRepository : IRepository<Authors>
    {
        IEnumerable<AuthorList> AuthorPagedList(int page, int row);
    }
}
