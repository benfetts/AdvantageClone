



























CREATE PROCEDURE [dbo].[proc_JOB_LOGUpdate]
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
	@ROWID int,
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

	UPDATE [JOB_LOG]
	SET
		[OFFICE_CODE] = @OFFICE_CODE,
		[CL_CODE] = @CL_CODE,
		[DIV_CODE] = @DIV_CODE,
		[PRD_CODE] = @PRD_CODE,
		[CMP_CODE] = @CMP_CODE,
		[SC_CODE] = @SC_CODE,
		[USER_ID] = @USER_ID,
		[CREATE_DATE] = @CREATE_DATE,
		[JOB_DESC] = @JOB_DESC,
		[JOB_DATE_OPENED] = @JOB_DATE_OPENED,
		[JOB_RUSH_CHARGES] = @JOB_RUSH_CHARGES,
		[JOB_ESTIMATE_REQ] = @JOB_ESTIMATE_REQ,
		[JOB_COMMENTS] = @JOB_COMMENTS,
		[JOB_CLI_REF] = @JOB_CLI_REF,
		[BILL_COOP_CODE] = @BILL_COOP_CODE,
		[FORMAT_SC_CODE] = @FORMAT_SC_CODE,
		[FORMAT_CODE] = @FORMAT_CODE,
		[COMPLEX_CODE] = @COMPLEX_CODE,
		[PROMO_CODE] = @PROMO_CODE,
		[CMP_IDENTIFIER] = @CMP_IDENTIFIER,
		[CMP_LINE_NBR] = @CMP_LINE_NBR,
		[JOB_BILL_COMMENT] = @JOB_BILL_COMMENT,
		[FEE_JOB] = @FEE_JOB,
		[UDV1_CODE] = @UDV1_CODE,
		[UDV2_CODE] = @UDV2_CODE,
		[UDV3_CODE] = @UDV3_CODE,
		[UDV4_CODE] = @UDV4_CODE,
		[UDV5_CODE] = @UDV5_CODE
	WHERE
		[JOB_NUMBER] = @JOB_NUMBER


	SET @Err = @@Error


	RETURN @Err
END



























