
    if exists (select * from dbo.sysobjects where id = object_id(N'StaffMembers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StaffMembers

    if exists (select * from dbo.sysobjects where id = object_id(N'hibernate_unique_key') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table hibernate_unique_key

    create table StaffMembers (
        Id INT not null,
       EmployeeNumber NVARCHAR(255) null,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       primary key (Id)
    )

    create table hibernate_unique_key (
         next_hi INT 
    )

    insert into hibernate_unique_key values ( 1 )
