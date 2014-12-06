ALTER PROCEDURE AvailibleBeds @DateStart date=null, @DateEnd date=null
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT  B.ID AS [Bed Number],R.ID, BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room as R on R.ID=B.RoomId
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd







alter PROCEDURE CountBeds @DateStart date=null, @DateEnd date=null, @R_Id int=null
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT b.ID, COUNT(b.RoomId)From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
left join Room AS R ON R.ID=B.RoomId
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd
and r.ID=@R_Id
Group by b.ID



exec AvailibleBeds '2014-12-12','2014-12-16'
exec CountBeds '2014-12-07','2014-12-08',12