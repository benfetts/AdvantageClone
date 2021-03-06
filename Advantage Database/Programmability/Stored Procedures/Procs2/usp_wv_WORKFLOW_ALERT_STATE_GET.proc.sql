SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_WORKFLOW_ALERT_STATE_GET]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_WORKFLOW_ALERT_STATE_GET]
GO

CREATE PROCEDURE [dbo].[usp_wv_WORKFLOW_ALERT_STATE_GET] /*WITH ENCRYPTION*/
@ALRT_NOTIFY_HDR_ID INT,
@ALERT_STATE_ID INT
AS
/*=========== QUERY ===========*/
DECLARE 
	@TEMPLATE_TEXT VARCHAR(100),
	@STATE_TEXT VARCHAR(100),
	@CURRENT_WORKFLOW_ID INT
	
	SELECT @TEMPLATE_TEXT = ALERT_NOTIFY_NAME FROM ALERT_NOTIFY_HDR WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID;
	SELECT @STATE_TEXT = ALERT_STATE_NAME FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = @ALERT_STATE_ID;
	SELECT @CURRENT_WORKFLOW_ID = WORKFLOW_ID FROM WORKFLOW_ALERT_STATE WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID AND ALERT_STATE_ID = @ALERT_STATE_ID;
	
	SELECT @TEMPLATE_TEXT AS TEMPLATE_TEXT, @STATE_TEXT AS STATE_TEXT, @CURRENT_WORKFLOW_ID AS CURRENT_WORKFLOW_ID;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO