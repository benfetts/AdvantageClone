﻿



























CREATE PROCEDURE [dbo].[proc_JOB_LOGInsert]
(
	@JOB_NUMBER int,
	@OFFICE_CODE varchar(4) = NULL,
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6),
	@CMP_CODE varchar(6) = NULL,
	@SC_CODE varchar(6) = NULL,
	@USER_ID varchar(100) = NULL,
	@CREATE_DATE smalldatetime = NULL,
	@JOB_DESC varchar(60) = NULL,
	@JOB_DATE_OPENED smalldatetime = NULL,
	@JOB_RUSH_CHARGES smallint = NULL,
	@JOB_ESTIMATE_REQ smallint = NULL,
	@JOB_COMMENTS text = NULL,
	@JOB_CLI_REF varchar(30) = NULL,
	@BILL_COOP_CODE varchar(6) = NULL,
	@FORMAT_SC_CODE varchar(6) = NULL,
	@FORMAT_CODE varchar(8) = NULL,
	@COMPLEX_CODE varchar(8) = NULL,
	@PROMO_CODE varchar(8) = NULL,
	@CMP_IDENTIFIER int = NULL,
	@CMP_LINE_NBR smallint = NULL,
	@ROWID int = NULL output,
	@JOB_BILL_COMMENT varchar(254) = NULL,
	@FEE_JOB smallint = NULL,
	@UDV1_CODE varchar(10) = NULL,
	@UDV2_CODE varchar(10) = NULL,
	@UDV3_CODE varchar(10) = NULL,
	@UDV4_CODE varchar(10) = NULL,
	@UDV5_CODE varchar(10) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [JOB_LOG]
	(
		[JOB_NUMBER],
		[OFFICE_CODE],
		[CL_CODE],
		[DIV_CODE],
		[PRD_CODE],
		[CMP_CODE],
		[SC_CODE],
		[USER_ID],
		[CREATE_DATE],
		[JOB_DESC],
		[JOB_DATE_OPENED],
		[JOB_RUSH_CHARGES],
		[JOB_ESTIMATE_REQ],
		[JOB_COMMENTS],
		[JOB_CLI_REF],
		[BILL_COOP_CODE],
		[FORMAT_SC_CODE],
		[FORMAT_CODE],
		[COMPLEX_CODE],
		[PROMO_CODE],
		[CMP_IDENTIFIER],
		[CMP_LINE_NBR],
		[JOB_BILL_COMMENT],
		[FEE_JOB],
		[UDV1_CODE],
		[UDV2_CODE],
		[UDV3_CODE],
		[UDV4_CODE],
		[UDV5_CODE]
	)
	VALUES
	(
		@JOB_NUMBER,
		@OFFICE_CODE,
		@CL_CODE,
		@DIV_CODE,
		@PRD_CODE,
		@CMP_CODE,
		@SC_CODE,
		@USER_ID,
		@CREATE_DATE,
		@JOB_DESC,
		@JOB_DATE_OPENED,
		@JOB_RUSH_CHARGES,
		@JOB_ESTIMATE_REQ,
		@JOB_COMMENTS,
		@JOB_CLI_REF,
		@BILL_COOP_CODE,
		@FORMAT_SC_CODE,
		@FORMAT_CODE,
		@COMPLEX_CODE,
		@PROMO_CODE,
		@CMP_IDENTIFIER,
		@CMP_LINE_NBR,
		@JOB_BILL_COMMENT,
		@FEE_JOB,
		@UDV1_CODE,
		@UDV2_CODE,
		@UDV3_CODE,
		@UDV4_CODE,
		@UDV5_CODE
	)

	SET @Err = @@Error

	SELECT @ROWID = SCOPE_IDENTITY()

	RETURN @Err
END



























