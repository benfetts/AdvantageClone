
CREATE FUNCTION [dbo].[udf_get_job_comp_status] ( @JOB_NUMBER int, @JOB_COMPONENT_NBR INT )
RETURNS int
AS
BEGIN
	-- =============================================
	-- Author:		Steven Walden
	-- Create date: 02/01/2011
	-- Description:	Check to see if Job Component is Open Or Closed
	-- =============================================
	-- variables
	DECLARE @JOB_PROCESS_CONTRL integer
	DECLARE @IS_JOB_COMP_OPEN integer
	
	SELECT 
		@JOB_PROCESS_CONTRL = ISNULL(JOB_PROCESS_CONTRL, 0)
	FROM
		[dbo].[JOB_COMPONENT]
	WHERE
		JOB_NUMBER = @JOB_NUMBER AND
		JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
		
	IF @JOB_PROCESS_CONTRL = 6 OR @JOB_PROCESS_CONTRL = 12 BEGIN

		SET @IS_JOB_COMP_OPEN = 0
		
	END ELSE BEGIN
	
		SET @IS_JOB_COMP_OPEN = 1
		
	END
	
	RETURN @IS_JOB_COMP_OPEN 
	
END
