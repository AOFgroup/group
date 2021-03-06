CREATE TABLE HostelRole
(
  ID INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
  Name varchar(255) NOT NULL,
)
CREATE TABLE Customer
(
ID INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
Name varchar(255) NOT NULL,
Phone int NOT NULL,
Email varchar(255) NOT NULL,
[Hash] varchar(255) NOT NULL,
Salt varchar(255)NOT NULL,
HostelRoleId INT  FOREIGN KEY REFERENCES HostelRole(ID)
)

CREATE TABLE City
(
ZIP int NOT NULL  PRIMARY KEY,
CITY varchar(255) NOT NULL,
)

CREATE TABLE Hostel
(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name varchar(255),
[Address] varchar(255) NOT NULL,
ZIP INT FOREIGN KEY REFERENCES City(ZIP),
Phone int NOT NULL,
Email varchar(255) NOT NULL,
Information varchar(255) NOT NULL,

)
CREATE table [Image]
(
  ID int identity (1,1) not null Primary key,
  Pic nvarchar(255),
  HostelId int foreign key references Hostel(ID) 
)

CREATE TABLE Room
(
ID INT IDENTITY  NOT NULL PRIMARY KEY,
RoomNumber int NOT NULL,
HostelId int not null foreign key references Hostel(ID) 

)

CREATE TABLE BED
(
 ID int identity (1,1) NOT NULL Primary Key,
 Price decimal,
 RoomId int foreign key references Room(ID) 

)
CREATE TABLE Booking
(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CustomerId INT FOREIGN KEY REFERENCES Customer (ID) NOT NULL,
TotalSum decimal not null,
BookingDate datetime default(getdate()),
Amount int 
)

CREATE TABLE BookingBed
(
 ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 BedId int  foreign key references BED (ID) NOT NULL,
 BookingId int  foreign key references Booking (ID) NOT NULL,
 DateStart datetime,
 DateEnd datetime,
)



Drop table [Image], BookingBed,Hostel,City,BED,Room,Booking,Customer,HostelRole