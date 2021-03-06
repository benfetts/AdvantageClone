if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_get_emp_np_time_data]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_get_emp_np_time_data]
GO
CREATE PROCEDURE [dbo].[usp_wv_get_emp_np_time_data]
	@user_id	varchar(100),
	@emp_code 	varchar(6),
	@start_date	smalldatetime,
	@end_date	smalldatetime,
	@sick_flag	smallint,
	@category   varchar(10)
AS

SET NOCOUNT ON

DECLARE @NumberRecords int, @RowCount int, @etid int, @empcomments varchar(8000)
DECLARE @FROMDATE SMALLDATETIME
DECLARE @TODATE SMALLDATETIME

if @sick_flag > 0 
begin

	if @sick_flag = 1
	Begin

		SELECT @FROMDATE = VAC_FROM_DATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code
		SELECT @TODATE = VAC_TO_DATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code
		
	End
	
	if @sick_flag = 2
	Begin

		SELECT @FROMDATE = SICK_FROM_DATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code
		SELECT @TODATE = SICK_TO_DATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code

	End
	
	if @sick_flag = 3
	Begin

		SELECT @FROMDATE = PERS_FROM_DATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code
		SELECT @TODATE = PERS_TO_DATE FROM EMPLOYEE WHERE EMP_CODE = @emp_code

	End

	if @sick_flag > 3
	Begin

		SELECT @FROMDATE = @start_date
		SELECT @TODATE = @end_date

	End

	SELECT	
		EMP_TIME.EMP_DATE, 
		EMP_TIME_NP.EMP_HOURS, 
		ISNULL(EMP_TIME_DTL_CMTS.EMP_COMMENT,'') AS COMMENTS
	FROM         
		TIME_CATEGORY INNER JOIN
		EMP_TIME_NP ON TIME_CATEGORY.CATEGORY = EMP_TIME_NP.CATEGORY INNER JOIN
		EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
		EMP_TIME_DTL_CMTS ON EMP_TIME_NP.ET_ID = EMP_TIME_DTL_CMTS.ET_ID AND 
		EMP_TIME_NP.ET_DTL_ID = EMP_TIME_DTL_CMTS.ET_DTL_ID AND EMP_TIME_NP.SEQ_NBR = EMP_TIME_DTL_CMTS.SEQ_NBR
	WHERE     
		(TIME_CATEGORY.VAC_SICK_FLAG = @sick_flag) AND 
		(EMP_TIME.EMP_CODE = @emp_code) AND 
		(EMP_TIME.EMP_DATE BETWEEN @FROMDATE AND @TODATE) AND 
		(EMP_TIME_DTL_CMTS.ET_SOURCE = 'N' OR EMP_TIME_DTL_CMTS.ET_SOURCE IS NULL) AND 
		EMP_TIME_NP.EMP_HOURS > 0
	ORDER BY EMP_TIME.EMP_DATE

end

if @sick_flag = 0
Begin

	SELECT 
		EMP_TIME.EMP_DATE, 
		EMP_TIME_NP.EMP_HOURS, 
		ISNULL(EMP_TIME_DTL_CMTS.EMP_COMMENT,'') AS COMMENTS
	FROM         
		TIME_CATEGORY INNER JOIN
		EMP_TIME_NP ON TIME_CATEGORY.CATEGORY = EMP_TIME_NP.CATEGORY INNER JOIN
		EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID LEFT OUTER JOIN
		EMP_TIME_DTL_CMTS ON EMP_TIME_NP.ET_ID = EMP_TIME_DTL_CMTS.ET_ID AND 
		EMP_TIME_NP.ET_DTL_ID = EMP_TIME_DTL_CMTS.ET_DTL_ID AND EMP_TIME_NP.SEQ_NBR = EMP_TIME_DTL_CMTS.SEQ_NBR
	WHERE     
		(TIME_CATEGORY.VAC_SICK_FLAG NOT IN(1,2,3) OR TIME_CATEGORY.VAC_SICK_FLAG IS NULL) AND 
		(EMP_TIME.EMP_CODE = @emp_code ) AND 
		(EMP_TIME.EMP_DATE BETWEEN @start_date AND @end_date) AND 
		(TIME_CATEGORY.CATEGORY = @category) AND (EMP_TIME_DTL_CMTS.ET_SOURCE = 'N' OR EMP_TIME_DTL_CMTS.ET_SOURCE IS NULL) AND EMP_TIME_NP.EMP_HOURS > 0
	ORDER BY EMP_TIME.EMP_DATE

End 

SET QUOTED_IDENTIFIER ON
