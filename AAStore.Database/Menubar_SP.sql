--Table Menubar
--Get Menu's
Create Procedure usp_GetMenu
As
Begin
	Select MenuId, MenuName from MenuBar
End
go

--Add Menu
Create Procedure usp_AddMenu
@MenuName nvarchar(50)
As
Begin
	Insert into MenuBar(MenuName) values(@MenuName)
End