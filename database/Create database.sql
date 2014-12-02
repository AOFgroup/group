CREATE TABLE HostelRole
(
  ID uniqueidentifier  NOT NULL PRIMARY KEY,
  Name varchar(255) NOT NULL,
)
CREATE TABLE Customer
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
Name varchar(255) NOT NULL,
Phone int NOT NULL,
Email varchar(255) NOT NULL,
[Hash] varchar(255) NOT NULL,
Salt varchar(255)NOT NULL,
HostelRoleId uniqueidentifier  FOREIGN KEY REFERENCES HostelRole(ID)
)

CREATE TABLE City
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
CITY varchar(255) NOT NULL,
ZIP int NOT NULL,
)
CREATE TABLE Hostel
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
[Address] varchar(255) NOT NULL,
CityId uniqueidentifier FOREIGN KEY REFERENCES City (ID) NOT NULL,
Phone int NOT NULL,
Email varchar(255) NOT NULL,
Information varchar(255) NOT NULL,
)
CREATE TABLE Room
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
BedNumber int NOT NULL,
HostelId uniqueidentifier FOREIGN KEY REFERENCES Hostel (ID) NOT NULL,
Price decimal NOT NULL,
PetAllow bit NOT NULL
)
CREATE TABLE HostelName
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
Name varchar(255) NOT NULL,
)

CREATE TABLE HostelNameToCity
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
HostelNameId uniqueidentifier FOREIGN KEY REFERENCES HostelName (ID) NOT NULL,
CityId uniqueidentifier FOREIGN KEY REFERENCES City (ID) NOT NULL,
)

CREATE TABLE Booking
(
ID uniqueidentifier  NOT NULL PRIMARY KEY,
RoomId uniqueidentifier FOREIGN KEY REFERENCES Room (ID) NOT NULL,
CustomerId uniqueidentifier FOREIGN KEY REFERENCES Customer (ID) NOT NULL,
DateStart datetime,
DateEnd datetime,
Commets nvarchar(255),
[Status] bit
)

