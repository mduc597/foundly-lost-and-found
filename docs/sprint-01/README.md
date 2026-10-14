# F  O  U  N  D  L  Y — Sprint 1 (Tuần 1)

**Tên dự án:** Hệ thống Quản lý và Tìm kiếm Đồ thất lạc trong Trường Đại học  
**Sprint:** 01 – Xây dựng chức năng cốt lõi  
**Thời gian:** Tuần 1 · **Ưu tiên:** P0 (cao nhất)

> **Về nguồn gốc:** Đây là **bản trích xuất và tái cấu trúc theo phạm vi Sprint 1** từ mã nguồn Foundly Final Full Operations đã xây dựng. Nó dùng để trình bày, kiểm thử và demo các chức năng của tuần đầu, **không phải bằng chứng rằng các chức năng đó thực sự đã được lập trình theo đúng thứ tự trong lịch sử Git**. Khi báo cáo tiến độ thực, nhóm cần đối chiếu với commit/issue và công việc thực tế của từng thành viên.

## 1. Mục tiêu Sprint

Sinh viên có thể đăng đồ thất lạc hoặc nhặt được; xem danh sách bài đăng tập trung; tìm kiếm bằng từ khóa; lọc theo danh mục/ngày đăng/khu vực; xem chi tiết để không phải lục các bài Facebook dễ bị trôi.

## 2. Các User Story P0

| US | Nội dung | Mã nguồn tách riêng (Frontend) | Backend chính |
|---|---|---|---|
| **US-01** | Đăng tin nhanh | `demo/web/src/features/US01_ReportForm.jsx` | `demo/api/Controllers/ReportsWriteController.cs` |
| **US-02** | Danh sách bài đăng | `demo/web/src/features/US02_ReportList.jsx` | `demo/api/Controllers/ReportsReadController.cs` (`List`) |
| **US-03** | Tìm theo từ khóa | `demo/web/src/features/US03_KeywordSearch.jsx` | `demo/api/Services/US03_KeywordSearch.cs` |
| **US-04** | Lọc danh mục, ngày, khu vực | `demo/web/src/features/US04_ReportFilters.jsx` | `demo/api/Services/US04_ReportFilters.cs` |
| **US-05** | Xem chi tiết | `demo/web/src/features/US05_ReportDetail.jsx` | `demo/api/Controllers/ReportsReadController.cs` (`Detail`) |

**Chức năng hỗ trợ (không phải US mới):** đăng nhập tài khoản demo, quản lý danh mục/khu vực, CRUD sửa/xóa bài của mình, xác thực dữ liệu và kết nối PostgreSQL.

## 3. Cấu trúc thư mục để đưa vào GitHub

```text
notion/
└── sprint-1/
    ├── README.md                       # Tổng quan Sprint, bảng chức năng & map code
    ├── 01_ke_hoach_sprint.md            # Mục tiêu, P0, backlog, đầu ra
    ├── 02_phan_cong_va_tien_do.md       # Bảng nhận nhiệm vụ (cập nhật bằng chứng thực tế)
    ├── 03_kiem_thu_nghiem_thu.md        # Kịch bản/tiêu chí, chưa tự đánh dấu đạt
    ├── 04_huong_dan_trinh_bay.md        # Kịch bản nói và demo trước lớp
    ├── 05_so_do_du_lieu.md              # Thiết kế dữ liệu Sprint 1
    ├── user-stories/                   # 5 US riêng biệt, dễ phân công
    │   ├── US-01.md ... US-05.md
    └── demo/                           # PHIÊN BẢN CODE CHẠY ĐỘC LẬP
        ├── compose.yaml                # localhost:5181 / API localhost:8081
        ├── api/                        # ASP.NET Core + PostgreSQL
        └── web/                        # React, mỗi US một component
```

**Không chép đè `notion/README.md` đang có** và không thay đổi project Foundly Full Operations. Chỉ thêm thư mục `notion/sprint-1/` vào repository.

## 4. Chạy demo trong VS Code

1. Mở Docker Desktop.
2. Mở Terminal tại thư mục **`notion/sprint-1/demo`** (chứa `compose.yaml`).
3. Chạy:

   ```powershell
   docker compose up --build -d
   docker compose ps
   ```
4. Website: **http://localhost:5181** · Health API: **http://localhost:8081/api/health**
5. Tài khoản demo: `minh@campus.edu` / `Demo12345!`; hoặc `lan@campus.edu` / `Demo12345!`.
6. Tắt demo mà giữ dữ liệu: `docker compose down`.

Không dùng `down -v` nếu muốn giữ bài đăng. Demo có Compose name và volume riêng, **không dùng chung database với Foundly đầy đủ**.

> **Giới hạn:** Bản này được chuẩn bị từ mã nguồn hiện có, đã kiểm tra cấu trúc/cú pháp tĩnh, nhưng chưa xác nhận chạy trọn bộ Docker/.NET trong môi trường tạo file. Nhóm cần chạy và ghi kết quả nghiệm thu thực tế trước khi báo cáo hoàn thành.

## 5. Phạm vi Sprint 1 / Không thuộc Sprint 1

**Trong phạm vi:** đăng LOST/FOUND, danh sách, tìm từ khóa, lọc, chi tiết, CRUD cơ bản, kiểm tra dữ liệu đầu vào.  
**Ngoài phạm vi:** matching, gợi ý phù hợp, notification, claim/xác minh, chat, hẹn gặp, bàn giao, quản trị mở rộng. Những phần đó vẫn thuộc phiên bản Foundly chính, **không trình bày là đầu ra tuần 1**.

## 6. Tài liệu liên quan

- [Kế hoạch Sprint 1](01_ke_hoach_sprint.md)
- [Phân công và tiến độ](02_phan_cong_va_tien_do.md)
- [Kiểm thử nghiệm thu](03_kiem_thu_nghiem_thu.md)
- [Kịch bản trình bày](04_huong_dan_trinh_bay.md)
- [Sơ đồ dữ liệu](05_so_do_du_lieu.md)
- [Hướng dẫn kỹ thuật demo](demo/README.md)
