
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_get_currency_info]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	DROP PROCEDURE [dbo].[advsp_get_currency_info]
GO

CREATE PROCEDURE [dbo].[advsp_get_currency_info] @bk_code varchar(6), @currency_code varchar(6) OUTPUT, @currency_symbol nvarchar(6) OUTPUT
AS

--v6.70.01.06 - version

SET ANSI_WARNINGS OFF

DECLARE @home_currency varchar(10)
DECLARE @bank_currency varchar(10)
DECLARE @ap_currency varchar(10)

IF @bk_code > ''
	SELECT @bank_currency = CURRENCY_CODE
	FROM BANK
	WHERE BK_CODE = @bk_code;	
ELSE
	IF @currency_code > ''
		SET @bank_currency = @currency_code
	
SELECT @home_currency = HOME_CRNCY
FROM AGENCY;	

IF @bank_currency = ''
	SET @bank_currency = NULL

IF @home_currency = ''
	SET @home_currency = NULL
	
SET @currency_code = @bank_currency

IF @currency_code IS NULL
	SET @currency_code = @home_currency

IF @currency_code IS NULL
	SET @currency_code = 'USD'

SELECT @currency_symbol = COALESCE(CURRENCY_SYMBOL, CURRENCY_CODE)
FROM CURRENCY_CODES
WHERE CURRENCY_CODE = @currency_code;
	
IF @currency_symbol IS NULL OR @currency_symbol = ''
	SET @currency_symbol = '$'

--SELECT @bk_code, @currency_code, @currency_symbol 
SELECT @bank_currency '@bank_currency', @home_currency '@home_currency', @currency_code '@currency_code'

GO		

GRANT EXECUTE ON [advsp_get_currency_info] TO PUBLIC AS dbo
GO

