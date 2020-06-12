using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IBookRepository : IRepository<Books> 
    {
        IEnumerable<BookList> BookPagedList(int page, int row);
        IEnumerable<Books> FilterQuery(int type, string filter);
    }
}
