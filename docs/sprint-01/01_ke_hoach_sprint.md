
# SPRINT 1 – XÂY DỰNG CHỨC NĂNG CỐT LÕI

**Dự án:** Foundly – Hệ thống quản lý và tìm kiếm đồ thất lạc trong trường đại học  
**Thời gian:** Tuần 1  
**Ưu tiên:** P0 – Cao nhất  
**Trạng thái công việc:** Hoàn thành (theo cập nhật của nhóm)

## 1. Mục tiêu

Xây dựng phiên bản đầu tiên để sinh viên đăng tin mất/nhặt được đồ, xem danh sách, tìm kiếm và lọc bài đăng tại một nơi. Sprint 1 giải quyết tình trạng thông tin phân tán, khó tìm lại do các bài đăng trong nhóm Facebook bị trôi.

## 2. Sprint Backlog

| Mã | Chức năng | Yêu cầu chính | Ưu tiên | Trạng thái |
|---|---|---|---|---|
| US-01 | Đăng tin nhanh | Chọn LOST/FOUND, tên, danh mục, mô tả, thời gian và khu vực | P0 | Hoàn thành |
| US-02 | Danh sách bài đăng | Hiển thị các bài đang mở, mới nhất trước, có phân trang | P0 | Hoàn thành |
| US-03 | Tìm kiếm từ khóa | Tìm theo tên hoặc mô tả vật phẩm | P0 | Hoàn thành |
| US-04 | Bộ lọc | Lọc theo danh mục, ngày đăng, khu vực và loại tin | P0 | Hoàn thành |
| US-05 | Xem chi tiết | Xem đầy đủ mô tả, thời gian, khu vực và trạng thái | P0 | Hoàn thành |

*US-01 đến US-05 là mã quản lý nhiệm vụ trong Sprint, không nhất thiết trùng mã User Story gốc của tài liệu môn học.*

## 3. Công việc kỹ thuật

- **Frontend:** React; tách 5 chức năng thành các component riêng trong `sprint-01-demo/web/src/features/`.
- **Backend:** ASP.NET Core Web API cho đăng bài, CRUD cơ bản, danh sách, tìm kiếm và lọc.
- **Database:** PostgreSQL với 4 bảng `Students`, `Reports`, `Categories`, `Locations`.
- **Ràng buộc:** Kiểm tra trường bắt buộc ở biểu mẫu và API; chỉ chủ bài được sửa/xóa.
- **Triển khai:** Docker Compose chạy website, API và PostgreSQL độc lập với Foundly hoàn chỉnh.

## 4. Kết quả bàn giao

- [x] Có chức năng đăng tin LOST và FOUND.
- [x] Có API lưu bài đăng vào PostgreSQL.
- [x] Có danh sách bài đăng mới nhất, phân trang.
- [x] Có tìm kiếm theo từ khóa.
- [x] Có bộ lọc theo danh mục, ngày, khu vực và loại tin.
- [x] Có trang xem chi tiết bài đăng.
- [x] Mã nguồn Sprint 1 đã được tách và đưa vào repository.

**Mã nguồn:** [`sprint-01-demo`](../../sprint-01-demo/)  
**Kiểm thử:** [03_kiem_thu_nghiem_thu.md](03_kiem_thu_nghiem_thu.md)

## 5. Tiêu chí nghiệm thu

| Tiêu chí | Điều kiện đạt |
|---|---|
| Đăng tin | Dữ liệu hợp lệ được lưu vào bảng `Reports` |
| Kiểm tra đầu vào | Thiếu danh mục/trường bắt buộc thì báo lỗi và không lưu |
| Danh sách | Bài mới xuất hiện sau khi đăng thành công |
| Tìm kiếm | Nhập từ khóa phù hợp thì trả về bài liên quan |
| Bộ lọc | Chỉ hiển thị bài đáp ứng danh mục/ngày/khu vực đã chọn |
| Chi tiết | Hiển thị đúng tên, mô tả, thời gian, khu vực và trạng thái |

## 6. Tổng kết

Theo cập nhật của nhóm, **5/5 hạng mục P0 đã hoàn thành về mặt triển khai**. Nhóm cần lưu ảnh, log hoặc kết quả kiểm thử trên localhost vào hồ sơ nghiệm thu để xác nhận chất lượng vận hành, không chỉ dựa vào trạng thái nhiệm vụ.

**Ngoài phạm vi Sprint 1:** Matching, thông báo, xác minh, chat, phòng bàn giao và Admin; các chức năng này thuộc những Sprint sau.
