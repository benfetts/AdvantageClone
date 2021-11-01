
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_import_brdcast_weeks]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_import_brdcast_weeks]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
***********************************************************************************************************
PJH 11/17/15 - TV processing
PJH 11/25/15 - Added RADIO processing & tested TV/Radio
PJH 11/16/17 - Changed CM to allow 0 spots
***********************************************************************************************************
*/

CREATE FUNCTION [dbo].advtf_med_import_brdcast_weeks (
		@order_type varchar(10),
		@start_date smalldatetime, 
		@end_date smalldatetime,
		@bc_date1 smalldatetime,
		@bc_date2 smalldatetime,
		@bc_date3 smalldatetime,
		@bc_date4 smalldatetime,
		@bc_date5 smalldatetime,
		@bc_date6 smalldatetime,
		@spots varchar (254),	
		@cal_type varchar (3) 
		)

	RETURNS @bc_dates_table TABLE ( 
		BC_DATE1 SMALLDATETIME,
		BC_DATE2 SMALLDATETIME,
		BC_DATE3 SMALLDATETIME,
		BC_DATE4 SMALLDATETIME,
		BC_DATE5 SMALLDATETIME,
		BC_DATE6 SMALLDATETIME,
		BC_MMYYYY VARCHAR(6),
		BC_SPOTS1 INT,
		BC_SPOTS2 INT,
		BC_SPOTS3 INT,
		BC_SPOTS4 INT,
		BC_SPOTS5 INT,
		BC_SPOTS6 INT
		)
AS
BEGIN

	DECLARE @bc_spots_table TABLE ( 
		BC_DATE1 SMALLDATETIME,
		BC_DATE2 SMALLDATETIME,
		BC_DATE3 SMALLDATETIME,
		BC_DATE4 SMALLDATETIME,
		BC_DATE5 SMALLDATETIME,
		BC_DATE6 SMALLDATETIME,
		BC_MMYYYY VARCHAR(6),
		BC_SPOTS1 INT DEFAULT (0),
		BC_SPOTS2 INT DEFAULT (0),
		BC_SPOTS3 INT DEFAULT (0),
		BC_SPOTS4 INT DEFAULT (0),
		BC_SPOTS5 INT DEFAULT (0),
		BC_SPOTS6 INT DEFAULT (0)
		)

	DECLARE @brdcast_weeks TABLE (
		BRD_YEAR int,
		BRD_WEEK_START smalldatetime,
		BRD_WEEK_END smalldatetime,
		MONTH_NAME varchar(3)
		)

	DECLARE @brdcast_weeks2 TABLE (
		BRD_YEAR int,
		BRD_MONTH int,
		BRD_WEEK_START smalldatetime,
		BRD_WEEK_END smalldatetime,
		MONTH_NAME varchar(3),
		WEEK_NBR int,
		MMYYYY varchar(6)
		)

	DECLARE @bc_date smalldatetime,
		@bc_mmyyyy varchar(10),
		@bc_spots int,
		@bc_index int,
		@tmp_date smalldatetime,
		@days int


	MAIN_LOOP:
	
	/*
	Get the Monday following the start date for the 2nd element of the array. 
	After that we can keep adding 7 days to the date to get the next Monday, etc.
	*/

	SET @bc_index = 1
	SET @bc_date = @start_date /* First Spot Date 1 */
	WHILE @bc_index <= 6 BEGIN /* This is enough for a 6 week buy. Max for Strata is 13 weeks or 14 days & Generic is 52 weeks. */
		--SET @bc_date = @start_date /* First Spot Date 1 */
		SET @tmp_date = @bc_date /* Previous spot date */
		SET @bc_spots = CAST(SUBSTRING(@spots, (3 * @bc_index) - 2, 3) AS INT)
		IF @cal_type IN ('BM') BEGIN
			SET @tmp_date = @bc_date /* Previous spot date */
			IF @bc_spots >= 0 BEGIN
				IF @bc_index = 1
					INSERT INTO @bc_spots_table (BC_DATE1, BC_MMYYYY, BC_SPOTS1) VALUES (@bc_date1, NULL, @bc_spots) /* Index 1 = updated later as needed */
				ELSE IF @bc_index = 2 
					UPDATE @bc_spots_table SET BC_DATE2 = @bc_date2, BC_SPOTS2 = @bc_spots
				ELSE IF @bc_index = 3 
					UPDATE @bc_spots_table SET BC_DATE3 = @bc_date3, BC_SPOTS3 = @bc_spots
				ELSE IF @bc_index = 4
					UPDATE @bc_spots_table SET BC_DATE4 = @bc_date4, BC_SPOTS4 = @bc_spots
				ELSE IF @bc_index = 5 
					UPDATE @bc_spots_table SET BC_DATE5 = @bc_date5, BC_SPOTS5 = @bc_spots
				ELSE IF @bc_index = 6 
					UPDATE @bc_spots_table SET BC_DATE6 = @bc_date6, BC_SPOTS6= @bc_spots
			END /* @bc_spots > 0 */
		END
		ELSE IF @cal_type = 'CM' BEGIN
			/*
			Strata is sending their own dates which will never be more than 6 dates per line so this code is not used by Strata.
			Strata has its own function that is used only for Strata Calendar month buys.
			If future broadcast imports send calendar month buys and do not send their own dates this code can be used.
			*/
			--SET @tmp_date = @bc_date /* Previous spot date */
			SET @bc_mmyyyy = CONVERT(VARCHAR(8),@tmp_date,112)  /*  112 = yyyymmdd  */
			SET @bc_mmyyyy = SUBSTRING(@bc_mmyyyy, 5, 2) + SUBSTRING(@bc_mmyyyy, 1, 4)
			--IF @bc_spots > 0 BEGIN
				IF @bc_index = 1
					INSERT INTO @bc_spots_table (BC_DATE1, BC_MMYYYY, BC_SPOTS1) VALUES (@bc_date, @bc_mmyyyy, @bc_spots) /* Index 1 = updated later as needed */
				ELSE IF @bc_index = 2 BEGIN
					IF DATEPART(dw, @bc_date) = 2 BEGIN  /* Monday so we are already at the start of a broadcast week so move to the next broadcast week */
						SET @tmp_date = @bc_date /* Previous spot date */
						SET @bc_date = DATEADD(d, 7, @tmp_date) /* New Spot Date 2 */
						SET @tmp_date = DATEADD(d, @days, @tmp_date)
						SET @bc_mmyyyy = CONVERT(VARCHAR(8),@tmp_date,112)  /*  112 = yyyymmdd  */
						SET @bc_mmyyyy = SUBSTRING(@bc_mmyyyy, 5, 2) + SUBSTRING(@bc_mmyyyy, 1, 4)
					END
					ELSE IF DATEPART(dw, @bc_date) = 1 BEGIN  /* Sunday so move to Monday which would be the next broadcast week */
						SET @tmp_date = @bc_date /* Previous spot date */
						SET @bc_date = DATEADD(d, 1, @tmp_date) /* New Spot Date 2 */
						/* Using previous date here ?? */
						SET @bc_mmyyyy = CONVERT(VARCHAR(8),@tmp_date,112)  /*  112 = yyyymmdd  */
						SET @bc_mmyyyy = SUBSTRING(@bc_mmyyyy, 5, 2) + SUBSTRING(@bc_mmyyyy, 1, 4)
					END
					ELSE BEGIN  /* Not Sunday or Monday so move to Monday which would be the next broadcast week */
						SET @tmp_date = @bc_date /* Previous spot date */
						SET @days = (7 -  DATEPART(dw, @tmp_date)) + 2
						SET @bc_date = DATEADD(d, @days, @tmp_date)  /* New Spot Date 2 */
						SET @tmp_date = DATEADD(d, @days - 1, @tmp_date)
						/* Using previous date here ?? */
						SET @bc_mmyyyy = CONVERT(VARCHAR(8),@tmp_date,112)  /*  112 = yyyymmdd  */
						SET @bc_mmyyyy = SUBSTRING(@bc_mmyyyy, 5, 2) + SUBSTRING(@bc_mmyyyy, 1, 4)
					END
					
					IF @bc_date IS NULL SET @bc_spots = 0
					UPDATE @bc_spots_table SET BC_DATE2 = @bc_date, BC_SPOTS2 = @bc_spots

				END /* @bc_index = 2 */
				ELSE BEGIN
					--SET @tmp_date = @bc_date /* Previous spot date */
					SET @bc_date = DATEADD(d, 7, @tmp_date)  /* New Spot Date 2 */
					SET @bc_mmyyyy = CONVERT(VARCHAR(8),@bc_date,112)  /*  112 = yyyymmdd  */
					SET @bc_mmyyyy = SUBSTRING(@bc_mmyyyy, 5, 2) + SUBSTRING(@bc_mmyyyy, 1, 4)

					IF @bc_date IS NULL SET @bc_spots = 0 /* Don't use aspots if there is no matching date */

					IF @bc_index = 3 
						UPDATE @bc_spots_table SET BC_DATE3 = @bc_date, BC_SPOTS3 = @bc_spots
					ELSE IF @bc_index = 4
						UPDATE @bc_spots_table SET BC_DATE4 = @bc_date, BC_SPOTS4 = @bc_spots
					ELSE IF @bc_index = 5 
						UPDATE @bc_spots_table SET BC_DATE5 = @bc_date, BC_SPOTS5 = @bc_spots
					ELSE IF @bc_index = 6 
						UPDATE @bc_spots_table SET BC_DATE6 = @bc_date, BC_SPOTS6= @bc_spots
				END /*ELSE */
			--END 
		END /* @cal_type = 'CM' */
		ELSE IF @cal_type = 'DB' BEGIN
			SET @tmp_date = @bc_date
			SET @bc_mmyyyy = CONVERT(VARCHAR(8),@tmp_date,112)  /*  112 = yyyymmdd  */
			SET @bc_mmyyyy = SUBSTRING(@bc_mmyyyy, 5, 2) + SUBSTRING(@bc_mmyyyy, 1, 4)

			INSERT INTO @bc_spots_table (BC_DATE1, BC_MMYYYY, BC_SPOTS1) VALUES (@bc_date, @bc_mmyyyy, @bc_spots) /* Index 1 = updated later as needed */

			GOTO DONE
		END
		
		SET @bc_index = @bc_index + 1

		IF @bc_date >= @end_date GOTO DONE
	END

	DONE:

	INSERT INTO @bc_dates_table SELECT * FROM @bc_spots_table

	GOTO FINISHED
	
	FINISHED:

	RETURN

END