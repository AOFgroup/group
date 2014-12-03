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
ZIP int NOT NULL IDENTITY PRIMARY KEY,
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
BedNumber int NOT NULL,
HostelId INT FOREIGN KEY REFERENCES Hostel (ID) NOT NULL,
)
CREATE TABLE HostelToRom
(
ID int identity (1,1)  NOT NULL PRIMARY KEY,
RoomID INT NOT NULL foreign key references Room(ID),
HostelId int NOT NULL foreign key references Hostel(ID)
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
BookingDate datetime
)

CREATE TABLE BookingBed
(
 ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 BedId int NOT NULL,
 BookingId int NOT NULL FOREIGN KEY REFERENCES Booking(ID),
 Amount int,
 DateStart datetime,
 DateEnd datetime,
)



