SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_traffic_getjobheader]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_traffic_getjobheader]
GO
























CREATE PROCEDURE [dbo].[usp_wv_traffic_getjobheader]

@JobNumber int,
@JobComponent smallint

AS

SELECT cast(JOB_LOG.JOB_NUMBER as varchar(6)) + ' - ' + JOB_LOG.JOB_DESC as Job, cast(JOB_COMPONENT.JOB_COMPONENT_NBR as varchar(6)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC as [Job Comp],
CLIENT.CL_NAME as Client, DIVISION.DIV_NAME as Division, PRODUCT.PRD_DESCRIPTION as Product, JOB_COMPONENT.EMP_CODE as [AE]
FROM  JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
INNER JOIN CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE
INNER JOIN DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE
INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
WHERE JOB_LOG.JOB_NUMBER = @JobNumber and JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComponent























GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

