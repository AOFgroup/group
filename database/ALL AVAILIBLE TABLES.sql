ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT R.ID as RoomId,  B.ID as [BedNumber],   BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd
and bb.DateEnd>=@DateStart
/*works*/
ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT R.ID as RoomId,  B.ID as [BedNumber],   BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,@DateStart))>=BB.DateEnd
or @DateStart<=BB.DateStart AND (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart 






exec AvailibleBeds '2014-12-06','2014-12-09'

declare @AVAILIBLE bit
exec CountBeds '2014-12-10','2014-12-18',1,4,@AVAILIBLE OUTPUT
PRINT @AVAILIBLE


alter PROCEDURE CountBeds @DateStart date=null, @DateEnd date=null, @R_Id int=null,@NumberOFBeds int=null,@AVAILIBLE bit OUTPUT
AS
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
Declare @CountTable Table(
BedNumber int ,
RoomId int
) 
insert into @CountTable 
SELECT COUNT(B.ID) as [BedNumber],r.ID From dbo.Room as R
left join BED as B on B.RoomId=r.ID 
left join BookingBed as BB on BB.BedId=B.ID
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd
or @DateStart<=BB.DateEnd AND (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart 
Group by R.ID

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


DECLARE @DURATION int, @EXISTING DATE


/*works*/

alter PROCEDURE CountBeds @DateStart date=null, @DateEnd date=null, @R_Id int=null,@NumberOFBeds int=null,@AVAILIBLE bit OUTPUT
AS
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
Declare @CountTable Table(
BedNumber int ,
RoomId int
) 
insert into @CountTable 
SELECT COUNT(B.ID) as [BedNumber],r.ID From dbo.Room as R
left join BED as B on B.RoomId=r.ID 
left join BookingBed as BB on BB.BedId=B.ID
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,@DateStart))>=BB.DateEnd
or @DateStart<=BB.DateStart AND (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart 
Group by R.ID
SET @AVAILIBLE=(
select BedNumber from @CountTable
where RoomID=@R_Id
and @NumberOFBeds<=BedNumber
)