if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_GetApprovalByQuoteMax]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_GetApprovalByQuoteMax]
GO






CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetApprovalByQuoteMax] 
@ESTIMATE_NUMBER INT,
@EST_COMPONENT_NBR INT,
@EST_QUOTE_NBR INT,
@EST_REV_NBR INT,
@APPROVAL_TYPE VARCHAR(10)
AS

if @APPROVAL_TYPE = 'CMP'
Begin
	SELECT     EST_QUOTE_NBR, EST_REVISION_NBR, EST_APPR_BY, EST_APPR_DATE, CREATE_USER, CREATE_DATE, ISNULL(APPR_NOTES,'') AS APPR_NOTES
	FROM         EST_CAMP_APPROVAL
	WHERE     (ESTIMATE_NUMBER = @ESTIMATE_NUMBER) AND (EST_COMPONENT_NBR = @EST_COMPONENT_NBR)  
			   AND (EST_QUOTE_NBR = @EST_QUOTE_NBR) AND (EST_REVISION_NBR = @EST_REV_NBR) AND(APPR_TYPE = 'C')
End
Else
Begin
	SELECT     EST_QUOTE_NBR, EST_REVISION_NBR, EST_APPR_BY, EST_APPR_DATE, ISNULL(EST_APPR_CL_PO_NBR,'') AS EST_APPR_CL_PO_NBR, CREATE_USER, CREATE_DATE, ISNULL(APPR_NOTES,'') AS APPR_NOTES
	FROM         ESTIMATE_APPROVAL
	WHERE     (ESTIMATE_NUMBER = @ESTIMATE_NUMBER) AND (EST_COMPONENT_NBR = @EST_COMPONENT_NBR) AND (EST_QUOTE_NBR = @EST_QUOTE_NBR) AND (EST_REVISION_NBR = @EST_REV_NBR)
End























