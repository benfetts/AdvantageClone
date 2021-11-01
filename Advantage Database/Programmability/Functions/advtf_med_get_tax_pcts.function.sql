/****** Object:  UserDefinedFunction [dbo].[advtf_advance_bill_by_job]    Script Date: 05/15/2015 16:07:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_get_tax_pcts]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_get_tax_pcts]
GO

/****** Object:  UserDefinedFunction [dbo].[advtf_med_get_tax_pcts]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* 
SELECT * FROM MAGAZINE_HEADER WHERE ORDER_NBR > 700
SELECT TAX_CODE, BILL_TYPE_FLAG, * FROM MAGAZINE_DETAIL WHERE TAX_CITY_PCT > 0 --ORDER_NBR > 700

SELECT * FROM SALES_TAX

SELECT * FROM advtf_med_get_tax_pcts('resl')
*/

CREATE FUNCTION [dbo].advtf_med_get_tax_pcts (
		@tax_code varchar (4)
		)
	RETURNS @med_defaults TABLE ( 
		[TAX_CODE] [varchar](4),
		[TAX_CITY_PCT] [decimal](7, 3) NULL,
		[TAX_COUNTY_PCT] [decimal](7, 3) NULL,
		[TAX_STATE_PCT] [decimal](7, 3) NULL,
		[TAX_RESALE] [smallint] NULL
		)
AS
BEGIN
		DECLARE 	@tax_city_pct decimal (7, 3) ,
			@tax_county_pct decimal (7, 3) ,
			@tax_state_pct decimal (7, 3) ,
			@tax_resale smallint 
									
		IF @tax_code = ''
			SET @tax_code = NULL
	
		IF @tax_code IS NOT NULL
			BEGIN
				--SELECT	 TAX_CITY_PERCENT, TAX_COUNTY_PERCENT,
				--			TAX_STATE_PERCENT, TAX_RESALE
				--FROM	 dbo.SALES_TAX
				--WHERE	 TAX_CODE='vend';
				SELECT	 @tax_city_pct=TAX_CITY_PERCENT, @tax_county_pct=TAX_COUNTY_PERCENT,
							@tax_state_pct=TAX_STATE_PERCENT, @tax_resale=TAX_RESALE
				FROM	 dbo.SALES_TAX
				WHERE	 TAX_CODE=@tax_code;		
			END
		ELSE
			BEGIN
				SET @tax_city_pct = 0
				SET @tax_county_pct = 0
				SET @tax_state_pct = 0
				SET @tax_resale = 0 --no
			END

		--Sales tax table has null when tax is not resale so lets make sure we get a
		IF (@tax_resale) IS NULL
			SET @tax_resale = 0

		IF (@tax_city_pct) IS NULL
			SET @tax_city_pct = 0
		IF (@tax_county_pct) IS NULL
			SET @tax_county_pct = 0
		IF (@tax_state_pct) IS NULL
			SET @tax_state_pct = 0		
			
		INSERT INTO @med_defaults
		VALUES (@tax_code,
			@tax_city_pct ,
			@tax_county_pct ,
			@tax_state_pct ,
			@tax_resale )		

RETURN
END

GO


