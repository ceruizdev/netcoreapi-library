using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public interface IUserRepository: IRepository<Users>
    {
        Users ValidateUser(string user, string password);
        IEnumerable<UserList> UserPageList(int page, int rows);
    }
}
