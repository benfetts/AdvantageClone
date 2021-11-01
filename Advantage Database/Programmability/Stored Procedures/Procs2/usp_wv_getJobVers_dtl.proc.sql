--DROP PROCEDURE usp_wv_getJobVers_dtl
CREATE PROCEDURE usp_wv_getJobVers_dtl
@jobverhdr	INT
AS
BEGIN

	SELECT
		JobVersionTemplateDetailID, -- 0
		JobVersionValue, -- 1
		JobVersionDataTypeID, --  2
		JobVersionTemplateLabel, --  3
		JobVersionTemplateOrder, --  4
		JobVersionTemplateIsRequired, -- 5
		JobVersionDataTypeDescription, --  6
		AdvantageDataTypeID, --  7
		JobVersionDataTypePrecision, --  8
		JobVersionDataTypeScale, -- 9
		JobVersionTemplateDetailInstructions, -- 10
		IsSection, -- 11
		IsDateWithDefault -- 12
	FROM 
		[dbo].[advtf_job_version_load](@jobverhdr);

END