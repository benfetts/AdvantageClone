CREATE PROCEDURE [dbo].[advsp_ap_expense_import_batch_report] @user_code varchar(100), @batch_date smalldatetime
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE  @AP_HEADER TABLE (
		[AP_ID] [int] NOT NULL,
		[AP_SEQ] [smallint] NOT NULL,
		[VN_FRL_EMP_CODE] [varchar](6) NOT NULL,
		[AP_INV_VCHR] [varchar](20) NOT NULL,
		[AP_DESC] [varchar](30) NULL,
		[AP_INV_DATE] [datetime] NOT NULL,
		[AP_INV_AMT] [decimal](14, 2) NOT NULL,
		[GLACODE] [varchar](30) NOT NULL,
		[POST_PERIOD] [varchar](6) NOT NULL,
		[GLEXACT] [int] NULL
	)

	INSERT INTO @AP_HEADER
	SELECT [AP_ID],
			[AP_SEQ],
			[VN_FRL_EMP_CODE],
			[AP_INV_VCHR],
			[AP_DESC],
			[AP_INV_DATE],
			[AP_INV_AMT],
			[GLACODE],
			[POST_PERIOD],
			[GLEXACT]
	FROM [dbo].AP_HEADER H
	WHERE ISNUMERIC(H.AP_INV_VCHR)=1
	AND H.AP_INV_VCHR NOT LIKE '%.%'
	AND H.AP_INV_VCHR NOT LIKE '%,%'
	AND H.AP_INV_VCHR NOT LIKE '0%'
	AND H.AP_INV_VCHR NOT LIKE '%$%'
	AND LEN(AP_INV_VCHR) <= 10

	SELECT
		[InvoiceNumber] = H.AP_INV_VCHR,
		[InvoiceDescription] = H.AP_DESC,
		[InvoiceDate] = H.AP_INV_DATE,
		[InvoiceAmount] = H.AP_INV_AMT,
		[PostPeriodCode] = H.POST_PERIOD,
		[OfficeCode] = P.OFFICE_CODE,
		[JobNumber] = P.JOB_NUMBER,
		[JobComponentNumber] = P.JOB_COMPONENT_NBR,
		[FunctionCode] = P.FNC_CODE,
		[Amount] = P.AP_PROD_EXT_AMT,
		[GLACode] = P.GLACODE,
		[VendorCode] = H.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[EmployeeCode] = E.EMP_CODE,
		[EmployeeName] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''),
		[EmployeeDepartmentTeamCode] = E.DP_TM_CODE,
		[IsDeletedInvoice] = CAST(0 AS BIT)
	FROM
		@AP_HEADER H
			INNER JOIN [dbo].GLENTHDR G ON H.GLEXACT = G.GLEHXACT 
			INNER JOIN [dbo].AP_PRODUCTION P ON H.AP_ID = P.AP_ID AND H.AP_SEQ = P.AP_SEQ 
			INNER JOIN [dbo].VENDOR V ON H.VN_FRL_EMP_CODE = V.VN_CODE 
			INNER JOIN [dbo].EXPENSE_HEADER EH ON ISNUMERIC(H.AP_INV_VCHR)=1 AND CAST(H.AP_INV_VCHR as float) < 2147483647 AND H.AP_INV_VCHR = EH.INV_NBR 
			INNER JOIN [dbo].EMPLOYEE_CLOAK E ON EH.EMP_CODE = E.EMP_CODE
	WHERE
			G.BATCH_DATE = @batch_date
	AND		G.GLEHSOURCE = 'XR'
	AND		UPPER(G.GLEHUSER) = UPPER(@user_code)
	
	UNION ALL
	
	SELECT
		[InvoiceNumber] = H.AP_INV_VCHR,
		[InvoiceDescription] = H.AP_DESC,
		[InvoiceDate] = H.AP_INV_DATE,
		[InvoiceAmount] = H.AP_INV_AMT,
		[PostPeriodCode] = H.POST_PERIOD,
		[OfficeCode] = D.OFFICE_CODE,
		[JobNumber] = NULL,
		[JobComponentNumber] = NULL,
		[FunctionCode] = NULL,
		[Amount] = D.AP_GL_AMT,
		[GLACode] = D.GLACODE,
		[VendorCode] = H.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[EmployeeCode] = E.EMP_CODE,
		[EmployeeName] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''),
		[EmployeeDepartmentTeamCode] = E.DP_TM_CODE,
		[IsDeletedInvoice] = CAST(0 AS BIT)
	FROM
		@AP_HEADER H
			INNER JOIN [dbo].GLENTHDR G ON H.GLEXACT = G.GLEHXACT 
			INNER JOIN [dbo].AP_GL_DIST D ON H.AP_ID = D.AP_ID AND H.AP_SEQ = D.AP_SEQ 
			INNER JOIN [dbo].VENDOR V ON H.VN_FRL_EMP_CODE = V.VN_CODE 
			INNER JOIN [dbo].EXPENSE_HEADER EH ON ISNUMERIC(H.AP_INV_VCHR)=1 AND CAST(H.AP_INV_VCHR as float) < 2147483647 AND H.AP_INV_VCHR = EH.INV_NBR 
			INNER JOIN [dbo].EMPLOYEE_CLOAK E ON EH.EMP_CODE = E.EMP_CODE
	WHERE
			G.BATCH_DATE = @batch_date
	AND		G.GLEHSOURCE = 'XR'
	AND		UPPER(G.GLEHUSER) = UPPER(@user_code)
	
	UNION ALL
	
	SELECT
		[InvoiceNumber] = CAST(H.INV_NBR AS varchar(20)),
		[InvoiceDescription] = H.EXP_DESC,
		[InvoiceDate] = CAST(H.INV_DATE AS SMALLDATETIME),
		[InvoiceAmount] = D.AMOUNT,
		[PostPeriodCode] = NULL,
		[OfficeCode] = NULL,
		[JobNumber] = D.JOB_NBR,
		[JobComponentNumber] = D.JOB_COMP_NBR,
		[FunctionCode] = D.FNC_CODE,
		[Amount] = D.AMOUNT,
		[GLACode] = NULL,
		[VendorCode] = H.VN_CODE,
		[VendorName] = V.VN_NAME,
		[EmployeeCode] = E.EMP_CODE,
		[EmployeeName] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''),
		[EmployeeDepartmentTeamCode] = E.DP_TM_CODE,
		[IsDeletedInvoice] = CAST(1 AS BIT)
	FROM
		[dbo].EXPENSE_HEADER H
			INNER JOIN [dbo].EXPENSE_DETAIL D ON H.INV_NBR = D.INV_NBR
			INNER JOIN [dbo].VENDOR V ON H.VN_CODE = V.VN_CODE 
			INNER JOIN [dbo].EMPLOYEE_CLOAK E ON H.EMP_CODE = E.EMP_CODE
	WHERE
			H.BATCH_DATE = @batch_date 
	
END

GO
