IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_get_latest_document_id]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_get_latest_document_id];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_get_latest_document_id] 
@ALERT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN
	SELECT 
		D.DocumentID
	FROM
		[dbo].[advtf_proofing_get_documents_details] (@ALERT_ID) D
	WHERE	
		D.IsLatestDocument = 1
	;
END
/*=========== QUERY ===========*/
