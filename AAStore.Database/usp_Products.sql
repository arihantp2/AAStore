---- Products

-- get products

create procedure usp_getProductDetails
as
	begin
		Select ProductId,ProductName,Price,PImage,CategoryId,CompanyId from Products
	end

-- get products by productId

create procedure usp_getProductDetailsByProductId
	@ProductId int
as
	begin
		Select ProductName,Price,PImage,CategoryId,CompanyId from Products
		where ProductId=@ProductId
	end

-- get products by CategoryId

create procedure usp_GetProductDetailsByCategoryId
  @CategoryId int
as
 begin
	Select ProductId,ProductName,Price,PImage,CompanyId from Products
	where CategoryId=@CategoryId
 end

-- get products by Company Id
create procedure usp_GetProductDetailsByCompanyId
  @CompanyId int
as
 begin
	Select ProductId,ProductName,Price,PImage,CategoryId from Products
	where CompanyId=@CompanyId
 end

 -- insert product details
 create procedure usp_InsertProductDetails
	@ProductName nvarchar(100),
	@Price int,
	@PImage nvarchar(100),
	@CategoryId int,
	@CompanyId int
 as
	begin
		insert into Products (ProductName,Price,PImage,CategoryId,CompanyId)
		values (@ProductName,@Price,@PImage,@CategoryId,@CompanyId)
	end

-- Update Product Details
 create procedure usp_UpdateProductDetails
    @ProductId int,
	@ProductName nvarchar(100),
	@Price int,
	@PImage nvarchar(100),
	@CategoryId int,
	@CompanyId int
 as
	begin
		update Products
		set ProductName=@ProductName,
		Price=@Price,
		PImage=@PImage,
		CategoryId=@CategoryId,
		CompanyId=@CompanyId
		where ProductId=@ProductId
	end

-- Delete Product Details
 create procedure usp_DeleteProductDetails
    @ProductId int
 as
	begin
		Delete from Products
		where ProductId=@ProductId
	end