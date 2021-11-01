IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_delete_sprint]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_delete_sprint]
GO
CREATE PROCEDURE [dbo].[advsp_agile_delete_sprint] (
@SPRINT_HDR_ID INT
)
AS
BEGIN


	IF NOT @SPRINT_HDR_ID IS NULL
    BEGIN

        DELETE FROM SPRINT_EMPLOYEE
        FROM SPRINT_EMPLOYEE SE
             INNER JOIN SPRINT_DTL SD ON SE.SPRINT_DTL_ID = SD.ID
             INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID
        WHERE SH.ID = @SPRINT_HDR_ID;

        UPDATE ALERT
          SET
              BOARD_STATE_ID = NULL,
              BACKLOG_SEQ_NBR = NULL
        FROM ALERT A
             INNER JOIN SPRINT_DTL SD ON A.ALERT_ID = SD.ALERT_ID
             INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID
        WHERE SH.ID = @SPRINT_HDR_ID;

        DELETE FROM SPRINT_DTL
        FROM SPRINT_DTL SD
             INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID
        WHERE SH.ID = @SPRINT_HDR_ID;

        DELETE FROM SPRINT_HDR
        WHERE ID = @SPRINT_HDR_ID;

    END;

END