BEGIN TRY
	BEGIN TRAN
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

