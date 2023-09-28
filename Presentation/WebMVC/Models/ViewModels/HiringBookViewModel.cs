
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.ViewModels;

public class HiringBookViewModel
{
    [Required(ErrorMessage = "Kiralayan kişi isim belirtilmelidir.")]
    public string RentName { get; set; }

    [Required(ErrorMessage = "Geri verilecek tarih belirtilmelidir.")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime ReturnDateTime { get; set; }
    public string BookId { get; set; }
}