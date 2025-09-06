# Coding Style & Architecture Guidelines (.NET 8 / C# 12)

## ✅ C# 12 Conventions
- **Sử dụng các tính năng mới của C# 12 khi phù hợp:**
  - `required` properties cho các thuộc tính bắt buộc.
  - Primary constructors cho các class bất biến hoặc value object.
  - Collection expressions như `[..items]`, `[1, 2, ..moreItems]`.
- **Ưu tiên `var`** khi kiểu dữ liệu rõ ràng từ context.
  - ❌ Tránh dùng `var` với các kiểu phức tạp như generics hoặc delegates.

## ✅ Coding Style
- Sử dụng **file-scoped namespaces**.
- Mỗi file chỉ nên chứa **một class, interface, hoặc record**.
- **Thứ tự thành phần trong class**:
  1. Fields
  2. Constructors
  3. Public methods
  4. Protected methods
  5. Private methods
- **Quy tắc đặt tên:**
  - PascalCase cho class, interface, method, property.
  - camelCase cho biến và tham số.
- Giới hạn phương thức:
  - Dưới **20 dòng**.
  - Tối đa **4 tham số** (sử dụng object nếu cần nhiều hơn).
- Sử dụng **expression-bodied members** cho những method/property đơn giản.

## ✅ Kiến trúc & Tổ chức thư mục (Layered Architecture)
- Chỉ sử dụng **1 project duy nhất** với cấu trúc theo layer:
  - `Controllers/`: Giao tiếp HTTP
  - `Services/`: Xử lý nghiệp vụ
  - `Repositories/`: Truy cập dữ liệu
  - `UnitOfWork/`: Quản lý transaction
  - `Models/`: Domain Entities
- Đặt interface trong `Interfaces/`, `Abstractions/`, hoặc `Contracts/`.

## ✅ Quy tắc cho Controllers
- **Giữ controller mỏng (thin controller)**:
  - ❌ Không chứa logic nghiệp vụ.
  - ✅ Gọi Service Layer để xử lý chính.
  - Sử dụng DTO cho input/output.
- Không sử dụng **Minimal API**.

## ✅ Quy tắc cho Business Logic
- Logic nghiệp vụ chỉ nằm trong **Service Layer**.
- Repository chỉ chịu trách nhiệm truy xuất dữ liệu.
- Sử dụng **Dependency Injection** để inject service, repository, và unit of work.
- Không cho phép code hạ tầng (như `DbContext`) xuất hiện trong domain hoặc services.

## ✅ Bình luận và Đọc hiểu
- Code nên **tự giải thích**.
- Chỉ thêm comment khi:
  - Logic phức tạp, khó hiểu.
  - Có side effect hoặc quyết định kỹ thuật cần làm rõ.
- ❌ Không comment những điều hiển nhiên; viết code rõ ràng hơn.

