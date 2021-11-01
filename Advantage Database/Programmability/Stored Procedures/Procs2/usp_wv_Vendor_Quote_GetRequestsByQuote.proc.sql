

CREATE PROCEDURE [dbo].[usp_wv_Vendor_Quote_GetRequestsByQuote]
(
	@EstNo Int,
	@EstCompNo Int,
	@VendorQteNo Int,
	@QuoteNo Int,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @FncCode as varchar(6), @EstQuote int, @EstRev int, @NumberRecords int, @RowCount int

SELECT @sql = 'SELECT VENDOR_QTE_HDR.ESTIMATE_NUMBER, VENDOR_QTE_HDR.EST_COMPONENT_NBR, VENDOR_QTE_HDR.VENDOR_QTE_NBR, 
                      VENDOR_QTE_SPECS.EST_QUOTE_NBR, VENDOR_QTE_SPECS.EST_REV_NBR
FROM         VENDOR_QTE_HDR INNER JOIN
                      VENDOR_QTE_SPECS ON VENDOR_QTE_HDR.ESTIMATE_NUMBER = VENDOR_QTE_SPECS.ESTIMATE_NUMBER AND 
                      VENDOR_QTE_HDR.EST_COMPONENT_NBR = VENDOR_QTE_SPECS.EST_COMPONENT_NBR AND 
                      VENDOR_QTE_HDR.VENDOR_QTE_NBR = VENDOR_QTE_SPECS.VENDOR_QTE_NBR
WHERE     (VENDOR_QTE_HDR.ESTIMATE_NUMBER = @EstNo) AND (VENDOR_QTE_HDR.EST_COMPONENT_NBR = @EstCompNo) AND 
                      (VENDOR_QTE_SPECS.EST_QUOTE_NBR = @QuoteNo)'

SELECT @paramlist = '@EstNo Int, @EstCompNo Int, @QuoteNo Int, @UserID varchar(100)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EstNo, @EstCompNo, @QuoteNo, @UserID


--SELECT @NumberRecords = COUNT(*) FROM #rfq
--SET @RowCount = 1
--
--WHILE @RowCount <= @NumberRecords
--BEGIN
-- SELECT @EstQuote = EST_QUOTE_NBR, @EstRev = EST_REV_NBR, @FncCode = EST_FNC_CODE
-- FROM #rfq
-- WHERE RowID = @RowCount
--
--INSERT INTO #rfq3
--SELECT ESTIMATE_NUMBER, EST_COMPONENT_NBR, VENDOR_QTE_NBR, EST_FNC_CODE, FNC_NOTES 
--FROM VENDOR_QTE_FNC WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNo) AND (EST_FNC_CODE = @FncCode)
--
----UPDATE #rfq 
----SET QTY = (SELECT DISTINCT QTY FROM VENDOR_QTE_DTL WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNo) AND (EST_QUOTE_NBR = @EstQuote) AND (EST_REV_NBR = @EstRev) AND (EST_FNC_CODE = @FncCode))
----WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNo) AND (EST_QUOTE_NBR = @EstQuote) AND (EST_REV_NBR = @EstRev) AND (EST_FNC_CODE = @FncCode)
--
--SET @RowCount = @RowCount + 1
--END



