BEGIN TRY
	BEGIN TRAN
		if ((select count(1) from sys.columns where Name = 'IdCulture' and object_id in (
			select object_id from sys.tables where name = 'Users' and type = 'U'))=0)
			begin
				ALTER TABLE [dbo].[Users] 
				ADD [deleted]   BIT CONSTRAINT [DF_Users_deleted] DEFAULT ((0)) NOT NULL,
				[IdCulture] INT CONSTRAINT [DF_Users_culture] DEFAULT ((1)) NOT NULL
			end

		--Quito la cultura que se dio de alta anteriormente
		if ((select count(1) from sys.tables where name = 'Culture' and type = 'U')>0)
			DROP TABLE [dbo].[Culture] 

		--Genero la cultura con el nombre correcto
		if ((select count(1) from sys.tables where name = 'webpages_Culture' and type = 'U')=0)
			begin
				CREATE TABLE [dbo].[webpages_Culture] (
					[IdCulture]   INT IDENTITY (1, 1) NOT NULL,
					[Description] VARCHAR (50) NOT NULL,
					CONSTRAINT [PK_Culture] PRIMARY KEY CLUSTERED ([IdCulture] ASC))

				insert into dbo.webpages_Culture (Description) values ('Español-Argentino')
				insert into dbo.webpages_Culture (Description) values ('Ingles-United State')
			end

		if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_Users_webpages_Culture')=0)
			begin
				ALTER TABLE [dbo].[Users] WITH NOCHECK
				ADD CONSTRAINT [FK_Users_webpages_Culture] FOREIGN KEY ([IdCulture]) REFERENCES [dbo].[webpages_Culture] ([IdCulture])
			
				ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_webpages_Culture]
			end

		if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_webpages_Membership_Users')=0)
			begin
				ALTER TABLE [dbo].[webpages_Membership] WITH NOCHECK
				ADD CONSTRAINT [FK_webpages_Membership_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
			
				ALTER TABLE [dbo].[webpages_Membership] WITH CHECK CHECK CONSTRAINT [FK_webpages_Membership_Users]
			end

			if ((select count(1) from sys.columns where Name = 'EnableViewDeletedEntities' and object_id in (
				select object_id from sys.tables where name = 'webpages_Roles' and type = 'U'))>0)
			begin
				alter table webpages_Roles drop column EnableViewDeletedEntities
			end

			if ((select count(1) from sys.columns where Name = 'EnableViewDeleted' and object_id in (select object_id from sys.tables where name = 'webpages_Roles' and type = 'U'))=0)
			begin
				alter table webpages_Roles add EnableViewDeleted bit not null default 0
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