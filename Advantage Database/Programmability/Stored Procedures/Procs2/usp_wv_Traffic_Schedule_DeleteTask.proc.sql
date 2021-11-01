CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_DeleteTask] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR INT,
@SEQ SMALLINT
AS
-- TP 3/26/2015: Move child items to new parent
-- TP 4/22/2015: Delete task alerts based on setting
-- TP 5/19/2015: Move tasks to project schedule when deleting & alerts are not set to delete

-- ST 02/01/2018: Replace with new script.  New script factors in sprint detail records.  
-- Also removes option to delete alerts/assignments per issu:  
-- 4922-1-100 - Project Schedule Settings - Adjust for new Boards. See Word doc attached.

/*=========== QUERY ===========*/
BEGIN
	EXEC [dbo].[advsp_project_schedule_delete_task] @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ;
END
/*=========== QUERY ===========*/