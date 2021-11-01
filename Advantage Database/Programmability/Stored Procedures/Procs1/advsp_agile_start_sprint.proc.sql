IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = object_id(N'[dbo].[advsp_agile_start_sprint]')
			AND OBJECTPROPERTY(id, N'IsProcedure') = 1
		)
	DROP PROCEDURE [dbo].[advsp_agile_start_sprint]
GO

CREATE PROCEDURE [dbo].[advsp_agile_start_sprint] 
@SPRINT_HEADER_ID INT
AS
BEGIN
/*=========== QUERY ===========*/
	DECLARE
		@BOARD_ID INT;

    SELECT @BOARD_ID = BOARD_ID FROM SPRINT_HDR WHERE ID = @SPRINT_HEADER_ID;

    UPDATE SPRINT_HDR SET IS_ACTIVE = 0 WHERE ID <> @SPRINT_HEADER_ID AND BOARD_ID = @BOARD_ID;
    UPDATE SPRINT_HDR SET IS_ACTIVE = 1 WHERE ID = @SPRINT_HEADER_ID AND BOARD_ID = @BOARD_ID;

/*=========== QUERY ===========*/
END