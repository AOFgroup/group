exec createBooking 1,'Oleksandr','2423232','olkly85@gmail.ocm','password','sdfsadf',1,1,'2014-12-10','2014-12-12',null,
3

alter  PROCEDURE createBooking
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
declare  @Customer int,@AVAILIBLE bit,@BookingId int,@Count int
set @Count=0
set @Customer=(select c.ID from Customer as c where c.Email=@Email)
EXEC CountBeds @DateStart,@DateEnd,@RoomId,@NumberOfbeds,@AVAILIBLE 
print @AVAILIBLE 

IF @CustomerId IS NULL
BEGIN
INSERT INTO Customer VALUES(@CusName,@Phone,@Email,@Hash,@Salt,2)
SET @CustomerId=(Select Customer.ID from Customer where Customer.Email=@Email)/*returns id of inserted row on aoutincrement*/
END
ELSE
INSERT INTO Booking (CustomerId,TotalSum) values  (1,200)
select @BookingId=SCOPE_IDENTITY()
IF @AVAILIBLE IS NOT NULL
PRINT @AVAILIBLE
WHILE @Count<=@NumberOfbeds
BEGIN
INSERT INTO BookingBed (BedId, BookingId,DateStart,DateEnd) VALUES(@BedId,@BookingId,@DateStart,@DateEnd)
SET @Count=@Count+1
set @BedId=@BedId+1
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