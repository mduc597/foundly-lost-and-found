# Checklist nghiệm thu Sprint 1

**Hướng dẫn:** Khởi chạy demo `http://localhost:5181`, thực hiện từng trường hợp và ghi kết quả. Trạng thái mặc định là **Chưa chạy** vì bản ZIP chưa được xác nhận chạy Docker trên máy báo cáo.

| ID | US | Cách kiểm tra | Kết quả mong đợi | Trạng thái thực tế |
|---|---|---|---|---|
| TC-01 | US-01 | Đăng nhập Minh, tạo LOST với mọi trường hợp lệ | Thông báo lưu thành công, tin mới trong danh sách | Chưa chạy |
| TC-02 | US-01 | Bỏ trống danh mục rồi gửi | Form báo thiếu, không tạo tin | Chưa chạy |
| TC-03 | US-01 | Nhập mô tả dưới 10 ký tự | API/form từ chối, báo lỗi cụ thể | Chưa chạy |
| TC-04 | US-02 | Mở trang mặc định | Có danh sách, sắp xếp mới nhất và tổng số tin | Chưa chạy |
| TC-05 | US-03 | Tìm `ví` | Chỉ trả bài có tên/mô tả chứa `ví` | Chưa chạy |
| TC-06 | US-03 | Tìm chuỗi không xuất hiện | Danh sách trống, không lỗi server | Chưa chạy |
| TC-07 | US-04 | Lọc danh mục Ví & túi | Chỉ hiện bài thuộc danh mục đã chọn | Chưa chạy |
| TC-08 | US-04 | Lọc Thư viện và loại FOUND | Chỉ hiện FOUND tại thư viện | Chưa chạy |
| TC-09 | US-04 | Lọc theo ngày đăng | Chỉ hiện bài trong khoảng ngày đã chọn | Chưa chạy |
| TC-10 | US-05 | Click chi tiết bài | Đủ mô tả, danh mục, thời gian, địa điểm, trạng thái | Chưa chạy |
| TC-11 | CRUD | Sửa bài của Minh | Nội dung cập nhật sau tải lại | Chưa chạy |
| TC-12 | CRUD | Dùng Lan thử sửa/xóa bài của Minh bằng API | Backend chặn 403 | Chưa chạy |
| TC-13 | CRUD | Xóa bài của Minh | Không còn trong danh sách | Chưa chạy |
| TC-14 | Bảo mật | Không đăng nhập rồi POST bài | API trả 401 | Chưa chạy |
| TC-15 | Responsive | Bật F12 ở độ rộng 375px | Form, bộ lọc và card không tràn ngang | Chưa chạy |

**Bằng chứng cần chụp:** Trang danh sách → Form đăng thành công → Lỗi thiếu thông tin → Kết quả tìm kiếm → Lọc danh mục → Chi tiết bài → Docker `compose ps` (API/web/db đang chạy).

**Lưu ý:** Đánh giá P0 dựa vào 5 tiêu chí người dùng yêu cầu; CRUD nâng cao, bảo mật và responsive là kiểm tra bổ trợ.
