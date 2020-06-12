using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICategoryRepository: IRepository<Categories>
    {
        IEnumerable<CategoryList> CategoryPagedList(int page, int row);
    }
}
