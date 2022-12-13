
Create table Zal(

 ID int Primary key identity,
 Name nvarchar(50)
)

Create table ZalPos(

 ID int Primary key identity,
 Sira nvarchar(50),
 ZalID int Foreign key references Zal(ID)
 
)

Create table Sira(

 ID int Primary key identity,
 Sira int,
 ZalPosID int Foreign key references ZalPos(ID)
 
)

Create table Time(	
 ID int Primary key identity,
 Starttime datetime,
 Endtime datetime
)

Create table Kino(	
 ID int Primary key identity,
 Name nvarchar(50),
 Price decimal
)


Create table Seans(	
 ID int Primary key identity,
 TimeID int Foreign key references Time(ID),
 ZalID int Foreign key references Zal(ID),
 KinoID int Foreign key references Kino(ID)
)

ALter table Date
Add Daytime nvarchar(50)

CREATE VIEW Bilet
AS
Select  k.Name, Zal.Name , zpos.Sira, Sira.Sira,Date.daytime,Time.Starttime,Endtime From Seans s
inner Join Kino k
on k.ID=s.KinoID
inner join Zal 
on Zal.ID=s.ZalID
Inner Join ZalPos zpos
on  zpos.ZalID=Zal.ID
inner Join Sira 
on  Sira.ZalPosID=zpos.ID
inner Join Date
on Date.ID=s.TimeID
inner join Time
on Time.ID=Date.TimeID