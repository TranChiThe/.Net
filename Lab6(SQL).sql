Create Database Quan_Ly_SinhVien
use Quan_Ly_SinhVien
create table Lop_Hoc (
	MaLop nvarchar(20) primary key ,
	TenLop nvarchar (20) not null
)
Create Table DS_Sinh_vien (
	STT int not null,
	MSSV nvarchar(15) ,
	Hoten nvarchar(60) not null,
	MaLop nvarchar(20) references Lop_Hoc (MaLop),
	Primary Key(MSSV)
)

Create Table DS_Mon_hoc (
	MaMon nvarchar(15) Primary Key,
	TenMon nvarchar(100) not null
)

Create Table DS_Can_bo (
	MaCB nvarchar(15) Primary Key,
	HotenCB nvarchar(70) not null,
	Matkhau nvarchar(30) not null,
)

create table Giang_Day (
	MaCB nvarchar(15) references DS_Can_bo(MaCB),
	MaMon nvarchar(15) references DS_Mon_hoc(MaMon),
	MaLop nvarchar(20) references Lop_Hoc(MaLop),
	primary key (MaCB, MaMon, MaLop)
)

create table Diem_HP (
	MSSV nvarchar(15) references DS_Sinh_vien(MSSV),
	MaMon nvarchar (15) references DS_Mon_hoc(MaMon),
	Diem float check(Diem >= 0 and Diem <= 10),
	primary key (MSSV, MaMon)
)

insert into Lop_Hoc values		('k44-01', 'CNPM 01'),
								('k44-02', 'CNPM 02'),
								('k44-03', 'CNPM 03')



insert into DS_Sinh_vien values ('1', 'B18001', N'Phạm Thị An Nhiên','k44-01'),
								('2', 'B18002', N'Nguyễn Văn An', 'k44-01'),
								('3', 'B18003', N'Lê Hoài Anh','k44-01'),
								('4', 'B18004', N'Nguyễn Lâm Hoàng Anh','k44-01'),
								('5', 'B18005', N'Lê Minh Bằng','k44-01'),
								('6', 'B18006', N'Vương Thừa Chấn','k44-02'),
								('7', 'B18007', N'Cao Công Danh','k44-02'),
								('8', 'B18008', N'Trịnh Lê Long Đức','k44-02'),
								('9', 'B18009', N'Dương Lê Minh Hậu','k44-02'),
								('10', 'B18010', N'Nguyễn Vũ Hoàng','k44-02'),
								('11', 'B18011', N'Nguyễn Hoàng Thái Học', 'k44-03'),
								('12', 'B18012', N'Nguyễn Quốc Huy','k44-03'),
								('13', 'B18013', N'Võ Đoàn Gia Huy','k44-03'),
								('14', 'B18014', N'Vũ Thị Bích Huyền','k44-03'),
								('15', 'B18015', N'Hồ Việt Hưng','k44-03')


insert into DS_Can_bo values	('001', N'Nguyễn Văn Cường','123'),
								('002', N'Huỳnh Minh Phương','123'),
								('003', N'Thái Cẩm Nhung','123')


insert into DS_Mon_hoc values ('CT101', N'Lập trình căn bản'),
							('CT103', N'Cấu trúc dữ liệu'),
							('CT251', N'Phát triển ứng dụng trên Windows')

insert into Giang_Day values('001', 'CT101', 'k44-01'),
							('001', 'CT101', 'k44-02'),
							('001', 'CT103', 'k44-01'),
							('001', 'CT103', 'k44-03'),
							('002', 'CT101', 'k44-03'),
							('002', 'CT103', 'k44-02'),
							('003', 'CT251', 'k44-01'),
							('003', 'CT251', 'k44-02'),
							('003', 'CT251', 'k44-03')




insert into Diem_HP values 	('B18001', 'CT101','5'),
							('B18001', 'CT103','4.5'),
							('B18001', 'CT251','5'),  
							('B18002', 'CT101','9.8'),
							('B18002', 'CT103','1'),
							('B18002', 'CT251','2.8'),
							('B18003', 'CT101','2.0'),
							('B18003', 'CT103','8.2'),
							('B18003', 'CT251','9'),
							('B18004', 'CT101','0'),
							('B18004', 'CT103','5.3'),
							('B18004', 'CT251','3.9'),
							('B18005', 'CT101','3'),
							('B18005', 'CT103','6'),
							('B18005', 'CT251','2'),
							('B18006', 'CT101','10'),
							('B18006', 'CT103','9'),
							('B18006', 'CT251','5.8'),
							('B18007', 'CT101','8'),
							('B18007', 'CT103','9'),
							('B18007', 'CT251','6'),
							('B18008', 'CT101','9'),
							('B18008', 'CT103','10'),
							('B18008', 'CT251','4.6'),
							('B18009', 'CT101','5.9'),
							('B18009', 'CT103','5'),
							('B18009', 'CT251','9'),
							('B18010', 'CT101','10'),
							('B18010', 'CT103','1'),
							('B18010', 'CT251','0'),
							('B18011', 'CT101','7.4'),
							('B18011', 'CT103','9'),
							('B18011', 'CT251','4'),
							('B18012', 'CT101','3'),
							('B18012', 'CT103','9'),
							('B18012', 'CT251','10'),
							('B18013', 'CT101','5'),
							('B18013', 'CT103','8'),
							('B18013', 'CT251','9'),
							('B18014', 'CT101','4'),
							('B18014', 'CT103','10'),
							('B18014', 'CT251','9.5'),
							('B18015', 'CT101','2.5'),
							('B18015', 'CT103','3.2'),
							('B18015', 'CT251','9.2')

drop table Diem_HP

select * from Diem_HP

select  gd.MaCB, gd.MaMon, gd.MaLop, mh.TenMon from Giang_Day gd inner join DS_Mon_hoc mh on gd.MaMon = mh.MaMon where gd.MaCB = 001

select  d.MSSV, sv.Hoten, d.MaMon,  d.Diem from (Diem_HP d inner join DS_Sinh_vien sv on d.MSSV = sv.MSSV) inner join Giang_Day gd on d.MaMon = gd.MaMon where MaCB = 001 and gd.MaMon = 'CT101'
'K44-01'
select  d.MSSV, sv.Hoten, d.MaMon,  d.Diem from Diem_HP d inner join Giang_Day sv on d.MaLop = sv.MaMon

select * from Diem_HP 

select MaLop from Giang_Day where MaCB = '001'

drop table Diem_HP

select distinct MaMon from Giang_Day where MaCB='001'

select * from DS_Sinh_vien

delete table Diem_HP

