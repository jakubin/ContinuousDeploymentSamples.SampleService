ALTER TABLE [dbo].[Notes] 
ADD IsDeleted bit NOT NULL 
CONSTRAINT DF_Notes_IsDeleted DEFAULT (0)