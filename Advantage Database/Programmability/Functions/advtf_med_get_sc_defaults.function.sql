
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_get_sc_defaults]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_get_sc_defaults]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[advtf_med_get_sc_defaults] (
		@cl_code	varchar (6), 
		@div_code	varchar (6),
		@prd_code	varchar (6),
		@order_type varchar (2),
		@sc_code varchar(6) 
		)
	RETURNS @med_billed TABLE ( 
		[SC_MARKUP] [decimal](7, 3) NULL,
		[SC_REBATE] [decimal](7, 3) NULL
		)
AS
BEGIN

	--IF @order_type =  'NP'

	DECLARE @rebate decimal(14, 4), @markup decimal(14, 4)

	INSERT INTO @med_billed SELECT NULL, NULL
	
	/* PJH 01/11/16 - Added */
	IF @sc_code IS NOT NULL BEGIN
		SELECT	@rebate = REBATE, @markup = MARKUP 
		FROM PRODUCT_MEDIA_OVERRIDES
		WHERE CL_CODE = @cl_code AND
				DIV_CODE = @div_code AND
				PRD_CODE = @prd_code AND
				MEDIA_TYPE = LEFT(@order_type, 1) AND
				SC_CODE = @sc_code /* media type */;
				
		IF 	@rebate > 0 UPDATE @med_billed SET [SC_REBATE] = @rebate
		IF 	@markup > 0 UPDATE @med_billed SET [SC_MARKUP] = @markup
	END


	RETURN
END

GO