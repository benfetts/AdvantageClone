CREATE VIEW [dbo].[CP_PROJECT_LIST]
AS
SELECT     TOP 100 PERCENT [dbo].[JOB_LOG].[CL_CODE] AS ClientCode, [dbo].[JOB_LOG].[DIV_CODE] AS DivCode, [dbo].[JOB_LOG].[PRD_CODE] AS ProductCode, 
                      LTRIM(STR([dbo].[JOB_LOG].[JOB_NUMBER])) + ' - ' + [dbo].[JOB_LOG].[JOB_DESC] AS Job, LTRIM(STR([dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR])) 
                      + ' - ' + [dbo].[JOB_COMPONENT].[JOB_COMP_DESC] AS JobComp, [dbo].[JOB_COMPONENT].[START_DATE] AS StartDate, 
                      [dbo].[JOB_COMPONENT].[JOB_FIRST_USE_DATE] AS DueDate, [dbo].[TRAFFIC].[TRF_DESCRIPTION] AS Status, [dbo].[JOB_COMPONENT].[EMP_CODE] AS AECode, 
                      [dbo].[JOB_LOG].[JOB_NUMBER] AS JobNo, [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR] AS JobCompNo, 
                      dbo.CP_PROJECT_MEDIA_TRAFFIC_COUNT.TrafficCount
FROM         [dbo].[JOB_TRAFFIC] INNER JOIN
                      [dbo].[JOB_LOG] ON [dbo].[JOB_TRAFFIC].[JOB_NUMBER] = [dbo].[JOB_LOG].[JOB_NUMBER] INNER JOIN
                      [dbo].[JOB_COMPONENT] AS JOB_COMPONENT ON [dbo].[JOB_TRAFFIC].[JOB_NUMBER] = [dbo].[JOB_COMPONENT].[JOB_NUMBER] AND 
                      [dbo].[JOB_TRAFFIC].[JOB_COMPONENT_NBR] = [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR] INNER JOIN
                      [dbo].[TRAFFIC] ON [dbo].[JOB_TRAFFIC].[TRF_CODE] = [dbo].[TRAFFIC].[TRF_CODE] INNER JOIN
                      [dbo].[CP_PROJECT_MEDIA_TRAFFIC_COUNT] ON [dbo].[JOB_COMPONENT].[JOB_NUMBER] = dbo.CP_PROJECT_MEDIA_TRAFFIC_COUNT.JOB_NUMBER AND 
                      [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR] = dbo.CP_PROJECT_MEDIA_TRAFFIC_COUNT.JOB_COMPONENT_NBR
WHERE     (NOT ([dbo].[JOB_COMPONENT].[JOB_PROCESS_CONTRL] IN (6, 12))) AND ([dbo].[JOB_TRAFFIC].[COMPLETED_DATE] IS NULL) OR
                      (NOT ([dbo].[JOB_COMPONENT].[JOB_PROCESS_CONTRL] IN (6, 12))) AND ([dbo].[JOB_TRAFFIC].[COMPLETED_DATE] IS NULL)
GROUP BY [dbo].[JOB_LOG].[CL_CODE], [dbo].[JOB_LOG].[DIV_CODE], [dbo].[JOB_LOG].[PRD_CODE], LTRIM(STR([dbo].[JOB_LOG].[JOB_NUMBER])) 
                      + ' - ' + [dbo].[JOB_LOG].[JOB_DESC], [dbo].[JOB_LOG].[JOB_NUMBER], LTRIM(STR([dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR])) 
                      + ' - ' + [dbo].[JOB_COMPONENT].[JOB_COMP_DESC], [dbo].[JOB_COMPONENT].[START_DATE], [dbo].[JOB_COMPONENT].[JOB_FIRST_USE_DATE], 
                      [dbo].[TRAFFIC].[TRF_DESCRIPTION], [dbo].[JOB_COMPONENT].[EMP_CODE], [dbo].[JOB_LOG].[JOB_NUMBER], [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR], 
                      dbo.CP_PROJECT_MEDIA_TRAFFIC_COUNT.TrafficCount
ORDER BY [dbo].[JOB_LOG].[CL_CODE], [dbo].[JOB_LOG].[DIV_CODE], [dbo].[JOB_LOG].[PRD_CODE]
