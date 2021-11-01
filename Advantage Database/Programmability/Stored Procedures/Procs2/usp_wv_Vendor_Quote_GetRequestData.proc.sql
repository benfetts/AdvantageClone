

CREATE PROCEDURE [dbo].[usp_wv_Vendor_Quote_GetRequestData]
(
	@EstNo Int,
	@EstCompNo Int,
	@VendorQteNo Int,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)


SELECT     VENDOR_QTE_HDR.ESTIMATE_NUMBER, VENDOR_QTE_HDR.EST_COMPONENT_NBR, VENDOR_QTE_HDR.VENDOR_QTE_NBR, 
                      VENDOR_QTE_HDR.VENDOR_QTE_DESC, VN_QTE_MEMO, VENDOR_QTE_HDR.CREATE_DATE, VENDOR_QTE_HDR.CREATED_BY
FROM         VENDOR_QTE_HDR 
WHERE     (VENDOR_QTE_HDR.ESTIMATE_NUMBER = @EstNo) AND (VENDOR_QTE_HDR.EST_COMPONENT_NBR = @EstCompNo) AND (VENDOR_QTE_HDR.VENDOR_QTE_NBR = @VendorQteNo)




