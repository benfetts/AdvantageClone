






/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_duplicationCDP] 
@CDPCode as int
AS

Set NoCount On

SELECT     CL_CODE, DIV_CODE, PRD_CODE 
FROM         CP_SEC_CLIENT 
WHERE CDP_CONTACT_ID = @CDPCode


























