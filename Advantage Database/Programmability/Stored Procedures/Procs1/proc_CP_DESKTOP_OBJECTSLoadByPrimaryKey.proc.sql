﻿


CREATE PROCEDURE [dbo].[proc_CP_DESKTOP_OBJECTSLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CATEGORY_ID],
		[NAME],
		[DESCRIPTION],
		[SECURITY_LEVEL],
		[ACTIVE],
		[ASCX_FILENAME]
	FROM [CP_DESKTOP_OBJECTS]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END





