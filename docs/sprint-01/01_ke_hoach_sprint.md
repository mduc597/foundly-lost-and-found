# SPRINT 1 — Xây dựng chức năng cốt lõi

**Thời gian:** Tuần 1  
**Mức độ ưu tiên:** P0 – Cao nhất

## 1. Mục tiêu

Xây dựng phiên bản đầu tiên cho phép sinh viên **đăng thông tin đồ thất lạc và tìm kiếm đồ đã được người khác đăng**. Dữ liệu được tập trung thay vì bị phân tán ở nhiều nhóm Facebook; thao tác đăng tin phải đơn giản để khuyến khích người nhặt sử dụng.

## 2. Danh sách chức năng

| STT | Mã công việc | Chức năng | Mô tả | Mức ưu tiên |
|---|---|---|---|---|
| 1 | US-01 | Đăng tin nhanh | Chọn danh mục, nhập mô tả, thời gian, khu vực và tên món đồ, chọn LOST/FOUND | P0 |
| 2 | US-02 | Danh sách bài đăng | Hiển thị bài đăng theo thứ tự rõ ràng, có phân trang | P0 |
| 3 | US-03 | Tìm kiếm | Tìm theo tên hoặc từ khóa trong mô tả | P0 |
| 4 | US-04 | Bộ lọc | Lọc danh mục, ngày đăng, khu vực; có tùy chọn LOST/FOUND | P0 |
| 5 | US-05 | Chi tiết | Xem mô tả, thời gian, địa điểm, trạng thái | P0 |

*Các mã US là mã quản lý công việc cho kế hoạch thực hiện, không thay thế định danh User Story gốc nếu tài liệu lớp có mã khác.*

## 3. Công việc kỹ thuật

- Thiết kế giao diện trang chủ, biểu mẫu đăng và danh sách bài.
- Thiết kế cơ sở dữ liệu `Student`, `Category`, `CampusLocation`, `ItemReport`.
- Xây dựng API CRUD: `GET/POST/PUT/DELETE /api/reports` và `GET /api/reports/{id}`.
- Tìm kiếm và lọc **tại PostgreSQL** để không lấy toàn bộ dữ liệu lên frontend.
- Kiểm tra bắt buộc: tên, loại tin, danh mục, mô tả, thời gian và khu vực.
- Thiết lập Docker Compose và tài khoản demo để trình bày.

## 4. Kết quả đầu ra yêu cầu

- [ ] Người dùng đăng được tin LOST hoặc FOUND.
- [ ] Tin hợp lệ được lưu vào PostgreSQL.
- [ ] Xem được danh sách tin còn hiệu lực.
- [ ] Tìm kiếm theo từ khóa và lọc theo danh mục, ngày đăng, khu vực.
- [ ] Xem chi tiết nội dung, trạng thái, thời gian và địa điểm.

*Chỉ tick khi đã chạy demo và có bằng chứng nghiệm thu; bản code không tự chứng minh các ô đã hoàn thành.*

## 5. Tiêu chí nghiệm thu

| Tiêu chí | Điều kiện đạt |
|---|---|
| Đăng tin | Tin hợp lệ được lưu thành công vào database |
| Kiểm tra dữ liệu | Thiếu danh mục hoặc trường bắt buộc → hiển thị lỗi, không lưu |
| Hiển thị | Tin vừa tạo xuất hiện trong danh sách |
| Tìm kiếm | Từ khóa phù hợp trả đúng tin liên quan |
| Bộ lọc | Chọn danh mục → chỉ còn bài thuộc danh mục tương ứng |
| Chi tiết | Hiển thị đủ tên, mô tả, khu vực, thời gian, trạng thái |

**Lý do ưu tiên P0:** Không có đăng tin thì không có dữ liệu; không có danh sách/tìm kiếm thì chưa giải quyết vấn đề bài Facebook bị trôi và phân tán.
