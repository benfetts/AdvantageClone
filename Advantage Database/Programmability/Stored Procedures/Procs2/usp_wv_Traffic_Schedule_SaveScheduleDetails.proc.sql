
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_SaveScheduleDetails] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@START_DATE SMALLDATETIME,
@DUE_DATE SMALLDATETIME,
@USE_START_DATE_FOR_CALC SMALLINT,
@AUTO_SAVE_TRAFF_CODE SMALLINT,
@TRAFFIC_CODE VARCHAR(10),
@JOB_TRAFFIC_COMPLETED_DATE SMALLDATETIME,
@PERCENT_COMPLETE decimal(7,3)

AS


    IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0 
    BEGIN
	    UPDATE JOB_COMPONENT
	    SET START_DATE = @START_DATE,JOB_FIRST_USE_DATE = @DUE_DATE, TRF_SCHEDULE_BY = @USE_START_DATE_FOR_CALC
	    WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
	    UPDATE JOB_TRAFFIC
	    SET COMPLETED_DATE = @JOB_TRAFFIC_COMPLETED_DATE, PERCENT_COMPLETE = @PERCENT_COMPLETE
	    WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
    END

    IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0  AND @AUTO_SAVE_TRAFF_CODE = 0 AND @TRAFFIC_CODE <> ''
    BEGIN
	    UPDATE JOB_TRAFFIC
	    SET TRF_CODE = @TRAFFIC_CODE
		WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
    END


