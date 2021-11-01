﻿





CREATE PROCEDURE [dbo].[usp_wv_Estimating_QuoteApprovalSecurity] 
@UserCode varchar(100)
AS

	DECLARE @SETTING_VALUE char(1)
	DECLARE @SEC_USER_ID int

	SELECT 
		@SEC_USER_ID = SEC_USER_ID
	FROM 
		[dbo].[SEC_USER]
	WHERE 
		UPPER(USER_CODE) = UPPER(@UserCode)

	IF EXISTS(SELECT * FROM [dbo].[SEC_USER_SETTING] WHERE SEC_USER_ID = @SEC_USER_ID AND SETTING_CODE = 'PR_QUOTE_APPR' AND STRING_VALUE = 'N') BEGIN

		SET @SETTING_VALUE = 'N'

	END ELSE BEGIN

		SET @SETTING_VALUE = 'Y'

	END

	SELECT
		[PR_QUOTE_APPR] = @SETTING_VALUE 






















