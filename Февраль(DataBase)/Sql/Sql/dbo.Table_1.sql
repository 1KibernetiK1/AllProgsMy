CREATE TABLE [dbo].[Student]
(
	[SrudentId] INT NOT NULL  IDENTITY(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NVARCHAR(10) NULL, 
    [SecondName] NVARCHAR(50) NOT NULL, 
    [AcademicGroupid] INT NOT NULL, 
    CONSTRAINT [FK_Student_ToTable] FOREIGN KEY ([AcademicGroupid]) REFERENCES [AcademicGroup]([AcademicGroupid]), 
)
