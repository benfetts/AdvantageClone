IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_UpdatePOCompleteFlag]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_UpdatePOCompleteFlag]
GO
CREATE PROCEDURE [dbo].[usp_wv_UpdatePOCompleteFlag] /*WITH ENCRYPTION*/
@PO_NUMBER INT,
@PO_COMPLETE INT
AS
/*=========== QUERY ===========*/
BEGIN
	UPDATE PURCHASE_ORDER
	SET PO_COMPLETE = @PO_COMPLETE
	WHERE PO_NUMBER = @PO_NUMBER
END

BEGIN
	UPDATE PURCHASE_ORDER_DET
	SET PO_COMPLETE = @PO_COMPLETE
	WHERE PO_NUMBER = @PO_NUMBER
END
/*=========== QUERY ===========*/