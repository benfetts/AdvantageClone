CREATE PROCEDURE [dbo].[advsp_sec_user_settings] (
	@include_terminated	bit = 0,
	@user_list varchar(max))

AS
BEGIN
SET NOCOUNT ON;

-- ================================
-- MAIN DATA TABLE #SecUserSettings
-- ================================
CREATE TABLE #SecUserSettings(
	UserCode					varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	Inactive					varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeCode				varchar(6)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeName				varchar(61)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeCode					varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeName					varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentCode				varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentName				varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	LimitTimeEntry				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	LimitTimesheetFunctions		varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	LimitPOsToEmployee			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	WebvantageOnly				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowProfileUpdate			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CheckForUserAccess			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	IsCRMUser					varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	IsMediaToolsUser			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS)

-- ===============================
-- BEGIN DATA GATHER
-- ===============================
INSERT INTO #SecUserSettings
SELECT
	su.USER_CODE,
	CASE ISNULL(su.IS_INACTIVE,0)
		WHEN 0 THEN 'N'
		ELSE 'Y'
	END AS Inactive,
	su.EMP_CODE,
	CASE WHEN e.EMP_MI IS NULL OR e.EMP_MI = '' THEN e.EMP_FNAME + ' ' + e.EMP_LNAME ELSE e.EMP_FNAME + ' ' + e.EMP_MI + '. ' + e.EMP_LNAME END,
	e.OFFICE_CODE,
	o.OFFICE_NAME,
	e.DP_TM_CODE,
	dt.DP_TM_DESC,
	CASE sus.SETTING_CODE
		WHEN 'SI_DO_OWN_TS' THEN ISNULL(sus.STRING_VALUE,'N')
	END AS LimitTimeEntry,
	CASE sus.SETTING_CODE
		WHEN 'EMP_TS_FNC' THEN ISNULL(sus.STRING_VALUE,'N')
	END AS LimitTimesheetFunctions,
	CASE sus.SETTING_CODE
		WHEN 'PR_PO_DO_OWN' THEN ISNULL(sus.STRING_VALUE,'N')
	END AS LimitPOsToEmployee,
	CASE sus.SETTING_CODE
		WHEN 'TIME_ENTRY_ONLY' THEN ISNULL(sus.STRING_VALUE,'N')
	END AS WebvantageOnly,
	CASE sus.SETTING_CODE
		WHEN 'AllowProfileUpdate' THEN ISNULL(sus.STRING_VALUE,'N')
	END AS AllowProfileUpdate,
	CASE ISNULL(su.CHECK_USER_ACCESS,0)
		WHEN 0 THEN 'N'
		ELSE 'Y'
	END AS CheckForUserAccess,
	CASE sus.SETTING_CODE
		WHEN 'IsCRMUser' THEN ISNULL(sus.STRING_VALUE,'N')
	END AS IsCRMUser,
	CASE sus.SETTING_CODE
		WHEN 'IsMediaToolsUser' THEN
			CASE
				WHEN ISNULL(sus.STRING_VALUE, '') = '' THEN 'N'
				ELSE 'Y'
			END
	END AS IsMediaToolsUser
FROM dbo.SEC_USER AS su
JOIN dbo.SEC_USER_SETTING AS sus ON su.SEC_USER_ID = sus.SEC_USER_ID
JOIN dbo.EMPLOYEE AS e ON su.EMP_CODE = e.EMP_CODE
LEFT JOIN dbo.DEPT_TEAM AS dt ON e.DP_TM_CODE = dt.DP_TM_CODE
LEFT JOIN dbo.OFFICE AS o ON e.OFFICE_CODE = o.OFFICE_CODE
WHERE (@user_list IS NULL OR (@user_list IS NOT NULL AND su.SEC_USER_ID IN (SELECT * from dbo.udf_split_list(@user_list, ','))))	

IF @include_terminated = 0
	SELECT
		UserCode,
		Inactive,
		EmployeeCode,
		EmployeeName,
		OfficeCode,
		OfficeName,
		DepartmentCode,
		DepartmentName,
		MAX(ISNULL(LimitTimeEntry,'N')) AS LimitTimeEntry,
		MAX(ISNULL(LimitTimesheetFunctions,'N')) AS LimitTimesheetFunctions,
		MAX(ISNULL(LimitPOsToEmployee,'N')) AS LimitPOsToEmployee,
		MAX(ISNULL(WebvantageOnly,'N')) AS WebvantageUserOnly,
		MAX(ISNULL(AllowProfileUpdate,'N')) As AllowProfileUpdate,
		ISNULL(CheckForUserAccess,'N') AS CheckForUserAccess,
		MAX(ISNULL(IsCRMUser,'N')) AS IsCRMUser,
		MAX(ISNULL(IsMediaToolsUser,'N')) AS IsMediaToolsUser
	FROM #SecUserSettings AS sus
	JOIN dbo.EMPLOYEE AS e ON e.EMP_CODE = sus.EmployeeCode
	WHERE e.EMP_TERM_DATE IS NULL
	GROUP BY UserCode, Inactive, EmployeeCode, EmployeeName, OfficeCode, OfficeName, DepartmentCode, DepartmentName, CheckForUserAccess
	ORDER BY UserCode
		ELSE
			SELECT
			UserCode,
			Inactive,
			EmployeeCode,
			EmployeeName,
			OfficeCode,
			OfficeName,
			DepartmentCode,
			DepartmentName,
			MAX(ISNULL(LimitTimeEntry,'N')) AS LimitTimeEntry,
			MAX(ISNULL(LimitTimesheetFunctions,'N')) AS LimitTimesheetFunctions,
			MAX(ISNULL(LimitPOsToEmployee,'N')) AS LimitPOsToEmployee,
			MAX(ISNULL(WebvantageOnly,'N')) AS WebvantageUserOnly,
			MAX(ISNULL(AllowProfileUpdate,'N')) As AllowProfileUpdate,
			ISNULL(CheckForUserAccess,'N') AS CheckForUserAccess,
			MAX(ISNULL(IsCRMUser,'N')) AS IsCRMUser,
			MAX(ISNULL(IsMediaToolsUser,'N')) AS IsMediaToolsUser
		FROM #SecUserSettings
		GROUP BY UserCode, Inactive, EmployeeCode, EmployeeName, OfficeCode, OfficeName, DepartmentCode, DepartmentName, CheckForUserAccess
		ORDER BY UserCode

END
GO

BEGIN
	
	GRANT EXECUTE ON [advsp_sec_user_settings]TO PUBLIC 

END
GO