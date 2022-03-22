IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_card_user_sort_alerts]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_card_user_sort_alerts]
GO
CREATE PROCEDURE [dbo].[advsp_card_user_sort_alerts] 
@EMP_CODE VARCHAR(6),
@ALERT_ID INT,
@TASK_SEQ_NBR SMALLINT = NULL,
@NEW_POSITION INT,
@FROM_DASHBOARD_TYPE SMALLINT = 3	--  1 = ASSIGNMENTS, 2 = ALERTS, 3 = PROOFS
AS
/*=========== QUERY ===========*/
BEGIN
	--	TABLE VARIABLES
	BEGIN
		DECLARE @SORTING_TABLE TABLE (ID INT IDENTITY(1,1) NOT NULL,
									  ALERT_ID INT NULL,
									  GENERATED SMALLDATETIME NULL,
									  OLD_POSITION INT NULL,
									  NEW_POSITION INT NULL);
		DECLARE @SORTED_TABLE TABLE (ID INT IDENTITY(1,1) NOT NULL,
									  ALERT_ID INT NULL,
									  GENERATED SMALLDATETIME NULL,
									  OLD_POSITION INT NULL,
									  NEW_POSITION INT NULL);
	END
	--	VARIABLES
	BEGIN
		DECLARE
			@ID_OF_MOVED_ROW INT = 0,
			@CURRENT_ID INT = 0, 
			@CURRENT_POSITION INT = 0, 
			@OLD_POSITION INT = 0,
			@LAST_POSITION INT = 0,
			@POSITION_DIFF INT = 0,
			@ROW_COUNT INT = 0,
			@OFFSET [DECIMAL](9,3) = 0,
			@IS_TASK BIT = 0,
			@JOB_NUMBER INT = 0,
			@JOB_COMPONENT_NBR SMALLINT = 0
		;
		DECLARE @ALERTS TABLE (	ID INT,
								AlertTypeID INT,
								AlertTypeDescription VARCHAR(MAX),
								GeneratedDate SMALLDATETIME,
								LastUpdatedDateTime SMALLDATETIME,
								EmployeeCode VARCHAR(6),
								LastUpdatedFullName VARCHAR(500),
								OfficeCode VARCHAR(500),
								ClientCode VARCHAR(500),
								ClientName VARCHAR(500),
								DivisionCode VARCHAR(500),
								DivisionName VARCHAR(500),
								ProductCode VARCHAR(500),
								ProductName VARCHAR(500),
								CampainID INT,
								CampaignCode VARCHAR(500),
								CampaignName VARCHAR(500),
								JobNumber INT,
								JobDescription VARCHAR(500),
								JobComponentNumber SMALLINT,
								JobComponentDescription VARCHAR(500),
								TaskFunctionDescription VARCHAR(500),
								IsAlertCC BIT,
								AlertCategoryID INT,
								AlertCategoryDescription VARCHAR(500),
								PriorityLevel SMALLINT,
								DueDate SMALLDATETIME,
								TimeDue VARCHAR(500),
								[Subject] VARCHAR(500),
								AlertStateID INT,
								AlertStateName VARCHAR(500),
								IsAlertAssignment BIT,
								TaskSequenceNumber SMALLINT,
								TaskStatus VARCHAR(500),
								SprintID INT,
								BoardID INT,
								IsWorkItem BIT,
								ReadAlert BIT,
								ReadAlertText VARCHAR(500),
								CardSequenceNumber INT,
								StartDate SMALLDATETIME,
								TaskComment VARCHAR(500),
								CheckListCompleted INT,
								CheckListTotal INT,
								IsCSReview BIT,
								CSProjectID INT,
								CSReviewID INT,
								IsMyTaskTempComplete BIT,
								EstimateNumber INT,
								EstimateComponentNumber SMALLINT,
								CheckListComplete BIT,
								GroupKey VARCHAR(500),
								IsAutoRoute BIT,
								IsProof BIT
		)
	END
	--	INITIALIZE
	BEGIN
		SET @NEW_POSITION = ISNULL(@NEW_POSITION, 0) + 1;
		IF @TASK_SEQ_NBR IS NULL
		BEGIN
			SELECT
				@JOB_NUMBER = A.JOB_NUMBER,
				@JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR,
				@TASK_SEQ_NBR = A.TASK_SEQ_NBR
			FROM
				ALERT A WITH(NOLOCK)
			WHERE
				A.ALERT_ID = @ALERT_ID
				AND ISNULL(A.JOB_NUMBER, 0) > 0
				AND ISNULL(A.JOB_COMPONENT_NBR, 0) > 0
				AND ISNULL(A.TASK_SEQ_NBR, 0) >= 0
			;
		END
		IF @TASK_SEQ_NBR IS NOT NULL
		BEGIN
			SELECT @IS_TASK = 1;
		END
	END
	--	GET DATA
	BEGIN
		-- BASE
		BEGIN
			INSERT INTO @ALERTS
			EXEC [dbo].[usp_wv_dto_dashboard_alert] @EMP_CODE;
		END
		--	GET LIST
		IF @FROM_DASHBOARD_TYPE = 1
		BEGIN
			INSERT INTO @SORTING_TABLE (ALERT_ID, GENERATED, OLD_POSITION)
			SELECT
				A.ID,
				A.GeneratedDate,
				A.CardSequenceNumber
			FROM
				@ALERTS A
			WHERE
				ISNULL(A.IsProof, 0) = 0
				AND A.AlertCategoryID <> 79
				AND A.AlertCategoryID <> 15
				AND ISNULL(A.IsAlertCC, 0) = 0
			ORDER BY
				A.CardSequenceNumber,
				A.LastUpdatedDateTime DESC
			;
		END
		IF @FROM_DASHBOARD_TYPE = 2
		BEGIN
			INSERT INTO @SORTING_TABLE (ALERT_ID, GENERATED, OLD_POSITION)
			SELECT
				A.ID,
				A.GeneratedDate,
				A.CardSequenceNumber
			FROM
				@ALERTS A
			WHERE
				ISNULL(A.IsAlertAssignment, 0) = 0
			ORDER BY
				A.CardSequenceNumber,
				A.LastUpdatedDateTime DESC
			;
		END
		IF @FROM_DASHBOARD_TYPE = 3
		BEGIN
			INSERT INTO @SORTING_TABLE (ALERT_ID, GENERATED, OLD_POSITION)
			SELECT
				A.ID,
				A.GeneratedDate,
				A.CardSequenceNumber
			FROM
				@ALERTS A
			WHERE
				A.IsProof = 1
			ORDER BY
				A.CardSequenceNumber,
				A.LastUpdatedDateTime DESC
			;
		END
		SELECT @ROW_COUNT = COUNT(1) FROM @SORTING_TABLE;
		IF @NEW_POSITION > @ROW_COUNT
		BEGIN
			SELECT @NEW_POSITION = @ROW_COUNT;
		END
		UPDATE @SORTING_TABLE SET OLD_POSITION = ID;-- WHERE OLD_POSITION IS NULL;
	END
	--	SET POSITION OF ITEM THAT WAS MOVED
	BEGIN
		SELECT @ID_OF_MOVED_ROW = ID, @OLD_POSITION = COALESCE(ID, OLD_POSITION, 1) FROM @SORTING_TABLE WHERE ALERT_ID = @ALERT_ID;
		UPDATE @SORTING_TABLE SET NEW_POSITION = @NEW_POSITION WHERE ID = @ID_OF_MOVED_ROW;
		SET @POSITION_DIFF = @NEW_POSITION - @OLD_POSITION;
	END
	--SELECT @OLD_POSITION, @NEW_POSITION, @POSITION_DIFF
	--SELECT * FROM @SORTING_TABLE;
	IF @POSITION_DIFF <> 0
	BEGIN
		IF @POSITION_DIFF < 0
		BEGIN
			INSERT INTO @SORTED_TABLE (ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION)
			SELECT ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION FROM @SORTING_TABLE WHERE NEW_POSITION IS NULL AND OLD_POSITION < @NEW_POSITION ORDER BY OLD_POSITION;
			INSERT INTO @SORTED_TABLE (ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION)
			SELECT ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION FROM @SORTING_TABLE WHERE NEW_POSITION = @NEW_POSITION;
			INSERT INTO @SORTED_TABLE (ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION)
			SELECT ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION FROM @SORTING_TABLE WHERE NEW_POSITION IS NULL AND ALERT_ID NOT IN (SELECT ALERT_ID FROM @SORTED_TABLE) ORDER BY OLD_POSITION;
			UPDATE @SORTED_TABLE SET NEW_POSITION = ID WHERE NEW_POSITION IS NULL;
		END
		IF @POSITION_DIFF > 0
		BEGIN
			INSERT INTO @SORTED_TABLE (ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION)
			SELECT ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION FROM @SORTING_TABLE WHERE NEW_POSITION IS NULL AND OLD_POSITION <= @NEW_POSITION ORDER BY OLD_POSITION;
			INSERT INTO @SORTED_TABLE (ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION)
			SELECT ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION FROM @SORTING_TABLE WHERE NEW_POSITION = @NEW_POSITION;
			INSERT INTO @SORTED_TABLE (ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION)
			SELECT ALERT_ID, GENERATED, OLD_POSITION, NEW_POSITION FROM @SORTING_TABLE WHERE NEW_POSITION IS NULL AND ALERT_ID NOT IN (SELECT ALERT_ID FROM @SORTED_TABLE) ORDER BY OLD_POSITION;
			UPDATE @SORTED_TABLE SET NEW_POSITION = ID WHERE NEW_POSITION IS NULL;
		END
		--SELECT * FROM @SORTING_TABLE;
		--SELECT * FROM @SORTED_TABLE;

		--	UPDATE THE RECORDS
		BEGIN
			IF @FROM_DASHBOARD_TYPE = 1 -- ASSIGNMENT (ONLY ALERT_RCPT WILL BE ON DASH)
			BEGIN
				UPDATE ALERT_RCPT SET CARD_SEQ_NBR = ST.NEW_POSITION
				FROM 
					ALERT_RCPT AR 
					INNER JOIN @SORTED_TABLE ST ON AR.ALERT_ID = ST.ALERT_ID
				WHERE 
					AR.EMP_CODE = @EMP_CODE 
					AND ISNULL(AR.CURRENT_NOTIFY, 0) = 1
				;
			END
			IF @FROM_DASHBOARD_TYPE = 2 -- ALERT (ONLY ALERT_RCPT WILL BE ON DASH) 
			BEGIN
				UPDATE ALERT_RCPT SET CARD_SEQ_NBR = ST.NEW_POSITION
				FROM 
					ALERT_RCPT AR 
					INNER JOIN @SORTED_TABLE ST ON AR.ALERT_ID = ST.ALERT_ID
				WHERE 
					AR.EMP_CODE = @EMP_CODE 
					AND ISNULL(AR.CURRENT_NOTIFY, 0) = 0
				;
			END
			IF @FROM_DASHBOARD_TYPE = 3 -- PROOFING (COULD BE IN EITHER ALERT_RCPT OR ALERT_RCPT_DISMISSED)
			BEGIN
				UPDATE ALERT_RCPT SET CARD_SEQ_NBR = ST.NEW_POSITION
				FROM 
					ALERT_RCPT AR 
					INNER JOIN @SORTED_TABLE ST ON AR.ALERT_ID = ST.ALERT_ID
				WHERE 
					AR.EMP_CODE = @EMP_CODE 
					AND ISNULL(AR.CURRENT_NOTIFY, 0) = 1
				;
				UPDATE ALERT_RCPT_DISMISSED SET CARD_SEQ_NBR = ST.NEW_POSITION
				FROM 
					ALERT_RCPT_DISMISSED ARd 
					INNER JOIN @SORTED_TABLE ST ON ARd.ALERT_ID = ST.ALERT_ID
				WHERE 
					ARd.EMP_CODE = @EMP_CODE 
					AND ISNULL(ARd.CURRENT_NOTIFY, 0) = 1
				;
			END
		END


	END
	--SELECT * FROM @SORTED_TABLE ORDER BY ID;
END
/*=========== QUERY ===========*/