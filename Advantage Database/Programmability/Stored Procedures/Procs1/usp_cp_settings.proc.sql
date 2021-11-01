

CREATE PROCEDURE [dbo].[usp_cp_settings]
	@WVFolder varchar(100),
	@CPFolder varchar(100)
	
AS

DELETE FROM [dbo].[CP_SETTINGS]

INSERT INTO [dbo].[CP_SETTINGS] 
		(
			[WV_APPLICATION_FOLDER],
			[CP_APPLICATION_FOLDER]
		)
VALUES
		(
			@WVFolder,
			@CPFolder
		)


