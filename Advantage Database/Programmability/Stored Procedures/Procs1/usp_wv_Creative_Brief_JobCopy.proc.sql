

















CREATE PROCEDURE [dbo].[usp_wv_Creative_Brief_JobCopy] 
@JobNum Int,
@JobCompNum Int,
@JOB_NUM int,
@JOB_COMP int,
@CREATE_DATE SMALLDATETIME
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int,
	@JNum int,
	@JCNum int	

CREATE TABLE #cb(
	RowID int IDENTITY(1, 1), 
	JobNo int,
	JobCompNo int)

INSERT INTO #cb
        SELECT JOB_NUMBER, JOB_COMPONENT_NBR
        FROM       CRTV_BRF_DTL
        WHERE     (JOB_NUMBER = @JobNum) AND (JOB_COMPONENT_NBR = @JobCompNum) 
         
		           
		           


SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @JNum = JobNo, @JCNum = JobCompNo
 FROM #cb
 WHERE RowID = @RowCount

 
 INSERT INTO CRTV_BRF_DTL (CRTV_BRF_DTL_ID, CRTV_BRF_DTL_DESC, JOB_NUMBER, JOB_COMPONENT_NBR, CRTV_BRF_LVL3_ID, DTL_ORDER, CREATED_BY, CREATE_DATE)
 SELECT CRTV_BRF_DTL_ID, CRTV_BRF_DTL_DESC, @JOB_NUM, @JOB_COMP, CRTV_BRF_LVL3_ID, DTL_ORDER, CREATED_BY, @CREATE_DATE
           FROM  CRTV_BRF_DTL 
				   WHERE JOB_NUMBER = @JNum AND JOB_COMPONENT_NBR = @JCNum  
 
		
 SET @RowCount = @RowCount + 1
END


 

DROP TABLE #cb





