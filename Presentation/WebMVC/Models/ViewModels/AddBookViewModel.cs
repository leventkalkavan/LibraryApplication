using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.ViewModels
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage = "Kitap ismi belirtilmelidir.")]
        public string BookName { get; set; }
        
        [Required(ErrorMessage = "Yazar ismi belirtilmelidir.")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Kitap görseli yüklenmelidir.")]
        public IFormFile BookPhotoFile { get; set; }
        
        public bool Status { get; set; }
    }
}