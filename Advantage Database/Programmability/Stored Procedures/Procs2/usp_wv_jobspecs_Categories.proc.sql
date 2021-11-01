if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_jobspecs_Categories]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_jobspecs_Categories]
GO





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_Categories] 
@JobSpecType varchar(6)
AS


SELECT     CATEGORY_DESC, SPEC_TYPE_CODE, CATEGORY_SEQ, INACTIVE_FLAG, CATEGORY_ID
FROM         JOB_SPEC_CATEGORY
WHERE     (SPEC_TYPE_CODE = @JobSpecType) AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
ORDER BY   CATEGORY_SEQ























