using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class Book: BaseEntity
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public string BookPhotoUrl { get; set; }
    public Order Order { get; set; }
    public bool Status { get; set; }

    [NotMapped]
    public IFormFile BookPhotoFile { get; set; }
}
