﻿


CREATE PROCEDURE [dbo].[proc_CP_DESKTOP_OBJECTSDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [CP_DESKTOP_OBJECTS]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END




