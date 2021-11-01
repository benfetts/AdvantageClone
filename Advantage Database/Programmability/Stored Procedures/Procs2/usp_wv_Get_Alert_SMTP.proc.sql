





/*****************************************************************
Webvantage
This Stored Procedure gets SMTP information from Agency table for email alerts
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_SMTP] 


AS

set nocount on

SELECT  SMTP_SERVER as SMTPServer, SMTP_SENDER as SMTPSender, SMTP_SENDER_PWD as SMTPPassword
from AGENCY




