
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetDetComments]
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR INT,
@SEQ SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
      SELECT     
            JOB_TRAFFIC_DET_CMTS.ID, 
            JOB_TRAFFIC_DET_CMTS.JOB_NUMBER, 
            JOB_TRAFFIC_DET_CMTS.JOB_COMPONENT_NBR, 
            JOB_TRAFFIC_DET_CMTS.SEQ_NBR, 
            JOB_TRAFFIC_DET_CMTS.EMP_CODE, 
            JOB_TRAFFIC_DET_CMTS.CREATE_USER,
            JOB_TRAFFIC_DET_CMTS.CREATE_DATE,
            JOB_TRAFFIC_DET_CMTS.CREATE_TIME,
            JOB_TRAFFIC_DET_CMTS.COMMENT
        FROM         
            JOB_TRAFFIC_DET_CMTS WITH(NOLOCK) 
        WHERE     
                    ((JOB_TRAFFIC_DET_CMTS.JOB_NUMBER = @JOB_NUMBER) 
                    AND (JOB_TRAFFIC_DET_CMTS.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR) 
                    AND (JOB_TRAFFIC_DET_CMTS.SEQ_NBR = @SEQ));
END

