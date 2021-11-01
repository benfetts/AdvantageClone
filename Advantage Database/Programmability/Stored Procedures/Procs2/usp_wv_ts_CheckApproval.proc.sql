























CREATE PROCEDURE [dbo].[usp_wv_ts_CheckApproval]
@Empcode VarChar(6),
@EmpDate SmallDateTime
AS

Select ISNULL(APPR_FLAG, 0) + ISNULL(APPR_PENDING, 0)
From EMP_TIME WITH (NOLOCK) 
Where EMP_CODE = @Empcode 
and EMP_DATE = @EmpDate























