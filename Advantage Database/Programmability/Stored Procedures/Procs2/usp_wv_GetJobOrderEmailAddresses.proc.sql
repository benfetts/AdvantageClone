







CREATE PROCEDURE [dbo].[usp_wv_GetJobOrderEmailAddresses]
@EmpCodes Varchar(4000)
AS

SELECT     EMPLOYEE.EMP_CODE AS EmpCodeName, 
           EMPLOYEE.EMP_EMAIL AS EmailAddress, ISNULL(EMPLOYEE.EMP_LNAME, '') + ', ' + ISNULL(EMPLOYEE.EMP_FNAME, '') 
                      + ' ' + ISNULL(EMPLOYEE.EMP_MI, '') AS EmpName, ALERT_EMAIL
FROM       EMPLOYEE INNER JOIN charlist_to_table(@EmpCodes, DEFAULT) c ON EMPLOYEE.EMP_CODE = c.vstr collate database_default




















