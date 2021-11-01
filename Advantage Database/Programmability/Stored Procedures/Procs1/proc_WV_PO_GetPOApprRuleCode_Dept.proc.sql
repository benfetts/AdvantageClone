
CREATE PROCEDURE [dbo].[proc_WV_PO_GetPOApprRuleCode_Dept](@Dept as varchar(4)) AS
 declare @code as varchar(6)
   select ISNULL(PO_APPR_RULE_CODE, '') from DEPT_TEAM
				  where DP_TM_CODE = @Dept
  --return @code

