CREATE VIEW [dbo].[V_SEC_UDR_PERMISSION]

WITH SCHEMABINDING 
AS

	SELECT
		[ID] = NEWID(),
		[UserDefinedReportID] = ISNULL(MA.UserDefinedReportID, 0),
		[UserDefinedReportName] = ISNULL(MA.UserDefinedReportName, ''),
		[UserDefinedReportCategoryID] = MA.UserDefinedReportCategoryID,
		[UserID] = ISNULL(MA.UserID, 0),
		[UserCode] = ISNULL(MA.UserCode, ''),
		[EmployeeCode] = ISNULL(MA.EmployeeCode, ''),
		[IsBlocked] = ISNULL(CAST(CASE WHEN MAX(MA.GroupID) > 0 AND MIN(CAST(MA.GroupIsBlocked AS int)) = 0 THEN 0 
									   ELSE 
											CASE 
												WHEN MAX(MA.GroupID) = 0 OR MAX(CAST(MA.UserCheckUserAccess AS int)) = 1 THEN MIN(CAST(MA.UserIsBlocked AS int)) 
												ELSE 1 
												END 
										END AS bit), 0)
	FROM
		(SELECT
			[UserDefinedReportID] = UDR.USER_DEF_REPORT_ID,
			[UserDefinedReportName] = UDR.[DESCRIPTION],
			[UserDefinedReportCategoryID] = UDR.UDR_REPORT_CATEGORY_ID,
			[UserID] = ISNULL(U.SEC_USER_ID, 0),
			[UserCode] = ISNULL(U.USER_CODE, ''),
			[EmployeeCode] = ISNULL(U.EMP_CODE, ''),
			[UserCheckUserAccess] = ISNULL(U.[CHECK_USER_ACCESS], 0),
			[UserIsBlocked] = ISNULL(UUDRA.IS_BLOCKED, 1),
			[GroupID] = ISNULL(GU.SEC_GROUP_ID, 0),
			[GroupIsBlocked] = ISNULL(GUDRA.IS_BLOCKED, 1)
		FROM
			[dbo].[USER_DEF_REPORT] UDR LEFT OUTER JOIN
			[dbo].[SEC_USER_UDRACCESS] UUDRA ON UUDRA.USER_DEF_REPORT_ID = UDR.USER_DEF_REPORT_ID LEFT OUTER JOIN
			[dbo].[SEC_USER] U ON U.SEC_USER_ID = UUDRA.SEC_USER_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_USER] GU ON GU.SEC_USER_ID = U.SEC_USER_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP] G ON G.SEC_GROUP_ID = GU.SEC_GROUP_ID LEFT OUTER JOIN
			[dbo].[SEC_GROUP_UDRACCESS] GUDRA ON GUDRA.USER_DEF_REPORT_ID = UDR.USER_DEF_REPORT_ID AND
												 GUDRA.SEC_GROUP_ID = GU.SEC_GROUP_ID) AS MA
	GROUP BY
		MA.UserDefinedReportID,
		MA.UserDefinedReportName,
		MA.UserDefinedReportCategoryID,
		MA.UserID,
		MA.UserCode,
		MA.EmployeeCode

GO
