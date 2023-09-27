using Application.Repositories.BookRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.BookRepositories;

public class BookReadRepository: ReadRepository<Book>, IBookReadRepository
{
    public BookReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}