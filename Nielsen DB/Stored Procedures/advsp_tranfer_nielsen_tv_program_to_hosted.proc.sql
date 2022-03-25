CREATE PROC [dbo].[advsp_tranfer_nielsen_tv_program_to_hosted]
AS

BEGIN TRAN

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_TV_PROGRAM ON

INSERT INTO NIELSENHOSTED.dbo.NIELSEN_TV_PROGRAM ( [NIELSEN_TV_PROGRAM_ID], [NIELSEN_TV_PROGRAM_BOOK_ID], [STATION_CODE], 
[QTR_HOUR_START_DATETIME], [QTR_HOUR_END_DATETIME], [PROGRAM_NAME], [SUBTITLE], [TRACKAGE_NAME] )
SELECT [NIELSEN_TV_PROGRAM_ID], [NIELSEN_TV_PROGRAM_BOOK_ID], [STATION_CODE], [QTR_HOUR_START_DATETIME], [QTR_HOUR_END_DATETIME], [PROGRAM_NAME], [SUBTITLE], [TRACKAGE_NAME]
FROM NIELSENDATASTORE.dbo.NIELSEN_TV_PROGRAM
WHERE NIELSEN_TV_PROGRAM_ID NOT IN (SELECT NIELSEN_TV_PROGRAM_ID FROM NIELSENHOSTED.dbo.NIELSEN_TV_PROGRAM)

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_TV_PROGRAM OFF

COMMIT TRAN

GO