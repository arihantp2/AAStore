---- Category -----

-- All Categories

create procedure usp_getCategoryDetails
as
  begin
    select CategoryId,CategoryName from Category
  end

-- Category by ID

create procedure usp_getCategoryById
	@CategoryId INT
as
  begin
    select CategoryName from Category
	where CategoryId = @CategoryId
  end

-- Create Categories

create procedure usp_CreateCategory
	@CategoryName nvarchar(100)
as
  begin
    Insert into Category (CategoryName) Values (@CategoryName)
  end

-- Update Categories

create procedure usp_UpdateCategory
	@CategoryId INT,
	@CategoryName nvarchar(100)
as 
    begin
		update Category
		set CategoryName=@CategoryName
		Where CategoryId=@CategoryId
	end


-- Delete Categories
create procedure usp_DeleteCategoryById
	@CategoryId INT
as
  begin
    Delete from Category
	where CategoryId = @CategoryId
  end