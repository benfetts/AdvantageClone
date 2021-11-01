



















CREATE PROCEDURE [dbo].[usp_wv_validate_functioncat_all]
@EmpCode as VarChar(6), 
@FuncCat VarChar(10),
@FuncType VarChar(1)
AS

	Declare @limit_etf varchar(1)

	DECLARE @SEC_USER_ID int

	SELECT 
		@SEC_USER_ID = SEC_USER_ID
	FROM 
		[dbo].[SEC_USER]
	WHERE 
		UPPER(EMP_CODE) = UPPER(@EmpCode)
		
	IF EXISTS(SELECT * FROM [dbo].[SEC_USER_SETTING] WHERE SEC_USER_ID = @SEC_USER_ID AND SETTING_CODE = 'EMP_TS_FNC' AND STRING_VALUE = 'Y') BEGIN

		SET @limit_etf = 'Y'

	END
				

	If EXISTS(

	SELECT 
		FNC_CODE
	FROM 
		FUNCTIONS WITH (NOLOCK) 
	WHERE 
		FNC_CODE = @FuncCat 
		AND ((FNC_INACTIVE IS NULL ) OR (FNC_INACTIVE = 0))
		-- Needed to restrict for use on expense
		AND ((FNC_TYPE = 'E') OR  (FNC_TYPE = 'V'))
		AND (EX_FLAG = 1)
	)
		Select 1
	Else
		Select 0

















