# Sprint 1 — demo độc lập

### Yêu cầu
- Docker Desktop đang chạy.
- Các cổng `5181` (web) và `8081` (API) chưa bị ứng dụng khác sử dụng.
- Không cần cài npm, .NET SDK hoặc PostgreSQL trên Windows: Docker build các thành phần này.

### Chạy

```powershell
docker compose up --build -d
docker compose ps
```

- Sinh viên: http://localhost:5181
- Kiểm tra API: http://localhost:8081/api/health
- Demo Minh: `minh@campus.edu` / `Demo12345!`
- Demo Lan: `lan@campus.edu` / `Demo12345!`

### Kiểm tra lỗi nếu chưa vào web được

```powershell
docker compose logs --tail=70 api
docker compose logs --tail=70 web
```

### Dừng mà không mất dữ liệu

```powershell
docker compose down
```

**Không dùng `docker compose down -v`** nếu muốn giữ dữ liệu của demo Sprint 1.

### Độc lập với project lớn
- Compose project: `foundly-sprint1` (khác tên `foundly-complete`).
- Database: `sprint1`, **không công bố cổng PostgreSQL ra host**, tránh trùng `5433`/`5434`.
- Trang web: cổng `5181` thay vì `5173`, API `8081` thay vì `8080`.
- Các bài đăng/tài khoản demo được khởi tạo riêng lần đầu, không ảnh hưởng dữ liệu Foundly Full Operations.
- Không chứa Matching, chat, Admin, Notification vì nằm ngoài Sprint 1.

### Đường dẫn API chính

| Method | URL | US |
|---|---|---|
| POST | `/api/auth/login` | nền tảng đăng bài |
| POST | `/api/auth/logout` | nền tảng đăng bài |
| GET | `/api/catalog` | US-01 / US-04 |
| POST | `/api/reports` | US-01 |
| GET | `/api/reports` | US-02 / US-03 / US-04 |
| GET | `/api/reports/{id}` | US-05 |
| PUT | `/api/reports/{id}` | CRUD |
| DELETE | `/api/reports/{id}` | CRUD |

Các file frontend được tách theo `web/src/features/USXX_*.jsx`, dữ liệu dùng chung tại `web/src/api/client.js` và `api/Data/`.

### Tình trạng kiểm thử
Đã kiểm tra cấu trúc files, tĩnh JSX/JSON/YAML và đường dẫn API; **chưa xác nhận biên dịch .NET hay chạy Docker đầu-cuối** trong môi trường tạo ZIP. Nhóm cần chạy tại localhost trước khi báo cáo "đã nghiệm thu".
