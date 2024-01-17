BEGIN TRY
	BEGIN TRAN
		if ((select count(1) from sys.tables where name = 'webpages_Resources' and type = 'U')=0)
			begin
				CREATE TABLE [dbo].[webpages_Resources](
				[IdResource] [int] IDENTITY(1,1) NOT NULL,
				[IdCulture] [int] NOT NULL,
				[Name] [varchar](100) NOT NULL,
				[Value] [nvarchar](4000) NOT NULL,
				[IDMenu] [int] NULL,
				[op][int] not null default 0,
				[stamp][datetime] not null default getdate()
				CONSTRAINT [pk_resources_culture_name] PRIMARY KEY CLUSTERED 
				(
				[IdResource] ASC
				))
								
				CREATE UNIQUE NONCLUSTERED INDEX IX_webpages_UResources ON dbo.webpages_Resources
				(
					IdCulture,
					Name,
					IdMenu
				) ON [PRIMARY]
			end
	
			if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_Culture_Resources')=0)
				begin
					ALTER TABLE [dbo].[webpages_resources] WITH NOCHECK
					ADD CONSTRAINT [FK_Culture_Resources] FOREIGN KEY ([IdCulture]) REFERENCES [dbo].[webpages_Culture] ([IdCulture])
			
					ALTER TABLE [dbo].[webpages_resources] WITH CHECK CHECK CONSTRAINT [FK_Culture_Resources]
				end
	
			if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_Menu_Resources')=0)
				begin
					ALTER TABLE [dbo].[webpages_resources] WITH NOCHECK
					ADD CONSTRAINT [FK_Menu_Resources] FOREIGN KEY ([IdMenu]) REFERENCES [dbo].[webpages_menu] ([IdMenu])
			
					ALTER TABLE [dbo].[webpages_resources] WITH CHECK CHECK CONSTRAINT [FK_Menu_Resources]
				end
			

			if ((select count(1) from sys.columns where Name = 'Code' and object_id in (
				select object_id from sys.tables where name = 'webpages_Culture' and type = 'U'))=0)
				begin
					ALTER TABLE webpages_Culture ADD Code varchar(10) DEFAULT NULL
				end
				
			if ((select count(1) from sys.columns where Name = 'Code' and object_id in (
				select object_id from sys.tables where name = 'webpages_Culture' and type = 'U'))=1)
				begin
					update webpages_Culture set Code='es-ar', Description='Español-Argentino' where IdCulture=1
					update webpages_Culture set Code='en-us', Description='Ingles-United State' where IdCulture=2
				end				
	COMMIT TRAN
END TRY
BEGIN CATCH
	Declare
		@ErrorNumber int
		,@ErrorSeverity int
		,@ErrorState int
		,@ErrorProcedure varchar(4000)
		,@ErrorLine int
		,@ErrorMessage varchar(4000)

		Select
		@ErrorNumber = Error_Number()
		,@ErrorSeverity = Error_Severity()
		,@ErrorState = Error_State()
		,@ErrorProcedure = Error_Procedure()
		,@ErrorLine = Error_Line()
		,@ErrorMessage = Error_Message()

		Print 'ErrorNumber : ' + Cast(@ErrorNumber as varchar(50))
		Print 'ErrorSeverity : ' + Cast(@ErrorSeverity as varchar(50))
		Print 'ErrorState : ' + Cast(@ErrorState as varchar(50))
		Print 'ErrorProcedure: ' + @ErrorProcedure
		Print 'ErrorLine : ' + Cast(@ErrorLine as varchar(50))
		Print 'ErrorMessage : ' + @ErrorMessage

	IF @@TRANCOUNT > 0
	BEGIN
		ROLLBACK TRAN
	END
END CATCH