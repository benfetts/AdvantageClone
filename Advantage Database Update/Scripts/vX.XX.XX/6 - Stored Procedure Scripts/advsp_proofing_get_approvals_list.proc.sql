IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_get_approvals_list]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_get_approvals_list];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_get_approvals_list] 
@ALERT_ID INT,
@DOCUMENT_ID INT = NULL
AS
/*=========== QUERY ===========*/
BEGIN

	SELECT 
		A.AlertStateID,
		A.AlertStateName,
		A.EmployeeCode,
		A.[Name],
		A.ProofingStatusID,
		A.ProofingStatus,
		A.ApproveDate,
		A.IsCurrentState,
		A.SequenceNumber,
		A.DocumentID,
		A.ProofingStatusExternalReviewerID,
		A.TotalMarkupCount,
		[CanDelete] =	CAST(1 AS BIT)
	FROM 
		[dbo].[advtf_proofing_get_approvals_list] (@ALERT_ID, @DOCUMENT_ID) AS A;

END
/*=========== QUERY ===========*/
