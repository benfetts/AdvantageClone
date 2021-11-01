IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advtf_find_open_time_entry]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advtf_find_open_time_entry]
END
GO
CREATE FUNCTION [dbo].[advtf_find_open_time_entry] (
@EMP_CODE VARCHAR(6),
@EMP_DATE SMALLDATETIME,
@EMP_HOURS DECIMAL (9,3),
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR INT,
@FNC_CODE VARCHAR(10),
@ALERT_ID INT,
@FIND_WITH_COMMENT BIT
) 
RETURNS @ENTRY TABLE (ET_ID INT, ETD_ID INT, EMP_HOURS DECIMAL (9,3), COMMENT TEXT)
AS
BEGIN
/*=========== QUERY ===========*/
	DECLARE
		@POSSIBLE_RECORDS TABLE (ID INT IDENTITY, ET_ID INT, ETD_ID INT);
	DECLARE
		@TIME_TYPE VARCHAR(1),
		@REC_COUNT INT,
		@CURR_ET_ID INT,
		@CURR_ETD_ID INT,
		@CURR_ID INT,
		@CURR_COMMENT VARCHAR(MAX),
		@ENTRY_FOUND BIT,
		@SEQ_NBR SMALLINT,
		@SUMMARIZED_REC_COUNT INT,
		@UPDATE_EDITABLE_CHECKED BIT,
		@UPDATE_EST_APPR_CHECKED BIT,
		@CAN_EDIT_THIS SMALLINT,
		@EDIT_MESSAGE_THIS VARCHAR(MAX),
		@EST_CHECK_CAN_MODIFY_TIME BIT,
		@EST_EXCEED_OPTION SMALLINT, -- 0 = YES (ALLOW, NO MESSAGE NEEDED), 1 = WARN (ALLOW BUT SHOW WARNING MESSAGE), 2 = NO  (DON'T ALLOW, SHOW MESSAGE)
		@SUM_ACTUAL DECIMAL(32,2),
		@SUM_APPROVED DECIMAL (32,2),
		@APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND BIT,
		@IS_OVER_ESTIMATE_AMOUNT BIT

	IF @FIND_WITH_COMMENT IS NULL SET @FIND_WITH_COMMENT = 0;

	IF NOT @JOB_NUMBER IS NULL AND @JOB_NUMBER > 0 AND NOT @JOB_COMPONENT_NBR IS NULL AND @JOB_COMPONENT_NBR > 0
	BEGIN
		SET @TIME_TYPE = 'D';
		IF @ALERT_ID IS NULL OR @ALERT_ID = 0
		BEGIN
			INSERT INTO @POSSIBLE_RECORDS (ET_ID, ETD_ID)
			SELECT 
				ET.ET_ID, ETD.ET_DTL_ID
			FROM
				EMP_TIME ET
				INNER JOIN EMP_TIME_DTL ETD ON ET.ET_ID = ETD.ET_ID
			WHERE
				ET.EMP_DATE = @EMP_DATE
				AND ET.EMP_CODE = @EMP_CODE
				AND ETD.FNC_CODE = @FNC_CODE
				AND ETD.JOB_NUMBER = @JOB_NUMBER
				AND ETD.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				AND (ETD.ALERT_ID IS NULL OR ETD.ALERT_ID = 0)
				AND (ETD.EDIT_FLAG IS NULL OR ETD.EDIT_FLAG = 0)
			ORDER BY
				ETD.ET_DTL_ID DESC
		END
		ELSE
		BEGIN
			INSERT INTO @POSSIBLE_RECORDS (ET_ID, ETD_ID)
			SELECT 
				ET.ET_ID, ETD.ET_DTL_ID
			FROM
				EMP_TIME ET
				INNER JOIN EMP_TIME_DTL ETD ON ET.ET_ID = ETD.ET_ID
			WHERE
				ET.EMP_DATE = @EMP_DATE
				AND ET.EMP_CODE = @EMP_CODE
				AND ETD.FNC_CODE = @FNC_CODE
				AND ETD.JOB_NUMBER = @JOB_NUMBER
				AND ETD.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				AND ETD.ALERT_ID = @ALERT_ID
				AND (ETD.EDIT_FLAG IS NULL OR ETD.EDIT_FLAG = 0)
			ORDER BY
				ETD.ET_DTL_ID DESC
		END
		SELECT @REC_COUNT = COUNT(1) FROM @POSSIBLE_RECORDS;
		SET @ENTRY_FOUND = 0;
		SET @CURR_ID = 0;
		IF @REC_COUNT > 0
		BEGIN
			WHILE @CURR_ID <= @REC_COUNT AND @ENTRY_FOUND = 0
			BEGIN
				SET @CURR_ID = @CURR_ID + 1;
				SET @CURR_ET_ID = NULL;
				SET @CURR_ETD_ID = NULL;
				SET @CURR_COMMENT = NULL;
				SELECT @CURR_ET_ID = ET_ID, @CURR_ETD_ID = ETD_ID FROM @POSSIBLE_RECORDS PR WHERE PR.ID = @CURR_ID;
				IF (NOT @CURR_ET_ID IS NULL AND @CURR_ET_ID > 0) AND (NOT @CURR_ETD_ID IS NULL AND @CURR_ETD_ID > 0)
				BEGIN	
					-- CHECK IF SUMMARIZED
					BEGIN
						SELECT @SUMMARIZED_REC_COUNT = COUNT(1)
						FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
						WHERE  etd.ET_ID = @CURR_ET_ID
								AND etd.ET_DTL_ID = @CURR_ETD_ID;
						IF @SUMMARIZED_REC_COUNT > 1
						BEGIN
							SELECT @SEQ_NBR = MAX(SEQ_NBR) 
							FROM EMP_TIME_DTL WITH(NOLOCK) 
							WHERE ET_ID = @CURR_ET_ID AND ET_DTL_ID = @CURR_ETD_ID AND (EDIT_FLAG = 0 OR EDIT_FLAG <> 1 OR EDIT_FLAG IS NULL);
						END
						ELSE
						BEGIN
							SET @SEQ_NBR = NULL;
						END
					END
					--GET EDIT STATUS
					BEGIN
						SELECT @CAN_EDIT_THIS = CAN_EDIT, @EDIT_MESSAGE_THIS = RETURN_MESSAGE 
						FROM [dbo].[wvfn_ts_can_edit] (@EMP_CODE, @CURR_ET_ID, @CURR_ETD_ID, @SEQ_NBR);
						SET @CAN_EDIT_THIS = ISNULL(@CAN_EDIT_THIS, 0);
					END
					IF @CAN_EDIT_THIS = 1
					BEGIN
						-- CHECK ESTIMATE APPROVAL SETTINGS
						SELECT 
							@EST_CHECK_CAN_MODIFY_TIME = EST_CHECK_CAN_MODIFY_TIME,
							@EST_EXCEED_OPTION = EXCEED_OPTION,
							@EDIT_MESSAGE_THIS = DISPLAY_MSG,
							@APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND = APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND,
							@SUM_ACTUAL = SUM_ACTUAL,
							@SUM_APPROVED = SUM_APPROVED,
							@IS_OVER_ESTIMATE_AMOUNT = IS_OVER
						FROM 
							[dbo].[advtf_timesheet_approved_estimate_check] (@JOB_NUMBER, @JOB_COMPONENT_NBR, @EMP_HOURS, @FNC_CODE);
						IF @APPROVED_ESTIMATE_REQUIRED_BUT_NOT_FOUND = 1 -- BLOCK
						BEGIN
							SET @CAN_EDIT_THIS = 0;
						END
						ELSE
						BEGIN
							IF @IS_OVER_ESTIMATE_AMOUNT = 1
							BEGIN
								IF @EST_EXCEED_OPTION = 1 -- WARN
								BEGIN
									SET @CAN_EDIT_THIS = 1;
								END
								IF @EST_EXCEED_OPTION = 2 -- BLOCK
								BEGIN
									SET @CAN_EDIT_THIS = 0;
								END
							END
						END
					END
					IF @CAN_EDIT_THIS = 1
					BEGIN
						SELECT @CURR_COMMENT = EMP_COMMENT FROM EMP_TIME_DTL_CMTS C WHERE C.ET_SOURCE = 'D' AND C.ET_ID = @CURR_ET_ID AND C.ET_DTL_ID = @CURR_ETD_ID;
						IF @FIND_WITH_COMMENT = 1
						BEGIN
							IF NOT @CURR_COMMENT IS NULL AND LEN(RTRIM(LTRIM(REPLACE(@CURR_COMMENT,CHAR(13)+CHAR(10),'')))) > 0
							BEGIN
								SET @CAN_EDIT_THIS = 1
							END
							ELSE
							BEGIN
								SET @CAN_EDIT_THIS = 0
							END
						END
						ELSE
						BEGIN
							IF @CURR_COMMENT IS NULL OR LEN(RTRIM(LTRIM(REPLACE(@CURR_COMMENT,CHAR(13)+CHAR(10),'')))) = 0
							BEGIN
								SET @CAN_EDIT_THIS = 1;
							END
							ELSE
							BEGIN
								SET @CAN_EDIT_THIS = 0;
							END
						END
					END
					IF @CAN_EDIT_THIS = 1
					BEGIN
						SET @ENTRY_FOUND = 1;
						BREAK;
					END
				END
			END
		END
		IF @ENTRY_FOUND = 0
		BEGIN
			SET @CURR_ET_ID = 0;
			SET @CURR_ETD_ID = 0;
		END
	END
	ELSE
	BEGIN
		SET @TIME_TYPE = 'N';
		SELECT
			@CURR_ET_ID = A.ET_ID,
			@CURR_ETD_ID = A.ET_DTL_ID
		FROM (
			SELECT 
				TOP 1 ET.ET_ID, ETD.ET_DTL_ID
			FROM
				EMP_TIME ET
				INNER JOIN EMP_TIME_NP ETD ON ET.ET_ID = ETD.ET_ID
			WHERE
				ET.EMP_DATE = @EMP_DATE
				AND ET.EMP_CODE = @EMP_CODE
				AND ETD.CATEGORY = @FNC_CODE
			ORDER BY
				ETD.ET_DTL_ID DESC
		) AS A;
	END

	SET @CURR_ET_ID = ISNULL(@CURR_ET_ID, 0);
	SET @CURR_ETD_ID = ISNULL(@CURR_ETD_ID, 0);
	IF @CURR_ET_ID > 0 AND @CURR_ETD_ID > 0
	BEGIN
		IF @TIME_TYPE = 'D'
		BEGIN
			INSERT INTO @ENTRY (ET_ID, ETD_ID, EMP_HOURS)
			SELECT
				TOP 1 E.ET_ID, E.ET_DTL_ID, E.EMP_HOURS
			FROM
				EMP_TIME_DTL E
			WHERE
				E.ET_ID = @CURR_ET_ID
				AND E.ET_DTL_ID = @CURR_ETD_ID;
		END
		IF @TIME_TYPE = 'N'
		BEGIN
			INSERT INTO @ENTRY (ET_ID, ETD_ID, EMP_HOURS)
			SELECT
				TOP 1 E.ET_ID, E.ET_DTL_ID, E.EMP_HOURS
			FROM
				EMP_TIME_NP E
			WHERE
				E.ET_ID = @CURR_ET_ID
				AND E.ET_DTL_ID = @CURR_ETD_ID;
		END
		UPDATE @ENTRY SET COMMENT = C.EMP_COMMENT
		FROM
			@ENTRY E
			INNER JOIN EMP_TIME_DTL_CMTS C ON E.ET_ID = C.ET_ID AND E.ETD_ID = C.ET_DTL_ID
		WHERE
			C.ET_SOURCE = @TIME_TYPE;
	END
	ELSE
	BEGIN
		INSERT INTO @ENTRY (ET_ID, ETD_ID) VALUES (@CURR_ET_ID, @CURR_ETD_ID);
	END

	RETURN;

/*=========== QUERY ===========*/
END
