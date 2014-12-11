exec createBooking 1,'Oleksandr','2423232','olkly85@gmail.com','password','sdfsadf',3,1,'2014-12-01','2014-12-03',null,
1
/*Change BED ID*/

CREATE  PROCEDURE createBooking
/*Customer*/ 
@CustomerId int,
@CusName varchar=null,
@Phone varchar=null,
@Email varchar=null,
@Hash varchar=null,
@Salt varchar=null,
/*Bed*/
@BedId int=null,
@RoomId int=null,
@DateStart date=null,
@DateEnd date=null,
@TotalSum decimal=null, 
@NumberOfbeds int=null
as 
declare  @Customer int,@AVAILIBLE bit,@BookingId int,@Count int,@FirstBedId int
set @Count=1
set @Customer=(select c.ID from Customer as c where c.Email=@Email)
EXEC CountBeds @DateStart,@DateEnd,@RoomId,@NumberOfbeds,@AVAILIBLE OUTPUT
print @AVAILIBLE 
IF @Customer IS NULL
BEGIN
INSERT INTO Customer VALUES(@CusName,@Phone,@Email,@Hash,@Salt,2)
SET @CustomerId=(Select Customer.ID from Customer where Customer.Email=@Email)/*returns id of inserted row on aoutincrement*/
END
ELSE
BEGIN
set @CustomerId=@Customer 
END
IF @AVAILIBLE=1
BEGIN
 /*Check the last bedid*/
 INSERT INTO Booking (CustomerId,TotalSum) values  (@CustomerId,200)
select @BookingId=SCOPE_IDENTITY()
exec LastID @DateStart,@DateEnd,@RoomId,@FirstBedId OUTPUT
PRINT @AVAILIBLE
WHILE @Count<=@NumberOfbeds
BEGIN
INSERT INTO BookingBed (BedId, BookingId,DateStart,DateEnd) VALUES(@FirstBedId ,@BookingId,@DateStart,@DateEnd)
SET @Count=@Count+1
set @FirstBedId=@FirstBedId+1
END
END










--exec createBooking 1,'Oleksandr','2423232','olkly85@gmail.ocm','password','sdfsadf',2,2,'2014-12-22','2014-12-25',null,
--2

--alter  PROCEDURE createBooking
--/*Customer*/ 
--@CustomerId int=null,
--@CusName varchar=null,
--@Phone varchar=null,
--@Email varchar=null,
--@Hash varchar=null,
--@Salt varchar=null,
--/*Bed*/
--@BediId int=null,
--@RoomId int=null,
--@DateEnd date=null,
--@DateStart date=null,
--@TotalSum decimal=null, 
--@NumberOfbeds int=null

--as 
--declare  @Customer int,@AVAILIBLE bit,@BookingId int,@Evailible bit,@Count int
--set @Count=0
--set @Customer=(select c.ID from Customer as c where c.Email=@Email)
--EXEC CountBeds @DateStart,@DateEnd,@RoomId,@NumberOfbeds,@AVAILIBLE 
--print @AVAILIBLE 
--IF @CustomerId IS NULL
--INSERT INTO Customer VALUES(@CusName,@Phone,@Email,@Hash,@Salt,2)
--select @CustomerId=SCOPE_IDENTITY()/*returns id of inserted row on aoutincrement*/
--BEGIN 
--TRY
--BEGIN TRANSACTION 
--INSERT INTO Booking (CustomerId) values  (@CustomerId)
--select @BookingId=SCOPE_IDENTITY()
--IF @AVAILIBLE=1
--WHILE @Count<@NumberOfbeds
--INSERT INTO BookingBed (BedId, BookingId,DateStart,DateEnd) VALUES(@BediId,@BookingId,@DateStart,@DateEnd)
--SET @Count=@Count+1
--Print ' Transaction success'
--Commit transaction 
--END TRY
--BEGIN 
--CATCH 
--Print ' Transaction Fejl'
--ROLLBACK TRANSACTION 
--END CATCH