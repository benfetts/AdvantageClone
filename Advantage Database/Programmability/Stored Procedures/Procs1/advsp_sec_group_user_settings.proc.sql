-- Specifications for new data set advsp_sec_group_user_settings.	
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_sec_group_user_settings]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_sec_group_user_settings]
GO

CREATE PROCEDURE [dbo].[advsp_sec_group_user_settings] (
	@include_terminated	bit = 0,
	@group_list varchar(max),
	@user_list varchar(max))

AS
BEGIN
SET NOCOUNT ON;

-- =====================================
-- MAIN DATA TABLE #SecGroupUserSettings
-- =====================================
CREATE TABLE #SecGroupUserSettings(
	GroupName						varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GroupDescription				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	UserCode						varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	Inactive						varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeCode					varchar(6)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeName					varchar(61)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeCode						varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeName						varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentCode					varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentName					varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowTaskEdit					varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowMediaPageEdit				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowUserToAddHolidays			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowUserToViewOtherEmployees	varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ShowAllAssignments				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ShowUnassignedAssignments		varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CanUploadDocuments				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ViewPrivateDocuments			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CreateWorkspaceTemplate			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	LimitTimeEntry					varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	LimitTimesheetFunctions			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	LimitPOsToEmployee				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	WebvantageOnly					varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowProfileUpdate				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CheckForUserAccess				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	IsCRMUser						varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	IsMediaToolsUser				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS)

-- ===============================
-- BEGIN DATA GATHER
-- ===============================
INSERT INTO #SecGroupUserSettings
SELECT
	sg.NAME,
	sg.[DESCRIPTION],
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
	CASE sgs.SETTING_CODE
		WHEN 'Schedule_AllowTaskEdit' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS AllowTaskEdit,
	CASE sgs.SETTING_CODE
		WHEN 'Schedule_AllowMediaPageEdit' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS AllowMediaPageEdit,
	CASE sgs.SETTING_CODE
		WHEN 'Calendar_AllowGroupToAddHolidays' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS AllowUserToAddHolidays,
	CASE sgs.SETTING_CODE
		WHEN 'Calendar_AllowGroupToViewOtherEmployees' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS AllowUserToViewOtherEmployees,
	CASE sgs.SETTING_CODE
		WHEN 'AlertInbox_ShowAllAssignments' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS ShowAllAssignments,
	CASE sgs.SETTING_CODE
		WHEN 'AlertInbox_ShowUnassignedAssignments' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS ShowUnassignedAssignments,
	CASE sgs.SETTING_CODE
		WHEN 'DocumentManager_CanUpload' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS CanUploadDocuments,
	CASE sgs.SETTING_CODE
		WHEN 'DocumentManager_ViewPrivateDocuments' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS ViewPrivateDocuments,
	CASE sgs.SETTING_CODE
		WHEN 'Workspace_Template_Create' THEN ISNULL(sgs.STRING_VALUE,'N')
	END AS CreateWorkspaceTemplate,
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
				WHEN sus.STRING_VALUE IS NULL THEN 'N'
				ELSE 'Y'
			END
	END AS IsMediaToolsUser
FROM dbo.SEC_GROUP AS sg
JOIN dbo.SEC_GROUP_USER AS sgu ON sg.SEC_GROUP_ID = sgu.SEC_GROUP_ID
JOIN dbo.SEC_GROUP_SETTING AS sgs ON sgu.SEC_GROUP_ID = sgs.SEC_GROUP_ID
JOIN dbo.SEC_USER AS su ON sgu.SEC_USER_ID = su.SEC_USER_ID
JOIN dbo.SEC_USER_SETTING AS sus ON su.SEC_USER_ID = sus.SEC_USER_ID
JOIN dbo.EMPLOYEE AS e ON su.EMP_CODE = e.EMP_CODE
LEFT JOIN dbo.DEPT_TEAM AS dt ON e.DP_TM_CODE = dt.DP_TM_CODE
LEFT JOIN dbo.OFFICE AS o ON e.OFFICE_CODE = o.OFFICE_CODE
WHERE (@group_list IS NULL OR (@group_list IS NOT NULL AND sg.SEC_GROUP_ID IN (SELECT * from dbo.udf_split_list(@group_list, ',')))) AND
	  (@user_list IS NULL OR (@user_list IS NOT NULL AND su.SEC_USER_ID IN (SELECT * from dbo.udf_split_list(@user_list, ','))))	

IF @include_terminated = 0
	SELECT
		GroupName,
		GroupDescription,
		UserCode,
		Inactive,
		EmployeeCode,
		EmployeeName,
		OfficeCode,
		OfficeName,
		DepartmentCode,
		DepartmentName,
		MAX(ISNULL(AllowTaskEdit,'N')) AS AllowTaskEdit,
		MAX(ISNULL(AllowMediaPageEdit,'N')) AS AllowMediaPageEdit,
		MAX(ISNULL(AllowUserToAddHolidays,'N')) AS AllowUserToAddHolidays,
		MAX(ISNULL(AllowUserToviewOtherEmployees,'N')) AS AllowUserToViewOtherEmployees,
		MAX(ISNULL(ShowAllAssignments,'N')) AS ShowAllAssignments,
		MAX(ISNULL(ShowUnassignedAssignments,'N')) AS ShowUnassignedAssignments,
		MAX(ISNULL(CanUploadDocuments,'N')) AS CanUploadDocuments,
		MAX(ISNULL(ViewPrivateDocuments,'N')) AS ViewPrivateDocuments,
		MAX(ISNULL(CreateWorkspaceTemplate,'N')) AS CreateWorkspaceTemplate,
		MAX(ISNULL(LimitTimeEntry,'N')) AS LimitTimeEntry,
		MAX(ISNULL(LimitTimesheetFunctions,'N')) AS LimitTimesheetFunctions,
		MAX(ISNULL(LimitPOsToEmployee,'N')) AS LimitPOsToEmployee,
		MAX(ISNULL(WebvantageOnly,'N')) AS WebvantageUserOnly,
		MAX(ISNULL(AllowProfileUpdate,'N')) As AllowProfileUpdate,
		ISNULL(CheckForUserAccess,'N') AS CheckForUserAccess,
		MAX(ISNULL(IsCRMUser,'N')) AS IsCRMUser,
		MAX(ISNULL(IsMediaToolsUser,'N')) AS IsMediaToolsUser
	FROM #SecGroupUserSettings
	JOIN dbo.EMPLOYEE AS e ON #SecGroupUserSettings.EmployeeCode = e.EMP_CODE
	WHERE e.EMP_TERM_DATE IS NULL
	GROUP BY GroupName, GroupDescription, UserCode, Inactive, EmployeeCode, EmployeeName, OfficeCode, OfficeName, DepartmentCode, DepartmentName, CheckForUserAccess
	ORDER BY GroupName, UserCode
		ELSE
			SELECT
			GroupName,
			GroupDescription,
			UserCode,
			Inactive,
			EmployeeCode,
			EmployeeName,
			OfficeCode,
			OfficeName,
			DepartmentCode,
			DepartmentName,
			MAX(ISNULL(AllowTaskEdit,'N')) AS AllowTaskEdit,
			MAX(ISNULL(AllowMediaPageEdit,'N')) AS AllowMediaPageEdit,
			MAX(ISNULL(AllowUserToAddHolidays,'N')) AS AllowUserToAddHolidays,
			MAX(ISNULL(AllowUserToviewOtherEmployees,'N')) AS AllowUserToViewOtherEmployees,
			MAX(ISNULL(ShowAllAssignments,'N')) AS ShowAllAssignments,
			MAX(ISNULL(ShowUnassignedAssignments,'N')) AS ShowUnassignedAssignments,
			MAX(ISNULL(CanUploadDocuments,'N')) AS CanUploadDocuments,
			MAX(ISNULL(ViewPrivateDocuments,'N')) AS ViewPrivateDocuments,
			MAX(ISNULL(CreateWorkspaceTemplate,'N')) AS CreateWorkspaceTemplate,
			MAX(ISNULL(LimitTimeEntry,'N')) AS LimitTimeEntry,
			MAX(ISNULL(LimitTimesheetFunctions,'N')) AS LimitTimesheetFunctions,
			MAX(ISNULL(LimitPOsToEmployee,'N')) AS LimitPOsToEmployee,
			MAX(ISNULL(WebvantageOnly,'N')) AS WebvantageUserOnly,
			MAX(ISNULL(AllowProfileUpdate,'N')) As AllowProfileUpdate,
			ISNULL(CheckForUserAccess,'N') AS CheckForUserAccess,
			MAX(ISNULL(IsCRMUser,'N')) AS IsCRMUser,
			MAX(ISNULL(IsMediaToolsUser,'N')) AS IsMediaToolsUser
		FROM #SecGroupUserSettings
		GROUP BY GroupName, GroupDescription, UserCode, Inactive, EmployeeCode, EmployeeName, OfficeCode, OfficeName, DepartmentCode, DepartmentName, CheckForUserAccess
		ORDER BY GroupName, UserCode

END
GO

BEGIN
	
	GRANT EXECUTE ON [advsp_sec_group_user_settings]TO PUBLIC 

END
GO