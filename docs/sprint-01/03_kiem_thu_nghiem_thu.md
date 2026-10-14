
# KIỂM THỬ VÀ NGHIỆM THU SPRINT 1

**Dự án:** Foundly  
**Thời gian:** Tuần 1  
**Phạm vi:** US-01 đến US-05  
**Trạng thái triển khai:** Hoàn thành 5/5 US theo cập nhật của nhóm.

## 1. Môi trường kiểm thử

- **Frontend:** React – `http://localhost:5181`
- **Backend:** ASP.NET Core – `http://localhost:8081/api/health`
- **Database:** PostgreSQL, database `sprint1`, chạy qua Docker Compose
- **Tài khoản demo:** `minh@campus.edu` hoặc `lan@campus.edu` (mật khẩu demo theo README trong mã nguồn)
- **Lệnh khởi động:** `docker compose up --build -d` tại thư mục `sprint-01-demo`

## 2. Ma trận kiểm thử và tiêu chí đạt

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

**Cách hiểu cột “Triển khai”:** Đã có code thực hiện tình huống/điều kiện tương ứng. Đây **không phải** biên bản xác nhận mọi ca kiểm thử đều đã chạy và đạt trên máy nhóm.

## 3. Minh chứng nghiệm thu cần lưu

| Minh chứng | Vị trí nên lưu |
|---|---|
| Ảnh đăng tin hợp lệ và thông báo thành công | `docs/sprint-01/evidence/TC-01.png` |
| Ảnh cảnh báo thiếu danh mục | `docs/sprint-01/evidence/TC-02.png` |
| Ảnh danh sách chứa bài mới | `docs/sprint-01/evidence/TC-05.png` |
| Ảnh tìm kiếm, lọc theo danh mục/khu vực | `docs/sprint-01/evidence/TC-06.png`, `TC-08.png` |
| Ảnh hộp thoại chi tiết bài đăng | `docs/sprint-01/evidence/TC-11.png` |
| Log/ảnh dữ liệu mới trong PostgreSQL | `docs/sprint-01/evidence/database.png` |

Đây là **đường dẫn đề xuất**. Chỉ tạo và gắn ảnh thật khi nhóm đã chụp trên máy chạy demo; không coi các ảnh chưa tồn tại là bằng chứng đã có.

## 4. Kiểm tra dữ liệu PostgreSQL

Mở Terminal trong `sprint-01-demo`:

```powershell
docker compose exec postgres psql -U sprint1 -d sprint1
```

Trong cửa sổ `psql`, chạy:

```sql
\dt
SELECT "ItemName", "Type", "Status", "CreatedAt"
FROM "Reports"
ORDER BY "CreatedAt" DESC
LIMIT 10;
```

Đăng bài mới trên web, chạy lại truy vấn và đối chiếu bản ghi.

## 5. Kết luận nghiệm thu

**Về phát triển:** 5/5 US P0 đã được đánh dấu Hoàn thành theo xác nhận nhóm và có mã nguồn tương ứng.

**Về kiểm thử đầu-cuối:** Chỉ ghi “Đạt 100%” khi đã chạy đủ ca thử trên localhost và đính kèm bằng chứng; hiện tài liệu này chưa kèm log/ảnh kết quả cho từng TC.
