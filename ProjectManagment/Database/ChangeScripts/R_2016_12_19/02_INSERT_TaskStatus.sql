-- Insert data to TaskStatus.

GO

INSERT INTO [dbo].[TaskStatus]
           ([Id]
           ,[Abrv]
           ,[Name]
           ,[Description]
           ,[DateCreated]
           ,[DateUpdated])
     VALUES
           (NEWID()
           ,'NEW'
           ,'New'
           ,'New task'
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'InProgress'
           ,'In Progress'
           ,'Task in progress'
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'RESOLVED'
           ,'Resolved'
           ,'Resolved task'
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'CLOSED'
           ,'Closed'
           ,'Closed task'
           ,GETDATE()
           ,GETDATE())
GO


