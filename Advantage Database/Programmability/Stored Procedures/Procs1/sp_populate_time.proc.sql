IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_populate_time]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_populate_time]
GO

CREATE PROCEDURE [dbo].[sp_populate_time] @emp_code varchar(6), @emp_date smalldatetime
AS
/* Temporary table to store returned rows */
-- BJL - 11/23/03 - Added start and end time to table
CREATE TABLE #time_rows( 	
	ET_ID				int NOT NULL,
	ET_DTL_ID			int NOT NULL,
	FNC_CAT				varchar(10) NULL,
	EMP_HOURS			decimal(9,3) NOT NULL,
	CL_CODE				varchar(6) NULL,
	DIV_CODE			varchar(6) NULL,
	PRD_CODE			varchar(6) NULL,
	JOB_NUMBER			int NULL,
	CLIENT_REF			varchar(30) NULL,
	JOB_COMPONENT_NBR	smallint NULL,
	DP_TM_CODE			varchar(4) NULL,
	TIME_TYPE			char(1) NOT NULL,
	EDIT_FLAG			smallint NOT NULL,
	MAX_SEQ				smallint NULL,
	START_TIME			char(4) NULL,
	END_TIME			char(4) NULL )

ALTER TABLE [dbo].[#time_rows] WITH NOCHECK ADD 
	CONSTRAINT [PK_time_rows] PRIMARY KEY  CLUSTERED 
	(
		[ET_ID], [ET_DTL_ID]
	)  ON [PRIMARY] 


INSERT INTO #time_rows
     SELECT etd.ET_ID, etd.ET_DTL_ID, NULL, SUM(EMP_HOURS), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 
			'D', 0, MAX( SEQ_NBR ), NULL, NULL
       FROM EMP_TIME_DTL etd, EMP_TIME et
      WHERE et.ET_ID = etd.ET_ID
		AND EMP_CODE = @emp_code
		AND EMP_DATE = @emp_date
   GROUP BY etd.ET_ID, etd.ET_DTL_ID

UPDATE #time_rows
   SET FNC_CAT = etd.FNC_CODE,
       CL_CODE = jl.CL_CODE, 
       DIV_CODE = jl.DIV_CODE, 
       PRD_CODE = jl.PRD_CODE,
       CLIENT_REF = jl.JOB_CLI_REF,
       JOB_NUMBER = etd.JOB_NUMBER,
       JOB_COMPONENT_NBR = etd.JOB_COMPONENT_NBR,
       DP_TM_CODE = etd.DP_TM_CODE
  FROM EMP_TIME_DTL etd, JOB_LOG jl, #time_rows tr
 WHERE tr.ET_ID = etd.ET_ID 
   AND tr.ET_DTL_ID = etd.ET_DTL_ID
   AND tr.MAX_SEQ = etd.SEQ_NBR
   AND etd.JOB_NUMBER = jl.JOB_NUMBER

--UPDATE #time_rows
--  SET FNC_CAT = ( SELECT FNC_CODE 
--										 FROM EMP_TIME_DTL etd 
--										WHERE etd.ET_ID = ET_ID 
--											AND etd.ET_DTL_ID = ,
--			 CL_CODE = jl.CL_CODE, 
--			 DIV_CODE = jl.DIV_CODE, 
--			 PRD_CODE = jl.PRD_CODE,
--			 JOB_NUMBER = etd.JOB_NUMBER,
--			 JOB_COMPONENT_NBR = etd.JOB_COMPONENT_NBR,
--			 DP_TM_CODE = etd.DP_TM_CODE
--  FROM EMP_TIME_DTL etd, JOB_LOG jl, #time_rows tr
-- WHERE tr.ET_ID = etd.ET_ID 
--	 AND tr.ET_DTL_ID = etd.ET_DTL_ID
--	 AND tr.MAX_SEQ = etd.SEQ_NBR
--	 AND tr.JOB_NUMBER = jl.JOB_NUMBER

INSERT INTO #time_rows
     SELECT etn.ET_ID, etn.ET_DTL_ID, CATEGORY, SUM(EMP_HOURS), NULL, NULL, NULL, NULL, NULL, NULL, 
	    	DP_TM_CODE, 'N', 0, NULL, NULL, NULL
       FROM EMP_TIME_NP etn, EMP_TIME et
      WHERE et.ET_ID = etn.ET_ID
	AND EMP_CODE = @emp_code
	AND EMP_DATE = @emp_date
   GROUP BY etn.ET_ID, etn.ET_DTL_ID, CATEGORY, DP_TM_CODE

-- BJL - 11/23/03
UPDATE #time_rows
   SET START_TIME = etdc.START_TIME,
       END_TIME = etdc.END_TIME
  FROM EMP_TIME_DTL_CMTS etdc, #time_rows tr
 WHERE tr.ET_ID = etdc.ET_ID 
   AND tr.ET_DTL_ID = etdc.ET_DTL_ID

-- Determine if rows have been billed
UPDATE #time_rows
   SET EDIT_FLAG = 1
 WHERE EXISTS ( SELECT etd.AR_INV_NBR  
		  FROM EMP_TIME_DTL etd
		 WHERE etd.ET_ID = #time_rows.ET_ID
		   AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
		   AND etd.AR_INV_NBR IS NOT NULL
		   AND (etd.EDIT_FLAG = 0 OR etd.EDIT_FLAG IS NULL))

-- Determine if item is summarized
UPDATE #time_rows
   SET EDIT_FLAG = 2
 WHERE EDIT_FLAG = 1
   AND ( SELECT COUNT(1)
	   FROM EMP_TIME_DTL etd
	  WHERE etd.ET_ID = #time_rows.ET_ID
	    AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID ) > 1
	
-- Determine if item is a restricted AB flag
UPDATE #time_rows
   SET EDIT_FLAG = 3
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT AB_FLAG
		  FROM EMP_TIME_DTL etd
		 WHERE etd.ET_ID = #time_rows.ET_ID
		   AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
		   AND etd.AB_FLAG IN (1,3) )

-- Determine if item is selected for billing
UPDATE #time_rows
   SET EDIT_FLAG = 4
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT BILLING_USER
		  FROM EMP_TIME_DTL etd
		 WHERE etd.ET_ID = #time_rows.ET_ID
		   AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
		   AND BILLING_USER IS NOT NULL )

-- BJL - 11/23/03
-- Check if row has been approved
UPDATE #time_rows
   SET EDIT_FLAG = 6
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT ET_ID
		  		  FROM EMP_TIME et
		 		 WHERE et.ET_ID = #time_rows.ET_ID
		   		   AND APPR_FLAG = 1 )
   AND EXISTS ( SELECT * FROM AGENCY WHERE TIME_APPR_ACTIVE = 1 )

-- BJL - 11/23/03
-- Check if row is pending approval
UPDATE #time_rows
   SET EDIT_FLAG = 5
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT ET_ID
		  		  FROM EMP_TIME et
		 		 WHERE et.ET_ID = #time_rows.ET_ID
		   		   AND APPR_PENDING = 1 )
   AND EXISTS ( SELECT * FROM AGENCY WHERE TIME_APPR_ACTIVE = 1 )

end_tran:

SELECT *
  FROM #time_rows

DROP TABLE #time_rows
