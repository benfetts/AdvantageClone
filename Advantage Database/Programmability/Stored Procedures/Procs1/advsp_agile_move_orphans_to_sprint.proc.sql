IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_move_orphans_to_sprint]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_move_orphans_to_sprint]
GO
CREATE PROCEDURE [dbo].[advsp_agile_move_orphans_to_sprint]
@SPRINT_ID INT,
@BOARD_ID INT
AS
BEGIN
/*=========== QUERY ===========*/

    UPDATE SPRINT_DTL WITH(ROWLOCK)
    SET 
        SPRINT_HDR_ID = @SPRINT_ID, 
        BACKLOG_BOARD_ID = NULL 
    WHERE 
        SPRINT_HDR_ID IS NULL
        AND BACKLOG_BOARD_ID = @BOARD_ID
    ;

/*=========== QUERY ===========*/
END