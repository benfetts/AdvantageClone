





CREATE PROCEDURE [dbo].[usp_wv_calendar_ddVendorRep]
@VendorCode varchar(20),
@VendorRepCode varchar(20)
AS

 SELECT * 
 FROM VEN_REP     
 WHERE VEN_REP.VN_CODE = @VendorCode and VEN_REP.VR_CODE = @VendorRepCode
                                                  




