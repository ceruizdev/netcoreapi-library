using Repositories;
using UnitOfWork;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString) {
            User = new UserRepository(connectionString);
            Book = new BookRepository(connectionString);
            Author = new AuthorRepository(connectionString);
            Category = new CategoryRepository(connectionString);
        }
        public IUserRepository User { get; private set; }
        public IBookRepository Book { get; private set; }
        public IAuthorRepository Author { get; private set; }
        public ICategoryRepository Category { get; private set; }
    }
}
