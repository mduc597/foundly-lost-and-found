# Kịch bản thuyết trình Sprint 1 (5–7 phút)

## 1. Nêu vấn đề (45 giây)
"Nội dung tìm đồ trên Facebook thường bị trôi và nằm ở nhiều nhóm khác nhau. Sprint 1 tập trung giải quyết hai nút thắt: tạo dữ liệu có cấu trúc và tìm kiếm lại dễ dàng."

## 2. Mục tiêu và phạm vi (45 giây)
- Sprint 1, tuần 1, P0, 5 mã US-01 đến US-05.
- Phạm vi: đăng tin, danh sách, tìm kiếm, lọc, chi tiết.
- Các module Matching, xác minh, chat, hẹn bàn giao, Admin thuộc giai đoạn sau, không nhận là kết quả tuần 1.

## 3. Kiến trúc (45 giây)
- React frontend (5 component độc lập theo US).
- ASP.NET Core xử lý validation/CRUD và truy vấn.
- PostgreSQL lưu 4 bảng chính; Docker Compose khởi chạy 3 dịch vụ.

## 4. Demo trực tiếp (3 phút)
1. Mở `http://localhost:5181`, đăng nhập Minh.
2. US-01: nhập một ví bị mất đủ danh mục/thời gian/khu vực → Đăng tin.
3. US-02: xem bài mới ở danh sách.
4. US-03: nhập `ví` → tìm thấy bài vừa tạo.
5. US-04: lọc đúng danh mục Ví & túi và khu vực.
6. US-05: mở chi tiết, cho thấy mô tả/thời gian/trạng thái.
7. Nếu còn thời gian: thử bỏ danh mục để chứng minh validation; sửa hoặc xóa bài của chính mình.

## 5. Tiêu chí & tổng kết (45 giây)
- Đối chiếu các dòng nghiệm thu trong `03_kiem_thu_nghiem_thu.md`.
- Chỉ báo đạt các trường hợp đã thử thành công trên máy.
- Chuẩn bị cho Sprint sau: Matching và thông báo sẽ dùng dữ liệu bài đã được chuẩn hóa từ Sprint 1.

## Câu hỏi giảng viên có thể hỏi

**Vì sao không triển khai Matching trong Sprint 1?** Vì chưa có bài đăng thì Matching không có dữ liệu để hoạt động; chức năng P0 là tạo dữ liệu và tra cứu.

**Tìm kiếm chạy ở frontend hay backend?** Backend áp dụng `ILIKE` tại PostgreSQL, có phân trang; frontend chỉ gửi query.

**Vì sao cần bảng danh mục và vị trí?** Để lọc chính xác theo dữ liệu chuẩn, tránh người dùng gõ nhiều cách khác nhau.

**Đăng tin thiếu dữ liệu thì sao?** HTML form kiểm tra sơ bộ; ASP.NET Core kiểm tra lại và trả HTTP 400 nếu sai.

**Đây có phải commit được làm từ tuần 1?** Không. Đây là bản phân rã từ code hiện có để minh họa ranh giới Sprint 1. Bằng chứng tiến độ thực là Issues/commit theo ngày và phần việc thành viên thực hiện.
