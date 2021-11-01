

CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_RemoveContactFromTask]
@ID INT
AS

        DELETE FROM         
            JOB_TRAFFIC_DET_CNTS
        WHERE ID = @ID



