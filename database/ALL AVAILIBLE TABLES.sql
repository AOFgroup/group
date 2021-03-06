create PROCEDURE LastID @DateStart date, @DateEnd date, @roomid int, @Bid int output
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SET @Bid=(
SELECT TOP(1) B.ID  From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
WHERE B.ID NOT IN
(
SELECT BED.ID FROM BED 
left join BookingBed  on BookingBed.BedId=B.ID
left join Room  on Room.ID=BED.RoomId
WHERE BookingBed.DateEnd>@DateStart
and   BookingBed.DateStart<@DateEnd
)
and R.ID=@roomid
ORDER BY B.ID asc
)

DECLARE @INT INT 
exec AvailibleBeds'2014-12-02','2014-12-06',1,@INT OUTPUT
PRINT @INT



/*WORKS*/
/*changed the >= to >*/
ALTER PROCEDURE AvailibleBeds @DateStart date, @DateEnd date 
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT B.ID as BedId , R.ID as RoomId,  BB.DateStart,  BB.DateEnd,h.Name as Hostel,h.ID as HostelId From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
left join Hostel as h on h.ID=R.HostelId
WHERE B.ID NOT IN
(
SELECT BED.ID FROM BED 
left join BookingBed  on BookingBed.BedId=B.ID
left join Room  on Room.ID=BED.RoomId
WHERE BookingBed.DateEnd>@DateStart
and   BookingBed.DateStart<@DateEnd
)






DECLARE @INT INT 
exec AvailibleBeds '2014-12-09','2014-12-12',2,@INT OUTPUT
PRINT @INT

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