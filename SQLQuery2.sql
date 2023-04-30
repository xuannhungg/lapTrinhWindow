use ahihi
CREATE TABLE CongDan (
 hoTen varchar(100),
 ngayThangNamSinh varchar(255),
 gioiTinh varchar(100),
 cmnd varchar(100) PRIMARY KEY,
 danToc varchar(255),
 tinhTrangHonNhan varchar(100),
 noiDangKiKhaiSinh varchar(100),
 queQuan varchar(255),
 noiThuongTru varchar(100),
 trinhDoHocVan varchar(255),
 ngheNghiep varchar(100),
 luong nvarchar(20),
 soLanKetHon nvarchar (20),
 tamTru nvarchar (100),
 noiCapCMND nvarchar (100),
 ngayCap varchar (100),
 quocTich varchar (100)
);
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('nva', '1/1/2003', 'nam','1','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '1000000','1','ki tuc xa','nghe An','2/2/2021','Viet Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('nva1', '2/2/2003', 'nam','2','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '2200000','2','nha tro','Nghe An','3/3/2021','Viet Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('nva2', '3/3/2003', 'nam','3','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '30000000','3','nha tro','Nghe an','4/4/2021','Viet Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('nva4', '3/3/2006', 'nu','4','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '30000000','3','nha tro','Nghe an','4/4/2021','Viet Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES ('nva5', '3/3/2000', 'nam','5','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '30000000','3','nha tro','Nghe an','4/4/2021','Viet Nam');

select * from CongDan


use ahihi;
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
VALUES ('1' , '2' , 'Vo','Chong');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES  ('1' , '3' , 'Bo','Con');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('1' , '4' , 'Bo','Con');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '4' , 'Anh','Em');

select * from QuanHe

use ahihi;
CREATE TABLE SoHoKhau(
	maSoHoKhau varchar (200) NOT NULL,
	CMNDChuHo varchar (100)  not null,
	maKV varchar (100)not null,
	xaPhuong varchar (100),
	quanHuyen varchar (100),
	tinhTP varchar (100),		
	diaChi varchar (100),
	ngayLap varchar (100),
	primary key (maSoHoKhau, CMNDChuHo),

	CONSTRAINT pk_soHoKhau_congDan
	FOREIGN KEY (CMNDChuHo)
	REFERENCES CongDan (cmnd)

);
INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('1','1','2NT','Long Dinh','Can Duoc','Long An','Ap 3','1993/2/1')
INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('2','5','1','Linh Xuan','Thu Duc','TPHCM','Duong so 5','1990/2/1')



select * from SoHoKhau

use ahihi;
CREATE TABLE ThanhVienSoHoKhau(
	maSoHoKhau varchar(200) not null ,
	CMNDChuHo varchar (100) NOT NULL ,
	CMNDThanhVien varchar (100) NOT NULL,
	quanHeVoiChuHo varchar(100) not null,
	CONSTRAINT fk_thanhVienSoHoKhau_soHoKhau
	FOREIGN KEY (maSoHoKhau,CMNDChuHo)
	REFERENCES SoHoKhau (maSoHoKhau,CMNDChuHo),
	CONSTRAINT pk_thanhVien_congDan
	FOREIGN KEY (CMNDThanhVien)
	REFERENCES CongDan (cmnd),
	CONSTRAINT fk_thanhVien_quanHe
	FOREIGN KEY (CmndChuHo, CMNDThanhVien)
	REFERENCES QuanHe (CMND1, CMND2)

);

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('1','1','3','Con gai');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien, quanHeVoiChuHo)
values ('1','1','4','Con trai');
select * from ThanhVienSoHoKhau

SELECT CongDan.hoTen, CongDan.gioiTinh, QuanHe.quanHeVoiCMND1 
FROM QuanHe 
JOIN CongDan ON CongDan.CMND = QuanHe.CMND2
WHERE QuanHe.CMND1 = '1' AND QuanHe.CMND2 = '2';