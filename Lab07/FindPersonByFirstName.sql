create proc FindPersonByFirstName
	@FirstName nvarchar(100)
as
	select * from Person where FirstName like '%'+ @FirstName + '%'
