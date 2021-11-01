



















CREATE PROCEDURE [dbo].[usp_wv_getContactCodeID] 
@ContactCode VarChar(6),
@ClientCode Varchar(6),
@DivisionCode Varchar(6),
@ProductCode Varchar(6)
AS
--Select CDP_CONTACT_ID
--FROM CDP_CONTACT_HDR
--WHERE CONT_CODE = @ContactCode 
--AND CL_CODE = @ClientCode
 

Select CDP_CONTACT_HDR.CDP_CONTACT_ID
FROM CDP_CONTACT_HDR LEFT OUTER JOIN
                      dbo.CDP_CONTACT_DTL ON dbo.CDP_CONTACT_DTL.CDP_CONTACT_ID = dbo.CDP_CONTACT_HDR.CDP_CONTACT_ID
WHERE CONT_CODE = @ContactCode
AND CL_CODE = @ClientCode
AND (DIV_CODE = @DivisionCode OR DIV_CODE IS NULL)
AND (PRD_CODE = @ProductCode OR PRD_CODE IS NULL)

















