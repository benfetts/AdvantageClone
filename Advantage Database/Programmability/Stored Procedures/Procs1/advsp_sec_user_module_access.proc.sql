-- Specifications for new data set advsp_sec_user_module_access
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_sec_user_module_access]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_sec_user_module_access]
GO

CREATE PROCEDURE [dbo].[advsp_sec_user_module_access](
	@include_terminated	bit = 0,
	@show_only_accessible bit,
	@user_list varchar(max))

AS
BEGIN
SET NOCOUNT ON;

-- =====================================
-- MAIN DATA TABLE #SecUserModuleAccess
-- =====================================
CREATE TABLE #SecUserModuleAccess(
	UserID						integer,
	UserCode					varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeCode				varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeName				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeCode					varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeName					varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentCode				varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentName				varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
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
-- SECONDARY DATA TABLE #SecUserAppAccess
-- ======================================
CREATE TABLE #SecUserAppAccess(
	UserID						integer,
	UserCode					varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeCode				varchar(50)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	EmployeeName				varchar(100)	COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeCode					varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	OfficeName					varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentCode				varchar(4)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
	DepartmentName				varchar(30)		COLLATE		SQL_Latin1_General_CP1_CS_AS,
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
INSERT INTO #SecUserAppAccess
SELECT
	sua.SEC_USER_ID,
	su.USER_CODE,
	su.EMP_CODE,
	CASE WHEN e.EMP_MI IS NULL OR e.EMP_MI = '' THEN e.EMP_FNAME + ' ' + e.EMP_LNAME ELSE e.EMP_FNAME + ' ' + e.EMP_MI + '. ' + e.EMP_LNAME END,
	e.OFFICE_CODE,
	o.OFFICE_NAME,
	e.DP_TM_CODE,
	dt.DP_TM_DESC,	
	sam.SEC_APPLICATION_ID,
	sa.NAME AS ApplicationName,
	ISNULL(sua.IS_BLOCKED,0),
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
	JOIN dbo.SEC_MODULE as sm ON sm.SEC_MODULE_ID = sam.SEC_MODULE_ID
	JOIN dbo.V_SEC_MODULES_STRUCT AS vsms ON vsms.ModuleID = sm.SEC_MODULE_ID
	JOIN dbo.SEC_USER_APPACCESS AS sua ON sua.SEC_APPLICATION_ID = sa.SEC_APPLICATION_ID
	JOIN dbo.SEC_USER AS su ON su.SEC_USER_ID = sua.SEC_USER_ID
	JOIN dbo.EMPLOYEE as e ON e.EMP_CODE = su.EMP_CODE
	LEFT JOIN dbo.OFFICE AS o ON o.OFFICE_CODE = e.OFFICE_CODE
	LEFT JOIN dbo.DEPT_TEAM AS dt ON dt.DP_TM_CODE = e.DP_TM_CODE
WHERE ISNULL(sm.IS_CATEGORY,0)=0 AND (@user_list IS NULL OR (@user_list IS NOT NULL AND su.SEC_USER_ID IN (SELECT * from dbo.udf_split_list(@user_list, ','))))	

-- ======================
-- BEGIN MAIN DATA GATHER
-- ======================
INSERT INTO #SecUserModuleAccess
SELECT
	suaa.UserID,
	suaa.UserCode,
	suaa.EmployeeCode,
	suaa.EmployeeName,
	suaa.OfficeCode,
	suaa.OfficeName,
	suaa.DepartmentCode,
	suaa.DepartmentName,
	suaa.ApplicationID,
	suaa.ApplicationName,
	suaa.ApplicationIsBlocked,
	suaa.ModuleID,
	suaa.ParentModule,
	suaa.SubParentModule,
	suaa.SubSubParentModule,
	suaa.Module,
	ISNULL(suma.IS_BLOCKED,0),
	ISNULL(suma.CAN_PRINT,0),
	ISNULL(suma.CAN_UPDATE,0),
	ISNULL(suma.CAN_ADD,0),
	ISNULL(suma.CUSTOM1,0),
	ISNULL(suma.CUSTOM2,0),
	suaa.ParentModuleSortOrder,
	suaa.SubParentModuleSortOrder,
	suaa.SubSubParentModuleSortOrder,
	suaa.ModuleSortOrder
FROM #SecUserAppAccess AS suaa
	JOIN dbo.SEC_USER_MODACCESS AS suma ON suma.SEC_USER_ID = suaa.UserID AND suma.SEC_MODULE_ID = suaa.ModuleID
WHERE 1 = CASE WHEN @show_only_accessible = 1 AND ISNULL(suma.IS_BLOCKED,0) = 1 THEN 0 ELSE 1 END

IF @include_terminated = 0
	SELECT
		UserID,
		UserCode,
		EmployeeCode,
		EmployeeName,
		OfficeCode,
		OfficeName,
		DepartmentCode,
		DepartmentName,
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
	FROM #SecUserModuleAccess AS suma
	JOIN dbo.EMPLOYEE AS e ON e.EMP_CODE = suma.EmployeeCode
	WHERE e.EMP_TERM_DATE IS NULL
	ORDER BY UserID, ApplicationID, ParentModuleSortOrder, SubParentModuleSortOrder, SubSubParentModuleSortOrder, ModuleSortOrder
		ELSE
			SELECT
				UserID,
				UserCode,
				EmployeeCode,
				EmployeeName,
				OfficeCode,
				OfficeName,
				DepartmentCode,
				DepartmentName,
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
		FROM #SecUserModuleAccess
		ORDER BY UserID, ApplicationID, ParentModuleSortOrder, SubParentModuleSortOrder, SubSubParentModuleSortOrder, ModuleSortOrder
END
GO

BEGIN
	
	GRANT EXECUTE ON [advsp_sec_user_module_access]TO PUBLIC 

END
GO
