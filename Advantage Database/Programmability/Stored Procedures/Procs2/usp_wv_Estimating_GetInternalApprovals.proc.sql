﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_GetInternalApprovals]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_GetInternalApprovals]
GO





CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetInternalApprovals] 
@ESTIMATE_NUMBER INT,
@EST_COMPONENT_NBR INT,
@APPROVAL_TYPE VARCHAR(10)
AS

if @APPROVAL_TYPE = 'CMP'
Begin
	SELECT     EST_QUOTE_NBR, EST_REVISION_NBR, EST_APPR_BY, EST_APPR_DATE, CREATE_USER, CREATE_DATE, ISNULL(APPR_NOTES,'') AS APPR_NOTES
	FROM         EST_CAMP_APPROVAL
	WHERE     (ESTIMATE_NUMBER = @ESTIMATE_NUMBER) AND (EST_COMPONENT_NBR = @EST_COMPONENT_NBR) AND 
			  (APPR_TYPE = 'I')
End
Else
Begin
	SELECT     EST_QUOTE_NBR, EST_REVISION_NBR, EST_APPR_BY, EST_APPR_DATE, CREATE_USER, CREATE_DATE, ISNULL(APPR_NOTES,'') AS APPR_NOTES
	FROM         ESTIMATE_INT_APPR
	WHERE     (ESTIMATE_NUMBER = @ESTIMATE_NUMBER) AND (EST_COMPONENT_NBR = @EST_COMPONENT_NBR)
End























