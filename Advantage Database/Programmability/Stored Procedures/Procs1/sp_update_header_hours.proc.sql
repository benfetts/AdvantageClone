
CREATE PROCEDURE [dbo].[sp_update_header_hours] @emp_code varchar(6), @emp_date smalldatetime
	
	AS

SET NOCOUNT ON
	

UPDATE EMP_TIME
	 SET EMP_TIME.EMP_DTL_HRS = (	SELECT COALESCE( SUM( EMP_HOURS ), 0 )
																	FROM EMP_TIME_DTL et
																 WHERE EMP_TIME.EMP_CODE = @emp_code
																	 AND EMP_TIME.ET_ID = et.ET_ID
															GROUP BY EMP_TIME.ET_ID )
 WHERE EMP_TIME.EMP_CODE = @emp_code
	 AND EMP_TIME.EMP_DATE = @emp_date


UPDATE EMP_TIME
	 SET EMP_TIME.EMP_NP_HRS = ( SELECT SUM( EMP_HOURS )
																 FROM	EMP_TIME_NP np
																WHERE	EMP_TIME.EMP_CODE = @emp_code
																	AND	EMP_TIME.ET_ID = np.ET_ID
														 GROUP BY EMP_TIME.ET_ID )
 WHERE EMP_TIME.EMP_CODE = @emp_code 
	 AND EMP_TIME.EMP_DATE = @emp_date

UPDATE EMP_TIME
	 SET EMP_TIME.EMP_NP_HRS = 0
 WHERE EMP_TIME.EMP_CODE = @emp_code
	 AND EMP_TIME.EMP_DATE = @emp_date
	 AND EMP_TIME.EMP_NP_HRS IS NULL

UPDATE EMP_TIME
	 SET EMP_TIME.EMP_DTL_HRS = 0
 WHERE EMP_TIME.EMP_CODE = @emp_code
	 AND EMP_TIME.EMP_DATE = @emp_date
   AND EMP_TIME.EMP_DTL_HRS IS NULL


UPDATE EMP_TIME
	 SET EMP_TOT_HRS = (EMP_DTL_HRS + EMP_NP_HRS)
 WHERE EMP_CODE = @emp_code
   AND EMP_DATE = @emp_date
