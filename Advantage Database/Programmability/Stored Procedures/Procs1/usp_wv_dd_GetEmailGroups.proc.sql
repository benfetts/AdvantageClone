

















/*
ST, 20060620:
Removed emp code filter and added distinct
*/





CREATE PROCEDURE [dbo].[usp_wv_dd_GetEmailGroups] 
@EmpCode as VarChar(6)
AS
Set NoCount On

SELECT     DISTINCT EMAIL_GR_CODE AS Code, EMAIL_GR_CODE AS Description
FROM         EMAIL_GROUP
Where 
--EMP_CODE = @EmpCode AND
 (INACTIVE_FLAG =0 OR INACTIVE_FLAG IS NULL)

















