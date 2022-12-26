---- Company ----

-- Get Company Details

create procedure usp_GetCompanyDetails
as
begin
   select CompanyId,CompanyName,CategoryId from Company
end

-- get by company ID
create procedure usp_GetCompanyDetailsByCompanyId
	@CompanyId INT
as
begin
   select CompanyName,CategoryId from Company
   where CompanyId = @CompanyId
end

-- get by category id
create procedure usp_GetCompanyDetailsByCategoryId
	@CategoryId INT
as
begin
   select CompanyId,CompanyName from Company
   where CategoryId = @CategoryId
end

-- Insert Company Details

create procedure usp_InsertCompanyDetails
	@CompanyName nvarchar(50),
	@CategoryId int
as
begin
	insert into Company (CompanyName,CategoryId) values(@CompanyName,@CategoryId)
end

-- update company details
create procedure usp_UpdateCompanyDetails
	@CompanyName nvarchar(50),
	@CategoryId int,
	@CompanyId int
as
begin
	update Company
	set CompanyName=@CompanyName,
		CategoryId=@CategoryId
	where CompanyId=@CompanyId
end

-- Delete Company Details
create procedure usp_DeleteCompanyDetails
	@CompanyId int
as
	begin
		Delete from Company 
		where  CompanyId= @CompanyId
	end