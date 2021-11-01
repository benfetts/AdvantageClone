﻿


CREATE PROCEDURE [dbo].[proc_CP_APPLICATIONSLoadByPrimaryKey]
(
	@APPID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[APPID],
		[CATID],
		[APPNAME],
		[URL],
		[IMAGEPATH],
		[ACTIVE],
		[SORTORDER]
	FROM [CP_APPLICATIONS]
	WHERE
		([APPID] = @APPID)

	SET @Err = @@Error

	RETURN @Err
END





