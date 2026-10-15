
# KIỂM THỬ VÀ NGHIỆM THU SPRINT 1

**Dự án:** Foundly  
**Thời gian:** Tuần 1  
**Phạm vi:** US-00 đến US-05  
**Trạng thái triển khai:** Hoàn thành 6/6 US theo cập nhật của nhóm.

## 1. Môi trường kiểm thử

- **Frontend:** React – `http://localhost:5181`
- **Backend:** ASP.NET Core – `http://localhost:8081/api/health`
- **Database:** PostgreSQL, database `sprint1`, chạy qua Docker Compose
- **Tài khoản demo:** `minh@campus.edu` hoặc `lan@campus.edu` (mật khẩu demo theo README trong mã nguồn)
- **Lệnh khởi động:** `docker compose up --build -d` tại thư mục `sprint-01-demo`

**Phạm vi kiểm thử:**
- Đăng ký, đăng nhập và đăng xuất.
- Xác thực tài khoản và phân quyền người dùng.
- Đăng tin LOST/FOUND.
- Hiển thị danh sách bài đăng.
- Tìm kiếm và lọc bài đăng.
- Xem chi tiết, chỉnh sửa và xóa bài đăng.

## 2. Ma trận kiểm thử và tiêu chí đạt

### 2.1. Kiểm thử US-00 – Đăng ký, đăng nhập và đăng xuất

| TC | US | Thao tác kiểm tra | Kết quả mong đợi | Triển khai |
|---|---|---|---|---|
| TC-00-01 | US-00 | Đăng ký tài khoản với thông tin hợp lệ | Tạo tài khoản thành công, lưu vào PostgreSQL | Hoàn thành |
| TC-00-02 | US-00 | Đăng ký bằng email đã tồn tại | Hệ thống thông báo lỗi, không tạo tài khoản trùng | Hoàn thành |
| TC-00-03 | US-00 | Đăng ký với email không hợp lệ | Form/API từ chối đăng ký | Hoàn thành |
| TC-00-04 | US-00 | Đăng nhập bằng email và mật khẩu chính xác | Đăng nhập thành công | Hoàn thành |
| TC-00-05 | US-00 | Đăng nhập với mật khẩu không chính xác | Thông báo lỗi, không cho phép truy cập | Hoàn thành |
| TC-00-06 | US-00 | Nhấn Đăng xuất | Kết thúc phiên đăng nhập, các thao tác yêu cầu xác thực không còn được phép | Hoàn thành |
| TC-00-07 | US-00 | Truy cập chức năng đăng tin khi chưa đăng nhập | Hệ thống yêu cầu đăng nhập | Hoàn thành |
| TC-00-08 | US-00 | Kiểm tra dữ liệu mật khẩu trong CSDL | Mật khẩu không được lưu dưới dạng văn bản thuần | Hoàn thành |

### 2.2. Kiểm thử US-01 đến US-05

| TC | US | Thao tác kiểm tra | Kết quả mong đợi | Triển khai |
|---|---|---|---|---|
| TC-01 | US-01 | Đăng nhập, tạo bài LOST với dữ liệu hợp lệ | Báo thành công và lưu vào `Reports` | Hoàn thành |
| TC-02 | US-01 | Bỏ trống danh mục | Báo lỗi, không thêm bản ghi | Hoàn thành |
| TC-03 | US-01 | Nhập mô tả dưới 10 ký tự | Form/API từ chối | Hoàn thành |
| TC-04 | US-02 | Mở danh sách | Hiển thị bài OPEN, mới nhất trước | Hoàn thành |
| TC-05 | US-02 | Đăng thêm một bài rồi tải lại | Bài mới vẫn xuất hiện | Hoàn thành |
| TC-06 | US-03 | Nhập từ khóa `ví` | Trả bài có tên hoặc mô tả liên quan | Hoàn thành |
| TC-07 | US-03 | Nhập từ khóa không có kết quả | Hiển thị danh sách trống, không lỗi API | Hoàn thành |
| TC-08 | US-04 | Chọn danh mục `Ví & túi` | Chỉ trả các bài thuộc danh mục | Hoàn thành |
| TC-09 | US-04 | Lọc khu vực `Thư viện`, loại `FOUND` | Chỉ trả các bài thỏa đồng thời hai điều kiện | Hoàn thành |
| TC-10 | US-04 | Lọc khoảng ngày đăng | Chỉ trả bài trong khoảng ngày | Hoàn thành |
| TC-11 | US-05 | Nhấn `Xem chi tiết` | Đúng mô tả, danh mục, thời gian, khu vực, trạng thái | Hoàn thành |
| TC-12 | CRUD | Chủ bài chỉnh sửa hoặc xóa bài | Nội dung được cập nhật / xóa đúng | Hoàn thành |
| TC-13 | Phân quyền | Người khác thử sửa bài không thuộc quyền | API từ chối, không thay đổi dữ liệu | Hoàn thành |

**Tổng số:** 21 trường hợp kiểm thử.

**Cách hiểu cột "Triển khai":** Các chức năng tương ứng đã được nhóm xác nhận hoàn thành về mặt triển khai. Trạng thái này không đồng nghĩa với việc tất cả test case đã được chạy và đạt trên localhost.

## 3. Minh chứng nghiệm thu cần lưu

### 3.1. Minh chứng US-00

| Minh chứng | Vị trí nên lưu |
|---|---|
| Ảnh giao diện đăng ký tài khoản | `docs/sprint-01/evidence/TC-00-01.png` |
| Ảnh thông báo email đã tồn tại | `docs/sprint-01/evidence/TC-00-02.png` |
| Ảnh đăng nhập thành công | `docs/sprint-01/evidence/TC-00-04.png` |
| Ảnh thông báo đăng nhập thất bại | `docs/sprint-01/evidence/TC-00-05.png` |
| Ảnh trạng thái sau khi đăng xuất | `docs/sprint-01/evidence/TC-00-06.png` |
| Ảnh yêu cầu đăng nhập trước khi đăng tin | `docs/sprint-01/evidence/TC-00-07.png` |
| Minh chứng kiểm tra lưu mật khẩu an toàn | `docs/sprint-01/evidence/TC-00-08.png` |

### 3.2. Minh chứng US-01 đến US-05

| Minh chứng | Vị trí nên lưu |
|---|---|
| Ảnh đăng tin hợp lệ và thông báo thành công | `docs/sprint-01/evidence/TC-01.png` |
| Ảnh cảnh báo thiếu danh mục | `docs/sprint-01/evidence/TC-02.png` |
| Ảnh danh sách chứa bài mới | `docs/sprint-01/evidence/TC-05.png` |
| Ảnh tìm kiếm, lọc theo danh mục/khu vực | `docs/sprint-01/evidence/TC-06.png`, `TC-08.png` |
| Ảnh hộp thoại chi tiết bài đăng | `docs/sprint-01/evidence/TC-11.png` |
| Log/ảnh dữ liệu mới trong PostgreSQL | `docs/sprint-01/evidence/database.png` |

Các đường dẫn trên là vị trí đề xuất lưu minh chứng.

Nhóm chỉ bổ sung ảnh/log thật sau khi kiểm thử trên máy chạy demo. Không sử dụng hình ảnh giả lập hoặc dữ liệu chưa được xác minh làm bằng chứng nghiệm thu.

## 4. Kiểm tra dữ liệu PostgreSQL

Mở Terminal trong `sprint-01-demo`:

```powershell
docker compose exec postgres psql -U sprint1 -d sprint1
```

Trong cửa sổ `psql`, chạy:

### 4.1. Kiểm tra danh sách bảng

```sql
\dt
```

### 4.2. Kiểm tra dữ liệu tài khoản

```sql
SELECT COUNT(*) AS "TotalUsers"
FROM "Students";
```

Kiểm tra cấu trúc bảng:

```sql
\d "Students"
```

Đăng ký một tài khoản mới, sau đó kiểm tra số lượng tài khoản có tăng hay không.

Việc kiểm tra mật khẩu dạng hash cần thực hiện bằng cách xem cấu trúc dữ liệu và logic xác thực trong mã nguồn, không công khai mật khẩu hoặc thông tin xác thực của người dùng.

### 4.3. Kiểm tra bài đăng

```sql
SELECT "ItemName", "Type", "Status", "CreatedAt"
FROM "Reports"
ORDER BY "CreatedAt" DESC
LIMIT 10;
```

Đăng bài mới trên web, chạy lại truy vấn và đối chiếu bản ghi.

## 5. Tiêu chí nghiệm thu Sprint 1

| User Story | Chức năng | Điều kiện nghiệm thu | Trạng thái triển khai |
|---|---|---|---|
| US-00 | Đăng ký, đăng nhập, đăng xuất | Tạo tài khoản, xác thực, đăng xuất và kiểm soát quyền truy cập | Hoàn thành |
| US-01 | Đăng tin nhanh | Dữ liệu hợp lệ được lưu vào PostgreSQL | Hoàn thành |
| US-02 | Danh sách bài đăng | Hiển thị bài mới nhất, hỗ trợ phân trang | Hoàn thành |
| US-03 | Tìm kiếm từ khóa | Tìm được bài theo tên hoặc mô tả | Hoàn thành |
| US-04 | Bộ lọc tìm kiếm | Lọc đúng danh mục, khu vực, ngày và loại tin | Hoàn thành |
| US-05 | Xem chi tiết | Hiển thị đầy đủ thông tin bài đăng | Hoàn thành |

### Điều kiện xác nhận nghiệm thu

- Tất cả chức năng trong phạm vi Sprint 1 đã được triển khai.
- Frontend kết nối thành công với Backend.
- Backend kết nối và lưu dữ liệu vào PostgreSQL.
- Các chức năng xác thực và phân quyền hoạt động chính xác.
- Các test case bắt buộc được thực hiện trên localhost.
- Kết quả kiểm thử được ghi nhận và lưu minh chứng.

## 6. Kết luận nghiệm thu

**Về phát triển:** 6/6 User Story P0 đã được nhóm đánh dấu Hoàn thành, bao gồm:

- US-00: Đăng ký, đăng nhập và đăng xuất.
- US-01: Đăng tin nhanh.
- US-02: Danh sách bài đăng.
- US-03: Tìm kiếm theo từ khóa.
- US-04: Bộ lọc tìm kiếm.
- US-05: Xem chi tiết bài đăng.

**Tổng số trường hợp kiểm thử:** 21 test case, bao gồm 8 test case cho US-00 và 13 test case cho các chức năng còn lại.

**Về tiến độ:** Sprint 1 hoàn thành 100% phạm vi triển khai theo xác nhận của nhóm.

**Về kiểm thử đầu-cuối:** Kết quả đạt thực tế cần được xác nhận bằng việc chạy các test case trên localhost và lưu ảnh/log tương ứng. Tài liệu hiện tại mô tả kịch bản và tiêu chí nghiệm thu, chưa phải biên bản chứng minh 21/21 test case đã đạt.

**Kết luận:** Sprint 1 đã hoàn thành phạm vi triển khai 6 chức năng cốt lõi, tạo nền tảng cho các Sprint tiếp theo của Foundly.
