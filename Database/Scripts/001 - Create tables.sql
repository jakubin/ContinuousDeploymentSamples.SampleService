CREATE TABLE [dbo].[Notes] (
	[Id] int NOT NULL IDENTITY(1,1),
	[Content] nvarchar(1000) NOT NULL,
	CONSTRAINT [PK_Notes] PRIMARY KEY ([Id] ASC)
)