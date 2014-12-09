


/*WORKS*/
ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date 
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT B.ID , R.ID as RoomId,  BB.DateStart,  BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
WHERE B.ID NOT IN
(
SELECT BED.ID FROM BED 
left join BookingBed  on BookingBed.BedId=B.ID
left join Room  on Room.ID=BED.RoomId
WHERE BookingBed.DateEnd>=@DateStart
and   BookingBed.DateStart<=@DateEnd
)




ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT COUNT( DISTINCT B.ID) as [BedNumber], R.ID as RoomId From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
WHERE B.ID NOT IN
(
SELECT BED.ID FROM BED 
left join BookingBed  on BookingBed.BedId=B.ID
left join Room  on Room.ID=BED.RoomId
WHERE BookingBed.DateEnd>=@DateStart
and   BookingBed.DateStart<=@DateEnd
)
Group by R.ID


/////////////////////////////////////////////////////////////////////////////////













DECLARE @INT INT 
exec AvailibleBeds '2014-12-06','2014-12-09',2,@INT OUTPUT
PRINT @INT











/*works*/
ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date
AS 
DECLARE @DURATION int
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT R.ID as RoomId,  B.ID as [BedNumber],   BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
WHERE BB.DateStart>=@DateStart
and BB.DateEnd<=@DateEnd 
or (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateEnd 
or BB.DateStart is null and BB.DateEnd is null
or BB.DateStart<=(DATEDIFF(DAY,@DURATION,BB.DateEnd))and BB.DateEnd<=@DateStart and 
or @DateStart>




where BB.DateStart is null OR BB.DateEnd is null OR (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart
and BB.DateStart!>@DateStart


or @DateStart>=BB.DateEnd and BB.DateEnd!>(DATEADD(DAY,@DURATION,@DateStart))

exec AvailibleBeds '2014-12-15','2014-12-18'




or @DateStart<=BB.DateEnd AND (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart 
and (DATEADD(DAY,@DURATION,@DateStart))>=BB.DateStart

 @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,@DateStart))<=BB.DateStart








declare @AVAILIBLE bit
exec CountBeds '2014-12-06','2014-12-09',1,2,@AVAILIBLE OUTPUT
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
SELECT COUNT( DISTINCT B.ID) as [BedNumber], R.ID as RoomId From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
WHERE B.ID NOT IN
(
SELECT BED.ID FROM BED 
left join BookingBed  on BookingBed.BedId=B.ID
left join Room  on Room.ID=BED.RoomId
WHERE BookingBed.DateEnd>=@DateStart
and   BookingBed.DateStart<=@DateEnd
)
Group by R.ID
SET @AVAILIBLE=(
select BedNumber from @CountTable
where RoomID=@R_Id
and @NumberOFBeds<=BedNumber
)