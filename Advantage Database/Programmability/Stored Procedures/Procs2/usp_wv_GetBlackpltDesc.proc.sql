







CREATE PROCEDURE [dbo].[usp_wv_GetBlackpltDesc]
@BpCode varchar(6)
AS

SELECT BLACKPLT_VER_DESC
FROM BLACKPLT_VERSION
WHERE BLACKPLT_VER_CODE = @BpCode  




















