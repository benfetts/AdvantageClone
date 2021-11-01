





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetApprovalData] 
@JobNumber int,
@JobCompNumber int
AS


SELECT     APPR_SPEC_VER, SPEC_APPR_BY, SPEC_APPR_COMMENT, SPEC_APPR_USER_ID, SPEC_APPR_DATE, ISNULL(SPEC_APPR_USER_ID_CP,0) AS SPEC_APPR_USER_ID_CP
FROM         JOB_SPEC_APPR
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber)
























