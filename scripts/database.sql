CREATE DATABASE PingSite

USE PingSite

CREATE TABLE Buildings (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Rooms (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	BuildingId INT NOT NULL FOREIGN KEY REFERENCES Buildings(Id)
)

CREATE TABLE Categories (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	ImgUrl NVARCHAR(250) NOT NULL
)

INSERT INTO Categories(Name, ImgUrl) VALUES('PC', '/images/computer.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('Website', '/images/website.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('Smartphone', '/images/smartphone.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('Game console', '/images/game-console.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('Router', '/images/router.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('Notebook', '/images/notebook.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('Camera', '/images/camera.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('TV', '/images/tv.png')
INSERT INTO Categories(Name, ImgUrl) VALUES('TV', '/images/tablet.png')

CREATE TABLE Hosts (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
	LastStatus BIT,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
)

CREATE TABLE HostsHistory (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DateOnline DATETIME,
	HostId INT NOT NULL FOREIGN KEY REFERENCES Hosts(Id)
)

CREATE TABLE Settings (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Value NVARCHAR(50) NOT NULL
)

INSERT INTO Settings(Name, Value) VALUES('AutoPing', '0')
INSERT INTO Settings(Name, Value) VALUES('AutoPingDelay', '1')