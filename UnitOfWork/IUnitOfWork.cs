using Repositories;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        ICategoryRepository Category { get;  }
    }
}
