# HƯỚNG DẪN TRÌNH BÀY SPRINT 1

**Dự án:** Foundly – Hệ thống quản lý và tìm kiếm đồ thất lạc  
**Sprint:** 1 – Xây dựng chức năng cốt lõi  
**Thời lượng dự kiến:** 15 phút

## 1. Nội dung trình bày

- Giới thiệu dự án Foundly và vấn đề cần giải quyết.
- Trình bày mục tiêu Sprint 1 và 5 User Story P0.
- Giới thiệu kết quả triển khai.
- Demo trực tiếp các chức năng US-01 đến US-05.
- Giải thích kiến trúc hệ thống và cơ sở dữ liệu.
- Tổng kết kết quả Sprint và định hướng phát triển.

## 2. Giới thiệu Sprint 1

Trong Sprint 1, nhóm tập trung xây dựng 5 chức năng cốt lõi:

| Mã | Chức năng | Trạng thái |
|---|---|---|
| US-01 | Đăng tin nhanh | Hoàn thành |
| US-02 | Hiển thị danh sách bài đăng | Hoàn thành |
| US-03 | Tìm kiếm theo từ khóa | Hoàn thành |
| US-04 | Bộ lọc tìm kiếm | Hoàn thành |
| US-05 | Xem chi tiết bài đăng | Hoàn thành |

Các chức năng được ưu tiên vì tạo nền tảng cho quá trình đăng tin, lưu trữ và tìm kiếm thông tin đồ thất lạc.

## 3. Demo trực tiếp

**Website:** http://localhost:5181

1. **US-01:** Đăng nhập, tạo bài LOST hoặc FOUND với đầy đủ thông tin.
2. **US-02:** Kiểm tra bài vừa tạo xuất hiện trong danh sách.
3. **US-03:** Nhập từ khóa để tìm kiếm bài đăng.
4. **US-04:** Lọc theo danh mục, khu vực và ngày đăng.
5. **US-05:** Mở chi tiết bài đăng để xem đầy đủ thông tin.
6. **Database:** Truy vấn bảng `Reports` trong PostgreSQL để chứng minh dữ liệu được lưu thực tế.

## 4. Kiến trúc hệ thống

```text
React Frontend
       ↓ HTTP / JSON
ASP.NET Core Web API
       ↓ Entity Framework Core
PostgreSQL Database
```

- **React:** Hiển thị giao diện và tiếp nhận thao tác người dùng.
- **ASP.NET Core:** Xử lý nghiệp vụ, kiểm tra dữ liệu và cung cấp API.
- **PostgreSQL:** Lưu trữ thông tin bài đăng, sinh viên, danh mục và khu vực.
- **Docker:** Triển khai các thành phần trên localhost.

## 5. Kết quả Sprint 1

- Hoàn thành mã nguồn 5/5 User Story P0.
- Xây dựng giao diện đăng tin và tìm kiếm đồ thất lạc.
- Tích hợp Frontend, Backend và PostgreSQL.
- Xây dựng API lưu trữ, truy vấn và quản lý bài đăng.
- Đưa mã nguồn và tài liệu Sprint 1 lên GitHub.

Kết quả kiểm thử và minh chứng nghiệm thu được quản lý trong `03_kiem_thu_nghiem_thu.md`.

## 6. Câu hỏi giảng viên có thể hỏi

**Câu 1: Dữ liệu được lưu ở đâu?**

Dữ liệu được lưu trong PostgreSQL, chủ yếu ở bảng `Reports`.

**Câu 2: Vì sao chưa triển khai Matching?**

Vì Sprint 1 ưu tiên xây dựng nguồn dữ liệu và khả năng tìm kiếm. Matching thuộc phạm vi Sprint tiếp theo.

**Câu 3: Làm sao chứng minh dữ liệu được lưu thật?**

Đăng bài mới trên website, sau đó truy vấn bảng `Reports` trong PostgreSQL.

**Câu 4: Vì sao sử dụng PostgreSQL thay vì LocalStorage?**

PostgreSQL hỗ trợ lưu trữ dữ liệu tập trung, quản lý quan hệ và cho phép nhiều người dùng truy cập.

**Câu 5: Nhóm quản lý tiến độ bằng cách nào?**

Sử dụng GitHub Repository, Issues, Sprint Backlog và theo dõi trạng thái công việc.

## 7. Tổng kết

Sprint 1 đã hoàn thành phạm vi triển khai 5 chức năng cốt lõi, tạo nền tảng để phát triển các nghiệp vụ nâng cao như Matching, thông báo, xác minh chủ sở hữu và bàn giao tài sản trong những Sprint tiếp theo.
