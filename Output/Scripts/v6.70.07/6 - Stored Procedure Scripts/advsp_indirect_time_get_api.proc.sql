IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_indirect_time_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_indirect_time_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_indirect_time_get_api] 
	@start_date smalldatetime,	/* Date to Pay range Start */
	@end_date smalldatetime,	/* Date to Pay range End */
	@emp_code varchar(6),		/* Employee code or NULL - NULL or * = all employees */

	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE
	@DEBUG int

DECLARE
	@found int = 0

IF @emp_code = '' SET @emp_code = NULL

SET @ret_val_s = 'Success...'

BEGIN TRY

SET NOCOUNT ON

SET @ret_val = 0
SET @ret_val_s = NULL

IF @emp_code IN ('', '*')
	SET @emp_code = NULL

IF ISDATE(@start_date) <> 1 BEGIN
	SET @error_msg_w = 'Invalid Start Date'
	GOTO ERROR_MSG
END

IF ISDATE(@end_date) <> 1 BEGIN
	SET @error_msg_w = 'Invalid End Date'
	GOTO ERROR_MSG
END

IF @end_date < @start_date BEGIN
	SET @error_msg_w = 'The End Date can not be prior to the Start Date'
	GOTO ERROR_MSG
END

SET @found = 0

IF @emp_code IS NOT NULL
	SELECT @found = 1 FROM [dbo].[EMPLOYEE] WHERE EMP_CODE = @emp_code
Else
	SET @found = 1

IF @found < 1 BEGIN
	SET @error_msg_w = 'Invalid Employee Code'
	GOTO ERROR_MSG
END

/* Return Dataset from EMP_TIME_NP */
BEGIN

	SELECT A.ET_ID, B.ET_DTL_ID,
	A.EMP_CODE EmployeeCode, 
	C.EMP_FNAME EmployeeFirstName, 
	C.EMP_LNAME EmployeeLastName, 
	D.OFFICE_NAME EmployeeOfficeName, 
	E.DP_TM_DESC EmployeeDepartmentName,
	A.EMP_DATE TimesheetDate,
	B.CATEGORY TimeCategory,
	B.EMP_HOURS 'Hours',
	B.DATE_ENTERED CreateDate,
	F.EMP_COMMENT Comments
	FROM EMP_TIME A JOIN
		EMP_TIME_NP B ON A.ET_ID = B.ET_ID JOIN
		EMPLOYEE C ON A.EMP_CODE = C.EMP_CODE LEFT JOIN
		OFFICE D ON C.OFFICE_CODE = D.OFFICE_CODE LEFT JOIN
		EMP_DP_TM E ON E.EMP_CODE = C.EMP_CODE AND C.DP_TM_CODE = E.DP_TM_CODE LEFT JOIN
		EMP_TIME_DTL_CMTS F ON B.ET_ID = F.ET_ID AND B.ET_DTL_ID = F.ET_DTL_ID AND B.SEQ_NBR = F.SEQ_NBR AND F.ET_SOURCE = 'N'
	WHERE (A.EMP_CODE = @emp_code OR @emp_code IS NULL)
		AND (A.EMP_DATE BETWEEN @start_date AND @end_date)

END

IF @@ROWCOUNT = 0 BEGIN
	SET @ret_val = 1
	SET @ret_val_s = 'No matching records'
END


GOTO ENDIT
  
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();

	IF @ErMessage IS NOT NULL BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

END CATCH

RETURN
GO

GRANT EXECUTE ON [advsp_indirect_time_get_api] TO PUBLIC AS dbo
GO