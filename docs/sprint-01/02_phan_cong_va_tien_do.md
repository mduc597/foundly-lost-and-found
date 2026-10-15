
# PHÂN CÔNG NHIỆM VỤ VÀ TIẾN ĐỘ SPRINT 1

**Dự án:** Foundly  
**Sprint:** 1 – Xây dựng chức năng cốt lõi  
**Thời gian:** Tuần 1  
**Trạng thái chung:** Hoàn thành 6/6 hạng mục (theo xác nhận của nhóm)

## 1. Bảng phân công

| Thành viên | Công việc cụ thể | Kết quả bàn giao | Trạng thái |
|---|---|---|---|
| **Lê Gia Hoàng** | Viết User Story, xác định Acceptance Criteria, sắp xếp Product Backlog; bổ sung US-00 về đăng ký, đăng nhập và đăng xuất | Hồ sơ US-00 đến US-05 và tiêu chí nghiệm thu | **Hoàn thành** |
| **Nguyễn Minh Đức** | Tạo GitHub Project, thiết lập Issues, phân công và theo dõi tiến độ; cập nhật US-00 vào Sprint Backlog | Repository, Sprint Backlog, Issues và báo cáo tiến độ | **Hoàn thành** |
| **Nguyễn Anh Đức** | Xây dựng giao diện trang chủ, form đăng tin, trang tìm kiếm; giao diện đăng ký, đăng nhập và đăng xuất | Giao diện React cho US-00 đến US-05, hỗ trợ responsive | **Hoàn thành** |
| **Hoàng Doãn Khiêm** | Xây dựng API đăng tin, danh sách, tìm kiếm, đăng ký, đăng nhập và xác thực người dùng | API ASP.NET Core, CRUD cơ bản và chức năng xác thực | **Hoàn thành** |
| **Phạm Việt Anh** | Thiết kế CSDL, tạo bảng bài đăng, danh mục đồ và quản lý dữ liệu tài khoản người dùng | Mô hình dữ liệu, PostgreSQL lưu tài khoản và bài đăng | **Hoàn thành** |

## 2. Minh chứng tài liệu và mã nguồn

| Người phụ trách | File / đường dẫn tham chiếu |
|---|---|
| Lê Gia Hoàng | [`user-stories/`](user-stories/) và [tiêu chí nghiệm thu](03_kiem_thu_nghiem_thu.md) |
| Nguyễn Minh Đức | [Kế hoạch Sprint](01_ke_hoach_sprint.md), file báo cáo này, GitHub Project/Issues của nhóm |
| Nguyễn Anh Đức | [`web/src/features/`](../../sprint-01-demo/web/src/features/), [`web/src/App.jsx`](../../sprint-01-demo/web/src/App.jsx) |
| Hoàng Doãn Khiêm | [`api/Controllers/`](../../sprint-01-demo/api/Controllers/), [`api/Services/`](../../sprint-01-demo/api/Services/) |
| Phạm Việt Anh | [`api/Data/SprintDb.cs`](../../sprint-01-demo/api/Data/SprintDb.cs), [`api/Domain/Entities.cs`](../../sprint-01-demo/api/Domain/Entities.cs), [sơ đồ CSDL](05_so_do_du_lieu.md) |

## 3. Trạng thái 6 User Story

| US | Tên chức năng | Trạng thái triển khai |
|---|---|---|
| US-00 | Đăng ký, đăng nhập và đăng xuất | **Hoàn thành** |
| US-01 | Đăng tin nhanh | **Hoàn thành** |
| US-02 | Danh sách bài đăng | **Hoàn thành** |
| US-03 | Tìm kiếm theo từ khóa | **Hoàn thành** |
| US-04 | Bộ lọc tìm kiếm | **Hoàn thành** |
| US-05 | Xem chi tiết bài đăng | **Hoàn thành** |

**Sản phẩm bàn giao:** Bản demo cho phép người dùng đăng ký, đăng nhập, đăng xuất, đăng tin LOST/FOUND, xem danh sách, tìm kiếm, lọc và xem chi tiết đồ thất lạc; sử dụng PostgreSQL để lưu dữ liệu.

## 4. Đánh giá tiến độ và nghiệm thu

- **Tiến độ công việc:** 6/6 hạng mục được đánh dấu Hoàn thành theo xác nhận của nhóm.
- **Tình trạng mã nguồn:** Nhóm xác nhận đã triển khai các chức năng US-00 đến US-05 trong dự án Foundly.
- **Chức năng xác thực:** US-00 bao gồm đăng ký tài khoản, đăng nhập, đăng xuất và kiểm soát quyền truy cập của người dùng.
- **Kiểm thử chức năng:** Các kịch bản và điều kiện đạt được liệt kê trong [03_kiem_thu_nghiem_thu.md](03_kiem_thu_nghiem_thu.md). Cần lưu bằng chứng kiểm thử thực tế để phục vụ nghiệm thu.
- **Quản lý đóng góp:** Người phụ trách theo phân công không nhất thiết là người đã thực hiện commit tải mã nguồn ban đầu. Dùng Issues, Pull Requests và lịch sử Git để xác nhận đóng góp thực tế.

### Tổng hợp kết quả Sprint 1

- [x] Hoàn thành hồ sơ User Story và Acceptance Criteria.
- [x] Hoàn thành quản lý Sprint Backlog và phân công nhiệm vụ.
- [x] Hoàn thành chức năng đăng ký, đăng nhập và đăng xuất.
- [x] Hoàn thành chức năng đăng tin LOST/FOUND.
- [x] Hoàn thành chức năng hiển thị danh sách bài đăng.
- [x] Hoàn thành chức năng tìm kiếm theo từ khóa.
- [x] Hoàn thành chức năng lọc bài đăng.
- [x] Hoàn thành chức năng xem chi tiết bài đăng.
- [x] Hoàn thành tích hợp Frontend, Backend và PostgreSQL.
- [x] Hoàn thành phạm vi triển khai Sprint 1 theo xác nhận của nhóm.

## 5. Kết luận

Sprint 1 đã hoàn thành **6/6 hạng mục chức năng P0 theo kế hoạch**, bao gồm:

- US-00: Đăng ký, đăng nhập và đăng xuất.
- US-01: Đăng tin nhanh.
- US-02: Danh sách bài đăng.
- US-03: Tìm kiếm từ khóa.
- US-04: Bộ lọc tìm kiếm.
- US-05: Xem chi tiết bài đăng.

Các chức năng trên tạo thành nền tảng cốt lõi của Foundly, giúp sinh viên quản lý tài khoản, đăng tin và tìm kiếm đồ thất lạc trong trường đại học.

**Kết quả Sprint 1:** Hoàn thành phạm vi triển khai theo xác nhận của nhóm, đạt 100% số hạng mục P0 được giao.

Sprint 1 tạo nền tảng cho các Sprint tiếp theo như Matching, thông báo, xác minh và trao trả vật phẩm.

Việc xác nhận chất lượng vận hành thực tế được thực hiện dựa trên kết quả demo và bằng chứng kiểm thử của nhóm.
