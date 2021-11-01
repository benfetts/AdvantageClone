﻿


















CREATE PROCEDURE [dbo].[usp_wv_validate_JobSpecVersion]
@JobNum INT,
@JobCompNum SMALLINT,
@VERSION INT,
@REVISION INT

AS

SELECT
	COUNT(*)
FROM
	JOB_SPECS WITH (NOLOCK)
WHERE
	JOB_NUMBER = @JobNum
	AND JOB_COMPONENT_NBR = @JobCompNum 
	AND SPEC_VER = @VERSION
	AND SPEC_REV = @REVISION
















