using System.Linq.Expressions;
using Domain.Entities.Common;

namespace Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    bool Update(T model);
    Task<int> SaveAsync();
    
}