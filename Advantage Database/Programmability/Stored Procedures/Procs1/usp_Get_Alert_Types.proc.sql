


























/*****************************************************************
Webvantage
This Stored Procedure gets all Category Types
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_Types] AS

SET NOCOUNT ON

Select ALERT_TYPE_ID, ALERT_TYPE_DESC 
From ALERT_TYPE
Order By ALERT_TYPE_DESC

























