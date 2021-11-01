
CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetJobSpecsQtyData] 
@JobNumber Int,
@JobCompNumber Int,
@Version Int,
@Revision Int
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT JOB_QTY AS Quantity, '''' AS EstimateNumber, '''' AS CompNum, '''' AS QuoteNum, '''' AS RevNum, SEQ_NBR AS SeqNum
				FROM  JOB_SPEC_QTY
				   WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobCompNumber AND JOB_QTY IS NOT NULL' 
			if @Version > 0 
				   SELECT @sql = @sql + ' AND (SPEC_VER = @Version)'
			if @Revision >= 0 
				   SELECT @sql = @sql + ' AND (SPEC_REV = @Revision)'
			
SELECT @sql = @sql + ' ORDER BY SEQ_NBR'			

SELECT @paramlist = '@JobNumber Int, @JobCompNumber Int, @Version Int, @Revision Int'

EXEC sp_executesql @sql, @paramlist, @JobNumber, @JobCompNumber, @Version, @Revision
 

PRINT @sql		



	
