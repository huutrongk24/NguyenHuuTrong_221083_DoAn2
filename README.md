# 📌 XÂY DỰNG NỀN TẢNG QUẢN LÝ HIỆU SUẤT HOẠT ĐỘNG CỦA DOANH NGHIỆP MỘT CÁCH THÔNG MINH DỰA TRÊN WEB VÀ AI

## 🎯 Mục tiêu của đề tài

Đề tài nhằm xây dựng một nền tảng Web hỗ trợ doanh nghiệp quản lý nhân sự, công việc và hiệu suất làm việc một cách khoa học, đồng thời tích hợp Trí tuệ nhân tạo (AI) để:

* Phân tích dữ liệu hoạt động
* Dự báo tiến độ công việc
* Đánh giá và xếp loại hiệu suất nhân viên
* Hỗ trợ nhà quản lý ra quyết định kịp thời và chính xác

---

## 🧠 Ý tưởng và tính mới

Khác với các hệ thống quản lý truyền thống chỉ thống kê dữ liệu quá khứ, hệ thống này hướng đến **quản lý dự báo**, trong đó AI đóng vai trò như một trợ lý thông minh:

* **Linear Regression:** Dự đoán nguy cơ trễ hạn công việc
* **Random Forest:** Phân loại và xếp hạng hiệu suất nhân viên

Hệ thống phù hợp với doanh nghiệp SME nhờ kiến trúc gọn nhẹ, chi phí triển khai thấp và dễ mở rộng.

---

## 🏗️ Mô hình và kiến trúc hệ thống

Hệ thống được xây dựng theo mô hình **Client – Server nhiều tầng (Multi-tier Architecture)** kết hợp **AI Service**:

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

* Frontend: Hiển thị giao diện, Dashboard, biểu đồ
* Backend: Xử lý nghiệp vụ, phân quyền, giao tiếp AI
* AI Service: Phân tích dữ liệu và dự báo

---

## 🗄️ Thiết kế cơ sở dữ liệu

Hệ thống sử dụng **CSDL quan hệ (SQL Server)**, chuẩn hóa đến **3NF**, gồm các nhóm bảng chính:

### 👤 Quản lý nhân sự

* NguoiDung
* PhongBan
* KyNang
* KyNangNhanVien

### 📋 Quản lý dự án & công việc

* DuAn
* CongViec
* TaiLieuDuAn

### 📊 Hiệu suất & AI

* DanhGiaHieuSuat
* DuBaoAI

### 🔔 Hệ thống hỗ trợ

* ThongBao

---

## ⚙️ Chức năng chính của hệ thống

### 🔐 Quản lý người dùng

* Đăng nhập / đăng xuất
* Phân quyền theo vai trò (Admin, Quản lý, Nhân viên)
* Quản lý thông tin cá nhân

### 🏢 Quản lý tổ chức

* Quản lý phòng ban
* Quản lý nhân viên
* Gán trưởng phòng

### 📁 Quản lý dự án & công việc

* Tạo dự án
* Giao việc cho nhân viên
* Theo dõi tiến độ thực hiện
* Đính kèm tài liệu

### 📊 Quản lý KPI & hiệu suất

* Đánh giá KPI theo tháng
* Tổng hợp hiệu suất làm việc
* Xếp loại nhân viên tự động

### 🧠 Chức năng AI thông minh

* Dự báo trễ hạn công việc
* Cảnh báo rủi ro sớm
* Phân loại hiệu suất nhân viên
* So sánh kết quả dự báo và thực tế

### 📈 Dashboard & báo cáo

* Biểu đồ tiến độ dự án
* Biểu đồ KPI
* Thống kê theo phòng ban

---

## 🧪 Công nghệ sử dụng

* **Frontend:** React
* **Backend:** ASP.NET Core / Node.js
* **Database:** SQL Server
* **AI:** Python, Scikit-learn
* **API:** RESTful API
* **Triển khai:** Docker (mô phỏng)

---

## 📌 Phạm vi đề tài

* Áp dụng cho doanh nghiệp vừa và nhỏ (SME)
* Tập trung vào quản lý nhân sự, công việc và hiệu suất
* Dữ liệu được mô phỏng phục vụ nghiên cứu và thực nghiệm

---

## 📊 Kết quả đạt được (dự kiến)

* Xây dựng thành công hệ thống Web quản lý doanh nghiệp
* Tích hợp AI hỗ trợ dự báo và đánh giá hiệu suất
* Giao diện trực quan, dễ sử dụng
* Làm cơ sở cho nghiên cứu và phát triển mở rộng trong tương lai

---

## 🚀 Hướng phát triển

* Mở rộng thêm nhiều mô hình AI
* Gợi ý phân công công việc thông minh dựa trên kỹ năng
* Triển khai thực tế cho doanh nghiệp
* Nâng cấp thành hệ thống ERP mini cho SME

---

## 📬 Ghi chú

Repository này phục vụ mục đích **học tập và nghiên cứu khoa học**.
Giảng viên có thể tham khảo:

* Kiến trúc hệ thống
* Thiết kế CSDL
* Ý tưởng tích hợp AI trong quản lý doanh nghiệp

---

✨ *Luận văn hướng đến việc ứng dụng công nghệ Web và Trí tuệ nhân tạo để giải quyết bài toán quản lý doanh nghiệp trong thực tiễn.*
