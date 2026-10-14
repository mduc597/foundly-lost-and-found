
# PHÂN CÔNG NHIỆM VỤ VÀ TIẾN ĐỘ SPRINT 1

**Dự án:** Foundly  
**Sprint:** 1 – Xây dựng chức năng cốt lõi  
**Thời gian:** Tuần 1  
**Trạng thái chung:** Hoàn thành 5/5 đầu việc (theo xác nhận của nhóm)

## 1. Bảng phân công

| Thành viên | Công việc cụ thể | Kết quả bàn giao | Trạng thái |
|---|---|---|---|
| **Lê Gia Hoàng** | Viết User Story, xác định Acceptance Criteria, sắp xếp Product Backlog | Hồ sơ US-01 đến US-05 và tiêu chí nghiệm thu | **Hoàn thành** |
| **Nguyễn Minh Đức** | Tạo GitHub Project, thiết lập Issues, phân công và theo dõi tiến độ | Repository, Sprint Backlog, báo cáo tiến độ | **Hoàn thành** |
| **Nguyễn Anh Đức** | Xây dựng giao diện trang chủ, form đăng tin, trang tìm kiếm | Giao diện React cho US-01 đến US-05 | **Hoàn thành** |
| **Hoàng Doãn Khiêm** | Xây dựng API đăng tin, danh sách và tìm kiếm | API ASP.NET Core và CRUD cơ bản | **Hoàn thành** |
| **Phạm Việt Anh** | Thiết kế CSDL, tạo bảng bài đăng và danh mục đồ | Mô hình dữ liệu và PostgreSQL lưu/truy vấn bài đăng | **Hoàn thành** |

## 2. Minh chứng tài liệu và mã nguồn

| Người phụ trách | File / đường dẫn tham chiếu |
|---|---|
| Lê Gia Hoàng | [`user-stories/`](user-stories/) và [tiêu chí nghiệm thu](03_kiem_thu_nghiem_thu.md) |
| Nguyễn Minh Đức | [Kế hoạch Sprint](01_ke_hoach_sprint.md), file báo cáo này, GitHub Project/Issues của nhóm |
| Nguyễn Anh Đức | [`web/src/features/`](../../sprint-01-demo/web/src/features/), [`web/src/App.jsx`](../../sprint-01-demo/web/src/App.jsx) |
| Hoàng Doãn Khiêm | [`api/Controllers/`](../../sprint-01-demo/api/Controllers/), [`api/Services/`](../../sprint-01-demo/api/Services/) |
| Phạm Việt Anh | [`api/Data/SprintDb.cs`](../../sprint-01-demo/api/Data/SprintDb.cs), [`api/Domain/Entities.cs`](../../sprint-01-demo/api/Domain/Entities.cs), [sơ đồ CSDL](05_so_do_du_lieu.md) |

## 3. Trạng thái 5 User Story

| US | Tên chức năng | Trạng thái triển khai |
|---|---|---|
| US-01 | Đăng tin nhanh | **Hoàn thành** |
| US-02 | Danh sách bài đăng | **Hoàn thành** |
| US-03 | Tìm kiếm theo từ khóa | **Hoàn thành** |
| US-04 | Bộ lọc tìm kiếm | **Hoàn thành** |
| US-05 | Xem chi tiết bài đăng | **Hoàn thành** |

**Sản phẩm bàn giao:** Bản demo cho phép đăng tin, xem danh sách, tìm kiếm, lọc và xem chi tiết đồ thất lạc; sử dụng PostgreSQL để lưu dữ liệu.

## 4. Đánh giá tiến độ và nghiệm thu

- **Tiến độ công việc:** 5/5 nhiệm vụ được đánh dấu Hoàn thành theo cập nhật của nhóm.
- **Tình trạng mã nguồn:** Có mã nguồn tương ứng cho toàn bộ 5 US trong repository.
- **Kiểm thử chức năng:** Các kịch bản và điều kiện đạt được liệt kê trong [03_kiem_thu_nghiem_thu.md](03_kiem_thu_nghiem_thu.md). Cần đính kèm ảnh/log kiểm thử thật trước khi khẳng định tất cả ca kiểm thử đã đạt.
- **Quản lý đóng góp:** Người phụ trách theo phân công không nhất thiết là người đã thực hiện commit tải mã nguồn ban đầu. Dùng Issues, Pull Requests và lịch sử Git để xác nhận đóng góp thực tế.

## 5. Kết luận

Sprint 1 đã hoàn thành **phạm vi triển khai** theo kế hoạch, làm nền tảng cho các Sprint tiếp theo (Matching, thông báo, xác minh và trao trả). Việc xác nhận nghiệm thu vận hành thực tế được thực hiện dựa trên kết quả demo và bằng chứng kiểm thử của nhóm.
