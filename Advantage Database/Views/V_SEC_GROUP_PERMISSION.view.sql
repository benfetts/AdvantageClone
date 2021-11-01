CREATE VIEW [dbo].[V_SEC_GROUP_PERMISSION]

WITH SCHEMABINDING 
AS

	SELECT
		[ID] = NEWID(),
		[ApplicationID] = ISNULL(MA.ApplicationID, 0),
		[ModuleID] = ISNULL(MA.ModuleID, 0),
		[ModuleCode] = ISNULL(MA.ModuleCode, ''),
		[Module] = ISNULL(MA.Module, ''),
		[ModuleIsCategory] = ISNULL(MA.ModuleIsCategory, 0),
		[ModuleInfoID] = ISNULL(MA.ModuleInfoID, 0),
		[GroupID] = MA.[GroupID],
		[GroupName] = MA.[GroupName],
		[GroupDescription] = MA.[GroupDescription],
		[IsBlocked] = ISNULL(CAST(MIN(CAST(MA.GroupIsBlocked AS int)) AS bit), 0),
		[CanPrint] = ISNULL(CAST(MAX(CAST(MA.GroupCanPrint AS int)) AS bit), 0),
		[CanUpdate] = ISNULL(CAST(MAX(CAST(MA.GroupCanUpdate AS int)) AS bit), 0),
		[CanAdd] = ISNULL(CAST(MAX(CAST(MA.GroupCanAdd AS int)) AS bit), 0),
		[Custom1] = ISNULL(CAST(MAX(CAST(MA.GroupCustom1 AS int)) AS bit), 0),
		[Custom2] = ISNULL(CAST(MAX(CAST(MA.GroupCustom2 AS int)) AS bit), 0),
		[ApplicationIsBlocked] = ISNULL(CAST(MIN(CAST(MA.GroupApplicationIsBlocked AS int)) AS bit), 0),
		[ApplicationCanPrint] = ISNULL(CAST(MAX(CAST(MA.GroupApplicationCanPrint AS int)) AS bit), 0),
		[ApplicationCanUpdate] = ISNULL(CAST(MAX(CAST(MA.GroupApplicationCanUpdate AS int)) AS bit), 0),
		[ApplicationCanAdd] = ISNULL(CAST(MAX(CAST(MA.GroupApplicationCanAdd AS int)) AS bit), 0),
		[ApplicationCustom1] = ISNULL(CAST(MAX(CAST(MA.GroupApplicationCustom1 AS int)) AS bit), 0),
		[ApplicationCustom2] = ISNULL(CAST(MAX(CAST(MA.GroupApplicationCustom2 AS int)) AS bit), 0)
	FROM
		(SELECT
			[ApplicationID] = AM.SEC_APPLICATION_ID,
			[ModuleID] = M.SEC_MODULE_ID,
			[ModuleCode] = M.SEC_MODULE_CODE,
			[Module] = M.[DESCRIPTION],
			[ModuleIsCategory] = M.IS_CATEGORY,
			[ModuleInfoID] = M.SEC_MODULE_INFO_ID,
			[GroupID] = ISNULL(G.SEC_GROUP_ID, 0),
			[GroupName] = G.NAME,
			[GroupDescription] = G.[DESCRIPTION],
			[GroupIsBlocked] = ISNULL(GMA.IS_BLOCKED, 1),
			[GroupCanPrint] = ISNULL(GMA.CAN_PRINT, 0),
			[GroupCanUpdate] = ISNULL(GMA.CAN_UPDATE, 0),
			[GroupCanAdd] = ISNULL(GMA.CAN_ADD, 0),
			[GroupCustom1] = ISNULL(GMA.CUSTOM1, 0),
			[GroupCustom2] = ISNULL(GMA.CUSTOM2, 0),
			[GroupApplicationIsBlocked] = ISNULL(GAA.IS_BLOCKED, 1),
			[GroupApplicationCanPrint]  = ISNULL(GAA.CAN_PRINT, 0),
			[GroupApplicationCanUpdate] = ISNULL(GAA.CAN_UPDATE, 0),
			[GroupApplicationCanAdd] = ISNULL(GAA.CAN_ADD, 0),
			[GroupApplicationCustom1] = ISNULL(GAA.CUSTOM1, 0),
			[GroupApplicationCustom2] = ISNULL(GAA.CUSTOM2, 0)
		FROM
			[dbo].[SEC_APPLICATION_MOD] AM LEFT OUTER JOIN
			[dbo].[SEC_MODULE] M ON M.SEC_MODULE_ID = AM.SEC_MODULE_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_MODACCESS] GMA ON GMA.SEC_MODULE_ID = M.SEC_MODULE_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP] G ON G.SEC_GROUP_ID = GMA.SEC_GROUP_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_APPACCESS] GAA ON GAA.SEC_APPLICATION_ID = AM.SEC_APPLICATION_ID AND
											   GAA.SEC_GROUP_ID = G.SEC_GROUP_ID) AS MA
	GROUP BY
		MA.ApplicationID,
		MA.ModuleID,
		MA.ModuleCode,
		MA.Module,
		MA.ModuleIsCategory,
		MA.ModuleInfoID,
		MA.GroupID,
		MA.GroupName,
		MA.GroupDescription
		


GO


