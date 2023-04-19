use project_LTWD;
CREATE TABLE ThanhVienSoHoKhau(
	maShk varchar(200) not null,
	cccd_ThanhVien varchar (100) NOT NULL,
	quanHeVoiChuHo varchar(100) NOT NULL,

	CONSTRAINT pk_thanhVienSoHoKhau_SoHoKhau
	FOREIGN KEY (maShk)
	REFERENCES SoHoKhau (maSoHoKhau),

	CONSTRAINT pk_thanhVien_congDan
	FOREIGN KEY (cccd_ThanhVien)
	REFERENCES CongDan (cmnd),
);

insert into ThanhVienSoHoKhau(maShk, cccd_ThanhVien, quanHeVoiChuHo)
values ('1','4','Con gai');
insert into ThanhVienSoHoKhau(maShk, cccd_ThanhVien, quanHeVoiChuHo)
values ('1','5','Con trai');

insert into ThanhVienSoHoKhau(maShk, cccd_ThanhVien, quanHeVoiChuHo)
values ('2','5','Con trai');

insert into ThanhVienSoHoKhau(maShk, cccd_ThanhVien, quanHeVoiChuHo)
values ('3','4','Con gai');


select * from ThanhVienSoHoKhau



