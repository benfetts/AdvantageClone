

























CREATE PROCEDURE [dbo].[usp_wv_dd_GetTrafficCodes] AS

SELECT     TRF_CODE AS Code,  TRF_CODE+ISNULL(' - '+TRF_DESCRIPTION ,'') AS Description, TRF_CODE+ISNULL(' - '+TRF_DESCRIPTION ,'') AS CodeDescription
FROM         TRAFFIC
WHERE     (INACTIVE_FLAG IS NULL) OR
                      (INACTIVE_FLAG = 0)

























