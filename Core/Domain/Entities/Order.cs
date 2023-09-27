using Domain.Entities.Common;

namespace Domain.Entities;

public class Order: BaseEntity
{
    public string Name { get; set; }
    public string BookId { get; set; }
    public Book Book { get; set; }
    public DateTime ReturnDateTime { get; set; }
}