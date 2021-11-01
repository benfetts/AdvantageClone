

















/* CHANGE LOG:
ST, 20060626: Added as quick fix for lost AE Descript in new comp for autoemail
*/
CREATE PROCEDURE [dbo].[usp_wv_GetAEDescript]
@EmpCode VARCHAR(6)
AS
SELECT
	EMP_CODE+' - '+ISNULL(EMP_FNAME,'')+ISNULL(' '+EMP_MI+'. ',' ')+ISNULL(EMP_LNAME,'') AS EMP_CODE_FULLNAME
FROM 
	EMPLOYEE
WHERE
	EMP_CODE = @EmpCode



















