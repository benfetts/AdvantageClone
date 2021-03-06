

CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetDistinctPhases] 
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR SMALLINT
AS




	SELECT DISTINCT 
		TRAFFIC_PHASE.TRAFFIC_PHASE_ID, TRAFFIC_PHASE.PHASE_DESC,TRAFFIC_PHASE.PHASE_ORDER
	FROM         
		JOB_TRAFFIC_DET WITH(NOLOCK) INNER JOIN
		TRAFFIC_PHASE WITH(NOLOCK) ON JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID
	WHERE     
		(JOB_TRAFFIC_DET.JOB_NUMBER = @JOB_NUMBER) AND (JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
	ORDER BY 
		TRAFFIC_PHASE.PHASE_ORDER;


		
