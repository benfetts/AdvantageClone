﻿--DROP PROCEDURE [dbo].[usp_wv_Job_Template_AddNewComponent] 
CREATE PROCEDURE [dbo].[usp_wv_Job_Template_AddNewComponent] 
@JOB_NUMBER AS INT,
@EMP_CODE VARCHAR(6),
@JOB_COMP_DESC VARCHAR(60),
@JOB_TMPLT_CODE VARCHAR(6),
@JT_CODE VARCHAR(10),
@CREATE_DATE SMALLDATETIME,
@USER_ID VARCHAR(100)
AS
BEGIN

	DECLARE
		@NewCompNumber INT,
		@PROD_MARKUP DECIMAL(11,3),
		@EmailGroup VARCHAR(50),
		@DFLT_TRF_SCHEDULE_BY SMALLINT,
		@comp_count INT

	SELECT @comp_count = ISNULL(COUNT(1),0) FROM JOB_COMPONENT WHERE JOB_NUMBER = @JOB_NUMBER;

	IF @comp_count < 999
	BEGIN
		--Get Next comp number, based on existing: usp_wv_job_component_next_number
		SELECT
			@NewCompNumber = MAX(JOB_COMPONENT_NBR) + 1
		FROM
			JOB_COMPONENT
		WHERE 
			JOB_NUMBER = @JOB_NUMBER;

		--Get Default markup and email group:
		SELECT
			@PROD_MARKUP = PRODUCT.PRD_PROD_MARKUP,
			@EmailGroup = PRODUCT.EMAIL_GR_CODE
		FROM
			PRODUCT
			INNER JOIN JOB_LOG
				ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
				AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
				AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
		WHERE
			JOB_LOG.JOB_NUMBER = @JOB_NUMBER;
    	
		--Get Default TRF_SCHEDULE_BY
		SELECT @DFLT_TRF_SCHEDULE_BY = TRF_SCHEDULE_BY FROM AGENCY;

		--Add new component:
		INSERT INTO [dbo].[JOB_COMPONENT] (
			[JOB_NUMBER],
			[JOB_COMPONENT_NBR],
			[EMP_CODE],
			[JOB_COMP_DESC],
			[JOB_SPEC_TYPE], 
			[JOB_PROCESS_CONTRL],
			[JOB_COMP_DATE], 
			[JOB_MARKUP_PCT],
			[JOB_TMPLT_CODE],
			[AB_FLAG],
			[EMAIL_GR_CODE],
			[NOBILL_FLAG],
			[TRF_SCHEDULE_BY],
			[JT_CODE],
			[MODIFY_DATE],
			[MODIFIED_BY]
		) 
		VALUES (
			@JOB_NUMBER,
			@NewCompNumber,
			@EMP_CODE,
			@JOB_COMP_DESC,
			0,1, --spec type and proc control
			CONVERT(VARCHAR(10) , @CREATE_DATE, 101),
			@PROD_MARKUP,
			@JOB_TMPLT_CODE,
			0,
			@EmailGroup,
			0,
			@DFLT_TRF_SCHEDULE_BY,
			@JT_CODE,
			@CREATE_DATE,
			@USER_ID
		);

	END

	SELECT @NewCompNumber;

END