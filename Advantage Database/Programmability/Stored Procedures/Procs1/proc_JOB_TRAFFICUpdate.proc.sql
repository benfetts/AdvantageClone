﻿

CREATE PROCEDURE [dbo].[proc_JOB_TRAFFICUpdate]
(
	@JOB_NUMBER int,
	@JOB_COMPONENT_NBR smallint,
	@TRF_CODE varchar(10) = NULL,
	@TRF_PRESET_CODE varchar(6) = NULL,
	@TRF_COMMENTS text = NULL,
	@ASSIGN_1 varchar(6) = NULL,
	@ASSIGN_2 varchar(6) = NULL,
	@ASSIGN_3 varchar(6) = NULL,
	@ASSIGN_4 varchar(6) = NULL,
	@ASSIGN_5 varchar(6) = NULL,
	@COMPLETED_DATE smalldatetime = NULL,
	@DATE_DELIVERED smalldatetime = NULL,
	@DATE_SHIPPED smalldatetime = NULL,
	@RECEIVED_BY varchar(40) = NULL,
	@REFERENCE varchar(150) = NULL,
	@ROWID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [JOB_TRAFFIC]
	SET
		[TRF_CODE] = @TRF_CODE,
		[TRF_PRESET_CODE] = @TRF_PRESET_CODE,
		[TRF_COMMENTS] = @TRF_COMMENTS,
		[ASSIGN_1] = @ASSIGN_1,
		[ASSIGN_2] = @ASSIGN_2,
		[ASSIGN_3] = @ASSIGN_3,
		[ASSIGN_4] = @ASSIGN_4,
		[ASSIGN_5] = @ASSIGN_5,
		[COMPLETED_DATE] = @COMPLETED_DATE,
		[DATE_DELIVERED] = @DATE_DELIVERED,
		[DATE_SHIPPED] = @DATE_SHIPPED,
		[RECEIVED_BY] = @RECEIVED_BY,
		[REFERENCE] = @REFERENCE
	WHERE
		[JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR
	AND	[JOB_NUMBER] = @JOB_NUMBER


	SET @Err = @@Error


	RETURN @Err
END

