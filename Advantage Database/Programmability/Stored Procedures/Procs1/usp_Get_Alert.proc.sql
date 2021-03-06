SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_Get_Alert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_Get_Alert]
GO






















/*****************************************************************
Webvantage
This Stored Procedure gets a single Alert by AlertID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert] 
@AlertID Int
AS

SET NOCOUNT ON

SELECT     ALERT_TYPE.ALERT_TYPE_DESC AS Type, ALERT_CATEGORY.ALERT_DESC AS Category, ALERT.SUBJECT AS Subject, ALERT.BODY AS Body, 
                  convert(varchar(25), ALERT.GENERATED) AS GenDate, ALERT.PRIORITY AS Priority, CLIENT.CL_NAME + '/' + PRODUCT.PRD_DESCRIPTION + '/' + DIVISION.DIV_NAME AS Client,
	    SEC_USER.USER_NAME as UserName
FROM ALERT 
	INNER JOIN ALERT_CATEGORY 
		ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID 
	INNER JOIN ALERT_TYPE 
		ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID 
	INNER JOIN CLIENT 
		ON ALERT.CL_CODE = CLIENT.CL_CODE
	INNER JOIN PRODUCT 
		ON ALERT.PRD_CODE = PRODUCT.PRD_CODE
		AND ALERT.DIV_CODE = PRODUCT.DIV_CODE
		AND ALERT.CL_CODE = PRODUCT.CL_CODE
	INNER JOIN DIVISION 
		ON ALERT.DIV_CODE = DIVISION.DIV_CODE
		AND ALERT.CL_CODE = DIVISION.CL_CODE
	INNER JOIN SEC_USER 
		ON UPPER(ALERT.ALERT_USER) = UPPER(SEC_USER.USER_CODE)
WHERE     (ALERT.ALERT_ID = @AlertID)





















GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

