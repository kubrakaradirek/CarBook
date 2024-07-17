# CarBook Araç Kiralama Projesi
Bu proje, ASP.NET Core 8.0 kullanılarak geliştirilmiş bir Web API ve MVC uygulamasıdır. Onion mimarisi kullanılarak tasarlanmış olup, "Asp.Net Core Api 8.0 Onion Architecture ile BookCar Projesi
" adlı Murat Yücedağ'ın udemy  kursu ile geliştirilmiştir. CarBook, araç kiralama işlemlerinin gerçekleştirildiği, araç fiyatlarının listelendiği ve araçlar hakkında detaylı bilgi alınabildiği bir web uygulamasıdır. Backend tarafında Onion, CQRS ve Mediator desenleri uygulanmıştır. MSSQL veritabanı kullanılmış ve kullanıcı/rol yetkilendirmeleri JWT ile sağlanmıştır.Admin paneli için ayrı bir vitrin oluşturulmuştur.Rezervasyon işlemi gerçekleştirme, araca ait özellikleri,yorumları görebilme, seçilen lokasyona göre müsait araçları görme,bloglara yorum yapma,üye olma,bizw ulaşın kısmından mesaj gönderme gibi daha bir çok işlemleri içerir.Admin panelinde ise tüm işlevler için crud işlemleri ve blog yazarları, bir sürü ayrıntılı işlevlere sahiptir.Aşağıdaki fotoğraflardan panelleri inceleyebilirsiniz.

## Proje Şeması:

- CarBook.Domain: Temel varlıkları ve iş mantığını içerir.
- CarBook.Application: DTO'ları, enumları, CQRS, Mediator, repository tasarım desenini ve doğrulama kurallarını içerir.

- CarBook.Persistence: Repository sınıflarını ve veritabanı işlemlerini gerçekleştirir.

- CarBook.WebApi: API metodlarını barındırır ve dış dünyayla iletişim sağlar.

- CarBook.Dto: Frontend ile eşleşecek DTO (Data Transfer Object) yapılarını sağlar.

- CarBook.WebUI: MVC ile tasarlanmış kullanıcı arayüzüdür. Admin paneli için ayrı bir alan (area) kullanılmıştır.
## Kullanılan Teknolojiler:

- ASP.NET Core 8
- Web API
- Onion Architecture
- CQRS Pattern
- Mediator Pattern
- Repository Pattern
- MSSQL
- Bootstrap
- JWT (JSON Web Token)
- SignalR
- Pivot Table
- Fluent Validation
- HTML/CSS
- JavaScript
- MVC


![1](https://github.com/user-attachments/assets/8e79e44f-f7d0-4198-964d-163fa8742d0c)
![2](https://github.com/user-attachments/assets/c640e67e-fc85-4f82-91f0-5ceb166301f9)
![3](https://github.com/user-attachments/assets/23bc99b9-754f-4e9e-ba82-0d8ecf70712e)
![4](https://github.com/user-attachments/assets/9670da1f-b934-48b2-87f4-6e32a710639d)
![5](https://github.com/user-attachments/assets/a4f5e5f8-1296-4bea-b046-29ef84e24e0f)
![27](https://github.com/user-attachments/assets/b62e886e-4029-4300-a54c-905cb99d03ff)
![6](https://github.com/user-attachments/assets/af58b297-c714-47df-a1a5-a9ed68a1e864)
![7](https://github.com/user-attachments/assets/1229a2fd-2550-4d13-93e4-a930b06addc2)
![8](https://github.com/user-attachments/assets/d84b3bc5-f59a-4b28-b086-b40111641b7e)
![9](https://github.com/user-attachments/assets/354e4e69-4e33-42b5-b480-6479d0b1cdc7)
![10](https://github.com/user-attachments/assets/9d54fa9e-333b-4818-9bfa-4d54351350fd)
![11](https://github.com/user-attachments/assets/dae3db10-79df-4783-9276-72c9cec2a39a)
![12](https://github.com/user-attachments/assets/7cb48782-6d61-4302-ba5b-50aad84c457c)
![13](https://github.com/user-attachments/assets/cc51e55c-91eb-4690-b02a-cc9b743702b2)
![14](https://github.com/user-attachments/assets/99f0a221-3cb4-4ded-985d-ee7de31a3a44)
![15](https://github.com/user-attachments/assets/a9fcfc2d-9981-401f-b92a-33feff896308)
![16](https://github.com/user-attachments/assets/2b8b796d-605b-4cf6-be4d-e9fd6f3476b2)
![Ekran görüntüsü 2024-07-17 100931](https://github.com/user-attachments/assets/2c84d782-1b69-4b50-a067-288f7f8a4a08)
![Ekran görüntüsü 2024-07-17 100942](https://github.com/user-attachments/assets/82a9d37f-ea2e-4fc8-b922-4bd784cc8444)
![18](https://github.com/user-attachments/assets/999ddaa4-4927-463c-9bb9-39a2aa3951ea)
![19](https://github.com/user-attachments/assets/3c009750-0c9f-49df-b0f1-425ba385fc85)
![20](https://github.com/user-attachments/assets/565a47d6-9fd2-48ef-94cc-cec3f2570ed4)
![21](https://github.com/user-attachments/assets/6a2e3865-eac2-4464-8cfa-d3cd3ed8ac34)
![22](https://github.com/user-attachments/assets/14b8d83a-7297-4b04-83d0-d7288ddec7b4)
![23](https://github.com/user-attachments/assets/667e4590-789d-4e53-bdc7-e3c397f24029)
![24](https://github.com/user-attachments/assets/3295f933-8dfb-4ef8-a821-ae9058d5cf26)
![25](https://github.com/user-attachments/assets/467ead60-2261-4e66-9778-7247e46cd242)
![26](https://github.com/user-attachments/assets/03c3373c-9e7a-4426-82ed-e6e5bd630040)
![Ekran görüntüsü 2024-07-16 185243](https://github.com/user-attachments/assets/e886fa25-9919-412c-aaf9-6cf3bb5b3345)
![Ekran görüntüsü 2024-07-16 185213](https://github.com/user-attachments/assets/1e1513b4-297e-45cb-947b-bfa7d3c08e8a)
