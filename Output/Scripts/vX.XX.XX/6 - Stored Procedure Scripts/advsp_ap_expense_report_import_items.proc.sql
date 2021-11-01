CREATE PROCEDURE advsp_ap_expense_report_import_items @office_code varchar(4) = NULL, @dp_tm_code varchar(4) = NULL, @user_code varchar(100)

AS

DECLARE @EmployeeCode varchar(6),
		@HasOfficeLimits bit
	
SET @HasOfficeLimits = 0

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@user_code)

IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
	SET @HasOfficeLimits = 1

DECLARE @INV TABLE (
	INV_NBR int NOT NULL,
	[STATUS] int NOT NULL
)

INSERT INTO @INV 
SELECT	H.INV_NBR, 
		H.[STATUS]  
FROM dbo.EXPENSE_HEADER H
	INNER JOIN EMPLOYEE_CLOAK E ON H.EMP_CODE = E.EMP_CODE 
WHERE
	H.[STATUS] IN (1,3,4)
AND	(E.OFFICE_CODE = @office_code OR @office_code IS NULL)
AND	(E.DP_TM_CODE = @dp_tm_code OR @dp_tm_code IS NULL)

DECLARE @EXPENSES TABLE (
	[Status] varchar(50) NULL,
	[IsOnHold] bit NOT NULL,
	[VendorCode] varchar(6) NULL,
	[EmployeeCode] varchar(6) NULL,
	[EmployeeName] varchar(70) NULL,
	[InvoiceNumber] int NOT NULL,
	[InvoiceDescription] varchar(30) NULL,
	[InvoiceDate] datetime NULL,
	[ItemDate] datetime NULL,
	[APComment] varchar(max) NULL,
	[InvoiceTotalNet] decimal(14,2) NULL,
	[OfficeCode] varchar(4) NULL,
	[DepartmentCode] varchar(4) NULL,
	[JobNumber] int NULL,
	[JobComponentNumber] smallint NULL,
	[FunctionCode] varchar(6) NULL,
	[Quantity] int NULL,
	[Rate] decimal(12,4) NULL,
	[Amount] decimal(14,2) NULL,
	[GLACode] varchar(30) NULL,
	[HasDocuments] bit NOT NULL,
	[CanModifyIsOnHold] bit NOT NULL,
	--[FunctionIsRequired] bit NOT NULL,
	[ExpenseReportDetailID] int NOT NULL,
	[IsNonbillable] smallint NULL,
	[CommissionPercent] decimal(9,3) NULL,
	[TaxCommissions] smallint NULL,
	[TaxCommissionsOnly] smallint NULL,
	[SalesTaxCode] varchar(4) NULL,
	[IsSystemGenerated] bit NOT NULL,
	[CreditCardGLAccountIsEmpty] bit NOT NULL,
	LINE_NBR int NOT NULL,
	[ClientName] varchar(40) NULL,
	[CCard] bit NULL,
	[EmployeeOfficeCode] varchar(4) NULL,
	[VendorOfficeCode] varchar(4) NULL,
	[HeaderStatus] int NOT NULL,
    [HasHeaderDocuments] bit NOT NULL
)

INSERT @EXPENSES
SELECT
	[Status] = CASE WHEN COALESCE(H.APPROVED_FLAG, 0) = 0 AND EMP.EMP_CODE IS NOT NULL AND COALESCE(EMP.EXP_APPR_REQ, 0) = 0 THEN ''
					WHEN COALESCE(H.APPROVED_FLAG, 0) = 0 THEN 'Pending Supervisor Approval'
					WHEN COALESCE(H.APPROVED_FLAG, 0) = 1 THEN 'Denied'
					ELSE '' END,
	[IsOnHold] = CAST(CASE WHEN COALESCE(H.APPROVED_FLAG, 0) = 0 AND EMP.EMP_CODE IS NOT NULL AND COALESCE(EMP.EXP_APPR_REQ, 0) = 0 THEN 0 
						   WHEN COALESCE(H.APPROVED_FLAG, 0) = 0 THEN 1
						   WHEN COALESCE(H.APPROVED_FLAG, 0) = 1 THEN 1 
						   ELSE 0 END AS bit),   
	[VendorCode] = H.VN_CODE,
	[EmployeeCode] = H.EMP_CODE,
	[EmployeeName] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
	[InvoiceNumber] = D.INV_NBR,
	[InvoiceDescription] = H.EXP_DESC,
	[InvoiceDate] = H.INV_DATE,
	[ItemDate] = D.ITEM_DATE,
	[APComment] = D.ITEM_DESC,
	[InvoiceTotalNet] = (SELECT SUM(COALESCE(AMOUNT, 0)) FROM dbo.EXPENSE_DETAIL WHERE INV_NBR = D.INV_NBR),
	[OfficeCode] = CASE WHEN JL.JOB_NUMBER IS NOT NULL AND JL.JOB_NUMBER <> 0 THEN JL.OFFICE_CODE
						ELSE GX.GLOXOFFICE END,
	[DepartmentCode] = EMP.DP_TM_CODE,
	[JobNumber] = NULLIF(D.JOB_NBR,0),
	[JobComponentNumber] = NULLIF(D.JOB_COMP_NBR,0),
	[FunctionCode] = D.FNC_CODE,
	[Quantity] = D.QTY,
	[Rate] = D.RATE,
	[Amount] = D.AMOUNT,
	[GLACode] = CASE WHEN O.OFFICE_CODE IS NOT NULL THEN O.PGLACODE_WIP
					 WHEN UPPER(D.ITEM_DESC) = 'SYSTEM GENERATED' AND EMP.EMP_CODE IS NOT NULL AND NULLIF(EMP.CC_GL_ACCOUNT,'') IS NOT NULL THEN EMP.CC_GL_ACCOUNT
					 ELSE NULL END,
	[HasDocuments] = CAST(CASE WHEN (SELECT COUNT(1) FROM dbo.EXPENSE_DETAIL_DOCS WHERE EXPDETAILID = D.EXPDETAILID) > 0 THEN 1 ELSE 0 END AS bit),
	[CanModifyIsOnHold] = CAST(CASE WHEN COALESCE(H.APPROVED_FLAG, 0) = 0 AND EMP.EMP_CODE IS NOT NULL AND COALESCE(EMP.EXP_APPR_REQ, 0) = 0 THEN 1
									WHEN COALESCE(H.APPROVED_FLAG, 0) = 2 THEN 1 
									ELSE 0 END AS bit),
	--[FunctionIsRequired] = CASE WHEN D.FNC_CODE IS NOT NULL THEN 1 ELSE 0 END,
	[ExpenseReportDetailID] = D.EXPDETAILID,
	[IsNonbillable] = CAST(CASE WHEN O.OFFICE_CODE IS NOT NULL THEN 0 ELSE NULL END AS smallint),
	[CommissionPercent] = NULL,
	[TaxCommissions] = NULL,
	[TaxCommissionsOnly] = NULL,
	[SalesTaxCode] = NULL,
	[IsSystemGenerated] = 0,
	[CreditCardGLAccountIsEmpty] = 0,
	D.LINE_NBR,
	[ClientName] = C.CL_NAME,
	[CCard] = CASE WHEN D.PAYMENT_TYPE = 0 THEN 1 ELSE 0 END,
	[EmployeeOfficeCode] = EMP.OFFICE_CODE,
	[VendorOfficeCode] = V.OFFICE_CODE,
	[HeaderStatus] = H.[STATUS],
    [HasHeaderDocuments] = CAST(CASE WHEN (SELECT COUNT(1) FROM dbo.EXPENSE_DOCS WHERE INV_NBR = H.INV_NBR) > 0 THEN 1 ELSE 0 END AS bit)
FROM dbo.EXPENSE_DETAIL D
	INNER JOIN dbo.EXPENSE_HEADER H ON D.INV_NBR = H.INV_NBR 
	INNER JOIN @INV I ON H.INV_NBR = I.INV_NBR 
	LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EMP ON H.EMP_CODE = EMP.EMP_CODE 
	LEFT OUTER JOIN dbo.JOB_LOG JL ON D.JOB_NBR = JL.JOB_NUMBER 
	LEFT OUTER JOIN dbo.OFFICE O ON JL.OFFICE_CODE = O.OFFICE_CODE
	LEFT OUTER JOIN dbo.CLIENT C ON JL.CL_CODE = C.CL_CODE
	LEFT OUTER JOIN dbo.VENDOR V ON H.VN_CODE = V.VN_CODE
	LEFT OUTER JOIN dbo.GLACCOUNT G ON V.GLACODE_AP = GLACODE
	LEFT OUTER JOIN dbo.GLOXREF GX ON GX.GLOXGLOFFICE = G.GLAOFFICE

UPDATE @EXPENSES SET [CommissionPercent] = R.COMM,
					 [TaxCommissions] = R.TAX_COMM,
					 [TaxCommissionsOnly] = R.TAX_COMM_ONLY,
					 [SalesTaxCode] = R.TAX_CODE,
					 [IsNonbillable] = R.NOBILL_FLAG,
					 OfficeCode = R.OFFICE_CODE,
					 GLACode = CASE WHEN COALESCE(R.NOBILL_FLAG,0) = 0 THEN R.PGLACODE_WIP ELSE R.NONBILL_CLI_GLACCT END
FROM @EXPENSES E
	INNER JOIN
	(
	SELECT	E.ExpenseReportDetailID, RATES.NOBILL_FLAG, RATES.COMM, RATES.TAX_COMM, RATES.TAX_COMM_ONLY, RATES.TAX_CODE,
			JL.OFFICE_CODE, O.PGLACODE_WIP, F.NONBILL_CLI_GLACCT 
	FROM @EXPENSES E
		INNER JOIN dbo.JOB_LOG JL ON E.JobNumber = JL.JOB_NUMBER 
		INNER JOIN dbo.OFFICE O ON JL.OFFICE_CODE = O.OFFICE_CODE 
		INNER JOIN dbo.FUNCTIONS F ON E.FunctionCode = F.FNC_CODE 
	CROSS APPLY dbo.advtf_get_billing_rate (NULL , NULL, E.FunctionCode, JL.CL_CODE, JL.DIV_CODE, JL.PRD_CODE, JL.SC_CODE, F.FNC_TYPE, E.JobNumber, E.JobComponentNumber, NULL ) AS RATES
	) AS R ON E.ExpenseReportDetailID = R.ExpenseReportDetailID 


UPDATE @EXPENSES SET GLACode = F.OVERHEAD_GLACCT, OfficeCode = GX.GLOXOFFICE
FROM @EXPENSES E
	INNER JOIN dbo.FUNCTIONS F ON E.FunctionCode = F.FNC_CODE
	INNER JOIN dbo.GLACCOUNT G ON G.GLACODE = F.OVERHEAD_GLACCT
	LEFT OUTER JOIN dbo.GLOXREF GX ON GX.GLOXGLOFFICE = G.GLAOFFICE

WHERE
	E.JobNumber IS NULL


UPDATE @EXPENSES SET IsSystemGenerated = 1, APComment = 'Credit Card Account Offset', 
						[CreditCardGLAccountIsEmpty] = CASE WHEN GLACode IS NULL THEN 1 ELSE 0 END
WHERE
	UPPER(APComment) = 'SYSTEM GENERATED'


SELECT 
		E.*,
		[GLACodeDescription] = G.GLADESC 
FROM	@EXPENSES E
		LEFT OUTER JOIN dbo.GLACCOUNT G ON E.GLACode = G.GLACODE
WHERE
	(
		(@HasOfficeLimits = 1 AND VendorOfficeCode IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
							  AND EmployeeOfficeCode IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
	OR
		(@HasOfficeLimits = 0)
	)
ORDER BY E.EmployeeName, E.InvoiceNumber, E.JobNumber, E.LINE_NBR, E.ItemDate 
GO

