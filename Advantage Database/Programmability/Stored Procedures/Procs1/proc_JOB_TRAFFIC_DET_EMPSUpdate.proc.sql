﻿

CREATE PROCEDURE [proc_JOB_TRAFFIC_DET_EMPSUpdate]
(
	@ID int,
	@JOB_NUMBER int,
	@JOB_COMPONENT_NBR int,
	@SEQ_NBR smallint,
	@EMP_CODE varchar(6),
	@HOURS_ALLOWED decimal(8,2) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [JOB_TRAFFIC_DET_EMPS]
	SET
		[JOB_NUMBER] = @JOB_NUMBER,
		[JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR,
		[SEQ_NBR] = @SEQ_NBR,
		[EMP_CODE] = @EMP_CODE,
		[HOURS_ALLOWED] = @HOURS_ALLOWED
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END

