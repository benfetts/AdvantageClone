

























--------------------------------------------------------------------------------------------------
-- Gets The DB Version
--------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_wv_App_Get_Version] 
@Version VarChar(15) OUTPUT
AS

SET NOCOUNT ON

SELECT @Version = VERSION_ID
FROM ADVAN_UPDATE

























