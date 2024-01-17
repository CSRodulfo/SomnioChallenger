BEGIN TRY
	BEGIN TRAN
			if ((select count(1) from sys.tables where name = 'webpages_Checkpoint' and type = 'U')=0)
			begin
				CREATE TABLE [dbo].[webpages_Checkpoint](
					[IdCheckpoint] [int] IDENTITY (1, 1) NOT NULL,
					[Code] [varchar](10) NOT NULL,
					[Description] [varchar](50) NOT NULL,
					[IpService] [varchar](50) NOT NULL,
					[deleted] [bit] NOT NULL,
					[op] [int] NOT NULL,
					[stamp] [datetime] NOT NULL
				CONSTRAINT [PK_Checkpoint] PRIMARY KEY CLUSTERED ([IdCheckpoint] ASC))
								
				ALTER TABLE [dbo].[webpages_Checkpoint] ADD  CONSTRAINT [DF_webpages_Checkoint_deleted]  DEFAULT ((0)) FOR [deleted]
				ALTER TABLE [dbo].[webpages_Checkpoint] ADD  CONSTRAINT [DF_webpages_Checkoint_op]  DEFAULT ((-1)) FOR [op]
				ALTER TABLE [dbo].[webpages_Checkpoint] ADD  CONSTRAINT [DF_webpages_Checkoint_stamp]  DEFAULT (getdate()) FOR [stamp]
			end

			if (select COUNT(1) from webpages_Menu where Controller='Checkpoints')=0
				insert into webpages_Menu (IDMenuModule, IDParent,Name,Area,Controller,Action,Description,Orden,Axis_X,Axis_Y,op, stamp) values (null,26,'Puntos de Control','Administration','Checkpoints','List','Administración de puntos de control',13,0,0,5,GETDATE())
	
			if (select COUNT(1) from webpages_MenuInRoles where IDrole = 2 and IDMenu=(select IDMenu from webpages_Menu where Controller='Checkpoints'))=0
				insert into webpages_MenuInRoles values (2,(select IDMenu from webpages_Menu where Controller='Checkpoints'))
			if (select COUNT(1) from webpages_MenuInRoles where IDrole = 32 and IDMenu=(select IDMenu from webpages_Menu where Controller='Checkpoints'))=0
				insert into webpages_MenuInRoles values (32,(select IDMenu from webpages_Menu where Controller='Checkpoints'))

			update webpages_Menu set Axis_X=546, Axis_Y=312 where controller='Checkpoints'
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