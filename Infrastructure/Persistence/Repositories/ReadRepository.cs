using System.Linq.Expressions;
using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;


public class ReadRepository<T>:IReadRepository<T> where T:BaseEntity
{
    private readonly ApplicationDbContext _context;
    public DbSet<T> Table => _context.Set<T>();
    
    public ReadRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(x=>x.Id==id);
    }
}