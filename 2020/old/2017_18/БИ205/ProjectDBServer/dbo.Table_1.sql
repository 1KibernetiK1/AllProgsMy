CREATE TABLE [dbo].[Smarts]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Model] VARCHAR(50) NOT NULL, 
    [Year] INT NOT NULL, 
    [Price] INT NOT NULL, 
    [id_brand] INT NOT NULL, 
    CONSTRAINT [FK_SmartsBrand] FOREIGN KEY ([id_brand]) REFERENCES [Brands]([Id])
)
