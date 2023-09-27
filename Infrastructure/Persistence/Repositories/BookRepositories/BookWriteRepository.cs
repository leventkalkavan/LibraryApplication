using Application.Repositories.BookRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.BookRepositories;

public class BookWriteRepository: WriteRepository<Book>, IBookWriteRepository
{
    public BookWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}