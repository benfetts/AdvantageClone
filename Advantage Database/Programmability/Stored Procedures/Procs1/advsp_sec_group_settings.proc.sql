-- Specifications for new data set advsp_sec_group_settings.
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_sec_group_settings]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_sec_group_settings]
GO

CREATE PROCEDURE [dbo].[advsp_sec_group_settings] (
	@group_list varchar(max))

AS
BEGIN
SET NOCOUNT ON;

-- =================================
-- MAIN DATA TABLE #SecGroupSettings
-- =================================
CREATE TABLE #SecGroupSettings(
	GroupName						varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GroupDescription				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowTaskEdit					varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowMediaPageEdit				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowUserToAddHolidays			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	AllowUserToViewOtherEmployees	varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ShowAllAssignments				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ShowUnassignedAssignments		varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CanUploadDocuments				varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ViewPrivateDocuments			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	CreateWorkspaceTemplate			varchar(1)		COLLATE		SQL_Latin1_General_CP1_CS_AS)

-- =================
-- BEGIN DATA GATHER
-- =================
INSERT INTO #SecGroupSettings
SELECT
	sg.NAME,
	sg.[DESCRIPTION],
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
	END AS CreateWorkspaceTemplate
FROM dbo.SEC_GROUP AS sg
JOIN dbo.SEC_GROUP_SETTING AS sgs ON sg.SEC_GROUP_ID = sgs.SEC_GROUP_ID
WHERE (@group_list IS NULL OR (@group_list IS NOT NULL AND sg.SEC_GROUP_ID IN (SELECT * from dbo.udf_split_list(@group_list, ','))))

SELECT
	GroupName,
	GroupDescription,
	MAX(ISNULL(AllowTaskEdit,'N')) AS AllowTaskEdit,
	MAX(ISNULL(AllowMediaPageEdit,'N')) AS AllowMediaPageEdit,
	MAX(ISNULL(AllowUserToAddHolidays,'N')) AS AllowUserToAddHolidays,
	MAX(ISNULL(AllowUserToviewOtherEmployees,'N')) AS AllowUserToViewOtherEmployees,
	MAX(ISNULL(ShowAllAssignments,'N')) AS ShowAllAssignments,
	MAX(ISNULL(ShowUnassignedAssignments,'N')) AS ShowUnassignedAssignments,
	MAX(ISNULL(CanUploadDocuments,'N')) AS CanUploadDocuments,
	MAX(ISNULL(ViewPrivateDocuments,'N')) AS ViewPrivateDocuments,
	MAX(ISNULL(CreateWorkspaceTemplate,'N')) AS CreateWorkspaceTemplate
FROM #SecGroupSettings
GROUP BY GroupName, GroupDescription
ORDER BY GroupName

END
GO

BEGIN
	
	GRANT EXECUTE ON [advsp_sec_group_settings]TO PUBLIC 

END
GO