



























CREATE PROCEDURE [dbo].[proc_DIVISIONLoadByPrimaryKey]
(
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CL_CODE],
		[DIV_CODE],
		[DIV_NAME],
		[DIV_ATTENTION],
		[DIV_BADDRESS1],
		[DIV_BADDRESS2],
		[DIV_BCITY],
		[DIV_BCOUNTY],
		[DIV_BSTATE],
		[DIV_BCOUNTRY],
		[DIV_BZIP],
		[DIV_SADDRESS1],
		[DIV_SADDRESS2],
		[DIV_SCITY],
		[DIV_SCOUNTY],
		[DIV_SSTATE],
		[DIV_SCOUNTRY],
		[DIV_SZIP],
		[DIV_ALPHA_SORT],
		[ACTIVE_FLAG]
	FROM [DIVISION]
	WHERE
		([CL_CODE] = @CL_CODE) AND
		([DIV_CODE] = @DIV_CODE)

	SET @Err = @@Error

	RETURN @Err
END



























