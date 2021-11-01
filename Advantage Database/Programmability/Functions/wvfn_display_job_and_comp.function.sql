
    CREATE FUNCTION [dbo].[wvfn_display_job_and_comp]
    (
	    @JOB_NUMBER         INT = 0,
	    @JOB_COMPONENT_NBR  SMALLINT = 0
    )
    RETURNS VARCHAR(500)
    AS
    BEGIN
	    DECLARE @RET VARCHAR(500)
	    SELECT @RET = RIGHT(
	               REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER),
	               6
	           ) + '-' + RIGHT(
	               REPLICATE('0', 2) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR),
	               2
	           ) 
	           + '  ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' / ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '')
	    FROM   JOB_LOG WITH(NOLOCK)
	           INNER JOIN JOB_COMPONENT WITH(NOLOCK)
	                ON  JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	    WHERE  JOB_LOG.JOB_NUMBER = @JOB_NUMBER
	           AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
	    RETURN @RET
    END


