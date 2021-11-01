





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetSpecFieldDesc] 
@FieldName varchar(18),
@JobSpecType varchar(6)
AS


SELECT     FIELD_DESC
FROM         JOB_SPEC_FIELDS
WHERE     (FIELD_NAME = @FieldName) AND (SPEC_TYPE_CODE = @JobSpecType)
























