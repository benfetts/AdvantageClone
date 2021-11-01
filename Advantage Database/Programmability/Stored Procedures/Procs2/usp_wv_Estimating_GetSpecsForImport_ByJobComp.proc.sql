





CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetSpecsForImport_ByJobComp]
@JobNumber int,
@JobCompNumber int
AS
DECLARE @NumberRecords int, @RowCount int,
	@SpecVer int,
	@SpecRev int,
	@SpecDesc varchar(60)
	
CREATE TABLE #MY_DATA --MASTER TABLE TO RETURN
    (
        [RowID]          int IDENTITY(1, 1),
	    [SPEC_VER]       int,
	    [SPEC_REV]       int,
	    [SPEC_TYPE_CODE] VARCHAR(6),
	    [SPEC_VER_DESC]  VARCHAR(60)
    )	
INSERT INTO #MY_DATA    
SELECT DISTINCT JOB_SPECS.SPEC_VER, MAX(JOB_SPECS.SPEC_REV) AS SPEC_REV, JOB_SPECS.SPEC_TYPE_CODE, ''
FROM         JOB_COMPONENT INNER JOIN
                      JOB_SPECS ON JOB_COMPONENT.JOB_NUMBER = JOB_SPECS.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_SPECS.JOB_COMPONENT_NBR LEFT OUTER JOIN
                      JOB_SPEC_APPR ON JOB_SPECS.JOB_NUMBER = JOB_SPEC_APPR.JOB_NUMBER AND 
                      JOB_SPECS.JOB_COMPONENT_NBR = JOB_SPEC_APPR.JOB_COMPONENT_NBR AND 
                      JOB_SPECS.SPEC_VER = JOB_SPEC_APPR.APPR_SPEC_VER
WHERE     (JOB_COMPONENT.JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNumber)
GROUP BY JOB_SPECS.SPEC_VER, JOB_SPECS.SPEC_TYPE_CODE
                                                 

SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @SpecVer = SPEC_VER, @SpecRev = SPEC_REV
 FROM #MY_DATA
 WHERE RowID = @RowCount
 
 SELECT @SpecDesc = SPEC_VER_DESC 
 FROM JOB_SPECS
 WHERE SPEC_VER = @SpecVer AND SPEC_REV = @SpecRev AND JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobCompNumber
 
 UPDATE #MY_DATA 
SET SPEC_VER_DESC = @SpecDesc
WHERE SPEC_VER = @SpecVer AND SPEC_REV = @SpecRev
 
 SET @RowCount = @RowCount + 1
END

SELECT SPEC_VER, SPEC_REV, SPEC_TYPE_CODE, SPEC_VER_DESC
FROM #MY_DATA
                                                 

DROP TABLE #MY_DATA;


