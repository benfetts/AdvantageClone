
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_get_next_media_import_order_id]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_get_next_media_import_order_id]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_get_next_media_import_order_id] 
	@SourceCode varchar(2)

AS

DECLARE @OrderID int

BEGIN TRAN

IF @SourceCode = 'AP' BEGIN

       UPDATE ASSIGN_NBR
       SET LAST_NBR = LAST_NBR + 1, @OrderID = LAST_NBR + 1
       WHERE COLUMNNAME ='IMPORT_ORDER_NBR_AP'

END ELSE IF @SourceCode = 'AM' BEGIN

       UPDATE ASSIGN_NBR
       SET LAST_NBR = LAST_NBR + 1, @OrderID = LAST_NBR + 1
       WHERE COLUMNNAME ='IMPORT_ORDER_NBR_AM'

END ELSE IF @SourceCode = 'AB' BEGIN

       UPDATE ASSIGN_NBR
       SET LAST_NBR = LAST_NBR + 1, @OrderID = LAST_NBR + 1
       WHERE COLUMNNAME ='IMPORT_ORDER_NBR_AB'

END ELSE IF @SourceCode = 'AW' BEGIN

       UPDATE ASSIGN_NBR
       SET LAST_NBR = LAST_NBR + 1, @OrderID = LAST_NBR + 1
       WHERE COLUMNNAME ='IMPORT_ORDER_NBR_AW'

END

SELECT @OrderID

COMMIT TRAN

GO
