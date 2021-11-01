SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_Get_AlertLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_Get_AlertLevel]
GO

CREATE PROCEDURE [dbo].[usp_Get_AlertLevel] 
@AlertID Int,
@AlertLevel varchar(50)

AS

Declare @Product as varchar(100)
Declare @Division as varchar(100)
Declare @Job as varchar(100)
declare @JobComp as varchar(100)


SET NOCOUNT ON

if @AlertLevel = 'PR' begin
SELECT     ALERT_TYPE.ALERT_TYPE_DESC AS Type, ALERT_CATEGORY.ALERT_DESC AS Category, ALERT.SUBJECT AS Subject, ALERT.BODY AS Body, 
                  convert(varchar(25), ALERT.GENERATED) AS GenDate, ALERT.PRIORITY AS Priority, CLIENT.CL_NAME as Client, PRODUCT.PRD_DESCRIPTION as Product, DIVISION.DIV_NAME AS Division,
	    SEC_USER.USER_NAME as UserName,  @Job as Job, @JobComp as JobComp
FROM         ALERT INNER JOIN
                      ALERT_CATEGORY ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID INNER JOIN
                      ALERT_TYPE ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID INNER JOIN
                      CLIENT ON ALERT.CL_CODE = CLIENT.CL_CODE
INNER JOIN
                      PRODUCT ON ALERT.PRD_CODE = PRODUCT.PRD_CODE
INNER JOIN
                      DIVISION ON ALERT.DIV_CODE = DIVISION.DIV_CODE
INNER JOIN
                      SEC_USER ON UPPER(ALERT.ALERT_USER) = UPPER(SEC_USER.USER_CODE)
WHERE     (ALERT.ALERT_ID = @AlertID) and ALERT.ALERT_LEVEL = 'PR'
end
if @AlertLevel = 'DI' begin
SELECT     ALERT_TYPE.ALERT_TYPE_DESC AS Type, ALERT_CATEGORY.ALERT_DESC AS Category, ALERT.SUBJECT AS Subject, ALERT.BODY AS Body, 
                  convert(varchar(25), ALERT.GENERATED) AS GenDate, ALERT.PRIORITY AS Priority, CLIENT.CL_NAME as Client, DIVISION.DIV_NAME AS Division,
	    SEC_USER.USER_NAME as UserName, @Job as Job, @JobComp as JobComp, @Product as Product
FROM         ALERT INNER JOIN
                      ALERT_CATEGORY ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID INNER JOIN
                      ALERT_TYPE ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID INNER JOIN
                      CLIENT ON ALERT.CL_CODE = CLIENT.CL_CODE
INNER JOIN
                      DIVISION ON ALERT.DIV_CODE = DIVISION.DIV_CODE
INNER JOIN
                      SEC_USER ON UPPER(ALERT.ALERT_USER) = UPPER(SEC_USER.USER_CODE)
WHERE     (ALERT.ALERT_ID = @AlertID) and ALERT.ALERT_LEVEL = 'DI'
end
if @AlertLevel = 'CL' begin
SELECT     ALERT_TYPE.ALERT_TYPE_DESC AS Type, ALERT_CATEGORY.ALERT_DESC AS Category, ALERT.SUBJECT AS Subject, ALERT.BODY AS Body, 
                  convert(varchar(25), ALERT.GENERATED) AS GenDate, ALERT.PRIORITY AS Priority, CLIENT.CL_NAME as Client,  SEC_USER.USER_NAME as UserName, 
		@Job as Job, @JobComp as JobComp, @Product as Product, @Division as Division
FROM         ALERT INNER JOIN
                      ALERT_CATEGORY ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID INNER JOIN
                      ALERT_TYPE ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID INNER JOIN
                      CLIENT ON ALERT.CL_CODE = CLIENT.CL_CODE
inner join                      
	SEC_USER ON UPPER(ALERT.ALERT_USER) = UPPER(SEC_USER.USER_CODE)
WHERE     (ALERT.ALERT_ID = @AlertID) and ALERT.ALERT_LEVEL = 'CL'
end
if @AlertLevel = 'JO' begin
SELECT     ALERT_TYPE.ALERT_TYPE_DESC AS Type, ALERT_CATEGORY.ALERT_DESC AS Category, ALERT.SUBJECT AS Subject, ALERT.BODY AS Body, 
                  convert(varchar(25), ALERT.GENERATED) AS GenDate, ALERT.PRIORITY AS Priority, CLIENT.CL_NAME as Client, PRODUCT.PRD_DESCRIPTION as Product, DIVISION.DIV_NAME AS Division,
	    SEC_USER.USER_NAME as UserName,  JOB_LOG.JOB_DESC  as Job, @JobComp as JobComp
FROM         ALERT INNER JOIN
                      ALERT_CATEGORY ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID INNER JOIN
                      ALERT_TYPE ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID INNER JOIN
                      CLIENT ON ALERT.CL_CODE = CLIENT.CL_CODE
INNER JOIN
                      PRODUCT ON ALERT.PRD_CODE = PRODUCT.PRD_CODE
INNER JOIN
                      DIVISION ON ALERT.DIV_CODE = DIVISION.DIV_CODE
INNER JOIN
                      SEC_USER ON UPPER(ALERT.ALERT_USER) = UPPER(SEC_USER.USER_CODE)
INNER JOIN JOB_LOG 
ON JOB_LOG.CL_CODE = ALERT.CL_CODE and
JOB_LOG.DIV_CODE = ALERT.DIV_CODE and
JOB_LOG.PRD_CODE = ALERT.PRD_CODE and
JOB_LOG.JOB_NUMBER = ALERT.JOB_NUMBER
WHERE     (ALERT.ALERT_ID = @AlertID) and ALERT.ALERT_LEVEL = 'JO'
end
if @AlertLevel = 'JC' begin
SELECT     ALERT_TYPE.ALERT_TYPE_DESC AS Type, ALERT_CATEGORY.ALERT_DESC AS Category, ALERT.SUBJECT AS Subject, ALERT.BODY AS Body, 
                  convert(varchar(25), ALERT.GENERATED) AS GenDate, ALERT.PRIORITY AS Priority, CLIENT.CL_NAME as Client, PRODUCT.PRD_DESCRIPTION as Product, DIVISION.DIV_NAME AS Division,
	    SEC_USER.USER_NAME as UserName,  JOB_LOG.JOB_DESC  as Job,  JOB_COMPONENT.JOB_COMP_DESC as JobComp
FROM         ALERT INNER JOIN
                      ALERT_CATEGORY ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID INNER JOIN
                      ALERT_TYPE ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID INNER JOIN
                      CLIENT ON ALERT.CL_CODE = CLIENT.CL_CODE
INNER JOIN
                      PRODUCT ON ALERT.PRD_CODE = PRODUCT.PRD_CODE
INNER JOIN
                      DIVISION ON ALERT.DIV_CODE = DIVISION.DIV_CODE
INNER JOIN
                      SEC_USER ON UPPER(ALERT.ALERT_USER) = UPPER(SEC_USER.USER_CODE)
INNER JOIN JOB_LOG 
ON JOB_LOG.CL_CODE = ALERT.CL_CODE and
JOB_LOG.DIV_CODE = ALERT.DIV_CODE and
JOB_LOG.PRD_CODE = ALERT.PRD_CODE and
JOB_LOG.JOB_NUMBER = ALERT.JOB_NUMBER
INNER JOIN JOB_COMPONENT ON
JOB_COMPONENT.JOB_NUMBER = ALERT.JOB_NUMBER and
JOB_COMPONENT.JOB_COMPONENT_NBR = ALERT.JOB_COMPONENT_NBR
WHERE     (ALERT.ALERT_ID = @AlertID) and ALERT.ALERT_LEVEL = 'JC'
end
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

