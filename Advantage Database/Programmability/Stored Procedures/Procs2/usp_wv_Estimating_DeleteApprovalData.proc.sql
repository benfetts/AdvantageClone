if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_DeleteApprovalData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_DeleteApprovalData]
GO






CREATE PROCEDURE [dbo].[usp_wv_Estimating_DeleteApprovalData] 
@ESTIMATE_NUMBER INT,
@EST_COMPONENT_NBR INT
AS


DELETE  FROM ESTIMATE_APPROVAL
WHERE (ESTIMATE_NUMBER = @ESTIMATE_NUMBER) AND (EST_COMPONENT_NBR = @EST_COMPONENT_NBR)

DELETE  FROM EST_CAMP_APPROVAL
WHERE (ESTIMATE_NUMBER = @ESTIMATE_NUMBER) AND (EST_COMPONENT_NBR = @EST_COMPONENT_NBR) AND (APPR_TYPE = 'C')

























