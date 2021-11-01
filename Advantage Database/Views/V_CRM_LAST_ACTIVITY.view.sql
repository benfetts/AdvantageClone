if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_CRM_LAST_ACTIVITY]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[V_CRM_LAST_ACTIVITY]
GO
CREATE VIEW V_CRM_LAST_ACTIVITY
WITH SCHEMABINDING 
AS

SELECT LastActivityDate, LastActivityType, LastActivitySubject, LastActivityBody, LastActivityEmployee, CL_CODE, DIV_CODE, PRD_CODE
FROM 
(SELECT GENERATED AS LastActivityDate,
			'Diary' AS LastActivityType,
			A.[SUBJECT] AS LastActivitySubject,
			CAST(A.BODY AS varchar(max)) AS LastActivityBody, 
			coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') AS LastActivityEmployee, A.CL_CODE, A.DIV_CODE, A.PRD_CODE
		 FROM dbo.[ALERT] A LEFT OUTER JOIN dbo.[EMPLOYEE_CLOAK] E ON A.EMP_CODE = E.EMP_CODE
		 WHERE A.ALERT_TYPE_ID = 11

		 UNION ALL

		 SELECT [START_TIME] AS LastActivityDate,
			'Scheduled Activity' AS LastActivityType,
	 		T.NON_TASK_DESC AS LastActivitySubject,
			T.NON_EMP_TASK_DESC AS LastActivityBody,
			coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') AS LastActivityEmployee, T.CL_CODE, T.DIV_CODE, T.PRD_CODE 
		 FROM [dbo].EMP_NON_TASKS T LEFT OUTER JOIN dbo.[EMPLOYEE_CLOAK] E ON T.EMP_CODE = E.EMP_CODE
		 WHERE T.[TYPE]='C' OR T.[TYPE]='M' OR T.[TYPE]='TD' OR T.[TYPE]='EL') TT

GO
