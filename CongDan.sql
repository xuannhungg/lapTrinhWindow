use hihil;
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
 ngayCap varchar (100)
);
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap)
VALUES ('nva', '1/1/2003', 'nam','1','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '1000000','1','ki tuc xa','nghe An','2/2/2021');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap)
VALUES ('nva1', '2/2/2003', 'nam','2','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '2200000','2','nha tro','Nghe An','3/3/2021');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap)
VALUES ('nva2', '3/3/2003', 'nam','3','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '30000000','3','nha tro','Nghe an','4/4/2021');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap)
VALUES ('nva4', '3/3/2006', 'nu','4','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '30000000','3','nha tro','Nghe an','4/4/2021');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap)
VALUES ('nva5', '3/3/2000', 'nam','5','kinh','chua ket hon','nghe an','nghe an','nghe an','dai hoc','sinh vien', '30000000','3','nha tro','Nghe an','4/4/2021');

select * from CongDan


