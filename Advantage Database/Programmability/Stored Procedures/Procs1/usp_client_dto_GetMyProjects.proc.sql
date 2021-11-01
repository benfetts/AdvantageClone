﻿






















CREATE PROCEDURE [dbo].[usp_client_dto_GetMyProjects]
@ClientCode as VarChar(6),
@SortOrder as VarChar(1)
AS
Set NoCount On
CREATE TABLE #myprojects( 	
	ClientCode			varchar(6) NULL,
	DivCode			varchar(6) NULL,
	ProductCode			varchar(6) NULL,
	Job				VarChar(100) NULL,
	JobComp			VarChar(100) NULL,
	StartDate			DateTime NULL,
	DueDate			DateTime NULL,
	Status				VarChar(50) NULL,
	AE				varchar(100) NULL,
	AECode				varchar(6) NULL,
	JobNo				INT NULL, 
	JobCompNo			INT NULL, 
	TrafficCount			INT NULL
)


if @SortOrder = 'j' Begin
Insert INTO #myprojects
SELECT JOB_LOG.CL_CODE AS ClientCode, 
	JOB_LOG.DIV_CODE AS DivCode, 
	JOB_LOG.PRD_CODE AS ProductCode, 
	LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + JOB_LOG.JOB_DESC AS Job, 
	LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS JobComp, 
	JOB_COMPONENT.START_DATE AS StartDate, 
	JOB_COMPONENT.JOB_FIRST_USE_DATE AS DueDate, 
       	TRAFFIC.TRF_DESCRIPTION AS Status, 
	EMPLOYEE.EMP_FNAME + ' ' + EMPLOYEE.EMP_LNAME  AS AE, 
	JOB_COMPONENT.EMP_CODE as AECode,
	JOB_LOG.JOB_NUMBER as JobNo, 
	JOB_COMPONENT.JOB_COMPONENT_NBR as JobCompNo, 0
FROM   JOB_TRAFFIC_DET INNER JOIN
       JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
       JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
       JOB_LOG ON JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
       JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
       JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
       TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE INNER JOIN
       EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
WHERE  ((NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
       AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL))
       AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%')
GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + JOB_LOG.JOB_DESC,  JOB_LOG.JOB_NUMBER,
         LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.START_DATE, 
         JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, EMPLOYEE.EMP_FNAME + ' ' + EMPLOYEE.EMP_LNAME,
	 JOB_COMPONENT.EMP_CODE,        JOB_LOG.JOB_NUMBER,  JOB_COMPONENT.JOB_COMPONENT_NBR 
Order By JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR

Update #myprojects
	Set TrafficCount = (Select Count(*)
From JOB_TRAFFIC_DET
Where JOB_TRAFFIC_DET.JOB_NUMBER = #myprojects.JobNo
 AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #myprojects.JobCompNo
 AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
end

if @SortOrder = 'a' Begin
Insert INTO #myprojects
SELECT JOB_LOG.CL_CODE AS ClientCode, 
	JOB_LOG.DIV_CODE AS DivCode, 
	JOB_LOG.PRD_CODE AS ProductCode, 
	LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + JOB_LOG.JOB_DESC AS Job, 
	LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS JobComp, 
	JOB_COMPONENT.START_DATE AS StartDate, 
	JOB_COMPONENT.JOB_FIRST_USE_DATE AS DueDate, 
       	TRAFFIC.TRF_DESCRIPTION AS Status, 
	EMPLOYEE.EMP_FNAME + ' ' + EMPLOYEE.EMP_LNAME  AS AE, 
	JOB_COMPONENT.EMP_CODE as AECode,
	JOB_LOG.JOB_NUMBER as JobNo, 
	JOB_COMPONENT.JOB_COMPONENT_NBR as JobCompNo, 0
FROM   JOB_TRAFFIC_DET INNER JOIN
       JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
       JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
       JOB_LOG ON JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
       JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
       JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
       TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE INNER JOIN
       EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
WHERE  ((NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
       AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL))       AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%')
GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' + JOB_LOG.JOB_DESC,  JOB_LOG.JOB_NUMBER,
         LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.START_DATE, 
         JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, EMPLOYEE.EMP_FNAME + ' ' + EMPLOYEE.EMP_LNAME,
	 JOB_COMPONENT.EMP_CODE,        JOB_LOG.JOB_NUMBER,  JOB_COMPONENT.JOB_COMPONENT_NBR 
Order By JOB_COMPONENT.EMP_CODE, JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR

Update #myprojects
	Set TrafficCount = (Select Count(*)
From JOB_TRAFFIC_DET
Where JOB_TRAFFIC_DET.JOB_NUMBER = #myprojects.JobNo
 AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #myprojects.JobCompNo
 AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
end

select * from #myprojects

drop table #myprojects























