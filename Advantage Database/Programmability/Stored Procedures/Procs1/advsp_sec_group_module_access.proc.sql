-- Specifications for new data set advsp_sec_group_module_access
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_sec_group_module_access]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_sec_group_module_access]
GO

CREATE PROCEDURE [dbo].[advsp_sec_group_module_access](
	@show_only_accessible bit,
	@group_list varchar(max))

AS
BEGIN
SET NOCOUNT ON;

-- =====================================
-- MAIN DATA TABLE #SecGroupModuleAccess
-- =====================================
CREATE TABLE #SecGroupModuleAccess(
	GroupID						integer,
	GroupName					varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GroupDescription			varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ApplicationID				integer,
	ApplicationName				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ApplicationIsBlocked		bit,
	ModuleID					integer,
	ParentModule				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	SubParentModule				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	SubSubParentModule			varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	Module						varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ModuleIsBlocked				bit,
	ModuleCanPrint				bit,
	ModuleCanUpdate				bit,
	ModuleCanAdd				bit,
	ModuleCustom1				bit,
	ModuleCustom2				bit,
	ParentModuleSortOrder		integer,
	SubParentModuleSortOrder	integer,
	SubSubParentModuleSortOrder	integer,
	ModuleSortOrder				integer)

-- ======================================
-- SECONDARY DATA TABLE #SecGroupAppAcess
-- ======================================
CREATE TABLE #SecGroupAppAccess(
	GroupID						integer,
	GroupName					varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	GroupDescription			varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ApplicationID				integer,
	ApplicationName				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ApplicationIsBlocked		bit,
	ModuleID					integer,
	ParentModule				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	SubParentModule				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	SubSubParentModule			varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	Module						varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	ParentModuleSortOrder		integer,
	SubParentModuleSortOrder	integer,
	SubSubParentModuleSortOrder	integer,
	ModuleSortOrder				integer)

-- ===========================
-- BEGIN SECONDARY DATA GATHER
-- ===========================
INSERT INTO #SecGroupAppAccess
SELECT
	sga.SEC_GROUP_ID,
	sg.NAME AS GroupName,
	sg.[DESCRIPTION] AS GroupDescription,
	sam.SEC_APPLICATION_ID,
	sa.NAME AS ApplicationName,
	ISNULL(sga.IS_BLOCKED,0),
	vsms.ModuleID,
	vsms.ParentModule,
	vsms.SubParentModule,
	vsms.SubSubParentModule,
	vsms.Module,
	vsms.ParentModuleSortOrder,
	vsms.SubParentModuleSortOrder,
	vsms.SubSubParentModuleSortOrder,
	vsms.ModuleSortOrder
FROM dbo.SEC_APPLICATION AS sa
	JOIN dbo.SEC_APPLICATION_MOD AS sam ON sam.SEC_APPLICATION_ID = sa.SEC_APPLICATION_ID
	JOIN dbo.SEC_GROUP_APPACCESS AS sga ON sga.SEC_APPLICATION_ID = sa.SEC_APPLICATION_ID
	JOIN dbo.SEC_MODULE as sm ON sm.SEC_MODULE_ID = sam.SEC_MODULE_ID
	JOIN dbo.SEC_GROUP AS sg ON sg.SEC_GROUP_ID = sga.SEC_GROUP_ID
	JOIN dbo.V_SEC_MODULES_STRUCT AS vsms ON vsms.ModuleID = sm.SEC_MODULE_ID
WHERE ISNULL(sm.IS_CATEGORY,0)=0 AND (@group_list IS NULL OR (@group_list IS NOT NULL AND sg.SEC_GROUP_ID IN (SELECT * from dbo.udf_split_list(@group_list, ','))))

-- ======================
-- BEGIN MAIN DATA GATHER
-- ======================
INSERT INTO #SecGroupModuleAccess
SELECT
	sgaa.GroupID,
	sgaa.GroupName,
	sgaa.GroupDescription,
	sgaa.ApplicationID,
	sgaa.ApplicationName,
	sgaa.ApplicationIsBlocked,
	sgaa.ModuleID,
	sgaa.ParentModule,
	sgaa.SubParentModule,
	sgaa.SubSubParentModule,
	sgaa.Module,
	ISNULL(sgm.IS_BLOCKED,0),
	ISNULL(sgm.CAN_PRINT,0),
	ISNULL(sgm.CAN_UPDATE,0),
	ISNULL(sgm.CAN_ADD,0),
	ISNULL(sgm.CUSTOM1,0),
	ISNULL(sgm.CUSTOM2,0),
	sgaa.ParentModuleSortOrder,
	sgaa.SubParentModuleSortOrder,
	sgaa.SubSubParentModuleSortOrder,
	sgaa.ModuleSortOrder
FROM #SecGroupAppAccess AS sgaa
	JOIN dbo.SEC_GROUP_MODACCESS AS sgm ON sgm.SEC_GROUP_ID = sgaa.GroupID AND sgm.SEC_MODULE_ID = sgaa.ModuleID
WHERE 1 = CASE WHEN @show_only_accessible = 1 AND ISNULL(sgm.IS_BLOCKED,0) = 1 THEN 0 ELSE 1 END

SELECT
	GroupID,
	GroupName,
	GroupDescription,
	ApplicationID,
	ApplicationName,
	CASE ApplicationIsBlocked WHEN 1 THEN 'Y' ELSE 'N' END AS ApplicationIsBlocked,
	ModuleID,
	ParentModule,
	SubParentModule,
	SubSubParentModule,
	Module,
	CASE ModuleIsBlocked WHEN 1 THEN 'Y' ELSE 'N' END AS ModuleIsBlocked,
	CASE ModuleCanPrint WHEN 1 THEN 'Y' ELSE 'N' END AS ModuleCanPrint,
	CASE ModuleCanUpdate WHEN 1 THEN 'Y' ELSE 'N' END AS ModuleCanUpdate,
	CASE ModuleCanAdd WHEN 1 THEN 'Y' ELSE 'N' END AS ModuleCanAdd,
	CASE ModuleCustom1 WHEN 1 THEN 'Y' ELSE 'N' END AS ModuleCustom1,
	CASE ModuleCustom2 WHEN 1 THEN 'Y' ELSE 'N' END AS ModuleCustom2,
	ParentModuleSortOrder,
	SubParentModuleSortOrder,
	SubSubParentModuleSortOrder,
	ModuleSortOrder
FROM #SecGroupModuleAccess
ORDER BY GroupID, ApplicationID, ParentModuleSortOrder, SubParentModuleSortOrder, SubSubParentModuleSortOrder, ModuleSortOrder

END
GO

BEGIN
	
	GRANT EXECUTE ON [advsp_sec_group_module_access]TO PUBLIC 

END
GO
