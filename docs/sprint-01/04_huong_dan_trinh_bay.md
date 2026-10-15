
# HƯỚNG DẪN TRÌNH BÀY SPRINT 1

**Dự án:** Foundly – Hệ thống quản lý và tìm kiếm đồ thất lạc  
**Sprint:** 1 – Xây dựng chức năng cốt lõi  
**Thời lượng dự kiến:** 15 phút  
**Trạng thái:** Hoàn thành 6/6 User Story P0 theo xác nhận của nhóm

## 1. Nội dung trình bày

- Giới thiệu dự án Foundly và vấn đề cần giải quyết.
- Trình bày mục tiêu Sprint 1 và 6 User Story P0.
- Giới thiệu kết quả triển khai các chức năng cốt lõi.
- Demo trực tiếp các chức năng US-00 đến US-05.
- Giải thích kiến trúc hệ thống và cơ sở dữ liệu.
- Trình bày phương pháp quản lý tiến độ bằng GitHub.
- Tổng kết kết quả Sprint và định hướng phát triển.

## 2. Giới thiệu Sprint 1

Trong Sprint 1, nhóm tập trung xây dựng 6 chức năng cốt lõi:

| Mã | Chức năng | Trạng thái |
|---|---|---|
| US-00 | Đăng ký, đăng nhập và đăng xuất | Hoàn thành |
| US-01 | Đăng tin nhanh | Hoàn thành |
| US-02 | Hiển thị danh sách bài đăng | Hoàn thành |
| US-03 | Tìm kiếm theo từ khóa | Hoàn thành |
| US-04 | Bộ lọc tìm kiếm | Hoàn thành |
| US-05 | Xem chi tiết bài đăng | Hoàn thành |

Các chức năng được ưu tiên vì tạo nền tảng cho quá trình xác thực tài khoản, đăng tin, lưu trữ và tìm kiếm thông tin đồ thất lạc.

Chức năng đăng ký và đăng nhập giúp xác định người đăng tin, quản lý tài khoản và hạn chế các thao tác không được phép.

## 3. Demo trực tiếp

**Website:** http://localhost:5181

### Bước 1: US-00 – Đăng ký, đăng nhập và đăng xuất

- Truy cập trang đăng ký tài khoản.
- Nhập họ tên, email và mật khẩu hợp lệ.
- Thực hiện đăng ký và kiểm tra thông báo thành công.
- Chuyển sang trang đăng nhập.
- Đăng nhập bằng tài khoản vừa tạo.
- Kiểm tra trạng thái đăng nhập thành công.
- Giới thiệu chức năng đăng xuất (thực hiện ở cuối demo).

### Bước 2: US-01 – Đăng tin nhanh

- Truy cập trang đăng tin.
- Chọn loại bài đăng LOST hoặc FOUND.
- Nhập tên vật phẩm, danh mục, mô tả, thời gian và khu vực.
- Nhấn nút đăng tin.
- Kiểm tra thông báo đăng bài thành công.

### Bước 3: US-02 – Hiển thị danh sách bài đăng

- Truy cập danh sách bài đăng.
- Kiểm tra bài vừa tạo xuất hiện trong danh sách.
- Giới thiệu cách sắp xếp bài mới nhất trước.
- Minh họa chức năng phân trang nếu có đủ dữ liệu.

### Bước 4: US-03 – Tìm kiếm theo từ khóa

- Nhập từ khóa liên quan đến vật phẩm.
- Kiểm tra danh sách bài đăng được cập nhật.
- Giải thích hệ thống tìm kiếm theo tên hoặc mô tả.

### Bước 5: US-04 – Bộ lọc tìm kiếm

- Chọn danh mục vật phẩm.
- Chọn khu vực.
- Chọn loại bài đăng LOST hoặc FOUND.
- Lọc theo khoảng ngày đăng.
- Kiểm tra kết quả đáp ứng điều kiện đã chọn.

### Bước 6: US-05 – Xem chi tiết bài đăng

- Nhấn vào một bài đăng trong danh sách.
- Hiển thị đầy đủ tên, mô tả, danh mục, thời gian, khu vực và trạng thái.
- Giới thiệu khả năng quản lý bài đăng của người dùng.

### Bước 7: Kiểm tra Database

Mở PostgreSQL và thực hiện truy vấn:

```sql
SELECT "ItemName", "Type", "Status", "CreatedAt"
FROM "Reports"
ORDER BY "CreatedAt" DESC
LIMIT 10;
```

Đối chiếu bài đăng vừa tạo trên website với dữ liệu trong bảng `Reports` để chứng minh thông tin được lưu thực tế.

Có thể kiểm tra số lượng tài khoản đã đăng ký:

```sql
SELECT COUNT(*) AS "TotalUsers"
FROM "Students";
```

### Bước 8: Đăng xuất

- Quay lại website.
- Nhấn nút Đăng xuất.
- Kiểm tra người dùng đã thoát khỏi phiên đăng nhập.
- Thử truy cập chức năng yêu cầu đăng nhập để minh họa cơ chế xác thực.

## 4. Kiến trúc hệ thống

```text
             NGƯỜI DÙNG
                  |
                  v
          REACT FRONTEND
     Giao diện và tương tác
                  |
              HTTP / JSON
                  |
                  v
       ASP.NET CORE WEB API
    Xác thực và xử lý nghiệp vụ
                  |
         ENTITY FRAMEWORK CORE
                  |
                  v
         POSTGRESQL DATABASE
    Students, Reports, Categories,
             Locations
```

- **React:** Hiển thị giao diện đăng ký, đăng nhập, đăng tin, tìm kiếm và xem chi tiết.
- **ASP.NET Core:** Xử lý nghiệp vụ, kiểm tra dữ liệu, xác thực người dùng và cung cấp API.
- **Entity Framework Core:** Hỗ trợ làm việc với dữ liệu và các thực thể.
- **PostgreSQL:** Lưu trữ thông tin tài khoản, bài đăng, danh mục và khu vực.
- **Docker Compose:** Triển khai các thành phần trên localhost.

### Luồng hoạt động

1. Người dùng thực hiện thao tác trên giao diện React.
2. Frontend gửi yêu cầu HTTP tới Backend API.
3. Backend kiểm tra dữ liệu và quyền truy cập.
4. Backend truy vấn hoặc cập nhật dữ liệu trong PostgreSQL.
5. API trả kết quả về Frontend dưới dạng JSON.
6. Frontend hiển thị kết quả cho người dùng.

## 5. Kết quả Sprint 1

- Hoàn thành mã nguồn 6/6 User Story P0 theo xác nhận của nhóm.
- Xây dựng chức năng đăng ký, đăng nhập và đăng xuất.
- Xây dựng giao diện đăng tin và tìm kiếm đồ thất lạc.
- Tích hợp Frontend, Backend và PostgreSQL.
- Xây dựng API xác thực và quản lý tài khoản người dùng.
- Xây dựng API lưu trữ, truy vấn và quản lý bài đăng.
- Áp dụng kiểm tra dữ liệu và phân quyền thao tác.
- Đưa mã nguồn và tài liệu Sprint 1 lên GitHub.

### Quản lý tiến độ

Nhóm sử dụng các công cụ GitHub để quản lý quá trình thực hiện:

- **Repository:** Lưu trữ mã nguồn và tài liệu.
- **GitHub Issues:** Quản lý các nhiệm vụ US-00 đến US-05.
- **GitHub Project:** Theo dõi tiến độ thực hiện.
- **Sprint Backlog:** Xác định các công việc ưu tiên trong Sprint.
- **Git History:** Theo dõi thay đổi và đóng góp của thành viên.

Kết quả kiểm thử và minh chứng nghiệm thu được quản lý trong `03_kiem_thu_nghiem_thu.md`.

## 6. Câu hỏi giảng viên có thể hỏi

### Câu 1: Dữ liệu được lưu ở đâu?

Dữ liệu được lưu trong PostgreSQL. Thông tin tài khoản được quản lý trong bảng `Students`, thông tin bài đăng nằm trong bảng `Reports`, ngoài ra còn có `Categories` và `Locations`.

### Câu 2: Vì sao phải xây dựng đăng ký, đăng nhập ngay Sprint 1?

Vì đây là chức năng nền tảng giúp xác định người đăng tin, quản lý tài khoản và đảm bảo chỉ người dùng có quyền mới được thực hiện các thao tác như đăng, sửa hoặc xóa bài.

### Câu 3: Làm sao hệ thống xác định ai được sửa hoặc xóa bài đăng?

Backend kiểm tra danh tính người dùng đã xác thực và đối chiếu với chủ sở hữu bài đăng. Nếu không có quyền, API từ chối yêu cầu.

### Câu 4: Vì sao chưa triển khai Matching?

Vì Sprint 1 ưu tiên xây dựng tài khoản, nguồn dữ liệu và khả năng tìm kiếm. Matching cần dữ liệu bài đăng LOST/FOUND làm đầu vào nên được triển khai ở Sprint tiếp theo.

### Câu 5: Làm sao chứng minh dữ liệu được lưu thật?

Đăng ký tài khoản hoặc tạo bài đăng mới trên website, sau đó truy vấn PostgreSQL để kiểm tra dữ liệu vừa được tạo.

### Câu 6: Vì sao sử dụng PostgreSQL thay vì LocalStorage?

PostgreSQL hỗ trợ lưu trữ dữ liệu tập trung, quản lý quan hệ và cho phép nhiều người dùng truy cập dữ liệu thông qua Backend API. LocalStorage chỉ lưu dữ liệu trong trình duyệt của từng người dùng.

### Câu 7: Nhóm quản lý tiến độ bằng cách nào?

Nhóm sử dụng GitHub Repository, Issues, GitHub Project và Sprint Backlog để phân công, theo dõi và cập nhật trạng thái công việc.

### Câu 8: Vì sao nhóm chọn React và ASP.NET Core?

React hỗ trợ xây dựng giao diện theo component, dễ tái sử dụng và mở rộng. ASP.NET Core phù hợp để xây dựng REST API, xử lý nghiệp vụ, xác thực và kết nối với PostgreSQL.

### Câu 9: Nếu người dùng đăng nhập sai mật khẩu thì sao?

Backend từ chối yêu cầu xác thực và trả thông báo lỗi phù hợp. Người dùng không được cấp quyền truy cập vào các chức năng yêu cầu đăng nhập.

### Câu 10: Làm thế nào để bảo vệ mật khẩu người dùng?

Mật khẩu phải được xử lý bằng thuật toán hash mật khẩu an toàn trước khi lưu vào cơ sở dữ liệu, không lưu mật khẩu dưới dạng văn bản thuần.

## 7. Phân bổ thời gian thuyết trình

| Nội dung | Thời lượng |
|---|---|
| Giới thiệu dự án và vấn đề | 2 phút |
| Mục tiêu Sprint 1 và 6 User Story | 2 phút |
| Demo trực tiếp US-00 đến US-05 | 6 phút |
| Kiến trúc hệ thống và Database | 2 phút |
| Quản lý tiến độ và kết quả Sprint | 1 phút |
| Tổng kết và định hướng phát triển | 2 phút |
| **Tổng cộng** | **15 phút** |

*Thời gian dự kiến không bao gồm phần giảng viên đặt câu hỏi nếu phần hỏi đáp được tổ chức riêng.*

## 8. Tổng kết

Sprint 1 đã hoàn thành phạm vi triển khai **6/6 chức năng cốt lõi theo xác nhận của nhóm**, bao gồm đăng ký, đăng nhập, đăng xuất, đăng tin, hiển thị danh sách, tìm kiếm, lọc và xem chi tiết bài đăng.

Nhóm đã xây dựng nền tảng ứng dụng dựa trên React, ASP.NET Core Web API và PostgreSQL, cho phép quản lý dữ liệu tập trung và mở rộng chức năng trong các Sprint tiếp theo.

**Kết quả đạt được:** Hoàn thành 100% phạm vi triển khai Sprint 1 theo cập nhật của nhóm. Việc nghiệm thu chất lượng vận hành được xác nhận qua demo và bằng chứng kiểm thử thực tế.

Đây là cơ sở để tiếp tục phát triển các nghiệp vụ nâng cao như Matching, thông báo, xác minh chủ sở hữu và bàn giao tài sản trong những Sprint tiếp theo.
