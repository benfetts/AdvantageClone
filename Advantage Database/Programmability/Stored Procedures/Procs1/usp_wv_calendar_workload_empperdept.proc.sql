

/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_workload_empperdept] 
@DeptCodes Varchar(4000)

AS
--Declare @Rescrictions Int
--
--Set NoCount On
--
--Select @Rescrictions = Count(*) 
--FROM SEC_CLIENT
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT DISTINCT EMP_DP_TM.EMP_CODE 
FROM EMP_DP_TM INNER JOIN charlist_to_table(@DeptCodes, DEFAULT) c ON EMP_DP_TM.DP_TM_CODE = c.vstr collate database_default



