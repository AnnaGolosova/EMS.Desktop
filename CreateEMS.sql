﻿USE [EMS]
GO
DROP TABLE [dbo].[Copay];
GO
Drop Table [dbo].[MeterData]
GO
Drop Table [dbo].[Payment]
GO
Drop Table [dbo].[Rate]
GO
Drop Table [dbo].[Service]
GO
Drop Table [dbo].[Meter]
GO
Drop Table [dbo].[Homestead]
GO
Drop Table [dbo].[File]
GO

Use [master]
GO
Drop DataBase [EMS]
GO
Create DataBase [EMS]
GO

Use [EMS]
GO

CREATE TABLE [dbo].[Copay] (
    [Id]    INT        IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Value] FLOAT (53) NOT NULL,
    [Date]  DATE       NULL
)
GO

CREATE TABLE [dbo].[Service] (
    [Id]   INT           NOT NULL PRIMARY KEY,
    [Name] nvarchar (50) NOT NULL
)
GO

CREATE TABLE [dbo].[Rate] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Id_Service] INT        NOT NULL,
    [Value]      FLOAT (53) NOT NULL,
    [Date]       DATE       NULL,
    [Number]       int       NULL,

	CONSTRAINT FK_Rate_ToService FOREIGN KEY (Id_Service) REFERENCES [Service](Id) 
)
GO

CREATE TABLE [dbo].[File] (
    [Id]   INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Date] DATE NULL,
    [Path] nvarchar(256) NOT NULL
)
GO

CREATE TABLE [dbo].[Homestead] (
	Id INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Number]     INT        ,
    [Owner_Name] nvarchar(50)
)
GO

CREATE TABLE [dbo].[Meter] (
    [Id]           INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Id_Homestead] INT NOT NULL,
    [Meter_Number] INT NOT NULL,
	
	CONSTRAINT FK_Meter_ToHomestead		FOREIGN KEY ([Id_Homestead])		REFERENCES Homestead(Id),
)
GO

CREATE TABLE [dbo].[Payment] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Id_Homestead]  INT        NOT NULL,
    [Id_Service]    INT        NOT NULL,
    [Id_File]       INT        NOT NULL,
    [INTroduced]    FLOAT (53) NOT NULL DEFAULT 0,
    [Entered]       FLOAT (53) NOT NULL DEFAULT 0,
    [Date]          DATE       NULL,
	
	CONSTRAINT FK_Payment_ToHomestead		FOREIGN KEY ([Id_Homestead])		REFERENCES Homestead(Id),
	CONSTRAINT FK_Payment_ToService		FOREIGN KEY ([Id_Service])		REFERENCES [Service](Id),
	CONSTRAINT FK_Payment_ToFile		FOREIGN KEY ([Id_File])			REFERENCES [File](Id)
)
GO

Create Table [dbo].[MeterData] (
	[Id]		INT		NOT NULL identity(1,1)  PRIMARY KEY,
	Id_Meter	INT		NOT NULL,
    [Id_Payment] INT        NULL,
	[Id_Rate]	INT		NULL,
	Value		FLOAT	NOT NULL default 0,
	[Date]		DATE	NULL ,
	
	CONSTRAINT FK_MeterData_ToMeter FOREIGN KEY (Id_Meter) REFERENCES Meter(Id), 
	CONSTRAINT FK_MeterData_ToRate FOREIGN KEY (Id_Rate) REFERENCES Rate(Id), 
	CONSTRAINT FK_MeterData_ToPayment	FOREIGN KEY ([Id_Payment])	REFERENCES [Payment](Id)
)
GO

INSERT INTO [SERVICE] 
VALUES	(1, N'Взносы'),
		(2, N'Электроэнергия'),
		(3, N'Налог на землю'),
		(4, N'Налог на недвижимость')
GO

INSERT INTO [Rate]
VALUES	(2, 0.1246, '09/01/2017', 1),
		(2, 0.1246, '09/01/2017', 1),
		(2, 0.1246, '09/01/2017', 1)
GO