﻿


CREATE PROCEDURE [dbo].[proc_CP_APPLICATIONS_CATEGORYLoadByPrimaryKey]
(
	@CATID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CATID],
		[CATEGORY],
		[ICONPATH],
		[SORT_ORDER]
	FROM [CP_APPLICATIONS_CATEGORY]
	WHERE
		([CATID] = @CATID)

	SET @Err = @@Error

	RETURN @Err
END





