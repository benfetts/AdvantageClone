if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Creative_Brief_Report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Creative_Brief_Report]
GO





CREATE PROCEDURE [dbo].[usp_wv_Creative_Brief_Report] 
@JobNum Int,
@JobCompNum Int,
@OmitEmptyFields int

AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int,
		@NumberRecords2 int, @RowCount2 int,
		@NumberRecords3 int, @RowCount3 int,
		@NumberRecords4 int, @RowCount4 int,
		@JNum int, 
		@desc1 varchar(MAX), @ID1 smallint,
		@desc2 varchar(MAX), @ID2 smallint,
		@desc3 varchar(MAX), @ID3 smallint,
		@desc4 varchar(MAX), @ID4 smallint,
		@descCheck varchar(MAX),
		@JCNum int, @Level1ID int, @Level2ID int, @Level3ID int, @Level4ID int	

CREATE TABLE #cb(
	RowID int IDENTITY(1, 1), 
	[Desc] varchar(MAX),
	[Level] varchar(254))

CREATE TABLE #cbLevel1(
	RowID int IDENTITY(1, 1), 
	Level1Order smallint,
	Level1Description varchar(MAX),
	Level1ID smallint)

CREATE TABLE #cbLevel2(
	RowID int IDENTITY(1, 1), 
	Level2Order smallint,
	Level2Description varchar(MAX),
	Level2ID smallint)

CREATE TABLE #cbLevel3(
	RowID int IDENTITY(1, 1), 
	Level3Order smallint,
	Level3Description varchar(MAX),
	Level3ID smallint)

CREATE TABLE #cbLevelDetail(
	RowID int IDENTITY(1, 1), 
	DetailID smallint,
	DetailDescription varchar(MAX))

CREATE TABLE #cbLevel1Check(
	RowID int IDENTITY(1, 1), 
	Level2Order smallint,
	Level2Description varchar(MAX),
	Level2ID smallint)

CREATE TABLE #cbLevel2Check(
	RowID int IDENTITY(1, 1), 
	Level3Order smallint,
	Level3Description varchar(MAX),
	Level3ID smallint)

CREATE TABLE #cbLevel3Check(
	RowID int IDENTITY(1, 1), 
	DetailID smallint,
	DetailDescription varchar(MAX))

INSERT INTO #cbLevel1
        SELECT CB1.LVL1_ORDER, ISNULL(CB1.CRTV_BRF_LVL1_DESC,''), CB1.CRTV_BRF_LVL1_ID
        FROM CRTV_BRF_DTL CBD
        INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
        INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
        INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
        WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
        GROUP BY CB1.LVL1_ORDER, CB1.CRTV_BRF_LVL1_DESC, CB1.CRTV_BRF_LVL1_ID
        ORDER BY CB1.LVL1_ORDER

SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1
--SELECT * FROM #cbLevel1

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @desc1 = Level1Description, @ID1 = Level1ID
 FROM #cbLevel1
 WHERE RowID = @RowCount
 
   TRUNCATE TABLE #cbLevel1Check 
   --SELECT * FROM #cbLevel1
   --SELECT @ID1 AS ID1,@RowCount AS RowCount1
  INSERT INTO #cbLevel1Check
        SELECT CB2.LVL2_ORDER, ISNULL(CB2.CRTV_BRF_LVL2_DESC,''), CB2.CRTV_BRF_LVL2_ID 
        FROM CRTV_BRF_DTL CBD
        INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
        INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
        INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
        WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
          AND CB2.CRTV_BRF_LVL1_ID = @ID1
        GROUP BY CB2.LVL2_ORDER, CB2.CRTV_BRF_LVL2_DESC, CB2.CRTV_BRF_LVL2_ID
        ORDER BY CB2.LVL2_ORDER
		--SELECT * FROM #cbLevel1Check
	SELECT @NumberRecords2 = COUNT(*) FROM #cbLevel1Check
	SET @RowCount2 = 1

	if @OmitEmptyFields = 1
	 Begin
		WHILE @RowCount2 <= @NumberRecords2
		BEGIN
			SELECT @ID2 = Level2ID FROM #cbLevel1Check WHERE RowID = @RowCount2
			--SELECT @ID2,@RowCount
			TRUNCATE TABLE #cbLevel3

			INSERT INTO #cbLevel3
				SELECT CB3.LVL3_ORDER, ISNULL(CB3.CRTV_BRF_LVL3_DESC,''), CB3.CRTV_BRF_LVL3_ID
				FROM CRTV_BRF_DTL CBD
				INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
				INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
				INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
				WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
				  AND CB3.CRTV_BRF_LVL2_ID = @ID2
				GROUP BY CB3.LVL3_ORDER, CB3.CRTV_BRF_LVL3_DESC, CB3.CRTV_BRF_LVL3_ID
				ORDER BY CB3.LVL3_ORDER
				--SELECT * FROM #cbLevel3
				SELECT @NumberRecords3 = COUNT(*) FROM #cbLevel3
				SET @RowCount3 = 1

				WHILE @RowCount3 <= @NumberRecords3
				BEGIN
				 SELECT @ID3 = Level3ID FROM #cbLevel3 WHERE RowID = @RowCount3
				 --SELECT @ID3
					 TRUNCATE TABLE #cbLevelDetail

					INSERT INTO #cbLevelDetail
						SELECT CBD.CRTV_BRF_DTL_ID, ISNULL(CBD.CRTV_BRF_DTL_DESC,'')
						FROM CRTV_BRF_DTL CBD
						INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
						INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
						INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
						WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
						  AND CBD.CRTV_BRF_LVL3_ID = @ID3
						ORDER BY CBD.DTL_ORDER
					
					--SELECT * FROM #cbLevelDetail	
					SELECT @NumberRecords4 = COUNT(*) FROM #cbLevelDetail
					SET @RowCount4 = 1
					--SET @descCheck = ''
					WHILE @RowCount4 <= @NumberRecords4
					BEGIN
							SELECT @descCheck = DetailDescription FROM #cbLevelDetail WHERE RowID = @RowCount4
							If @descCheck <> ''
								Begin								
									INSERT INTO #cb VALUES(@desc1,'1')
																				
								End	

						SET @RowCount4 = @RowCount4 + 1			
								
					END
					--SELECT @ID3,@descCheck,@desc1
				 SET @RowCount3 = @RowCount3 + 1
				 If @descCheck <> ''
				  Begin
					BREAK
				  End
			    END
				--SELECT @ID2,@descCheck,@desc1
			SET @RowCount2 = @RowCount2 + 1
			
					BREAK
			
		END
	 End
	 Else
	 Begin
		INSERT INTO #cb VALUES(@desc1,'1')
	 End 

	
	TRUNCATE TABLE #cbLevel2  	

	INSERT INTO #cbLevel2
        SELECT CB2.LVL2_ORDER, ISNULL(CB2.CRTV_BRF_LVL2_DESC,''), CB2.CRTV_BRF_LVL2_ID 
        FROM CRTV_BRF_DTL CBD
        INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
        INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
        INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
        WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
          AND CB2.CRTV_BRF_LVL1_ID = @ID1
        GROUP BY CB2.LVL2_ORDER, CB2.CRTV_BRF_LVL2_DESC, CB2.CRTV_BRF_LVL2_ID
        ORDER BY CB2.LVL2_ORDER

	SELECT @NumberRecords2 = COUNT(*) FROM #cbLevel2
	SET @RowCount2 = 1

	
	WHILE @RowCount2 <= @NumberRecords2
	BEGIN
	 SELECT @desc2 = Level2Description, @ID2 = Level2ID
	 FROM #cbLevel2
	 WHERE RowID = @RowCount2
	 --SELECT * FROM #cbLevel2
	 --SELECT @ID2 AS ID2,@RowCount AS RowCount2
	 TRUNCATE TABLE #cbLevel2Check

		INSERT INTO #cbLevel2Check
			SELECT CB3.LVL3_ORDER, ISNULL(CB3.CRTV_BRF_LVL3_DESC,''), CB3.CRTV_BRF_LVL3_ID
			FROM CRTV_BRF_DTL CBD
			INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
			INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
			INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
			WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
			  AND CB3.CRTV_BRF_LVL2_ID = @ID2
			GROUP BY CB3.LVL3_ORDER, CB3.CRTV_BRF_LVL3_DESC, CB3.CRTV_BRF_LVL3_ID
			ORDER BY CB3.LVL3_ORDER

	 if @OmitEmptyFields = 1
	 Begin
		SELECT @NumberRecords3 = COUNT(*) FROM #cbLevel2Check
		SET @RowCount3 = 1

		WHILE @RowCount3 <= @NumberRecords3
		BEGIN
		 SELECT @ID3 = Level3ID FROM #cbLevel2Check WHERE RowID = @RowCount3

			 TRUNCATE TABLE #cbLevelDetail

			INSERT INTO #cbLevelDetail
				SELECT CBD.CRTV_BRF_DTL_ID, ISNULL(CBD.CRTV_BRF_DTL_DESC,'')
				FROM CRTV_BRF_DTL CBD
				INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
				INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
				INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
				WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
				  AND CBD.CRTV_BRF_LVL3_ID = @ID3
				ORDER BY CBD.DTL_ORDER

			SELECT @NumberRecords4 = COUNT(*) FROM #cbLevelDetail
			SET @RowCount4 = 1
			--SELECT * FROM #cbLevelDetail			
			WHILE @RowCount4 <= @NumberRecords4
			BEGIN			
				SELECT @descCheck = DetailDescription FROM #cbLevelDetail WHERE RowID = @RowCount4	
					If @descCheck <> ''
						Begin								
							INSERT INTO #cb VALUES(@desc2,'2')	
							BREAK										
						End	

				SET @RowCount4 = @RowCount4 + 1
				
			END

		  SET @RowCount3 = @RowCount3 + 1	
		  If @descCheck <> ''
		  Begin
			BREAK
		  End	 
		  
		 END
	 End
	 Else
	 Begin
		INSERT INTO #cb VALUES(@desc2,'2')
	 End	  
	 
		TRUNCATE TABLE #cbLevel3

		INSERT INTO #cbLevel3
			SELECT CB3.LVL3_ORDER, ISNULL(CB3.CRTV_BRF_LVL3_DESC,''), CB3.CRTV_BRF_LVL3_ID
			FROM CRTV_BRF_DTL CBD
			INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
			INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
			INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
			WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
			  AND CB3.CRTV_BRF_LVL2_ID = @ID2
			GROUP BY CB3.LVL3_ORDER, CB3.CRTV_BRF_LVL3_DESC, CB3.CRTV_BRF_LVL3_ID
			ORDER BY CB3.LVL3_ORDER
	

			SELECT @NumberRecords3 = COUNT(*) FROM #cbLevel3
			SET @RowCount3 = 1

			WHILE @RowCount3 <= @NumberRecords3
			BEGIN
			 SELECT @desc3 = Level3Description, @ID3 = Level3ID
			 FROM #cbLevel3		
			 WHERE RowID = @RowCount3	 
	 --SELECT * FROM #cbLevel3
		--SELECT @desc3, @ID3
			 TRUNCATE TABLE #cbLevel3Check

				INSERT INTO #cbLevel3Check
				SELECT CBD.CRTV_BRF_DTL_ID, ISNULL(CBD.CRTV_BRF_DTL_DESC,'')
				FROM CRTV_BRF_DTL CBD
				INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
				INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
				INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
				WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
				  AND CBD.CRTV_BRF_LVL3_ID = @ID3
				ORDER BY CBD.DTL_ORDER

			 --SELECT * FROM #cbLevel3Check
			 if @OmitEmptyFields = 1
			 Begin	
				SELECT @NumberRecords4 = COUNT(*) FROM #cbLevel3Check
				SET @RowCount4 = 1

				WHILE @RowCount4 <= @NumberRecords4
				BEGIN
					SELECT @descCheck = DetailDescription FROM #cbLevel3Check WHERE RowID = @RowCount4
						If @descCheck <> ''
							Begin								
								INSERT INTO #cb VALUES(@desc3,'3')			
								BREAK						
							End	

					SET @RowCount4 = @RowCount4 + 1
					
				END				
			 End
			 Else
			 Begin
				INSERT INTO #cb VALUES(@desc3,'3')
			 End
			 		 

				TRUNCATE TABLE #cbLevelDetail

				INSERT INTO #cbLevelDetail
				SELECT CBD.CRTV_BRF_DTL_ID, ISNULL(CBD.CRTV_BRF_DTL_DESC,'')
				FROM CRTV_BRF_DTL CBD
				INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL3_ID = CBD.CRTV_BRF_LVL3_ID
				INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL2_ID = CB3.CRTV_BRF_LVL2_ID
				INNER JOIN CRTV_BRF_LVL1 CB1 ON CB1.CRTV_BRF_LVL1_ID = CB2.CRTV_BRF_LVL1_ID
				WHERE CBD.JOB_NUMBER = @JobNum AND CBD.JOB_COMPONENT_NBR = @JobCompNum
				  AND CBD.CRTV_BRF_LVL3_ID = @ID3
				ORDER BY CBD.DTL_ORDER

			--SELECT * FROM #cbLevelDetail

				SELECT @NumberRecords4 = COUNT(*) FROM #cbLevelDetail
				SET @RowCount4 = 1

				WHILE @RowCount4 <= @NumberRecords4
					BEGIN
					 SELECT @descCheck = DetailDescription, @ID4 = DetailID
					 FROM #cbLevelDetail
					 WHERE RowID = @RowCount4
						if @OmitEmptyFields = 1
						Begin
							If @descCheck <> ''
							Begin								
								INSERT INTO #cb
								VALUES(@descCheck,'4')												
							End
						End
						Else
						Begin
							INSERT INTO #cb
							VALUES(@descCheck,'4')			
						End
						
						--SELECT * FROM #cb
						SET @RowCount4 = @RowCount4 + 1
					END

				SET @RowCount3 = @RowCount3 + 1
			END

		SET @RowCount2 = @RowCount2 + 1
	END 
		
 SET @RowCount = @RowCount + 1
END

SELECT * FROM #cb ORDER BY RowID
 

DROP TABLE #cb





