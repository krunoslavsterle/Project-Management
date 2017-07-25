-- Insert priority script.

GO

INSERT INTO [dbo].[TaskPriority]
           ([Id]
           ,[Abrv]
           ,[Name]
           ,[Description]
           ,[DateCreated]
           ,[DateUpdated])
     VALUES
           (NEWID()
           ,'NONE'
           ,'None'
           ,'No priority'
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'LOW'
           ,'Low'
           ,'Low priority'
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'HIGH'
           ,'High'
           ,'High priority'
           ,GETDATE()
           ,GETDATE())
GO


