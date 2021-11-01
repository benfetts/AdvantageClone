/*****************************************************************
Gets Creative Brief Templates for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_CreativeBriefTmplts] 
AS

Set NoCount On

SELECT  CRTV_BRF_CODE AS Code, CRTV_BRF_CODE + ' - ' + CRTV_BRF_DEF_DESC  AS Description
FROM  dbo.CRTV_BRF_DEF
WHERE  ( ACTIVE_FLAG = 0 OR ACTIVE_FLAG IS NULL )
ORDER BY CRTV_BRF_CODE


