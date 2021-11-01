CREATE PROCEDURE [dbo].[advsp_campaign_load_by_usercode] (
	@UserCode varchar(100)
) 
AS
BEGIN

	DECLARE @Restrictions int

	SELECT
		 @Restrictions = COUNT(*) 
	FROM 
		dbo.SEC_CLIENT
	WHERE 
		UPPER([USER_ID]) = UPPER(@UserCode)
	
	CREATE TABLE #CampaignIDs(CampaignID int NOT NULL)
	CREATE TABLE #UniqueClients(ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)
	CREATE TABLE #UniqueDivisions(CDCode varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)
	CREATE TABLE #UniqueProducts(CDPCode varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)

	IF @Restrictions > 0 BEGIN

		INSERT INTO #UniqueClients(ClientCode)
		SELECT
			DISTINCT CL_CODE
		FROM
			dbo.SEC_CLIENT
		WHERE 
			UPPER([USER_ID]) = UPPER(@UserCode)

		INSERT INTO #UniqueDivisions(CDCode)
		SELECT
			DISTINCT CL_CODE + '|' + DIV_CODE
		FROM
			dbo.SEC_CLIENT
		WHERE 
			UPPER([USER_ID]) = UPPER(@UserCode)

		INSERT INTO #UniqueProducts(CDPCode)
		SELECT
			DISTINCT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE
		FROM
			dbo.SEC_CLIENT
		WHERE 
			UPPER([USER_ID]) = UPPER(@UserCode)

		INSERT INTO #CampaignIDs(CampaignID)
		SELECT 
			DISTINCT CAMP.CMP_IDENTIFIER
		FROM  
			[dbo].[V_CAMPAIGN] AS CAMP
			INNER JOIN #UniqueProducts AS UP ON UP.CDPCode = CAST(CAMP.CL_CODE + '|' + CAMP.DIV_CODE + '|' + CAMP.PRD_CODE AS varchar(30))
		WHERE
			CAMP.CMP_IDENTIFIER NOT IN (SELECT CampaignID FROM #CampaignIDs)
		
		INSERT INTO #CampaignIDs(CampaignID)
		SELECT 
			DISTINCT CAMP.CMP_IDENTIFIER
		FROM  
			[dbo].[V_CAMPAIGN] AS CAMP
			INNER JOIN #UniqueDivisions AS UD ON UD.CDCode = CAMP.CL_CODE + '|' + CAMP.DIV_CODE AND CAMP.PRD_CODE IS NULL
		WHERE
			CAMP.CMP_IDENTIFIER NOT IN (SELECT CampaignID FROM #CampaignIDs)
		
		INSERT INTO #CampaignIDs(CampaignID)
		SELECT 
			DISTINCT CAMP.CMP_IDENTIFIER
		FROM  
			[dbo].[V_CAMPAIGN] AS CAMP
			INNER JOIN #UniqueClients AS UC ON UC.ClientCode = CAMP.CL_CODE AND CAMP.DIV_CODE IS NULL AND CAMP.PRD_CODE IS NULL
		WHERE
			CAMP.CMP_IDENTIFIER NOT IN (SELECT CampaignID FROM #CampaignIDs)

	END ELSE BEGIN

		INSERT INTO #CampaignIDs(CampaignID)
		SELECT 
			DISTINCT CAMP.CMP_IDENTIFIER
		FROM  
			[dbo].[V_CAMPAIGN] AS CAMP

	END

	SELECT 
		CampaignCode = CAMP.CMP_CODE,
		CampaignName = CAMP.CMP_NAME,
		ID = CAMP.CMP_IDENTIFIER,
		IsClosed = CAMP.CMP_CLOSED,
		IsActive = CAMP.ACTIVE_FLAG,
		CampaignType = CAMP.CMP_TYPE,
		ClientCode = CAMP.CL_CODE,
		ClientName = CAMP.CL_NAME,
		DivisionCode = CAMP.DIV_CODE,
		DivisionName = CAMP.DIV_NAME,
		ProductCode = CAMP.PRD_CODE,
		ProductDescription = CAMP.PRD_DESCRIPTION,
		OfficeCode = CAMP.OFFICE_CODE,
		OfficeName = CAMP.OFFICE_NAME
	FROM  
		[dbo].[V_CAMPAIGN] AS CAMP
	WHERE
		CAMP.CMP_IDENTIFIER IN (SELECT CampaignID FROM #CampaignIDs)

	DROP TABLE #CampaignIDs
	DROP TABLE #UniqueClients
	DROP TABLE #UniqueDivisions
	DROP TABLE #UniqueProducts

END
GO