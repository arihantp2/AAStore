----  Roles

-- get role details

create procedure usp_getRoleDetails
as
	begin
		select RoleId,RoleName from Roles
	end

-- get role details by ID
create procedure usp_getRoleById 
	@RoleId int
as
	begin
		select RoleName from Roles
		where RoleId=@RoleId
	end
