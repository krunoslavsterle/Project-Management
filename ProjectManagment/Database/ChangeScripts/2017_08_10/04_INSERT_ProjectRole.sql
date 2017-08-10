
INSERT INTO [dbo].[ProjectRole]
           ([Id]
           ,[Abrv]
           ,[Name]
           ,[Description]
           ,[SortOrder]
           ,[DateCreated]
           ,[DateUpdated])
     VALUES
           (NEWID()
           ,'PM'
           ,'Project Manager'
           ,NULL
           ,0
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'DEV'
           ,'Developer'
           ,NULL
           ,1
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'DESG'
           ,'Designer'
           ,NULL
           ,2
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'TEST'
           ,'Tester'
           ,NULL
           ,3
           ,GETDATE()
           ,GETDATE()),

		   (NEWID()
           ,'CLNT'
           ,'Client'
           ,NULL
           ,4
           ,GETDATE()
           ,GETDATE())
GO


