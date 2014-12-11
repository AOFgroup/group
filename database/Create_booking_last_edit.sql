exec createBooking 4,'Oleksandr','2423232','olkly85@gmail.com','password','sdfsadf',1,'2014-12-06','2014-12-10',null,
2
/*Change BED ID*/

alter  PROCEDURE createBooking
/*Customer*/ 
@CustomerId int,
@CusName varchar(255)=null,
@Phone varchar(255)=null,
@Email varchar(255)=null,
@Hash varchar(255)=null,
@Salt varchar(255)=null,
/*Bed*/
 /* @BedId int, */
@RoomId int=null,
@DateStart date=null,
@DateEnd date=null,
@TotalSum decimal(18,0)=null, 
@NumberOfbeds int=null
as 
declare  @Customer int,@AVAILIBLE bit,@BookingId int,@Count int,@FirstBedId int ,@Bookingdate date
set @Count=1
set @Bookingdate=getdate()
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
SET @CustomerId = @Customer
END


IF @AVAILIBLE=1





INSERT INTO Booking (CustomerId,TotalSum,BookingDate) values  (@CustomerId,@TotalSum,@Bookingdate)
select @BookingId=SCOPE_IDENTITY()
BEGIN
 /*Check the last bedid*/
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