﻿

CREATE PROCEDURE [proc_JOB_TRAFFIC_DET_EMPSLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[JOB_NUMBER],
		[JOB_COMPONENT_NBR],
		[SEQ_NBR],
		[EMP_CODE],
		[HOURS_ALLOWED]
	FROM [JOB_TRAFFIC_DET_EMPS]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END

