
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_log_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_log_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_job_log_get_api] 
	@LoadClosed bit = 1,
	@JobNumberIn int = 0

AS

--DECLARE
--	@LoadClosed bit = 1,
--	@JobNumberIn int = 0

DECLARE @job_log TABLE (
		ClientCode varchar(6),  
		ClientName varchar(40), 
		DivisionCode varchar(6),
		DivisionName varchar(40), 
		ProductCode varchar(6), 
		ProductDescription varchar(40), 
		JobNumber int, 
		JobDescription varchar(60), 
		OfficeCode varchar(4), 
		OfficeName varchar(30),
		IsOpen int,
		CampaignID int,
		CampaignName varchar(128),
		CreateDate smalldatetime,
		BillCoopCode varchar(6),
		JobClientReference varchar(30),
		SalesClass varchar(6),
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
		JobComments varchar(max),
		ModifiedDate smalldatetime,
		ModifiedBy varchar(100),
		CreatedBy varchar(100)
)

SET @LoadClosed = COALESCE(@LoadClosed,0)
SET @JobNumberIn = COALESCE(@JobNumberIn,0)  

INSERT INTO @job_log
	SELECT 
		JL.CL_CODE,  
		CL.CL_NAME, 
		JL.DIV_CODE,
		DIV.DIV_NAME, 
		JL.PRD_CODE, 
		PRD.PRD_DESCRIPTION, 
		JL.JOB_NUMBER, 
		JL.JOB_DESC, 
		JL.OFFICE_CODE, 
		[OFF].OFFICE_NAME,
		COMP_OPEN = ISNULL(JO.IS_OPEN, 0),
		JL.CMP_IDENTIFIER,
		CMP.CMP_NAME,
		JL.CREATE_DATE,
		JL.BILL_COOP_CODE,
		JL.JOB_CLI_REF, 
		JL.SC_CODE,
		NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,
		JL.UDV1_CODE, JL.UDV2_CODE, JL.UDV3_CODE, JL.UDV4_CODE, JL.UDV5_CODE,
		JOB_COMMENTS,
		MODIFY_DATE,
		MODIFIED_BY,
		JL.[USER_ID]
	FROM 
		JOB_LOG JL INNER JOIN
		CLIENT CL ON JL.CL_CODE = CL.CL_CODE INNER JOIN
		PRODUCT PRD ON JL.CL_CODE = PRD.CL_CODE AND JL.DIV_CODE = PRD.DIV_CODE AND JL.PRD_CODE = PRD.PRD_CODE INNER JOIN
		DIVISION DIV ON JL.CL_CODE = DIV.CL_CODE AND JL.DIV_CODE = DIV.DIV_CODE LEFT OUTER JOIN
		OFFICE [OFF] ON JL.OFFICE_CODE = [OFF].OFFICE_CODE LEFT OUTER JOIN
		CAMPAIGN CMP ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER LEFT OUTER JOIN
		(SELECT 
			JOB_NUMBER, 
			IS_OPEN = MAX(CASE WHEN JOB_PROCESS_CONTRL <> 6 AND JOB_PROCESS_CONTRL <> 12 THEN 1 ELSE 0 END)
		FROM 
			JOB_COMPONENT 
		GROUP BY
			JOB_NUMBER) AS JO ON JO.JOB_NUMBER = JL.JOB_NUMBER
	WHERE (JL.JOB_NUMBER = @JobNumberIn OR @JobNumberIn = 0)
	OPTION (RECOMPILE)

IF @@ROWCOUNT > 0 BEGIN

	/* Update user entered & lookup data */
	UPDATE A
	SET A.UdvLabel1 = B.UDV_LABEL, A.UdvDesc1 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_log A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_LOG_UDV1 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_LOG_UDV1' ) B ON A.UdvCode1 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel2 = B.UDV_LABEL, A.UdvDesc2 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_log A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_LOG_UDV2 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_LOG_UDV2' ) B ON A.UdvCode2 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel3 = B.UDV_LABEL, A.UdvDesc3 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_log A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_LOG_UDV3 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_LOG_UDV3' ) B ON A.UdvCode3 = B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel4 = B.UDV_LABEL, A.UdvDesc4 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_log A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_LOG_UDV4 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_LOG_UDV4' ) B ON A.UdvCode4= B.UDV_CODE
	OPTION (RECOMPILE)

	UPDATE A
	SET A.UdvLabel5 = B.UDV_LABEL, A.UdvDesc5 = CASE WHEN B.UDV_DESC = '' THEN NULL ELSE B.UDV_DESC END
	FROM @job_log A
		INNER JOIN
		(SELECT UDV.UDV_CODE, UDV.UDV_DESC, UL.USER_LABEL UDV_LABEL FROM UDV_LABEL UL
	LEFT JOIN JOB_LOG_UDV5 UDV ON UDV.UDV_CODE IS NOT NULL
	--WHERE COALESCE(UL.EDITABLE,0) = 0 AND 
	WHERE UL.UDV_TABLE_NAME = 'JOB_LOG_UDV5' ) B ON A.UdvCode5 = B.UDV_CODE
	OPTION (RECOMPILE)

END
--ELSE
--	INSERT INTO @job_log (JobNumber, JobDescription, IsOpen, CreateDate, ModifiedDate)
--		VALUES (0, 'No Matching Job', 1, '01/01/1900', NULL)

/* DEBUG TEST */
--UPDATE @job_log
--SET UdvLabel5 = 'DEBUG'

SELECT ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductDescription,
		JobNumber,
		JobDescription,
		OfficeCode,
		OfficeName,
		IsOpen,
		CampaignID,
		CampaignName,
		CreateDate,
		BillCoopCode,
		JobClientReference,
		SalesClass,
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
		JobComments,
		ModifiedDate,
		ModifiedBy,
		CreatedBy
FROM @job_log
WHERE (IsOpen = 1 OR @LoadClosed = 1)
ORDER BY JobNumber
OPTION (RECOMPILE)
GO

GRANT EXECUTE ON [advsp_job_log_get_api] TO PUBLIC AS dbo
GO