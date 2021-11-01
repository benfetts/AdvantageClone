IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_load_agile_boards]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_load_agile_boards]
GO

CREATE PROCEDURE [dbo].[advsp_agile_load_agile_boards]
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@FOR_JOB_ADD BIT,
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
BEGIN
	--	VARIABLES
	BEGIN
		DECLARE @BOARDS TABLE (
		   [ID] INT,
		   [Name] VARCHAR(50),
		   [Description] VARCHAR(MAX),
		   [BoardOwnerEmployeeCode] VARCHAR(6),
		   [BoardHeaderID] INT,
		   [OfficeCode] VARCHAR(4),
		   [CreatedByUserCode] VARCHAR(100),
		   [CreatedDate] SMALLDATETIME,
		   [CompletedDate] SMALLDATETIME,
		   [IsActive] BIT,
		   [BoardOwnerFullName] VARCHAR(2000),
		   [OfficeName] VARCHAR(2000),
		   [SprintCount] INT,
		   [JobIsOnBoard] BIT
		)

		DECLARE
			@EMP_CODE VARCHAR(6),
			@OFFICE_COUNT INT,
			@SELECTED_JOB_NUMBER INT,
			@SELECTED_JOB_COMPONENT_NBR SMALLINT
	END
	--	INIT
	BEGIN
		SET @EMP_CODE = (SELECT TOP 1 EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@USER_CODE));

		SELECT @OFFICE_COUNT = COUNT(1) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;


		IF ISNULL(@FOR_JOB_ADD, 0) = 1
		BEGIN
			SELECT
				@SELECTED_JOB_NUMBER = @JOB_NUMBER,
				@SELECTED_JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
			SELECT
				@JOB_NUMBER = NULL,
				@JOB_COMPONENT_NBR = NULL;
		END
	END
	--	DATA
	BEGIN
		INSERT INTO @BOARDS (ID, [Name], [Description], BoardOwnerEmployeeCode, BoardHeaderID, OfficeCode, CreatedByUserCode, CreatedDate, CompletedDate, IsActive, BoardOwnerFullName, OfficeName, SprintCount)
		SELECT DISTINCT A.*
		FROM
		(
			SELECT
				BOARD.ID,
				BOARD.[NAME] AS Name,
				BOARD.[DESCRIPTION] AS Description,
				BOARD.BOARD_OWNER_EMP_CODE AS BoardOwnerEmployeeCode,
				BOARD.BOARD_HDR_ID AS BoardHeaderID,
				BOARD.OFFICE_CODE AS OfficeCode,
				BOARD.CREATE_USER AS CreatedByUserCode,
				BOARD.CREATE_DATE AS CreatedDate,
				BOARD.COMPLETED_DATE AS CompletedDate,
				BOARD.IS_ACTIVE AS IsActive,
				ISNULL(E.EMP_FNAME+' ', '')+ISNULL(E.EMP_MI+'. ', '')+ISNULL(E.EMP_LNAME, '') AS BoardOwnerFullName,
				O.OFFICE_NAME AS OfficeName,
				COUNT(SH.ID) AS SprintCount
			FROM 
				BOARD WITH(NOLOCK)
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON BOARD.BOARD_OWNER_EMP_CODE = E.EMP_CODE
				INNER JOIN OFFICE O WITH(NOLOCK) ON O.OFFICE_CODE = BOARD.OFFICE_CODE
				LEFT OUTER JOIN SPRINT_HDR SH WITH(NOLOCK) ON BOARD.ID = SH.BOARD_ID
			GROUP BY
				BOARD.ID,
				BOARD.NAME,
				BOARD.[DESCRIPTION],
				BOARD.BOARD_OWNER_EMP_CODE,
				BOARD.BOARD_HDR_ID,
				BOARD.OFFICE_CODE,
				BOARD.CREATE_USER,
				BOARD.CREATE_DATE,
				BOARD.COMPLETED_DATE,
				BOARD.IS_ACTIVE,
				ISNULL(E.EMP_FNAME+' ', '')+ISNULL(E.EMP_MI+'. ', '')+ISNULL(E.EMP_LNAME, ''),
				O.OFFICE_NAME 
		) AS A
		LEFT OUTER JOIN BOARD_JOB BJ ON A.ID = BJ.BOARD_ID
		WHERE
		1 =	CASE
				WHEN @JOB_NUMBER IS NULL OR @JOB_NUMBER = 0 THEN 1
				WHEN BJ.JOB_NUMBER = @JOB_NUMBER THEN 1
				ELSE 0
			END
		AND
		1 = CASE
				WHEN @JOB_COMPONENT_NBR IS NULL OR @JOB_COMPONENT_NBR = 0 THEN 1
				WHEN BJ.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR THEN 1
				ELSE 0
			END
		;
	END
	--	FOR PMD
	BEGIN
		DELETE @BOARDS
		FROM
			BOARD B WITH(NOLOCK)
			INNER JOIN @BOARDS BB ON B.BOARD_HDR_ID = BB.BoardHeaderID
		WHERE
			B.IS_ACTIVE = 0
		;
		UPDATE @BOARDS SET JobIsOnBoard = 1 
		FROM
			BOARD_JOB BJ WITH(NOLOCK)
			INNER JOIN @BOARDS BB ON BB.ID = BJ.BOARD_ID
			INNER JOIN BOARD B WITH(NOLOCK) ON BJ.BOARD_ID = BJ.BOARD_ID
		WHERE
			BJ.JOB_NUMBER = @SELECTED_JOB_NUMBER
			AND BJ.JOB_COMPONENT_NBR = @SELECTED_JOB_COMPONENT_NBR;
		UPDATE @BOARDS SET IsActive = 1
		FROM
			BOARD B WITH(NOLOCK)
			INNER JOIN @BOARDS BB ON B.ID = BB.ID
		WHERE
			B.IS_ACTIVE = 1;
		;
	END
	--	RETURN
	BEGIN
		IF @OFFICE_COUNT = 0
		BEGIN
			SELECT 
				B.ID,
				B.[Name],
				B.[Description],
				B.BoardOwnerEmployeeCode,
				B.BoardOwnerFullName,
				B.BoardHeaderID,
				B.OfficeCode,
				B.OfficeName,
				B.CreatedByUserCode,
				B.CreatedDate,
				B.CompletedDate,
				[IsActive] = ISNULL(B.IsActive, 0),
				B.SprintCount,
				[JobIsOnBoard] = ISNULL(B.JobIsOnBoard, 0)
			FROM 
				@BOARDS B;
		END
		ELSE
		BEGIN		
			SELECT 
				B.ID,
				B.[Name],
				B.[Description],
				B.BoardOwnerEmployeeCode,
				B.BoardOwnerFullName,
				B.BoardHeaderID,
				B.OfficeCode,
				B.OfficeName,
				B.CreatedByUserCode,
				B.CreatedDate,
				B.CompletedDate,
				[IsActive] = ISNULL(B.IsActive, 0),
				B.SprintCount,
				[JobIsOnBoard] = ISNULL(B.JobIsOnBoard, 0)
			FROM 
				@BOARDS B
				INNER JOIN EMP_OFFICE EO WITH(NOLOCK) ON B.OfficeCode = EO.OFFICE_CODE
			WHERE
				EO.EMP_CODE = @EMP_CODE;
		END
	END
END
/*=========== QUERY ===========*/
