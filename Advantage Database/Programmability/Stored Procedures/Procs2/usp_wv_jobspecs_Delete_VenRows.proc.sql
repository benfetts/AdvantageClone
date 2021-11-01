




CREATE PROCEDURE [dbo].[usp_wv_jobspecs_Delete_VenRows]
@JobNumber int,
@JobCompNumber int,
@Vendor smallint


AS

if @Vendor = 1
	Begin
		DELETE FROM [dbo].[JOB_PUB_VENDOR] 
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
	End

if @Vendor = 2
	Begin
		DELETE FROM [dbo].[JOB_OUTDOOR_VENDOR] 
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
	End






















