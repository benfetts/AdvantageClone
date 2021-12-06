CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_billing_invoices]
	@UserCode AS varchar(100)
AS
BEGIN
		
	DECLARE @FirstInvoiceNumber AS int, @LastInvoiceNumber AS int

	IF EXISTS(SELECT BILLING_USER FROM [dbo].[BILLING] WHERE BILLING_USER = @UserCode) BEGIN

		SELECT
			@FirstInvoiceNumber = FIRST_INV,
			@LastInvoiceNumber = LAST_INV
		FROM 
			[dbo].[BILLING] 
		WHERE 
			BILLING_USER = @UserCode

		SELECT 
			[InvoiceNumber] = AR.AR_INV_NBR,
			[InvoiceSequenceNumber] = AR.AR_INV_SEQ, 
			[InvoiceDate] = ARID.AR_INV_DATE,
			[InvoiceType] = AR.AR_TYPE,  
			[InvoiceAmount] = ISNULL(AR.AR_INV_AMOUNT, 0),  
			[ClientCode] = AR.CL_CODE,   
			[ClientName] = C.CL_NAME,     
            [DivisionCode] = AR.DIV_CODE,   
            [DivisionName] = D.DIV_NAME,   
            [ProductCode] = AR.PRD_CODE,   
            [ProductName] = P.PRD_DESCRIPTION, 
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), AR.JOB_NUMBER), 6) + CASE WHEN AR.JOB_COMPONENT_NBR IS NOT NULL THEN '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), AR.JOB_COMPONENT_NBR), 3) ELSE '' END,
            [OfficeCode] = AR.OFFICE_CODE,   
			[OfficeName] = O.OFFICE_NAME,
			[RecordType] = AR.REC_TYPE,
			[DueDate] = AR.DUE_DATE,
			[InvoiceCategoryCode] = AR.INV_CAT,
			[InvoiceComment] = CAST(BC.BILL_COMMENT AS varchar(MAX)),  
			[InvoiceContact] = AR.CDP_CONTACT_ID,
			[InvoiceContactName] =  CDPC.CONT_FNAME + ' ' + CDPC.CONT_LNAME,
			[BillingCommentID] = BC.BC_ID,
            [Batch] = NULL,
            [CurrencyCode] = AR.CURRENCY_CODE,
            [CurrencyRate] = AR.CURRENCY_RATE,
            [CurrencyAmount] = ISNULL(AR.AR_INV_AMOUNT, 0) * ISNULL(AR.CURRENCY_RATE, 1),
            [CurrencySymbol] = CC.CURRENCY_SYMBOL,
			[LastAutoEmailDate] = NULL,
			[CampaignCode] = CAMP.CMP_CODE
		FROM 
			[dbo].[ACCT_REC] AS AR INNER JOIN
            (SELECT 
                        AR.AR_INV_NBR, 
                        AR.AR_TYPE, 
                        [AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
                FROM 
                        [dbo].[ACCT_REC] AS AR
                WHERE
					AR.AR_INV_NBR >= @FirstInvoiceNumber AND AR.AR_INV_NBR <= @LastInvoiceNumber AND
					AR.AR_TYPE <> 'VO' 
                GROUP BY 
                        AR.AR_INV_NBR, 
                        AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = AR.AR_INV_NBR AND 
                                                ARID.AR_TYPE = AR.AR_TYPE INNER JOIN
            (SELECT 
                        AR.AR_INV_NBR, 
						AR.AR_INV_SEQ,
                        [LAST_AUTO_EMAIL_DATE] = MAX(AR.LAST_AUTO_EMAIL_DATE) 
                FROM 
                        [dbo].[ACCT_REC] AS AR
                GROUP BY 
                        AR.AR_INV_NBR,
						AR.AR_INV_SEQ) AS ARLAED ON ARLAED.AR_INV_NBR = AR.AR_INV_NBR AND ARLAED.AR_INV_SEQ = AR.AR_INV_SEQ INNER JOIN
            [dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
            [dbo].[DIVISION] AS D ON D.CL_CODE = AR.CL_CODE AND D.DIV_CODE = AR.DIV_CODE LEFT OUTER JOIN
            [dbo].[PRODUCT] AS P ON P.CL_CODE = AR.CL_CODE AND P.DIV_CODE = AR.DIV_CODE AND P.PRD_CODE = AR.PRD_CODE LEFT OUTER JOIN
            [dbo].[OFFICE] AS O ON O.OFFICE_CODE = AR.OFFICE_CODE LEFT OUTER JOIN
            (SELECT 
                        BC.BC_ID,
                        BC.AR_INV_NBR,
                        BC.AR_INV_SEQ,
                        BC.BILL_COMMENT
                FROM 
                        [dbo].[BILL_COMMENT] AS BC
                WHERE 
                        BC.BC_ID = (SELECT MAX(BCM.BC_ID) FROM [dbo].[BILL_COMMENT] AS BCM WHERE BC.AR_INV_NBR = BCM.AR_INV_NBR AND BC.AR_INV_SEQ = BCM.AR_INV_SEQ)) AS BC ON BC.AR_INV_NBR = AR.AR_INV_NBR AND 
                                                                                                                                                                                                                                                                                        BC.AR_INV_SEQ = AR.AR_INV_SEQ LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = AR.CDP_CONTACT_ID LEFT OUTER JOIN 
			(SELECT DISTINCT AR_INV_NBR FROM [dbo].[AR_SUMMARY] WHERE AR_TYPE = 'VO') AS ARSVO ON ARSVO.AR_INV_NBR = AR.AR_INV_NBR LEFT OUTER JOIN
            [dbo].[CURRENCY_CODES] AS CC ON CC.CURRENCY_CODE = AR.CURRENCY_CODE LEFT OUTER JOIN 
			(SELECT 
					AR_INV_NBR,
					AR_INV_SEQ,
					AR_TYPE,
					CMP_CODE
				FROM
					(SELECT 
							AR_INV_NBR,
							AR_INV_SEQ,
							AR_TYPE,
							C.CMP_CODE,
							[RANK] = ROW_NUMBER() OVER(PARTITION BY AR_INV_NBR, AR_INV_SEQ, AR_TYPE 
														ORDER BY AR_INV_NBR DESC)
						FROM 
							dbo.AR_SUMMARY A LEFT OUTER JOIN 
							dbo.CAMPAIGN C ON C.CMP_IDENTIFIER = A.CMP_IDENTIFIER
						WHERE 
							A.CMP_IDENTIFIER IS NOT NULL) AS A
				WHERE 
					A.[RANK] = 1) AS CAMP ON CAMP.AR_INV_NBR = AR.AR_INV_NBR AND CAMP.AR_INV_SEQ = AR.AR_INV_SEQ AND CAMP.AR_TYPE = AR.AR_TYPE
		WHERE 
			(AR.MANUAL_INV IS NULL OR 
			 AR.MANUAL_INV = 0) AND 
			AR.AR_INV_SEQ <> 99 AND
			ARSVO.AR_INV_NBR IS NULL AND
			AR.AR_INV_NBR >= @FirstInvoiceNumber AND AR.AR_INV_NBR <= @LastInvoiceNumber
		GROUP BY 
			AR.AR_INV_NBR,
			AR.AR_INV_SEQ,
			AR.AR_TYPE, 
			ISNULL(AR.AR_INV_AMOUNT, 0), 
			AR.CL_CODE, 
			C.CL_NAME,   
            AR.DIV_CODE, 
            D.DIV_NAME, 
            AR.PRD_CODE, 
            P.PRD_DESCRIPTION,
			AR.JOB_NUMBER,
			AR.JOB_COMPONENT_NBR,
			AR.OFFICE_CODE, 
			O.OFFICE_NAME, 
			ARID.AR_INV_DATE, 
			AR.REC_TYPE,
			AR.DUE_DATE,
			AR.INV_CAT,
			CAST(BC.BILL_COMMENT AS varchar(MAX)),  
			AR.CDP_CONTACT_ID,
			CDPC.CONT_FNAME,
			CDPC.CONT_LNAME,
			BC.BC_ID,
			AR.CURRENCY_CODE,
			AR.CURRENCY_RATE,
			CC.CURRENCY_SYMBOL,
			CAMP.CMP_CODE 
		ORDER BY 1 DESC

	END

END
GO