﻿
CREATE VIEW [dbo].[WV_Sec_Sum_By_Client]
AS
SELECT     dbo.JOB_LOG.CL_CODE, dbo.JOB_LOG.DIV_CODE, dbo.JOB_LOG.PRD_CODE, dbo.CLIENT.CL_NAME AS Client, dbo.DIVISION.DIV_NAME AS Division, 
                      dbo.PRODUCT.PRD_DESCRIPTION AS Product, dbo.JOB_LOG.JOB_NUMBER, dbo.JOB_LOG.OFFICE_CODE, dbo.JOB_LOG.JOB_DESC, 
                      dbo.JOB_LOG.JOB_CLI_REF,dbo.JOB_COMPONENT.JOB_COMPONENT_NBR, dbo.JOB_COMPONENT.JOB_COMP_DESC, dbo.JOB_COMPONENT.JOB_PROCESS_CONTRL, 
                      dbo.JOB_COMPONENT.JOB_COMP_DATE, dbo.EMPLOYEE.EMP_CODE, 
                      dbo.EMPLOYEE.EMP_FNAME + ' ' + dbo.EMPLOYEE.EMP_LNAME AS [Account Executive],
					  CONVERT(CHAR(10),dbo.JOB_COMPONENT.START_DATE, 101) AS [Start Date],
					  dbo.JOB_COMPONENT.JOB_FIRST_USE_DATE, dbo.JOB_LOG.USER_ID AS [User ID], 
                      dbo.CLIENT.CL_NAME + ' - ' + dbo.DIVISION.DIV_NAME + ' - ' + dbo.PRODUCT.PRD_DESCRIPTION AS CDP, dbo.JOB_LOG.SC_CODE, 
                      dbo.SALES_CLASS.SC_DESCRIPTION, dbo.JOB_TRAFFIC.COMPLETED_DATE, dbo.JOB_TRAFFIC.ROWID,dbo.JOB_TRAFFIC.TRF_COMMENTS, 
                      dbo.JOB_COMPONENT.TRF_SCHEDULE_REQ,dbo.JOB_TYPE.JT_CODE,dbo.JOB_TYPE.JT_DESC,
					  dbo.TRAFFIC.TRF_CODE,dbo.TRAFFIC.TRF_DESCRIPTION,dbo.JOB_COMPONENT.ESTIMATE_NUMBER,
					  dbo.ESTIMATE_APPROVAL.JOB_NUMBER AS EJobNum,dbo.ESTIMATE_APPROVAL.JOB_COMPONENT_NBR AS EJobComNum
					--dbo.JOB_TRAFFIC_DET.FNC_CODE,dbo.JOB_TRAFFIC_DET.JOB_REVISED_DATE,dbo.JOB_TRAFFIC_DET.FNC_COMMENTS
FROM         dbo.JOB_LOG INNER JOIN
                      dbo.JOB_COMPONENT ON dbo.JOB_LOG.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER INNER JOIN
                      dbo.EMPLOYEE ON dbo.JOB_COMPONENT.EMP_CODE = dbo.EMPLOYEE.EMP_CODE LEFT OUTER JOIN
					  dbo.JOB_TYPE ON dbo.JOB_COMPONENT.JT_CODE=dbo.JOB_TYPE.JT_CODE INNER JOIN
                      dbo.CLIENT ON dbo.JOB_LOG.CL_CODE = dbo.CLIENT.CL_CODE INNER JOIN
                      dbo.PRODUCT ON dbo.JOB_LOG.CL_CODE = dbo.PRODUCT.CL_CODE AND dbo.JOB_LOG.DIV_CODE = dbo.PRODUCT.DIV_CODE AND 
                      dbo.JOB_LOG.PRD_CODE = dbo.PRODUCT.PRD_CODE INNER JOIN
                      dbo.DIVISION ON dbo.JOB_LOG.CL_CODE = dbo.DIVISION.CL_CODE AND dbo.JOB_LOG.DIV_CODE = dbo.DIVISION.DIV_CODE INNER JOIN
					  dbo.SEC_CLIENT ON dbo.JOB_LOG.CL_CODE = dbo.SEC_CLIENT.CL_CODE AND dbo.JOB_LOG.DIV_CODE = dbo.SEC_CLIENT.DIV_CODE AND 
                      dbo.JOB_LOG.PRD_CODE = dbo.SEC_CLIENT.PRD_CODE INNER JOIN
                      dbo.SALES_CLASS ON dbo.JOB_LOG.SC_CODE = dbo.SALES_CLASS.SC_CODE INNER JOIN
                      dbo.JOB_TRAFFIC ON dbo.JOB_LOG.JOB_NUMBER = dbo.JOB_TRAFFIC.JOB_NUMBER AND
					  dbo.JOB_COMPONENT.JOB_COMPONENT_NBR = dbo.JOB_TRAFFIC.JOB_COMPONENT_NBR
					  --INNER JOIN dbo.JOB_TRAFFIC_DET on dbo.JOB_TRAFFIC.JOB_NUMBER=dbo.JOB_TRAFFIC_DET.JOB_NUMBER
					  --AND dbo.JOB_TRAFFIC.JOB_COMPONENT_NBR=dbo.JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
					  LEFT OUTER JOIN dbo.TRAFFIC on dbo.JOB_TRAFFIC.TRF_CODE=dbo.TRAFFIC.TRF_CODE
					  LEFT OUTER JOIN dbo.ESTIMATE_APPROVAL on dbo.JOB_COMPONENT.JOB_NUMBER=dbo.ESTIMATE_APPROVAL.JOB_NUMBER
					  AND dbo.JOB_COMPONENT.JOB_COMPONENT_NBR=dbo.ESTIMATE_APPROVAL.JOB_COMPONENT_NBR
WHERE				  (dbo.JOB_COMPONENT.JOB_PROCESS_CONTRL <> 6 and dbo.JOB_COMPONENT.JOB_PROCESS_CONTRL <>12)
					  AND dbo.JOB_TRAFFIC.COMPLETED_DATE IS NULL
					  --AND dbo.JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL
					  --order by dbo.JOB_TRAFFIC_DET.JOB_ORDER,dbo.JOB_TRAFFIC_DET.SEQ_NBR


--elect dbo.JOB_TRAFFIC_DET.FNC_CODE from dbo.JOB_TRAFFIC_DET
