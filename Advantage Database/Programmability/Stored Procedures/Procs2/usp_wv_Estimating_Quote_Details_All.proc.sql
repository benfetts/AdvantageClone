






















CREATE PROCEDURE [dbo].[usp_wv_Estimating_Quote_Details_All] 
@EstNo Int,
@EstCompNo Int
AS
SELECT     ESTIMATE_QUOTE.ESTIMATE_NUMBER, ESTIMATE_QUOTE.EST_COMPONENT_NBR, ESTIMATE_QUOTE.EST_QUOTE_NBR, 
                      ESTIMATE_QUOTE.EST_QUOTE_DESC, ESTIMATE_REV.EST_REV_NBR, ESTIMATE_REV_DET.SEQ_NBR, 
                      ESTIMATE_REV_DET.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, ISNULL(ESTIMATE_REV_DET.LINE_TOTAL, 0.00) as LINE_TOTAL
FROM         ESTIMATE_QUOTE INNER JOIN
                      ESTIMATE_REV ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                      ESTIMATE_QUOTE.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                      ESTIMATE_COMPONENT ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR INNER JOIN
                      ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER INNER JOIN
                      ESTIMATE_REV_DET ON ESTIMATE_REV.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER AND 
                      ESTIMATE_REV.EST_COMPONENT_NBR = ESTIMATE_REV_DET.EST_COMPONENT_NBR AND 
                      ESTIMATE_REV.EST_QUOTE_NBR = ESTIMATE_REV_DET.EST_QUOTE_NBR AND 
                      ESTIMATE_REV.EST_REV_NBR = ESTIMATE_REV_DET.EST_REV_NBR INNER JOIN
                      FUNCTIONS ON ESTIMATE_REV_DET.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
                      JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR
WHERE     (ESTIMATE_QUOTE.ESTIMATE_NUMBER = @EstNo) AND (ESTIMATE_QUOTE.EST_COMPONENT_NBR = @EstCompNo)
ORDER BY ESTIMATE_QUOTE.EST_QUOTE_NBR, ESTIMATE_REV_DET.SEQ_NBR

SELECT     ESTIMATE_REV_DET.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION
FROM         ESTIMATE_QUOTE INNER JOIN
                      ESTIMATE_REV ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                      ESTIMATE_QUOTE.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                      ESTIMATE_COMPONENT ON ESTIMATE_QUOTE.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_QUOTE.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR INNER JOIN
                      ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER INNER JOIN
                      ESTIMATE_REV_DET ON ESTIMATE_REV.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER AND 
                      ESTIMATE_REV.EST_COMPONENT_NBR = ESTIMATE_REV_DET.EST_COMPONENT_NBR AND 
                      ESTIMATE_REV.EST_QUOTE_NBR = ESTIMATE_REV_DET.EST_QUOTE_NBR AND 
                      ESTIMATE_REV.EST_REV_NBR = ESTIMATE_REV_DET.EST_REV_NBR INNER JOIN
                      FUNCTIONS ON ESTIMATE_REV_DET.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
                      JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
                      ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR
WHERE     (ESTIMATE_QUOTE.ESTIMATE_NUMBER = @EstNo) AND (ESTIMATE_QUOTE.EST_COMPONENT_NBR = @EstCompNo)
		--AND (ESTIMATE_QUOTE.EST_QUOTE_NBR = @QuoteNo) AND (ESTIMATE_REV.EST_REV_NBR = @RevNo)
GROUP BY ESTIMATE_REV_DET.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION





















