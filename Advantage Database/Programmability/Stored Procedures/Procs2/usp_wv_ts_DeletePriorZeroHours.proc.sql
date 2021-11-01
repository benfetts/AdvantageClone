SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_DeletePriorZeroHours]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_DeletePriorZeroHours]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_DeletePriorZeroHours] /*WITH ENCRYPTION*/
@EMP_CODE VARCHAR(6),
@CUTOFF_DATE SMALLDATETIME
AS
/*=========== QUERY ===========*/

	DECLARE @ZERO_ROWS TABLE (ET_ID INT, ET_DTL_ID SMALLINT)

	INSERT INTO @ZERO_ROWS (ET_ID, ET_DTL_ID)
	SELECT 
		ETD.ET_ID, ETD.ET_DTL_ID
	FROM 
		EMP_TIME_DTL ETD
		INNER JOIN EMP_TIME ET ON ETD.ET_ID = ET.ET_ID
	WHERE
		(ETD.EMP_HOURS = 0 OR ETD.EMP_HOURS IS NULL)
		AND ETD.AR_INV_NBR IS NULL
		AND ETD.BILLING_USER IS NULL
		AND ETD.TOTAL_COST = 0
		AND ETD.TOTAL_BILL = 0
		AND ETD.EXT_MARKUP_AMT = 0
		AND ETD.EXT_STATE_RESALE = 0
		AND ETD.EXT_COUNTY_RESALE = 0
		AND ETD.EXT_CITY_RESALE = 0
		AND ETD.LINE_TOTAL = 0
		AND ET.EMP_CODE = @EMP_CODE
		AND ET.EMP_DATE < @CUTOFF_DATE
	;

	DELETE 
		EMP_TIME_DTL_CMTS
	FROM 
		EMP_TIME_DTL_CMTS ETDC 
		INNER JOIN @ZERO_ROWS ZR ON ETDC.ET_ID = ZR.ET_ID AND ETDC.ET_DTL_ID = ZR.ET_DTL_ID; 

	DELETE  
		EMP_TIME_DTL
	FROM 
		EMP_TIME_DTL ETD
		INNER JOIN @ZERO_ROWS ZR ON ETD.ET_ID = ZR.ET_ID AND ETD.ET_DTL_ID = ZR.ET_DTL_ID; 

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO