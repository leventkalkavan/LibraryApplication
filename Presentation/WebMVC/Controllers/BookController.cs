using Application.Repositories.BookRepositories;
using Application.Repositories.CustomerRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models.ViewModels;

namespace WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IOrderWriteRepository orderWriteRepository, ILogger<BookController> logger)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _logger = logger;
        }

        // Kitapları listeleme işlemi
        [HttpGet]
        public IActionResult ListBook()
        {
            // Tüm kitapları al, bu arada ilişkili siparişleri de dahil ediyoruz.
            var books = _bookReadRepository.GetAll().Include(b => b.Order).ToList();
            
            // Log bilgisi kaydediliyor.
            _logger.LogInformation("BookController - ListBook action executed, books are listed.");
            
            return View(books);
        }

        // Yeni kitap eklemek için sayfayı gösterme işlemi
        [HttpGet]
        public IActionResult AddBook()
        { 
            return View();
        }

        // Yeni kitap eklemek için form gönderme işlemi
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Yeni kitap nesnesi oluşturuyoruz ve model üzerinden gelen verileri atıyoruz.
            var book = new Book
            {
                Name = model.BookName,
                AuthorName = model.AuthorName,
                Status = true
            };

            // Eğer bir kitap fotoğrafı yüklenmişse, onu kaydediyoruz.
            if (model.BookPhotoFile != null && model.BookPhotoFile.Length > 0)
            {
                var imagePath = "wwwroot/images/"; // Dosyanın kaydedileceği dizini seçiyoruz.
                var uniqueFileName = Guid.NewGuid() + "_" + model.BookPhotoFile.FileName;
                var filePath = Path.Combine(imagePath, uniqueFileName);

                // Dosyayı oluşturuyoruz ve içeriği kopyalıyoruz.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.BookPhotoFile.CopyToAsync(stream);
                }

                // Kitap nesnesine resmin URL'sini kaydediyoruz.
                book.BookPhotoUrl = "/images/" + uniqueFileName;
            }

            // Kitabı veritabanına ekliyoruz ve kaydediyoruz.
            await _bookWriteRepository.AddAsync(book);
            await _bookWriteRepository.SaveAsync();

            // Log bilgisi kaydediliyor.
            _logger.LogInformation($"BookController - AddBook action executed, '{book.Name}' added.");

            // Kitap listesi sayfasına yönlendiriyor.
            return RedirectToAction("ListBook");
        }


        // Kitap kiralamak için sayfayı gösterme işlemi
        [HttpGet]
        public IActionResult HiringBook()
        {
            // Durumu true olan tüm kitapları al
            var books = _bookReadRepository.GetAll().Where(x => x.Status == true);
            ViewBag.Books = books;

            return View();
        }

        // Kitap kiralamak için form gönderme işlemi
        [HttpPost]
        public async Task<IActionResult> HiringBook(HiringBookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Eğer iade tarihi bugünden önceyse, hata ekleyin ve aynı sayfayı tekrar gösteriyoruz.
            if (model.ReturnDateTime.Date < DateTime.Today)
            {
                ModelState.AddModelError("ReturnDateTime", "İade tarihi geçmiş tarih olamaz.");
                _logger.LogInformation("Return date cannot be in the past.");
                return View(model);
            }

            // Kiralanacak kitabı modeldeki BookId ile veritabanından alıyoruz.
            var book = await _bookReadRepository.GetByIdAsync(model.BookId);

            // Kitabın durumunu false olarak ayarlıyoruz.
            book.Status = false;
            _bookWriteRepository.Update(book);
            await _bookWriteRepository.SaveAsync();

            // Siparişi oluşturuyoruz.
            var order = new Order
            {
                Name = model.CustomerName,
                ReturnDateTime = model.ReturnDateTime.Date,
                BookId = model.BookId,
            };

            // Siparişi veritabanına ekleyip ve kaydediyoruz.
            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            // Log bilgisi kaydediliyor.
            _logger.LogInformation($"BookController - HiringBook action executed, '{order.Name}' borrowed the book '{order.Book.Name}' ");

            // Kitap listesi sayfasına yönlendiriyoruz.
            return RedirectToAction("ListBook");
        }

    }
}
