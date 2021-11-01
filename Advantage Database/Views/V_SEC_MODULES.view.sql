
--> CreateV_SEC_MODULES_110901
CREATE VIEW [dbo].[V_SEC_MODULES]
AS

    SELECT
		[ID] = ISNULL(ROW_NUMBER() OVER(ORDER BY [A].[SEC_APPLICATION_ID]), 0),
		[ApplicationID] = [A].[SEC_APPLICATION_ID],
		[ApplicationName] = [A].[NAME],
		[ApplicationDescription] = [A].[DESCRIPTION],
		[ModuleCode] = [M].[SEC_MODULE_CODE],
		[ModuleInformationID] = [M].[SEC_MODULE_INFO_ID],
		[ModuleID] = [M].[SEC_MODULE_ID],
		[ModuleDescription] = [M].[DESCRIPTION],
		[IsInactive] = [M].[IS_INACTIVE],
		[IsMenuItem] = [M].[IS_MENU_ITEM],
		[IsCategory] = [M].[IS_CATEGORY],
		[IsApplication] = [M].[IS_APPLICATION],
		[IsReport] = [M].[IS_REPORT],
		[IsDesktopObject] = [M].[IS_DESKTOP_OBJECT],
		[IsDashQuery] = [M].[IS_DASH_QUERY],
		[ParentModuleID] = [MS].[PARENT_MODULE_ID],
		[ParentModuleCode] = [PM].[SEC_MODULE_CODE],
		[ParentModuleDescription] = [PM].[DESCRIPTION],
		[ReportIsLocked] = [MI].[WV_RPT_LOCKED],
		[ReportPreviewLocation] = [MI].[WV_RPT_PREVIEWLOCATION],
		[ReportDescription] = [MI].[WV_RPT_DESCRIPTION],
		[ReportImagePath] = [MI].[WV_RPT_IMAGEPATH],
		[ReportImagePathActive] = [MI].[WV_RPT_IMAGEPATHACTIVE],
		[ReportLargeImagePath] = [MI].[WV_RPT_IMAGEPATHLARGE],
		[ReportURL] = [MI].[WV_RPT_URL],
		[DesktopObjectSize] = [MI].[WV_DO_DSIZE],
		[DesktopObjectName] = [MI].[WV_DO_NAME],
		[ImageName] = [MI].[IMAGENAME],
		[SortOrder] = [MI].[SORT_ORDER],
		[HasCustomPermission] = [MI].[CUSTOM_PERMISSION],
		[WebvantageURL] = [MI].[WV_URL],
		[WebvantageImagePathActive] = [MI].[WV_IMAGEPATHACTIVE],
		[WebvantageImagePath] = [MI].[WV_IMAGEPATH],
		[WebvantageLargeImagePath] = [MI].[WV_IMAGEPATHLARGE],
		[AdvantageApplicationName] = [MI].[PB_APPNAME],
		[AdvantageMenuName] = [MI].[PB_MENU],
		[AdvantageApplicationCode] = [MI].[PB_NAME],
		[AdvantageCommandString] = [MI].[PB_COMMAND_STRING],
		[AdvantageIconIndex] = [MI].[PB_ICON],
		[AdvantageAllowMultipleInstances] = [MI].[PB_ALLOW_MULTI]
	FROM
		[dbo].[SEC_APPLICATION] [A] INNER JOIN
		[dbo].[SEC_APPLICATION_MOD] [AM] ON [A].[SEC_APPLICATION_ID] = [AM].[SEC_APPLICATION_ID] INNER JOIN
		[dbo].[SEC_MODULE] [M] ON [M].[SEC_MODULE_ID] = [AM].[SEC_MODULE_ID] LEFT OUTER JOIN
		[dbo].[SEC_MODULE_SUB] [MS] ON [MS].[SEC_MODULE_ID] = [M].[SEC_MODULE_ID] INNER JOIN
		[dbo].[SEC_MODULE_INFO] [MI] ON [MI].[SEC_MODULE_INFO_ID] = [M].[SEC_MODULE_INFO_ID] LEFT OUTER JOIN
		[dbo].[SEC_MODULE] [PM] ON [PM].[SEC_MODULE_ID] = [MS].[PARENT_MODULE_ID]

		
