SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_media_spec]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_media_spec]
GO

CREATE PROCEDURE [dbo].[advsp_media_spec](@date_from smalldatetime, @date_to smalldatetime, @date_type smallint, @status varchar(20), @AcceptedOnly smallint, @UserID varchar(100))
AS

	DECLARE @OfficeRestrictions AS INTEGER, @Restrictions AS INTEGER	
	DECLARE @EMP_CODE AS varchar(6)

	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID)
	SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	Select @Restrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID);

SET NOCOUNT ON

-- ============================================================================
-- advsp_media_spec
-- #00 07/10/14 - v660 initial - v6.60.04.00 (2543-1)
--
-- Note: see next to last (2) lines to activate link to MEDIA_RPT_ORDERS to filter the result set
-- There must be a routine to populate MEDIA_RPT_ORDERS based on selection criteria if this is used (JP)
-- ============================================================================

-- Temporary table to hold comments--------------------------------------------
	CREATE TABLE #comments(
		ORDER_NBR					int NULL,
		LINE_NBR					smallint NULL,
		INSTRUCTIONS				text NULL,
		ORDER_COPY					text NULL,
		MATL_NOTES					text NULL,
		POSITION_INFO				text NULL,
		CLOSE_INFO					text NULL,
		MISC_INFO					text NULL )			
		
		INSERT INTO #comments SELECT ORDER_NBR, LINE_NBR, INSTRUCTIONS, ORDER_COPY, MATL_NOTES, POSITION_INFO, CLOSE_INFO, MISC_INFO FROM dbo.MAGAZINE_COMMENTS
		INSERT INTO #comments SELECT ORDER_NBR, LINE_NBR, INSTRUCTIONS, ORDER_COPY, MATL_NOTES, POSITION_INFO, CLOSE_INFO, MISC_INFO FROM dbo.NEWSPAPER_COMMENTS
		INSERT INTO #comments SELECT ORDER_NBR, LINE_NBR, INSTRUCTIONS, ORDER_COPY, MATL_NOTES, NULL, NULL, MISC_INFO FROM dbo.OUTDOOR_COMMENTS
		INSERT INTO #comments SELECT ORDER_NBR, LINE_NBR, INSTRUCTIONS, ORDER_COPY, MATL_NOTES, NULL, NULL, MISC_INFO FROM dbo.INTERNET_COMMENTS
		INSERT INTO #comments SELECT ORDER_NBR, LINE_NBR, INSTRUCTIONS, ORDER_COPY, MATL_NOTES, NULL, CLOSE_INFO, MISC_INFO FROM dbo.RADIO_COMMENTS
		INSERT INTO #comments SELECT ORDER_NBR, LINE_NBR, INSTRUCTIONS, ORDER_COPY, MATL_NOTES, NULL, CLOSE_INFO, MISC_INFO FROM dbo.TV_COMMENTS
	--SELECT * FROM #comments	

	CREATE TABLE #mediaspecs(
		OrderType			varchar(1) NULL,                                                                                                                                                                                                                                                           
		OrderNumber			int NULL,                                                                                                                                                                                                                                                      
		OrderDescription	varchar(60) NULL,                                                                                                                                                                                                                                                    
		OfficeCode			varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,   
		OfficeName			varchar(30) NULL,                                                                                                                                                                                                                                                       
		ClientCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,   
		ClientName			varchar(40) NULL,                                                                                                                                                                                                                                                           
		DivisionCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,   
		DivisionName		varchar(40) NULL,                                                                                                                                                                                                                                                          
		ProductCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,   
		ProductDescription	varchar(40) NULL,                                                                                                                                                                                                                                                          
		MarketCode			varchar(40) NULL,   
		MarketDescription	varchar(40) NULL,                                                                                                                                                                                                                                                       
		CampaignCode		varchar(6) NULL,                                                                                                                                                                                                                                                
		CampaignID			int NULL, 
		CampaignName		varchar(128) NULL,                                                                                                                                                                                                                                                                       
		VendorCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		VendorName			varchar(40) NULL,                                                                                                                                                                                                                                                       
		VendorRepCode		varchar(6) NULL,
		VendorLabel			varchar(20) NULL,
		VendorRepName		varchar(65) NULL,  
		VendorRepEmail		varchar(50) NULL,  
		VendorRepPhone		varchar(13) NULL,                                                                                                                                                                                                                                                       
		VendorRepCode2		varchar(6) NULL, 
		VendorLabel2		varchar(20) NULL,
		VendorRepName2		varchar(65) NULL,
		VendorRepEmail2		varchar(50) NULL,  
		VendorRepPhone2		varchar(13) NULL,                                                                                                                                                                                                                                                       
		ClientPO			varchar(40) NULL,                                                                                                                                                                                                                                                      
		OrderDate			smalldatetime NULL,                                                                                                                                                                                                                                                     
		MediaType			varchar(6) NULL,
		MediaTypeDescription  varchar(30) NULL,
		FlightFrom			smalldatetime NULL, 
		FlightTo			smalldatetime NULL, 				                                                                                                                                                                                                                                                                               
		Buyer               varchar(40),                                                                                                                                                                                                                                            
		OrderAccepted		smallint NULL,                                                                                                                                                                                                                                                 
		OrderCommentLimited varchar(MAX) NULL,                                                                                                                                                                                                                                                 
		LineNumber			smallint NULL,                                                                                                                                                                                                                                                       
		LineRevisionNumber	smallint NULL,                                                                                                                                                                                                                                                        
		Period              int NULL,                                                                                                                                                                                                                                            
		[Month]             int NULL,                                                                                                                                                                                                                                                          
		[Year]				int NULL,                                                                                                                                                                                                                                                           
		StartDate			smalldatetime NULL,                                                                                                                                                                                                                                                      
		EndDate				smalldatetime NULL,                                                                                                                                                                                                                                                        
		CloseDate			smalldatetime NULL,                                                                                                                                                                                                                                                     
		MaterialCloseDate   smalldatetime NULL,                                                                                                                                                                                                                                              
		ExtendedCloseDate   smalldatetime NULL,                                                                                                                                                                                                                                               
		ExtendedMaterialCloseDate   smalldatetime NULL,                                                                                                                                                                                                                                                
		HeadlineOrProgram   varchar(60) NULL,                                                                                                                                                                                                                                             
		SizeCode            varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,                                                                                                                                                                                                                                          
		Size                varchar(60) NULL,                                                                                                                                                                                                                                            
		EditionOrIssue		varchar(30) NULL,                                                                                                                                                                                                                                                  
		Section				varchar(60) NULL,                                                                                                                                                                                                                                                        
		Material			varchar(60) NULL,                                                                                                                                                                                                                                                       
		BroadcastRemarks	varchar(254) NULL,                                                                                                                                                                                                                                                        
		CompletedDate		smalldatetime NULL,                                                                                                                                                                                                                                                        
		URL					varchar(60) NULL,                                                                                                                                                                                                                                                            
		CopyArea			varchar(40) NULL,                                                                                                                                                                                                                                                      
		AdNumber			varchar(30) NULL, 
		AdNumberDescription varchar(60) NULL,                                                                                                                                                                                                                                                     
		JobNumber           int NULL,       
		JobDescription		varchar(60) NULL,                                                                                                                                                                                                                                                   
		JobComponentNumber	smallint NULL,                                                                                                                                                                                                                                              
		JobComponentDescription		varchar(60) NULL,                                                                                                                                                                                                                                                  
		NewspaperPrintQuantity decimal(14, 3) NULL,                                                                                                                                                                                                                                                 
		InternetGuaranteedImpressions int NULL,                                                                                                                                                                                                                                                     
		BroadcastSpots		int NULL,                                                                                                                                                                                                                                                            
		BroadcastCommercialLength	smallint NULL,                                                                                                                                                                                                                                                            
		LineCancelled		smallint NULL,                                                                                                                                                                                                                                                    
		NewspaperCirculation		int NULL, 
		Instructions		text NULL, 
		OrderCopy			text NULL, 
		MaterialNotes		text NULL, 
		PositionInfo		text NULL, 
		CloseInfo			text NULL, 
		MiscInfo			text NULL,
		InternetTypeCode    varchar(6) NULL,
		InternetTypeDescription  varchar(30) NULL,	
		OutdoorTypeCode    varchar(6) NULL,
		OutdoorTypeDescription  varchar(30) NULL,	
		VendorSundayCirculation		int NULL,   
		VendorDailyCirculation		int NULL,   
		VendorShippingName	varchar(40) NULL,
		VendorShippingAddress1	varchar(40) NULL,
		VendorShippingAddress2	varchar(40) NULL,
		VendorShippingAddress3	varchar(40) NULL,
		VendorShippingCity	varchar(25) NULL,
		VendorShippingCounty	varchar(20) NULL,
		VendorShippingState	varchar(10) NULL,
		VendorShippingZip	varchar(10) NULL,
		VendorShippingCountry	varchar(20) NULL,
		VendorShippingPhone	varchar(13) NULL,
		VendorShippingPhoneExt	varchar(4) NULL,
		VendorAcceptedMedia	varchar(250) NULL,
		VendorEFILEInfo		varchar(250) NULL,
		VendorPreferenceMaterial	varchar(250) NULL,
		VendorFTPUser		varchar(100) NULL,
		VendorFTPPassword	varchar(100) NULL,
		VendorFTPDirectory	varchar(100) NULL,
		[Location]			varchar(60) NULL,
		Placement1			varchar(256) NULL,
		Placement2			varchar(160),
		VendorRepCellPhone		varchar(13) NULL,   
		VendorRepCellPhone2		varchar(13) NULL
	)

	DECLARE @sql nvarchar(4000),@paramlist nvarchar(4000)
-- ===============================================================================
-- MAIN EXTRACTION QUERY		
-- ===============================================================================
				
	If @date_type = 1
	Begin
		If @status = 'Open'
		Begin
			If @AcceptedOnly = 1
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR		
				AND d.MATL_CLOSE_DATE BETWEEN @date_from and @date_to AND h.ORD_PROCESS_CONTRL <> 6 AND h.ORDER_ACCEPTED = 1
			End
			Else 
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR		
				AND d.MATL_CLOSE_DATE BETWEEN @date_from and @date_to AND h.ORD_PROCESS_CONTRL <> 6 
			End
		End
		Else
		Begin
			If @AcceptedOnly = 1
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR		
				AND d.MATL_CLOSE_DATE BETWEEN @date_from and @date_to AND h.ORDER_ACCEPTED = 1
			End
			Else 
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR		
				AND d.MATL_CLOSE_DATE BETWEEN @date_from and @date_to
			End
		End
		 
	End
	If @date_type = 2
	Begin
		If @status = 'Open'
		Begin
			If @AcceptedOnly = 1
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR	
				AND d.[START_DATE] BETWEEN @date_from and @date_to AND h.ORD_PROCESS_CONTRL <> 6 AND h.ORDER_ACCEPTED = 1
			End
			Else 
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR	
				AND d.[START_DATE] BETWEEN @date_from and @date_to AND h.ORD_PROCESS_CONTRL <> 6
			End

		End
		Else
		Begin
			If @AcceptedOnly = 1
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR	
				AND d.[START_DATE] BETWEEN @date_from and @date_to AND h.ORDER_ACCEPTED = 1
			End
			Else 
			Begin
				INSERT INTO #mediaspecs 
				 SELECT	h.ORDER_TYPE AS OrderType,h.ORDER_NBR AS OrderNumber,h.ORDER_DESC AS OrderDescription,h.OFFICE_CODE AS OfficeCode,o.OFFICE_NAME AS OfficeName,h.CL_CODE AS ClientCode,
					c.CL_NAME AS ClientName,h.DIV_CODE AS DivisionCode,dv.DIV_NAME AS DivisionName,h.PRD_CODE AS ProductCode,p.PRD_DESCRIPTION AS ProductDescription, h.MARKET_CODE AS MarketCode,m.MARKET_DESC AS MarketDescription,                                                                                                                                                                                                                                                    
					h.CMP_CODE AS CampaignCode, h.CMP_ID AS CampaignID,cmp.CMP_NAME AS CampaignName,h.VN_CODE AS VendorCode,v.VN_NAME AS VendorName,h.VR_CODE AS VendorRepCode,vr.VR_LABEL AS VendorRepLabel,
					vr.VR_FNAME + ' ' + vr.VR_LNAME AS VendorRepName,  vr.EMAIL_ADDRESS AS VendorRepEmail,vr.VR_TELEPHONE AS VendorRepPhone,h.VR_CODE2 AS VendorRepCode2,vr2.VR_LABEL AS VendorRepLabel2,vr2.VR_FNAME + ' ' + vr2.VR_LNAME AS VendorRepName2, vr2.EMAIL_ADDRESS AS VendorRepEmail2,     
					vr2.VR_TELEPHONE AS VendorRepPhone2, h.CLIENT_PO AS ClientPO,h.ORDER_DATE AS OrderDate,h.MEDIA_TYPE AS MediaType,sc.SC_DESCRIPTION AS MediaTypeDescription,
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[START_DATE]
						WHEN 'T' THEN h.[START_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightFrom, 
					CASE h.ORDER_TYPE
						WHEN 'R' THEN h.[END_DATE]
						WHEN 'T' THEN h.[END_DATE]
						ELSE NULL                                                                                                                                                                                                                 
					END AS FlightTo,h.BUYER AS Buyer,h.ORDER_ACCEPTED AS OrderAccepted,h.ORDER_COMMENT_LTD AS OrderCommentLimited,                                                                                                                                                        
					d.LINE_NBR AS LineNumber,d.REV_NBR AS LineRevisionNumber,d.PERIOD AS Period,d.[MONTH] AS [Month],d.[YEAR] AS [Year],d.[START_DATE] AS StartDate,d.END_DATE AS EndDate,                                                                                                                                                                                                                                                       
					d.CLOSE_DATE AS CloseDate,d.MATL_CLOSE_DATE AS MaterialCloseDate, d.EXT_CLOSE_DATE AS ExtendedCloseDate,d.EXT_MATL_DATE AS ExtendedMaterialCloseDate,d.HEADLINE_PROGRAM AS HeadlineOrProgram,                                                                                                                                                                                                                                               
					d.SIZE_CODE AS SizeCode,d.SIZE AS Size,d.EDITION_ISSUE AS EditionOrIssue,d.SECTION AS Section,d.MATERIAL AS Material,d.REMARKS AS BroadcastRemarks,d.MAT_COMP AS CompletedDate,                                                                                                                                                                                                                                                       
					d.URL AS URL,d.COPY_AREA AS CopyArea,d.AD_NUMBER AS AdNumber,an.AD_NBR_DESC AS AdNumberDescription,d.JOB_NUMBER AS JobNumber,j.JOB_DESC,d.JOB_COMPONENT_NBR AS JobComponentNumber,d.JOB_COMPONENT AS JobComponent,                                                                                                                                                                                                                                                  
					d.PRINT_QUANTITY AS NewspaperPrintQuantity,d.GUARANTEED_IMPRESS AS InternetGuaranteedImpressions,d.TOTAL_SPOTS AS BroadcastSpots,d.[LENGTH] AS BroadcastCommercialLength,                                                                                                                                                                                                                                                         
					d.LINE_CANCELLED AS LineCancelled,d.CIRCULATION AS NewspaperCirculation,cmt.INSTRUCTIONS AS Instructions,
					cmt.ORDER_COPY AS OrderCopy,cmt.MATL_NOTES AS MaterialNotes,cmt.POSITION_INFO AS PositionInfo,cmt.CLOSE_INFO AS CloseInfo,cmt.MISC_INFO AS MiscInfo,
					d.INTERNET_TYPE, d.INTERNET_TYPE_DESC, d.OUTDOOR_TYPE, d.OUTDOOR_TYPE_DESC,
					v.SUNDAY_CIRC AS VendorSundayCirculation,v.DAILY_CIRC AS VendorDailyCirculation,
					v.SHIP_NAME AS VendorShippingName,v.SHIP_ADDR1 AS VendorShippingAddress1,v.SHIP_ADDR2 AS VendorShippingAddress2,v.SHIP_ADDR3 AS VendorShippingAddress3,
					v.SHIP_CITY AS VendorShippingCity,v.SHIP_COUNTY AS VendorShippingCounty,v.SHIP_STATE AS VendorShippingState,
					v.SHIP_ZIP AS VendorShippingZip,v.SHIP_COUNTRY AS VendorShippingCountry,v.SHIP_PHONE AS VendorShippingPhone,
					v.SHIP_PHONE_EXT AS VendorShippingPhoneExt,vc.ACCEPTED_MEDIA AS VendorAcceptedMedia,
					vc.EFILE_INFO AS VendorEFILEInfo,vc.PREF_MATL AS VendorPreferenceMaterial,vc.FTP_USER AS VendorFTPUser,vc.FTP_PW AS VendorFTPPassword,vc.FTP_DIR AS VendorFTPDirectory, d.OUTDOOR_LOCATION AS [Location],
					d.PLACEMENT_1 as Placement1, d.PLACEMENT_2 as Placement2, vr.VR_PHONE_CELL as VendorRepCellPhone, vr2.VR_PHONE_CELL as VendorRepCellPhone2	 
				FROM dbo.V_MEDIA_HDR AS h
				JOIN dbo.V_MEDIA_DTL AS d ON h.ORDER_NBR = d.ORDER_NBR
				JOIN dbo.OFFICE AS o ON h.OFFICE_CODE = o.OFFICE_CODE	
				JOIN dbo.CLIENT AS c ON h.CL_CODE = c.CL_CODE
				JOIN dbo.DIVISION AS dv	ON h.CL_CODE = dv.CL_CODE AND h.DIV_CODE = dv.DIV_CODE
				JOIN dbo.PRODUCT AS p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
				JOIN dbo.SALES_CLASS AS sc ON h.MEDIA_TYPE = sc.SC_CODE	
				JOIN dbo.VENDOR AS v ON h.VN_CODE = v.VN_CODE
				LEFT JOIN dbo.VEN_REP AS vr ON h.VN_CODE = vr.VN_CODE AND h.VR_CODE = vr.VR_CODE	
				LEFT JOIN dbo.VEN_REP AS vr2 ON h.VN_CODE = vr2.VN_CODE AND h.VR_CODE2 = vr2.VR_CODE
				LEFT JOIN dbo.JOB_LOG AS j ON d.JOB_NUMBER = j.JOB_NUMBER
				LEFT JOIN dbo.JOB_COMPONENT AS jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR		
				LEFT JOIN dbo.MARKET AS m ON h.MARKET_CODE = m.MARKET_CODE
				LEFT JOIN dbo.CAMPAIGN AS cmp ON h.CMP_ID = cmp.CMP_IDENTIFIER 
				LEFT JOIN dbo.AD_NUMBER AS an ON d.AD_NUMBER = an.AD_NBR
				LEFT JOIN dbo.VENDOR_COMMENTS AS vc	ON h.VN_CODE = vc.VN_CODE	
				LEFT JOIN #comments AS cmt ON d.ORDER_NBR = cmt.ORDER_NBR AND d.LINE_NBR = cmt.LINE_NBR
				--JOIN dbo.MEDIA_RPT_ORDERS AS mro
				--	ON h.ORDER_NBR = mro.ORDER_NBR	
				WHERE h.VER_ID = 2			--Note: this filters out old print and broadcast from V_MEDIA_HDR	
				AND d.[START_DATE] BETWEEN @date_from and @date_to
			End

		End
		
	End

	
	--Add media specs user defined columns.	 	
	DECLARE @label_text varchar(30), @size_code varchar(6), @media_type varchar(1), @pos int, @pos2 int, @alter_sql varchar(MAX), @update_sql varchar(MAX), @select_sql varchar(MAX)
	DECLARE ms_col_cursor CURSOR FOR 
		 SELECT AD_SIZE.MEDIA_TYPE, REPLACE(REPLACE(AD_SIZE.SIZE_CODE,'''',''),'"',''), AD_SIZE_LABEL.LABEL_DESC
			FROM AD_SIZE INNER JOIN AD_SIZE_LABEL ON AD_SIZE.MEDIA_TYPE = AD_SIZE_LABEL.MEDIA_TYPE
			WHERE (AD_SIZE_LABEL.INACTIVE_FLAG IS NULL OR AD_SIZE_LABEL.INACTIVE_FLAG = 0) --AND AD_SIZE.SIZE_CODE IN (SELECT DISTINCT SIZE_CODE FROM #mediaspecs WHERE SIZE_CODE IS NOT NULL)
			ORDER BY AD_SIZE.MEDIA_TYPE, AD_SIZE.SIZE_CODE,AD_SIZE_LABEL.LABEL_SEQ		 

	SELECT @pos = ORDINAL_POSITION FROM tempdb.information_schema.columns where table_name like '#mediaspecs%' and column_name like 'Placement2'
	 SET @select_sql = ''
	OPEN ms_col_cursor
	--SELECT @pos
	FETCH NEXT FROM ms_col_cursor INTO @media_type, @size_code, @label_text

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN		
		--SELECT @media_type, @size_code, @label_text
		SET @update_sql = ''
		SET @alter_sql = ''
		SELECT @pos2 = ISNULL(ORDINAL_POSITION,0) FROM tempdb.information_schema.columns where table_name like '#mediaspecs%' and column_name like @label_text		
		If exists (Select * from tempdb.information_schema.columns where table_name like '#mediaspecs%' and column_name like @label_text) AND (@pos >= @pos2)
		Begin
			SELECT @alter_sql = 'ALTER TABLE #mediaspecs ADD [' + @label_text + '_' + @size_code + ']  varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS'					
			SELECT @select_sql = @select_sql + '[' + @label_text + '_' + @size_code + '],'								
		End
		Else If not exists (Select * from tempdb.information_schema.columns where table_name like '#mediaspecs%' and column_name like @label_text)
		Begin
			SELECT @alter_sql = 'ALTER TABLE #mediaspecs ADD [' + @label_text + '] varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS'		
			SELECT @select_sql = @select_sql + '[' + @label_text + '],'	
		End

		If exists (Select * from tempdb.information_schema.columns where table_name like '#mediaspecs%' and column_name like @label_text) AND (@pos >= @pos2)
		Begin			
			SELECT @update_sql = 'UPDATE #mediaspecs SET [' + @label_text + '_' + @size_code + '] = '	
		End
		Else 
		Begin
			SELECT @update_sql = 'UPDATE #mediaspecs SET [' + @label_text + '] = '
		End
		
		SELECT @select_sql = @select_sql + ''
		SELECT @alter_sql = @alter_sql + ' NULL'
		
		SELECT @update_sql = @update_sql + '		( SELECT dbo.MEDIA_SPECS_DTL.SPEC_DATA  '
		SELECT @update_sql = @update_sql + '	  FROM dbo.MEDIA_SPECS_HDR INNER JOIN dbo.MEDIA_SPECS_DTL ON dbo.MEDIA_SPECS_HDR.SPEC_ID = dbo.MEDIA_SPECS_DTL.SPEC_ID INNER JOIN
												  dbo.AD_SIZE_LABEL ON dbo.MEDIA_SPECS_DTL.MEDIA_TYPE = dbo.AD_SIZE_LABEL.MEDIA_TYPE AND 
												  dbo.MEDIA_SPECS_DTL.LABEL_ID = dbo.AD_SIZE_LABEL.LABEL_ID '		
		SELECT @update_sql = @update_sql + '	 WHERE MEDIA_SPECS_HDR.VN_CODE = #mediaspecs.VendorCode'
		SELECT @update_sql = @update_sql + '	   AND MEDIA_SPECS_HDR.AD_SIZE = #mediaspecs.SizeCode'
		SELECT @update_sql = @update_sql + '	   AND AD_SIZE_LABEL.LABEL_DESC = ''' + @label_text + ''' AND (AD_SIZE_LABEL.INACTIVE_FLAG IS NULL OR AD_SIZE_LABEL.INACTIVE_FLAG = 0))'
		SELECT @update_sql = @update_sql + '      WHERE REPLACE(REPLACE(SizeCode,'''',''''),''"'','''') = ''' + @size_code + ''''
		--SELECT @update_sql = @update_sql + '   AND [Component Number] = ' + CONVERT( varchar(3), @job_component_nbr )
		--SELECT @update_sql = @update_sql + '   AND [Number] = ' + CONVERT( varchar(3), @job_ver_seq_nbr )
								
		BEGIN TRY
			EXECUTE ( @alter_sql )
		END TRY
		
		BEGIN CATCH
			GOTO FNEXT
		END CATCH
		
		FNEXT:
		PRINT(@update_sql)
		EXECUTE ( @update_sql )
		
		--SET @pos += 1
		FETCH NEXT FROM ms_col_cursor INTO @media_type, @size_code, @label_text
	END

	CLOSE ms_col_cursor
	DEALLOCATE ms_col_cursor	
	
	IF @select_sql <> ''
	BEGIN
		SET @select_sql = LEFT(@select_sql, LEN(@select_sql) - 1)
	END

	DECLARE @sql2 varchar(MAX)
	SELECT @sql2 = ''

	If @OfficeRestrictions > 0
	Begin				
		If @Restrictions > 0
		Begin
			SELECT @sql2 = @sql2 + ' SELECT OrderType,OrderNumber,OrderDescription,OfficeCode,OfficeName,ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,
					MarketCode,MarketDescription,CampaignCode,CampaignID,CampaignName,VendorCode,VendorName,VendorRepCode,VendorLabel,VendorRepName,VendorRepEmail,
					VendorRepPhone,VendorRepCode2,VendorLabel2,VendorRepName2,VendorRepEmail2,VendorRepPhone2,ClientPO,OrderDate,MediaType,MediaTypeDescription,FlightFrom,FlightTo,
					Buyer,OrderAccepted,OrderCommentLimited, LineNumber,LineRevisionNumber,[Period],[Month], [Year],StartDate,EndDate,CloseDate,MaterialCloseDate,ExtendedCloseDate,ExtendedMaterialCloseDate, HeadlineOrProgram,SizeCode,Size,
					EditionOrIssue,Section,Material,BroadcastRemarks,CompletedDate,[URL],CopyArea,AdNumber,AdNumberDescription,JobNumber,JobDescription,JobComponentNumber,JobComponentDescription,NewspaperPrintQuantity,InternetGuaranteedImpressions,
					BroadcastSpots,BroadcastCommercialLength,LineCancelled,NewspaperCirculation,Instructions,OrderCopy,MaterialNotes,PositionInfo,CloseInfo,MiscInfo,InternetTypeCode,InternetTypeDescription,OutdoorTypeCode,OutdoorTypeDescription,
					VendorSundayCirculation,VendorDailyCirculation,VendorShippingName,VendorShippingAddress1,VendorShippingAddress2,VendorShippingAddress3,VendorShippingCity,VendorShippingCounty,VendorShippingState,VendorShippingZip,VendorShippingCountry,
					VendorShippingPhone,VendorShippingPhoneExt,VendorAcceptedMedia,VendorEFILEInfo,VendorPreferenceMaterial,VendorFTPUser,VendorFTPPassword,VendorFTPDirectory,[Location],Placement1,Placement2, VendorRepCellPhone, VendorRepCellPhone2
					'
					SELECT @sql2 = @sql2 + @select_sql 
					SELECT @sql2 = @sql2 + ' FROM #mediaspecs m
							INNER JOIN EMP_OFFICE E ON m.OfficeCode = E.OFFICE_CODE AND E.EMP_CODE = ''' + @EMP_CODE + '''
							INNER JOIN SEC_CLIENT S ON m.ClientCode = S.CL_CODE AND m.DivisionCode = S.DIV_CODE AND m.ProductCode = S.PRD_CODE
														AND UPPER(S.USER_ID) = UPPER(''' + @UserID + ''')'

			EXEC(@sql2)	

			--SELECT * FROM #mediaspecs m
			--	INNER JOIN EMP_OFFICE E ON m.OfficeCode = E.OFFICE_CODE AND E.EMP_CODE = @EMP_CODE
			--	INNER JOIN SEC_CLIENT S ON m.ClientCode = S.CL_CODE AND m.DivisionCode = S.DIV_CODE AND m.ProductCode = S.PRD_CODE
			--								AND UPPER(S.USER_ID) = UPPER(@UserID)
		End	
		Else
		Begin
			SELECT @sql2 = @sql2 + ' SELECT OrderType,OrderNumber,OrderDescription,OfficeCode,OfficeName,ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,
					MarketCode,MarketDescription,CampaignCode,CampaignID,CampaignName,VendorCode,VendorName,VendorRepCode,VendorLabel,VendorRepName,VendorRepEmail,
					VendorRepPhone,VendorRepCode2,VendorLabel2,VendorRepName2,VendorRepEmail2,VendorRepPhone2,ClientPO,OrderDate,MediaType,MediaTypeDescription,FlightFrom,FlightTo,
					Buyer,OrderAccepted,OrderCommentLimited, LineNumber,LineRevisionNumber,[Period],[Month], [Year],StartDate,EndDate,CloseDate,MaterialCloseDate,ExtendedCloseDate,ExtendedMaterialCloseDate, HeadlineOrProgram,SizeCode,Size,
					EditionOrIssue,Section,Material,BroadcastRemarks,CompletedDate,[URL],CopyArea,AdNumber,AdNumberDescription,JobNumber,JobDescription,JobComponentNumber,JobComponentDescription,NewspaperPrintQuantity,InternetGuaranteedImpressions,
					BroadcastSpots,BroadcastCommercialLength,LineCancelled,NewspaperCirculation,Instructions,OrderCopy,MaterialNotes,PositionInfo,CloseInfo,MiscInfo,InternetTypeCode,InternetTypeDescription,OutdoorTypeCode,OutdoorTypeDescription,
					VendorSundayCirculation,VendorDailyCirculation,VendorShippingName,VendorShippingAddress1,VendorShippingAddress2,VendorShippingAddress3,VendorShippingCity,VendorShippingCounty,VendorShippingState,VendorShippingZip,VendorShippingCountry,
					VendorShippingPhone,VendorShippingPhoneExt,VendorAcceptedMedia,VendorEFILEInfo,VendorPreferenceMaterial,VendorFTPUser,VendorFTPPassword,VendorFTPDirectory,[Location],Placement1,Placement2, VendorRepCellPhone, VendorRepCellPhone2
					'
					SELECT @sql2 = @sql2 + @select_sql 
					SELECT @sql2 = @sql2 + ' FROM #mediaspecs m
				INNER JOIN EMP_OFFICE ON m.OfficeCode = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

			EXEC(@sql2)	

			--SELECT * FROM #mediaspecs m
			--	INNER JOIN EMP_OFFICE ON m.OfficeCode = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE		
		End
	End
	Else	
	Begin			
		If @Restrictions > 0
		Begin
			SELECT @sql2 = @sql2 + ' SELECT OrderType,OrderNumber,OrderDescription,OfficeCode,OfficeName,ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,
					MarketCode,MarketDescription,CampaignCode,CampaignID,CampaignName,VendorCode,VendorName,VendorRepCode,VendorLabel,VendorRepName,VendorRepEmail,
					VendorRepPhone,VendorRepCode2,VendorLabel2,VendorRepName2,VendorRepEmail2,VendorRepPhone2,ClientPO,OrderDate,MediaType,MediaTypeDescription,FlightFrom,FlightTo,
					Buyer,OrderAccepted,OrderCommentLimited, LineNumber,LineRevisionNumber,[Period],[Month], [Year],StartDate,EndDate,CloseDate,MaterialCloseDate,ExtendedCloseDate,ExtendedMaterialCloseDate, HeadlineOrProgram,SizeCode,Size,
					EditionOrIssue,Section,Material,BroadcastRemarks,CompletedDate,[URL],CopyArea,AdNumber,AdNumberDescription,JobNumber,JobDescription,JobComponentNumber,JobComponentDescription,NewspaperPrintQuantity,InternetGuaranteedImpressions,
					BroadcastSpots,BroadcastCommercialLength,LineCancelled,NewspaperCirculation,Instructions,OrderCopy,MaterialNotes,PositionInfo,CloseInfo,MiscInfo,InternetTypeCode,InternetTypeDescription,OutdoorTypeCode,OutdoorTypeDescription,
					VendorSundayCirculation,VendorDailyCirculation,VendorShippingName,VendorShippingAddress1,VendorShippingAddress2,VendorShippingAddress3,VendorShippingCity,VendorShippingCounty,VendorShippingState,VendorShippingZip,VendorShippingCountry,
					VendorShippingPhone,VendorShippingPhoneExt,VendorAcceptedMedia,VendorEFILEInfo,VendorPreferenceMaterial,VendorFTPUser,VendorFTPPassword,VendorFTPDirectory,[Location],Placement1,Placement2, VendorRepCellPhone, VendorRepCellPhone2
					'
					SELECT @sql2 = @sql2 + @select_sql 
					SELECT @sql2 = @sql2 + ' FROM #mediaspecs m
							INNER JOIN SEC_CLIENT S ON m.ClientCode = S.CL_CODE AND m.DivisionCode = S.DIV_CODE AND m.ProductCode = S.PRD_CODE
														AND UPPER(S.USER_ID) = UPPER(''' + @UserID + ''')'

			EXEC(@sql2)	

			--SELECT * FROM #mediaspecs m
			--	INNER JOIN SEC_CLIENT S ON m.ClientCode = S.CL_CODE AND m.DivisionCode = S.DIV_CODE AND m.ProductCode = S.PRD_CODE	
			--								AND UPPER(S.USER_ID) = UPPER(@UserID)
		End	
		Else
		Begin
			SELECT * FROM #mediaspecs		
		End		
	End

GO

GRANT EXECUTE ON [dbo].[advsp_media_spec] TO PUBLIC AS dbo
GO


