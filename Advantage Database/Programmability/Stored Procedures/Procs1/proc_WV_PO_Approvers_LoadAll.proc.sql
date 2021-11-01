/****** Object:  StoredProcedure [dbo].[proc_WV_PO_Approvers_LoadAll]    Script Date: 7/16/2019 5:02:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[proc_WV_PO_Approvers_LoadAll]

AS

SELECT  DISTINCT   PO_APPR_RULE_EMP.EMP_CODE as Code,
					EMPLOYEE.EMP_FNAME FirstName,
					EMPLOYEE.EMP_LNAME LastName,
					EMPLOYEE.EMP_MI MiddleInitial,
 PO_APPR_RULE_EMP.EMP_CODE + ' - ' + isnull(EMPLOYEE.EMP_LNAME, PO_APPR_RULE_EMP.EMP_CODE) + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') AS Description
FROM         dbo.PO_APPROVAL INNER JOIN
                      dbo.PO_APPR_RULE_EMP ON dbo.PO_APPROVAL.PO_APPR_RULE_ID = dbo.PO_APPR_RULE_EMP.PO_APPR_RULE_ID INNER JOIN
                      dbo.EMPLOYEE ON dbo.PO_APPR_RULE_EMP.EMP_CODE = dbo.EMPLOYEE.EMP_CODE
      
 




GO


