----Para pasar recursos de Mobydick a AssetControl, a SmartRetail o a Mobydick test, correr el siguiente script
----Para pasar recursos de Merpin a Azure, limpiar la webpages_resources y pasar todo lo que tenga en merpin

BEGIN TRY
	BEGIN TRAN

	--Quita la FK de resources a menus
	if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_Menu_Resources')>0)
		ALTER TABLE [dbo].[webpages_resources] DROP CONSTRAINT [FK_Menu_Resources] 

	---Agrega todos los nuevos recursos
	INSERT INTO [dbo].[WebPages_Resources] (IdCulture, Name,Value,IDMenu,op,stamp) select IdCulture, Name,Value,IDMenu,op,stamp from MobyDick.dbo.WebPages_Resources where Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) not in (select Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) from WebPages_Resources)

	---Actualiza los valores del menu
	UPDATE webpages_resources SET Value = nw.value FROM webpages_resources old INNER JOIN MobyDick.dbo.webpages_resources nw ON old.Name = nw.Name and old.IdCulture = nw.idculture and old.IDMenu = nw.IDMenu WHERE old.stamp < nw.stamp and old.Value <> nw.Value and old.Name <> 'Home' and nw.Name <> 'Home'

	----------------------------------->CORRER EL QUE CORRESPONDA<------------------------------
	---Actualiza los ID de menu
	--SmartRetail
	--update webpages_Resources set IDMenu=38 where IDMenu=40 and Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) not in (select Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) from WebPages_Resources)
	--Asset Control
	--update [WebPages_Resources] set IDMenu=66 where IDMenu=34 and Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) not in (select Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) from WebPages_Resources)
	--MobyDickTest
	--update [WebPages_Resources] set IDMenu=39 where IDMenu=34 and Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) not in (select Name + '-' + convert(varchar,IdCulture) + '-' + convert(varchar,IsNULL(IDMenu,0)) from WebPages_Resources)
	-----------------------------------------------------------------

	--Quita todos los recursos que esten de más
	delete webpages_resources where IDMenu not in (select IDMenu from webpages_Menu)

	---Vuelve a agregar la FK de resources a menus
	if ((SELECT count(1) FROM sys.foreign_keys WHERE Name='FK_Menu_Resources')=0)
		begin
			ALTER TABLE [dbo].[webpages_resources] WITH NOCHECK
			ADD CONSTRAINT [FK_Menu_Resources] FOREIGN KEY ([IdMenu]) REFERENCES [dbo].[webpages_menu] ([IdMenu])
	
			ALTER TABLE [dbo].[webpages_resources] WITH CHECK CHECK CONSTRAINT [FK_Menu_Resources]
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