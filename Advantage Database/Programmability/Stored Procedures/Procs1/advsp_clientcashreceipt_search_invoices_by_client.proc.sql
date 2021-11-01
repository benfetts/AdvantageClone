CREATE PROC advsp_clientcashreceipt_search_invoices_by_client
	@UserCode varchar(100)
AS

BEGIN

	DECLARE @EmployeeCode varchar(6),
			@HasCDPLimits bit
	
	SET @HasCDPLimits = 0

	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@UserCode)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserCode)) > 0
		SET @HasCDPLimits = 1

	SELECT	DISTINCT
			[ARInvoiceNumber] = AR.AR_INV_NBR,
			[ClientCode] = AR.CL_CODE,
			[ClientName] = C.CL_NAME,
			[ARInvoiceDate] = AR.AR_INV_DATE
	FROM	dbo.ACCT_REC AR
		INNER JOIN dbo.CLIENT C ON AR.CL_CODE = C.CL_CODE
	WHERE	VOID_FLAG IS NULL
	AND		AR.AR_INV_SEQ != 99
	AND		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = AR.CL_CODE
											AND (AR.DIV_CODE IS NULL OR sc.DIV_CODE = AR.DIV_CODE)
											AND (AR.PRD_CODE IS NULL OR sc.PRD_CODE = AR.PRD_CODE)
											AND (AR.OFFICE_CODE IS NULL OR (AR.OFFICE_CODE IS NOT NULL AND AR.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
										   ))
			OR
			( @HasCDPLimits = 0 AND (AR.OFFICE_CODE IS NULL OR (AR.OFFICE_CODE IS NOT NULL AND AR.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))))
			)
	ORDER BY AR.AR_INV_DATE DESC, AR.AR_INV_NBR DESC
END
