DROP TABLE [dbo].[Copay]
GO
Drop Table [dbo].[MeterData]
GO
Drop Table [dbo].[Payment]
GO
Drop Table [dbo].[Meter]
GO
Drop Table [dbo].[Rate]
GO
Drop Table [dbo].[Service]
GO
Drop Table [dbo].[Homestead]
GO
Drop Table [dbo].[File]
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
	[Tariff]	INT			NULL,
	
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
    [Number]     INT        NOT NULL,
    [Owner_Name] nvarchar(50)
)
GO

CREATE TABLE [dbo].[Meter] (
    [Id]           INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Id_Homestead] INT NOT NULL,
    [Meter_Number] INT NOT NULL,
	[Id_Rate]	INT		NOT NULL,
	
	CONSTRAINT FK_Meter_ToHomestead		FOREIGN KEY ([Id_Homestead])		REFERENCES Homestead(Id),
	CONSTRAINT FK_Meter_ToRate FOREIGN KEY (Id_Rate) REFERENCES Rate(Id), 
)
GO

CREATE TABLE [dbo].[Payment] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Id_Homestead]  INT        NOT NULL,
    [Id_Service]    INT        NOT NULL,
    [Id_File]       INT        NULL,
    [INTroduced]    FLOAT (53) NOT NULL DEFAULT 0,
    [Arrear]       FLOAT (53) NOT NULL DEFAULT 0,
    [Entered]       FLOAT (53) NOT NULL DEFAULT 0,
    [Date]          DATE       NOT NULL,
	[PackageNumber] INT			NOT NULL DEFAULT 0
	
	CONSTRAINT FK_Payment_ToHomestead		FOREIGN KEY ([Id_Homestead])		REFERENCES Homestead(Id),
	CONSTRAINT FK_Payment_ToService		FOREIGN KEY ([Id_Service])		REFERENCES [Service](Id),
	CONSTRAINT FK_Payment_ToFile		FOREIGN KEY ([Id_File])			REFERENCES [File](Id)
)
GO

Create Table [dbo].[MeterData] (
	[Id]		INT		NOT NULL identity(1,1)  PRIMARY KEY,
	Id_Meter	INT		NOT NULL,
    [Id_Payment] INT        NULL,
	oldValue		FLOAT	NOT NULL default 0,
	newValue		FLOAT	NOT NULL default 0,
	[Date]		DATE	NULL ,
	
	CONSTRAINT FK_MeterData_ToMeter FOREIGN KEY (Id_Meter) REFERENCES Meter(Id), 
	CONSTRAINT FK_MeterData_ToPayment	FOREIGN KEY ([Id_Payment])	REFERENCES [Payment](Id)
)
GO

drop view FullInfo
go
create view fullInfo
as
select	payment.Id,
		payment.Id_service,
		homestead.number,
		introduced,
		arrear,
		entered,
		payment.[date],
		id_rate,
		MeterData.newValue as 'newValue',
		MeterData.oldValue as 'oldValue',
		owner_name,
		meter_number,
		[path]

from ((payment left join meterdata on meterdata.id_payment = payment.id)
	join homestead on homestead.Id = payment.id_homestead)
	join meter on meter.Id = meterData.id_meter
	left join rate on rate.id = meter.id_rate
	join [file] on [file].id = payment.id_file
go

INSERT INTO [SERVICE] 
VALUES	(1, N'Взносы'),
		(2, N'Электроснабжение'),
		(3, N'Налог на землю'),
		(4, N'Налог на недвижимость')
GO

INSERT INTO [Rate]
VALUES	(2, 0.05, '09/01/2017', 1, NULL),
		(2, 0.25, '09/01/2017', 1, NULL),
		(2, 0.5, '09/01/2017', 1, NULL)
GO

DROP FUNCTION GetAmount
GO

CREATE FUNCTION GetAmount(@Month int, @Year int)
RETURNS float(53)
AS
BEGIN
	DECLARE @res float(53) = (
		SELECT sum(Entered) as Amount FROM Payment
		WHERE month([Date]) = @Month and year([Date]) = @Year
	)
	IF(@res IS NULL)
		 set @res = 0
	RETURN @res
END
GO

DROP FUNCTION GetNextPackageNumber
GO

CREATE FUNCTION GetNextPackageNumber()
RETURNS INT
AS
BEGIN
	IF(Select count(*) from Payment) = 0
		return 1
	return (SELECT (max(PackageNumber) + 1) FROM Payment)
END
GO