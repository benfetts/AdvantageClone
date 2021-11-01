IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ALERT_GET_COMMENTS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ALERT_GET_COMMENTS]
GO
/*
    REPLACED WITH:  [dbo].[advsp_alert_load_comments]
*/
