using Microsoft.Extensions.Configuration;

namespace Persistence;

public class Configuration
{
    public static string? GetConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                
                // Projenin adresini kopyalıyoruz
                "/../../Presentation/WebMVC"));
            configurationManager.AddJsonFile("appsettings.json");
            
            // appsettings.json dosyasından ConnectionStrings bölümünü okuyarak bağlantı dizesini alıyoruz
            return configurationManager.GetConnectionString("SqlConnection");
        }
    }
}
