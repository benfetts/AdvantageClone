IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_move_orphans_to_sprint]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_move_orphans_to_sprint]
GO
CREATE PROCEDURE [dbo].[advsp_agile_move_orphans_to_sprint]
@SPRINT_ID INT,
@BOARD_ID INT
AS
BEGIN
/*=========== QUERY ===========*/

    --SELECT ALERT_ID FROM SPRINT_DTL WHERE BACKLOG_BOARD_ID = @BOARD_ID;

    --DECLARE @ALERT_ID AS INT

    --DECLARE ORPHAN_CURSOR CURSOR FOR
    --SELECT ALERT_ID FROM SPRINT_DTL WHERE BACKLOG_BOARD_ID = @BOARD_ID;

    --OPEN ORPHAN_CURSOR;
    --FETCH NEXT FROM ORPHAN_CURSOR INTO @ALERT_ID;

    --WHILE (@@FETCH_STATUS = 0)
    --BEGIN

	   -- EXEC [dbo].[advsp_agile_sprint_check_employee_records] @SPRINT_ID, @ALERT_ID;
	   -- FETCH NEXT FROM ORPHAN_CURSOR INTO @ALERT_ID;

    --END

    --CLOSE ORPHAN_CURSOR;
    --DEALLOCATE ORPHAN_CURSOR;

    UPDATE SPRINT_DTL SET SPRINT_HDR_ID = @SPRINT_ID, BACKLOG_BOARD_ID = NULL WHERE SPRINT_HDR_ID IS NULL AND BACKLOG_BOARD_ID = @BOARD_ID;
	EXEC [dbo].[advsp_agile_sprint_check_employee_records] @SPRINT_ID, 0;


/*=========== QUERY ===========*/
END