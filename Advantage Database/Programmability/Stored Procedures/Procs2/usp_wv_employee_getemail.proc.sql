

CREATE PROCEDURE [dbo].[usp_wv_employee_getemail] 
@EmpCode as VarChar(6),
@CheckEmailFlag as tinyint,
@GetMailBeeFormatted as tinyint
AS

	DECLARE @RTN VARCHAR(50), @RTN_MAILBEE VARCHAR(1000)

	IF @CheckEmailFlag = 0
	BEGIN
		SELECT 
			@RTN = ISNULL(EMP_EMAIL, ''), 
			@RTN_MAILBEE =  ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') +  ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + ISNULL(EMP_EMAIL, '') + '>' 
		FROM   EMPLOYEE WITH(NOLOCK)
		WHERE  EMP_CODE = @EmpCode;
	END

	IF @CheckEmailFlag = 1
	BEGIN
		SELECT 
			@RTN = ISNULL(EMP_EMAIL, ''), 
			@RTN_MAILBEE =  ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') +  ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + ISNULL(EMP_EMAIL, '') + '>' 
		FROM   EMPLOYEE WITH(NOLOCK)
		WHERE  EMP_CODE = @EmpCode
			   AND (ALERT_EMAIL = 1 OR ALERT_EMAIL = 3);
	END

	IF @GetMailBeeFormatted = 0
	BEGIN
		SELECT ISNULL(@RTN, '');
	END

	IF @GetMailBeeFormatted = 1
	BEGIN
		SELECT ISNULL(@RTN_MAILBEE, '');
	END

