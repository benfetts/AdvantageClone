




CREATE PROCEDURE [dbo].[usp_wv_jobspecs_Delete_QtyVenRows]
@JobNumber int,
@JobCompNumber int,
@Version int,
@Revision int,
@Quantity bit,
@Vendor smallint,
@SpecID smallint,
@SeqNum smallint

AS

if @Quantity = 1
	Begin
		DELETE FROM [dbo].[JOB_SPEC_QTY]
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
			AND SPEC_VER = @Version	
			AND SPEC_REV = @Revision
			AND SEQ_NBR = @SeqNum
	End

if @Vendor = 1
	Begin
		DELETE FROM [dbo].[JOB_PUB_VENDOR] 
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
			AND SPEC_ID = @SpecID
	End

if @Vendor = 2
	Begin
		DELETE FROM [dbo].[JOB_OUTDOOR_VENDOR] 
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
			AND SPEC_ID = @SpecID
	End






















