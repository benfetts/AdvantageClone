
CREATE PROCEDURE [dbo].[proc_WV_PO_GetPOApprRuleCode_Emp](@EmpCode as varchar(6)) AS
 declare @code as varchar(6)
   select ISNULL(PO_APPR_RULE_CODE, '') from EMPLOYEE
				  where EMP_CODE = @EmpCode
--  return @code

