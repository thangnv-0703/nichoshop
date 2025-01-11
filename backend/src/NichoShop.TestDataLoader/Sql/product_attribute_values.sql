﻿DELETE FROM product_attribute_values;

DROP TABLE IF EXISTS temp_data_attribute;

CREATE TEMP TABLE temp_data_attribute (
  nameAttri TEXT,
  valueAttri TEXT
);

INSERT INTO temp_data_attribute (nameAttri, valueAttri)
  VALUES ('Bao bì bơ', 'Hộp giấy bảo vệ môi trường'),
  ('Bộ nhớ', '16GB DDR4'),
  ('Bộ xử lý TV', 'Quad-Core Processor'),
  ('Care Instructions', 'Giặt tay ở nhiệt độ 30°C'),
  ('Chất liệu', 'Cotton tự nhiên 100%'),
  ('Chất liệu vợt', 'Sợi carbon cao cấp'),
  ('Chiều dài', '1.5 mét'),
  ('Chiều dài áo khoác ngoài', '75 cm'),
  ('Chiều dài tay áo', '60 cm'),
  ('Chiều rộng', '50 cm'),
  ('Chiều rộng phù hợp', '45-50 cm'),
  ('Chủ đề mẫu đồ họa', 'Phong cảnh thiên nhiên'),
  ('Chức năng ghế', 'Ghế xoay 360 độ'),
  ('Có cáp/ Không cáp', 'Không cáp'),
  ('Công suất', '2000W'),
  ('Công Thức', 'Không chứa Gluten'),
  ('Da ngoài', 'Da bò tự nhiên'),
  ('Dây vợt', 'Dây căng lực cao'),
  ('Địa chỉ tổ chức chịu trách nhiệm sản xuất', 'KCN Bình Dương, Việt Nam'),
  ('Điện áp đầu vào', '220V - 50Hz'),
  ('Dịp', 'Sinh nhật'),
  ('Độ phân giải quay video', '4K UHD'),
  ('Độ tuổi khuyến nghị', '6-12 tuổi'),
  ('Đội bóng đá', 'Manchester United'),
  ('Dung lượng lưu trữ', '512GB SSD'),
  ('Dung lượng pin', '5000mAh'),
  ('Dung tích', '1.5L'),
  ('Đường kính quả bóng', '22 cm'),
  ('Fit', 'Slim Fit'),
  ('Giai đoạn', 'Trẻ sơ sinh'),
  ('Giảm cân đặc biệt', 'Keto Diet'),
  ('Giày cao gót', '7 cm'),
  ('Giới tính', 'Nữ'),
  ('Hạn bảo hành', '24 tháng'),
  ('Hạn sử dụng', '12 tháng từ ngày sản xuất'),
  ('Has BSMI No.', 'Yes'),
  ('Hình thức sản phẩm', 'Dạng viên nén'),
  ('Hỗ trợ hệ điều hành', 'Windows, macOS'),
  ('Hương vị', 'Socola nguyên chất'),
  ('ISBN', '978-3-16-148410-0'),
  ('Item Batch code', 'BATCH12345'),
  ('Kết cấu da', 'Mềm mịn'),
  ('Kết cấu giấy', 'Giấy nhám'),
  ('Khóa Ví', 'Khóa kéo kim loại'),
  ('Kích Cỡ Gói', '30x20x15 cm'),
  ('Kích thước (dài x rộng x cao)', '40x30x10 cm'),
  ('Kích ứng', 'Không gây kích ứng da'),
  ('Kiểu đóng gói', 'Hút chân không'),
  ('Kiểu giày', 'Giày thể thao'),
  ('Kiểu váy', 'Váy dài dạ hội'),
  ('Lens Model', 'Canon EF 50mm f/1.8'),
  ('Loại anten', 'Anten ngoài'),
  ('Loại bao bì', 'Hộp nhựa'),
  ('Loại bảo hành', 'Bảo hành tại nhà'),
  ('Loại bơ', 'Bơ lạt'),
  ('Loại cài đặt', 'Cài đặt sẵn'),
  ('Loại da', 'Da PU'),
  ('Loại đầu cắm', 'USB Type-C'),
  ('Loại đồng hồ tốc độ', 'Analog'),
  ('Loại hình thể thao', 'Bóng rổ'),
  ('Loại Khóa', 'Khóa từ'),
  ('Loại khối', 'Khối vuông'),
  ('Loại mặt chắn', 'Kính cường lực'),
  ('Loại mũi giày', 'Mũi nhọn'),
  ('Loại nắp', 'Nắp bật'),
  ('Loại phân bón', 'Phân hữu cơ'),
  ('Loại phiên bản', 'Phiên bản giới hạn'),
  ('Loại pin', 'Pin Lithium-ion'),
  ('Loại sữa', 'Sữa tách béo'),
  ('Loại thú cưng', 'Chó'),
  ('Loại thực phẩm cho thú cưng nhỏ', 'Thức ăn hạt'),
  ('Loại trang bị  bóng chày', 'Găng tay bắt bóng'),
  ('Loại trang phục', 'Trang phục truyền thống'),
  ('Lứa tuổi', 'Người lớn'),
  ('Mã phụ tùng', 'PART45678'),
  ('Màn hình', 'AMOLED 6.5 inch'),
  ('Mẫu', 'Thiết kế hiện đại'),
  ('MCMC Approved', 'Yes'),
  ('Mô hình tương thích', 'iPhone 13 Pro Max'),
  ('Model Name', 'Galaxy S22 Ultra'),
  ('Mùa', 'Mùa hè'),
  ('Năm xuất bản', '2023'),
  ('Ngày hết hạn', '31-12-2025'),
  ('Ngày sản xuất', '01-01-2024'),
  ('Ngôn ngữ', 'Tiếng Việt'),
  ('Nhà cung cấp dịch vụ', 'Viettel'),
  ('Nhà Phát Hành', 'Nhà xuất bản Kim Đồng'),
  ('Nhà xuất bản', 'NXB Trẻ'),
  ('Nhập khẩu/ trong nước', 'Nhập khẩu'),
  ('Nhóm tuổi', '18-25 tuổi'),
  ('Petite', 'Dáng người nhỏ nhắn'),
  ('Phong cách', 'Tối giản'),
  ('Purpose', 'Làm đẹp'),
  ('Quantity per Pack', '10 chiếc'),
  ('Quốc gia', 'Việt Nam'),
  ('RAM', '8GB'),
  ('Rất lớn', 'Size XXL'),
  ('ROM', '256GB'),
  ('Sản phẩm đặt theo yêu cầu', 'Có thể tùy chỉnh'),
  ('SIRIM Certified', 'Yes'),
  ('Số giấy phép xuất bản', 'GP123456'),
  ('Số lượng', '100 cái'),
  ('Số lượng ghế', '6 ghế'),
  ('Số lưu hành', 'Số 7890'),
  ('Số ngăn đựng thẻ', '12 ngăn'),
  ('Số sêri', 'SER123456'),
  ('Số Trang', '300 trang'),
  ('Tall Fit', 'Dáng người cao'),
  ('Tên đội', 'Real Madrid'),
  ('Tên người chơi', 'Cristiano Ronaldo'),
  ('Tên tổ chức chịu trách nhiệm sản xuất', 'Công ty ABC'),
  ('Thành phần', 'Vitamin C, D'),
  ('Thành phố', 'Hà Nội'),
  ('Thể tích', '1 lít'),
  ('Thời lượng pin trung bình', '12 giờ'),
  ('Tích hợp pin', 'Có'),
  ('Tiêu thụ điện năng', '150W'),
  ('Tính năng', 'Chống nước IP68'),
  ('Tính năng trang phục', 'Thoáng khí'),
  ('Tình trạng', 'Mới 100%'),
  ('Tốc độ đồng hồ bộ nhớ', '3200 MHz'),
  ('Tốc độ khung hình', '60fps'),
  ('Trang phục nén', 'Có'),
  ('Trọng lượng', '1.2 kg'),
  ('Trọng lượng được hỗ trợ', '200 kg'),
  ('Vị trí', 'Trong nhà'),
  ('Xuất xứ', 'Việt Nam');

INSERT INTO product_attribute_values ("Id", "AttributeId", "ValueId", "RawValue", "ProductId")
  SELECT
    100000 + ROW_NUMBER() OVER () AS "Id",
    a."Id" AS "AttributeId",
    NULL AS "ValueId",
    db.valueAttri AS "RawValue",
    p."Id" AS "ProductId"
  FROM products p
    INNER JOIN product_categories pc
      ON p."Id" = pc."ProductId"
    INNER JOIN attribute_categories ac
      ON ac."CategoriesId" = pc."CategoryId"
    INNER JOIN attributes a
      ON ac."AttributesId" = a."Id"
    INNER JOIN temp_data_attribute db
      ON a."DisplayName" = db.nameAttri;

DROP TABLE IF EXISTS temp_data_attribute;