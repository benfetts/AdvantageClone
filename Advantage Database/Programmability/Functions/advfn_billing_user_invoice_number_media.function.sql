if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advfn_billing_user_invoice_number_media]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advfn_billing_user_invoice_number_media]
GO


CREATE FUNCTION [dbo].[advfn_billing_user_invoice_number_media] (
	@CL_MINV_BY tinyint, @CL_CODE varchar(6), @DIV_CODE varchar(6), @PRD_CODE varchar(6),
	@MEDIA_TYPE varchar(2), @MKT_CODE varchar(6), @CMP_CODE varchar(6), 
	@JOB_CL_PO_NBR varchar(40), @ORDER_NBR int)

-- #00 04/03/13 - initial - copied from "fn_billing_user_invoice_number"

RETURNS varchar(65)
AS
BEGIN
	DECLARE @BU_INV_NBR varchar(100)

	SELECT @BU_INV_NBR = 
		CASE @CL_MINV_BY
			WHEN 1 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + @MEDIA_TYPE
			WHEN 2 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + @MEDIA_TYPE + '-' + ISNULL(@JOB_CL_PO_NBR, '')
			WHEN 3 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + @MEDIA_TYPE + '-' + ISNULL(@MKT_CODE, '')
			WHEN 4 THEN LTRIM(STR(@ORDER_NBR))
			WHEN 5 THEN @CL_CODE + '-' + @DIV_CODE + '-' + @PRD_CODE + '-' + @MEDIA_TYPE + '-' + ISNULL(@CMP_CODE, '')
		END

	RETURN @BU_INV_NBR

END

