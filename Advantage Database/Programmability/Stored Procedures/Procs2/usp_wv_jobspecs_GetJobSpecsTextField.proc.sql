
CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetJobSpecsTextField] 
@JobNumber Int,
@JobCompNumber Int,
@Version Int,
@Revision Int,
@JobItemCode varchar(50)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT '
SELECT @sql = @sql + @JobItemCode
SELECT @sql = @sql + ' FROM  JOB_SPECS
					  WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobCompNumber AND (SPEC_VER = @Version) AND (SPEC_REV = @Revision)'
						
SELECT @paramlist = '@JobNumber Int, @JobCompNumber Int, @Version Int, @Revision Int'

EXEC sp_executesql @sql, @paramlist, @JobNumber, @JobCompNumber, @Version, @Revision
 

PRINT @sql		



	
