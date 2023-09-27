using Application.Repositories.CustomerRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.CustomerRepositories;

public class OrderWriteRepository: WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}