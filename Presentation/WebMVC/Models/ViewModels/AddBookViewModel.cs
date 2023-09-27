using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.ViewModels;

public class AddBookViewModel
{
    [Required(ErrorMessage = "Kitap ismi belirtilmelidir.")]
    public string BookName { get; set; }
    
    [Required(ErrorMessage = "Yazar ismi belirtilmelidir.")]
    public string AuthorName { get; set; }

    [Required(ErrorMessage = "Kitap görsel url'i belirtilmelidir.")]
    public string BookPhotoUrl { get; set; }
    public bool Status { get; set; }
}