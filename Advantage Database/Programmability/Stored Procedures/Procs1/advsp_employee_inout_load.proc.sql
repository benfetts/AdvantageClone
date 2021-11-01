IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_employee_inout_load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	DROP PROCEDURE [dbo].[advsp_employee_inout_load]
GO

CREATE PROCEDURE [dbo].[advsp_employee_inout_load] 
	@UserID varchar(100),
	@OFFSET [DECIMAL](9,3),
	@LimitEntries bit,
	@START_DATE AS smalldatetime
	--@END_DATE AS smalldatetime
AS
BEGIN
	
	CREATE TABLE #DT 
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[EmployeeCode] varchar(6), 
		[Employee] varchar(80), 
		[EmployeeFirstName] varchar(30),
		[EmployeeLastName] varchar(30),
		[EmployeeTitle] varchar(50),
		[IsEmployeeFreelance] varchar(3),
		[IsActiveFreelance] varchar(3),
		[OfficeCode] varchar(4),
		[Office] varchar(30),
		[DepartmentTeamCode] varchar(6), 		
		[DepartmentTeam] varchar(30),
		[SupervisorCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[Supervisor] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,--CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END,	
		[DefaultRoleCode] varchar(6),
		[DefaultRole] varchar(40),
		[EmployeeStatus] varchar(12),
		[Status] varchar(3),
		[InOutDate] smalldatetime,
		[InOutTime] smalldatetime,
		[Reason] varchar(50),
		[ExpectedReturn] smalldatetime
	);	

if @LimitEntries = 1
Begin
	INSERT INTO #DT
    SELECT  
		--[ID] = NEWID(),
		[EmployeeCode] = EMP.EMP_CODE, 
		[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		[EmployeeFirstName] = EMP.EMP_FNAME,
		[EmployeeLastName] = EMP.EMP_LNAME,
		[EmployeeTitle] = EMPT.EMPLOYEE_TITLE,
		[IsEmployeeFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[IsActiveFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN CASE WHEN EMP.IS_ACTIVE_FREELANCE = 1 THEN 'Yes' ELSE 'No' END ELSE 'No' END,
		[OfficeCode] = EMP.OFFICE_CODE,
		[Office] = O.OFFICE_NAME,
		[DepartmentTeamCode] = EMP.DP_TM_CODE, 		
		[DepartmentTeam] = D.DP_TM_DESC, 
		[SupervisorCode] = EMP.SUPERVISOR_CODE,
		[Supervisor] = '',--CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END,		
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = R.ROLE_DESC,
		[EmployeeStatus] = CASE WHEN EMP.[STATUS] = 0 THEN 'N/A'
			            WHEN EMP.[STATUS] = 1 THEN 'Exempt'
						WHEN EMP.[STATUS] = 2 THEN 'Non-Exempt'
						ELSE 'N/A' END,
		[Status] = CASE WHEN E.INOUT_STAT = 1 THEN 'Out' Else 'In' END,
		[InOutDate] = [dbo].[advfn_local_date](@OFFSET, convert(varchar(10), E.INOUT_TIME,120)),
		[InOutTime] = [dbo].[advfn_local_date](@OFFSET, E.INOUT_TIME),
		[Reason] = ISNULL(E.COMMENT,''),
		[ExpectedReturn] = E.EXP_RETURN_TIME

	FROM 
		EMP_INOUTBOARD E INNER JOIN 
		EMPLOYEE EMP ON E.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN
		DEPT_TEAM D ON EMP.DP_TM_CODE = D.DP_TM_CODE LEFT OUTER JOIN
		OFFICE O ON EMP.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN 
		EMPLOYEE_TITLE AS EMPT ON EMPT.EMPLOYEE_TITLE_ID = EMP.EMPLOYEE_TITLE_ID LEFT OUTER JOIN
		TRAFFIC_ROLE AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
	WHERE E.INOUT_REF = (SELECT MAX(INOUT_REF) FROM EMP_INOUTBOARD E2 WHERE E.EMP_CODE = E2.EMP_CODE) AND EMP.EMP_TERM_DATE IS NULL  

	UNION 

	SELECT  
		--[ID] = NEWID(),
		[EmployeeCode] = EMP.EMP_CODE, 
		[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		[EmployeeFirstName] = EMP.EMP_FNAME,
		[EmployeeLastName] = EMP.EMP_LNAME,
		[EmployeeTitle] = EMPT.EMPLOYEE_TITLE,
		[IsEmployeeFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[IsActiveFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN CASE WHEN EMP.IS_ACTIVE_FREELANCE = 1 THEN 'Yes' ELSE 'No' END ELSE 'No' END,
		[OfficeCode] = EMP.OFFICE_CODE,
		[Office] = O.OFFICE_NAME,
		[DepartmentTeamCode] = EMP.DP_TM_CODE, 		
		[DepartmentTeam] = D.DP_TM_DESC, 
		[SupervisorCode] = EMP.SUPERVISOR_CODE,
		[Supervisor] = '',--CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END,		
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = R.ROLE_DESC,
		[EmployeeStatus] = CASE WHEN EMP.[STATUS] = 0 THEN 'N/A'
			            WHEN EMP.[STATUS] = 1 THEN 'Exempt'
						WHEN EMP.[STATUS] = 2 THEN 'Non-Exempt'
						ELSE 'N/A' END,
		[Status] = 'In',
		[InOutDate] = NULL,
		[InOutTime] = NULL,
		[Reason] = '',
		[ExpectedReturn] = NULL

	FROM 
		EMPLOYEE EMP LEFT OUTER JOIN
		DEPT_TEAM D ON EMP.DP_TM_CODE = D.DP_TM_CODE LEFT OUTER JOIN
		OFFICE O ON EMP.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN 
		EMPLOYEE_TITLE AS EMPT ON EMPT.EMPLOYEE_TITLE_ID = EMP.EMPLOYEE_TITLE_ID LEFT OUTER JOIN
		TRAFFIC_ROLE AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
	WHERE EMP.EMP_CODE NOT IN (SELECT EMP_CODE FROM EMP_INOUTBOARD) AND EMP.EMP_TERM_DATE IS NULL  

End
Else
Begin
	INSERT INTO #DT
    SELECT  
		--[ID] = NEWID(),
		[EmployeeCode] = EMP.EMP_CODE, 
		[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		[EmployeeFirstName] = EMP.EMP_FNAME,
		[EmployeeLastName] = EMP.EMP_LNAME,
		[EmployeeTitle] = EMPT.EMPLOYEE_TITLE,
		[IsEmployeeFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[IsActiveFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN CASE WHEN EMP.IS_ACTIVE_FREELANCE = 1 THEN 'Yes' ELSE 'No' END ELSE 'No' END,
		[OfficeCode] = EMP.OFFICE_CODE,
		[Office] = O.OFFICE_NAME,
		[DepartmentTeamCode] = EMP.DP_TM_CODE, 		
		[DepartmentTeam] = D.DP_TM_DESC, 
		[SupervisorCode] = EMP.SUPERVISOR_CODE,
		[Supervisor] = '',--CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END,		
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = R.ROLE_DESC,
		[EmployeeStatus] = CASE WHEN EMP.[STATUS] = 0 THEN 'N/A'
			            WHEN EMP.[STATUS] = 1 THEN 'Exempt'
						WHEN EMP.[STATUS] = 2 THEN 'Non-Exempt'
						ELSE 'N/A' END,
		[Status] = CASE WHEN E.INOUT_STAT = 1 THEN 'Out' Else 'In' END,
		[InOutDate] = [dbo].[advfn_local_date](@OFFSET, convert(varchar(10), E.INOUT_TIME,120)),
		[InOutTime] = [dbo].[advfn_local_date](@OFFSET, E.INOUT_TIME),
		[Reason] = ISNULL(E.COMMENT,''),
		[ExpectedReturn] = E.EXP_RETURN_TIME

	FROM 
		EMP_INOUTBOARD E INNER JOIN 
		EMPLOYEE EMP ON E.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN
		DEPT_TEAM D ON EMP.DP_TM_CODE = D.DP_TM_CODE LEFT OUTER JOIN
		OFFICE O ON EMP.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN 
		EMPLOYEE_TITLE AS EMPT ON EMPT.EMPLOYEE_TITLE_ID = EMP.EMPLOYEE_TITLE_ID LEFT OUTER JOIN
		TRAFFIC_ROLE AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
	WHERE EMP.EMP_TERM_DATE IS NULL AND E.INOUT_TIME >= @START_DATE  

	UNION 

	SELECT  
		--[ID] = NEWID(),
		[EmployeeCode] = EMP.EMP_CODE, 
		[Employee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END, 
		[EmployeeFirstName] = EMP.EMP_FNAME,
		[EmployeeLastName] = EMP.EMP_LNAME,
		[EmployeeTitle] = EMPT.EMPLOYEE_TITLE,
		[IsEmployeeFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN 'Yes' ELSE 'No' END,
		[IsActiveFreelance] = CASE WHEN ISNULL(EMP.FREELANCE, 0) = 1 THEN CASE WHEN EMP.IS_ACTIVE_FREELANCE = 1 THEN 'Yes' ELSE 'No' END ELSE 'No' END,
		[OfficeCode] = EMP.OFFICE_CODE,
		[Office] = O.OFFICE_NAME,
		[DepartmentTeamCode] = EMP.DP_TM_CODE, 		
		[DepartmentTeam] = D.DP_TM_DESC, 
		[SupervisorCode] = EMP.SUPERVISOR_CODE,
		[Supervisor] = '',--CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END,		
		[DefaultRoleCode] = EMP.DEF_TRF_ROLE,
		[DefaultRole] = R.ROLE_DESC,
		[EmployeeStatus] = CASE WHEN EMP.[STATUS] = 0 THEN 'N/A'
			            WHEN EMP.[STATUS] = 1 THEN 'Exempt'
						WHEN EMP.[STATUS] = 2 THEN 'Non-Exempt'
						ELSE 'N/A' END,
		[Status] = 'In',
		[InOutDate] = NULL,
		[InOutTime] = NULL,
		[Reason] = '',
		[ExpectedReturn] = NULL

	FROM
		EMPLOYEE EMP LEFT OUTER JOIN
		DEPT_TEAM D ON EMP.DP_TM_CODE = D.DP_TM_CODE LEFT OUTER JOIN
		OFFICE O ON EMP.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN 
		EMPLOYEE_TITLE AS EMPT ON EMPT.EMPLOYEE_TITLE_ID = EMP.EMPLOYEE_TITLE_ID LEFT OUTER JOIN
		TRAFFIC_ROLE AS R ON R.ROLE_CODE = EMP.DEF_TRF_ROLE
	WHERE EMP.EMP_CODE NOT IN (SELECT EMP_CODE FROM EMP_INOUTBOARD) AND EMP.EMP_TERM_DATE IS NULL
End

	

	UPDATE #DT
	SET Supervisor = (SELECT CASE WHEN SUP.EMP_MI IS NULL OR SUP.EMP_MI = '' THEN SUP.EMP_FNAME + ' ' + SUP.EMP_LNAME ELSE SUP.EMP_FNAME + ' ' + SUP.EMP_MI + '. ' + SUP.EMP_LNAME END
								FROM [dbo].[EMPLOYEE_CLOAK] AS SUP WHERE SUP.EMP_CODE = #DT.SupervisorCode)

	SELECT * FROM #DT
		
	
	DROP TABLE #DT

END
GO

