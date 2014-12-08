ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT R.ID as RoomId,  B.ID as [BedNumber],   BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd
and bb.DateEnd>=@DateStart

ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT R.ID as RoomId,  B.ID as [BedNumber],   BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd
or @DateStart<=BB.DateEnd AND (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart 



exec AvailibleBeds '2014-12-07','2014-12-10'
exec CountBeds '2014-12-22','2014-12-25',1,3




alter PROCEDURE CountBeds @DateStart date=null, @DateEnd date=null, @R_Id int=null,@NumberOFBeds int=null,@AVAILIBLE bit=null out
AS
DECLARE @DURATION int, @EXISTING DATE
Declare @CountTable Table(
BedNumber int ,
RoomId int
) 
insert into @CountTable 
SELECT COUNT(B.ID) as [BedNumber],r.ID From dbo.Room as R
left join BED as B on B.RoomId=r.ID 
left join BookingBed as BB on BB.BedId=B.ID
where bb.DateStart is null or bb.DateEnd is null  OR R.ID=@R_Id and @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd
and bb.DateEnd>=@DateStart
Group by R.ID
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SET @AVAILIBLE=(
select BedNumber from @CountTable
where RoomID=@R_Id
and @NumBerOFBeds<=BedNumber)
PRINT @AVAILIBLE


create procedure allHostels
as 
Select *from Hostel
exec allHostels

delete BookingBed 

