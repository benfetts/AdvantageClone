





















CREATE PROCEDURE [dbo].[usp_wv_validate_poapprover] 
@EmpCode VarChar(6)
AS
Set NoCount On
 
If Exists(
SELECT  DISTINCT   PO_APPR_RULE_EMP.EMP_CODE as Code, PO_APPR_RULE_EMP.EMP_CODE + ' - ' + isnull(EMPLOYEE.EMP_LNAME, PO_APPR_RULE_EMP.EMP_CODE) + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') AS Description
FROM         PO_APPROVAL INNER JOIN
                      PO_APPR_RULE_EMP ON PO_APPROVAL.PO_APPR_RULE_ID = PO_APPR_RULE_EMP.PO_APPR_RULE_ID INNER JOIN
                      EMPLOYEE ON PO_APPR_RULE_EMP.EMP_CODE = EMPLOYEE.EMP_CODE
WHERE PO_APPR_RULE_EMP.EMP_CODE = @EmpCode
)
	 select 1
Else
	select  0





















