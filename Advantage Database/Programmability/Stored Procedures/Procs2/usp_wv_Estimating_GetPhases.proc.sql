





CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetPhases]
@EstNumber int,
@EstCompNumber int
AS

SELECT DISTINCT   ESTIMATE_REV_DET.EST_PHASE_ID AS Code, ESTIMATE_REV_DET.EST_PHASE_DESC as Description
FROM         ESTIMATE_REV_DET
WHERE     (ESTIMATE_REV_DET.ESTIMATE_NUMBER = @EstNumber) AND (ESTIMATE_REV_DET.EST_COMPONENT_NBR = @EstCompNumber) AND
			ESTIMATE_REV_DET.EST_PHASE_ID IS NOT NULL
ORDER BY ESTIMATE_REV_DET.EST_PHASE_DESC 			

                                                 




