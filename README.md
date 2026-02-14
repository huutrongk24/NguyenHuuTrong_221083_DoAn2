# 📌 XÂY DỰNG NỀN TẢNG QUẢN LÝ HIỆU SUẤT HOẠT ĐỘNG CỦA DOANH NGHIỆP MỘT CÁCH THÔNG MINH DỰA TRÊN WEB VÀ AI

---

## 📌 1. Giới thiệu

Smart Performance Management Platform là hệ thống Web hỗ trợ doanh nghiệp quản lý:

- 👤 Nhân sự  
- 📋 Công việc  
- 📊 Hiệu suất làm việc  

Hệ thống tích hợp **Trí tuệ nhân tạo (AI)** nhằm phân tích dữ liệu, dự báo rủi ro và hỗ trợ nhà quản lý ra quyết định chính xác hơn.

---

## 🎯 2. Mục tiêu đề tài

- Xây dựng hệ thống quản lý doanh nghiệp trên nền tảng Web
- Phân tích dữ liệu hoạt động nội bộ
- Dự báo tiến độ và nguy cơ trễ hạn công việc
- Đánh giá & xếp loại hiệu suất nhân viên
- Hỗ trợ quản lý ra quyết định dựa trên dữ liệu

---

## 🧠 3. Điểm nổi bật & Tính mới

Khác với hệ thống quản lý truyền thống (chỉ thống kê dữ liệu quá khứ), nền tảng này hướng đến **quản lý dự báo (Predictive Management)**.

### 🔍 Ứng dụng AI trong hệ thống

| Mô hình | Mục đích |
|----------|-----------|
| 📈 Linear Regression | Dự đoán nguy cơ trễ hạn công việc |
| 🌲 Random Forest | Phân loại & xếp hạng hiệu suất nhân viên |

✔ So sánh kết quả dự báo và dữ liệu thực tế  
✔ Cảnh báo rủi ro sớm cho nhà quản lý  

---

## 🏗️ 4. Kiến trúc hệ thống

Hệ thống được xây dựng theo mô hình **Multi-tier Architecture** kết hợp AI Service độc lập:

```
Client (Web Browser)
        ↓
Frontend (React)
        ↓ REST API
Backend (ASP.NET Core / Node.js)
        ↓
SQL Server Database
        ↓
AI Service (Python + Scikit-learn)
```

### 🔹 Thành phần chính

- **Frontend**: Hiển thị giao diện, Dashboard, biểu đồ
- **Backend**: Xử lý nghiệp vụ, phân quyền, tích hợp AI
- **Database**: Lưu trữ dữ liệu
- **AI Service**: Phân tích & dự báo

---

## 🗄️ 5. Thiết kế cơ sở dữ liệu

CSDL quan hệ sử dụng **SQL Server**, chuẩn hóa đến **3NF**.

### 👤 Quản lý nhân sự
- NguoiDung
- PhongBan
- KyNang
- KyNangNhanVien

### 📋 Quản lý dự án & công việc
- DuAn
- CongViec
- TaiLieuDuAn

### 📊 Hiệu suất & AI
- DanhGiaHieuSuat
- DuBaoAI

### 🔔 Hệ thống hỗ trợ
- ThongBao

---

## ⚙️ 6. Chức năng chính

### 🔐 Quản lý người dùng
- Đăng nhập / Đăng xuất
- Phân quyền (Admin / Quản lý / Nhân viên)
- Quản lý thông tin cá nhân

### 🏢 Quản lý tổ chức
- Quản lý phòng ban
- Quản lý nhân viên
- Gán trưởng phòng

### 📁 Quản lý dự án & công việc
- Tạo dự án
- Phân công công việc
- Theo dõi tiến độ
- Đính kèm tài liệu

### 📊 Quản lý KPI & hiệu suất
- Đánh giá KPI theo tháng
- Tổng hợp hiệu suất làm việc
- Xếp loại nhân viên tự động

### 🧠 Chức năng AI
- Dự báo trễ hạn công việc
- Cảnh báo rủi ro sớm
- Phân loại hiệu suất nhân viên
- So sánh dự báo và thực tế

### 📈 Dashboard & Báo cáo
- Biểu đồ tiến độ dự án
- Biểu đồ KPI
- Thống kê theo phòng ban

---

## 🧪 7. Công nghệ sử dụng

| Thành phần | Công nghệ |
|------------|------------|
| Frontend | React |
| Backend | ASP.NET Core / Node.js |
| Database | SQL Server |
| AI | Python, Scikit-learn |
| API | RESTful API |
| Deployment | Docker (mô phỏng) |

---

## 🧠 8. Mô hình sử dụng

Hệ thống tích hợp các mô hình Machine Learning nhằm hỗ trợ dự báo và đánh giá hiệu suất doanh nghiệp.

### 📈 8.1. Linear Regression (Hồi quy tuyến tính)

**Mục đích:**  
Dự báo nguy cơ trễ hạn công việc.

**Ứng dụng trong hệ thống:**
- Dự đoán số ngày trễ
- Ước lượng xác suất trễ hạn
- Hỗ trợ cảnh báo sớm cho nhà quản lý

**Lý do lựa chọn:**
- Dễ triển khai
- Dễ giải thích về mặt toán học
- Phù hợp với dữ liệu doanh nghiệp SME

---

### 🌲 8.2. Random Forest (Rừng ngẫu nhiên)

**Mục đích:**  
Phân loại và xếp loại hiệu suất nhân viên.

**Ứng dụng trong hệ thống:**
- Phân loại nhân viên: Xuất sắc / Tốt / Trung bình / Yếu
- Phân tích mức độ ảnh hưởng của các yếu tố KPI
- Hỗ trợ đánh giá khách quan dựa trên dữ liệu

**Lý do lựa chọn:**
- Độ chính xác cao
- Hạn chế overfitting
- Hoạt động tốt với dữ liệu thực tế doanh nghiệp

---

## 📊 Tổng quan mô hình AI

| Bài toán | Mô hình sử dụng | Mục tiêu |
|----------|-----------------|----------|
| Dự báo trễ hạn | Linear Regression | Ước lượng số ngày trễ |
| Xếp loại hiệu suất | Random Forest Classifier | Phân loại nhân viên |

---

Các mô hình được triển khai bằng **Python** và thư viện **Scikit-learn**, tích hợp vào hệ thống thông qua REST API.

---

## 📊 9. Kết quả đạt được (Dự kiến)

- Hoàn thiện hệ thống Web quản lý doanh nghiệp
- Tích hợp AI dự báo & đánh giá hiệu suất
- Giao diện trực quan, thân thiện
- Tạo nền tảng cho nghiên cứu mở rộng

---

## 🚀 10. Hướng phát triển

- Mở rộng thêm nhiều mô hình AI
- Gợi ý phân công công việc thông minh dựa trên kỹ năng
- Triển khai thực tế cho doanh nghiệp
- Phát triển thành hệ thống ERP mini cho SME

---

## 📌 11. Phạm vi đề tài

- Áp dụng cho doanh nghiệp vừa và nhỏ (SME)
- Dữ liệu mô phỏng phục vụ nghiên cứu & thực nghiệm
- Tập trung vào quản lý nhân sự – công việc – hiệu suất

---

## 📚 12. Mục đích Repository

Repository được xây dựng phục vụ:

- 📖 Học tập
- 🎓 Luận văn tốt nghiệp
- 🔬 Nghiên cứu khoa học

Giảng viên có thể tham khảo:
- Kiến trúc hệ thống
- Thiết kế cơ sở dữ liệu
- Phương pháp tích hợp AI vào quản lý doanh nghiệp

---

## ✨ Tổng kết

Đề tài hướng đến việc ứng dụng **Công nghệ Web và Trí tuệ nhân tạo** để giải quyết bài toán quản lý doanh nghiệp trong thực tiễn, tạo nền tảng cho mô hình quản lý thông minh trong tương lai.
