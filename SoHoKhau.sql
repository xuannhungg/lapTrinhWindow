use project_LTWD;
CREATE TABLE SoHoKhau(
	maSoHoKhau varchar (200) Primary key,
	CMND varchar (100) ,
	maKV varchar (100),
	xaPhuong varchar (100),
	quanHuyen varchar (100),
	tinhTP varchar (100),		
	diaChi varchar (100),
	ngayLap varchar (100)

	CONSTRAINT pk_soHoKhau_congDan
	FOREIGN KEY (CMND)
	REFERENCES CongDan (cmnd)
);
INSERT INTO SoHoKhau(maSoHoKhau,CMND,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('1','1','2NT','Long Dinh','Can Duoc','Long An','Ap 3','1993/2/1')
INSERT INTO SoHoKhau(maSoHoKhau,CMND,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('2','2','1','Linh Xuan','Thu Duc','TPHCM','Duong so 5','1990/2/1')
INSERT INTO SoHoKhau(maSoHoKhau,CMND,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('3','3','2NT','Dong Hoa','Di An','Binh Duong','Duong so 7','1998/2/1')

select * from SoHoKhau
