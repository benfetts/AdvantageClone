
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_UpdateEmpList]
	@ID INT,
	@COMPLETEDDATE smalldatetime,
	@COMMENTS text,
	@PERCENTCOMPLETE decimal(7,3)
AS
BEGIN
Update JOB_TRAFFIC_DET_EMPS
SET TEMP_COMP_DATE = @COMPLETEDDATE,
	COMPLETED_COMMENTS = @COMMENTS,
	PERCENT_COMPLETE = @PERCENTCOMPLETE
Where ID = @ID

END

