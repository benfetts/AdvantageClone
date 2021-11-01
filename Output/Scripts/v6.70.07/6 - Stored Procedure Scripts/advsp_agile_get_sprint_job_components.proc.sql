IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_get_sprint_job_components]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_get_sprint_job_components]
GO
CREATE PROCEDURE [dbo].[advsp_agile_get_sprint_job_components] 
@SPRINT_ID INT,
@USER_CODE VARCHAR(100),
@LEVEL SMALLINT
AS
/*=========== QUERY ===========*/
BEGIN
	-- VARS
	BEGIN
		DECLARE @RESULTS TABLE ([OfficeCode] VARCHAR (4),
								[OfficeName] VARCHAR (30),
								[ClientCode] VARCHAR (6),
								[ClientName] VARCHAR (40),
								[DivisionCode] VARCHAR (6),
								[DivisionName] VARCHAR (40),
								[ProductCode] VARCHAR (6),
								[ProductName] VARCHAR (40),
								[JobNumber] INT,
								[JobDescription] VARCHAR (60),
								[JobComponentNumber] SMALLINT,
								[JobComponentDescription] VARCHAR (60),
								[HasSchedule] BIT,
								[Text] VARCHAR (300));

		DECLARE 
			@ALL_JOBS BIT
		;
	END
	-- INIT
	BEGIN
		IF @SPRINT_ID IS NULL OR @SPRINT_ID = 0
		BEGIN
			SET @ALL_JOBS = 1;
		END
		ELSE
		BEGIN
			SELECT @ALL_JOBS = CAST(ISNULL(B.INCL_ALL_JOBS, 0) AS BIT) FROM SPRINT_HDR SH INNER JOIN BOARD B ON SH.BOARD_ID = B.ID WHERE SH.ID = @SPRINT_ID;
		END
		SET @LEVEL = ISNULL(@LEVEL, 0);
	END
	-- GET DATA
	BEGIN
	IF @ALL_JOBS = 0
		BEGIN
			INSERT INTO @RESULTS (OfficeCode, 
								  OfficeName, 
								  ClientCode, 
								  ClientName, 
								  DivisionCode, 
								  DivisionName, 
								  ProductCode, 
								  ProductName, 
								  JobNumber, 
								  JobDescription, 
								  JobComponentNumber, 
								  JobComponentDescription, 
								  HasSchedule)
			SELECT
				JOB_LOG.OFFICE_CODE,
				O.OFFICE_NAME, 
				JOB_LOG.CL_CODE,
				CLIENT.CL_NAME,
				JOB_LOG.DIV_CODE,
				DIVISION.DIV_NAME,
				JOB_LOG.PRD_CODE,
				PRODUCT.PRD_DESCRIPTION,
				JOB_LOG.JOB_NUMBER,
				JOB_LOG.JOB_DESC,
				JOB_COMPONENT.JOB_COMPONENT_NBR,
				JOB_COMPONENT.JOB_COMP_DESC,
				CONVERT(BIT, CASE WHEN JOB_TRAFFIC.JOB_NUMBER IS NOT NULL THEN 1 ELSE 0 END)
			FROM
				SPRINT_HDR 
			INNER JOIN
				BOARD ON SPRINT_HDR.BOARD_ID = BOARD.ID
			INNER JOIN
				BOARD_JOB ON BOARD.ID = BOARD_JOB.BOARD_ID
			INNER JOIN
				JOB_LOG ON BOARD_JOB.JOB_NUMBER = JOB_LOG.JOB_NUMBER
			INNER JOIN
				JOB_COMPONENT ON BOARD_JOB.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND
									BOARD_JOB.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
			INNER JOIN
				CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE 
			INNER JOIN
				DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND
								JOB_LOG.DIV_CODE = DIVISION.DIV_CODE 
			INNER JOIN
				PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND
							  JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND
							  JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE
			LEFT OUTER JOIN
				JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND
								  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
			LEFT OUTER JOIN
				OFFICE O ON JOB_LOG.OFFICE_CODE = O.OFFICE_CODE
			WHERE
				SPRINT_HDR.ID = @SPRINT_ID
			ORDER BY
				JOB_COMPONENT.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC;
		END
		ELSE
		BEGIN
		   DECLARE @EMP_CODE VARCHAR(6), @OFFICE_RESTRICTION_COUNT AS INT
		   SET @OFFICE_RESTRICTION_COUNT = 0;
		   SET @EMP_CODE = (SELECT TOP 1 EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@USER_CODE));
		   IF DATALENGTH(@EMP_CODE) > 0
		   BEGIN
			  SELECT @OFFICE_RESTRICTION_COUNT = COUNT(1) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;
		   END
		   IF @OFFICE_RESTRICTION_COUNT IS NULL OR @OFFICE_RESTRICTION_COUNT = 0
		   BEGIN
			INSERT INTO @RESULTS (OfficeCode, 
								  OfficeName, 
								  ClientCode, 
								  ClientName, 
								  DivisionCode, 
								  DivisionName, 
								  ProductCode, 
								  ProductName, 
								  JobNumber, 
								  JobDescription, 
								  JobComponentNumber, 
								  JobComponentDescription, 
								  HasSchedule)
			   SELECT
					JOB_LOG.OFFICE_CODE,
					O.OFFICE_NAME, 
					JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
					CONVERT(BIT, CASE WHEN JOB_TRAFFIC.JOB_NUMBER IS NOT NULL THEN 1 ELSE 0 END)
			   FROM
				   JOB_COMPONENT INNER JOIN  JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
			   INNER JOIN
				   CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE 
			   INNER JOIN
				   DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND
								   JOB_LOG.DIV_CODE = DIVISION.DIV_CODE 
			   INNER JOIN
				   PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND
								 JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND
								 JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE
			   LEFT OUTER JOIN
				   JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND
									 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
			   LEFT OUTER JOIN
				   OFFICE O ON JOB_LOG.OFFICE_CODE = O.OFFICE_CODE
			   WHERE
				 JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)
			   ORDER BY
				 JOB_COMPONENT.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC;
		   END
		   ELSE
		   BEGIN
			INSERT INTO @RESULTS (OfficeCode, 
								  OfficeName, 
								  ClientCode, 
								  ClientName, 
								  DivisionCode, 
								  DivisionName, 
								  ProductCode, 
								  ProductName, 
								  JobNumber, 
								  JobDescription, 
								  JobComponentNumber, 
								  JobComponentDescription, 
								  HasSchedule)
			   SELECT
					JOB_LOG.OFFICE_CODE,
					O.OFFICE_NAME, 
					JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
					CONVERT(BIT, CASE WHEN JOB_TRAFFIC.JOB_NUMBER IS NOT NULL THEN 1 ELSE 0 END)
			   FROM
				   JOB_COMPONENT 
			   INNER JOIN  JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
			   INNER JOIN EMP_OFFICE EO ON JOB_LOG.OFFICE_CODE = EO.OFFICE_CODE
			   INNER JOIN OFFICE O ON O.OFFICE_CODE = EO.OFFICE_CODE
			   INNER JOIN
				   CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE 
			   INNER JOIN
				   DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND
								   JOB_LOG.DIV_CODE = DIVISION.DIV_CODE 
			   INNER JOIN
				   PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND
								 JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND
								 JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE
			   LEFT OUTER JOIN
				   JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND
									 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR

			   WHERE
				 JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)
				 AND EO.EMP_CODE = @EMP_CODE
			   ORDER BY
				 JOB_COMPONENT.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC;
		   END
		END
	END
	-- RETURN DATA
	BEGIN
		IF @LEVEL = 0 --  COMPONENT
		BEGIN
			SELECT 
				[OfficeCode],
				[OfficeName],
				[ClientCode],
				[ClientName],
				[DivisionCode],
				[DivisionName],
				[ProductCode],
				[ProductName],
				[JobNumber],
				[JobDescription],
				[JobComponentNumber],
				[JobComponentDescription],
				[HasSchedule],
				[Text] = RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), R.JobComponentNumber), 3) + ' - ' + R.JobComponentDescription		
			FROM
				@RESULTS R
			ORDER BY
				R.JobNumber DESC, R.JobComponentNumber ASC;
		END
		IF @LEVEL = 1 --  JOB
		BEGIN
			SELECT DISTINCT
				[OfficeCode],
				[OfficeName],
				[ClientCode],
				[ClientName],
				[DivisionCode],
				[DivisionName],
				[ProductCode],
				[ProductName],
				[JobNumber],
				[JobDescription],
				[Text] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), R.JobNumber), 6) + ' - ' + R.JobDescription		
			FROM
				@RESULTS R
			ORDER BY
				R.JobNumber DESC;
		END
		IF @LEVEL = 2 --  PRODUCT
		BEGIN
			SELECT DISTINCT
				[OfficeCode],
				[OfficeName],
				[ClientCode],
				[ClientName],
				[DivisionCode],
				[DivisionName],
				[ProductCode],
				[ProductName],
				[Text] = R.ProductName
			FROM
				@RESULTS R
			ORDER BY
				R.ClientName, R.DivisionName, R.ProductName;
		END
		IF @LEVEL = 3 --  DIVISION
		BEGIN
			SELECT DISTINCT
				[OfficeCode],
				[OfficeName],
				[ClientCode],
				[ClientName],
				[DivisionCode],
				[DivisionName],
				[Text] = R.DivisionName
			FROM
				@RESULTS R
			ORDER BY
				R.ClientName, R.DivisionName;
		END
		IF @LEVEL = 4 --  CLIENT
		BEGIN
			SELECT DISTINCT
				[OfficeCode],
				[OfficeName],
				[ClientCode],
				[ClientName],
				[Text] = R.ClientName
			FROM
				@RESULTS R
			ORDER BY
				R.ClientName;
		END
		IF @LEVEL = 5 --  OFFICE
		BEGIN
			SELECT DISTINCT
				[OfficeCode],
				[OfficeName],
				[Text] = R.OfficeName
			FROM
				@RESULTS R
			ORDER BY
				R.OfficeName;
		END
	END

END
/*=========== QUERY ===========*/