﻿

CREATE PROCEDURE [proc_JOB_TRAFFIC_DET_EMPSDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [JOB_TRAFFIC_DET_EMPS]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END

