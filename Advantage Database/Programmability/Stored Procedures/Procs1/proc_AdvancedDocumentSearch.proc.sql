CREATE PROCEDURE [dbo].[proc_AdvancedDocumentSearch] /*WITH ENCRYPTION*/
@SearchCriteria  VARCHAR(100) = '',
@EmpCode         VARCHAR(100) = '',
@AccessPrivate	 BIT
AS
/*=========== QUERY ===========*/
BEGIN

	SET NOCOUNT ON;
	SET ANSI_WARNINGS OFF;
	
	DECLARE @IsBlockedFromOfficeLevel AS bit
	DECLARE @IsBlockedFromClientLevel AS bit
	DECLARE @IsBlockedFromDivisionLevel AS bit
	DECLARE @IsBlockedFromProductLevel AS bit
	DECLARE @IsBlockedFromCampaignLevel AS bit
	DECLARE @IsBlockedFromJobLevel AS bit
	DECLARE @IsBlockedFromJobComponentLevel AS bit
	DECLARE @IsBlockedFromAPLevel AS bit
	DECLARE @IsBlockedFromAgencyDesktopLevel AS bit
	DECLARE @IsBlockedFromExecutiveDesktopLevel AS bit
	DECLARE @IsBlockedFromAdNumberLevel AS bit
	DECLARE @IsBlockedFromExpenseReportLevel AS bit
	
	SELECT @IsBlockedFromOfficeLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_Office'
	SELECT @IsBlockedFromClientLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_Client'
	SELECT @IsBlockedFromDivisionLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_Division'
	SELECT @IsBlockedFromProductLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_Product'
	SELECT @IsBlockedFromCampaignLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_Campaign'
	SELECT @IsBlockedFromJobLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_Job'
	SELECT @IsBlockedFromJobComponentLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_JobComponent'
	SELECT @IsBlockedFromAPLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_APInvoice'
	SELECT @IsBlockedFromAgencyDesktopLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_AgencyDesktop'
	SELECT @IsBlockedFromExecutiveDesktopLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_ExecutiveDesktop'
	SELECT @IsBlockedFromAdNumberLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_AdNumber'
	SELECT @IsBlockedFromExpenseReportLevel = [IsBlocked] FROM dbo.V_SEC_PERMISSION WHERE UserCode = @EmpCode AND ModuleCode = 'Desktop_DocumentManagerLevels_ExpenseReceipts'

	DECLARE @SEARCH_RESULTS TABLE(
									[DOCUMENT_ID]			INT,
									[FILENAME]				VARCHAR(50),
									[DESCRIPTION]			VARCHAR(200),
									[KEYWORDS]				VARCHAR(255),
									[FILE_SIZE]				INT,
									[UPLOADED_DATE]			DATETIME,
									[MIME_TYPE]				VARCHAR(50),
									[USER_CODE]				VARCHAR(100),
									[CMP_CODE]				VARCHAR(6),
									[OFFICE_CODE]			VARCHAR(6),
									[CL_CODE]				VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
									[DIV_CODE]				VARCHAR(6)COLLATE SQL_Latin1_General_CP1_CS_AS,
									[PRD_CODE]				VARCHAR(6)COLLATE SQL_Latin1_General_CP1_CS_AS,
									[JOB_NUMBER]			INT,
									[JOB_COMPONENT_NBR]		INT,
									[LEVEL]					VARCHAR(2),
									[OFFICE_NAME]			VARCHAR(30) NULL,
									[CAMPAIGN_NAME]			VARCHAR(128) NULL,
									[CLIENT_NAME]			VARCHAR(40) NULL,
									[DIVISION_NAME]			VARCHAR(40) NULL,
									[PRODUCT_DESCRIPTION]	VARCHAR(40) NULL,
									[JOB_DESCRIPTION]		VARCHAR(60) NULL,
									[JOB_COMP_DESCRIPTION]	VARCHAR(60) NULL,
									[REPOSITORY_FILENAME]	VARCHAR(200),
									[VENDOR_CODE]			VARCHAR(6),
									[AP_INVOICE]			VARCHAR(20),
									[VENDOR_NAME]			VARCHAR(30),
									[AP_INVOICE_DESC]		VARCHAR(50),
									[AP_ID]					INT,
									[AD_NBR]				VARCHAR(30),
									[AD_NBR_DESC]			VARCHAR(60)
								)
	
	DECLARE @IsLimitedByOffice BIT
	DECLARE @Offices TABLE (OfficeCode VARCHAR(4))
	DECLARE @CDPs TABLE (ClientCode VARCHAR(6),
						 DivisionCode VARCHAR(6),
						 ProductCode VARCHAR(6),
						 TimeEntryOnly SMALLINT)
	DECLARE @Employees TABLE (EmployeeCode VARCHAR(6))

	DECLARE @RealEmpCode VARCHAR(6)
	
	SELECT @RealEmpCode = EMP_CODE FROM dbo.SEC_USER WHERE UPPER(USER_CODE) = UPPER(@EmpCode)
	
	SET @IsLimitedByOffice = 0

	IF EXISTS (SELECT * FROM dbo.EMP_OFFICE WHERE EMP_CODE = @RealEmpCode)
		SET @IsLimitedByOffice = 1

	INSERT INTO @Offices
		exec dbo.advsp_employee_office_limits_load @RealEmpCode		
	
	INSERT INTO @CDPs
		SELECT
			CL_CODE,
			DIV_CODE,
			PRD_CODE,
			ISNULL(TIME_ENTRY, 0)
		FROM
			dbo.advtf_user_product_limits (@EmpCode)

	INSERT INTO @Employees
		SELECT
			EMP_CODE
		FROM
			dbo.advtf_user_employee_limits (@EmpCode)

	IF @SearchCriteria <> ''
	BEGIN

		IF @IsBlockedFromOfficeLevel = 0 
		BEGIN
			-- Search the Office Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = [DOCUMENT_ID],
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = [KEYWORDS],
					[FILE_SIZE] = [FILE_SIZE],
					[UPLOADED_DATE] = [UPLOADED_DATE],
					[MIME_TYPE] = [MIME_TYPE],
					[USER_CODE] = [USER_CODE],
					[CMP_CODE] = '',
					[OFFICE_CODE] = OFFICE.OFFICE_CODE,
					[CL_CODE] = '',
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'OF',
					[OFFICE_NAME] = OFFICE.OFFICE_NAME,
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = '',
					[DIVISION_NAME] = '',
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = ''
				FROM
					dbo.WV_CURRENT_OFFICE_DOCUMENTS
				INNER JOIN 
					dbo.OFFICE ON OFFICE.OFFICE_CODE = WV_CURRENT_OFFICE_DOCUMENTS.OFFICE_CODE 
				INNER JOIN 
					@Offices O ON OFFICE.OFFICE_CODE = O.OfficeCode
				WHERE 
					LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(OFFICE.OFFICE_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(OFFICE.OFFICE_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
				ORDER BY
						OFFICE.OFFICE_CODE 
		               
	    END
		
		IF @IsBlockedFromClientLevel = 0 
		BEGIN
				-- Search the Client Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = [DOCUMENT_ID],
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = [KEYWORDS],
					[FILE_SIZE] = [FILE_SIZE],
					[UPLOADED_DATE] = [UPLOADED_DATE],
					[MIME_TYPE] = [MIME_TYPE],
					[USER_CODE] = [USER_CODE],
					[CMP_CODECMP_CODE] = '',
					[OFFICE_CODE] = '',
					[CL_CODE] = CLIENT.CL_CODE,
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'CL',
					[OFFICE_NAME] = '',
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = '',
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = ''
				FROM   
					dbo.WV_CURRENT_CLIENT_DOCUMENTS
				INNER JOIN 
					dbo.CLIENT ON CLIENT.CL_CODE = WV_CURRENT_CLIENT_DOCUMENTS.CL_CODE
				INNER JOIN
					(SELECT	DISTINCT
						ClientCode
					 FROM
						@CDPs
					 WHERE
						TimeEntryOnly = 0) C ON CLIENT.CL_CODE = C.ClientCode						
				WHERE  
					LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(CLIENT.CL_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(CLIENT.CL_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
				ORDER BY
					CLIENT.CL_CODE
				         
	        END

	    IF @IsBlockedFromDivisionLevel = 0 
		BEGIN
			-- Search the Division Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = [DOCUMENT_ID],
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = [KEYWORDS],
					[FILE_SIZE] = [FILE_SIZE],
					[UPLOADED_DATE] = [UPLOADED_DATE],
					[MIME_TYPE] = [MIME_TYPE],
					[USER_CODE] = [USER_CODE],
					[CMP_CODE] = '',
					[OFFICE_CODE] = '',
					[CL_CODE] = CLIENT.CL_CODE,
					[DIV_CODE] = DIVISION.DIV_CODE,
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'DI',
					[OFFICE_NAME] = '',
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = DIVISION.DIV_NAME,
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.WV_CURRENT_DIVISION_DOCUMENTS
				INNER JOIN 
					dbo.DIVISION ON DIVISION.DIV_CODE = WV_CURRENT_DIVISION_DOCUMENTS.DIV_CODE
									AND WV_CURRENT_DIVISION_DOCUMENTS.CL_CODE = DIVISION.CL_CODE
				INNER JOIN 
					dbo.CLIENT ON CLIENT.CL_CODE = DIVISION.CL_CODE
				INNER JOIN 
					(SELECT
						*
					 FROM
						@CDPs
					 WHERE
						TimeEntryOnly = 0) CD ON WV_CURRENT_DIVISION_DOCUMENTS.CL_CODE = CD.ClientCode
												 AND WV_CURRENT_DIVISION_DOCUMENTS.DIV_CODE = CD.DivisionCode
				WHERE  
					LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(CLIENT.CL_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DIVISION.DIV_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(CLIENT.CL_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DIVISION.DIV_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
				ORDER BY
					CLIENT.CL_CODE,
					DIVISION.DIV_CODE
				         
	    END
	    
		IF @IsBlockedFromProductLevel = 0 
		BEGIN
			-- Search the Product Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = WV_CURRENT_PRODUCT_DOCUMENTS.DOCUMENT_ID,
					[FILENAME] = WV_CURRENT_PRODUCT_DOCUMENTS.[FILENAME],
					[DESCRIPTION] = WV_CURRENT_PRODUCT_DOCUMENTS.[DESCRIPTION],
					[KEYWORDS] = WV_CURRENT_PRODUCT_DOCUMENTS.KEYWORDS,
					[FILE_SIZE] = WV_CURRENT_PRODUCT_DOCUMENTS.FILE_SIZE,
					[UPLOADED_DATE] = WV_CURRENT_PRODUCT_DOCUMENTS.UPLOADED_DATE,
					[MIME_TYPE] = WV_CURRENT_PRODUCT_DOCUMENTS.MIME_TYPE,
					[USER_CODE] = WV_CURRENT_PRODUCT_DOCUMENTS.USER_CODE,
					[CMP_CODE] = '',
					[OFFICE_CODE] = OFFICE.OFFICE_CODE,
					[CL_CODE] = CLIENT.CL_CODE,
					[DIV_CODE] = DIVISION.DIV_CODE,
					[PRD_CODE] = PRODUCT.PRD_CODE,
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] =  'PR',
					[OFFICE_NAME] = OFFICE.OFFICE_NAME,
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = DIVISION.DIV_NAME,
					[PRODUCT_DESCRIPTION] = PRODUCT.PRD_DESCRIPTION,
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = WV_CURRENT_PRODUCT_DOCUMENTS.REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = ''
				FROM   
					dbo.WV_CURRENT_PRODUCT_DOCUMENTS
				INNER JOIN 
					dbo.CLIENT ON WV_CURRENT_PRODUCT_DOCUMENTS.CL_CODE = CLIENT.CL_CODE
				INNER JOIN 
					dbo.DIVISION ON WV_CURRENT_PRODUCT_DOCUMENTS.DIV_CODE = DIVISION.DIV_CODE
									AND WV_CURRENT_PRODUCT_DOCUMENTS.CL_CODE = DIVISION.CL_CODE
				INNER JOIN
					dbo.PRODUCT ON WV_CURRENT_PRODUCT_DOCUMENTS.CL_CODE = PRODUCT.CL_CODE
									AND WV_CURRENT_PRODUCT_DOCUMENTS.DIV_CODE = PRODUCT.DIV_CODE
									AND WV_CURRENT_PRODUCT_DOCUMENTS.PRD_CODE = PRODUCT.PRD_CODE
				INNER JOIN 
					dbo.OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
				INNER JOIN 
					@CDPs CDP ON PRODUCT.CL_CODE = CDP.ClientCode
									AND PRODUCT.DIV_CODE = CDP.DivisionCode
									AND PRODUCT.PRD_CODE = CDP.ProductCode
				WHERE  
					(
						LOWER(WV_CURRENT_PRODUCT_DOCUMENTS.KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(WV_CURRENT_PRODUCT_DOCUMENTS.DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(WV_CURRENT_PRODUCT_DOCUMENTS.FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(WV_CURRENT_PRODUCT_DOCUMENTS.USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND CDP.TimeEntryOnly = 0
				ORDER BY
					CLIENT.CL_CODE,
					DIVISION.DIV_CODE,
					PRODUCT.PRD_CODE,
					DOCUMENT_ID
				         
	    END

		IF @IsBlockedFromCampaignLevel = 0 
		BEGIN
			-- Search the Campaign Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = DOCUMENT_ID,
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = KEYWORDS,
					[FILE_SIZE] = FILE_SIZE,
					[UPLOADED_DATE] = UPLOADED_DATE,
					[MIME_TYPE] = MIME_TYPE,
					[USER_CODE] = USER_CODE,
					[CMP_CODE] = CAMPAIGN.CMP_CODE,
					[OFFICE_CODE] = OFFICE.OFFICE_CODE,
					[CL_CODE] = CAMPAIGN.CL_CODE,
					[DIV_CODE] = CAMPAIGN.DIV_CODE,
					[PRD_CODE] = CAMPAIGN.PRD_CODE,
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'CM',
					[OFFICE_NAME] = OFFICE.OFFICE_NAME,
					[CAMPAIGN_NAME] = CAMPAIGN.CMP_NAME,
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = DIVISION.DIV_NAME,
					[PRODUCT_DESCRIPTION] = PRODUCT.PRD_DESCRIPTION,
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.WV_CURRENT_CAMPAIGN_DOCUMENTS
				INNER JOIN 
					dbo.CAMPAIGN ON WV_CURRENT_CAMPAIGN_DOCUMENTS.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER
				LEFT OUTER JOIN 
					dbo.CLIENT ON CAMPAIGN.CL_CODE = CLIENT.CL_CODE
				LEFT OUTER JOIN 
					dbo.PRODUCT ON CAMPAIGN.CL_CODE = PRODUCT.CL_CODE
								   AND CAMPAIGN.DIV_CODE = PRODUCT.DIV_CODE
								   AND CAMPAIGN.PRD_CODE = PRODUCT.PRD_CODE
				LEFT OUTER JOIN 
					dbo.OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
				LEFT OUTER JOIN 
					dbo.DIVISION ON CAMPAIGN.CL_CODE = DIVISION.CL_CODE
									AND CAMPAIGN.DIV_CODE = DIVISION.DIV_CODE
				INNER JOIN
					(SELECT	DISTINCT
						ClientCode
					 FROM
						@CDPs
					 WHERE
						TimeEntryOnly = 0) C ON CAMPAIGN.CL_CODE = C.ClientCode 
				LEFT OUTER JOIN
					(SELECT	DISTINCT
						ClientCode,
						DivisionCode
					 FROM
						@CDPs
					 WHERE
						TimeEntryOnly = 0) CD ON CAMPAIGN.CL_CODE = CD.ClientCode AND
												 CAMPAIGN.DIV_CODE = CD.DivisionCode
				LEFT OUTER JOIN
					(SELECT
						ClientCode,
						DivisionCode,
						ProductCode
					 FROM
						@CDPs
					 WHERE
						TimeEntryOnly = 0) CDP ON CAMPAIGN.CL_CODE = CDP.ClientCode AND
												  CAMPAIGN.DIV_CODE = CDP.DivisionCode AND
												  CAMPAIGN.PRD_CODE = CDP.ProductCode
				LEFT OUTER JOIN
					@Offices O ON CAMPAIGN.OFFICE_CODE = O.OfficeCode
				WHERE  
					(
						LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CAMPAIGN.CMP_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND 1 = CASE WHEN CAMPAIGN.DIV_CODE IS NULL THEN 1 WHEN CD.DivisionCode IS NOT NULL THEN 1 ELSE 0 END
					AND 1 = CASE WHEN CAMPAIGN.PRD_CODE IS NULL THEN 1 WHEN CDP.ProductCode IS NOT NULL THEN 1 ELSE 0 END
					AND 1 = CASE WHEN @IsLimitedByOffice = 0 THEN 1 WHEN O.OfficeCode IS NOT NULL THEN 1 ELSE 0 END
				ORDER BY
					CLIENT.CL_CODE,
					DIVISION.DIV_CODE,
					PRODUCT.PRD_CODE,
					CAMPAIGN.CMP_CODE

		END

		IF @IsBlockedFromJobLevel = 0 
		BEGIN
			-- Search the Job Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = DOCUMENT_ID,
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = KEYWORDS,
					[FILE_SIZE] = FILE_SIZE,
					[UPLOADED_DATE] = UPLOADED_DATE,
					[MIME_TYPE] = MIME_TYPE,
					[USER_CODE] = USER_CODE,
					[CMP_CODE] = CAMPAIGN.CMP_CODE,
					[OFFICE_CODE] = OFFICE.OFFICE_CODE,
					[CL_CODE] = CLIENT.CL_CODE,
					[DIV_CODE] = DIVISION.DIV_CODE,
					[PRD_CODE] = PRODUCT.PRD_CODE,
					[JOB_NUMBER] = JOB_LOG.JOB_NUMBER,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'JO',
					[OFFICE_NAME] = OFFICE_NAME,
					[CAMPAIGN_NAME] = CAMPAIGN.CMP_NAME,
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = DIVISION.DIV_NAME,
					[PRODUCT_DESCRIPTION] = PRODUCT.PRD_DESCRIPTION,
					[JOB_DESCRIPTION] = JOB_LOG.JOB_DESC,
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = ''
				FROM   
					dbo.WV_CURRENT_JOB_DOCUMENTS
				INNER JOIN 
					dbo.JOB_LOG ON WV_CURRENT_JOB_DOCUMENTS.JOB_NUMBER = JOB_LOG.JOB_NUMBER
				INNER JOIN 
					dbo.DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE
									AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE
				INNER JOIN 
					dbo.PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE
								   AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE
								   AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE
				INNER JOIN 
					dbo.OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
				INNER JOIN 
					dbo.CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
				INNER JOIN
					@CDPs CDP ON PRODUCT.CL_CODE = CDP.ClientCode
								 AND PRODUCT.DIV_CODE = CDP.DivisionCode
								 AND PRODUCT.PRD_CODE = CDP.ProductCode
				LEFT OUTER JOIN 
					dbo.CAMPAIGN ON JOB_LOG.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER
				LEFT OUTER JOIN 
					@Offices O ON JOB_LOG.OFFICE_CODE = O.OfficeCode
				WHERE  
					(
						LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(OFFICE.OFFICE_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(JOB_LOG.JOB_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(OFFICE.OFFICE_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(JOB_LOG.JOB_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND CDP.TimeEntryOnly = 0
					AND 1 = CASE WHEN @IsLimitedByOffice = 0 THEN 1 WHEN O.OfficeCode IS NOT NULL THEN 1 ELSE 0 END
				ORDER BY
					CLIENT.CL_CODE,
					DIVISION.DIV_CODE,
					PRODUCT.PRD_CODE,
					JOB_LOG.JOB_NUMBER

		END

		IF @IsBlockedFromJobComponentLevel = 0 
		BEGIN
			-- Search the Job Component Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = DOCUMENT_ID,
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = KEYWORDS,
					[FILE_SIZE] = FILE_SIZE,
					[UPLOADED_DATE] = UPLOADED_DATE,
					[MIME_TYPE] = MIME_TYPE,
					[USER_CODE] = USER_CODE,
					[CMP_CODE] = JOB_LOG.CMP_CODE,
					[OFFICE_CODE] = JOB_LOG.OFFICE_CODE,
					[CL_CODE] = JOB_LOG.CL_CODE,
					[DIV_CODE] = JOB_LOG.DIV_CODE,
					[PRD_CODE] = JOB_LOG.PRD_CODE,
					[JOB_NUMBER] = JOB_COMPONENT.JOB_NUMBER,
					[JOB_COMPONENT_NBR] = JOB_COMPONENT.JOB_COMPONENT_NBR,
					[LEVEL] = 'JC',
					[OFFICE_NAME] = OFFICE_NAME,
					[CAMPAIGN_NAME] = CAMPAIGN.CMP_NAME,
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = DIVISION.DIV_NAME,
					[PRODUCT_DESCRIPTION] = PRODUCT.PRD_DESCRIPTION,
					[JOB_DESCRIPTION] = JOB_LOG.JOB_DESC,
					[JOB_COMP_DESCRIPTION] = JOB_COMPONENT.JOB_COMP_DESC,
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.WV_CURRENT_JOB_COMPONENT_DOCUMENTS
				INNER JOIN 
					dbo.JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = WV_CURRENT_JOB_COMPONENT_DOCUMENTS.JOB_NUMBER
										 AND JOB_COMPONENT.JOB_COMPONENT_NBR = WV_CURRENT_JOB_COMPONENT_DOCUMENTS.JOB_COMPONENT_NUMBER
				INNER JOIN 
					dbo.JOB_LOG ON JOB_LOG.JOB_NUMBER = WV_CURRENT_JOB_COMPONENT_DOCUMENTS.JOB_NUMBER
				INNER JOIN 
					dbo.PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
								   AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
								   AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN 
					dbo.DIVISION ON DIVISION.CL_CODE = JOB_LOG.CL_CODE
									AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
				INNER JOIN 
					dbo.CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN 
					dbo.OFFICE ON OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE
				LEFT OUTER JOIN 
					dbo.CAMPAIGN ON CAMPAIGN.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER
				LEFT OUTER JOIN 
					@Offices O ON JOB_LOG.OFFICE_CODE = O.OfficeCode
				INNER JOIN
					@CDPs CDP ON PRODUCT.CL_CODE = CDP.ClientCode
								 AND PRODUCT.DIV_CODE = CDP.DivisionCode
								 AND PRODUCT.PRD_CODE = CDP.ProductCode
				WHERE 
					(
						LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(JOB_LOG.JOB_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(JOB_COMPONENT.JOB_COMP_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(CLIENT.CL_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DIVISION.DIV_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(PRODUCT.PRD_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(OFFICE.OFFICE_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND CDP.TimeEntryOnly = 0 
					AND 1 = CASE WHEN @IsLimitedByOffice = 0 THEN 1 WHEN O.OfficeCode IS NOT NULL THEN 1 ELSE 0 END
				ORDER BY
					CLIENT.CL_CODE,
					DIVISION.DIV_CODE,
					PRODUCT.PRD_CODE,
					JOB_LOG.JOB_NUMBER,
					JOB_COMPONENT.JOB_COMPONENT_NBR
				         
		END

		IF @IsBlockedFromAPLevel = 0 
		BEGIN
			-- Search the AP Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT DISTINCT 
					[DOCUMENT_ID] = DOCUMENT_ID,
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = KEYWORDS,
					[FILE_SIZE] = FILE_SIZE,
					[UPLOADED_DATE] = UPLOADED_DATE,
					[MIME_TYPE] = MIME_TYPE,
					[USER_CODE] = USER_CODE,
					[CMP_CODE] = '',
					[OFFICE_CODE] = '',
					[CL_CODE] = '',
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'VN',
					[OFFICE_NAME] = '',
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = '',
					[DIVISION_NAME] = '',
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = AP_HEADER.VN_FRL_EMP_CODE,
					[AP_INVOICE] = AP_HEADER.AP_INV_VCHR,
					[VENDOR_NAME] = VENDOR.VN_NAME,
					[AP_INVOICE_DESC] = AP_HEADER.AP_DESC,
					[AP_ID] = AP_HEADER.AP_ID,
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.WV_CURRENT_AP_DOCUMENTS
				INNER JOIN 
					dbo.AP_HEADER ON AP_HEADER.AP_ID = WV_CURRENT_AP_DOCUMENTS.AP_ID
				LEFT OUTER JOIN 
					dbo.AP_PRODUCTION ON AP_PRODUCTION.AP_ID = WV_CURRENT_AP_DOCUMENTS.AP_ID
				LEFT OUTER JOIN 
					dbo.JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = AP_PRODUCTION.JOB_NUMBER
										 AND JOB_COMPONENT.JOB_COMPONENT_NBR = AP_PRODUCTION.JOB_COMPONENT_NBR
				LEFT OUTER JOIN 
					dbo.JOB_LOG ON JOB_LOG.JOB_NUMBER = AP_PRODUCTION.JOB_NUMBER
				INNER JOIN 
					dbo.VENDOR ON AP_HEADER.VN_FRL_EMP_CODE = VENDOR.VN_CODE
				LEFT OUTER JOIN
					@Offices VO ON VENDOR.OFFICE_CODE = VO.OfficeCode
				LEFT OUTER JOIN
					@Offices APO ON AP_HEADER.OFFICE_CODE = APO.OfficeCode
				LEFT OUTER JOIN
					@CDPs CDP ON JOB_LOG.CL_CODE = CDP.ClientCode AND
								 JOB_LOG.DIV_CODE = CDP.DivisionCode AND
								 JOB_LOG.PRD_CODE = CDP.ProductCode
				WHERE
					(
						LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(AP_HEADER.VN_FRL_EMP_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(AP_HEADER.AP_INV_VCHR) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(VENDOR.VN_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(AP_HEADER.AP_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND CDP.TimeEntryOnly = 0 
					AND 1 = CASE WHEN AP_PRODUCTION.JOB_NUMBER IS NULL THEN 1 WHEN CDP.ClientCode IS NOT NULL THEN 1 ELSE 0 END 
					AND 1 = CASE WHEN @IsLimitedByOffice = 0 THEN 1 WHEN VO.OfficeCode IS NOT NULL AND APO.OfficeCode IS NOT NULL THEN 1 ELSE 0 END
				ORDER BY
					AP_HEADER.VN_FRL_EMP_CODE
		END

		IF @IsBlockedFromAgencyDesktopLevel = 0 
		BEGIN
			-- Search the Agency Desktop Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = DOCUMENT_ID,
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = KEYWORDS,
					[FILE_SIZE] = FILE_SIZE,
					[UPLOADED_DATE] = UPLOADED_DATE,
					[MIME_TYPE] = MIME_TYPE,
					[USER_CODE] = USER_CODE,
					[CMP_CODE] = '',
					[OFFICE_CODE] = OFFICE.OFFICE_CODE,
					[CL_CODE] = '',
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'AD',
					[OFFICE_NAME] = OFFICE.OFFICE_NAME,
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = '',
					[DIVISION_NAME] = '',
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS
				LEFT OUTER JOIN 
					dbo.OFFICE ON OFFICE.OFFICE_CODE = WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS.OFFICE_CODE
				LEFT OUTER JOIN DEPT_TEAM ON DEPT_TEAM.DP_TM_CODE = WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS.DP_TM_CODE
				WHERE  
					LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(OFFICE.OFFICE_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(OFFICE.OFFICE_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DEPT_TEAM.DP_TM_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					OR LOWER(DEPT_TEAM.DP_TM_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
				ORDER BY
					OFFICE.OFFICE_CODE
				         
	    END

		IF @IsBlockedFromExecutiveDesktopLevel = 0 
		BEGIN
			-- Search the Executive Desktop Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT 
					[DOCUMENT_ID] = DOCUMENT_ID,
					[FILENAME] = [FILENAME],
					[DESCRIPTION] = [DESCRIPTION],
					[KEYWORDS] = KEYWORDS,
					[FILE_SIZE] = FILE_SIZE,
					[UPLOADED_DATE] = UPLOADED_DATE,
					[MIME_TYPE] = MIME_TYPE,
					[USER_CODE] = USER_CODE,
					[CMP_CODE] = '',
					[OFFICE_CODE] = OFFICE.OFFICE_CODE,
					[CL_CODE] = '',
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'ED',
					[OFFICE_NAME] = OFFICE.OFFICE_NAME,
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = '',
					[DIVISION_NAME] = '',
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.WV_CURRENT_EXEC_DESKTOP_DOCUMENTS
				LEFT OUTER JOIN 
					dbo.OFFICE ON OFFICE.OFFICE_CODE = WV_CURRENT_EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE
				LEFT OUTER JOIN
					@Offices O ON OFFICE.OFFICE_CODE = O.OfficeCode
				WHERE  
					(
						LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(OFFICE.OFFICE_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(OFFICE.OFFICE_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND 1 = CASE WHEN @IsLimitedByOffice = 0 THEN 1 WHEN O.OfficeCode IS NOT NULL THEN 1 ELSE 0 END
				ORDER BY
					OFFICE.OFFICE_CODE
				         
	        END

		IF @IsBlockedFromAdNumberLevel = 0 
		BEGIN
			-- Search the Ad Number Documents
			INSERT INTO @SEARCH_RESULTS
				SELECT DISTINCT
					[DOCUMENT_ID] = DOCUMENTS.DOCUMENT_ID,
					[FILENAME] = DOCUMENTS.[FILENAME],
					[DESCRIPTION] = DOCUMENTS.[DESCRIPTION],
					[KEYWORDS] = DOCUMENTS.KEYWORDS,
					[FILE_SIZE] = DOCUMENTS.FILE_SIZE,
					[UPLOADED_DATE] = DOCUMENTS.UPLOADED_DATE,
					[MIME_TYPE] = DOCUMENTS.MIME_TYPE,
					[USER_CODE] = DOCUMENTS.USER_CODE,
					[CMP_CODE] = '',
					[OFFICE_CODE] = '',
					[CL_CODE] = AD_NUMBER.CL_CODE,
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NUMBER] = NULL,
					[JOB_COMPONENT_NBR] = NULL,
					[LEVEL] = 'AN',
					[OFFICE_NAME] = '',
					[CAMPAIGN_NAME] = '',
					[CLIENT_NAME] = CLIENT.CL_NAME,
					[DIVISION_NAME] = '',
					[PRODUCT_DESCRIPTION] = '',
					[JOB_DESCRIPTION] = '',
					[JOB_COMP_DESCRIPTION] = '',
					[REPOSITORY_FILENAME] = DOCUMENTS.REPOSITORY_FILENAME,
					[VENDOR_CODE] = '',
					[AP_INVOICE] = '',
					[VENDOR_NAME] = '',
					[AP_INVOICE_DESC] = '',
					[AP_ID] = '',
					[AD_NBR] = AD_NUMBER.AD_NBR,
					[AD_NBR_DESC] = AD_NUMBER.AD_NBR_DESC
				FROM   
					dbo.DOCUMENTS
				INNER JOIN 
					dbo.AD_NUMBER ON DOCUMENTS.DOCUMENT_ID = AD_NUMBER.DOCUMENT_ID
				LEFT OUTER JOIN 
					dbo.CLIENT ON AD_NUMBER.CL_CODE = CLIENT.CL_CODE
				LEFT OUTER JOIN
					(SELECT	DISTINCT
						ClientCode
					 FROM
						@CDPs
					 WHERE
						TimeEntryOnly = 0) C ON CLIENT.CL_CODE = C.ClientCode
				WHERE  (
						   LOWER(DOCUMENTS.KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						   OR LOWER(DOCUMENTS.DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						   OR LOWER(DOCUMENTS.FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%'
						   OR LOWER(AD_NUMBER.AD_NBR_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
						   OR LOWER(AD_NUMBER.AD_NBR) LIKE '%' + LOWER(@SearchCriteria) + '%'
						   OR LOWER(DOCUMENTS.USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
					   )
					   AND 1 = CASE WHEN AD_NUMBER.CL_CODE IS NULL THEN 1 WHEN C.ClientCode IS NOT NULL THEN 1 ELSE 0 END
				ORDER BY
					AD_NUMBER.AD_NBR 

	        END

		IF @IsBlockedFromExpenseReportLevel = 0 BEGIN
			-- Search the Expense Report Documents
			-- Receipts can contain documents from multiple job/comp's and can produce duplicates.                        
			INSERT INTO @SEARCH_RESULTS
				SELECT DISTINCT 
					[DOCUMENT_ID] = DOCUMENTS.DOCUMENT_ID,
					[FILENAME] = DOCUMENTS.[FILENAME],
					[DESCRIPTION] = DOCUMENTS.[DESCRIPTION],
					[KEYWORDS] = DOCUMENTS.KEYWORDS,
					[FILE_SIZE] = DOCUMENTS.FILE_SIZE,
					[UPLOADED_DATE] = DOCUMENTS.UPLOADED_DATE,
					[MIME_TYPE] = DOCUMENTS.MIME_TYPE,
					[USER_CODE] = DOCUMENTS.USER_CODE,
					[CMP_CODE] = '',
					[OFFICE_CODE] = '',
					[CL_CODE] = '',
					[DIV_CODE] = '',
					[PRD_CODE] = '',
					[JOB_NBR] = NULL,
					[JOB_COMP_NBR] = NULL,
					[LEVEL] = 'EX',
					[OFFICE_NAME] = '',
					[CAMPAIGN_NAME] = '',
					[CL_NAME] = '',
					[DIV_NAME] = '',
					[PRD_DESCRIPTION] = '',
					[JOB_DESC] = '',
					[JOB_COMP_DESC] = '',
					[REPOSITORY_FILENAME] = DOCUMENTS.REPOSITORY_FILENAME,
					[EMP_CODE] = EXPENSE_HEADER.EMP_CODE,
					[INV_NBR] = EXPENSE_DOCS.INV_NBR,
					[EMP_NAME] = dbo.udf_get_empl_name(EXPENSE_HEADER.EMP_CODE, 'FML'),
					[EXP_DESC] = EXPENSE_HEADER.EXP_DESC,
					[AP_ID] = '',
					[AD_NBR] = '',
					[AD_NBR_DESC] = '' 
				FROM   
					dbo.DOCUMENTS
				INNER JOIN 
					dbo.EXPENSE_DOCS ON DOCUMENTS.DOCUMENT_ID = EXPENSE_DOCS.DOCUMENT_ID
				INNER JOIN 
					dbo.EXPENSE_HEADER ON EXPENSE_HEADER.INV_NBR = EXPENSE_DOCS.INV_NBR
				INNER JOIN
					@Employees AS EL ON EXPENSE_HEADER.EMP_CODE = EL.EmployeeCode
				INNER JOIN 
					dbo.EXPENSE_DETAIL ON EXPENSE_DETAIL.INV_NBR = EXPENSE_HEADER.INV_NBR		                        
				LEFT OUTER JOIN
					@CDPs CDP ON EXPENSE_DETAIL.CL_CODE = CDP.ClientCode AND
								 EXPENSE_DETAIL.DIV_CODE = CDP.DivisionCode AND
								 EXPENSE_DETAIL.PRD_CODE = CDP.ProductCode
				WHERE  
					(
						LOWER(KEYWORDS) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(DESCRIPTION) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(FILENAME) LIKE '%' + LOWER(@SearchCriteria) + '%' 
						OR LOWER(USER_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(EXPENSE_HEADER.EXP_DESC) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(EXPENSE_HEADER.EMP_CODE) LIKE '%' + LOWER(@SearchCriteria) + '%'
						OR LOWER(dbo.udf_get_empl_name(EXPENSE_HEADER.EMP_CODE, 'FML')) LIKE '%' + LOWER(@SearchCriteria) + '%'
					)
					AND 1 = CASE WHEN ISNULL(EXPENSE_DETAIL.CL_CODE, '') = '' THEN 1 WHEN CDP.ClientCode IS NOT NULL AND CDP.TimeEntryOnly = 0 THEN 1 ELSE 0 END
				ORDER BY
					EXPENSE_DOCS.INV_NBR
					            
	        END
	        
	END --Ending the search criteria blank "if" statement

	SELECT 
		[DOCUMENT_ID] = SR.DOCUMENT_ID,
		[FILENAME] = SR.[FILENAME],
		[DESCRIPTION] = SR.[DESCRIPTION],
		[KEYWORDS] = SR.KEYWORDS,
		[FILE_SIZE] = SR.FILE_SIZE,
		[UPLOADED_DATE] = SR.UPLOADED_DATE,
		[MIME_TYPE] = SR.MIME_TYPE,
		[USER_CODE] = SR.USER_CODE,
		[CMP_CODE] = SR.CMP_CODE,
		[OFFICE_CODE] = SR.OFFICE_CODE,
		[CL_CODE] = SR.CL_CODE,
		[DIV_CODE] = SR.DIV_CODE,
		[PRD_CODE] = SR.PRD_CODE,
		[JOB_NUMBER] = SR.JOB_NUMBER,
		[JOB_COMPONENT_NBR] = SR.JOB_COMPONENT_NBR,
		[LEVEL] = SR.[LEVEL],
		[OFFICE_NAME] = SR.OFFICE_NAME,
		[CAMPAIGN_NAME] = SR.CAMPAIGN_NAME,
		[CLIENT_NAME] = SR.CLIENT_NAME,
		[DIVISION_NAME] = SR.DIVISION_NAME,
		[PRODUCT_DESCRIPTION] = SR.PRODUCT_DESCRIPTION,
		[JOB_DESCRIPTION] = SR.JOB_DESCRIPTION,
		[JOB_COMP_DESCRIPTION] = SR.JOB_COMP_DESCRIPTION,
		[REPOSITORY_FILENAME] = SR.REPOSITORY_FILENAME,
		[VENDOR_CODE] = SR.VENDOR_CODE,
		[AP_INVOICE] = SR.AP_INVOICE,
		[VENDOR_NAME] = SR.VENDOR_NAME,
		[AP_INVOICE_DESC] = SR.AP_INVOICE_DESC,
		[AP_ID] = SR.AP_ID,
		[AD_NBR] = SR.AD_NBR,
		[AD_NBR_DESC] = SR.AD_NBR_DESC
	FROM   
		@SEARCH_RESULTS AS SR
	INNER JOIN 
		dbo.DOCUMENTS AS D ON SR.DOCUMENT_ID = D.DOCUMENT_ID
	WHERE  
		1 = CASE WHEN @AccessPrivate = 1 THEN 1 WHEN D.PRIVATE_FLAG IS NULL OR D.PRIVATE_FLAG = 0 THEN 1 ELSE 0 END

END --Ending the very very first Begin statement