IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_crm_load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_crm_load]
GO

CREATE PROCEDURE [dbo].[advsp_crm_load]
	@UserCode varchar(100)
AS
BEGIN

	SET NOCOUNT ON
	
	DECLARE @OfficeCount AS INTEGER		

	DECLARE @HasSecurityRestrictions bit
	DECLARE @EMP_CODE AS varchar(6)
	DECLARE @HasMyObjectDefRestrictions bit
	DECLARE
			@RESTRICT_ALERT_GROUP BIT,
			@RESTRICT_SCHEDULE_ASSIGNMENTS BIT,
			@RESTRICT_SCHEDULE_MANAGER BIT,
			@RESTRICT_TASK_ASSIGNEES BIT,
			@RESTRICT_ACCOUNT_EXECUTIVE BIT,
			@AGENCY_MANAGER_COLUMN VARCHAR(40),
			@JOB_TRAFFIC_MANAGER_COLUMN VARCHAR(40),
			@HAS_ACTIVE_RESTRICTION BIT,
			@NEEDS_OR BIT
		
		SELECT 
			@RESTRICT_ALERT_GROUP = A.ALERT_GROUP,
			@RESTRICT_SCHEDULE_ASSIGNMENTS = A.SCHEDULE_ASSIGNMENTS,
			@RESTRICT_SCHEDULE_MANAGER = A.SCHEDULE_MANAGER,
			@RESTRICT_TASK_ASSIGNEES = A.TASK_ASSIGNEES,
			@RESTRICT_ACCOUNT_EXECUTIVE = A.ACCOUNT_EXECUTIVE,
			@AGENCY_MANAGER_COLUMN = A.AGENCY_MANAGER_COLUMN,
			@JOB_TRAFFIC_MANAGER_COLUMN = A.JOB_TRAFFIC_MANAGER_COLUMN,
			@HAS_ACTIVE_RESTRICTION = A.HAS_ACTIVE_RESTRICTION
		FROM [dbo].[fn_my_objects_get_static_restrictions](12) AS A;
	
	SET @EMP_CODE = ''
	
	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserCode)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE
	
	IF EXISTS(SELECT [USER_ID] FROM [dbo].[SEC_CLIENT] WHERE UPPER([USER_ID]) = UPPER(@UserCode)) BEGIN

		SET @HasSecurityRestrictions = 1
		
	END ELSE BEGIN

		SET @HasSecurityRestrictions = 0

	END

	IF EXISTS(SELECT CL_CODE FROM [dbo].[fn_my_objects_get_dynamic_restrictions](12, @EMP_CODE)) BEGIN

		SET @HasMyObjectDefRestrictions = 1

	END ELSE BEGIN

		SET @HasMyObjectDefRestrictions = 0

	END

	IF @HasMyObjectDefRestrictions = 0 and @RESTRICT_ACCOUNT_EXECUTIVE = 1
	Begin
		if @OfficeCount = 0
		Begin
			SELECT 
				[ClientCode] = P.CL_CODE,  
				[ClientName] = C.CL_NAME, 
				[DivisionCode] = P.DIV_CODE,
				[DivisionName] = D.DIV_NAME, 
				[ProductCode] = P.PRD_CODE, 
				[ProductName] = P.PRD_DESCRIPTION, 
				[OfficeCode] = P.OFFICE_CODE, 
				[OfficeName] = O.OFFICE_NAME, 
				[DefaultAccountExecutiveCode] = AE.EMP_CODE, 
				[DefaultAccountExecutive] = AE.[EMP_FML], 
				[NewBusiness] = CAST(ISNULL(C.NEW_BUSINESS, 0) AS bit),
				[IsInactive] = CAST(CASE WHEN ISNULL(C.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(D.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(P.ACTIVE_FLAG, 0) = 0 THEN 1 
										 ELSE 0 END AS bit),
				[LastActivityDate] = LA.LastActivityDate, 
				[LastActivityType] = LA.LastActivityType, 
				[LastActivitySubject] = LA.LastActivitySubject,
				[LastContactDate] = A.LAST_CONTACT_DATE
			FROM
				[dbo].[PRODUCT] AS P INNER JOIN
				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = P.OFFICE_CODE INNER JOIN
				[dbo].[CLIENT] AS C ON C.CL_CODE = P.CL_CODE INNER JOIN
				[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND 
										 D.DIV_CODE = P.DIV_CODE LEFT OUTER JOIN
				[dbo].[SEC_CLIENT] AS SC ON SC.CL_CODE = P.CL_CODE AND 
											SC.DIV_CODE = P.DIV_CODE AND 
											SC.PRD_CODE = P.PRD_CODE AND 
											SC.[USER_ID] = @UserCode INNER JOIN
				[dbo].[fn_my_objects_get_dynamic_restrictions](12, @EMP_CODE) AS [MODEF] ON [MODEF].CL_CODE = P.CL_CODE AND 
																							[MODEF].DIV_CODE = P.DIV_CODE AND 
																							[MODEF].PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				[dbo].[ACTIVITY] AS A ON A.CL_CODE = P.CL_CODE AND 
										 A.DIV_CODE = P.DIV_CODE AND 
										 A.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT
					PDAE.CL_CODE,
					PDAE.DIV_CODE,
					PDAE.PRD_CODE,
					PDAE.EMP_CODE,
					PDAE.[EMP_FML]
				 FROM
					(SELECT 
						ID = ROW_NUMBER() OVER (PARTITION BY PAE.CL_CODE, PAE.DIV_CODE, PAE.PRD_CODE ORDER BY PAE.EMP_CODE DESC),
						PAE.CL_CODE,
						PAE.DIV_CODE,
						PAE.PRD_CODE,
						PAE.EMP_CODE,
						[EMP_FML] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') 
					FROM 
						[dbo].[ACCOUNT_EXECUTIVE] AS PAE INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] EMP ON EMP.EMP_CODE = PAE.EMP_CODE
					WHERE
						PAE.DEFAULT_AE = 1 AND
						(PAE.INACTIVE_FLAG IS NULL OR 
						 PAE.INACTIVE_FLAG = 0)) AS PDAE
				 WHERE 
					PDAE.ID = 1) AS AE ON AE.CL_CODE = P.CL_CODE AND 
										  AE.DIV_CODE = P.DIV_CODE AND 
										  AE.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT 
					LA1.LastActivityDate, 
					LA1.LastActivityType, 
					LA1.LastActivitySubject, 
					LA1.LastActivityBody, 
					LA1.LastActivityEmployee, 
					LA1.CL_CODE, 
					LA1.DIV_CODE, 
					LA1.PRD_CODE
				FROM 
					(SELECT 
						LastActivityID = ROW_NUMBER() OVER (PARTITION BY LA2.CL_CODE, LA2.DIV_CODE, LA2.PRD_CODE ORDER BY LA2.LastActivityDate DESC),
						LA2.LastActivityDate, 
						LA2.LastActivityType, 
						LA2.LastActivitySubject, 
						LA2.LastActivityBody, 
						LA2.LastActivityEmployee, 
						LA2.CL_CODE, 
						LA2.DIV_CODE, 
						LA2.PRD_CODE
					FROM 
						(SELECT 
							[LastActivityDate] = A.GENERATED,
							[LastActivityType] = 'Diary',
							[LastActivitySubject] = A.[SUBJECT],
							[LastActivityBody] = CAST(A.BODY AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							A.CL_CODE, 
							A.DIV_CODE, 
							A.PRD_CODE 
						FROM 
							dbo.[ALERT] A LEFT OUTER JOIN 
							dbo.[EMPLOYEE_CLOAK] E ON A.EMP_CODE = E.EMP_CODE
						WHERE 
							A.ALERT_TYPE_ID = 11 AND A.GENERATED <= GETDATE()

						UNION ALL

						SELECT 
							[LastActivityDate] = ENT.[START_TIME],
							[LastActivityType] = 'Scheduled Activity',
							[LastActivitySubject] = ENT.NON_TASK_DESC,
							[LastActivityBody] = CAST(ENT.NON_EMP_TASK_DESC AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							ENT.CL_CODE, 
							ENT.DIV_CODE, 
							ENT.PRD_CODE 
						FROM 
							[dbo].[EMP_NON_TASKS] ENT LEFT OUTER JOIN 
							[dbo].[EMPLOYEE_CLOAK] E ON ENT.EMP_CODE = E.EMP_CODE
						WHERE 
							(ENT.[TYPE]='C' OR ENT.[TYPE]='M' OR ENT.[TYPE]='TD' OR ENT.[TYPE]='EL') AND ENT.[START_TIME] <= GETDATE()) AS LA2) AS LA1
				WHERE
					LA1.LastActivityID = 1) AS LA ON LA.CL_CODE = P.CL_CODE AND
													 LA.DIV_CODE = P.DIV_CODE AND
													 LA.PRD_CODE = P.PRD_CODE
			WHERE
				1 = CASE WHEN @HasSecurityRestrictions = 0 THEN 1 ELSE CASE WHEN SC.CL_CODE IS NULL THEN 0 ELSE 1 END END AND
				1 = CASE WHEN @HasMyObjectDefRestrictions = 0 THEN 1 ELSE CASE WHEN [MODEF].CL_CODE IS NULL THEN 0 ELSE 1 END END
		End
		Else
		Begin
			SELECT 
				[ClientCode] = P.CL_CODE,  
				[ClientName] = C.CL_NAME, 
				[DivisionCode] = P.DIV_CODE,
				[DivisionName] = D.DIV_NAME, 
				[ProductCode] = P.PRD_CODE, 
				[ProductName] = P.PRD_DESCRIPTION, 
				[OfficeCode] = P.OFFICE_CODE, 
				[OfficeName] = O.OFFICE_NAME, 
				[DefaultAccountExecutiveCode] = AE.EMP_CODE, 
				[DefaultAccountExecutive] = AE.[EMP_FML], 
				[NewBusiness] = CAST(ISNULL(C.NEW_BUSINESS, 0) AS bit),
				[IsInactive] = CAST(CASE WHEN ISNULL(C.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(D.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(P.ACTIVE_FLAG, 0) = 0 THEN 1 
										 ELSE 0 END AS bit),
				[LastActivityDate] = LA.LastActivityDate, 
				[LastActivityType] = LA.LastActivityType, 
				[LastActivitySubject] = LA.LastActivitySubject,
				[LastContactDate] = A.LAST_CONTACT_DATE
			FROM
				[dbo].[PRODUCT] AS P INNER JOIN
				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = P.OFFICE_CODE INNER JOIN
				[dbo].[CLIENT] AS C ON C.CL_CODE = P.CL_CODE INNER JOIN
				[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND 
										 D.DIV_CODE = P.DIV_CODE LEFT OUTER JOIN
				[dbo].[SEC_CLIENT] AS SC ON SC.CL_CODE = P.CL_CODE AND 
											SC.DIV_CODE = P.DIV_CODE AND 
											SC.PRD_CODE = P.PRD_CODE AND 
											SC.[USER_ID] = @UserCode INNER JOIN
				[dbo].[EMP_OFFICE] ON P.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE INNER JOIN 
				[dbo].[fn_my_objects_get_dynamic_restrictions](12, @EMP_CODE) AS [MODEF] ON [MODEF].CL_CODE = P.CL_CODE AND 
																							[MODEF].DIV_CODE = P.DIV_CODE AND 
																							[MODEF].PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				[dbo].[ACTIVITY] AS A ON A.CL_CODE = P.CL_CODE AND 
										 A.DIV_CODE = P.DIV_CODE AND 
										 A.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				
				(SELECT
					PDAE.CL_CODE,
					PDAE.DIV_CODE,
					PDAE.PRD_CODE,
					PDAE.EMP_CODE,
					PDAE.[EMP_FML]
				 FROM
					(SELECT 
						ID = ROW_NUMBER() OVER (PARTITION BY PAE.CL_CODE, PAE.DIV_CODE, PAE.PRD_CODE ORDER BY PAE.EMP_CODE DESC),
						PAE.CL_CODE,
						PAE.DIV_CODE,
						PAE.PRD_CODE,
						PAE.EMP_CODE,
						[EMP_FML] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') 
					FROM 
						[dbo].[ACCOUNT_EXECUTIVE] AS PAE INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] EMP ON EMP.EMP_CODE = PAE.EMP_CODE
					WHERE
						PAE.DEFAULT_AE = 1 AND
						(PAE.INACTIVE_FLAG IS NULL OR 
						 PAE.INACTIVE_FLAG = 0)) AS PDAE
				 WHERE 
					PDAE.ID = 1) AS AE ON AE.CL_CODE = P.CL_CODE AND 
										  AE.DIV_CODE = P.DIV_CODE AND 
										  AE.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT 
					LA1.LastActivityDate, 
					LA1.LastActivityType, 
					LA1.LastActivitySubject, 
					LA1.LastActivityBody, 
					LA1.LastActivityEmployee, 
					LA1.CL_CODE, 
					LA1.DIV_CODE, 
					LA1.PRD_CODE
				FROM 
					(SELECT 
						LastActivityID = ROW_NUMBER() OVER (PARTITION BY LA2.CL_CODE, LA2.DIV_CODE, LA2.PRD_CODE ORDER BY LA2.LastActivityDate DESC),
						LA2.LastActivityDate, 
						LA2.LastActivityType, 
						LA2.LastActivitySubject, 
						LA2.LastActivityBody, 
						LA2.LastActivityEmployee, 
						LA2.CL_CODE, 
						LA2.DIV_CODE, 
						LA2.PRD_CODE
					FROM 
						(SELECT 
							[LastActivityDate] = A.GENERATED,
							[LastActivityType] = 'Diary',
							[LastActivitySubject] = A.[SUBJECT],
							[LastActivityBody] = CAST(A.BODY AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							A.CL_CODE, 
							A.DIV_CODE, 
							A.PRD_CODE 
						FROM 
							dbo.[ALERT] A LEFT OUTER JOIN 
							dbo.[EMPLOYEE_CLOAK] E ON A.EMP_CODE = E.EMP_CODE
						WHERE 
							A.ALERT_TYPE_ID = 11 AND A.GENERATED <= GETDATE()

						UNION ALL

						SELECT 
							[LastActivityDate] = ENT.[START_TIME],
							[LastActivityType] = 'Scheduled Activity',
							[LastActivitySubject] = ENT.NON_TASK_DESC,
							[LastActivityBody] = CAST(ENT.NON_EMP_TASK_DESC AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							ENT.CL_CODE, 
							ENT.DIV_CODE, 
							ENT.PRD_CODE 
						FROM 
							[dbo].[EMP_NON_TASKS] ENT LEFT OUTER JOIN 
							[dbo].[EMPLOYEE_CLOAK] E ON ENT.EMP_CODE = E.EMP_CODE
						WHERE 
							(ENT.[TYPE]='C' OR ENT.[TYPE]='M' OR ENT.[TYPE]='TD' OR ENT.[TYPE]='EL') AND ENT.[START_TIME] <= GETDATE()) AS LA2) AS LA1
				WHERE
					LA1.LastActivityID = 1) AS LA ON LA.CL_CODE = P.CL_CODE AND
													 LA.DIV_CODE = P.DIV_CODE AND
													 LA.PRD_CODE = P.PRD_CODE
			WHERE
				1 = CASE WHEN @HasSecurityRestrictions = 0 THEN 1 ELSE CASE WHEN SC.CL_CODE IS NULL THEN 0 ELSE 1 END END AND
				1 = CASE WHEN @HasMyObjectDefRestrictions = 0 THEN 1 ELSE CASE WHEN [MODEF].CL_CODE IS NULL THEN 0 ELSE 1 END END
		End
		
	End
	Else
	Begin
		if @OfficeCount = 0
		Begin
			SELECT 
				[ClientCode] = P.CL_CODE,  
				[ClientName] = C.CL_NAME, 
				[DivisionCode] = P.DIV_CODE,
				[DivisionName] = D.DIV_NAME, 
				[ProductCode] = P.PRD_CODE, 
				[ProductName] = P.PRD_DESCRIPTION, 
				[OfficeCode] = P.OFFICE_CODE, 
				[OfficeName] = O.OFFICE_NAME, 
				[DefaultAccountExecutiveCode] = AE.EMP_CODE, 
				[DefaultAccountExecutive] = AE.[EMP_FML], 
				[NewBusiness] = CAST(ISNULL(C.NEW_BUSINESS, 0) AS bit),
				[IsInactive] = CAST(CASE WHEN ISNULL(C.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(D.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(P.ACTIVE_FLAG, 0) = 0 THEN 1 
										 ELSE 0 END AS bit),
				[LastActivityDate] = LA.LastActivityDate, 
				[LastActivityType] = LA.LastActivityType, 
				[LastActivitySubject] = LA.LastActivitySubject,
				[LastContactDate] = A.LAST_CONTACT_DATE
			FROM
				[dbo].[PRODUCT] AS P INNER JOIN
				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = P.OFFICE_CODE INNER JOIN
				[dbo].[CLIENT] AS C ON C.CL_CODE = P.CL_CODE INNER JOIN
				[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND 
										 D.DIV_CODE = P.DIV_CODE LEFT OUTER JOIN
				[dbo].[SEC_CLIENT] AS SC ON SC.CL_CODE = P.CL_CODE AND 
											SC.DIV_CODE = P.DIV_CODE AND 
											SC.PRD_CODE = P.PRD_CODE AND 
											SC.[USER_ID] = @UserCode LEFT OUTER JOIN
				[dbo].[fn_my_objects_get_dynamic_restrictions](12, @EMP_CODE) AS [MODEF] ON [MODEF].CL_CODE = P.CL_CODE AND 
																							[MODEF].DIV_CODE = P.DIV_CODE AND 
																							[MODEF].PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				[dbo].[ACTIVITY] AS A ON A.CL_CODE = P.CL_CODE AND 
										 A.DIV_CODE = P.DIV_CODE AND 
										 A.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT
					PDAE.CL_CODE,
					PDAE.DIV_CODE,
					PDAE.PRD_CODE,
					PDAE.EMP_CODE,
					PDAE.[EMP_FML]
				 FROM
					(SELECT 
						ID = ROW_NUMBER() OVER (PARTITION BY PAE.CL_CODE, PAE.DIV_CODE, PAE.PRD_CODE ORDER BY PAE.EMP_CODE DESC),
						PAE.CL_CODE,
						PAE.DIV_CODE,
						PAE.PRD_CODE,
						PAE.EMP_CODE,
						[EMP_FML] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') 
					FROM 
						[dbo].[ACCOUNT_EXECUTIVE] AS PAE INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] EMP ON EMP.EMP_CODE = PAE.EMP_CODE
					WHERE
						PAE.DEFAULT_AE = 1 AND
						(PAE.INACTIVE_FLAG IS NULL OR 
						 PAE.INACTIVE_FLAG = 0)) AS PDAE
				 WHERE 
					PDAE.ID = 1) AS AE ON AE.CL_CODE = P.CL_CODE AND 
										  AE.DIV_CODE = P.DIV_CODE AND 
										  AE.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT 
					LA1.LastActivityDate, 
					LA1.LastActivityType, 
					LA1.LastActivitySubject, 
					LA1.LastActivityBody, 
					LA1.LastActivityEmployee, 
					LA1.CL_CODE, 
					LA1.DIV_CODE, 
					LA1.PRD_CODE
				FROM 
					(SELECT 
						LastActivityID = ROW_NUMBER() OVER (PARTITION BY LA2.CL_CODE, LA2.DIV_CODE, LA2.PRD_CODE ORDER BY LA2.LastActivityDate DESC),
						LA2.LastActivityDate, 
						LA2.LastActivityType, 
						LA2.LastActivitySubject, 
						LA2.LastActivityBody, 
						LA2.LastActivityEmployee, 
						LA2.CL_CODE, 
						LA2.DIV_CODE, 
						LA2.PRD_CODE
					FROM 
						(SELECT 
							[LastActivityDate] = A.GENERATED,
							[LastActivityType] = 'Diary',
							[LastActivitySubject] = A.[SUBJECT],
							[LastActivityBody] = CAST(A.BODY AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							A.CL_CODE, 
							A.DIV_CODE, 
							A.PRD_CODE 
						FROM 
							dbo.[ALERT] A LEFT OUTER JOIN 
							dbo.[EMPLOYEE_CLOAK] E ON A.EMP_CODE = E.EMP_CODE
						WHERE 
							A.ALERT_TYPE_ID = 11 AND A.GENERATED <= GETDATE()

						UNION ALL

						SELECT 
							[LastActivityDate] = ENT.[START_TIME],
							[LastActivityType] = 'Scheduled Activity',
							[LastActivitySubject] = ENT.NON_TASK_DESC,
							[LastActivityBody] = CAST(ENT.NON_EMP_TASK_DESC AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							ENT.CL_CODE, 
							ENT.DIV_CODE, 
							ENT.PRD_CODE 
						FROM 
							[dbo].[EMP_NON_TASKS] ENT LEFT OUTER JOIN 
							[dbo].[EMPLOYEE_CLOAK] E ON ENT.EMP_CODE = E.EMP_CODE
						WHERE 
							(ENT.[TYPE]='C' OR ENT.[TYPE]='M' OR ENT.[TYPE]='TD' OR ENT.[TYPE]='EL') AND ENT.[START_TIME] <= GETDATE()) AS LA2) AS LA1
				WHERE
					LA1.LastActivityID = 1) AS LA ON LA.CL_CODE = P.CL_CODE AND
													 LA.DIV_CODE = P.DIV_CODE AND
													 LA.PRD_CODE = P.PRD_CODE
			WHERE
				1 = CASE WHEN @HasSecurityRestrictions = 0 THEN 1 ELSE CASE WHEN SC.CL_CODE IS NULL THEN 0 ELSE 1 END END AND
				1 = CASE WHEN @HasMyObjectDefRestrictions = 0 THEN 1 ELSE CASE WHEN [MODEF].CL_CODE IS NULL THEN 0 ELSE 1 END END
		End
		Else
		Begin
			SELECT 
				[ClientCode] = P.CL_CODE,  
				[ClientName] = C.CL_NAME, 
				[DivisionCode] = P.DIV_CODE,
				[DivisionName] = D.DIV_NAME, 
				[ProductCode] = P.PRD_CODE, 
				[ProductName] = P.PRD_DESCRIPTION, 
				[OfficeCode] = P.OFFICE_CODE, 
				[OfficeName] = O.OFFICE_NAME, 
				[DefaultAccountExecutiveCode] = AE.EMP_CODE, 
				[DefaultAccountExecutive] = AE.[EMP_FML], 
				[NewBusiness] = CAST(ISNULL(C.NEW_BUSINESS, 0) AS bit),
				[IsInactive] = CAST(CASE WHEN ISNULL(C.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(D.ACTIVE_FLAG, 0) = 0 THEN 1 
										 WHEN ISNULL(P.ACTIVE_FLAG, 0) = 0 THEN 1 
										 ELSE 0 END AS bit),
				[LastActivityDate] = LA.LastActivityDate, 
				[LastActivityType] = LA.LastActivityType, 
				[LastActivitySubject] = LA.LastActivitySubject,
				[LastContactDate] = A.LAST_CONTACT_DATE
			FROM
				[dbo].[PRODUCT] AS P INNER JOIN
				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = P.OFFICE_CODE INNER JOIN
				[dbo].[CLIENT] AS C ON C.CL_CODE = P.CL_CODE INNER JOIN
				[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND 
										 D.DIV_CODE = P.DIV_CODE LEFT OUTER JOIN
				[dbo].[SEC_CLIENT] AS SC ON SC.CL_CODE = P.CL_CODE AND 
											SC.DIV_CODE = P.DIV_CODE AND 
											SC.PRD_CODE = P.PRD_CODE AND 
											SC.[USER_ID] = @UserCode INNER JOIN
				[dbo].[EMP_OFFICE] ON P.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE LEFT OUTER JOIN
				[dbo].[fn_my_objects_get_dynamic_restrictions](12, @EMP_CODE) AS [MODEF] ON [MODEF].CL_CODE = P.CL_CODE AND 
																							[MODEF].DIV_CODE = P.DIV_CODE AND 
																							[MODEF].PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				[dbo].[ACTIVITY] AS A ON A.CL_CODE = P.CL_CODE AND 
										 A.DIV_CODE = P.DIV_CODE AND 
										 A.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT
					PDAE.CL_CODE,
					PDAE.DIV_CODE,
					PDAE.PRD_CODE,
					PDAE.EMP_CODE,
					PDAE.[EMP_FML]
				 FROM
					(SELECT 
						ID = ROW_NUMBER() OVER (PARTITION BY PAE.CL_CODE, PAE.DIV_CODE, PAE.PRD_CODE ORDER BY PAE.EMP_CODE DESC),
						PAE.CL_CODE,
						PAE.DIV_CODE,
						PAE.PRD_CODE,
						PAE.EMP_CODE,
						[EMP_FML] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') 
					FROM 
						[dbo].[ACCOUNT_EXECUTIVE] AS PAE INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] EMP ON EMP.EMP_CODE = PAE.EMP_CODE
					WHERE
						PAE.DEFAULT_AE = 1 AND
						(PAE.INACTIVE_FLAG IS NULL OR 
						 PAE.INACTIVE_FLAG = 0)) AS PDAE
				 WHERE 
					PDAE.ID = 1) AS AE ON AE.CL_CODE = P.CL_CODE AND 
										  AE.DIV_CODE = P.DIV_CODE AND 
										  AE.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
				(SELECT 
					LA1.LastActivityDate, 
					LA1.LastActivityType, 
					LA1.LastActivitySubject, 
					LA1.LastActivityBody, 
					LA1.LastActivityEmployee, 
					LA1.CL_CODE, 
					LA1.DIV_CODE, 
					LA1.PRD_CODE
				FROM 
					(SELECT 
						LastActivityID = ROW_NUMBER() OVER (PARTITION BY LA2.CL_CODE, LA2.DIV_CODE, LA2.PRD_CODE ORDER BY LA2.LastActivityDate DESC),
						LA2.LastActivityDate, 
						LA2.LastActivityType, 
						LA2.LastActivitySubject, 
						LA2.LastActivityBody, 
						LA2.LastActivityEmployee, 
						LA2.CL_CODE, 
						LA2.DIV_CODE, 
						LA2.PRD_CODE
					FROM 
						(SELECT 
							[LastActivityDate] = A.GENERATED,
							[LastActivityType] = 'Diary',
							[LastActivitySubject] = A.[SUBJECT],
							[LastActivityBody] = CAST(A.BODY AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							A.CL_CODE, 
							A.DIV_CODE, 
							A.PRD_CODE 
						FROM 
							dbo.[ALERT] A LEFT OUTER JOIN 
							dbo.[EMPLOYEE_CLOAK] E ON A.EMP_CODE = E.EMP_CODE
						WHERE 
							A.ALERT_TYPE_ID = 11 AND A.GENERATED <= GETDATE()

						UNION ALL

						SELECT 
							[LastActivityDate] = ENT.[START_TIME],
							[LastActivityType] = 'Scheduled Activity',
							[LastActivitySubject] = ENT.NON_TASK_DESC,
							[LastActivityBody] = CAST(ENT.NON_EMP_TASK_DESC AS varchar(MAX)), 
							[LastActivityEmployee] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''), 
							ENT.CL_CODE, 
							ENT.DIV_CODE, 
							ENT.PRD_CODE 
						FROM 
							[dbo].[EMP_NON_TASKS] ENT LEFT OUTER JOIN 
							[dbo].[EMPLOYEE_CLOAK] E ON ENT.EMP_CODE = E.EMP_CODE
						WHERE 
							(ENT.[TYPE]='C' OR ENT.[TYPE]='M' OR ENT.[TYPE]='TD' OR ENT.[TYPE]='EL') AND ENT.[START_TIME] <= GETDATE()) AS LA2) AS LA1
				WHERE
					LA1.LastActivityID = 1) AS LA ON LA.CL_CODE = P.CL_CODE AND
													 LA.DIV_CODE = P.DIV_CODE AND
													 LA.PRD_CODE = P.PRD_CODE
			WHERE
				1 = CASE WHEN @HasSecurityRestrictions = 0 THEN 1 ELSE CASE WHEN SC.CL_CODE IS NULL THEN 0 ELSE 1 END END AND
				1 = CASE WHEN @HasMyObjectDefRestrictions = 0 THEN 1 ELSE CASE WHEN [MODEF].CL_CODE IS NULL THEN 0 ELSE 1 END END
		End
		
	End


	

END
GO


