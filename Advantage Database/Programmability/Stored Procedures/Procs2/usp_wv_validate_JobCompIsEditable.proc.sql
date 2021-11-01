
--Being used on:
--Timesheet, add new single row.

CREATE PROCEDURE [dbo].[usp_wv_validate_JobCompIsEditable]
@JobNum INT,
@JobCompNum INT,
@OnlyClosedProcessControls SMALLINT
AS
	DECLARE @ThisReturn INT


	SELECT @ThisReturn = 0


IF @OnlyClosedProcessControls = 1
	BEGIN
		SELECT DISTINCT 
			@ThisReturn = JOB_COMPONENT_NBR
		FROM         
			JOB_COMPONENT  WITH (NOLOCK) 
		WHERE     
			(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12))
			AND JOB_COMPONENT.JOB_NUMBER = @JobNum
			AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNum
	END
ELSE
	BEGIN
		SELECT DISTINCT 
			@ThisReturn = JOB_COMPONENT_NBR
		FROM         
			JOB_COMPONENT  WITH (NOLOCK) 
		WHERE     
			(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,6,9,10,12,13))
			AND JOB_COMPONENT.JOB_NUMBER = @JobNum
			AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNum
	END
	

	
	SELECT ISNULL(@ThisReturn,0)


