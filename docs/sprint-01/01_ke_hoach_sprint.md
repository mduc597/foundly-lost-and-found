
# SPRINT 1 – XÂY DỰNG CHỨC NĂNG CỐT LÕI

**Dự án:** Foundly – Hệ thống quản lý và tìm kiếm đồ thất lạc trong trường đại học  
**Thời gian:** Tuần 1  
**Ưu tiên:** P0 – Cao nhất  
**Trạng thái công việc:** 5 hạng mục hoàn thành, 1 hạng mục chờ xác nhận

## 1. Mục tiêu

Xây dựng phiên bản đầu tiên để sinh viên có thể đăng ký tài khoản, đăng nhập, đăng xuất, đăng tin mất/nhặt được đồ, xem danh sách, tìm kiếm và lọc bài đăng tại một nơi.

Sprint 1 giải quyết tình trạng thông tin phân tán, khó tìm lại do các bài đăng trong nhóm Facebook bị trôi.

Đồng thời, hệ thống cung cấp chức năng xác thực tài khoản để quản lý người đăng tin, bảo vệ thông tin người dùng và đảm bảo chỉ người dùng đã đăng nhập mới có quyền đăng bài.

## 2. Sprint Backlog

| Mã | Chức năng | Yêu cầu chính | Ưu tiên | Trạng thái |
|---|---|---|---|---|
| US-00 | Đăng ký, đăng nhập, đăng xuất | Tạo tài khoản, xác thực email và mật khẩu, quản lý phiên đăng nhập | P0 | Hoàn thành |
| US-01 | Đăng tin nhanh | Chọn LOST/FOUND, tên, danh mục, mô tả, thời gian và khu vực | P0 | Hoàn thành |
| US-02 | Danh sách bài đăng | Hiển thị các bài đang mở, mới nhất trước, có phân trang | P0 | Hoàn thành |
| US-03 | Tìm kiếm từ khóa | Tìm theo tên hoặc mô tả vật phẩm | P0 | Hoàn thành |
| US-04 | Bộ lọc | Lọc theo danh mục, ngày đăng, khu vực và loại tin | P0 | Hoàn thành |
| US-05 | Xem chi tiết | Xem đầy đủ mô tả, thời gian, khu vực và trạng thái | P0 | Hoàn thành |

*US-00 đến US-05 là mã quản lý nhiệm vụ trong Sprint, không nhất thiết trùng mã User Story gốc của tài liệu môn học.*

## 3. Công việc kỹ thuật

- **Frontend:** React; tách các chức năng thành component riêng trong `sprint-01-demo/web/src/features/`. Bổ sung giao diện đăng ký, đăng nhập và chức năng đăng xuất.
- **Backend:** ASP.NET Core Web API cho đăng ký, đăng nhập, đăng xuất, xác thực người dùng, đăng bài, CRUD cơ bản, danh sách, tìm kiếm và lọc.
- **Database:** PostgreSQL với 4 bảng `Students`, `Reports`, `Categories`, `Locations`. Bảng `Students` quản lý thông tin tài khoản và dữ liệu phục vụ xác thực.
- **Xác thực:** Kiểm tra email, mật khẩu; không cho phép đăng ký email trùng; lưu mật khẩu dưới dạng hash an toàn; quản lý phiên đăng nhập.
- **Phân quyền:** Chỉ người dùng đã đăng nhập mới được đăng bài; chỉ chủ bài được sửa/xóa bài đăng.
- **Ràng buộc:** Kiểm tra trường bắt buộc ở biểu mẫu và API; thông báo lỗi khi thông tin đăng ký hoặc đăng nhập không hợp lệ.
- **Triển khai:** Docker Compose chạy website, API và PostgreSQL độc lập với Foundly hoàn chỉnh.

## 4. Kết quả bàn giao

### Chức năng tài khoản

- [ ] Có giao diện đăng ký tài khoản.
- [ ] Có chức năng đăng nhập bằng email và mật khẩu.
- [ ] Có chức năng đăng xuất.
- [ ] Có API đăng ký, đăng nhập và xác thực.
- [ ] Thông tin tài khoản được lưu an toàn trong PostgreSQL.
- [ ] Người dùng chưa đăng nhập không thể đăng tin.

### Chức năng quản lý đồ thất lạc

- [x] Có chức năng đăng tin LOST và FOUND.
- [x] Có API lưu bài đăng vào PostgreSQL.
- [x] Có danh sách bài đăng mới nhất, phân trang.
- [x] Có tìm kiếm theo từ khóa.
- [x] Có bộ lọc theo danh mục, ngày, khu vực và loại tin.
- [x] Có trang xem chi tiết bài đăng.
- [x] Mã nguồn Sprint 1 đã được tách và đưa vào repository.

**Lưu ý:** Các mục tài khoản đang để chưa xác nhận, cần cập nhật sau khi kiểm tra chức năng trong mã nguồn Sprint 1.

**Mã nguồn:** [`sprint-01-demo`](../../sprint-01-demo/)  
**Kiểm thử:** [03_kiem_thu_nghiem_thu.md](03_kiem_thu_nghiem_thu.md)

## 5. Tiêu chí nghiệm thu

| Tiêu chí | Điều kiện đạt |
|---|---|
| Đăng ký | Người dùng nhập thông tin hợp lệ và tạo tài khoản thành công |
| Email trùng | Hệ thống từ chối đăng ký nếu email đã tồn tại |
| Đăng nhập | Email và mật khẩu chính xác cho phép truy cập tài khoản |
| Sai thông tin đăng nhập | Hiển thị thông báo lỗi phù hợp |
| Đăng xuất | Phiên đăng nhập kết thúc, chức năng yêu cầu xác thực không còn truy cập được |
| Bảo mật mật khẩu | Mật khẩu không được lưu dưới dạng văn bản thuần |
| Phân quyền | Người dùng chưa đăng nhập không thể đăng bài |
| Đăng tin | Dữ liệu hợp lệ được lưu vào bảng `Reports` |
| Kiểm tra đầu vào | Thiếu danh mục/trường bắt buộc thì báo lỗi và không lưu |
| Danh sách | Bài mới xuất hiện sau khi đăng thành công |
| Tìm kiếm | Nhập từ khóa phù hợp thì trả về bài liên quan |
| Bộ lọc | Chỉ hiển thị bài đáp ứng danh mục/ngày/khu vực đã chọn |
| Chi tiết | Hiển thị đúng tên, mô tả, thời gian, khu vực và trạng thái |

## 6. Tổng kết

Sprint 1 bao gồm **6 hạng mục chức năng P0**, trong đó:

- **US-00:** Đăng ký, đăng nhập và đăng xuất.
- **US-01:** Đăng tin nhanh.
- **US-02:** Danh sách bài đăng.
- **US-03:** Tìm kiếm từ khóa.
- **US-04:** Bộ lọc.
- **US-05:** Xem chi tiết bài đăng.

Theo cập nhật của nhóm, **5/6 hạng mục P0 đã hoàn thành về mặt triển khai**. Hạng mục US-00 được bổ sung vào kế hoạch và cần xác nhận kết quả triển khai, kiểm thử.

Nhóm cần lưu ảnh, log hoặc kết quả kiểm thử trên localhost vào hồ sơ nghiệm thu để xác nhận chất lượng vận hành, không chỉ dựa vào trạng thái nhiệm vụ.

Khi US-00 được xác nhận hoạt động đúng và đáp ứng Acceptance Criteria, Sprint 1 có thể được cập nhật thành **6/6 hạng mục P0 hoàn thành**.


