


































/*****************************************************************
Webvantage
This Stored Procedure gets a Alert keywords by AttachmentID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_Keywords] 
@AdvantageID Int
AS

declare @T_Alertkeywords table (intCount int identity (1,1), keywordID  int, AlertID  int, AdvantageID  int, keyword  varchar(100))


insert into @T_Alertkeywords (keywordID, AlertID, AdvantageID, keyword)
select A.keywordID, A.AlertID, A.AdvantageID, A.keyword from
(SELECT top 1000 ALERT_DOCUMENT_KEYWORD.KEYWORD_ID AS keywordID,  ALERT_DOCUMENT_KEYWORD.ALERT_ID as AlertID,
ALERT_DOCUMENT_KEYWORD.ADVANTAGE_ID as AdvantageID, ALERT_DOCUMENT_KEYWORD.KEYWORD as keyword
FROM        ALERT_DOCUMENT_KEYWORD 
WHERE     (ALERT_DOCUMENT_KEYWORD.ADVANTAGE_ID = @AdvantageID)) A


select * from @T_Alertkeywords
order by intCount desc


































