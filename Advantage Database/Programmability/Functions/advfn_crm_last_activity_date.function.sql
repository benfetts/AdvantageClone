CREATE FUNCTION [dbo].[advfn_crm_last_activity_date](
	@cl_code	varchar(6),
	@div_code	varchar(6),
	@prod_code	varchar(6))
		
RETURNS smalldatetime
WITH SCHEMABINDING 
AS
BEGIN
	DECLARE @last_activity_date smalldatetime
	
	SELECT @last_activity_date = MAX(LAST_DATE) 
	FROM (
	SELECT MAX(GENERATED) AS LAST_DATE
	FROM [dbo].ALERT
	WHERE ALERT_TYPE_ID=11
	AND CL_CODE = @cl_code
	AND DIV_CODE = @div_code
	AND PRD_CODE = @prod_code

	UNION
	
	SELECT MAX([START_DATE]) AS LAST_DATE
	FROM [dbo].EMP_NON_TASKS
	WHERE [TYPE]='C'
	AND CL_CODE = @cl_code
	AND DIV_CODE = @div_code
	AND PRD_CODE = @prod_code) T

	RETURN @last_activity_date 	
END

GO


