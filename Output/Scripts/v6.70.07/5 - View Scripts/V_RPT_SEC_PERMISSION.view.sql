CREATE VIEW [dbo].[V_RPT_SEC_PERMISSION]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		SP.ApplicationID,
		MS.ParentModuleID,
		MS.ParentModule,
		MS.ParentModuleSortOrder,
		MS.SubParentModuleID,
		MS.SubParentModule,
		MS.SubParentModuleSortOrder,
		MS.SubSubParentModuleID,
		MS.SubSubParentModule,
		MS.SubSubParentModuleSortOrder,
		SP.ModuleID,
		SP.ModuleCode,
		SP.Module,
		SP.ModuleIsCategory,
		SP.ModuleInfoID,
		MS.ModuleSortOrder,
		MS.ModuleHasCustomPermission,
		SP.UserID,
		SP.UserCode,
		SP.EmployeeCode,
		[Employee] = E.EMP_CODE + ' - ' + COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''),
		SP.IsBlocked,
		SP.CanPrint,
		SP.CanUpdate,
		SP.CanAdd,
		SP.Custom1,
		SP.Custom2,
		SP.ApplicationIsBlocked,
		SP.ApplicationCanPrint,
		SP.ApplicationCanUpdate,
		SP.ApplicationCanAdd,
		SP.ApplicationCustom1,
		SP.ApplicationCustom2
	FROM 
		[dbo].[V_SEC_PERMISSION] SP INNER JOIN
		[dbo].[V_SEC_MODULES_STRUCT] MS ON MS.ModuleID = SP.ModuleID INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] E ON E.EMP_CODE = SP.EmployeeCode


GO




