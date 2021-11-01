

























CREATE PROCEDURE [dbo].[usp_wv_dd_GetTrafficCodes_Name] AS

SELECT     TRF_CODE AS Code,  TRF_CODE+ISNULL(' - '+TRF_DESCRIPTION ,'') AS Description, ISNULL(TRF_DESCRIPTION ,'') AS CodeDescription
FROM         TRAFFIC
WHERE     (INACTIVE_FLAG IS NULL) OR
                      (INACTIVE_FLAG = 0)
ORDER BY TRF_DESCRIPTION					  

























