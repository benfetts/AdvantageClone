IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_UpdatePOLineItemCompleteFlag]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_UpdatePOLineItemCompleteFlag]
GO
CREATE PROCEDURE [dbo].[usp_wv_UpdatePOLineItemCompleteFlag] /*WITH ENCRYPTION*/
@PO_NUMBER INT,
@LINE_NUMBER INT,
@PO_COMPLETE INT
AS
/*=========== QUERY ===========*/
BEGIN
	UPDATE PURCHASE_ORDER_DET
	SET PO_COMPLETE = @PO_COMPLETE
	WHERE PO_NUMBER = @PO_NUMBER
	AND LINE_NUMBER = @LINE_NUMBER
END
/*=========== QUERY ===========*/