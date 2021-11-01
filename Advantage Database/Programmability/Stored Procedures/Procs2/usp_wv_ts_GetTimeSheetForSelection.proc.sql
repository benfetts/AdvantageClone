
/* BJL 060625 - Commented out PK_TIME_ROWS, per Scott */
/* BJL 060625 - Fixed dept/team in last SELECT */

CREATE PROCEDURE [dbo].[usp_wv_ts_GetTimeSheetForSelection]
@emp_code   VARCHAR(6),
@StartDate  SMALLDATETIME,
@EndDate    SMALLDATETIME
AS
	/* Temporary table to store returned rows */
	CREATE TABLE #time_rows
	(
		ET_ID              INT NOT NULL,
		ET_DTL_ID          INT NOT NULL,
		FNC_CAT            VARCHAR(10) NULL,
		EMP_HOURS          DECIMAL(9, 3) NOT NULL,
		CL_CODE            VARCHAR(6) NULL,
		DIV_CODE           VARCHAR(6) NULL,
		PRD_CODE           VARCHAR(6) NULL,
		JOB_NUMBER         INT NULL,
		CLIENT_REF         VARCHAR(30) NULL,
		JOB_COMPONENT_NBR  SMALLINT NULL,
		DP_TM_CODE         VARCHAR(4) NULL,
		TIME_TYPE          CHAR(1) NOT NULL,
		EDIT_FLAG          SMALLINT NOT NULL,
		MAX_SEQ            SMALLINT NULL,
		START_TIME         CHAR(4) NULL,
		END_TIME           CHAR(4) NULL,
		EMP_DATE           SMALLDATETIME,
		COMMENTS           TEXT NULL,
		PROD_CAT_CODE      VARCHAR(10) NULL,
		IS_TIME_CAT        BIT
	)


	/* ALTER TABLE [dbo].[#time_rows] WITH NOCHECK ADD 
		CONSTRAINT [PK_time_rows] PRIMARY KEY  CLUSTERED 
		(
			[ET_ID], [ET_DTL_ID]
		)  ON [PRIMARY] */


	INSERT INTO #time_rows
	SELECT etd.ET_ID,
			etd.ET_DTL_ID,
			NULL,
			SUM(EMP_HOURS),
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			'D',
			0,
			MAX(SEQ_NBR),
			NULL,
			NULL,
			EMP_DATE,
			NULL,
			NULL,
			NULL
	FROM   EMP_TIME_DTL AS etd WITH (NOLOCK),
			EMP_TIME AS et WITH (NOLOCK)
	WHERE  et.ET_ID = etd.ET_ID
			AND EMP_CODE = @emp_code
			AND EMP_DATE >= @StartDate
			AND EMP_DATE <= @EndDate
	GROUP BY
			etd.ET_ID,
			etd.ET_DTL_ID,
			EMP_DATE

	UPDATE #time_rows
	SET    FNC_CAT = etd.FNC_CODE,
			CL_CODE = jl.CL_CODE,
			DIV_CODE = jl.DIV_CODE,
			PRD_CODE = jl.PRD_CODE,
			CLIENT_REF = jl.JOB_CLI_REF,
			JOB_NUMBER = etd.JOB_NUMBER,
			JOB_COMPONENT_NBR = etd.JOB_COMPONENT_NBR,
			DP_TM_CODE = etd.DP_TM_CODE,
			IS_TIME_CAT = 0
	FROM   EMP_TIME_DTL AS etd WITH (NOLOCK),
			JOB_LOG AS jl WITH (NOLOCK),
			#time_rows tr
	WHERE  tr.ET_ID = etd.ET_ID
			AND tr.ET_DTL_ID = etd.ET_DTL_ID
			AND tr.MAX_SEQ = etd.SEQ_NBR
			AND etd.JOB_NUMBER = jl.JOB_NUMBER

	INSERT INTO #time_rows
	SELECT etn.ET_ID,
			etn.ET_DTL_ID,
			CATEGORY,
			SUM(EMP_HOURS),
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			DP_TM_CODE,
			'N',
			0,
			NULL,
			NULL,
			NULL,
			EMP_DATE,
			NULL,
			NULL,
			1
	FROM   EMP_TIME_NP AS etn WITH (NOLOCK),
			EMP_TIME AS et WITH (NOLOCK)
	WHERE  et.ET_ID = etn.ET_ID
			AND EMP_CODE = @emp_code
			AND EMP_DATE >= @StartDate
			AND EMP_DATE <= @EndDate
	GROUP BY
			etn.ET_ID,
			etn.ET_DTL_ID,
			CATEGORY,
			DP_TM_CODE,
			EMP_DATE

	--Get Comments
	UPDATE #time_rows
	SET    COMMENTS = ct.EMP_COMMENT
	FROM   EMP_TIME_DTL_CMTS AS ct WITH (NOLOCK),
			#time_rows tr
	WHERE  tr.ET_ID = ct.ET_ID
			AND tr.ET_DTL_ID = ct.ET_DTL_ID

	UPDATE #time_rows
	SET    PROD_CAT_CODE = etd.PROD_CAT_CODE
	FROM   EMP_TIME_DTL AS etd WITH (NOLOCK),
			#time_rows tr
	WHERE  tr.ET_ID = etd.ET_ID
			AND tr.ET_DTL_ID = etd.ET_DTL_ID
 
	-- BJL - 11/23/03
	UPDATE #time_rows
	SET    START_TIME = etdc.START_TIME,
			END_TIME = etdc.END_TIME
	FROM   EMP_TIME_DTL_CMTS AS etdc WITH (NOLOCK),
			#time_rows tr
	WHERE  tr.ET_ID = etdc.ET_ID
			AND tr.ET_DTL_ID = etdc.ET_DTL_ID

	-- Determine if rows have been billed
	UPDATE #time_rows
	SET    EDIT_FLAG = 1
	WHERE  EXISTS (
				SELECT etd.AR_INV_NBR
				FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
				WHERE  etd.ET_ID = #time_rows.ET_ID
						AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
						AND etd.AR_INV_NBR IS NOT NULL
			)

	-- Determine if item is summarized
	UPDATE #time_rows
	SET    EDIT_FLAG = 2
	WHERE  EDIT_FLAG = 0
			AND (
					SELECT COUNT(*)
					FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					WHERE  etd.ET_ID = #time_rows.ET_ID
							AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
				) > 1
	
	-- Determine if item is a restricted AB flag
	UPDATE #time_rows
	SET    EDIT_FLAG = 3
	WHERE  EDIT_FLAG = 0
			AND EXISTS (
					SELECT AB_FLAG
					FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					WHERE  etd.ET_ID = #time_rows.ET_ID
							AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
							AND etd.AB_FLAG IN (1, 3)
				)

	-- Determine if item is selected for billing
	UPDATE #time_rows
	SET    EDIT_FLAG = 4
	WHERE  EDIT_FLAG = 0
			AND EXISTS (
					SELECT BILLING_USER
					FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					WHERE  etd.ET_ID = #time_rows.ET_ID
							AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
							AND BILLING_USER IS NOT NULL
				)

	-- Check agency and employee approval req flag	   
	DECLARE 
	@TIME_APPR_ACTIVE SMALLINT
	
	SELECT @TIME_APPR_ACTIVE = ISNULL(TIME_APPR_ACTIVE,0) 
	FROM AGENCY WITH(NOLOCK);
	
	SET @TIME_APPR_ACTIVE = ISNULL(@TIME_APPR_ACTIVE,0);
		
	IF @TIME_APPR_ACTIVE = 1 AND (NOT @emp_code IS NULL)
	BEGIN
		
		SELECT @TIME_APPR_ACTIVE = ISNULL(TS_APPR_FLAG, 0)
		FROM EMPLOYEE WITH(NOLOCK) 
		WHERE EMP_CODE = @emp_code;

		--THE EMP TABLE FLAG ACTS AS AN EXEMPTION; NOT INCLUSION
		IF @TIME_APPR_ACTIVE = 1
		BEGIN
			SET @TIME_APPR_ACTIVE = 0
		END
		ELSE
		BEGIN
			SET @TIME_APPR_ACTIVE = 1
		END
				
	END
	
	SET @TIME_APPR_ACTIVE = ISNULL(@TIME_APPR_ACTIVE,0);

	IF @TIME_APPR_ACTIVE = 1
	BEGIN	

		-- BJL - 11/23/03
		-- Check if row has been approved
		UPDATE #time_rows
		SET    EDIT_FLAG = 6
		WHERE  EDIT_FLAG = 0
				AND EXISTS (
						SELECT ET_ID
						FROM   EMP_TIME AS et WITH (NOLOCK)
						WHERE  et.ET_ID = #time_rows.ET_ID
								AND APPR_FLAG = 1
					);

		-- BJL - 11/23/03
		-- Check if row is pending approval
		UPDATE #time_rows
		SET    EDIT_FLAG = 5
		WHERE  EDIT_FLAG = 0
				AND EXISTS (
						SELECT ET_ID
						FROM   EMP_TIME AS et WITH (NOLOCK)
						WHERE  et.ET_ID = #time_rows.ET_ID
								AND APPR_PENDING = 1
					);

	END



	DELETE 
	FROM   #time_rows
	WHERE  IS_TIME_CAT = 0
			AND FNC_CAT COLLATE database_default IN (SELECT FNC_CODE COLLATE database_default
													FROM   FUNCTIONS WITH (NOLOCK)
													WHERE  (FNC_INACTIVE = 1))
 
	DELETE 
	FROM   #time_rows
	WHERE  IS_TIME_CAT = 1
			AND FNC_CAT COLLATE database_default IN (SELECT CATEGORY COLLATE database_default
													FROM   TIME_CATEGORY WITH (NOLOCK)
													WHERE  (INACTIVE_FLAG = 1)) 
           
           
				end_tran:

	SELECT ISNULL(#time_rows.ET_ID, '') AS ET_ID,	--0
			ISNULL(#time_rows.ET_DTL_ID, '') AS ET_DTL_ID,
			ISNULL(#time_rows.FNC_CAT, '') AS FNC_CAT,
			ISNULL(#time_rows.EMP_HOURS, '') AS EMP_HOURS,
			ISNULL(#time_rows.CL_CODE, '') AS CL_CODE,
			ISNULL(#time_rows.DIV_CODE, '') AS DIV_CODE,
			ISNULL(#time_rows.PRD_CODE, '') AS PRD_CODE,
			ISNULL(#time_rows.JOB_NUMBER, '') AS JOB_NUMBER,
			ISNULL(#time_rows.CLIENT_REF, '') AS CLIENT_REF,
			ISNULL(#time_rows.JOB_COMPONENT_NBR, '') AS JOB_COMPONENT_NBR,
			ISNULL(#time_rows.DP_TM_CODE, '') AS DP_TM_CODE,	--10
			ISNULL(#time_rows.TIME_TYPE, '') AS TIME_TYPE,
			ISNULL(#time_rows.EDIT_FLAG, '') AS EDIT_FLAG,
			ISNULL(#time_rows.MAX_SEQ, '') AS MAX_SEQ,
			ISNULL(#time_rows.START_TIME, '') AS START_TIME,
			ISNULL(#time_rows.END_TIME, '') AS END_TIME,
			ISNULL(#time_rows.EMP_DATE, '') AS EMP_DATE,
			ISNULL(#time_rows.COMMENTS, '') AS COMMENTS,
			ISNULL(LTRIM(STR(#time_rows.JOB_NUMBER)), '-') AS JOB,
			ISNULL(JOB_LOG.JOB_DESC, '') AS JobDesc,
			ISNULL(LTRIM(STR(#time_rows.JOB_COMPONENT_NBR)), '-') AS JobComp,	--20
			CASE 
				WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2) THEN '<span class="warning">' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') + '</span>'
				ELSE ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '')
			END AS JobCompDesc,
			ISNULL(LTRIM(STR(#time_rows.JOB_NUMBER)), '') + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS JOB_DESC,
			ISNULL(LTRIM(STR(#time_rows.JOB_COMPONENT_NBR)), '') + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') AS JOB_COMP_DESC,
			ISNULL(#time_rows.PROD_CAT_CODE, '') AS PROD_CAT_CODE,
			ISNULL(CLIENT.CL_NAME, '') AS CL_NAME,
			ISNULL(DIVISION.DIV_NAME, '') AS DIV_NAME,
			ISNULL(PRODUCT.PRD_DESCRIPTION, '') AS PRD_DESCRIPTION,
			#time_rows.IS_TIME_CAT
	FROM   #time_rows
			LEFT OUTER JOIN JOB_LOG WITH (NOLOCK)
				ON  #time_rows.JOB_NUMBER = JOB_LOG.JOB_NUMBER
			LEFT OUTER JOIN JOB_COMPONENT WITH (NOLOCK)
				ON  #time_rows.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				AND #time_rows.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
					/* added for tooltip */
			LEFT OUTER JOIN PRODUCT WITH (NOLOCK)
				ON  #time_rows.CL_CODE COLLATE database_default = PRODUCT.CL_CODE COLLATE database_default
				AND #time_rows.DIV_CODE COLLATE database_default = PRODUCT.DIV_CODE COLLATE database_default
				AND #time_rows.PRD_CODE COLLATE database_default = PRODUCT.PRD_CODE COLLATE database_default
			LEFT OUTER JOIN DIVISION WITH (NOLOCK)
				ON  #time_rows.CL_CODE COLLATE database_default = DIVISION.CL_CODE COLLATE database_default
				AND #time_rows.DIV_CODE COLLATE database_default = DIVISION.DIV_CODE COLLATE database_default
			LEFT OUTER JOIN CLIENT WITH (NOLOCK)
				ON  #time_rows.CL_CODE COLLATE database_default = CLIENT.CL_CODE COLLATE database_default
	WHERE  (
				NOT (
					JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2)
				)
			)
			OR  (JOB_COMPONENT.JOB_PROCESS_CONTRL IS NULL)
	ORDER BY
			#time_rows.CL_CODE,
			#time_rows.DIV_CODE,
			#time_rows.PRD_CODE,
			#time_rows.JOB_NUMBER,
			#time_rows.JOB_COMPONENT_NBR,
			#time_rows.FNC_CAT,
			#time_rows.DP_TM_CODE;


	DROP TABLE #time_rows;

