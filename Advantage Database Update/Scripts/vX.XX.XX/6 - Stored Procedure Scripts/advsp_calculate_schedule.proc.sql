IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_calculate_schedule]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_calculate_schedule]
GO

/****** Object:  StoredProcedure [dbo].[advsp_calculate_schedule]    Script Date: 10/22/2021 11:58:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
 DECLARE @ret as integer
 exec advsp_calculate_schedule 306,1,0, @ret
 print @ret
*/

CREATE PROCEDURE [dbo].[advsp_calculate_schedule] @job_number integer, @job_component_nbr smallint, @use_predecessor bit, @ret_val integer OUTPUT
AS
/*===================	QUERY	===================*/
BEGIN
	SET ANSI_NULLS ON
	SET ANSI_WARNINGS OFF
	SET ARITHABORT OFF
	SET ARITHIGNORE ON
	SET NOCOUNT ON

	-- @use_predecessor: on = 1, off = 0
	SELECT @ret_val = 0;

	-- VARIABLES
	BEGIN 
		DECLARE 
			@by_start smallint, @include_phase bit, @max_days smallint, @trf_calc_by_cmp bit, 
			@date_lock bit, @start_date smalldatetime, @first_use_date smalldatetime, 
			@orig_first_use_date smalldatetime,	@revised_date smalldatetime, @due_date smalldatetime, 
			@group_comp_date smalldatetime, @cur_row_id integer,
			@group_due_date smalldatetime, @completed_date smalldatetime, @orig_date smalldatetime, 
			@schedule_by smallint, @lock_flag bit, @latest_lock_date smalldatetime, @day_sum integer,
			@sort_col decimal(13,6), @sort_col2 decimal(13,6), @sort_col3 decimal(13,6), @trf_calc_concur_dt bit, @grp_seq int,
			@ctr as int, @curr_row_id as int, @curr_job_days as int, @curr_sort_col as decimal(13,6), @curr_max_days as int,
			@prev_sort_col as decimal(13,6), @curr_start as smalldatetime, @curr_end as smalldatetime, @last_start as smalldatetime, 
			@last_end as smalldatetime, @prev_max_days as int, @grp_max_days as int, @current_seq integer, @new_order smallint,
			@grp_start as smalldatetime, @prev_grp_comp_date as smalldatetime, @curr_grp_comp_date as smalldatetime, 
			@set_due_date_and_next_start_on_same_day int

		DECLARE 
			@PRED_GROUP TABLE ( SEQ_NBR smallint NOT NULL );
		
	END
	-- TABLES
	BEGIN 

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
			SORT_COL			decimal(13,6) NULL );

		ALTER TABLE #schedule WITH NOCHECK ADD 
			CONSTRAINT [PK_schedule] PRIMARY KEY  CLUSTERED ( [SEQ_NBR] );

		CREATE TABLE #schedule_groups( 	
			GROUP_SEQ				integer identity (1,1) NOT NULL,
			SORT_COL				decimal(13,6) NULL,
			MAX_DAYS				smallint NULL,
			GROUP_COMP_DATE			smalldatetime NULL,
			LATEST_LOCK_DATE		smalldatetime NULL,
			GROUP_START_DATE		smalldatetime NULL,
			GROUP_DUE_DATE			smalldatetime NULL,
			GROUP_COUNT				integer NULL );
	
		ALTER TABLE #schedule_groups WITH NOCHECK ADD 
			CONSTRAINT [PK_schedule_groups] PRIMARY KEY  CLUSTERED ( GROUP_SEQ );

	END
	--SET SETTING FLAGS
	BEGIN
		SET @trf_calc_by_cmp = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_BY_CMP' );
		SET @lock_flag = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_LOCK_DATE' );
		SET @schedule_by = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_SCHEDULE_BY' );
		SET @include_phase = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'USE_PHASE' );
		SET @trf_calc_concur_dt = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_CONCUR_DT' );
		SET @set_due_date_and_next_start_on_same_day = ( SELECT CAST( AGY_SETTINGS_VALUE AS bit ) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_CALC_BY_DAY' );
		-- BJL 10/01/2011 - When using predecessors, @include_phase should be off
		IF ( @use_predecessor = 1 )
		BEGIN
			SET @include_phase = 0;
		END
		--SET 3 VARIABLES...
		SELECT @by_start = TRF_SCHEDULE_BY, @start_date = [START_DATE], @first_use_date = JOB_FIRST_USE_DATE 
		FROM dbo.JOB_COMPONENT WITH(NOLOCK)
		WHERE JOB_NUMBER = @job_number
		AND JOB_COMPONENT_NBR = @job_component_nbr;
	END
	--GET BASE/NEEDED TASKS OUT OF JOB_TRAFFIC_DET INTO TEMP TABLE:
	BEGIN
		IF ( @trf_calc_by_cmp = 1 )
		BEGIN
			INSERT INTO #schedule ( SEQ_NBR, TASK_START_DATE, JOB_DUE_DATE, JOB_REVISED_DATE, ORIG_REVISED_DATE, JOB_COMPLETED_DATE, DUE_DATE_LOCK, JOB_DAYS, PHASE_ORDER, JOB_ORDER )
				SELECT SEQ_NBR, TASK_START_DATE, JOB_DUE_DATE, JOB_REVISED_DATE, JOB_REVISED_DATE, JOB_COMPLETED_DATE, COALESCE( DUE_DATE_LOCK, 0 ), JOB_DAYS, PHASE_ORDER, JOB_ORDER
				  FROM dbo.JOB_TRAFFIC_DET jtd LEFT OUTER JOIN dbo.TRAFFIC_PHASE tp
					ON jtd.TRAFFIC_PHASE_ID = tp.TRAFFIC_PHASE_ID
				 WHERE JOB_NUMBER = @job_number
				   AND JOB_COMPONENT_NBR = @job_component_nbr;
		END
		ELSE
		BEGIN
			INSERT INTO #schedule ( SEQ_NBR, TASK_START_DATE, JOB_DUE_DATE, JOB_REVISED_DATE, ORIG_REVISED_DATE, JOB_COMPLETED_DATE, DUE_DATE_LOCK, JOB_DAYS, PHASE_ORDER, JOB_ORDER )
				SELECT SEQ_NBR, TASK_START_DATE, JOB_DUE_DATE, JOB_REVISED_DATE, JOB_REVISED_DATE, JOB_COMPLETED_DATE, COALESCE( DUE_DATE_LOCK, 0 ), JOB_DAYS, PHASE_ORDER, JOB_ORDER
				  FROM dbo.JOB_TRAFFIC_DET jtd LEFT OUTER JOIN dbo.TRAFFIC_PHASE tp
					ON jtd.TRAFFIC_PHASE_ID = tp.TRAFFIC_PHASE_ID
				 WHERE JOB_NUMBER = @job_number
				   AND JOB_COMPONENT_NBR = @job_component_nbr
				   AND jtd.JOB_COMPLETED_DATE IS NULL;
		END
	END


	---- ST 10/22/2014 - Per conversation with Larry, remove any locked tasks from any further date calc
	---- ST 03/20/2015 - Per conversation with Ellen and Larry; undo this change.
	--BEGIN
	--	DELETE FROM #schedule WHERE DUE_DATE_LOCK = 1;
	--END   


	-- BJL 10/01/2011 - New routine; changes the job (task) order based on predecessor definitions
	-- BJL 10/02/2011 - The routine only changes JOB_ORDER; all other columns related to calculations
	--					that might be completed or locked are still reordered because the existing 
	--					date routines will handle them as before

	-- ALL PREDECESSOR STUFF IN HERE
	IF ( @use_predecessor = 1 ) 
	BEGIN

		CREATE TABLE #predecessors( 	
			ROW_ID					integer identity (1,1) NOT NULL,
			SEQ_NBR					smallint NOT NULL,
			PRED_ID					integer NULL,
			PRED_SEQ				smallint NULL,
			JOB_ORDER				smallint NULL,	
			JOB_DAYS				smallint NULL,
			TASK_START_DATE			smalldatetime NULL,
			NEW_JOB_ORDER			smallint NULL );	
		ALTER TABLE #predecessors WITH NOCHECK ADD 
			CONSTRAINT [PK_predecessors] PRIMARY KEY  CLUSTERED ( [ROW_ID] );
		CREATE UNIQUE INDEX IDX_predecessors ON #predecessors ( SEQ_NBR, PRED_SEQ );	
		CREATE TABLE #pred_group( SEQ_NBR smallint NOT NULL, CONSTRAINT [PK_pred_group] PRIMARY KEY  CLUSTERED ( [SEQ_NBR] ));	
		-- Gets predecessors task definitions and tasks that have no predecessor defined 
		INSERT INTO #predecessors ( SEQ_NBR, PRED_SEQ, PRED_ID, JOB_ORDER, JOB_DAYS )
			SELECT jtd.SEQ_NBR, jtdp.PREDECESSOR_SEQ_NBR, jtdp.ID, jtd.JOB_ORDER, jtd.JOB_DAYS
			  FROM dbo.JOB_TRAFFIC_DET jtd LEFT OUTER JOIN dbo.JOB_TRAFFIC_DET_PREDS jtdp 
				ON jtd.JOB_NUMBER = jtdp.JOB_NUMBER 
			   AND jtd.JOB_COMPONENT_NBR = jtdp.JOB_COMPONENT_NBR 
			   AND jtd.SEQ_NBR = jtdp.SEQ_NBR 
			 WHERE jtd.JOB_NUMBER = @job_number
			   AND jtd.JOB_COMPONENT_NBR = @job_component_nbr
		  ORDER BY jtd.SEQ_NBR, jtd.JOB_ORDER, jtdp.PREDECESSOR_SEQ_NBR	   
		INSERT INTO #pred_group
		SELECT DISTINCT SEQ_NBR FROM #predecessors p
		SET @new_order = 1;
		-- The new first item(s) will be those no predecessor(s)
		UPDATE #predecessors 
		   SET NEW_JOB_ORDER = @new_order
		 WHERE PRED_SEQ IS NULL
		   AND NEW_JOB_ORDER IS NULL;
	--	SELECT * FROM #pred_group   
		DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.NEW_JOB_ORDER IS NULL )  
	--	SELECT * FROM #pred_group
		SET @ctr = @@ROWCOUNT;
		WHILE ( @ctr > 0 )
		BEGIN
			-- The next item is the lowest SEQ_NBR that has a null NEW_JOB_ORDER
			-- and does not have an unassigned predecessor
			SET @new_order = ( SELECT COALESCE( MAX( NEW_JOB_ORDER ), 0 ) + 1 FROM #predecessors )

			UPDATE #predecessors 
			   SET NEW_JOB_ORDER = @new_order
			 WHERE SEQ_NBR IN (  SELECT pg.SEQ_NBR 
								   FROM #pred_group pg
								  WHERE NOT EXISTS ( SELECT pred.*
													   FROM #predecessors p
												 INNER JOIN #predecessors pred
														 ON p.PRED_SEQ = pred.SEQ_NBR
														AND pred.NEW_JOB_ORDER IS NULL
													  WHERE p.SEQ_NBR = pg.SEQ_NBR )) 
			   AND NEW_JOB_ORDER IS NULL

			SET @ctr = @@ROWCOUNT		
			IF ( @ctr > 0 )
			BEGIN
				DELETE FROM #pred_group WHERE NOT EXISTS ( SELECT SEQ_NBR FROM #predecessors WHERE #predecessors.SEQ_NBR = #pred_group.SEQ_NBR AND #predecessors.NEW_JOB_ORDER IS NULL )   
			END
		END   

		SET @ctr = ( SELECT COUNT(*) FROM #predecessors WHERE NEW_JOB_ORDER IS NULL )
		IF ( @ctr > 0 )		   
		BEGIN
			SET @ret_val = -7
			GOTO end_tran			
		END

		--  BJL 10/01/2011 - Use for testing to check values before updating the actual job (task) order
	--	SELECT * FROM #predecessors WHERE NEW_JOB_ORDER IS NULL
	--	SELECT * FROM #predecessors WHERE NEW_JOB_ORDER IS NOT NULL ORDER BY NEW_JOB_ORDER ASC, JOB_ORDER ASC, JOB_DAYS DESC

		 UPDATE #schedule
			SET JOB_ORDER = ( SELECT TOP 1 p.NEW_JOB_ORDER FROM #predecessors p WHERE p.SEQ_NBR = #schedule.SEQ_NBR ORDER BY p.NEW_JOB_ORDER ASC );

		DROP TABLE #pred_group;
		DROP TABLE #predecessors;

	END
	--PUT TASKS IN CORRECT SEQUENTIAL ORDER BASED ON SETTINGS:
	BEGIN
		IF ( @include_phase = 1 )
		BEGIN
			UPDATE #schedule SET SORT_COL = (( COALESCE( @include_phase, 0 ) * COALESCE( PHASE_ORDER, 0 )) + ( COALESCE( JOB_ORDER, 0 ) * 0.000001 ));
		END
		ELSE
		BEGIN
			UPDATE #schedule SET SORT_COL = ( COALESCE( JOB_ORDER, 0 ) * 0.000001 );
		END

		INSERT INTO #schedule_groups ( SORT_COL, GROUP_COUNT )
			SELECT SORT_COL, COUNT( * ) FROM #schedule GROUP BY SORT_COL;

		UPDATE #schedule_groups
		   SET GROUP_COMP_DATE = ( SELECT MAX( JOB_COMPLETED_DATE )
									 FROM #schedule 
									WHERE SORT_COL = #schedule_groups.SORT_COL 
									  AND NOT EXISTS ( SELECT * 
														 FROM #schedule 
														WHERE SORT_COL = #schedule_groups.SORT_COL 
														  AND JOB_COMPLETED_DATE IS NULL ));

		UPDATE #schedule_groups
		   SET LATEST_LOCK_DATE = ( SELECT MAX( JOB_REVISED_DATE )
									  FROM #schedule 
									 WHERE SORT_COL = #schedule_groups.SORT_COL 
									   AND DUE_DATE_LOCK = 1 );

		UPDATE #schedule_groups
		   SET MAX_DAYS = ( SELECT MAX( JOB_DAYS )
							  FROM #schedule 
							 WHERE #schedule_groups.SORT_COL = SORT_COL
							   AND #schedule.DUE_DATE_LOCK = 0 );
	END

	SET @ctr = 0;	
		
	---- TEST OUTPUT
	--BEGIN
	--	SELECT @trf_calc_concur_dt AS trf_calc_concur_dt			   
	--	SELECT 'BEFORE'
	--	SELECT * FROM #schedule_groups;
	--	SELECT * FROM #schedule ORDER BY JOB_ORDER;
	--END 

	-- CALCULATING BY START DATE
	DECLARE 
		@BY_START_CTR INT,
		@last_max_days INT;
	SET @BY_START_CTR = 0;
	IF ( @by_start = 1 )
	BEGIN

		IF @start_date IS NULL
		BEGIN
			SELECT @ret_val = -1;
			GOTO end_tran;
		END
		ELSE
		BEGIN

			DECLARE due_date_cursor CURSOR FOR
				SELECT MAX_DAYS, GROUP_COMP_DATE, LATEST_LOCK_DATE, GROUP_SEQ
				  FROM #schedule_groups
			  ORDER BY SORT_COL ASC;

			OPEN due_date_cursor;

			FETCH NEXT FROM due_date_cursor INTO @max_days, @group_comp_date, @latest_lock_date, @grp_seq;

			WHILE ( @@FETCH_STATUS = 0 )
			BEGIN
	
		    	--SELECT @start_date as start, @last_start as last_start, @due_date as due_date, @last_end as last_end;
				--SELECT @BY_START_CTR;
				--SELECT @last_start, @last_end;
				IF (@trf_calc_concur_dt = 0) OR (@trf_calc_concur_dt IS NULL)  ---ORIGINAL PATH
				BEGIN
					IF @set_due_date_and_next_start_on_same_day = 0
					BEGIN
						IF @max_days = 0
						BEGIN
							IF @last_end > @start_date
							BEGIN
								IF @last_max_days = 0
								BEGIN
									SET @start_date = @last_end;
								END
								ELSE
								BEGIN
									SELECT @start_date = (SELECT dbo.fn_get_nth_workday(@last_end, 1));
								END
							END
							SELECT @due_date = @start_date;
						END
						ELSE
						BEGIN
							IF NOT @last_end IS NULL
							BEGIN
								SELECT @start_date = (SELECT dbo.fn_get_nth_workday(@last_end, 1));
							END
							SELECT @due_date = (SELECT dbo.fn_get_nth_workday(@start_date, Case When @max_days = 1 then 0 else -1 End + @max_days ));
						END			
						IF @BY_START_CTR = 0
						BEGIN
							SET @last_end = @due_date;
						END
						--SELECT @BY_START_CTR AS BY_START_CTR, @start_date AS START, @last_end AS LAST_END, @max_days AS MAX_DAYS, dbo.fn_get_nth_workday(@start_date, @max_days ) AS FN, @due_date AS DUE
					END
					ELSE
					BEGIN
						SELECT @due_date = (SELECT dbo.fn_get_nth_workday(@start_date, @max_days));
					END;

					IF (@trf_calc_by_cmp = 1) AND (@group_comp_date IS NOT NULL)
					BEGIN
						SELECT @due_date = @group_comp_date;
					END
					ELSE
					BEGIN
						IF (@latest_lock_date IS NOT NULL) AND (@latest_lock_date > @due_date)
						BEGIN
							SELECT @due_date = @latest_lock_date;
						END
					END;

					UPDATE #schedule_groups 
					   SET GROUP_DUE_DATE = @due_date 
					 WHERE CURRENT OF due_date_cursor;
					 
					 SELECT @last_start = @start_date, @last_end = @due_date;

					IF DATEPART(dw, @due_date) IN (1, 7)
					BEGIN
						SELECT @start_date = (SELECT dbo.fn_get_nth_workday(@due_date, 1));
					END
					ELSE
					BEGIN
						IF @set_due_date_and_next_start_on_same_day = 0
						BEGIN
							SELECT @start_date = (SELECT dbo.fn_get_nth_workday(@due_date, 1));
						END
						ELSE
						BEGIN
							SELECT @start_date = @due_date;
						END
					END

				END

				SET @last_end = @due_date;
				SET @last_start = @start_date;
				SET @last_max_days = @max_days;
				SET @BY_START_CTR = @BY_START_CTR + 1;

				FETCH NEXT FROM due_date_cursor INTO @max_days, @group_comp_date, @latest_lock_date, @grp_seq;

			END

			CLOSE due_date_cursor;
			DEALLOCATE due_date_cursor;


		DECLARE detail_cursor CURSOR FOR
			SELECT JOB_DUE_DATE, GROUP_DUE_DATE, JOB_COMPLETED_DATE, DUE_DATE_LOCK, ORIG_REVISED_DATE, JOB_REVISED_DATE,#schedule.SORT_COL, #schedule.ROW_ID, #schedule.JOB_DAYS
				FROM #schedule INNER JOIN #schedule_groups  
				ON #schedule.SORT_COL = #schedule_groups.SORT_COL
			ORDER BY #schedule.SORT_COL, SEQ_NBR ASC;

		OPEN detail_cursor;

		FETCH NEXT FROM detail_cursor INTO @due_date, @group_due_date, @completed_date, @date_lock, @orig_date, @revised_date, @sort_col3,@curr_row_id, @curr_job_days
		
		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			IF (@trf_calc_concur_dt = 0) OR (@trf_calc_concur_dt IS NULL) ---ORIGINAL PATH
			BEGIN
			IF (@orig_date IS NULL) AND (@due_date IS NOT NULL)
				BEGIN
					SELECT @orig_date = @due_date;
				END;
				IF (@due_date IS NULL)
				BEGIN
					SELECT @due_date = @group_due_date;
				END;
				IF (@date_lock = 0) AND (@completed_date IS NULL)
				BEGIN
					UPDATE #schedule 
					   SET JOB_DUE_DATE = @due_date,
						   JOB_REVISED_DATE = @group_due_date,
						   TASK_START_DATE = CASE WHEN @set_due_date_and_next_start_on_same_day = 0 THEN
												CASE WHEN JOB_DAYS = 0 THEN @group_due_date
													 WHEN JOB_DAYS = 1 THEN dbo.fn_get_nth_workday( @group_due_date, - (JOB_DAYS))
													 ELSE dbo.fn_get_nth_workday( @group_due_date, ((JOB_DAYS*-1) + 1)) 
												END
											 ELSE
												dbo.fn_get_nth_workday(@group_due_date, - (JOB_DAYS))	
											 END,		
						   ORIG_REVISED_DATE = @orig_date,
						   DUE_DATE_LOCK = 0
					 WHERE CURRENT OF detail_cursor;
				END;
			END
			ELSE --NEW ALTERNATE DUE DATE PATH
			BEGIN
				SET @curr_sort_col = @sort_col3;

				IF ( @ctr = 0 )
				BEGIN
					SET @prev_sort_col = @sort_col3;
					SET @curr_start = @start_date;
					SET @last_end = @start_date;
					IF ( @date_lock = 0 ) AND ( @completed_date IS NULL )
					BEGIN
						IF @set_due_date_and_next_start_on_same_day = 0
						BEGIN
							IF @curr_job_days <= 1
							BEGIN
								UPDATE #schedule 
								   SET TASK_START_DATE = @start_date, 
									   JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @start_date, @curr_job_days )) 
								 WHERE ROW_ID = @curr_row_id;
							END
							ELSE
							BEGIN
								UPDATE #schedule 
								   SET TASK_START_DATE = @start_date, 
									   JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @start_date, @curr_job_days - 1 )) 
								 WHERE ROW_ID = @curr_row_id;
							END
						END
						ELSE
						BEGIN
							UPDATE #schedule 
							   SET TASK_START_DATE = @start_date, 
								   JOB_REVISED_DATE = ( SELECT dbo.fn_get_nth_workday( @start_date, @curr_job_days )) 
							 WHERE ROW_ID = @curr_row_id;
						END						
					END
					SELECT @last_end = JOB_REVISED_DATE  FROM #schedule WHERE ROW_ID = @curr_row_id;
				END
				ELSE
				BEGIN
					IF ( @date_lock = 0 ) AND ( @completed_date IS NULL )
					BEGIN		
					
					IF @curr_sort_col = @prev_sort_col --still within same order group
					BEGIN						
	
						SELECT @prev_max_days = ISNULL(MAX_DAYS, 0), @prev_grp_comp_date = ISNULL(GROUP_COMP_DATE, (SELECT MAX(JOB_COMPLETED_DATE) FROM #schedule WHERE SORT_COL = @curr_sort_col)) FROM #schedule_groups WHERE SORT_COL = @prev_sort_col;
					
						IF ( @trf_calc_by_cmp = 1 ) AND ( @prev_grp_comp_date IS NOT NULL )
						BEGIN
							SET @curr_start = @prev_grp_comp_date;
							
							IF @set_due_date_and_next_start_on_same_day = 0
							BEGIN
								SET @curr_start = dbo.fn_get_nth_workday(@curr_start, 1)
							END

						END
						IF @set_due_date_and_next_start_on_same_day = 0
						BEGIN
							SET @last_end = ( SELECT dbo.fn_get_nth_workday( @curr_start, (CASE WHEN @curr_job_days <= 1 THEN 0 ELSE -1 END + @curr_job_days) ));
						END
						ELSE
						BEGIN
							SET @last_end = ( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
						END	
					END
					ELSE --the order group has changed..
					BEGIN

						SELECT @prev_max_days = ISNULL(MAX_DAYS, 0), @prev_grp_comp_date = ISNULL(GROUP_COMP_DATE, (SELECT MAX(JOB_REVISED_DATE) FROM #schedule WHERE SORT_COL = @prev_sort_col)) FROM #schedule_groups WHERE SORT_COL = @prev_sort_col;

						SET @prev_sort_col = @sort_col3;
						--select @curr_start, @last_end
						IF ( @trf_calc_by_cmp = 1 ) AND ( @prev_grp_comp_date IS NOT NULL )
						BEGIN
							SET @curr_start = @prev_grp_comp_date
						END
						ELSE
						BEGIN
							IF @set_due_date_and_next_start_on_same_day = 0
							BEGIN
								IF @prev_max_days = 0 
								BEGIN
									--SELECT 'HI',@curr_row_id AS ROW_ID, @curr_start AS [START_DATE], @prev_max_days AS PREV_MAX_DAYS
									SET @curr_start = ( SELECT dbo.fn_get_nth_workday( @curr_start, @prev_max_days + 1 ));
									--SELECT 'HI',@curr_row_id AS ROW_ID, @curr_start AS [START_DATE], @prev_max_days AS PREV_MAX_DAYS, @date_lock AS DATE_LOCKED, @completed_date AS  COMPLETED_DATE
								END
								ELSE
								BEGIN
									SET @curr_start = ( SELECT dbo.fn_get_nth_workday( @curr_start, @prev_max_days ));
									--SELECT 'HO',@curr_row_id AS ROW_ID, @curr_start AS [START_DATE], @prev_max_days AS PREV_MAX_DAYS, @date_lock AS DATE_LOCKED, @completed_date AS  COMPLETED_DATE
								END		
							END
							ELSE
							BEGIN
								SET @curr_start = ( SELECT dbo.fn_get_nth_workday( @curr_start, @prev_max_days ));
								--SELECT 'HA',@curr_row_id AS ROW_ID, @curr_start AS [START_DATE], @prev_max_days AS PREV_MAX_DAYS
							END					
						END						
						IF @set_due_date_and_next_start_on_same_day = 0
						BEGIN
							SET @last_end = ( SELECT dbo.fn_get_nth_workday( @curr_start, (CASE WHEN @curr_job_days <= 1 THEN 0 ELSE -1 END + @curr_job_days) ));
						END
						ELSE
						BEGIN
							SET @last_end = ( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
							--SELECT 'OH',@curr_row_id AS ROW_ID, @curr_start AS [START_DATE], @last_end AS LAST_END, @prev_max_days AS PREV_MAX_DAYS
						END	
					END
					--SELECT @curr_row_id AS ROW_ID, @curr_start AS [START_DATE]
						UPDATE #schedule 
						SET TASK_START_DATE = @curr_start, 
						JOB_REVISED_DATE = @last_end 
						WHERE ROW_ID = @curr_row_id;
						--SELECT 'INS',@curr_row_id AS ROW_ID, @curr_start AS [START_DATE], @last_end AS LAST_END, @prev_max_days AS PREV_MAX_DAYS
					END
					ELSE
					BEGIN
						SET @curr_start = @revised_date;	
						SET @prev_sort_col = @sort_col3;
					END
				END

				SET @ctr = @ctr + 1;
			END
			FETCH NEXT FROM detail_cursor INTO @due_date, @group_due_date, @completed_date, @date_lock, @orig_date, @revised_date,@sort_col3, @curr_row_id, @curr_job_days
			
		END
			CLOSE detail_cursor;
			DEALLOCATE detail_cursor;
		END


	END
	ELSE -- by due date
	BEGIN
	IF ( @first_use_date IS NULL )
	BEGIN
		SELECT @ret_val = -3
		GOTO end_tran
	END
	ELSE
	BEGIN
		SELECT @orig_first_use_date = @first_use_date;
		SELECT @due_date = @first_use_date;
		SET @ctr = 0;
		DECLARE first_use_date_cursor CURSOR FOR
		SELECT MAX_DAYS, SORT_COL FROM #schedule_groups ORDER BY SORT_COL DESC

		OPEN first_use_date_cursor

		FETCH NEXT FROM first_use_date_cursor INTO @max_days, @sort_col

		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			UPDATE #schedule_groups 
			SET GROUP_DUE_DATE = @due_date 
			WHERE CURRENT OF first_use_date_cursor

			IF @set_due_date_and_next_start_on_same_day = 0
			BEGIN
				SELECT @due_date = (SELECT dbo.fn_get_nth_workday(@first_use_date, -(@max_days +1)))	
	     	END
			ELSE
			BEGIN
				SELECT @due_date = (SELECT dbo.fn_get_nth_workday( @first_use_date, -@max_days ))	
			END
			SELECT @first_use_date = @due_date;
			SET @ctr = @ctr + 1;

			FETCH NEXT FROM first_use_date_cursor INTO @max_days, @sort_col
		END

		CLOSE first_use_date_cursor
		DEALLOCATE first_use_date_cursor

	END
	
	IF (@trf_calc_concur_dt = 0) OR (@trf_calc_concur_dt IS NULL) --original path
	BEGIN
		DECLARE detail2_cursor CURSOR FOR
			SELECT JOB_DUE_DATE, GROUP_DUE_DATE, JOB_COMPLETED_DATE, DUE_DATE_LOCK, ORIG_REVISED_DATE, JOB_REVISED_DATE
			  FROM #schedule INNER JOIN #schedule_groups  
				ON #schedule.SORT_COL = #schedule_groups.SORT_COL
		  ORDER BY #schedule.SORT_COL, SEQ_NBR DESC
		OPEN detail2_cursor
		FETCH NEXT FROM detail2_cursor INTO @due_date, @group_due_date, @completed_date, @date_lock, @orig_date, @revised_date
		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			IF ( @orig_date IS NULL ) AND ( @due_date IS NOT NULL )
				SELECT @orig_date = @due_date
			IF ( @due_date IS NULL )
				SELECT @due_date = @group_due_date
			IF ( @date_lock = 0 ) AND ( @completed_date IS NULL )				
				UPDATE #schedule 
				   SET JOB_DUE_DATE = @due_date,
					   JOB_REVISED_DATE = @group_due_date,
					   TASK_START_DATE = CASE WHEN 
												@set_due_date_and_next_start_on_same_day = 0 THEN
													CASE 
														WHEN JOB_DAYS = 0 THEN dbo.fn_get_nth_workday( @group_due_date, 0)
														ELSE dbo.fn_get_nth_workday( @group_due_date, -(JOB_DAYS )) 
													END
											  ELSE
												dbo.fn_get_nth_workday( @group_due_date, -( JOB_DAYS ))	
											  END,
					   ORIG_REVISED_DATE = @orig_date,
					   DUE_DATE_LOCK = 0
				 WHERE CURRENT OF detail2_cursor
			FETCH NEXT FROM detail2_cursor INTO @due_date, @group_due_date, @completed_date, @date_lock, @orig_date, @revised_date
		END
		CLOSE detail2_cursor
		DEALLOCATE detail2_cursor
	END
	ELSE
	BEGIN
		  /**/
		--new
		SET @ctr = 0;
		DECLARE detail2_cursor CURSOR FOR
			SELECT JOB_DUE_DATE, GROUP_DUE_DATE, JOB_COMPLETED_DATE, DUE_DATE_LOCK, ORIG_REVISED_DATE, JOB_REVISED_DATE,#schedule.SORT_COL, #schedule.ROW_ID, #schedule.JOB_DAYS,#schedule_groups.MAX_DAYS
			  FROM #schedule INNER JOIN #schedule_groups  
				ON #schedule.SORT_COL = #schedule_groups.SORT_COL
		  ORDER BY #schedule.SORT_COL DESC, SEQ_NBR DESC
		OPEN detail2_cursor
		FETCH NEXT FROM detail2_cursor INTO @due_date, @group_due_date, @completed_date, @date_lock, @orig_date, @revised_date, @sort_col3,@curr_row_id, @curr_job_days, @curr_max_days
		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			SET @curr_sort_col = @sort_col3;
			IF @ctr = 0 -- first time in the loop
			BEGIN
				SET @prev_sort_col = @sort_col3
				SELECT @due_date = @orig_first_use_date
				SELECT @grp_max_days = MAX_DAYS FROM #schedule_groups WHERE SORT_COL = @sort_col3
				IF @set_due_date_and_next_start_on_same_day = 0
				BEGIN
					IF @grp_max_days = 1 OR @grp_max_days = 0
					BEGIN
						SET @grp_start = ( SELECT dbo.fn_get_nth_workday( @due_date, 0 ))
						--SELECT 'A', @grp_start, @due_date;
					END
					ELSE
					BEGIN
						SET @grp_start = ( SELECT dbo.fn_get_nth_workday( @due_date, -(@grp_max_days - 1) ))
						--SELECT 'B', @due_date, @grp_max_days;
					END
				END
				ELSE
				BEGIN
					SET @grp_start = ( SELECT dbo.fn_get_nth_workday( @due_date, -(@grp_max_days) ))
					--SELECT 'C', @due_date, @grp_max_days;
				END				
				SET @curr_start = @grp_start;
				IF @set_due_date_and_next_start_on_same_day = 0
				BEGIN
					IF @curr_job_days = 0
					BEGIN
						SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
						--SELECT 'D', @curr_start, @curr_job_days;
					END
					ELSE
					BEGIN
						SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days - 1 ));
						--SELECT 'E', @curr_start, @curr_job_days;
					END					
				END
				ELSE
				BEGIN
					SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
					--SELECT 'F', @curr_start, @curr_job_days;
				END	
				--SELECT 'yabba:', @curr_start AS curr_start, @curr_end AS curr_end, @curr_max_days AS curr_max_da
			END
			ELSE
			BEGIN
				IF @curr_sort_col = @prev_sort_col --still within same order group
				BEGIN
					SET @curr_start = @grp_start;
					--SELECT '00', @curr_start, @grp_start;
					IF @set_due_date_and_next_start_on_same_day = 0
					BEGIN
						IF @curr_job_days = 0
						BEGIN
							SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
						END
						ELSE
						BEGIN
							SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days - 1 ));
						END	
						--SELECT '1', @curr_start, @curr_job_days;						
					END
					ELSE
					BEGIN
						SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
						--SELECT '2', @curr_start, @curr_job_days;						
   					END						
					--SELECT 'dabba:', @curr_start AS curr_start, @curr_end AS curr_end, @curr_job_days AS curr_job_days, @curr_max_days AS curr_max_days
				END
				ELSE  --the order group has changed..
				BEGIN
					SET @prev_sort_col = @sort_col3;
					SET @last_start = @grp_start;
					SELECT @grp_max_days = MAX_DAYS FROM #schedule_groups WHERE SORT_COL = @sort_col3
					IF @set_due_date_and_next_start_on_same_day = 0
					BEGIN
						IF @grp_max_days = 1 OR @grp_max_days = 0
						BEGIN
							SET @grp_start = ( SELECT dbo.fn_get_nth_workday( @last_start, -1 ))
						END
						ELSE
						BEGIN
							SET @grp_start = ( SELECT dbo.fn_get_nth_workday( @last_start, -(@grp_max_days) ))
						END	
						--SELECT '3', @last_start, @grp_max_days
					END
					ELSE
					BEGIN
						SET @grp_start = ( SELECT dbo.fn_get_nth_workday( @last_start, -(@grp_max_days) ))
						--SELECT '4', @last_start, @grp_max_days
					END						
					SET @curr_start = @grp_start
					IF @set_due_date_and_next_start_on_same_day = 0
					BEGIN
						IF @curr_job_days = 0
						BEGIN
							SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
							--SELECT '5', @curr_start, @curr_job_days;		
						END
						ELSE
						BEGIN
							SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days - 1 ));
							--SELECT '6', @curr_start, @curr_job_days;		
						END
					END
					ELSE
					BEGIN
						SET @curr_end =( SELECT dbo.fn_get_nth_workday( @curr_start, @curr_job_days ));
						--SELECT '7', @curr_start, @curr_job_days;		
					END						
					--SELECT 'doo:', @curr_start AS curr_start, @curr_end AS curr_end, @curr_job_days AS curr_job_days, @curr_max_days AS curr_max_days, @grp_start AS grp_start
				END	

			END
			IF ( @date_lock = 0 ) AND ( @completed_date IS NULL )
			BEGIN
				UPDATE #schedule SET TASK_START_DATE = @curr_start, JOB_REVISED_DATE = @curr_end WHERE ROW_ID = @curr_row_id;
			END
			SET @ctr = @ctr + 1;
			FETCH NEXT FROM detail2_cursor INTO @due_date, @group_due_date, @completed_date, @date_lock, @orig_date, @revised_date, @sort_col3,@curr_row_id, @curr_job_days,@curr_max_days
		END
		CLOSE detail2_cursor
		DEALLOCATE detail2_cursor
	END
END

	-- TEST OUTPUT
	BEGIN
		--SELECT 'AFTER'
		SELECT * FROM #schedule_groups;
		SELECT * FROM #schedule ORDER BY JOB_ORDER;
	END

	-- FINAL UPDATE
	BEGIN
		UPDATE dbo.JOB_TRAFFIC_DET
		   SET JOB_DUE_DATE = s.JOB_DUE_DATE,
			   JOB_REVISED_DATE = s.JOB_REVISED_DATE,
			   TASK_START_DATE = s.TASK_START_DATE,
			   DUE_DATE_LOCK = s.DUE_DATE_LOCK,
			   JOB_ORDER = s.JOB_ORDER
		  FROM dbo.JOB_TRAFFIC_DET jtd, #schedule s
		 WHERE jtd.JOB_NUMBER = @job_number
		   AND jtd.JOB_COMPONENT_NBR = @job_component_nbr
		   AND jtd.SEQ_NBR = s.SEQ_NBR;
	END
	-- DROP TEMP TABLES
	BEGIN
		DROP TABLE #schedule;
		DROP TABLE #schedule_groups;
	END
	-- UPDATE JOB_COMPONENT
	BEGIN
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
		ELSE -- by due date
		BEGIN
			IF ( @lock_flag = 0 ) OR ( @lock_flag IS NULL ) OR ( @start_date IS NULL )
				BEGIN
					SELECT @start_date = ( SELECT MIN( TASK_START_DATE )
											 FROM dbo.JOB_TRAFFIC_DET
											WHERE JOB_NUMBER = @job_number
											  AND JOB_COMPONENT_NBR = @job_component_nbr )

					IF ( @start_date IS NOT NULL )
						UPDATE dbo.JOB_COMPONENT
						   SET START_DATE = @start_date
						 WHERE JOB_NUMBER = @job_number
						   AND JOB_COMPONENT_NBR = @job_component_nbr
				END
		END
	END
	-- CLEAN UP JOB_DUE_DATE IN JOB_TRAFFIC_DET
	BEGIN
		UPDATE dbo.JOB_TRAFFIC_DET
		   SET JOB_DUE_DATE = JOB_REVISED_DATE
		 WHERE ((NOT JOB_REVISED_DATE IS NULL) AND (JOB_DUE_DATE IS NULL))
			   AND JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr;
	END

	end_tran:

END
/*===================	QUERY	===================*/
GO


