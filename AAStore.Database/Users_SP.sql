--User 
--Get All Users
Create Procedure usp_GetAllUsers
AS
Begin
	Select UserId,UserName,UserDOB,UserEmail, UserContactNo,RoleId from Users
End
go

--Get User By Id
Create Procedure usp_GetUserById
@UserId int
As
Begin
	Select UserId,UserName,UserDOB,UserEmail, UserContactNo,RoleId from Users where UserId = @UserId
End
go

--Update User by Id
Alter Procedure usp_UpdateUser
@UserId int,
@UserName varchar(50),
@UserContactNo nvarchar(50),
@UserPassword nvarchar(50)
As
Begin
	Update Users set UserName = @UserName,
	UserContactNo = @UserContactNo,
	UserPassword = @UserPassword
	Where UserId = @UserId
End
go

--Add User
Create Procedure usp_AddUser
@UserName varchar(50),
@UserDOB date,
@UserEmail nvarchar(50),
@UserContactNo nvarchar(10),
@UserPassword nvarchar(50)
As
Begin
	Insert into Users (UserName,UserDOB,UserEmail,UserContactNo,UserPassword,RoleId)
	values(@UserName,@UserDOB,@UserEmail,@UserContactNo,@UserPassword,2)
End
go

--Delete User
Create Procedure usp_DeleteUser
@UserId int
As
Begin
	Delete from Users Where UserId = @UserId
End
