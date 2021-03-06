



























CREATE PROCEDURE [dbo].[proc_CAMPAIGNUpdate]
(
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6),
	@CMP_CODE varchar(6),
	@CMP_BEG_DATE smalldatetime = NULL,
	@CMP_END_DATE smalldatetime = NULL,
	@CMP_COMMENTS text = NULL,
	@CMP_NAME varchar(128) = NULL,
	@CMP_DIRECT smallint = NULL,
	@CMP_MAGAZINE smallint = NULL,
	@CMP_NEWSPAPER smallint = NULL,
	@CMP_OUTDOOR smallint = NULL,
	@CMP_PRINT_COLL smallint = NULL,
	@CMP_RADIO smallint = NULL,
	@CMP_TELEVISION smallint = NULL,
	@CMP_OTHER smallint = NULL,
	@CMP_OTHER_EXPLAIN varchar(30) = NULL,
	@CMP_IDENTIFIER int,
	@CMP_CLOSED smallint = NULL,
	@ACTIVE_FLAG smallint = NULL,
	@CMP_BILL_BUDGET decimal(18,2) = NULL,
	@CMP_INC_BUDGET decimal(18,2) = NULL,
	@CMP_TYPE smallint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [CAMPAIGN]
	SET
		[CL_CODE] = @CL_CODE,
		[DIV_CODE] = @DIV_CODE,
		[PRD_CODE] = @PRD_CODE,
		[CMP_CODE] = @CMP_CODE,
		[CMP_BEG_DATE] = @CMP_BEG_DATE,
		[CMP_END_DATE] = @CMP_END_DATE,
		[CMP_COMMENTS] = @CMP_COMMENTS,
		[CMP_NAME] = @CMP_NAME,
		[CMP_DIRECT] = @CMP_DIRECT,
		[CMP_MAGAZINE] = @CMP_MAGAZINE,
		[CMP_NEWSPAPER] = @CMP_NEWSPAPER,
		[CMP_OUTDOOR] = @CMP_OUTDOOR,
		[CMP_PRINT_COLL] = @CMP_PRINT_COLL,
		[CMP_RADIO] = @CMP_RADIO,
		[CMP_TELEVISION] = @CMP_TELEVISION,
		[CMP_OTHER] = @CMP_OTHER,
		[CMP_OTHER_EXPLAIN] = @CMP_OTHER_EXPLAIN,
		[CMP_CLOSED] = @CMP_CLOSED,
		[ACTIVE_FLAG] = @ACTIVE_FLAG,
		[CMP_BILL_BUDGET] = @CMP_BILL_BUDGET,
		[CMP_INC_BUDGET] = @CMP_INC_BUDGET,
		[CMP_TYPE] = @CMP_TYPE
	WHERE
		[CMP_IDENTIFIER] = @CMP_IDENTIFIER


	SET @Err = @@Error


	RETURN @Err
END



























