CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_Calculate_Pred] @job_number integer, @job_component_nbr smallint, @use_predecessor bit, @ret_val integer OUTPUT
AS
BEGIN

SET ANSI_NULLS ON
SET ANSI_WARNINGS OFF
SET ARITHABORT OFF
SET ARITHIGNORE ON

SET NOCOUNT ON

-- @use_predecessor: on = 1, off = 0

DECLARE @by_start smallint, @include_phase bit, @max_days int, @trf_calc_by_cmp bit, 
		@date_lock bit, @start_date smalldatetime, @first_use_date smalldatetime, @orig_first_use_date smalldatetime,
		@revised_date smalldatetime, @due_date smalldatetime, @group_comp_date smalldatetime, @cur_row_id integer,
		@group_due_date smalldatetime, @completed_date smalldatetime, @orig_date smalldatetime, 
		@schedule_by smallint, @lock_flag bit, @latest_lock_date smalldatetime, @day_sum integer,
		@sort_col decimal(13,6), @sort_col2 decimal(13,6), @sort_col3 decimal(13,6), @trf_calc_concur_dt bit, @grp_seq int,
		@ctr as int, @curr_row_id as int, @curr_job_days as int, @curr_sort_col as decimal(13,6), @curr_max_days as int,
		@prev_sort_col as decimal(13,6), @curr_start as smalldatetime, @curr_end as smalldatetime, @last_start as smalldatetime, 
		@last_end as smalldatetime, @prev_max_days as int, @grp_max_days as int, @current_seq integer, @new_order smallint,
		@grp_start as smalldatetime, @prev_grp_comp_date as smalldatetime, @curr_grp_comp_date as smalldatetime, @day_option int
		
DECLARE @PRED_GROUP TABLE (SEQ_NBR smallint NOT NULL )

SELECT @ret_val = 0

CREATE TABLE #PREDS(
	ROW_ID				integer identity ( 1, 1 ) NOT NULL,
	SEQ_NBR				smallint NOT NULL,
	PRED_SEQ			smallint NULL
) 

CREATE TABLE #schedule( 	
	ROW_ID				integer identity ( 1, 1 ) NOT NULL,
	SEQ_NBR				smallint NOT NULL,
	TASK_START_DATE		smalldatetime NULL,
	JOB_DUE_DATE		smalldatetime NULL,
	JOB_REVISED_DATE	smalldatetime NULL,
	ORIG_REVISED_DATE	smalldatetime NULL,
	JOB_COMPLETED_DATE	smalldatetime NULL,
	DUE_DATE_LOCK		smallint NULL,
	JOB_DAYS			smallint NULL,
	PHASE_ORDER			integer NULL,
	JOB_ORDER			smallint NULL,
	PRED_SEQ				smallint NULL,
	SORT_COL			decimal(13,6) NULL )

--ALTER TABLE #schedule WITH NOCHECK ADD 
--	CONSTRAINT [PK_schedule] PRIMARY KEY  CLUSTERED ( [SEQ_NBR] )

CREATE TABLE #schedule_groups( 	
	GROUP_SEQ				integer identity (1,1) NOT NULL,
	SORT_COL				decimal(13,6) NULL,
	MAX_DAYS				smallint NULL,
	GROUP_COMP_DATE			smalldatetime NULL,
	LATEST_LOCK_DATE		smalldatetime NULL,
	GROUP_START_DATE		smalldatetime NULL,
	GROUP_DUE_DATE			smalldatetime NULL,
	GROUP_COUNT				integer NULL )
	
--ALTER TABLE #schedule_groups WITH NOCHECK ADD 
--	CONSTRAINT [PK_schedule_groups] PRIMARY KEY  CLUSTERED ( GROUP_SEQ )

CREATE TABLE #predecessors( 	
	ROW_ID					integer identity (1,1) NOT NULL,
	SEQ_NBR					smallint NOT NULL,
	PRED_ID					integer NULL,
	PRED_SEQ				smallint NULL,
	JOB_ORDER				smallint NULL,	
	JOB_DAYS				smallint NULL,
	TASK_START_DATE			smalldatetime NULL,
	JOB_REVISED_DATE		smalldatetime NULL,
	JOB_DUE_DATE			smalldatetime NULL,	
	ORIG_REVISED_DATE		smalldatetime NULL,
	JOB_COMPLETED_DATE		smalldatetime NULL,
	DUE_DATE_LOCK			smallint NULL,
	SORT_COL				decimal(13,6) NULL,
	MAX_DAY					int NULL,
	ROW_ORDER				decimal(38, 30) NULL )	

--ALTER TABLE #predecessors WITH NOCHECK ADD 
--	CONSTRAINT [PK_predecessors] PRIMARY KEY  CLUSTERED ( [ROW_ID] )
	
CREATE UNIQUE INDEX IDX_predecessors ON #predecessors ( ROW_ID, SEQ_NBR, PRED_SEQ )	

CREATE TABLE #pred_group(
	 SEQ_NBR smallint NOT NULL,
	 SORT_COL				decimal(13,6) NULL,
	 MAX_DAYS				smallint NULL,
	 GROUP_COMP_DATE			smalldatetime NULL,
	 LATEST_LOCK_DATE		smalldatetime NULL,
	 GROUP_START_DATE		smalldatetime NULL,
	 GROUP_DUE_DATE			smalldatetime NULL,
	 GROUP_COUNT				integer NULL,
	 PRED					integer NULL,
	 PRED_COMP_DATE			smalldatetime NULL,
	 JOB_ORDER			smallint NULL)	

--ALTER TABLE #pred_group WITH NOCHECK ADD 
--	CONSTRAINT [PK_pred_group] PRIMARY KEY  CLUSTERED ( [SEQ_NBR] )

--SET SETTING FLAGS
SET @trf_calc_by_cmp = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_BY_CMP' )
SET @lock_flag = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_LOCK_DATE' )
SET @schedule_by = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_SCHEDULE_BY' )
SET @include_phase = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'USE_PHASE' )
SET @trf_calc_concur_dt = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_CONCUR_DT' )
SET @day_option = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_BY_DAY' )

-- BJL 10/01/2011 - When using predecessors, @include_phase should be off
IF ( @use_predecessor = 1 )
	SET @include_phase = 0

--SET 3 VARIABLES...
DECLARE comp_cursor CURSOR FOR
	SELECT TRF_SCHEDULE_BY, [START_DATE], JOB_FIRST_USE_DATE 
	  FROM dbo.JOB_COMPONENT WITH(NOLOCK)
	 WHERE JOB_NUMBER = @job_number
	   AND JOB_COMPONENT_NBR = @job_component_nbr
	FOR READ ONLY

OPEN comp_cursor

FETCH comp_cursor
 INTO @by_start, @start_date, @first_use_date

CLOSE comp_cursor
DEALLOCATE comp_cursor

set @by_start = 1

--GET BASE/NEEDED TASKS OUT OF JOB_TRAFFIC_DET INTO TEMP TABLE:
INSERT INTO #schedule ( SEQ_NBR, TASK_START_DATE, JOB_DUE_DATE, JOB_REVISED_DATE, ORIG_REVISED_DATE, JOB_COMPLETED_DATE, DUE_DATE_LOCK, JOB_DAYS, PHASE_ORDER, JOB_ORDER, PRED_SEQ )
	SELECT jtd.SEQ_NBR, hd.TASK_START_DATE, hd.JOB_DUE_DATE, hd.JOB_REVISED_DATE, hd.JOB_REVISED_DATE, hd.JOB_COMPLETED_DATE, COALESCE( DUE_DATE_LOCK, 0 ), hd.JOB_DAYS, PHASE_ORDER, JOB_ORDER, jtdp.PREDECESSOR_SEQ_NBR
	  FROM dbo.JOB_TRAFFIC_DET jtd LEFT OUTER JOIN dbo.TRAFFIC_PHASE tp
	    ON jtd.TRAFFIC_PHASE_ID = tp.TRAFFIC_PHASE_ID LEFT OUTER JOIN dbo.JOB_TRAFFIC_DET_PREDS jtdp 
			ON jtd.JOB_NUMBER = jtdp.JOB_NUMBER 
		   AND jtd.JOB_COMPONENT_NBR = jtdp.JOB_COMPONENT_NBR 
		   AND jtd.SEQ_NBR = jtdp.SEQ_NBR INNER JOIN -- ADDED BY TP
		   dbo.advtf_traffic_schedule_GetHierarchyDates(@job_number, @job_component_nbr) hd ON jtd.JOB_NUMBER = hd.JOB_NUMBER AND
																							   jtd.JOB_COMPONENT_NBR = hd.JOB_COMPONENT_NBR AND
																							   jtd.SEQ_NBR = hd.SEQ_NBR
	 WHERE jtd.JOB_NUMBER = @job_number
	   AND jtd.JOB_COMPONENT_NBR = @job_component_nbr


IF ( @use_predecessor = 1 ) 
BEGIN
	-- Gets predecessors task definitions and tasks that have no predecessor defined 
	INSERT INTO #predecessors
		SELECT jtd.SEQ_NBR, jtdp.ID, jtdp.PREDECESSOR_SEQ_NBR, jtd.JOB_ORDER, hd.JOB_DAYS, CASE WHEN jtd.DUE_DATE_LOCK = 1 OR hd.JOB_COMPLETED_DATE IS NOT NULL THEN COALESCE(hd.TASK_START_DATE, hd.JOB_COMPLETED_DATE) ELSE NULL END, CASE WHEN jtd.DUE_DATE_LOCK = 1 OR hd.JOB_COMPLETED_DATE IS NOT NULL THEN COALESCE(hd.JOB_REVISED_DATE, hd.JOB_COMPLETED_DATE) ELSE NULL END, hd.JOB_DUE_DATE, hd.JOB_REVISED_DATE, hd.JOB_COMPLETED_DATE,  ISNULL(jtd.DUE_DATE_LOCK,0), NULL,NULL, hd.ROW_ORDER
		FROM dbo.JOB_TRAFFIC_DET jtd LEFT OUTER JOIN dbo.JOB_TRAFFIC_DET_PREDS jtdp 
			ON jtd.JOB_NUMBER = jtdp.JOB_NUMBER 
		   AND jtd.JOB_COMPONENT_NBR = jtdp.JOB_COMPONENT_NBR 
		   AND jtd.SEQ_NBR = jtdp.SEQ_NBR LEFT OUTER JOIN -- ADDED BY TP
		   dbo.advtf_traffic_schedule_GetHierarchyDates(@job_number, @job_component_nbr) hd on jtd.JOB_NUMBER = hd.JOB_NUMBER AND
																							   jtd.JOB_COMPONENT_NBR = hd.JOB_COMPONENT_NBR AND
																							   jtd.SEQ_NBR = hd.SEQ_NBR
		 WHERE jtd.JOB_NUMBER = @job_number
		   AND jtd.JOB_COMPONENT_NBR = @job_component_nbr
	  ORDER BY jtd.SEQ_NBR, jtd.JOB_ORDER, jtdp.PREDECESSOR_SEQ_NBR	   

	UPDATE #predecessors SET SORT_COL = ( COALESCE( ISNULL(PRED_SEQ,-1), 0) * 0.000001 )
	UPDATE #predecessors SET PRED_ID  = NULL, PRED_SEQ = NULL WHERE SEQ_NBR = PRED_SEQ

	INSERT INTO #pred_group (SEQ_NBR, SORT_COL, GROUP_COUNT, PRED, JOB_ORDER )
	SELECT SEQ_NBR, SORT_COL, (SELECT COUNT( * ) FROM #predecessors pd WHERE pd.SEQ_NBR = p.SEQ_NBR), PRED_SEQ, JOB_ORDER FROM #predecessors p GROUP BY SEQ_NBR, SORT_COL, PRED_SEQ, JOB_ORDER

	UPDATE #pred_group
	   SET GROUP_COMP_DATE = ( SELECT MAX( JOB_COMPLETED_DATE )
								 FROM #predecessors 
								WHERE SORT_COL = #pred_group.SORT_COL 
								  AND NOT EXISTS ( SELECT * 
													 FROM #predecessors 
													WHERE SORT_COL = #pred_group.SORT_COL 
													  AND JOB_COMPLETED_DATE IS NULL ))								
	UPDATE #pred_group
	   SET LATEST_LOCK_DATE = ( SELECT MAX( JOB_REVISED_DATE )
								  FROM #schedule 
								 WHERE SEQ_NBR = #pred_group.PRED 
								   AND DUE_DATE_LOCK = 1 )

	UPDATE #pred_group
	   SET MAX_DAYS = ( SELECT MAX( JOB_DAYS )
						  FROM #predecessors 
						 WHERE #pred_group.SORT_COL = SORT_COL
						   AND #predecessors.DUE_DATE_LOCK = 0 )
	--SELECT * FROM #predecessors
	--SELECT * FROM #pred_group
		
	UPDATE #pred_group
		SET PRED_COMP_DATE = CASE WHEN GROUP_COUNT > 1 THEN (SELECT DISTINCT GROUP_COMP_DATE FROM #pred_group pg WHERE pg.SEQ_NBR = p.PRED AND p.PRED IS NOT NULL) ELSE NULL END FROM #pred_group p WHERE GROUP_COUNT > 1
	
	--UPDATE #pred_group
	--	SET GROUP_COUNT = CASE WHEN GROUP_COUNT > 1 THEN (SELECT DISTINCT MAX_DAYS FROM #pred_group pg WHERE pg.SEQ_NBR = p.PRED AND p.PRED IS NOT NULL) ELSE 1 END FROM #pred_group p WHERE GROUP_COUNT > 1

	--SELECT * FROM #pred_group
	      
	
	--SELECT * FROM #predecessors
	--DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.NEW_JOB_ORDER IS NULL )  
	--SELECT * FROM #pred_group
	

END


--PUT TASKS IN CORRECT SEQUENTIAL ORDER BASED ON SETTINGS:
IF ( @include_phase = 1 )
	UPDATE #schedule SET SORT_COL = (( COALESCE( @include_phase, 0 ) * COALESCE( PHASE_ORDER, 0 )) + ( COALESCE( JOB_ORDER, 0 ) * 0.000001 ))
ELSE
	UPDATE #schedule SET SORT_COL = ( COALESCE( PRED_SEQ, -1 ) * 0.000001 )
--SELECT * from #schedule	   
SET @ctr = 0;		
			   
--SELECT * FROM #schedule_groups;
--SELECT * FROM #schedule;
--SELECT @by_start

DECLARE @seq int, @seq_c int, @pred int, @days int, @task_start smalldatetime, @task_end smalldatetime, @seq_count int, @sort decimal(9,6), @total_days int,
 @sort_c decimal(9,6), @ct int, @max_date smalldatetime, @last_seq int, @last_pred int, @grp_pred int, @max_pred int, @null_count int, @lock_date smalldatetime, @curr_pred int, @pred_ct int, @pred_group_ct int, @pred_grp_pred int, @seq_ct int, @path int
SET @total_days = 0
SET @sort_c = 0.1
SET @seq_c = -1
SET @path = 0
IF ( @by_start = 1 )
BEGIN
	IF @start_date IS NULL
	BEGIN
		SELECT @ret_val = -1
		GOTO end_tran
	END
	ELSE
	BEGIN
		if @day_option = 0
		Begin
			--SELECT @start_date
			-- The new first item(s) will be those no predecessor(s)
			UPDATE #predecessors 
			 SET TASK_START_DATE = @start_date, JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @start_date, (CASE WHEN ISNULL(JOB_DAYS, 0) > 1 THEN -1 ELSE 0 END + JOB_DAYS) ))
			WHERE PRED_SEQ IS NULL
			 AND TASK_START_DATE IS NULL
	
			--UPDATE #predecessors 
			-- SET TASK_START_DATE = @start_date, JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @start_date, JOB_DAYS ))
		 --   WHERE PRED_SEQ IS NULL
			-- AND TASK_START_DATE IS NULL


				
			SELECT * FROM #predecessors
			SELECT * FROM #pred_group   
			DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.TASK_START_DATE IS NULL )  
			SELECT * FROM #pred_group
	
			SELECT @ctr = COUNT(*) FROM #pred_group
		
			WHILE ( @ctr > 0 )
			BEGIN
				DECLARE seq_cursor CURSOR FOR
					SELECT SEQ_NBR, JOB_COMPLETED_DATE
					FROM #predecessors
					WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #pred_group WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.TASK_START_DATE IS NULL)
					ORDER BY ROW_ORDER ASC, SEQ_NBR ASC

					OPEN seq_cursor

					FETCH NEXT FROM seq_cursor INTO @grp_seq, @group_comp_date

					WHILE ( @@FETCH_STATUS = 0 )
					BEGIN
						DECLARE pred_cursor CURSOR FOR
						SELECT SEQ_NBR, PRED_SEQ, JOB_DAYS
						FROM #predecessors
						WHERE PRED_SEQ = @grp_seq
						ORDER BY SEQ_NBR

						SELECT @pred_ct = COUNT(*)
						FROM #pred_group
						WHERE PRED = @grp_seq
						
						SELECT @pred_group_ct = COUNT(*) FROM #pred_group
						
						if @pred_ct = 0 and @pred_group_ct <> 0 
						Begin
							SET @ret_val = -3								
						End
						Else 
						Begin
							SET @path = 1
						End	

						SELECT @seq_count = COUNT(*)
						FROM #predecessors
						WHERE SEQ_NBR = @grp_seq

						SELECT @null_count = COUNT(*)
						FROM #pred_group
						WHERE SEQ_NBR = @grp_seq and PRED_COMP_DATE IS NOT NULL	
					
						SELECT @lock_date = MAX(LATEST_LOCK_DATE)
						FROM #pred_group
						WHERE PRED = @grp_seq
					
						--SELECT @seq_count, @grp_seq, @trf_calc_by_cmp, @seq, @pred, @days, @group_comp_date,@lock_date

						if @seq_count > 1
						Begin						
							IF ( @trf_calc_by_cmp = 1 ) AND ( @null_count = @seq_count )
							BEGIN
								SET @max_date = (SELECT MAX(PRED_COMP_DATE) FROM #pred_group WHERE SEQ_NBR = @grp_seq)
							END
							Else
							Begin
								SET @max_date = (SELECT MAX(JOB_REVISED_DATE) FROM #predecessors WHERE SEQ_NBR = @grp_seq)
							End	
						End
						--SELECT @max_date
						OPEN pred_cursor

						FETCH NEXT FROM pred_cursor INTO @seq, @pred, @days

						WHILE ( @@FETCH_STATUS = 0 )
						BEGIN
							if @seq_count > 1
							Begin
								SELECT @task_start = @max_date
							End
							Else
							Begin
								IF ( @trf_calc_by_cmp = 1 ) AND ( @group_comp_date IS NOT NULL )
								BEGIN
									SELECT @task_start = JOB_COMPLETED_DATE FROM #predecessors WHERE SEQ_NBR = @grp_seq
								END
								Else
								Begin
									SELECT @task_start = JOB_REVISED_DATE FROM #predecessors WHERE SEQ_NBR = @grp_seq
								End		
								
								IF @task_start IS NULL BEGIN

									SELECT @task_start = TASK_START_DATE FROM #predecessors WHERE SEQ_NBR = @grp_seq

								END

							End						
						
							if @lock_date > @task_start
							Begin
								SET @task_start = @lock_date
							End

							DECLARE @CalculatedTaskStartDate SMALLDATETIME

							SELECT @CalculatedTaskStartDate = dbo.fn_get_nth_workday( @task_start, 1 )

							UPDATE #predecessors 
								 SET TASK_START_DATE = @CalculatedTaskStartDate, JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @CalculatedTaskStartDate, (CASE WHEN ISNULL(JOB_DAYS, 0) > 1 THEN -1 ELSE 0 END + JOB_DAYS) ))
								 WHERE SEQ_NBR = @seq AND PRED_SEQ = @pred
									   AND ISNULL(DUE_DATE_LOCK, 0) = 0 
									   AND JOB_COMPLETED_DATE IS NULL
									   
									--AND TASK_START_DATE IS NULL			

							--SELECT @seq, @pred, @curr_pred			
							--SET @curr_pred = @pred							
							FETCH NEXT FROM pred_cursor INTO @seq, @pred, @days
						END		
						--SELECT * FROM #predecessors 
						CLOSE pred_cursor
						DEALLOCATE pred_cursor			
						DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.TASK_START_DATE IS NULL )
						--SELECT * FROM #pred_group  
						FETCH NEXT FROM seq_cursor INTO @grp_seq, @group_comp_date
					END

					CLOSE seq_cursor
					DEALLOCATE seq_cursor
				
					SET @ctr = ( SELECT COUNT(*) FROM #pred_group )

					if @path = 0
					Begin
						SET @ret_val = -2		
						GOTO end_tran
					End
					SET @path = 0
				
			END   		
		End
		Else
		Begin
			--SELECT @start_date
			-- The new first item(s) will be those no predecessor(s)
			
			UPDATE #predecessors 
			 SET TASK_START_DATE = @start_date, JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @start_date, JOB_DAYS ))
		    WHERE PRED_SEQ IS NULL
			 AND TASK_START_DATE IS NULL


				
			SELECT * FROM #predecessors
			SELECT * FROM #pred_group   
			
			DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.TASK_START_DATE IS NULL )  
			
			SELECT * FROM #pred_group
	
			SELECT @ctr = COUNT(*) FROM #pred_group
		
			WHILE ( @ctr > 0 )
			BEGIN
				DECLARE seq_cursor CURSOR FOR
					SELECT SEQ_NBR, JOB_COMPLETED_DATE
					FROM #predecessors
					WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #pred_group WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.TASK_START_DATE IS NULL)
					ORDER BY ROW_ORDER ASC, SEQ_NBR ASC

					OPEN seq_cursor

					FETCH NEXT FROM seq_cursor INTO @grp_seq, @group_comp_date

					WHILE ( @@FETCH_STATUS = 0 )
					BEGIN
						DECLARE pred_cursor CURSOR FOR
						SELECT SEQ_NBR, PRED_SEQ, JOB_DAYS
						FROM #predecessors
						WHERE PRED_SEQ = @grp_seq
						ORDER BY SEQ_NBR

						SELECT @pred_ct = COUNT(*)
						FROM #pred_group
						WHERE PRED = @grp_seq
						
						SELECT @pred_group_ct = COUNT(*) FROM #pred_group
						
						if @pred_ct = 0 and @pred_group_ct <> 0 
						Begin
							SET @ret_val = -3								
						End
						Else 
						Begin
							SET @path = 1
						End	

						SELECT @seq_count = COUNT(*)
						FROM #predecessors
						WHERE SEQ_NBR = @grp_seq

						SELECT @null_count = COUNT(*)
						FROM #pred_group
						WHERE SEQ_NBR = @grp_seq and PRED_COMP_DATE IS NOT NULL	
					
						SELECT @lock_date = MAX(LATEST_LOCK_DATE)
						FROM #pred_group
						WHERE PRED = @grp_seq
					
						--SELECT @seq_count, @grp_seq, @trf_calc_by_cmp, @seq, @pred, @days, @group_comp_date,@lock_date

						if @seq_count > 1
						Begin						
							IF ( @trf_calc_by_cmp = 1 ) AND ( @null_count = @seq_count )
							BEGIN
								SET @max_date = (SELECT MAX(PRED_COMP_DATE) FROM #pred_group WHERE SEQ_NBR = @grp_seq)
							END
							Else
							Begin
								SET @max_date = (SELECT MAX(JOB_REVISED_DATE) FROM #predecessors WHERE SEQ_NBR = @grp_seq)
							End	
						End
						--SELECT @max_date
						OPEN pred_cursor

						FETCH NEXT FROM pred_cursor INTO @seq, @pred, @days

						WHILE ( @@FETCH_STATUS = 0 )
						BEGIN
							if @seq_count > 1
							Begin
								SELECT @task_start = @max_date
							End
							Else
							Begin
								IF ( @trf_calc_by_cmp = 1 ) AND ( @group_comp_date IS NOT NULL )
								BEGIN
									SELECT @task_start = JOB_COMPLETED_DATE FROM #predecessors WHERE SEQ_NBR = @grp_seq
								END
								Else
								Begin
									SELECT @task_start = JOB_REVISED_DATE FROM #predecessors WHERE SEQ_NBR = @grp_seq

									
									IF @task_start IS NULL BEGIN

										SELECT @task_start = TASK_START_DATE FROM #predecessors WHERE SEQ_NBR = @grp_seq

									END

								End							
							End						
						
							if @lock_date > @task_start
							Begin
								SET @task_start = @lock_date
							End

							UPDATE #predecessors 
								 SET TASK_START_DATE = @task_start, JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @task_start, JOB_DAYS ))
								 WHERE SEQ_NBR = @seq AND PRED_SEQ = @pred
									   --AND TASK_START_DATE IS NULL							


							FETCH NEXT FROM pred_cursor INTO @seq, @pred, @days
						END		
						--SELECT * FROM #predecessors 
						CLOSE pred_cursor
						DEALLOCATE pred_cursor			
						DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.TASK_START_DATE IS NULL )
						--SELECT * FROM #pred_group  
						FETCH NEXT FROM seq_cursor INTO @grp_seq, @group_comp_date
					END

					CLOSE seq_cursor
					DEALLOCATE seq_cursor
				
					SET @ctr = ( SELECT COUNT(*) FROM #pred_group )

					if @path = 0
					Begin
						SET @ret_val = -2		
						GOTO end_tran
					End
					SET @path = 0
				
			END   		

		End
		
	END
END

UPDATE #schedule
SET JOB_DUE_DATE = #predecessors.JOB_DUE_DATE,
	   JOB_REVISED_DATE = #predecessors.JOB_REVISED_DATE,
	   TASK_START_DATE = #predecessors.TASK_START_DATE,
	   DUE_DATE_LOCK = #predecessors.DUE_DATE_LOCK
	FROM #predecessors
	WHERE #predecessors.SEQ_NBR = #schedule.SEQ_NBR AND #schedule.JOB_COMPLETED_DATE IS NULL AND #schedule.DUE_DATE_LOCK = 0
		AND #predecessors.TASK_START_DATE = (SELECT MAX(TASK_START_DATE) FROM #predecessors p WHERE p.SEQ_NBR = #predecessors.SEQ_NBR) 
	
SELECT * FROM #schedule ORDER BY TASK_START_DATE
UPDATE dbo.JOB_TRAFFIC_DET
   SET JOB_DUE_DATE = s.JOB_DUE_DATE,
	   JOB_REVISED_DATE = s.JOB_REVISED_DATE,
	   TASK_START_DATE = s.TASK_START_DATE,
	   DUE_DATE_LOCK = s.DUE_DATE_LOCK,
	   JOB_ORDER = s.JOB_ORDER
  FROM dbo.JOB_TRAFFIC_DET jtd, #schedule s
 WHERE jtd.JOB_NUMBER = @job_number
   AND jtd.JOB_COMPONENT_NBR = @job_component_nbr
   AND jtd.SEQ_NBR = s.SEQ_NBR

IF ( @by_start = 1 )
BEGIN
	IF ( @lock_flag = 0 ) OR ( @lock_flag IS NULL ) OR ( @first_use_date IS NULL )
		BEGIN
			SELECT @first_use_date = ( SELECT MAX( JOB_REVISED_DATE )
										 FROM dbo.JOB_TRAFFIC_DET
										WHERE JOB_NUMBER = @job_number
										  AND JOB_COMPONENT_NBR = @job_component_nbr )
			
			IF ( @first_use_date IS NOT NULL )
				UPDATE dbo.JOB_COMPONENT
				   SET JOB_FIRST_USE_DATE = @first_use_date
				 WHERE JOB_NUMBER = @job_number
				   AND JOB_COMPONENT_NBR = @job_component_nbr
		END
END
--ELSE -- by due date
--BEGIN
--	IF ( @lock_flag = 0 ) OR ( @lock_flag IS NULL ) OR ( @start_date IS NULL )
--		BEGIN
--			SELECT @start_date = ( SELECT MIN( TASK_START_DATE )
--									 FROM dbo.JOB_TRAFFIC_DET
--									WHERE JOB_NUMBER = @job_number
--									  AND JOB_COMPONENT_NBR = @job_component_nbr )

--			IF ( @start_date IS NOT NULL )
--				UPDATE dbo.JOB_COMPONENT
--				   SET START_DATE = @start_date
--				 WHERE JOB_NUMBER = @job_number
--				   AND JOB_COMPONENT_NBR = @job_component_nbr
--		END
--END
UPDATE dbo.JOB_TRAFFIC_DET
   SET JOB_DUE_DATE = JOB_REVISED_DATE
 WHERE ((NOT JOB_REVISED_DATE IS NULL) AND (JOB_DUE_DATE IS NULL))
       AND JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr;

-- corrects parent tasks dates
exec dbo.advsp_traffic_schedule_UpdateDatesByHierarchy @job_number, @job_component_nbr

end_tran:

END
