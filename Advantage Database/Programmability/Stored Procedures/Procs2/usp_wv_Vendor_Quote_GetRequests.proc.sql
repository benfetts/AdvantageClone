

CREATE PROCEDURE [dbo].[usp_wv_Vendor_Quote_GetRequests]
(
	@EstNo Int,
	@EstCompNo Int,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @VendorQteNbr as int, @Submit as int, @Reply int, @Approve int, @NumberRecords int, @RowCount int, @Vend int

CREATE TABLE #rfq(
	RowID int IDENTITY(1, 1), 
	ESTIMATE_NUMBER int,
	EST_COMPONENT_NBR smallint,
	VENDOR_QTE_NBR int,
	--RFQ varchar(20),
	VENDOR_QTE_DESC varchar(60),	
	CREATE_DATE smalldatetime,
	SUBMITTED varchar(10),
	REPLIES varchar(10),
	APPROVED bit)

INSERT INTO #rfq
SELECT     VENDOR_QTE_HDR.ESTIMATE_NUMBER, VENDOR_QTE_HDR.EST_COMPONENT_NBR, VENDOR_QTE_HDR.VENDOR_QTE_NBR, 
                      VENDOR_QTE_HDR.VENDOR_QTE_DESC, VENDOR_QTE_HDR.CREATE_DATE, '', '', 0
FROM         VENDOR_QTE_HDR 
WHERE     (VENDOR_QTE_HDR.ESTIMATE_NUMBER = @EstNo) AND (VENDOR_QTE_HDR.EST_COMPONENT_NBR = @EstCompNo)



SELECT @NumberRecords = COUNT(*) FROM #rfq
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @VendorQteNbr = VENDOR_QTE_NBR
 FROM #rfq
 WHERE RowID = @RowCount

 SELECT @Vend = COUNT(*)
 FROM VENDOR_QTE_VEN
 WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNbr) 

 if @Vend > 0
	Begin
		SELECT @Submit = COUNT(*) 
		FROM VENDOR_QTE_VEN
		WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNbr) AND (DISPATCH_DATE IS NULL)

		SELECT @Reply = COUNT(*) 
		FROM VENDOR_QTE_VEN
		WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNbr) AND (REPLY_DATE IS NULL)
	End
 Else
	Begin
		SET @Submit = -1
		SET @Reply = -1
	End
 

 SELECT @Approve = COUNT(*) 
 FROM VENDOR_QTE_DTL
 WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNbr) AND (APPROVED_FLAG = 1)
 
 --SELECT @Submit

UPDATE #rfq 
SET SUBMITTED = CASE WHEN @Submit = -1 THEN 'No' 
			         WHEN @Submit > 0 AND @Submit = @Vend THEN 'No' 
					 WHEN @Submit > 0 AND @Submit <> @Vend THEN 'Partial'
					 ELSE 'All' END, 
	REPLIES = CASE WHEN @Reply = -1 THEN 'No'
				   WHEN @Reply > 0 AND @Reply = @Vend THEN 'No' 
				   WHEN @Reply > 0 AND @Reply <> @Vend THEN 'Partial' 
				   ELSE 'All' END,
APPROVED = CASE WHEN @Approve > 0 THEN 1 ELSE 0 END
WHERE (ESTIMATE_NUMBER = @EstNo) AND (EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_NBR = @VendorQteNbr)

SET @RowCount = @RowCount + 1
END

SELECT * FROM #rfq


