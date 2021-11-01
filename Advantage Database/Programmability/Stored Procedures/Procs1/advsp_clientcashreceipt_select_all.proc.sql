CREATE PROCEDURE advsp_clientcashreceipt_select_all
	@UserCode varchar(100)
AS

BEGIN
	DECLARE @EmployeeCode varchar(6),
			@HasCDPLimits bit

	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@UserCode)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserCode)) > 0
		SET @HasCDPLimits = 1
	ELSE
		SET @HasCDPLimits = 0

	SELECT *
	FROM (
		SELECT
				[ClientCashReceiptID] = CR.REC_ID,
				[ClientCashReceiptSequenceNumber] = CR.SEQ_NBR,
				[ClientCode] = CR.CL_CODE,
				[DivisionCode] = Details.DIV_CODE,
				[ProductCode] = Details.PRD_CODE,
				[OfficeCode] = P.OFFICE_CODE,
				[BankCode] = CR.BK_CODE,
				[ARInvoiceNumber] = Details.AR_INV_NBR,
				[CheckNumber] = CR.CR_CHECK_NBR,
				[PostPeriodCode] = CR.POST_PERIOD,
				[CheckDate] = CR.CR_CHECK_DATE,
				[CheckAmount] = CR.CR_CHECK_AMT,
				[DepositDate] = CR.CR_DEP_DATE,
				[GLACode] = CR.GLACODE,
				[PaymentAmount] = COALESCE(Details.CR_PAY_AMT, 0),
				[WriteoffAmount] = COALESCE(Details.CR_ADJ_AMT, 0)
		FROM dbo.CR_CLIENT CR
			LEFT OUTER JOIN (SELECT	SUM(CR_PAY_AMT) AS CR_PAY_AMT,
									SUM(CR_ADJ_AMT) AS CR_ADJ_AMT,
									REC_ID,
									SEQ_NBR,
									AR_INV_NBR,
									DIV_CODE,
									PRD_CODE
							FROM dbo.CR_CLIENT_DTL 
							GROUP BY
								REC_ID,
								SEQ_NBR,
								AR_INV_NBR,
								DIV_CODE,
								PRD_CODE) Details ON CR.REC_ID = Details.REC_ID AND CR.SEQ_NBR = Details.SEQ_NBR 
			LEFT OUTER JOIN dbo.PRODUCT P ON CR.CL_CODE = P.CL_CODE AND Details.DIV_CODE = P.DIV_CODE AND Details.PRD_CODE = P.PRD_CODE 
		WHERE
				CR.[STATUS] IS NULL OR CR.[STATUS] <> 'D'
		) CCR
	WHERE
		(
		( @HasCDPLimits = 1 AND EXISTS (
										SELECT 1
										FROM dbo.SEC_CLIENT sc
										WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
										AND sc.CL_CODE = CCR.ClientCode
										AND (CCR.DivisionCode IS NULL OR sc.DIV_CODE = CCR.DivisionCode)
										AND (CCR.ProductCode IS NULL OR sc.PRD_CODE = CCR.ProductCode)
										AND (CCR.OfficeCode IS NULL OR (CCR.OfficeCode IS NOT NULL AND CCR.OfficeCode IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
									   ))
		OR
		( @HasCDPLimits = 0 AND (CCR.OfficeCode IS NULL OR (CCR.OfficeCode IS NOT NULL AND CCR.OfficeCode IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))))
		)
	ORDER BY CheckDate DESC

END
GO
