CREATE PROCEDURE [dbo].[advsp_imp_digital_results_auto_resolve_data] 
	@BATCH_NAME VARCHAR(50)
AS
BEGIN

	UPDATE 
		dbo.IMP_DIGITAL_RESULTS_STAGING 
	SET
		CL_CODE = IMP_TABLE.CL_CODE,
		CL_NAME = IMP_TABLE.CL_NAME,
		DIV_CODE = IMP_TABLE.DIV_CODE,
		PRD_CODE = IMP_TABLE.PRD_CODE,
		CMP_CODE = IMP_TABLE.CMP_CODE,
		CMP_IDENTIFIER = IMP_TABLE.CMP_IDENTIFIER,
		CMP_NAME = IMP_TABLE.CMP_NAME,
		VN_CODE = IMP_TABLE.VN_CODE,
		VN_NAME = IMP_TABLE.VN_NAME,
		AD_NBR = IMP_TABLE.AD_NBR,
		AD_NBR_DESC = IMP_TABLE.AD_NBR_DESC,
		JOB_NUMBER = IMP_TABLE.JOB_NUMBER,
		JOB_DESC = IMP_TABLE.JOB_DESC,
		JOB_COMPONENT_NBR = IMP_TABLE.JOB_COMPONENT_NBR,
		JOB_COMP_DESC = IMP_TABLE.JOB_COMP_DESC,
		MARKET_CODE = IMP_TABLE.MARKET_CODE,
		MARKET_DESC = IMP_TABLE.MARKET_DESC,
		INTERNET_TYPE_CODE = IMP_TABLE.OD_CODE,
		OD_DESC = IMP_TABLE.OD_DESC,
		AD_SIZE_CODE = IMP_TABLE.AD_SIZE_CODE,
		AD_SIZE_DESC = IMP_TABLE.AD_SIZE_DESC
	FROM
		IMP_DIGITAL_RESULTS_STAGING INNER JOIN 
		(SELECT 
			[ID] = IMP_DIGITAL_RESULTS_STAGING.IMPORT_ID,
			[CL_CODE] = CASE
							WHEN V_JOB_LOG.CL_CODE IS NOT NULL THEN V_JOB_LOG.CL_CODE
							WHEN JOB_NAMES.CL_CODE IS NOT NULL THEN JOB_NAMES.CL_CODE
							WHEN CLIENT.CL_CODE IS NOT NULL THEN CLIENT.CL_CODE
							WHEN CL_NAMES.CL_CODE IS NOT NULL THEN CL_NAMES.CL_CODE
							WHEN IMP_DIGITAL_RESULTS_STAGING.CL_CODE <> '' THEN IMP_DIGITAL_RESULTS_STAGING.CL_CODE
						END,
			[CL_NAME] = CASE 
							WHEN V_JOB_LOG.CL_CODE IS NOT NULL THEN V_JOB_LOG.CL_NAME
							WHEN JOB_NAMES.CL_CODE IS NOT NULL THEN JOB_NAMES.CL_NAME
							WHEN CLIENT.CL_NAME IS NOT NULL THEN CLIENT.CL_NAME
							WHEN CL_NAMES.CL_NAME IS NOT NULL THEN CL_NAMES.CL_NAME
							WHEN IMP_DIGITAL_RESULTS_STAGING.CL_NAME <> '' THEN IMP_DIGITAL_RESULTS_STAGING.CL_NAME
						END,
			[DIV_CODE] = CASE
							WHEN V_JOB_LOG.DIV_CODE IS NOT NULL THEN V_JOB_LOG.DIV_CODE
							WHEN JOB_NAMES.DIV_CODE IS NOT NULL THEN JOB_NAMES.DIV_CODE
							ELSE IMP_DIGITAL_RESULTS_STAGING.DIV_CODE
						END,
			[PRD_CODE] = CASE
							WHEN V_JOB_LOG.PRD_CODE IS NOT NULL THEN V_JOB_LOG.PRD_CODE
							WHEN JOB_NAMES.PRD_CODE IS NOT NULL THEN JOB_NAMES.PRD_CODE
							ELSE IMP_DIGITAL_RESULTS_STAGING.PRD_CODE
						END,
			[CMP_CODE] = CASE 
							WHEN CAMPAIGN.CMP_CODE IS NOT NULL THEN CAMPAIGN.CMP_CODE
							WHEN CMP_CODES.CMP_CODE IS NOT NULL THEN CMP_CODES.CMP_CODE
							WHEN CMP_NAMES.CMP_CODE IS NOT NULL THEN CMP_NAMES.CMP_CODE
							WHEN CMP_CODES_AND_NAMES.CMP_CODE IS NOT NULL THEN CMP_CODES_AND_NAMES.CMP_CODE
							WHEN IMP_DIGITAL_RESULTS_STAGING.CMP_CODE <> '' THEN IMP_DIGITAL_RESULTS_STAGING.CMP_CODE
						 END,
			[CMP_IDENTIFIER] = CASE
								  WHEN CAMPAIGN.CMP_IDENTIFIER IS NOT NULL THEN CAMPAIGN.CMP_IDENTIFIER
								  WHEN CMP_CODES.CMP_IDENTIFIER IS NOT NULL THEN CMP_CODES.CMP_IDENTIFIER
								  WHEN CMP_NAMES.CMP_IDENTIFIER IS NOT NULL THEN CMP_NAMES.CMP_IDENTIFIER
								  WHEN CMP_CODES_AND_NAMES.CMP_IDENTIFIER IS NOT NULL THEN CMP_CODES_AND_NAMES.CMP_IDENTIFIER
								  ELSE IMP_DIGITAL_RESULTS_STAGING.CMP_IDENTIFIER
							   END,
			[CMP_NAME] = CASE
							WHEN CAMPAIGN.CMP_NAME IS NOT NULL THEN CAMPAIGN.CMP_NAME
							WHEN CMP_CODES.CMP_NAME IS NOT NULL THEN CMP_CODES.CMP_NAME
							WHEN CMP_NAMES.CMP_NAME IS NOT NULL THEN CMP_NAMES.CMP_NAME
							WHEN CMP_CODES_AND_NAMES.CMP_NAME IS NOT NULL THEN CMP_CODES_AND_NAMES.CMP_NAME
							WHEN IMP_DIGITAL_RESULTS_STAGING.CMP_NAME <> '' THEN IMP_DIGITAL_RESULTS_STAGING.CMP_NAME
						 END,
			[VN_CODE] = CASE 
							WHEN VENDOR.VN_CODE IS NOT NULL THEN VENDOR.VN_CODE
							WHEN VN_NAMES.VN_CODE IS NOT NULL THEN VN_NAMES.VN_CODE
							WHEN IMP_DIGITAL_RESULTS_STAGING.VN_CODE <> '' THEN IMP_DIGITAL_RESULTS_STAGING.VN_CODE
						END,
			[VN_NAME] = CASE 
							WHEN VENDOR.VN_NAME IS NOT NULL THEN VENDOR.VN_NAME
							WHEN VN_NAMES.VN_NAME IS NOT NULL THEN VN_NAMES.VN_NAME
							WHEN IMP_DIGITAL_RESULTS_STAGING.VN_NAME <> '' THEN IMP_DIGITAL_RESULTS_STAGING.VN_NAME
						END,
			[AD_NBR] = CASE 
						   WHEN AD_NUMBER.AD_NBR IS NOT NULL THEN AD_NUMBER.AD_NBR
						   WHEN AD_NBR_DESCS.AD_NBR IS NOT NULL THEN AD_NBR_DESCS.AD_NBR
						   WHEN IMP_DIGITAL_RESULTS_STAGING.AD_NBR <> '' THEN IMP_DIGITAL_RESULTS_STAGING.AD_NBR
					   END,
			[AD_NBR_DESC] = CASE 
								WHEN AD_NUMBER.AD_NBR_DESC IS NOT NULL THEN AD_NUMBER.AD_NBR_DESC
								WHEN AD_NBR_DESCS.AD_NBR_DESC IS NOT NULL THEN AD_NBR_DESCS.AD_NBR_DESC
								WHEN IMP_DIGITAL_RESULTS_STAGING.AD_NBR_DESC <> '' THEN IMP_DIGITAL_RESULTS_STAGING.AD_NBR_DESC
							END,
			[JOB_NUMBER] = CASE 
								WHEN V_JOB_LOG.JOB_NUMBER IS NOT NULL THEN V_JOB_LOG.JOB_NUMBER
								WHEN JOB_NAMES.JOB_NUMBER IS NOT NULL THEN JOB_NAMES.JOB_NUMBER
								WHEN ISNULL(IMP_DIGITAL_RESULTS_STAGING.JOB_NUMBER, 0) > 0 THEN IMP_DIGITAL_RESULTS_STAGING.JOB_NUMBER
							END,
			[JOB_DESC] = CASE 
							WHEN V_JOB_LOG.JOB_NUMBER IS NOT NULL THEN V_JOB_LOG.JOB_DESC
							WHEN JOB_NAMES.JOB_DESC IS NOT NULL THEN JOB_NAMES.JOB_DESC
							WHEN IMP_DIGITAL_RESULTS_STAGING.JOB_DESC <> '' THEN IMP_DIGITAL_RESULTS_STAGING.JOB_DESC
						 END,
			[JOB_COMPONENT_NBR] = CASE 
										WHEN JOB_COMPONENT.JOB_COMPONENT_NBR IS NOT NULL THEN JOB_COMPONENT.JOB_COMPONENT_NBR
										WHEN JOB_COMP_NAMES.JOB_COMPONENT_NBR IS NOT NULL THEN JOB_COMP_NAMES.JOB_COMPONENT_NBR
										WHEN ISNULL(IMP_DIGITAL_RESULTS_STAGING.JOB_COMPONENT_NBR, 0) > 0 THEN IMP_DIGITAL_RESULTS_STAGING.JOB_COMPONENT_NBR
								  END,
			[JOB_COMP_DESC] = CASE 
									WHEN JOB_COMPONENT.JOB_COMPONENT_NBR IS NOT NULL THEN JOB_COMPONENT.JOB_COMP_DESC
									WHEN JOB_COMP_NAMES.JOB_COMP_DESC IS NOT NULL THEN JOB_COMP_NAMES.JOB_COMP_DESC
									WHEN IMP_DIGITAL_RESULTS_STAGING.JOB_COMP_DESC <> '' THEN IMP_DIGITAL_RESULTS_STAGING.JOB_COMP_DESC
							  END,
			[MARKET_CODE] = CASE 
								WHEN MARKET.MARKET_CODE IS NOT NULL THEN MARKET.MARKET_CODE
								WHEN MARKET_NAMES.MARKET_CODE IS NOT NULL THEN MARKET_NAMES.MARKET_CODE
								WHEN IMP_DIGITAL_RESULTS_STAGING.MARKET_CODE <> '' THEN IMP_DIGITAL_RESULTS_STAGING.MARKET_CODE
							END,
			[MARKET_DESC] = CASE 
								WHEN MARKET.MARKET_CODE IS NOT NULL THEN MARKET.MARKET_DESC
								WHEN MARKET_NAMES.MARKET_DESC IS NOT NULL THEN MARKET_NAMES.MARKET_DESC
								WHEN IMP_DIGITAL_RESULTS_STAGING.MARKET_DESC <> '' THEN IMP_DIGITAL_RESULTS_STAGING.MARKET_DESC
							END,
			[OD_CODE] = CASE 
							WHEN INTERNET_TYPE.OD_CODE IS NOT NULL THEN INTERNET_TYPE.OD_CODE
							WHEN INTERNET_TYPE_NAMES.OD_CODE IS NOT NULL THEN INTERNET_TYPE_NAMES.OD_CODE
							WHEN IMP_DIGITAL_RESULTS_STAGING.INTERNET_TYPE_CODE <> '' THEN IMP_DIGITAL_RESULTS_STAGING.INTERNET_TYPE_CODE
						END,
			[OD_DESC] = CASE 
							WHEN INTERNET_TYPE.OD_CODE IS NOT NULL THEN INTERNET_TYPE.OD_DESC
							WHEN INTERNET_TYPE_NAMES.OD_DESC IS NOT NULL THEN INTERNET_TYPE_NAMES.OD_DESC
							WHEN IMP_DIGITAL_RESULTS_STAGING.OD_DESC <> '' THEN IMP_DIGITAL_RESULTS_STAGING.OD_DESC
						END,
			[AD_SIZE_CODE] = CASE 
								WHEN AD_SIZE.SIZE_CODE IS NOT NULL THEN AD_SIZE.SIZE_CODE
								WHEN AD_SIZE_NAMES.SIZE_CODE IS NOT NULL THEN AD_SIZE_NAMES.SIZE_CODE
								WHEN IMP_DIGITAL_RESULTS_STAGING.AD_SIZE_CODE <> '' THEN IMP_DIGITAL_RESULTS_STAGING.AD_SIZE_CODE
							 END,
			[AD_SIZE_DESC] = CASE 
								WHEN AD_SIZE.SIZE_CODE IS NOT NULL THEN AD_SIZE.SIZE_DESC
								WHEN AD_SIZE_NAMES.SIZE_DESC IS NOT NULL THEN AD_SIZE_NAMES.SIZE_DESC
								WHEN IMP_DIGITAL_RESULTS_STAGING.AD_SIZE_DESC <> '' THEN IMP_DIGITAL_RESULTS_STAGING.AD_SIZE_DESC
							 END
		FROM
			dbo.IMP_DIGITAL_RESULTS_STAGING LEFT OUTER JOIN
			dbo.CLIENT ON IMP_DIGITAL_RESULTS_STAGING.CL_CODE = CLIENT.CL_CODE LEFT OUTER JOIN
			(SELECT
				[CL_CODE] = MIN(CLIENT.CL_CODE),
				[CL_NAME] = CLIENT.CL_NAME
			 FROM
				dbo.CLIENT
			 GROUP BY
				CL_NAME
			 HAVING
				COUNT(*) = 1) CL_NAMES ON IMP_DIGITAL_RESULTS_STAGING.CL_NAME = CL_NAMES.CL_NAME LEFT OUTER JOIN
			dbo.CAMPAIGN ON IMP_DIGITAL_RESULTS_STAGING.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER LEFT OUTER JOIN
			(SELECT
				[CMP_IDENTIFIER] = MIN(CAMPAIGN.CMP_IDENTIFIER),
				[CMP_CODE] = CAMPAIGN.CMP_CODE,
				[CMP_NAME] = MIN(CMP_NAME)
			 FROM
				dbo.CAMPAIGN
			 GROUP BY
				CMP_CODE
			 HAVING 
				COUNT(*) = 1) CMP_CODES ON IMP_DIGITAL_RESULTS_STAGING.CMP_CODE = CMP_CODES.CMP_CODE LEFT OUTER JOIN
			(SELECT
				[CMP_IDENTIFIER] = MIN(CAMPAIGN.CMP_IDENTIFIER),
				[CMP_CODE] = MIN(CAMPAIGN.CMP_CODE),
				[CMP_NAME] = CMP_NAME
			 FROM
				dbo.CAMPAIGN
			 GROUP BY
				CMP_NAME
			 HAVING 
				COUNT(*) = 1) CMP_NAMES ON IMP_DIGITAL_RESULTS_STAGING.CMP_NAME = CMP_NAMES.CMP_NAME LEFT OUTER JOIN
			(SELECT
				[CMP_IDENTIFIER] = MIN(CAMPAIGN.CMP_IDENTIFIER),
				[CMP_CODE] = CAMPAIGN.CMP_CODE,
				[CMP_NAME] = CMP_NAME
			 FROM
				dbo.CAMPAIGN
			 GROUP BY
				CMP_NAME,
				CMP_CODE
			 HAVING 
				COUNT(*) = 1) CMP_CODES_AND_NAMES ON IMP_DIGITAL_RESULTS_STAGING.CMP_NAME = CMP_CODES_AND_NAMES.CMP_NAME AND
													 IMP_DIGITAL_RESULTS_STAGING.CMP_CODE = CMP_CODES_AND_NAMES.CMP_CODE LEFT OUTER JOIN
			dbo.VENDOR ON IMP_DIGITAL_RESULTS_STAGING.VN_CODE = VENDOR.VN_CODE LEFT OUTER JOIN
			(SELECT	
				[VN_CODE] = MIN(VENDOR.VN_CODE),
				[VN_NAME] = VENDOR.VN_NAME
			 FROM
				dbo.VENDOR
			 GROUP BY 
				VN_NAME
			 HAVING
				COUNT(*) = 1) VN_NAMES ON IMP_DIGITAL_RESULTS_STAGING.VN_NAME = VN_NAMES.VN_NAME LEFT OUTER JOIN
			dbo.AD_NUMBER ON IMP_DIGITAL_RESULTS_STAGING.AD_NBR = AD_NUMBER.AD_NBR LEFT OUTER JOIN
			(SELECT	
				[AD_NBR] = MIN(AD_NUMBER.AD_NBR),
				[AD_NBR_DESC] = AD_NUMBER.AD_NBR_DESC
			 FROM
				dbo.AD_NUMBER
			 GROUP BY
				AD_NBR_DESC
			 HAVING	
				COUNT(*) = 1) AD_NBR_DESCS ON IMP_DIGITAL_RESULTS_STAGING.AD_NBR_DESC = AD_NBR_DESCS.AD_NBR_DESC LEFT OUTER JOIN
			dbo.V_JOB_LOG ON IMP_DIGITAL_RESULTS_STAGING.JOB_NUMBER = V_JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
			(SELECT
				[CL_CODE] = V_JOB_LOG.CL_CODE,
				[CL_NAME] = V_JOB_LOG.CL_NAME,
				[DIV_CODE] = V_JOB_LOG.DIV_CODE,
				[PRD_CODE] = V_JOB_LOG.PRD_CODE,
				[JOB_NUMBER] = MIN(V_JOB_LOG.JOB_NUMBER),
				[JOB_DESC] = V_JOB_LOG.JOB_DESC
			 FROM
				dbo.V_JOB_LOG
			 GROUP BY 
				CL_CODE, CL_NAME, DIV_CODE, PRD_CODE, JOB_DESC
			 HAVING	
				COUNT(*) = 1) JOB_NAMES ON IMP_DIGITAL_RESULTS_STAGING.JOB_DESC = JOB_NAMES.JOB_DESC AND 
										   ISNULL(IMP_DIGITAL_RESULTS_STAGING.CL_CODE, JOB_NAMES.CL_CODE) = JOB_NAMES.CL_CODE AND 
										   ISNULL(IMP_DIGITAL_RESULTS_STAGING.DIV_CODE, JOB_NAMES.DIV_CODE) = JOB_NAMES.DIV_CODE AND
										   ISNULL(IMP_DIGITAL_RESULTS_STAGING.PRD_CODE, JOB_NAMES.PRD_CODE) = JOB_NAMES.PRD_CODE LEFT OUTER JOIN
			dbo.JOB_COMPONENT ON IMP_DIGITAL_RESULTS_STAGING.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND
								 IMP_DIGITAL_RESULTS_STAGING.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
			(SELECT	
				CL_CODE = V_JOB_COMPONENT.CL_CODE,
				CL_NAME = V_JOB_COMPONENT.CL_NAME,
				DIV_CODE = V_JOB_COMPONENT.DIV_CODE,
				PRD_CODE = V_JOB_COMPONENT.PRD_CODE,
				JOB_NUMBER = V_JOB_COMPONENT.JOB_NUMBER,
				JOB_COMPONENT_NBR = MIN(V_JOB_COMPONENT.JOB_COMPONENT_NBR),
				JOB_COMP_DESC = V_JOB_COMPONENT.JOB_COMP_DESC
			 FROM
				dbo.V_JOB_COMPONENT
			 GROUP BY
				CL_CODE, CL_NAME, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMP_DESC
			 HAVING
				COUNT(*) = 1) JOB_COMP_NAMES ON IMP_DIGITAL_RESULTS_STAGING.JOB_COMP_DESC = JOB_COMP_NAMES.JOB_COMP_DESC AND
												ISNULL(IMP_DIGITAL_RESULTS_STAGING.JOB_NUMBER, JOB_COMP_NAMES.JOB_NUMBER)  = JOB_COMP_NAMES.JOB_NUMBER AND
												ISNULL(IMP_DIGITAL_RESULTS_STAGING.CL_CODE, JOB_COMP_NAMES.CL_CODE) = JOB_COMP_NAMES.CL_CODE AND
												ISNULL(IMP_DIGITAL_RESULTS_STAGING.CL_NAME, JOB_COMP_NAMES.CL_NAME) = JOB_COMP_NAMES.CL_NAME AND
												ISNULL(IMP_DIGITAL_RESULTS_STAGING.DIV_CODE, JOB_COMP_NAMES.DIV_CODE) = JOB_COMP_NAMES.DIV_CODE AND
												ISNULL(IMP_DIGITAL_RESULTS_STAGING.PRD_CODE, JOB_COMP_NAMES.PRD_CODE) = JOB_COMP_NAMES.PRD_CODE LEFT OUTER JOIN
			dbo.MARKET ON IMP_DIGITAL_RESULTS_STAGING.MARKET_CODE = MARKET.MARKET_CODE LEFT OUTER JOIn
			(SELECT
				[MARKET_CODE] = MIN(MARKET.MARKET_CODE),
				[MARKET_DESC] = MARKET.MARKET_DESC
			 FROM
				dbo.MARKET
			 GROUP BY
				MARKET_DESC
			 HAVING 
				COUNT(*) = 1) MARKET_NAMES ON IMP_DIGITAL_RESULTS_STAGING.MARKET_DESC = MARKET_NAMES.MARKET_DESC LEFT OUTER JOIN
			dbo.INTERNET_TYPE ON IMP_DIGITAL_RESULTS_STAGING.INTERNET_TYPE_CODE = INTERNET_TYPE.OD_CODE LEFT OUTER JOIN
			(SELECT
				[OD_CODE] = MIN(INTERNET_TYPE.OD_CODE),
				[OD_DESC] = INTERNET_TYPE.OD_DESC
			 FROM
				dbo.INTERNET_TYPE
			 GROUP BY
				OD_DESC
			 HAVING	
				COUNT(*) = 1) INTERNET_TYPE_NAMES ON IMP_DIGITAL_RESULTS_STAGING.OD_DESC = INTERNET_TYPE_NAMES.OD_DESC LEFT OUTER JOIN
			dbo.AD_SIZE ON IMP_DIGITAL_RESULTS_STAGING.AD_SIZE_CODE = AD_SIZE.SIZE_CODE AND
						   IMP_DIGITAL_RESULTS_STAGING.MEDIA_TYPE = AD_SIZE.MEDIA_TYPE LEFT OUTER JOIN
			(SELECT	
				[SIZE_CODE] = MIN(AD_SIZE.SIZE_CODE),
				[MEDIA_TYPE] = AD_SIZE.MEDIA_TYPE,
				[SIZE_DESC] = AD_SIZE.SIZE_DESC
			 FROM
				dbo.AD_SIZE
			 GROUP BY
				SIZE_DESC, MEDIA_TYPE
			 HAVING	
				COUNT(*) = 1) AD_SIZE_NAMES ON IMP_DIGITAL_RESULTS_STAGING.AD_SIZE_DESC = AD_SIZE_NAMES.SIZE_DESC AND
											   IMP_DIGITAL_RESULTS_STAGING.MEDIA_TYPE = AD_SIZE_NAMES.MEDIA_TYPE
		WHERE
			IMP_DIGITAL_RESULTS_STAGING.BATCH_NAME = @BATCH_NAME) IMP_TABLE ON IMP_DIGITAL_RESULTS_STAGING.IMPORT_ID = IMP_TABLE.ID
	WHERE
		IMP_DIGITAL_RESULTS_STAGING.BATCH_NAME = @BATCH_NAME
		
END
GO

