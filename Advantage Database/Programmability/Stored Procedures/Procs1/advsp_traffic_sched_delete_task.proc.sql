/* Wrapper for usp_wv_Traffic_Schedule_DeleteTask() so it can be called from SQL Windows */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_traffic_sched_delete_task]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_traffic_sched_delete_task]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_traffic_sched_delete_task] 
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR INT,
	@SEQ SMALLINT

AS

		exec dbo.usp_wv_Traffic_Schedule_DeleteTask @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ
			
GO


