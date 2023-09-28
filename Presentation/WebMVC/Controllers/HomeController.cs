using System.Diagnostics;
using Application.Repositories.BookRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookReadRepository _bookReadRepository;

    public HomeController(ILogger<HomeController> logger, IBookReadRepository bookReadRepository)
    {
        _logger = logger;
        _bookReadRepository = bookReadRepository;
    }
    public IActionResult Index()
    {
        // Tüm kitapları alıyoruz.
        var books = _bookReadRepository.GetAll();
            
        // Log bilgi kaydediliyor.
        _logger.LogInformation("HomeController - Index action executed.");
            
        return View(books);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
