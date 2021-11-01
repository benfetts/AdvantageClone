





/*****************************************************************
Webvantage
This Stored Procedure gets a Alert Document by AdvantageID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_Document] 
@AdvantageID Int
AS

set nocount on

SELECT ALERT_DOCUMENT.NAME AS Name, ALERT_DOCUMENT.LOCATION AS Location
FROM        ALERT_DOCUMENT
WHERE    ALERT_DOCUMENT.ADVANTAGE_ID = @AdvantageID




