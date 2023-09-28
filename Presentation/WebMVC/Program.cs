using Persistence;
using Serilog;
using WebMVC.Exception;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Persistence servisini ekliyoruz.
builder.Services.AddPersistenceServices();

// Serilog konfigürasyonu ve loglama ekliyoruz.
Log.Logger = new LoggerConfiguration().WriteTo.Debug(Serilog.Events.LogEventLevel.Information).WriteTo.File("logs.txt").CreateLogger();
builder.Services.AddLogging().AddSerilog();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

// Özel bir hata işleme middleware ekliyoruz.
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();