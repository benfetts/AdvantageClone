﻿

CREATE PROCEDURE [dbo].[usp_wv_Job_Template_GetEstimateApproval] 
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR INT
AS

SELECT     JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, ESTIMATE_APPROVAL.ESTIMATE_NUMBER, 
                      ESTIMATE_APPROVAL.EST_COMPONENT_NBR, ESTIMATE_APPROVAL.EST_APPR_BY, ESTIMATE_APPROVAL.EST_APPR_DATE
FROM         JOB_COMPONENT INNER JOIN
                      ESTIMATE_APPROVAL ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_APPROVAL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_APPROVAL.JOB_COMPONENT_NBR
WHERE     (JOB_COMPONENT.JOB_NUMBER = @JOB_NUMBER) AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
	

	

