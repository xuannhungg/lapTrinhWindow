use ahihi
--CONG DAN--
CREATE TABLE CongDan (
 hoTen nvarchar(100),
 ngayThangNamSinh nvarchar(255),
 gioiTinh nvarchar(100),
 cmnd varchar(100) PRIMARY KEY,
 danToc nvarchar(255),
 tinhTrangHonNhan nvarchar(100),
 noiDangKiKhaiSinh nvarchar(100),
 queQuan nvarchar(255),
 noiThuongTru nvarchar(100),
 trinhDoHocVan nvarchar(255),
 ngheNghiep nvarchar(100),
 luong nvarchar(20),
 soLanKetHon nvarchar (20),
 tamTru nvarchar (100),
 noiCapCMND nvarchar (100),
 ngayCap nvarchar (100),
 quocTich nvarchar (100)
);
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('Trịnh Văn Hải', '1/1/1981', N'Nam','1','Kinh','Da Ket Hon Voi Nguoi Co CMND La 2',N'Nghệ An',N'Nghệ An',N'Nghệ An',N'Đại Học',N'Làm mộc', '1000000','1',N'Hà Nội 01/01/2019',N'Nghệ An','2/2/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('Đặng Thị Hoa', '2/2/1980', N'Nữ','2','Kinh','Da Ket Hon Voi Nguoi Co CMND La 1',N'Đà Nẵng',N'Đà Nẵng',N'Đà Nẵng',N'Đại Học',N'Làm nông', '2200000','2',N'Hà Nội 02/02/2020',N'Đà Nẵng','3/3/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Văn Đạt', '3/6/2003', N'Nam','3',N'Bà Nà','Doc Than',N'Nghệ An',N'Nghệ An',N'Nghệ An',N'Đại Học',N'Sinh viên', '30000000','3',N'Nhà trọ 03/03/2021',N'Nghệ An','4/4/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Nguyễn Thị Hòa', '4/3/1988', N'Nữ','5',N'Mông','Da Ket Hon Voi Nguoi Co CMND La 5',N'Vũng Tàu',N'Vũng Tàu',N'Vũng Tàu',N'Phổ Thông',N'Học sinh', '30000000','3',N'Quãng Ngãi 04/06/2018',N'Vũng Tàu','4/4/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hồ Văn Cường', '7/4/1984', N'Nam','4',N'Hơ Me','Da Ket Hon Voi Nguoi Co CMND La 4',N'Vũng Tàu',N'Vũng Tàu',N'Vũng Tàu',N'Đại Học',N'Thợ may', '30000000','3',N'Quãng Ngãi 05/02/2023',N'Vũng Tàu','4/4/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Thị Liễu', '8/9/2000', N'Nữ','6','Kinh','Doc Than',N'Nghệ An',N'Nghệ An',N'Nghệ An',N'Trung Học',N'Bán hàng', '40000000','3',N'Kí túc xá 09/02/2021',N'Nghệ An','14/5/2019',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hồ Thị Mến', '3/5/2004', N'Nữ','7','Kinh','Doc Than',N'Vũng Tàu',N'Vũng Tàu',N'Vũng Tàu',N'Đại Học',N'Sinh viên', '40000000','3',N'Kí túc xá 09/02/2021',N'Hồ Chí Minh','4/4/2022',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hà Thủ Môn', '6/6/1992', N'Nữ','9','Kinh','Da Ket Hon Voi Nguoi Co CMND La 9',N'Đồng Tháp',N'Đồng Tháp',N'Đồng Tháp',N'Trung Học',N'Sửa xe', '47000000','3',N'Biên Hòa 03/03/2021',N'Đồng Tháp','4/4/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Thăng Bình', '1/3/1994', N'Nam','8','Kinh','Da Ket Hon Voi Nguoi Co CMND La 8',N'Đồng Nai',N'Đồng Nai',N'Đồng Nai',N'Đại Học',N'Làm nông', '40000000','3',N'Biên Hòa 07/02/2023',N'Đồng Nai','4/4/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Đào Tấn Lộc', '2/4/2004', N'Nữ','10','Kinh','Doc Than',N'Quảng Bình',N'Quảng Bình',N'Quảng Bình',N'Đại Học',N'Sinh viên', '40000000','3',N'Kí túc xá 07/06/2020',N'Quảng Bình','14/4/2023',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hồ Gia Bảo', '3/8/1992', N'Nữ','11','Kinh','Doc Than',N'Quảng Trị',N'Quảng Trị',N'Quảng Trị',N'Trung Học',N'Sửa xe', '47000000','3',N'Biên Hòa 08/02/2022',N'Quảng Trị','24/5/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Đinh Mạnh Ninh', '9/3/1994', N'Nam','12','Kinh','Doc Than',N'Đồng Nai',N'Đồng Nai',N'Đồng Nai',N'Đại Học',N'Làm nông', '40000000','3',N'Biên Hòa 09/03/2021',N'Đồng Nai','7/4/2021',N'Việt Nam');

select * from CongDan

--QUAN HE--

GO
CREATE TABLE QuanHe (
    CMND1 varchar(100),
    CMND2 varchar(100),
    quanHeVoiCMND1 NVARCHAR(50),
	quanHeVoiCMND2 NVARCHAR(50),
    PRIMARY KEY (CMND1, CMND2),
    FOREIGN KEY (CMND1) REFERENCES CongDan(CMND),
    FOREIGN KEY (CMND2) REFERENCES CongDan(CMND)
);

INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('1' , '2' , N'Vợ',N'Chồng');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES  ('1' , '3' , 'Con Trai',N'Bố');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES  ('1' , '6' , N'Con Gái',N'Bố');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('2' , '1' , N'Chồng',N'Vợ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('2' , '3' , 'Con Trai',N'Mẹ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('2' , '6' , 'Con Gái',N'Mẹ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '1' , N'Bố','Con Trai');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '2' , N'Mẹ','Con Trai');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '6' , 'Em Gái','Anh Trai');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('6' , '1' , N'Bố',N'Con Gái');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('6' , '2' , N'Mẹ',N'Con Gái');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('6' , '3' , 'Anh Trai','Em Gái');

INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('4' , '5' , N'Vợ',N'Chồng');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('4' , '7' , N'Con Gái',N'Bố');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('5' , '4' , N'Chồng',N'Vợ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('5' , '7' , N'Con Gái',N'Mẹ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('7' , '5' , N'Mẹ',N'Con Gái');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('7' , '4' , N'Bố',N'Con Gái');


INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('8' , '9' , N'Vợ',N'Chồng');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('9' , '8' , N'Chồng',N'Vợ');
select * from QuanHe
--SO HO KHAU--

CREATE TABLE SoHoKhau(
	maSoHoKhau varchar (200) NOT NULL,
	CMNDChuHo varchar (100)  not null,
	maKV nvarchar (100)not null,
	xaPhuong nvarchar (100),
	quanHuyen nvarchar (100),
	tinhTP nvarchar (100),		
	diaChi nvarchar (100),
	ngayLap nvarchar (100),
	primary key (maSoHoKhau, CMNDChuHo),

	CONSTRAINT pk_soHoKhau_congDan
	FOREIGN KEY (CMNDChuHo)
	REFERENCES CongDan (cmnd)
);

INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('1','1','2NT',N'Long Đình',N'Cần Dược',N'Long An',N'Ấp 3','1993/2/1')
INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('2','4','1',N'Linh Xuân',N'Thủ Đức',N'TPHCM',N'Đường số 5','1990/2/1')
INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('3','8','3MD',N'Phạm Văn Đồng',N'Thủ Đức',N'TPHCM',N'Duong so 5','1998/2/1')
select * from SoHoKhau

--THANH VIEN SO HO KHAU--
CREATE TABLE ThanhVienSoHoKhau(
    maSoHoKhau varchar(200) not null,
    CMNDChuHo varchar (100) NOT NULL ,
    CMNDThanhVien varchar (100) NOT NULL,
    quanHeVoiChuHo nvarchar(100) not null,
    CONSTRAINT pk_ThanhVienSoHoKhau PRIMARY KEY (maSoHoKhau, CMNDChuHo, CMNDThanhVien),
    CONSTRAINT fk_thanhVienSoHoKhau_soHoKhau FOREIGN KEY (maSoHoKhau, CMNDChuHo) REFERENCES SoHoKhau (maSoHoKhau, CMNDChuHo),
    CONSTRAINT fk_thanhVien_congDan FOREIGN KEY (CMNDThanhVien) REFERENCES CongDan (cmnd),
    CONSTRAINT fk_thanhVien_quanHe FOREIGN KEY (CMNDChuHo, CMNDThanhVien) REFERENCES QuanHe (CMND1, CMND2)
);

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('1','1','2',N'Vợ');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien, quanHeVoiChuHo)
values ('1','1','3','Con Trai');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien, quanHeVoiChuHo)
values ('1','1','6',N'Con Gái');

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('2','4','5',N'Vợ');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('2','4','7',N'Con Gái');

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('3','8','9',N'Vợ');

select * from ThanhVienSoHoKhau

--THUE--
Create table Thue (
CCCD varchar(100) NOT NULL Primary key,
LoaiThue nvarchar(100),
MucThue real,
TinhTrang nvarchar(50),
CONSTRAINT thue_theo_cccd
FOREIGN KEY (CCCD)
REFERENCES CongDan (cmnd)
)

insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('1','Thue thu nhap ca nhan',1.5, 'Chua dong');
insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('2','Thue thu nhap ca nhan',2.4, 'Chua dong');
insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('3','Thue thu nhap ca nhan',3.6, 'Chua dong');
insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('4','Thue thu nhap ca nhan', 2.3, 'Chua dong');

select * from Thue

--TAI KHOAN--
CREATE TABLE TaiKhoan (
 TaiKhoan varchar(100) primary key,
 MatKhau varchar(255)
);
INSERT INTO TaiKhoan (TaiKhoan, MatKhau)
VALUES ('admin', '123');
INSERT INTO TaiKhoan (TaiKhoan, MatKhau)
VALUES ('nva', '123');
INSERT INTO TaiKhoan (TaiKhoan, MatKhau)
VALUES ('nvb', '123');
select * from TaiKhoan
--INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap) SELECT '5', '6', maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap FROM SoHoKhau WHERE maSoHoKhau = '2'
--INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '5', '6',CMNDThanhVien, quanHeVoiCMND1 FROM ThanhVienSoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = ThanhVienSoHoKhau.CMNDThanhVien WHERE ThanhVienSoHoKhau.maSoHoKhau = '1' AND QuanHe.CMND1 = '6'
--DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau ='1'
--DELETE FROM SoHoKhau WHERE maSoHoKhau ='1'
