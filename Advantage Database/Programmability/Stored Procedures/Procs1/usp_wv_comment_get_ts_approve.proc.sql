























CREATE PROCEDURE [dbo].[usp_wv_comment_get_ts_approve] 
@EmpCode VarChar(6), 
@EmpDate SmallDateTime
AS

Select APPR_NOTES FROM EMP_TIME
Where EMP_CODE = @EmpCode
and EMP_DATE = @EmpDate























