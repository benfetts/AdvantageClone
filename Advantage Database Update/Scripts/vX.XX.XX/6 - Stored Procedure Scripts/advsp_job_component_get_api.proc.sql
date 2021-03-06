
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_component_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_component_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_job_component_get_api] 
	@LoadClosed bit = 1,
	@JobNumberIn int = 0,
	@JobComponentNumberIn smallint = 0

AS

--DECLARE
--	@LoadClosed bit = 1,
--	@JobNumberIn int = 0,
--	@JobComponentNumberIn smallint = 0

/*
PJH 04/17/21 - Added PROCESS_DATE FROM JOB_PROCESS_LOG
*/

DECLARE @job_comp TABLE (
		ClientCode varchar(6),  
		ClientName varchar(40), 
		DivisionCode varchar(6),
		DivisionName varchar(40), 
		ProductCode varchar(6), 
		ProductDescription varchar(40), 
		JobNumber int, 
		JobDescription varchar(60), 
		JobComponentNumber smallint, 
		JobComponentDescription varchar(60),
		OfficeCode varchar(4), 
		OfficeName varchar(30),
		IsOpen int,
		JobProcessControl smallint,
		JobProcessDescription varchar(40),
		CampaignID int,
		CampaignName varchar(128),
		CreateDate smalldatetime,
		FiscalPeriod varchar(6),
		FiscalPeriodDescription varchar(30), 
		JobType varchar(10),
		JobTypeDescription varchar(30), 
		SalesClass varchar(6),
		AccountExecutive varchar(80),
		ClientPO varchar(40),
		UdvLabel1 varchar(20),
		UdvDesc1 varchar(40),
		UdvLabel2 varchar(20),
		UdvDesc2 varchar(40),
		UdvLabel3 varchar(20),
		UdvDesc3 varchar(40),
		UdvLabel4 varchar(20),
		UdvDesc4 varchar(40),
		UdvLabel5 varchar(20),
		UdvDesc5 varchar(40),
		UdvCode1 varchar(10),
		UdvCode2 varchar(10),
		UdvCode3 varchar(10),
		UdvCode4 varchar(10),
		UdvCode5 varchar(10),
		ProjectManager varchar (80),
		JobComponentComments varchar(max),
		ID integer,
		ModifiedDate smalldatetime,
		ModifiedBy varchar(100),
		JobComponentBudget decimal(14,2),
		LastStatusDate smalldatetime,
		JobCreatedBy varchar(100),
		JobCreateDate smalldatetime
)

SET @LoadClosed = COALESCE(@LoadClosed,0)  
SET @JobNumberIn = COALESCE(@JobNumberIn,0)  
SET @JobComponentNumberIn = COALESCE(@JobComponentNumberIn,0)  

INSERT INTO @job_comp
	SELECT 
		JL.CL_CODE,  
		CLIENT.CL_NAME, 
		JL.DIV_CODE,
		DIV.DIV_NAME, 
		JL.PRD_CODE, 
		PRD.PRD_DESCRIPTION, 
		JL.JOB_NUMBER, 
		JL.JOB_DESC, 
		JC.JOB_COMPONENT_NBR,
		JC.JOB_COMP_DESC, 
		JL.OFFICE_CODE, 
		OFFICE.OFFICE_NAME,
		COMP_OPEN = ISNULL(JO.IS_OPEN, 0),
		JC.JOB_PROCESS_CONTRL,
		JPC.JOB_PROCESS_DESC,
		JL.CMP_IDENTIFIER,
		CMP.CMP_NAME,
		JC.JOB_COMP_DATE,
		JC.FISCAL_PERIOD_CODE,
		FP.FISCAL_PERIOD_DESC,
		JC.JT_CODE,
		JT.JT_DESC,
		JL.SC_CODE,
		COALESCE(EMP.EMP_FNAME, '') + ' ' + COALESCE(EMP.EMP_MI, '') + CASE WHEN EMP.EMP_MI IS NULL THEN '' ELSE ' ' END + COALESCE(EMP.EMP_LNAME, '') 'Account Executive',
		JC.JOB_CL_PO_NBR,
		NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,
		JC.UDV1_CODE, JC.UDV2_CODE, JC.UDV3_CODE, JC.UDV4_CODE, JC.UDV5_CODE,
		NULL,
		JC.JOB_COMP_COMMENTS,
		JC.ROWID,
		JC.MODIFY_DATE,
		JC.MODIFIED_BY,
		JC.JOB_COMP_BUDGET_AM,
		JPL.LAST_STATUS_DATE,
		JL.[USER_ID],
		JL.CREATE_DATE
	FROM 
		JOB_COMPONENT JC INNER JOIN
		JOB_LOG JL ON JC.JOB_NUMBER = JL.JOB_NUMBER JOIN
		CLIENT ON JL.CL_CODE = CLIENT.CL_CODE JOIN
		PRODUCT PRD ON JL.CL_CODE = PRD.CL_CODE AND JL.DIV_CODE = PRD.DIV_CODE AND JL.PRD_CODE = PRD.PRD_CODE JOIN
		DIVISION DIV ON JL.CL_CODE = DIV.CL_CODE AND JL.DIV_CODE = DIV.DIV_CODE LEFT JOIN
		OFFICE ON JL.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT JOIN
		FISCAL_PERIOD FP ON JC.FISCAL_PERIOD_CODE = FP.FISCAL_PERIOD_CODE LEFT JOIN
		JOB_TYPE JT ON JC.JT_CODE = JT.JT_CODE LEFT JOIN
		CAMPAIGN CMP ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER LEFT JOIN
		EMPLOYEE EMP ON JC.EMP_CODE = EMP.EMP_CODE LEFT JOIN
		(SELECT JOB_NUMBER, JOB_COMPONENT_NBR, MAX(PROCESS_DATE) LAST_STATUS_DATE FROM JOB_PROCESS_LOG GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR) JPL ON JC.JOB_NUMBER = JPL.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JPL.JOB_COMPONENT_NBR JOIN
		JOB_PROC_CONTROLS JPC ON JC.JOB_PROCESS_CONTRL = JPC.JOB_PROCESS_CONTRL LEFT JOIN
		(SELECT 
			JOB_NUMBER, 
			IS_OPEN = MAX(CASE WHEN JOB_PROCESS_CONTRL <> 6 AND JOB_PROCESS_CONTRL <> 12 THEN 1 ELSE 0 END)
		FROM 
			JOB_COMPONENT 
		GROUP BY
			JOB_NUMBER) AS JO ON JO.JOB_NUMBER = JL.JOB_NUMBER
	WHERE (JC.JOB_NUMBER = @JobNumberIn OR @JobNumberIn = 0) AND
				(JC.JOB_COMPONENT_NBR = @JobComponentNumberIn OR @JobComponentNumberIn = 0)
	OPTION (RECOMPILE)

IF @@ROWCOUNT > 0 BEGIN

	/* Update user entered & lookup data */
	UPDATE A
	SET A.UdvLabel1 = B.UDV_LABEL, A.UdvDesc1 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_comp A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_CMP_UDV1 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_CMP_UDV1' AND COALESCE(UDV.INACTIVE_FLAG, 0) = 0) B ON A.UdvCode1 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel2 = B.UDV_LABEL, A.UdvDesc2 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_comp A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_CMP_UDV2 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_CMP_UDV2' AND COALESCE(UDV.INACTIVE_FLAG, 0) = 0) B ON A.UdvCode2 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel3 = B.UDV_LABEL, A.UdvDesc3 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_comp A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_CMP_UDV3 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_CMP_UDV3' AND COALESCE(UDV.INACTIVE_FLAG, 0) = 0) B ON A.UdvCode3 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel4 = B.UDV_LABEL, A.UdvDesc4 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_comp A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_CMP_UDV4 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_CMP_UDV4' AND COALESCE(UDV.INACTIVE_FLAG, 0) = 0) B ON A.UdvCode4 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel5 = B.UDV_LABEL, A.UdvDesc5 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_comp A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_CMP_UDV5 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_CMP_UDV5' AND COALESCE(UDV.INACTIVE_FLAG, 0) = 0) B ON A.UdvCode5 = B.UDV_CODE
	OPTION (RECOMPILE)


	DECLARE @level int

	SELECT @level =  CAST(RIGHT(CAST(AGY.AGY_SETTINGS_VALUE AS varchar(20)),1) AS int)
	FROM dbo.AGY_SETTINGS AS AGY
	WHERE (AGY.AGY_SETTINGS_GRP IS NULL) AND 
		(AGY.AGY_SETTINGS_APP = 0) AND (AGY.AGY_SETTINGS_TAB = 2) AND 
		(AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL')

	UPDATE A
	SET A.ProjectManager = COALESCE(EMP.EMP_FNAME, '') + ' ' + COALESCE(EMP.EMP_MI, '') + CASE WHEN EMP.EMP_MI IS NULL THEN '' ELSE ' ' END + COALESCE(EMP.EMP_LNAME, '')
	FROM @job_comp A INNER JOIN
		(SELECT JOB_NUMBER, JOB_COMPONENT_NBR, CASE @level 
			WHEN 1 THEN ASSIGN_1
			WHEN 2 THEN ASSIGN_2
			WHEN 3 THEN ASSIGN_3
			WHEN 4 THEN ASSIGN_4
			ELSE ASSIGN_5
		END AS EMP_CODE
		FROM JOB_TRAFFIC JTR) LVL ON A.JobNumber = LVL.JOB_NUMBER AND A.JobComponentNumber = LVL.JOB_COMPONENT_NBR INNER JOIN 
		EMPLOYEE EMP ON LVL.EMP_CODE = EMP.EMP_CODE
	OPTION (RECOMPILE)

END
--ELSE
--	INSERT INTO @job_comp (JobNumber, JobDescription, CreateDate, IsOpen, ID)
--		VALUES (0, 'No Matching Job/Component', '01/01/1900', 0, 0)

SELECT ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductDescription,
		JobNumber,
		JobDescription,
		JobComponentNumber,
		JobComponentDescription,
		OfficeCode,
		OfficeName,
		IsOpen,
		JobProcessControl,
		JobProcessDescription,
		CampaignID,
		CampaignName,
		CreateDate,
		FiscalPeriod,
		FiscalPeriodDescription,
		JobType,
		JobTypeDescription,
		SalesClass,
		AccountExecutive,
		ClientPO,
		UdvLabel1,
		UdvDesc1,
		UdvLabel2,
		UdvDesc2,
		UdvLabel3,
		UdvDesc3,
		UdvLabel4,
		UdvDesc4,
		UdvLabel5,
		UdvDesc5,
		ProjectManager,
		JobComponentComments,
		ID,
		ModifiedDate,
		ModifiedBy,
		JobComponentBudget,
		LastStatusDate,
		JobCreatedBy,
		JobCreateDate
FROM @job_comp
WHERE (IsOpen = 1 OR @LoadClosed = 1)
ORDER BY JobNumber, JobComponentNumber
OPTION (RECOMPILE)
GO

GRANT EXECUTE ON [advsp_job_component_get_api] TO PUBLIC AS dbo
GO