




CREATE PROCEDURE [dbo].[usp_cp_logoPath]
	@Path varchar(500)
AS

DELETE FROM [dbo].[CP_LOGO]

INSERT INTO [dbo].[CP_LOGO] 
		(
			[LOGO_PATH]
		)
VALUES
		(
			@Path
		)



















