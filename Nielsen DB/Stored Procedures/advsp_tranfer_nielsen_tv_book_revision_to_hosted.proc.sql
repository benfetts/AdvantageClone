CREATE PROC [dbo].[advsp_tranfer_nielsen_tv_book_revision_to_hosted]
AS

BEGIN TRAN

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_TV_BOOK_REVISION ON

INSERT INTO NIELSENHOSTED.dbo.NIELSEN_TV_BOOK_REVISION ( NIELSEN_TV_BOOK_REVISION_ID, OLD_NIELSEN_TV_BOOK_ID, NEW_NIELSEN_TV_BOOK_ID )
SELECT NIELSEN_TV_BOOK_REVISION_ID, OLD_NIELSEN_TV_BOOK_ID, NEW_NIELSEN_TV_BOOK_ID
FROM NIELSENDATASTORE.dbo.NIELSEN_TV_BOOK_REVISION
WHERE NIELSEN_TV_BOOK_REVISION_ID NOT IN (SELECT NIELSEN_TV_BOOK_REVISION_ID FROM NIELSENHOSTED.dbo.NIELSEN_TV_BOOK_REVISION)

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_TV_BOOK_REVISION OFF

COMMIT TRAN

GO
