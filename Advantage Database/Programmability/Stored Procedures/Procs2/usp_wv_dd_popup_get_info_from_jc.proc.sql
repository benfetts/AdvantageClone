﻿
CREATE PROCEDURE [dbo].[usp_wv_dd_popup_get_info_from_jc] 
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR SMALLINT

AS
	DECLARE @NEXT_ALERT_SEQ_NBR INT;
	
	SELECT @NEXT_ALERT_SEQ_NBR = ISNULL(MAX(ALERT_SEQ_NBR), 0)
	FROM   ALERT WITH (NOLOCK)
	WHERE  JOB_NUMBER = @JOB_NUMBER
		   AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
		   AND ALERT_LEVEL = 'JC';

	SET @NEXT_ALERT_SEQ_NBR = ISNULL(@NEXT_ALERT_SEQ_NBR, 0) + 1;

	SELECT OFFICE.OFFICE_CODE,
		   OFFICE.OFFICE_NAME,
		   CLIENT.CL_CODE,
		   CLIENT.CL_NAME,
		   DIVISION.DIV_CODE,
		   DIVISION.DIV_NAME,
		   PRODUCT.PRD_CODE,
		   PRODUCT.PRD_DESCRIPTION,
		   JOB_LOG.JOB_NUMBER,
		   REPLACE(JOB_LOG.JOB_DESC, '''', '') AS JOB_DESC,
		   JOB_COMPONENT.JOB_COMPONENT_NBR,
		   REPLACE(JOB_COMPONENT.JOB_COMP_DESC, '''', '') AS JOB_COMP_DESC,
		   ISNULL(JOB_COMPONENT.CDP_CONTACT_ID, '') AS CDP_CONTACT_ID,
		   ISNULL(JOB_COMPONENT.PRD_CONT_CODE, '') AS PRD_CONT_CODE,
		   ISNULL(CDP_CONTACT_HDR.CONT_FML, '') AS CONT_FML,
		   @NEXT_ALERT_SEQ_NBR AS NEXT_ALERT_SEQ_NBR,
		   JOB_LOG.SC_CODE, JOB_COMPONENT.EMP_CODE, ISNULL(JOB_LOG.CMP_CODE,'') AS CMP_CODE,
		   ISNULL(JOB_LOG.CMP_IDENTIFIER,0) AS CMP_IDENTIFIER
	FROM   JOB_LOG WITH (NOLOCK)
		   INNER JOIN JOB_COMPONENT WITH (NOLOCK)
				ON  JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
		   INNER JOIN PRODUCT WITH (NOLOCK)
				ON  JOB_LOG.CL_CODE = PRODUCT.CL_CODE
				AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE
				AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE
		   INNER JOIN CLIENT WITH (NOLOCK)
		   INNER JOIN DIVISION WITH (NOLOCK)
				ON  CLIENT.CL_CODE = DIVISION.CL_CODE
				ON  PRODUCT.CL_CODE = DIVISION.CL_CODE
				AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE
		   LEFT OUTER JOIN OFFICE WITH (NOLOCK)
				ON  JOB_LOG.OFFICE_CODE = OFFICE.OFFICE_CODE
		   LEFT OUTER JOIN CDP_CONTACT_HDR WITH (NOLOCK)
				ON  JOB_COMPONENT.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
	WHERE  (JOB_LOG.JOB_NUMBER = @JOB_NUMBER)
		   AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR);
