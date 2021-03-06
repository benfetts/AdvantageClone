CREATE PROCEDURE [dbo].[advsp_office_rpt] @OFFICE_CODE VARCHAR(4)
AS
BEGIN

	DECLARE @REPORT_TABLE TABLE (
		[OFFICE_CODE] VARCHAR(100),
		[OFFICE_NAME] VARCHAR(100),
		[GLACODE_AR] VARCHAR(100),
		[GLACODE_AP] VARCHAR(100),
		[GLACODE_AP_DISC] VARCHAR(30),
		[GLACODE_CRNCY_GAIN_LOSS] VARCHAR(30),
		[GLACODE_SUSPENSE] VARCHAR(30),
		[GLACODE_STATE] VARCHAR(30),
		[GLACODE_COUNTY] VARCHAR(30),
		[GLACODE_CITY] VARCHAR(30),
		[PGLACODE_SALES] VARCHAR(30),
		[PGLACODE_COS] VARCHAR(30),
		[PGLACODE_WIP] VARCHAR(30),
		[PGLACODE_DEF_SALES] VARCHAR(30),
		[PGLACODE_ACC_COS] VARCHAR(30),
		[PGLACODE_ACC_AP] VARCHAR(30),
		[PGLACODE_DEF_COS] VARCHAR(30),
		[PGLACODE_ACC_TAX] VARCHAR(30),
		[MGLACODE_SALES] VARCHAR(30),
		[MGLACODE_COS] VARCHAR(30),
		[MGLACODE_WIP] VARCHAR(30),
		[MGLACODE_DEF_SALES] VARCHAR(30),
		[MGLACODE_ACC_COS] VARCHAR(30),
		[MGLACODE_ACC_AP] VARCHAR(30),
		[MGLACODE_DEF_COS] VARCHAR(30),
		[MGLACODE_ACC_TAX] VARCHAR(30)
	)

	DECLARE @INTER_COMPANY SMALLINT
	
	SELECT @INTER_COMPANY = ISNULL(AGENCY.INTER_COMPANY, 0) FROM dbo.AGENCY

	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES (NULL) -- blank row

	INSERT INTO @REPORT_TABLE 
		SELECT	[OFFICE_CODE] = OFFICE.OFFICE_CODE ,
				[OFFICE_NAME] = OFFICE.OFFICE_NAME,
				[GLACODE_AR] = OFFICE.GLACODE_AR,
				[GLACODE_AP] = OFFICE.GLACODE_AP,
				[GLACODE_AP_DISC] = OFFICE.GLACODE_AP_DISC,
				[GLACODE_CRNCY_GAIN_LOSS] = OFFICE.GLACODE_CRNCY_GAIN_LOSS,
				[GLACODE_SUSPENSE] = OFFICE.GLACODE_SUSPENSE,
				[GLACODE_STATE] = OFFICE.GLACODE_STATE,
				[GLACODE_COUNTY] = OFFICE.GLACODE_COUNTY,
				[GLACODE_CITY] = OFFICE.GLACODE_CITY,
				[PGLACODE_SALES] = OFFICE.PGLACODE_SALES,
				[PGLACODE_COS] = OFFICE.PGLACODE_COS,
				[PGLACODE_WIP] = OFFICE.PGLACODE_WIP,
				[PGLACODE_DEF_SALES] = OFFICE.PGLACODE_DEF_SALES,
				[PGLACODE_ACC_COS] = OFFICE.PGLACODE_ACC_COS,
				[PGLACODE_ACC_AP] = OFFICE.PGLACODE_ACC_AP,
				[PGLACODE_DEF_COS] = OFFICE.PGLACODE_DEF_COS,
				[PGLACODE_ACC_TAX] = OFFICE.PGLACODE_ACC_TAX,
				[MGLACODE_SALES] = OFFICE.MGLACODE_SALES,
				[MGLACODE_COS] = OFFICE.MGLACODE_COS,
				[MGLACODE_WIP] = OFFICE.MGLACODE_WIP,
				[MGLACODE_DEF_SALES] = OFFICE.MGLACODE_DEF_SALES,
				[MGLACODE_ACC_COS] = OFFICE.MGLACODE_ACC_COS,
				[MGLACODE_ACC_AP] = OFFICE.MGLACODE_ACC_AP,
				[MGLACODE_DEF_COS] = OFFICE.MGLACODE_DEF_COS,
				[MGLACODE_ACC_TAX] = OFFICE.MGLACODE_ACC_TAX
		FROM dbo.OFFICE WHERE OFFICE_CODE = @OFFICE_CODE
	
	INSERT INTO @REPORT_TABLE (OFFICE_CODE)
		SELECT	'     ' + 'Inactive: ' + CASE WHEN OFFICE.INACTIVE_FLAG IS NULL OR OFFICE.INACTIVE_FLAG = 0 THEN 'No' ELSE 'Yes' END			
		FROM dbo.OFFICE 
		WHERE OFFICE_CODE = @OFFICE_CODE
		
	INSERT INTO @REPORT_TABLE (OFFICE_CODE)
		SELECT	'     ' + 'GL Cross Reference Code: ' + GLOXREF.GLOXGLOFFICE
		FROM dbo.GLOXREF 
		WHERE GLOXOFFICE = @OFFICE_CODE
		
	INSERT INTO @REPORT_TABLE (OFFICE_CODE)
		SELECT	'     ' + 'Advance Billing Income Recognition: ' + CASE WHEN OFFICE.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN OFFICE.PRD_AB_INCOME = 2 THEN 'Initial Billing' END
		FROM dbo.OFFICE 
		WHERE OFFICE_CODE = @OFFICE_CODE

	INSERT INTO @REPORT_TABLE (OFFICE_CODE)
		SELECT	'     ' + 'Prebill Income Recognition: ' + CASE WHEN OFFICE.MED_AB_INCOME = 1 THEN 'Billing Date' WHEN OFFICE.MED_AB_INCOME = 2 THEN 'Insertion/Broadcast Date' WHEN OFFICE.MED_AB_INCOME = 3 THEN 'Close Date' END
		FROM dbo.OFFICE 
		WHERE OFFICE_CODE = @OFFICE_CODE
		
	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES (NULL) -- blank row

	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES ('     ' + 'Function Accounts') -- header row
		
	INSERT INTO @REPORT_TABLE (OFFICE_CODE, PGLACODE_SALES, PGLACODE_COS)
		SELECT	'          ' + OFF_FNC_ACCTS.FNC_CODE + ' - ' + FUNCTIONS.FNC_DESCRIPTION,
				OFF_FNC_ACCTS.PGLACODE_SALES,
				OFF_FNC_ACCTS.PGLACODE_COS
		FROM dbo.OFF_FNC_ACCTS INNER JOIN
			 dbo.FUNCTIONS ON FUNCTIONS.FNC_CODE = OFF_FNC_ACCTS.FNC_CODE 
		WHERE OFFICE_CODE = @OFFICE_CODE
	
	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES (NULL) -- blank row

	INSERT INTO @REPORT_TABLE ([OFFICE_CODE], [OFFICE_NAME]) VALUES ('     ' + 'Sales Class/Function Accounts', 'Function') -- header row

	INSERT INTO @REPORT_TABLE (OFFICE_CODE, OFFICE_NAME, PGLACODE_SALES, PGLACODE_COS, MGLACODE_SALES, MGLACODE_COS)
		SELECT	'          ' + OFF_SC_ACCTS.SC_CODE,
				OFF_SC_FNC_ACCTS.FNC_CODE,
				CASE WHEN OFF_SC_FNC_ACCTS.FNC_CODE IS NOT NULL THEN OFF_SC_FNC_ACCTS.PGLACODE_SALES ELSE OFF_SC_ACCTS.PGLACODE_SALES END,
				CASE WHEN OFF_SC_FNC_ACCTS.FNC_CODE IS NOT NULL THEN OFF_SC_FNC_ACCTS.PGLACODE_COS ELSE OFF_SC_ACCTS.PGLACODE_COS END,
				OFF_SC_ACCTS.MGLACODE_SALES,
				OFF_SC_ACCTS.MGLACODE_COS
		FROM dbo.OFF_SC_ACCTS 
		LEFT OUTER JOIN dbo.OFF_SC_FNC_ACCTS ON OFF_SC_ACCTS.OFFICE_CODE = OFF_SC_FNC_ACCTS.OFFICE_CODE AND
												OFF_SC_ACCTS.SC_CODE = OFF_SC_FNC_ACCTS.SC_CODE
		WHERE OFF_SC_ACCTS.OFFICE_CODE = @OFFICE_CODE
	
	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES (NULL) -- blank row

	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES ('     ' + 'Sales Tax Accounts') -- header row

	INSERT INTO @REPORT_TABLE (OFFICE_CODE, GLACODE_STATE, GLACODE_COUNTY, GLACODE_CITY)
		SELECT	'          ' + OFF_TAX_ACCTS.TAX_CODE,
				OFF_TAX_ACCTS.GLACODE_TAX_STATE,
				OFF_TAX_ACCTS.GLACODE_TAX_CNTY,
				OFF_TAX_ACCTS.GLACODE_TAX_CITY
		FROM dbo.OFF_TAX_ACCTS 
		WHERE OFFICE_CODE = @OFFICE_CODE

	INSERT INTO @REPORT_TABLE ([OFFICE_CODE]) VALUES (NULL) -- blank row

	INSERT INTO @REPORT_TABLE (OFFICE_CODE, OFFICE_NAME, GLACODE_AR, GLACODE_AP) VALUES ('     ' + 'Inter-Company Accounts', 'GL Cross Ref', '''' + @OFFICE_CODE + ''' Account', 'Inter-Company Account') -- header row

	IF @INTER_COMPANY = 1 
	BEGIN

	INSERT INTO @REPORT_TABLE (OFFICE_CODE, OFFICE_NAME, GLACODE_AR, GLACODE_AP)
		SELECT	'          ' + OFF_INTER_CO.INTER_CO_CODE,
				GLOXREF.GLOXGLOFFICE,
				OFF_INTER_CO.DUE_FROM,
				OFF_INTER_CO.DUE_TO
		FROM dbo.OFF_INTER_CO 
		JOIN dbo.GLOXREF ON OFF_INTER_CO.INTER_CO_CODE = GLOXREF.GLOXOFFICE
		WHERE @INTER_COMPANY = 1 AND 
			  OFFICE_CODE = @OFFICE_CODE 

	END
	ELSE
	BEGIN
	
		INSERT INTO @REPORT_TABLE (OFFICE_CODE) VALUES ('          ' + 'None')
		
	END

	SELECT	[OFFICE_CODE] as 'Office',
			[OFFICE_NAME] as 'Description',
			[GLACODE_AR] as 'A/R',
			[GLACODE_AP] as 'A/P',
			[GLACODE_AP_DISC] as 'A/P Discount',
			[GLACODE_CRNCY_GAIN_LOSS] as 'Currency Exchange Unrealized',
			[GLACODE_SUSPENSE] as 'Suspense',
			[GLACODE_STATE] as 'State',
			[GLACODE_COUNTY] as 'County',
			[GLACODE_CITY] as 'City',
			[PGLACODE_SALES] as 'Production Sales',
			[PGLACODE_COS] as 'Production Cost of Sales',
			[PGLACODE_WIP] as 'Production Work in Progress',
			[PGLACODE_DEF_SALES] as 'Production Deferred Sales',
			[PGLACODE_ACC_COS] as 'Production Accrued COS',
			[PGLACODE_ACC_AP] as 'Production Accrued A/P',
			[PGLACODE_DEF_COS] as 'Production Deferred COS',
			[PGLACODE_ACC_TAX] as 'Production Accrued Sales Tax',
			[MGLACODE_SALES] as 'Media Sales',
			[MGLACODE_COS] as 'Media Cost of Sales',
			[MGLACODE_WIP] as 'Media Accrued A/P',
			[MGLACODE_DEF_SALES] as 'Media Deferred Sales',
			[MGLACODE_ACC_COS] as 'Media Accrued COS',
			[MGLACODE_ACC_AP] as 'Media Accrued A/P',
			[MGLACODE_DEF_COS] as 'Media Deferred COS',
			[MGLACODE_ACC_TAX] as 'Media Accrued Sales Tax'
	FROM @REPORT_TABLE

END
GO