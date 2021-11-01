CREATE PROCEDURE [dbo].[advsp_invoice_printing_load]
       @UserCode AS varchar(100),
       @StartDate AS smalldatetime,
       @EndDate AS smalldatetime,
       @IncludeProduction AS bit,
       @IncludeMagazine AS bit,
       @IncludeNewspaper AS bit,
       @IncludeInternet AS bit,
       @IncludeOutOfHome AS bit,
       @IncludeRadio AS bit,
       @IncludeTV AS bit,
       @IsDraft AS bit,
       @InvoiceNumber AS int,
       @CombineCoop AS bit
AS
BEGIN
              
       IF @IsDraft = 1 BEGIN
                           
			SELECT 
				[InvoiceNumber] = ARF.AR_INV_NBR,
				[InvoiceSequenceNumber] = ARF.DRAFT_INV_SEQ, 
				[InvoiceDate] = GETDATE(),
				[InvoiceType] = 'IN',  
				[InvoiceAmount] = SUM(ISNULL(ARF.TOTAL_BILL, 0)),  
				[ClientCode] = ARF.CL_CODE,   
				[ClientName] = C.CL_NAME,    
				[DivisionCode] = ARF.DIV_CODE,   
				[DivisionName] = D.DIV_NAME,   
				[ProductCode] = ARF.PRD_CODE,   
				[ProductName] = P.PRD_DESCRIPTION, 
				[JobComponent] = (SELECT TOP 1 RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_NUMBER), 6) FROM dbo.AR_FUNCTION WHERE AR_INV_NBR = ARF.AR_INV_NBR),
				[OfficeCode] = ARF.OFFICE_CODE,   
				[OfficeName] = O.OFFICE_NAME,
				[RecordType] = CASE WHEN ARF.INV_BY > 20 THEN 'C' 
									WHEN ARF.MEDIA_TYPE IS NULL OR ARF.MEDIA_TYPE = 'P' THEN 'P'
									ELSE ARF.MEDIA_TYPE END,
				[DueDate] = NULL,
				[InvoiceCategoryCode] = NULL,
				[InvoiceComment] = NULL,  
				[InvoiceContact] = NULL,
				[InvoiceContactName] =  NULL,
				[BillingCommentID] = NULL,
				[Batch] = ARF.BILLING_USER,
				[CurrencyCode] = ARF.CURRENCY_CODE,
				[CurrencyRate] = ARF.CURRENCY_RATE,
				[CurrencyAmount] = SUM(ISNULL(ARF.TOTAL_BILL, 0) * ISNULL(ARF.CURRENCY_RATE, 1)),
				[CurrencySymbol] = CC.CURRENCY_SYMBOL,
				[LastAutoEmailDate] = NULL,
				[CampaignCode] = CAMP.CMP_CODE
			FROM 
				[dbo].[AR_FUNCTION] AS ARF INNER JOIN
				[dbo].[CLIENT] AS C ON C.CL_CODE = ARF.CL_CODE LEFT OUTER JOIN
				[dbo].[DIVISION] AS D ON D.CL_CODE = ARF.CL_CODE AND D.DIV_CODE = ARF.DIV_CODE LEFT OUTER JOIN
				[dbo].[PRODUCT] AS P ON P.CL_CODE = ARF.CL_CODE AND P.DIV_CODE = ARF.DIV_CODE AND P.PRD_CODE = ARF.PRD_CODE LEFT OUTER JOIN
				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = ARF.OFFICE_CODE LEFT OUTER JOIN
				[dbo].[CURRENCY_CODES] AS CC ON CC.CURRENCY_CODE = ARF.CURRENCY_CODE LEFT OUTER JOIN
				[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = ARF.CMP_IDENTIFIER
			WHERE 
				ARF.BILLING_USER LIKE @UserCode + '%' AND
				1 = CASE WHEN ARF.MEDIA_TYPE IS NULL OR ARF.MEDIA_TYPE = 'P' THEN CASE WHEN @IncludeProduction = 1 THEN 1 ELSE 0 END
						 WHEN ARF.MEDIA_TYPE = 'M' THEN CASE WHEN @IncludeMagazine = 1 THEN 1 ELSE 0 END
						 WHEN ARF.MEDIA_TYPE = 'N' THEN CASE WHEN @IncludeNewspaper = 1 THEN 1 ELSE 0 END
						 WHEN ARF.MEDIA_TYPE = 'I' THEN CASE WHEN @IncludeInternet = 1 THEN 1 ELSE 0 END
						 WHEN ARF.MEDIA_TYPE = 'O' THEN CASE WHEN @IncludeOutOfHome = 1 THEN 1 ELSE 0 END
						 WHEN ARF.MEDIA_TYPE = 'R' THEN CASE WHEN @IncludeRadio = 1 THEN 1 ELSE 0 END
						 WHEN ARF.MEDIA_TYPE = 'T' THEN CASE WHEN @IncludeTV = 1 THEN 1 ELSE 0 END END
			GROUP BY 
				ARF.AR_INV_NBR,
				ARF.DRAFT_INV_SEQ,
				ARF.CL_CODE, 
				C.CL_NAME,  
				ARF.DIV_CODE, 
				D.DIV_NAME, 
				ARF.PRD_CODE, 
				P.PRD_DESCRIPTION,
				--ARF.JOB_NUMBER,
				ARF.OFFICE_CODE, 
				O.OFFICE_NAME,  
				CASE WHEN ARF.INV_BY > 20 THEN 'C' 
				WHEN ARF.MEDIA_TYPE IS NULL OR ARF.MEDIA_TYPE = 'P' THEN 'P'
				ELSE ARF.MEDIA_TYPE END,
				ARF.BILLING_USER,
				ARF.CURRENCY_CODE,
				ARF.CURRENCY_RATE,
				CC.CURRENCY_SYMBOL,
				CAMP.CMP_CODE
			ORDER BY 1 DESC

       END ELSE BEGIN
              
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
				[LastAutoEmailDate] = MAX(ARLAED.LAST_AUTO_EMAIL_DATE),
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
				             1 = CASE WHEN @StartDate IS NULL THEN 1 ELSE CASE WHEN AR.AR_INV_DATE >= @StartDate THEN 1 ELSE 0 END END AND 
				             1 = CASE WHEN @EndDate IS NULL THEN 1 ELSE CASE WHEN AR.AR_INV_DATE <= @EndDate THEN 1 ELSE 0 END END AND 
				             1 = CASE WHEN ISNULL(@InvoiceNumber, 0) = 0 THEN 1 ELSE CASE WHEN AR.AR_INV_NBR = @InvoiceNumber THEN 1 ELSE 0 END END AND
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
				[dbo].[OFFICE] AS O ON O.OFFICE_CODE = AR.OFFICE_CODE  LEFT OUTER JOIN
				[dbo].[CURRENCY_CODES] AS CC ON CC.CURRENCY_CODE = AR.CURRENCY_CODE LEFT OUTER JOIN
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
				(SELECT DISTINCT AR_INV_NBR FROM [dbo].[AR_SUMMARY] WHERE AR_TYPE = 'VO') AS ARSVO ON ARSVO.AR_INV_NBR = AR.AR_INV_NBR  LEFT OUTER JOIN 
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
				1 = CASE WHEN @CombineCoop = 1 THEN CASE WHEN AR.AR_INV_SEQ = 99 OR AR.AR_INV_SEQ = 0 THEN 1 ELSE 0 END 
						  ELSE CASE WHEN AR.AR_INV_SEQ <> 99 THEN 1 ELSE 0 END END AND
				ARSVO.AR_INV_NBR IS NULL AND
				NOT EXISTS (SELECT * 
				                    FROM [dbo].[BILLING] AS B 
				                    WHERE B.BILLING_USER NOT LIKE @UserCode + '%'  AND AR.AR_INV_NBR >= B.FIRST_INV AND AR.AR_INV_NBR <= B.LAST_INV) AND
				1 = CASE WHEN AR.REC_TYPE IS NULL OR AR.REC_TYPE = 'P' THEN CASE WHEN @IncludeProduction = 1 THEN 1 ELSE 0 END
				             WHEN AR.REC_TYPE = 'M' THEN CASE WHEN @IncludeMagazine = 1 THEN 1 ELSE 0 END
				             WHEN AR.REC_TYPE = 'N' THEN CASE WHEN @IncludeNewspaper = 1 THEN 1 ELSE 0 END
				             WHEN AR.REC_TYPE = 'I' THEN CASE WHEN @IncludeInternet = 1 THEN 1 ELSE 0 END
				             WHEN AR.REC_TYPE = 'O' THEN CASE WHEN @IncludeOutOfHome = 1 THEN 1 ELSE 0 END
				             WHEN AR.REC_TYPE = 'R' THEN CASE WHEN @IncludeRadio = 1 THEN 1 ELSE 0 END
				             WHEN AR.REC_TYPE = 'T' THEN CASE WHEN @IncludeTV = 1 THEN 1 ELSE 0 END
				             ELSE 1 END
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