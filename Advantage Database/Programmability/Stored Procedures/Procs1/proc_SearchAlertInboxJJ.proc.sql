if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proc_SearchAlertInboxJJ]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[proc_SearchAlertInboxJJ]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[proc_SearchAlertInboxJJ]
@SearchCriteria VARCHAR(100), 
@EmpCode VARCHAR(6),
@JobNum int,
@JobCompNum int

AS
SELECT     dbo.ALERT.ALERT_ID, dbo.ALERT.SUBJECT, dbo.ALERT.GENERATED, dbo.SEC_USER.USER_NAME, 
                      dbo.ALERT.PRIORITY, dbo.ALERT_TYPE.ALERT_TYPE_DESC AS TYPE, 
                      dbo.ALERT_CATEGORY.ALERT_DESC AS CATEGORY, dbo.ALERT_TYPE.ALERT_TYPE_ID, dbo.ALERT_CATEGORY.ALERT_CAT_ID,
                          (SELECT     COUNT(*) AS EXPR1
                            FROM          dbo.ALERT_ATTACHMENT
                            WHERE      (ALERT_ID = dbo.ALERT.ALERT_ID)) AS ATTACHMENTCOUNT, dbo.ALERT.ALERT_LEVEL, ISNULL(dbo.ALERT.OFFICE_CODE, '') 
                      AS OFFICE_CODE, ISNULL(dbo.ALERT.CL_CODE, '') AS CL_CODE, ISNULL(dbo.ALERT.DIV_CODE, '') AS DIV_CODE, ISNULL(dbo.ALERT.PRD_CODE, '') 
                      AS PRD_CODE, ISNULL(dbo.ALERT.CMP_CODE, '') AS CMP_CODE, dbo.ALERT.JOB_NUMBER, dbo.ALERT.JOB_COMPONENT_NBR, 
                      dbo.ALERT.EMP_CODE AS SENDER_EMP_CODE,  
                      dbo.CLIENT.CL_NAME, dbo.DIVISION.DIV_NAME, dbo.PRODUCT.PRD_DESCRIPTION, ISNULL(dbo.CAMPAIGN.CMP_NAME, '') AS CMP_NAME, 
                      dbo.ALERT.BODY, LOWER(dbo.ALERT.SUBJECT) AS LOWER_SUBJECT, LOWER(CAST(dbo.ALERT.BODY AS varchar)) AS LOWER_BODY, 
                      ISNULL(dbo.OFFICE.OFFICE_NAME, '') AS OFFICE_NAME, dbo.JOB_LOG.JOB_DESC, dbo.JOB_COMPONENT.JOB_COMP_DESC, 
                      dbo.ALERT.ALERT_USER, dbo.ALERT.CP_ALERT, dbo.ALERT.DUE_DATE
FROM         dbo.OFFICE RIGHT OUTER JOIN
                      dbo.ALERT INNER JOIN
                      dbo.ALERT_TYPE ON dbo.ALERT.ALERT_TYPE_ID = dbo.ALERT_TYPE.ALERT_TYPE_ID INNER JOIN
                      dbo.ALERT_CATEGORY ON dbo.ALERT.ALERT_CAT_ID = dbo.ALERT_CATEGORY.ALERT_CAT_ID LEFT OUTER JOIN
                      dbo.SEC_USER ON UPPER(dbo.ALERT.ALERT_USER) = UPPER(dbo.SEC_USER.USER_CODE) LEFT OUTER JOIN
                      dbo.JOB_COMPONENT ON dbo.ALERT.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND 
                      dbo.ALERT.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
                      dbo.JOB_LOG ON dbo.ALERT.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER ON 
                      dbo.OFFICE.OFFICE_CODE = dbo.ALERT.OFFICE_CODE LEFT OUTER JOIN
                      dbo.PRODUCT ON dbo.ALERT.CL_CODE = dbo.PRODUCT.CL_CODE AND dbo.ALERT.DIV_CODE = dbo.PRODUCT.DIV_CODE AND 
                      dbo.ALERT.PRD_CODE = dbo.PRODUCT.PRD_CODE LEFT OUTER JOIN
                      dbo.CAMPAIGN ON dbo.ALERT.CMP_IDENTIFIER = dbo.CAMPAIGN.CMP_IDENTIFIER LEFT OUTER JOIN
                      dbo.DIVISION ON dbo.ALERT.CL_CODE = dbo.DIVISION.CL_CODE AND dbo.ALERT.DIV_CODE = dbo.DIVISION.DIV_CODE LEFT OUTER JOIN
                      dbo.CLIENT ON dbo.ALERT.CL_CODE = dbo.CLIENT.CL_CODE
WHERE     ((ALERT.SUBJECT LIKE '%' + LOWER(@SearchCriteria) +'%') OR
(LOWER(USER_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%') OR (ALERT.BODY LIKE '%' + LOWER(@SearchCriteria)))
AND (ALERT.JOB_NUMBER = @JobNum) AND (ALERT.JOB_COMPONENT_NBR = @JobCompNum)
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

