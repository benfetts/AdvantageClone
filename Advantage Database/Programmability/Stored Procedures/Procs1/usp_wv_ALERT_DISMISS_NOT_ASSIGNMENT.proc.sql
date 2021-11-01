IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[usp_wv_ALERT_DISMISS_NOT_ASSIGNMENT]')
          AND OBJECTPROPERTY(id, N'IsProcedure') = 1
)
    DROP PROCEDURE [dbo].[usp_wv_ALERT_DISMISS_NOT_ASSIGNMENT];
GO