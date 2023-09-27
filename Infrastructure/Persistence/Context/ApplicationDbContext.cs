using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {}
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
}