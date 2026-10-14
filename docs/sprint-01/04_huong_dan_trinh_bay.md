
# HƯỚNG DẪN TRÌNH BÀY SPRINT 1

**Dự án:** Foundly – Hệ thống quản lý và tìm kiếm đồ thất lạc  
**Sprint:** 1 – Xây dựng chức năng cốt lõi  
**Thời lượng gợi ý:** 6–8 phút

## 1. Phân chia nội dung trình bày

| Người trình bày | Nội dung | Thời lượng gợi ý |
|---|---|---|
| **Nguyễn Minh Đức** | Mục tiêu, phạm vi Sprint, bảng phân công và tiến độ | 1 phút |
| **Lê Gia Hoàng** | 5 User Story P0 và Acceptance Criteria | 1 phút |
| **Nguyễn Anh Đức** | Demo giao diện US-01 đến US-05 | 2 phút |
| **Hoàng Doãn Khiêm** | Giải thích API, luồng thêm bài và tìm kiếm | 1 phút |
| **Phạm Việt Anh** | Giải thích 4 bảng PostgreSQL, quan hệ và minh chứng lưu dữ liệu | 1 phút |

Dành thêm 1–2 phút cho kết quả nghiệm thu và câu hỏi của giảng viên.

## 2. Nội dung mở đầu

> Trong Sprint 1, nhóm em tập trung giải quyết khó khăn khi tìm đồ thất lạc qua bài đăng Facebook: thông tin dễ bị trôi và phân tán. Vì vậy, nhóm ưu tiên 5 chức năng P0: đăng tin, danh sách, tìm kiếm, bộ lọc và xem chi tiết. Theo kế hoạch phân công, các đầu việc triển khai hiện được nhóm đánh dấu hoàn thành.

## 3. Demo trực tiếp

1. Truy cập `http://localhost:5181`; đăng nhập tài khoản demo.
2. **US-01:** Tạo bài LOST hoặc FOUND, chọn danh mục, khu vực, thời gian, nhập mô tả rồi đăng.
3. **US-02:** Xác nhận bài vừa tạo xuất hiện trong danh sách, mới nhất trước.
4. **US-03:** Nhập từ khóa có trong tên hoặc mô tả của bài vừa đăng.
5. **US-04:** Chọn bộ lọc danh mục, khu vực và ngày đăng để thu hẹp kết quả.
6. **US-05:** Nhấn `Xem chi tiết` và chỉ các trường tên, mô tả, trạng thái, thời gian, địa điểm.
7. Nếu còn thời gian, thử gửi form thiếu danh mục để minh họa kiểm tra dữ liệu.
8. Mở PostgreSQL bằng Terminal để cho thấy bài vừa tạo thực sự nằm trong bảng `Reports`.

## 4. Giải thích kiến trúc

```text
React (localhost:5181)
       ↓ HTTP / JSON
ASP.NET Core Web API (localhost:8081)
       ↓ Entity Framework Core
PostgreSQL (database sprint1)
```

- **React:** biểu mẫu và giao diện từng User Story.
- **ASP.NET Core:** kiểm tra dữ liệu, quyền sửa/xóa, API CRUD, tìm kiếm và lọc.
- **PostgreSQL:** lưu `Students`, `Reports`, `Categories`, `Locations`.
- **Docker Compose:** khởi động ba dịch vụ trong môi trường localhost.

## 5. Giải thích phần việc của mỗi thành viên

- **Lê Gia Hoàng:** phụ trách xác định yêu cầu, User Story, Acceptance Criteria và Product Backlog.
- **Nguyễn Minh Đức:** phụ trách GitHub Project, Issues, kế hoạch và theo dõi tiến độ.
- **Nguyễn Anh Đức:** phụ trách frontend và các giao diện tương ứng với 5 US.
- **Hoàng Doãn Khiêm:** phụ trách API và xử lý nghiệp vụ phía backend.
- **Phạm Việt Anh:** phụ trách lược đồ dữ liệu và PostgreSQL.

Lưu ý: bảng trên thể hiện **phân công/trách nhiệm**. Để chứng minh đóng góp thực tế, xuất trình Issues, Pull Requests và lịch sử commit nếu giảng viên yêu cầu.

## 6. Câu hỏi giảng viên có thể hỏi

**Dữ liệu bài đăng được lưu ở đâu?** Trong PostgreSQL, bảng `Reports`; không phải LocalStorage hay mảng cố định trên React.

**Vì sao Sprint 1 chưa có Matching?** Vì cần ưu tiên xây dựng nguồn dữ liệu bài đăng và khả năng tra cứu trước. Matching, thông báo và bàn giao thuộc các Sprint sau.

**Tìm kiếm xử lý ở đâu?** Backend áp dụng tìm kiếm bằng PostgreSQL `ILIKE`, kết hợp phân trang; frontend chỉ gửi điều kiện tìm kiếm.

**Làm thế nào để chứng minh dữ liệu đã lưu?** Đăng bài trên web, sau đó truy vấn bảng `Reports` bằng `psql` để thấy bản ghi mới.

**Toàn bộ Sprint đã được kiểm thử đạt chưa?** Mã nguồn 5 US đã hoàn thiện theo cập nhật nhóm; kết quả nghiệm thu cần đối chiếu ảnh/log chạy thực tế trong tài liệu kiểm thử. Không dùng việc đã upload code làm bằng chứng thay thế.

## 7. Kết luận trình bày

> Sprint 1 đã hoàn thành phạm vi triển khai 5 chức năng P0, hình thành luồng đăng tin – lưu PostgreSQL – danh sách – tìm kiếm/lọc – xem chi tiết. Đây là nền tảng cho các chức năng Matching và trao trả trong những Sprint tiếp theo.
