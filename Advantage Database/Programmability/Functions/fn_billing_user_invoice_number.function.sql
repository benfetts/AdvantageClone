CREATE FUNCTION [dbo].[fn_billing_user_invoice_number] (
	@CL_INV_BY tinyint, @CL_CODE varchar(6), @DIV_CODE varchar(6), @PRD_CODE varchar(6),
	@SC_CODE varchar(6), @CMP_CODE varchar(6), @JOB_CL_PO_NBR varchar(40), 
	@JOB_NUMBER int, @JOB_COMPONENT_NBR smallint)

-- #01 01/17/13 - changed dimensioning for @JOB_CL_PO_NBR varchar to (40)

RETURNS varchar(65)
AS
BEGIN
	DECLARE @BU_INV_NBR varchar(100)

	SELECT @BU_INV_NBR = 
		CASE @CL_INV_BY
			WHEN 1 THEN LTRIM(STR(@JOB_NUMBER))
			WHEN 2 THEN LTRIM(STR(@JOB_NUMBER)) + '-' + LTRIM(STR(@JOB_COMPONENT_NBR))
			WHEN 3 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + ISNULL(@SC_CODE, '')
			WHEN 4 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + ISNULL(@CMP_CODE, '')
			WHEN 5 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + ISNULL(@JOB_CL_PO_NBR, '')
			WHEN 6 THEN @CL_CODE
			WHEN 7 THEN @CL_CODE + '-' + @DIV_CODE
			WHEN 8 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE
		END

	RETURN @BU_INV_NBR

END
