




CREATE PROCEDURE [dbo].[usp_wv_CopyCreativeBriefJobComp] 
@CRTV_BRF_CODE 	VARCHAR(6),
@JOB_NBR	INTEGER,
@COMP_NBR	SMALLINT,
@JOB_NBR_COPY INTEGER,
@COMP_NBR_COPY SMALLINT,
@USERID		VARCHAR(100),
@CREATE_DATE SMALLDATETIME

AS

--CREATE TABLE #CRV_TMP (
--	CRTV_BRF_DTL_ID INTEGER IDENTITY (1, 1) NOT NULL, 
--	CRTV_BRF_LVL3_ID SMALLINT
--)
--
--
--INSERT INTO #CRV_TMP
--SELECT CB3.CRTV_BRF_LVL3_ID
--FROM CRTV_BRF_DEF CBD
--	INNER JOIN CRTV_BRF_LVL1 CB1 ON CBD.CRTV_BRF_DEF_ID = CB1.CRTV_BRF_DEF_ID
--	INNER JOIN CRTV_BRF_LVL2 CB2 ON CB2.CRTV_BRF_LVL1_ID = CB1.CRTV_BRF_LVL1_ID
--	INNER JOIN CRTV_BRF_LVL3 CB3 ON CB3.CRTV_BRF_LVL2_ID = CB2.CRTV_BRF_LVL2_ID
--WHERE CBD.CRTV_BRF_CODE = @CRTV_BRF_CODE


INSERT INTO CRTV_BRF_DTL 
(CRTV_BRF_DTL_ID, CRTV_BRF_DTL_DESC, JOB_NUMBER, JOB_COMPONENT_NBR, CRTV_BRF_LVL3_ID, DTL_ORDER, CREATED_BY, CREATE_DATE)
SELECT CRTV_BRF_DTL_ID, CRTV_BRF_DTL_DESC, @JOB_NBR, @COMP_NBR, CRTV_BRF_LVL3_ID, DTL_ORDER, @USERID, @CREATE_DATE
FROM CRTV_BRF_DTL
WHERE JOB_NUMBER = @JOB_NBR_COPY AND JOB_COMPONENT_NBR = @COMP_NBR_COPY




