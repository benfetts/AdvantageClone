IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_Traffic_Schedule_Calculate_JobPred]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_Traffic_Schedule_Calculate_JobPred]
GO
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_Calculate_JobPred] @job_number integer, @job_component_nbr smallint, @use_predecessor bit, @emp_code as varchar(6), @ret_val integer OUTPUT
AS

SET ANSI_NULLS ON
SET ANSI_WARNINGS OFF
SET ARITHABORT OFF
SET ARITHIGNORE ON

SET NOCOUNT ON

-- @use_predecessor: on = 1, off = 0

DECLARE @by_start smallint, @include_phase bit, @max_days int, @trf_calc_by_cmp bit, 
		@start_date smalldatetime, @first_use_date smalldatetime,
		@schedule_by smallint, @lock_flag bit, @latest_lock_date smalldatetime, @day_sum integer,
		@sort_col decimal(13,6), @sort_col2 decimal(13,6), @sort_col3 decimal(13,6), @trf_calc_concur_dt bit,
		@job_pred int, @job_comp_pred int, @schedule_calc int, @pred int, @job_order int,
		@ctr as int, @day_option int, @job_pred_end_date smalldatetime, @job_num int, @job_comp int
		
SELECT @ret_val = 0

--SET SETTING FLAGS
SET @trf_calc_by_cmp = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_BY_CMP' )
SET @lock_flag = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_LOCK_DATE' )
SET @schedule_by = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_SCHEDULE_BY' )
SET @include_phase = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'USE_PHASE' )
SET @trf_calc_concur_dt = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_CONCUR_DT' )
SET @day_option = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_BY_DAY' )

SET @job_order = (SELECT CASE WHEN DISPLAY_TYPE = 'G' THEN 1
 			WHEN DISPLAY_TYPE = 'GA' THEN 1
 			WHEN DISPLAY_TYPE IS NULL THEN 0
 			ELSE 0
			END AS SHOW_ON_GRID    
FROM JOB_TRAFFIC_SETUP_DTL INNER JOIN
     JOB_TRAFFIC_SETUP_ITEMS ON JOB_TRAFFIC_SETUP_DTL.COLUMN_ID = JOB_TRAFFIC_SETUP_ITEMS.ID
WHERE HDR_CODE = @emp_code and COLUMN_NAME = 'colJOB_ORDER')

SET @pred = (SELECT CASE WHEN DISPLAY_TYPE = 'G' THEN 1
 			WHEN DISPLAY_TYPE = 'GA' THEN 1
 			WHEN DISPLAY_TYPE IS NULL THEN 0
 			ELSE 0
			END AS SHOW_ON_GRID    
FROM JOB_TRAFFIC_SETUP_DTL INNER JOIN
		 JOB_TRAFFIC_SETUP_ITEMS ON JOB_TRAFFIC_SETUP_DTL.COLUMN_ID = JOB_TRAFFIC_SETUP_ITEMS.ID
WHERE HDR_CODE = @emp_code and COLUMN_NAME = 'colPREDECESSORS_TEXT')
--SELECT @pred
if @pred IS NULL
BEGIN
	SET @pred = 0
END

if @job_order IS NULL and @pred = 0
BEGIN
	SET @job_order = 1
END

CREATE TABLE #JOBS(
	ROW_ID				integer identity ( 1, 1 ) NOT NULL,
	JOB_NUMBER				int NOT NULL,
	JOB_COMPONENT_NBR		smallint NOT NULL
) 

INSERT INTO #JOBS VALUES(@job_number, @job_component_nbr)
DECLARE job_cursor CURSOR FOR
SELECT JOB_NUMBER, JOB_COMPONENT_NBR FROM #JOBS
	OPEN job_cursor

	FETCH NEXT FROM job_cursor INTO @job_num, @job_comp

	WHILE ( @@FETCH_STATUS = 0 )
	BEGIN
		--SELECT @job_num, @job_comp
		SELECT @job_pred_end_date = JOB_FIRST_USE_DATE 
		FROM JOB_COMPONENT
		WHERE (JOB_NUMBER = @job_num) AND (JOB_COMPONENT_NBR = @job_comp)
		--SELECT @job_pred_end_date

		DECLARE pred_cursor_pred CURSOR FOR
		SELECT DISTINCT JOB_TRAFFIC_PREDS.JOB_NUMBER, JOB_TRAFFIC_PREDS.JOB_COMPONENT_NBR, ISNULL(JOB_TRAFFIC.SCHEDULE_CALC,-1), 
			   JOB_COMPONENT.TRF_SCHEDULE_BY, JOB_COMPONENT.START_DATE--, ISNULL(JOB_COMPONENT.JOB_FIRST_USE_DATE,'')
		FROM  JOB_TRAFFIC INNER JOIN
				JOB_TRAFFIC_PREDS ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_PREDS.JOB_NUMBER AND 
				JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_PREDS.JOB_COMPONENT_NBR INNER JOIN
				JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
				JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
		WHERE (JOB_TRAFFIC_PREDS.JOB_PRED = @job_num) AND (JOB_TRAFFIC_PREDS.JOB_COMP_PRED = @job_comp)
		ORDER BY JOB_COMPONENT.START_DATE ASC, JOB_TRAFFIC_PREDS.JOB_NUMBER, JOB_TRAFFIC_PREDS.JOB_COMPONENT_NBR

			OPEN pred_cursor_pred

			FETCH NEXT FROM pred_cursor_pred INTO @job_pred, @job_comp_pred, @schedule_calc, @by_start, @start_date

			WHILE ( @@FETCH_STATUS = 0 )
			BEGIN
				INSERT INTO #JOBS VALUES(@job_pred, @job_comp_pred)
				--SELECT @job_pred, @job_comp_pred, @schedule_calc, @by_start, @start_date, @pred, @job_order
				if @schedule_calc = -1
				BEGIN
					if @pred = 1
					BEGIN
						UPDATE JOB_COMPONENT SET START_DATE = @job_pred_end_date WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred
						EXECUTE usp_wv_Traffic_Schedule_Calculate_Pred @job_pred, @job_comp_pred, 1, @ret_val = @ret_val OUTPUT
						--if @ret_val = 0
						--BEGIN
							--SET @job_pred_end_date = (SELECT JOB_FIRST_USE_DATE FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred)
						--END					
					END
					if @job_order = 1
					BEGIN
						UPDATE JOB_COMPONENT SET START_DATE = @job_pred_end_date WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred
						EXECUTE advsp_calculate_schedule @job_pred, @job_comp_pred, 0, @ret_val = @ret_val OUTPUT
						--if @ret_val = 0
						--BEGIN
						--	SET @job_pred_end_date = (SELECT JOB_FIRST_USE_DATE FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred)
						--END			
					END
				END	
				ELSE					
				BEGIN
					if @schedule_calc = 1
					BEGIN
						UPDATE JOB_COMPONENT SET START_DATE = @job_pred_end_date WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred
						EXECUTE usp_wv_Traffic_Schedule_Calculate_Pred @job_pred, @job_comp_pred, 1, @ret_val = @ret_val OUTPUT
						--if @ret_val = 0
						--BEGIN
						--	SET @job_pred_end_date = (SELECT JOB_FIRST_USE_DATE FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred)
						--END						
					END
					if @schedule_calc = 0
					BEGIN
						UPDATE JOB_COMPONENT SET START_DATE = @job_pred_end_date WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred
						EXECUTE advsp_calculate_schedule @job_pred, @job_comp_pred, 0, @ret_val = @ret_val OUTPUT
						--if @ret_val = 0
						--BEGIN
						--	SET @job_pred_end_date = (SELECT JOB_FIRST_USE_DATE FROM JOB_COMPONENT WHERE JOB_NUMBER = @job_pred AND JOB_COMPONENT_NBR = @job_comp_pred)
						--END				
					END
				END
						
				--SELECT @job_pred_end_date		
				FETCH NEXT FROM pred_cursor_pred INTO @job_pred, @job_comp_pred, @schedule_calc, @by_start, @start_date
				--SELECT @job_pred, @job_comp_pred, @schedule_calc, @by_start, @start_date, @pred, @job_order
			END

			CLOSE pred_cursor_pred
			DEALLOCATE pred_cursor_pred
		
		FETCH NEXT FROM job_cursor INTO @job_num, @job_comp
	END

	CLOSE job_cursor
	DEALLOCATE job_cursor








end_tran:
