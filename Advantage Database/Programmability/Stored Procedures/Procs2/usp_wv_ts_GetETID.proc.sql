























CREATE PROCEDURE [dbo].[usp_wv_ts_GetETID]
@Empcode VarChar(6),
@EmpDate SmallDateTime
AS

Select ISNULL(ET_ID,0) 
From EMP_TIME WITH (NOLOCK) 
Where EMP_CODE = @Empcode 
and EMP_DATE = @EmpDate























