

CREATE PROCEDURE [dbo].[usp_wv_Vendor_Quote_GetRequestNum]
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


SELECT ISNULL(MAX(VENDOR_QTE_NBR),0) + 1 
FROM VENDOR_QTE_HDR
WHERE (VENDOR_QTE_HDR.ESTIMATE_NUMBER = @EstNo) AND (VENDOR_QTE_HDR.EST_COMPONENT_NBR = @EstCompNo)




