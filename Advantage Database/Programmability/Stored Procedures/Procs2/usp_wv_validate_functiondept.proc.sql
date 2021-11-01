



















CREATE PROCEDURE [dbo].[usp_wv_validate_functiondept]
@EmpCode as VarChar(6), 
@FuncCat VarChar(10)
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
					
	IF @limit_etf = 'Y'
		If Exists(
		SELECT COUNT(*) 
		FROM EMP_TS_FNC etf, FUNCTIONS f
		WHERE f.FNC_CODE = @FuncCat 
		AND f.FNC_CODE = etf.FNC_CODE
		AND EMP_CODE = @EmpCode
		AND FNC_TYPE = 'E'
		AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ))
			Select 1
		Else
			Select 0
	ELSE
		If Exists(
		SELECT COUNT(*) 
		FROM FUNCTIONS 
		WHERE FNC_CODE = @FuncCat 
		AND FNC_TYPE = 'E'
		AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 ))
			Select 1
		Else
			Select 0




















