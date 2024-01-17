BEGIN TRY
	BEGIN TRAN
	if ((select count(1) from sys.tables where name = 'webpages_Company' and type = 'U')=0)
		begin
			CREATE TABLE [dbo].[webpages_Company](
			[IdCompany] [int] IDENTITY(1,1) NOT NULL,
			[Name] [varchar](50) NOT NULL,
			[CUIT] [varchar](50) NULL,
			[Address] [varchar](50) NULL,
			[Number] [varchar](50) NULL,
			[State] [varchar](50) NULL,
			[Country] [varchar](50) NULL,
			[Logo] [int] NULL,
			[op] [int] NOT NULL,
			[stamp] [datetime] NOT NULL,
			CONSTRAINT [PK_webpages_Company] PRIMARY KEY CLUSTERED 
			(
				[IdCompany] ASC
			)) ON [PRIMARY]

			ALTER TABLE [dbo].[webpages_Company] ADD  DEFAULT ((-1)) FOR [op]

			ALTER TABLE [dbo].[webpages_Company] ADD  DEFAULT (getdate()) FOR [stamp]
		end

		if (select COUNT(1) from webpages_Company)=0
			insert into webpages_Company values ('MobyDick Technologies S.R.L.','30-70967380-3','Av. Belgrano','1580 Piso 1º','C.A.B.A.', 'Argentina',NULL,0,getdate())
						
		if ((select count(1) from sys.columns where Name = 'op' and object_id in (select object_id from sys.tables where name = 'webpages_Company' and type = 'U'))=0)
			ALTER TABLE [webpages_Company] ADD [op] [int] NOT NULL DEFAULT - 1

		if ((select count(1) from sys.columns where Name = 'stamp' and object_id in (select object_id from sys.tables where name = 'webpages_Company' and type = 'U'))=0)
			ALTER TABLE [webpages_Company] ADD [stamp] [datetime] NOT NULL DEFAULT getdate ()

		if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_Company_webpages_File')=0)
			begin
				ALTER TABLE [dbo].[webpages_Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_webpages_File] FOREIGN KEY([Logo]) REFERENCES [dbo].[webpages_File] ([IdFile])
	
				ALTER TABLE [dbo].[webpages_Company] CHECK CONSTRAINT [FK_Company_webpages_File]
			end

		if (select COUNT(1) from webpages_Menu where Controller='Company')=0
			insert into webpages_Menu (IDMenuModule, IDParent,Name,Area,Controller,Action,Description,Orden,Axis_X,Axis_Y,op, stamp) values (null,26,'Compañía','Administration','Company','Edit','Administración de la compañía',10,0,0,5,GETDATE())

		if (select COUNT(1) from webpages_MenuInRoles where IDrole = 2 and IDMenu=(select IDMenu from webpages_Menu where Controller='Company'))=0
			insert into webpages_MenuInRoles values (2,(select IDMenu from webpages_Menu where Controller='Company'))

		if (select COUNT(1) from webpages_MenuInRoles where IDrole = 32 and IDMenu=(select IDMenu from webpages_Menu where Controller='Company'))=0
			insert into webpages_MenuInRoles values (32,(select IDMenu from webpages_Menu where Controller='Company'))				

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