using System.Net;

namespace WebMVC.Exception
{
    // ExceptionHandlerMiddleware sınıfı, HTTP istekleri üzerinde bir araya gelecek ve istisnaları ele alacak olan middleware'dir.
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Middleware'in ana işlemi Invoke yöntemi içinde gerçekleşir.
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Sonraki middleware'e işlemi ileteceğiz.
                await _next(context);
            }
            catch (System.Exception ex)
            {
                // Oluşan istisnayı kaydediyoruz.
                _logger.LogError(ex, "Global exception occurred");
                
                // Yanıt kodunu 500 (Internal Server Error) olarak ayarlıyoruz.
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/plain";

                // Hata mesajını yanıta yazıyoruz.
                await context.Response.WriteAsync("Internal Server Error");
            }
        }
    }
}