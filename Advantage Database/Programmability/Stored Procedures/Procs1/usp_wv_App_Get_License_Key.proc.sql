

























--------------------------------------------------------------------------------------------------
-- Gets the lincense Key
--------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_wv_App_Get_License_Key] 
@LicenseKey VarChar(58) OUTPUT
AS

SET NOCOUNT ON

SELECT @LicenseKey = LICENSE_KEY
FROM AGENCY

























