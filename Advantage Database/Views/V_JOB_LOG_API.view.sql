/****** Object:  View [dbo].[V_JOB_LOG_API]    Script Date: 11/21/2017 9:41:15 AM ******/

IF EXISTS (SELECT * FROM sys.views WHERE name = 'V_JOB_LOG_API' AND type = 'v')

DROP VIEW [dbo].[V_JOB_LOG_API]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_JOB_LOG_API]

WITH SCHEMABINDING
AS

	SELECT 
		dbo.JOB_LOG.CL_CODE,  
		dbo.CLIENT.CL_NAME, 
		dbo.JOB_LOG.DIV_CODE,
		dbo.DIVISION.DIV_NAME, 
		dbo.JOB_LOG.PRD_CODE, 
		dbo.PRODUCT.PRD_DESCRIPTION, 
		dbo.JOB_LOG.JOB_NUMBER, 
		dbo.JOB_LOG.JOB_DESC, 
		dbo.JOB_LOG.OFFICE_CODE, 
		dbo.OFFICE.OFFICE_NAME,
		[COMP_OPEN] = ISNULL(JO.[IS_OPEN], 0),
		dbo.JOB_LOG.CMP_IDENTIFIER,
		dbo.CAMPAIGN.CMP_NAME,
		dbo.JOB_LOG.CREATE_DATE
	FROM 
		dbo.JOB_LOG INNER JOIN
		dbo.CLIENT ON dbo.JOB_LOG.CL_CODE = dbo.CLIENT.CL_CODE INNER JOIN
		dbo.PRODUCT ON dbo.JOB_LOG.CL_CODE = dbo.PRODUCT.CL_CODE AND dbo.JOB_LOG.DIV_CODE = dbo.PRODUCT.DIV_CODE AND dbo.JOB_LOG.PRD_CODE = dbo.PRODUCT.PRD_CODE INNER JOIN
		dbo.DIVISION ON dbo.JOB_LOG.CL_CODE = dbo.DIVISION.CL_CODE AND dbo.JOB_LOG.DIV_CODE = dbo.DIVISION.DIV_CODE LEFT OUTER JOIN
		dbo.OFFICE ON dbo.JOB_LOG.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE LEFT OUTER JOIN
		dbo.CAMPAIGN ON dbo.JOB_LOG.CMP_IDENTIFIER = dbo.CAMPAIGN.CMP_IDENTIFIER LEFT OUTER JOIN
		(SELECT 
			JOB_NUMBER, 
			[IS_OPEN] = MAX(CASE WHEN JOB_PROCESS_CONTRL <> 6 AND JOB_PROCESS_CONTRL <> 12 THEN 1 ELSE 0 END)
		FROM 
			dbo.JOB_COMPONENT 
		GROUP BY
			JOB_NUMBER) AS JO ON JO.JOB_NUMBER = JOB_LOG.JOB_NUMBER



GO


