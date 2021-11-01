﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_QUOTE_VS_ACTUAL]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[V_QUOTE_VS_ACTUAL]
GO

CREATE VIEW [dbo].[V_QUOTE_VS_ACTUAL] ( JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE ) AS

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE
FROM dbo.PURCHASE_ORDER_DET
WHERE FNC_CODE IS NOT NULL
AND JOB_NUMBER IS NOT NULL
AND JOB_COMPONENT_NBR IS NOT NULL

UNION

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE
FROM dbo.INCOME_ONLY

UNION

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE
FROM dbo.AP_PRODUCTION

UNION

SELECT jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR, erd.FNC_CODE
FROM dbo.JOB_COMPONENT jc
	INNER JOIN dbo.ESTIMATE_REV_DET erd ON jc.ESTIMATE_NUMBER = erd.ESTIMATE_NUMBER AND jc.EST_COMPONENT_NBR = erd.EST_COMPONENT_NBR
	INNER JOIN dbo.ESTIMATE_APPROVAL ea ON erd.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER AND erd.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
													AND erd.EST_QUOTE_NBR = ea.EST_QUOTE_NBR AND erd.EST_REV_NBR = ea.EST_REVISION_NBR

UNION

SELECT jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR, erd.FNC_CODE
FROM dbo.JOB_COMPONENT jc
	INNER JOIN dbo.ESTIMATE_REV_DET erd ON jc.ESTIMATE_NUMBER = erd.ESTIMATE_NUMBER AND jc.EST_COMPONENT_NBR = erd.EST_COMPONENT_NBR
	INNER JOIN dbo.ESTIMATE_INT_APPR ea ON erd.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER AND erd.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
											AND erd.EST_QUOTE_NBR = ea.EST_QUOTE_NBR AND erd.EST_REV_NBR = ea.EST_REVISION_NBR
	LEFT OUTER JOIN (
		SELECT jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR
		FROM dbo.JOB_COMPONENT jc
			INNER JOIN dbo.ESTIMATE_REV_DET erd ON jc.ESTIMATE_NUMBER = erd.ESTIMATE_NUMBER AND jc.EST_COMPONENT_NBR = erd.EST_COMPONENT_NBR
			INNER JOIN dbo.ESTIMATE_APPROVAL ea ON erd.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER AND erd.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
													AND erd.EST_QUOTE_NBR = ea.EST_QUOTE_NBR AND erd.EST_REV_NBR = ea.EST_REVISION_NBR
		) approved ON approved.JOB_NUMBER = jc.JOB_NUMBER AND approved.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
WHERE approved.JOB_NUMBER IS NULL

UNION

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE
FROM dbo.EMP_TIME_DTL

UNION

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE
FROM dbo.ADVANCE_BILLING
WHERE ( AR_INV_NBR IS NOT NULL OR AB_FLAG = 3 )

UNION

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE
FROM dbo.CLIENT_OOP