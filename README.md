# Kütüphane Uygulaması

Kütüphane Uygulaması, kullanıcıların kütüphane yönetimini kolayca gerçekleştirebilmeleri için tasarlanmış bir uygulamadır. Bu uygulama, hem kütüphane çalışanlarının hem de kullanıcıların ihtiyaçlarını karşılayacak şekilde geliştirilmiştir.

# Uygulamadaki Sayfalar

### Ana Sayfa
Uygulamanın ana sayfası, kütüphanede bulunan kitapların listesini sunar. Kitaplar, alfabetik sıraya göre sıralanır ve kitap hakkında temel bilgiler (ad, yazar, görsel, durum) görüntülenir. Kitapların durumu, "kütüphanede" veya "dışarıda" olarak belirtilir, bu sayede kullanıcılar hangi kitapların müsait olduğunu hızla görebilirler.

### Kitap İşlemleri Sayfası
Kitap İşlemleri sayfası, kitaplar hakkında ayrıntı sunar. Kütüphanede bulunan kitaplar listelenir ve burada ödünç alınan kitaplar, kimin tarafından alındığı ve ne zaman geri getireleceği gibi bilgilerle birlikte görüntülenir.

### Kitap Ekleme Sayfası
Kitap eklemek için kullanıcılar "Kitap Ekle" sayfasını kullanabilirler. Bu sayfada kitabın adı, yazarı ve görseli eklenir. Eklenen kitap kütüphanenin listesine dahil edilir.

### Kitap Ödünç Alma Sayfası
Kitap Ödünç Al sayfası, kullanıcıların kütüphanede bulunan kitapları ödünç almalarını sağlar. Kullanıcılar durumu "kütüphanede" yazılı olan istediği kitabı seçebilir, adlarını ve kitabı ne zaman iade edeceklerini belirterek ödünç alabilirler.

## Kullanılan Mimari ve Teknolojiler
- Onion Architecture
- ASP.NET Core 7.0 MVC
- Bootstrap
- MSSQL
- Entity Framework

## Projenin Kurulumu

1. Projeyi indirin: [Library Application](https://github.com/leventkalkavan/LibraryApplication)

2. `appsettings.json` dosyasındaki `connectionString`i kendi veritabanı bilgilerinize göre ayarlayın:

```json
"ConnectionStrings": {
    "SqlConnection": "Server=tcp:localhost,4141;Database=MyDatabase;User ID=userId;Password=password;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=false;"
}
```
## Veritabanını Oluşturma

Veritabanını oluşturmak için aşağıdaki adımları takip edebilirsiniz:

1. Projeyi indirin veya klonlayın.

2. `Persistence` klasörünün içinde bulunan `Persistence.csproj` dosyasının dizininde bir terminal açın.

3. Aşağıdaki komutları sırayla çalıştırarak veritabanını oluşturun:

```shell
dotnet ef migrations add InitialMig
dotnet ef database update
```

## Proje Fonksiyonları

### Kitap Listeleme Fonksiyonu
```C#
public IActionResult ListBook() 
```
adlı bu fonksiyon, kütüphanede bulunan kitapları listelemek için kullanılır. Bu fonksiyon aşağıdaki bilgileri içerir:

Kütüphanedeki tüm kitaplar listelenir.
Her bir kitap için kitap adı, yazarı, görseli ve durumu (kütüphanede veya dışarıda) görüntülenir.
Ödünç alınmış kitaplar ise kimin aldığı ve ne zaman geri getireceği gibi bilgilerle birlikte listelenir.

### Kitap Ekleme Fonksiyonu
```C#
public async Task<IActionResult> AddBook(AddBookFormViewModel model)
```
adlı bu fonksiyon, yeni kitapların veritabanına eklenmesini sağlar. İşte bu fonksiyonun işlevleri:

AddBookFormViewModel nesnesi aracılığıyla gelen kitap bilgilerini (adı, yazarı, görseli) alır.
Alınan kitap bilgilerini veri tabanına ekler ve yeni bir kitap kaydı oluşturur.
Bu fonksiyon, kitap eklenme işlemini asenkron olarak gerçekleştirir.

### Kitap Ödünç Alma Fonksiyonu

```C#
public async Task<IActionResult> HiringBook(HiringBookFormViewModel model)
```
adlı bu fonksiyon, kullanıcıların kütüphaneden kitap ödünç almalarını sağlar. Fonksiyonun işlevleri şunlardır:

HiringBookFormViewModel nesnesi aracılığıyla gelen bilgileri alır: kitabın adı, ödünç alan kişinin adı, ve geri getirme tarihi.
Veritabanında bu bilgilere dayalı olarak yeni bir kayıt oluşturur.
Bu fonksiyon da asenkron bir şekilde çalışır ve ödünç alma işlemini gerçekleştirir.
