ALTER PROCEDURE AvailibleBeds @DateStart date=null, @DateEnd date=null
AS 
DECLARE @DURATION int, @EXISTING DATE
SET @DURATION=(DATEDIFF(DAY,@DateStart,@DateEnd))
SELECT  B.ID AS [Bed Number], BB.DateEnd From dbo.BED as B 
left join BookingBed as BB on BB.BedId=B.ID
where bb.DateStart is null or bb.DateEnd is null OR @DateStart>=BB.DateEnd AND (DATEADD(DAY,@DURATION,BB.DateStart))<=BB.DateEnd










SELECT B.ID AS [Bed Number],BB.DateStart ,BB.DateEnd, B.Price From dbo.BED as B 
LEFT join BookingBed as BB on BB.BedId=B.ID
where BB.DateStart>='2014-11-10' or BB.DateStart is null and bb.DateEnd<@Da