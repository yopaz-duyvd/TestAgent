# TruyenVerse API - Web App đọc truyện chữ (.NET 8)

Dự án này là một **Web API xây dựng bằng .NET 8**, áp dụng triệt để các nguyên tắc **SOLID**, **Clean Architecture**, và các best practices trong phát triển phần mềm hiện đại. Mục tiêu là cung cấp một hệ thống **dịch vụ backend cho nền tảng đọc truyện chữ trực tuyến**, có khả năng mở rộng, bảo trì và tích hợp dễ dàng.

> Được thiết kế và triển khai bởi một lập trình viên .NET với hơn 20 năm kinh nghiệm thực chiến trong các hệ thống lớn và phức tạp.

---

## 🏗️ Công nghệ sử dụng

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- AutoMapper
- FluentValidation
- JWT Authentication & Authorization
- Swagger (Swashbuckle)
- PostgreSQL hoặc SQL Server (tuỳ chọn)
- In-memory event bus (có thể mở rộng sang RabbitMQ)

---

## 🎯 Tính năng chính

### 1. 👤 Quản lý người dùng
- Đăng ký, đăng nhập với JWT token
- Quên mật khẩu, thay đổi mật khẩu
- Cập nhật thông tin cá nhân
- Xác thực qua email (tuỳ chọn)

### 2. 📚 Quản lý truyện & chương
- Tạo, sửa, xoá truyện
- Tạo, sửa, xoá chương truyện
- Phân quyền: chỉ chủ truyện hoặc admin có quyền chỉnh sửa

### 3. ⭐ Theo dõi truyện
- Người dùng có thể theo dõi/unfollow truyện
- API hiển thị danh sách truyện đang theo dõi
- Tự động thông báo khi có chương mới

### 4. 🔔 Hệ thống thông báo
- Gửi thông báo khi có chương mới
- Gửi thông báo admin (hệ thống)
- API lấy danh sách thông báo chưa đọc

### 5. 🔐 Phân quyền và quản trị
- Hệ thống phân quyền theo role: `User`, `Moderator`, `Admin`
- Admin có thể:
  - Khoá tài khoản người dùng
  - Phân quyền tài khoản khác
  - Duyệt truyện nếu bật chế độ kiểm duyệt

---

## 💡 Một số chức năng nâng cao (gợi ý & sẽ triển khai)

- **Lịch sử đọc**: Ghi nhớ vị trí đọc gần nhất của người dùng
- **Bookmark chương**: Đánh dấu chương yêu thích
- **Gợi ý truyện theo thói quen đọc**
- **Tìm kiếm nâng cao**: Theo thể loại, tác giả, trạng thái hoàn thành
- **Dark Mode cho client** (nếu có frontend)
- **API thống kê**: Số lượt đọc, truyện hot trong tuần
- **Hệ thống reaction/emote cho chương**: Like, sad, funny, etc.

---

## 🧠 Định hướng kiến trúc

Dự án tuân thủ nghiêm ngặt theo:

### 🧱 Clean Architecture
- **Domain Layer**: Logic nghiệp vụ cốt lõi
- **Application Layer**: Use cases, services, interfaces
- **Infrastructure Layer**: Giao tiếp DB, file, email, v.v.
- **API Layer (Presentation)**: Controllers, Filters, Middleware

### 📐 SOLID Principles
- **S**ingle Responsibility: Mỗi class, service có một nhiệm vụ
- **O**pen/Closed: Dễ mở rộng, không sửa code cũ
- **L**iskov Substitution: Tuân thủ kế thừa đúng chuẩn
- **I**nterface Segregation: Interface nhỏ, tách biệt
- **D**ependency Inversion: Dùng DI, không phụ thuộc tầng dưới

---

## ⚙️ Triển khai & chạy thử

> Dự án đang được sinh tự động bằng Codex AI và sẽ tiếp tục hoàn thiện dần từng phần.

Sau khi có mã nguồn đầy đủ, bạn có thể:

```bash
dotnet restore
dotnet build
dotnet run
````

Truy cập Swagger UI tại: `https://localhost:5001/swagger`

---

## 📌 Lưu ý

* Tất cả endpoint sẽ được bảo vệ bằng JWT
* Admin APIs được phân quyền chặt chẽ
* Dữ liệu truyện/chương hiện tại sẽ lưu DB; có thể tích hợp cloud storage nếu có ảnh, file lớn

---

## 🔮 Định hướng tương lai

* Tích hợp hệ thống bình luận
* Notification real-time bằng SignalR
* Tích hợp CMS để quản lý truyện dễ dàng hơn
* Cung cấp SDK cho mobile/SPA frontend

---

## 🧑‍💻 Đóng góp

Đây là dự án mở. Nếu bạn có kinh nghiệm .NET, C#, hoặc muốn học thêm Clean Architecture, hãy cùng tham gia đóng góp!

---

**TruyenVerse API** – Nền tảng truyện chữ tương lai, viết bằng những gì tốt nhất của .NET hiện tại.

```
