





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetSpecIDMax] 
@JobNumber int,
@JobCompNumber int,
@type int
AS

if @type = 1
	Begin
		SELECT ISNULL(MAX(SPEC_ID),-1) AS SPEC_ID_MAX
		FROM         JOB_PUB_VENDOR
		WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber) 
	End

if @type = 2
	Begin
		SELECT ISNULL(MAX(SPEC_ID),-1) AS SPEC_ID_MAX
		FROM         JOB_OUTDOOR_VENDOR
		WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber) 
	End





















