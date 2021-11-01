


CREATE VIEW [dbo].[CP_GET_TASK_DETAILS]
AS
SELECT     [dbo].[JOB_LOG].[CL_CODE], [dbo].[CLIENT].[CL_NAME] AS CLIENT, [dbo].[JOB_LOG].[DIV_CODE], [dbo].[DIVISION].[DIV_NAME] AS DIVISION, 
                      [dbo].[JOB_LOG].[PRD_CODE], [dbo].[PRODUCT].[PRD_DESCRIPTION] AS PRODUCT, [dbo].[JOB_LOG].[JOB_NUMBER], [dbo].[JOB_LOG].[JOB_DESC] AS Job, 
                      [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR], [dbo].[JOB_COMPONENT].[JOB_COMP_DESC] AS JobComp, [dbo].[JOB_TRAFFIC_DET].[FNC_CODE], 
                      [dbo].[JOB_TRAFFIC_DET].[TASK_DESCRIPTION] AS Task, [dbo].[JOB_TRAFFIC_DET].[JOB_DUE_DATE] AS DueDate, 
                      [dbo].[JOB_TRAFFIC_DET].[JOB_REVISED_DATE] AS RevDueDate, [dbo].[JOB_TRAFFIC_DET].[DUE_TIME] AS DueTime, 
                      [dbo].[JOB_TRAFFIC_DET].[REVISED_DUE_TIME] AS RevDueTime, [dbo].[JOB_TRAFFIC_DET].[TASK_START_DATE] AS TaskStartDate, 
                      [dbo].[JOB_TRAFFIC_DET].[FNC_COMMENTS] AS Comments, [dbo].[JOB_TRAFFIC_DET].[TEMP_COMP_DATE] AS TempCompDate, 
                      [dbo].[JOB_TRAFFIC_DET].[JOB_HRS] AS HoursAllowed, ISNULL([dbo].[JOB_TRAFFIC_DET].[TASK_STATUS], 'P') AS TaskStatus, 
                      [dbo].[TRAFFIC_PHASE].[PHASE_DESC] AS Phase, [dbo].[JOB_COMPONENT].[START_DATE] AS JobStartDate, 
                      [dbo].[JOB_COMPONENT].[JOB_FIRST_USE_DATE] AS JobDueDate, [dbo].[TRAFFIC].[TRF_CODE], [dbo].[TRAFFIC].[TRF_DESCRIPTION] AS TrafficStatus, 
                      [dbo].[JOB_TRAFFIC].[TRF_COMMENTS] AS TrafficComments, '(' + [dbo].[JOB_COMPONENT].[EMP_CODE] + ') ' + ISNULL(dbo.EMPLOYEE.EMP_FNAME, '') 
                      + ' ' + ISNULL(dbo.EMPLOYEE.EMP_MI, '') + ' ' + ISNULL(dbo.EMPLOYEE.EMP_LNAME, '') AS AE
FROM         [dbo].[JOB_LOG] INNER JOIN
                      [dbo].[CLIENT] ON [dbo].[CLIENT].[CL_CODE] = [dbo].[JOB_LOG].[CL_CODE] INNER JOIN
                      [dbo].[DIVISION] ON [dbo].[DIVISION].[DIV_CODE] = [dbo].[JOB_LOG].[DIV_CODE] AND [dbo].[DIVISION].[CL_CODE] = [dbo].[JOB_LOG].[CL_CODE] INNER JOIN
                      [dbo].[PRODUCT] ON [dbo].[PRODUCT].[CL_CODE] = [dbo].[JOB_LOG].[CL_CODE] AND [dbo].[PRODUCT].[DIV_CODE] = [dbo].[JOB_LOG].[DIV_CODE] AND 
                      [dbo].[PRODUCT].[PRD_CODE] = [dbo].[JOB_LOG].[PRD_CODE] INNER JOIN
                      [dbo].[JOB_COMPONENT] ON [dbo].[JOB_LOG].[JOB_NUMBER] = [dbo].[JOB_COMPONENT].[JOB_NUMBER] INNER JOIN
                      [dbo].[JOB_TRAFFIC_DET] ON [dbo].[JOB_COMPONENT].[JOB_NUMBER] = [dbo].[JOB_TRAFFIC_DET].[JOB_NUMBER] AND 
                      [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR] = [dbo].[JOB_TRAFFIC_DET].[JOB_COMPONENT_NBR] LEFT OUTER JOIN
                      [dbo].[TRAFFIC_PHASE] ON [dbo].[JOB_TRAFFIC_DET].[TRAFFIC_PHASE_ID] = [dbo].[TRAFFIC_PHASE].[TRAFFIC_PHASE_ID] INNER JOIN
                      [dbo].[JOB_TRAFFIC] ON [dbo].[JOB_COMPONENT].[JOB_NUMBER] = [dbo].[JOB_TRAFFIC].[JOB_NUMBER] AND 
                      [dbo].[JOB_COMPONENT].[JOB_COMPONENT_NBR] = [dbo].[JOB_TRAFFIC].[JOB_COMPONENT_NBR] INNER JOIN
                      [dbo].[TRAFFIC] ON [dbo].[JOB_TRAFFIC].[TRF_CODE] = [dbo].[TRAFFIC].[TRF_CODE] LEFT OUTER JOIN
                      [dbo].[EMPLOYEE] ON [dbo].[JOB_COMPONENT].[EMP_CODE] = [dbo].[EMPLOYEE].[EMP_CODE]



