--DROP FUNCTION [dbo].[advtf_job_version_load]
CREATE FUNCTION [dbo].[advtf_job_version_load] (
@JobVersionHeaderID INT
) 
RETURNS @VERSION TABLE (JobVersionTemplateDetailID INT, -- 0
						JobVersionValue SQL_VARIANT, -- 1
						JobVersionDataTypeID INT, --  2
						JobVersionTemplateLabel VARCHAR(25), --  3
						JobVersionTemplateOrder SMALLINT, --  4
						JobVersionTemplateIsRequired BIT, -- 5
						JobVersionDataTypeDescription VARCHAR(50), --  6
						AdvantageDataTypeID INT, --  7
						JobVersionDataTypePrecision SMALLINT, --  8
						JobVersionDataTypeScale SMALLINT, -- 9
						JobVersionTemplateDetailInstructions VARCHAR(255), -- 10
						IsSection BIT, -- 11
						IsDateWithDefault BIT -- 12
						)
AS
BEGIN

	DECLARE
		@SECTION_TYPE_ID INT,
		@DATE_WITH_TODAY_DEFAULT_ID INT,
		@JV_TMPLT_CODE VARCHAR(6);

	SET @SECTION_TYPE_ID = 12;
	SET @DATE_WITH_TODAY_DEFAULT_ID = 13;
	SELECT @JV_TMPLT_CODE = JV_TMPLT_CODE FROM JOB_VER_HDR WITH(NOLOCK) WHERE JOB_VER_HDR_ID = @JobVersionHeaderID;

	INSERT INTO @VERSION
	SELECT 
		JVTD.JV_TMPLT_DTL_ID,
		NULL,
		JVTD.JV_DTYPE_ID,
		JVTD.JV_TMPLT_LABEL,
		JVTD.JV_TMPLT_ORDER,
		JVTD.JV_TMPLT_REQ,
		JVT.JV_DTYPE_DESC,
		JVT.ADVAN_DTYPE_ID,
		ISNULL(JVT.JV_DTYPE_PREC, 0) AS JV_DTYPE_PREC,
		ISNULL(JVT.JV_DTYPE_SCALE, 0) AS JV_DTYPE_SCALE,
		JVTD.JV_TMPLT_DTL_INSTR,
		CASE
			WHEN JVTD.JV_DTYPE_ID = @SECTION_TYPE_ID THEN CAST(1 AS BIT)
			ELSE CAST(0 AS BIT)
		END AS IS_SECTION ,
		CASE
			WHEN JVTD.JV_DTYPE_ID = @DATE_WITH_TODAY_DEFAULT_ID THEN CAST(1 AS BIT)
			ELSE CAST(0 AS BIT)
		END AS IS_DATE_WITH_DFLT
	FROM 
		JOB_VER_TMPLT_DTL JVTD WITH(NOLOCK) 
		INNER JOIN JOB_VER_DTYPE JVT WITH(NOLOCK) ON JVTD.JV_DTYPE_ID = JVT.JV_DTYPE_ID
	WHERE   
		JVTD.JV_TMPLT_CODE = @JV_TMPLT_CODE
		AND (JVTD.INACTIVE_FLAG = 0 OR JVTD.INACTIVE_FLAG IS NULL)
	ORDER BY 
		JVTD.JV_TMPLT_ORDER, JV_TMPLT_LABEL;

	UPDATE @VERSION
	SET JobVersionValue = JVD.JOB_VER_VALUE 
	FROM 
		JOB_VER_DTL JVD WITH(NOLOCK) 
		INNER JOIN @VERSION V ON JVD.JV_TMPLT_DTL_ID = V.JobVersionTemplateDetailID
	WHERE 
		JOB_VER_HDR_ID = @JobVersionHeaderID;

	RETURN;

END