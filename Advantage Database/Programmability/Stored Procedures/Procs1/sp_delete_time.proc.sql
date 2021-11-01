
CREATE PROCEDURE [dbo].[sp_delete_time] @et_id integer, @etd_id integer, @time_type char(1), 
	@error_text varchar(254) OUTPUT
	
	AS

SET NOCOUNT ON
	
DECLARE @row_count integer, @error_code integer, @emp_code varchar(6), @emp_date smalldatetime

BEGIN TRANSACTION

SELECT @error_code = 0

IF @time_type = 'D'
	BEGIN
		SELECT @row_count = ( SELECT COUNT(*) FROM EMP_TIME_DTL WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id )
		IF @row_count = 1
			BEGIN
				DELETE FROM EMP_TIME_DTL 
				 WHERE ET_ID = @et_id 
   				 AND ET_DTL_ID = @etd_id
				IF @@ERROR <> 0
					BEGIN
						SELECT @error_code = @@ERROR
						SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Delete record failed.'
					END
			END
		ELSE -- Cannot delete multiple row records
			BEGIN
				SELECT @error_code = -1
				SELECT @error_text = 'Error -1: Cannot delete summary records.'
			END
	END	
ELSE IF @time_type = 'N' -- Delete non-productive time
	BEGIN
		SELECT @row_count = ( SELECT COUNT(*) FROM EMP_TIME_NP WHERE ET_ID = @et_id AND ET_DTL_ID = @etd_id )
		IF @row_count = 1
			BEGIN

				DELETE FROM EMP_TIME_NP
				 WHERE ET_ID = @et_id 
   				 AND ET_DTL_ID = @etd_id

				IF @@ERROR <> 0
					BEGIN
						SELECT @error_code = @@ERROR
						SELECT @error_text = 'Error ' + RTRIM( CONVERT( varchar(10), @error_code )) + ': Delete record failed.'
					END
			END
		ELSE -- Cannot delete multiple row records
			BEGIN
				SELECT @error_code = -1
				SELECT @error_text = 'Error -1: Cannot delete summary records.'
			END
	END	

IF @error_code = 0
	BEGIN
		-- BJL - 11/25/03
		DELETE FROM EMP_TIME_DTL_CMTS
		 WHERE ET_ID = @et_id 
   		   AND ET_DTL_ID = @etd_id

		SELECT @emp_code = ( SELECT EMP_CODE FROM EMP_TIME WHERE ET_ID = @et_id )
		SELECT @emp_date = ( SELECT EMP_DATE FROM EMP_TIME WHERE ET_ID = @et_id )
	  EXECUTE sp_update_header_hours @emp_code, @emp_date
		COMMIT
	END
ELSE
	ROLLBACK

SELECT @error_text
