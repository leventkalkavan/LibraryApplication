using System.Linq.Expressions;
using Domain.Entities.Common;

namespace Application.Repositories;

public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    Task<T> GetByIdAsync(string id,bool tracking = true);
}