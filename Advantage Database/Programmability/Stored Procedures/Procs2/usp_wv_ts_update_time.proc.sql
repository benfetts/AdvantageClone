/* BJL - 11/23/03 - This procedure has been completely revamped. It is ONLY used to update the start and end times,
	not the comments */

CREATE PROCEDURE [dbo].[usp_wv_ts_update_time] @et_id integer, @etd_id integer, @time_type varchar(1),	
	@start_time char(4), @end_time char(4)
	
	AS

SET NOCOUNT ON

DECLARE @row_count int

IF @et_id > 0
BEGIN

	BEGIN TRANSACTION

	SELECT @row_count = ( SELECT COUNT(*) 
							FROM EMP_TIME_DTL_CMTS WITH(NOLOCK)
						   WHERE ET_ID = @et_id
							 AND ET_DTL_ID = @etd_id )

	IF @row_count = 1 
	  UPDATE EMP_TIME_DTL_CMTS WITH(ROWLOCK)
		 SET START_TIME = @start_time,
			 END_TIME = @end_time
	   WHERE ET_ID = @et_id
		 AND ET_DTL_ID = @etd_id
	ELSE 
	  INSERT INTO EMP_TIME_DTL_CMTS WITH (ROWLOCK)( ET_ID, ET_DTL_ID, SEQ_NBR, ET_SOURCE, START_TIME, END_TIME )
		   VALUES ( @et_id, @etd_id, 0, @time_type, @start_time, @end_time )
	COMMIT

END


























