--Table AddressMaster
--Get Address By UserId
Create Procedure usp_GetAddressByUser
@UserId int
As
Begin
	Select AddressId,Address_Details,City,[State],PinCode from AddressMaster Where UserId = @UserId
End
go

--Add Address 
Create Procedure usp_InsertAddress
@Address_Details nvarchar(max),
@City nvarchar(100),
@State nvarchar(100),
@PinCode int,
@UserId int
As
Begin
	Insert into AddressMaster(Address_Details,City,[State],PinCode,UserId)
	Values (@Address_Details,@City,@State,@PinCode,@UserId)
End
go

--Update Address
Create Procedure usp_UpdateAddress
@AddressId int,
@Address_Details nvarchar(max),
@City nvarchar(100),
@State nvarchar(100),
@PinCode int
As
Begin
	Update AddressMaster set
	Address_Details = @Address_Details,
	City = @City,
	[State] = @State,
	PinCode = @PinCode
	Where AddressId = @AddressId
End
go

--Delete Address
Create Procedure usp_DeleteAddress
@AddressId int
As
Begin
	Delete from AddressMaster where AddressId = @AddressId
End