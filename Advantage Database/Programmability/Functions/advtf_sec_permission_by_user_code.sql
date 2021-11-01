IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_sec_permission_by_user_code]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_sec_permission_by_user_code]
GO

CREATE FUNCTION [dbo].[advtf_sec_permission_by_user_code] (
@APPLICATION_ID INT,
@USER_CODE VARCHAR(100),
@MODULE_CODE VARCHAR(100)
)
RETURNS @PERMISSIONS TABLE (
	[ApplicationID] [int] NOT NULL,
	[ModuleID] [int] NOT NULL,
	[ModuleCode] [varchar](100) NOT NULL,
	[Module] [varchar](100) NOT NULL,
	[ModuleIsCategory] [bit] NOT NULL,
	[ModuleInfoID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserCode] [varchar](100) NOT NULL,
	[EmployeeCode] [varchar](6) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[CanPrint] [bit] NOT NULL,
	[CanUpdate] [bit] NOT NULL,
	[CanAdd] [bit] NOT NULL,
	[Custom1] [bit] NOT NULL,
	[Custom2] [bit] NOT NULL,
	[ApplicationIsBlocked] [bit] NOT NULL,
	[ApplicationCanPrint] [bit] NOT NULL,
	[ApplicationCanUpdate] [bit] NOT NULL,
	[ApplicationCanAdd] [bit] NOT NULL,
	[ApplicationCustom1] [bit] NOT NULL,
	[ApplicationCustom2] [bit] NOT NULL
)
AS
BEGIN

INSERT INTO @PERMISSIONS
-- THIS QUERY IS THE QUERY INSIDE V_SEC_PERMISSION WITH ADDED WHERE CLAUSE AND NO ID (SQL NEWID) COLUMN
	SELECT
		[ApplicationID] = ISNULL(MA.ApplicationID, 0),
		[ModuleID] = ISNULL(MA.ModuleID, 0),
		[ModuleCode] = ISNULL(MA.ModuleCode, ''),
		[Module] = ISNULL(MA.Module, ''),
		[ModuleIsCategory] = ISNULL(MA.ModuleIsCategory, 0),
		[ModuleInfoID] = ISNULL(MA.ModuleInfoID, 0),
		[UserID] = ISNULL(MA.UserID, 0),
		[UserCode] = ISNULL(MA.UserCode, ''),
		[EmployeeCode] = ISNULL(MA.EmployeeCode, ''),
		[IsBlocked] = ISNULL(CAST(CASE WHEN ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MIN(CAST(MA.GroupApplicationIsBlocked AS int)) = 0 THEN 0 
															 ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MIN(CAST(MA.UserApplicationIsBlocked AS int)) 
																	   ELSE 1 END END AS bit), 0) = 1 THEN 1 
									   ELSE
											CASE 
											WHEN MAX(MA.UserTimeEntryOnly) = 1 AND MA.ApplicationID = 1 THEN 
												CASE 
													WHEN MA.ModuleCode = 'Employee_Timesheet' THEN 0 
													WHEN MA.ModuleCode = 'ProjectManagement_QuoteApproval' OR MA.ModuleCode = 'Maintenance_Client_ClientContact' OR MA.ModuleCode = 'FinanceAccounting_JobProcessCtrl' THEN 
														CASE 
															WHEN MAX(MA.GroupID) > 0 AND MIN(CAST(MA.GroupIsBlocked AS int)) = 0 THEN 0 
															ELSE 
																CASE 
																	WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MIN(CAST(MA.UserIsBlocked AS int)) 
																	ELSE 1 
																	END 
															END 
													ELSE 1 
													END
											ELSE 
												CASE 
													WHEN MAX(MA.GroupID) > 0 AND MIN(CAST(MA.GroupIsBlocked AS int)) = 0 THEN 0 
													ELSE 
														CASE 
															WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MIN(CAST(MA.UserIsBlocked AS int)) 
															ELSE 1 
															END 
													END
											END 
									END AS bit), 0),
		[CanPrint] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupCanPrint AS int)) = 1 THEN 1 
									   ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserCanPrint AS int)) 
												 ELSE 0 END END AS bit), 0),
		[CanUpdate] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupCanUpdate AS int)) = 1 THEN 1 
										ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserCanUpdate AS int)) 
												  ELSE 0 END END AS bit), 0),
		[CanAdd] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupCanAdd AS int)) = 1 THEN 1 
									ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserCanAdd AS int)) 
											  ELSE 0 END END AS bit), 0),
		[Custom1] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupCustom1 AS int)) = 1 THEN 1 
									  ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserCustom1 AS int)) 
												ELSE 0 END END AS bit), 0),
		[Custom2] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupCustom2 AS int)) = 1 THEN 1 
									  ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserCustom2 AS int)) 
												ELSE 0 END END AS bit), 0),
		[ApplicationIsBlocked] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MIN(CAST(MA.GroupApplicationIsBlocked AS int)) = 0 THEN 0 
												  ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MIN(CAST(MA.UserApplicationIsBlocked AS int)) 
													   ELSE 1 END END AS bit), 0),
		[ApplicationCanPrint] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupApplicationCanPrint AS int)) = 1 THEN 1 
												 ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserApplicationCanPrint AS int)) 
														   ELSE 0 END END AS bit), 0),
		[ApplicationCanUpdate] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupApplicationCanUpdate AS int)) = 1 THEN 1 
												  ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserApplicationCanUpdate AS int)) 
														    ELSE 0 END END AS bit), 0),
		[ApplicationCanAdd] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupApplicationCanAdd AS int)) = 1 THEN 1 
											   ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserApplicationCanAdd AS int)) 
														 ELSE 0 END END AS bit), 0),
		[ApplicationCustom1] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupApplicationCustom1 AS int)) = 1 THEN 1 
									  ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserApplicationCustom1 AS int)) 
												ELSE 0 END END AS bit), 0),
		[ApplicationCustom2] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MAX(CAST(MA.GroupApplicationCustom2 AS int)) = 1 THEN 1 
											    ELSE CASE WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MAX(CAST(MA.UserApplicationCustom2 AS int)) 
														  ELSE 0 END END AS bit), 0)
	FROM
		(SELECT
			[ApplicationID] = AM.SEC_APPLICATION_ID,
			[ModuleID] = M.SEC_MODULE_ID,
			[ModuleCode] = M.SEC_MODULE_CODE,
			[Module] = M.[DESCRIPTION],
			[ModuleIsCategory] = M.IS_CATEGORY,
			[ModuleInfoID] = M.SEC_MODULE_INFO_ID,
			[UserID] = ISNULL(U.SEC_USER_ID, 0),
			[UserCode] = ISNULL(U.USER_CODE, ''),
			[EmployeeCode] = ISNULL(U.EMP_CODE, ''),
			[UserCheckUserAccess] = ISNULL(U.[CHECK_USER_ACCESS], 0),
			[UserTimeEntryOnly] = CASE WHEN UPPER(ISNULL(US.[STRING_VALUE], 'N')) = 'Y' THEN 1 ELSE 0 END,
			[UserIsBlocked] = ISNULL(UMA.IS_BLOCKED, 1),
			[UserCanPrint] = ISNULL(UMA.CAN_PRINT, 0),
			[UserCanUpdate] = ISNULL(UMA.CAN_UPDATE, 0),
			[UserCanAdd] = ISNULL(UMA.CAN_ADD, 0),
			[UserCustom1] = ISNULL(UMA.CUSTOM1, 0),
			[UserCustom2] = ISNULL(UMA.CUSTOM2, 0),
			[GroupID] = ISNULL(GU.SEC_GROUP_ID, 0),
			[GroupIsBlocked] = ISNULL(GMA.IS_BLOCKED, 1),
			[GroupCanPrint] = ISNULL(GMA.CAN_PRINT, 0),
			[GroupCanUpdate] = ISNULL(GMA.CAN_UPDATE, 0),
			[GroupCanAdd] = ISNULL(GMA.CAN_ADD, 0),
			[GroupCustom1] = ISNULL(GMA.CUSTOM1, 0),
			[GroupCustom2] = ISNULL(GMA.CUSTOM2, 0),
			[UserApplicationIsBlocked] = ISNULL(UAA.IS_BLOCKED, 1),
			[UserApplicationCanPrint]  = ISNULL(UAA.CAN_PRINT, 0),
			[UserApplicationCanUpdate] = ISNULL(UAA.CAN_UPDATE, 0),
			[UserApplicationCanAdd] = ISNULL(UAA.CAN_ADD, 0),
			[UserApplicationCustom1] = ISNULL(UAA.CUSTOM1, 0),
			[UserApplicationCustom2] = ISNULL(UAA.CUSTOM2, 0),
			[GroupApplicationIsBlocked] = ISNULL(GAA.IS_BLOCKED, 1),
			[GroupApplicationCanPrint]  = ISNULL(GAA.CAN_PRINT, 0),
			[GroupApplicationCanUpdate] = ISNULL(GAA.CAN_UPDATE, 0),
			[GroupApplicationCanAdd] = ISNULL(GAA.CAN_ADD, 0),
			[GroupApplicationCustom1] = ISNULL(GAA.CUSTOM1, 0),
			[GroupApplicationCustom2] = ISNULL(GAA.CUSTOM2, 0)
		FROM
			[dbo].[SEC_APPLICATION_MOD] AM LEFT OUTER JOIN
			[dbo].[SEC_MODULE] M ON M.SEC_MODULE_ID = AM.SEC_MODULE_ID LEFT OUTER JOIN
			[dbo].[SEC_USER_MODACCESS] UMA ON UMA.SEC_MODULE_ID = M.SEC_MODULE_ID LEFT OUTER JOIN
			[dbo].[SEC_USER] U ON U.SEC_USER_ID = UMA.SEC_USER_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_USER] GU ON GU.SEC_USER_ID = U.SEC_USER_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_MODACCESS] GMA ON GMA.SEC_MODULE_ID = M.SEC_MODULE_ID AND
											   GMA.SEC_GROUP_ID = GU.SEC_GROUP_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_APPACCESS] GAA ON GAA.SEC_APPLICATION_ID = AM.SEC_APPLICATION_ID AND
											   GAA.SEC_GROUP_ID = GU.SEC_GROUP_ID LEFT OUTER JOIN
			[dbo].[SEC_USER_APPACCESS] UAA ON UAA.SEC_APPLICATION_ID = AM.SEC_APPLICATION_ID AND
											  UAA.SEC_USER_ID = U.SEC_USER_ID LEFT OUTER JOIN
			[dbo].[SEC_USER_SETTING] US ON US.SEC_USER_ID = U.SEC_USER_ID AND
										   US.SETTING_CODE = 'TIME_ENTRY_ONLY'
		WHERE
			AM.SEC_APPLICATION_ID = @APPLICATION_ID
			AND UPPER(U.USER_CODE) = UPPER(@USER_CODE)
			AND CASE WHEN @MODULE_CODE IS NULL THEN 1 WHEN M.SEC_MODULE_CODE = @MODULE_CODE THEN 1 END = 1									
										   ) AS MA
	GROUP BY
		MA.ApplicationID,
		MA.ModuleID,
		MA.ModuleCode,
		MA.Module,
		MA.ModuleIsCategory,
		MA.ModuleInfoID,
		MA.UserID,
		MA.UserCode,
		MA.EmployeeCode

	RETURN

END
GO