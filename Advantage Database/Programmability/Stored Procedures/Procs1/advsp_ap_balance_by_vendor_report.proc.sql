if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_ap_balance_by_vendor_report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ap_balance_by_vendor_report]
GO

CREATE PROCEDURE [dbo].[advsp_ap_balance_by_vendor_report]
	@post_period_to varchar(6),
	@record_source int
 AS

 BEGIN

 SET NOCOUNT ON;
 
SELECT 
	[ID] = NEWID(),
	[VendorCode],
	[VendorName],
	[VendorAddress1],
	[VendorAddress2],
	[VendorAddress3],
	[VendorCity],
	[VendorCounty],
	[VendorState],
	[VendorZip],
	[VendorCountry],
	[VendorPhone],
	[VendorPhoneExt],
	[VendorFaxNumber],
	[VendorFaxExt],
	[VendorEmail],
	[VendorPayToCode],
	[VendorPayToName],
	[VendorPayToAddress1],
	[VendorPayToAddress2],
	[VendorPayToAddress3],
	[VendorPayToCity],
	[VendorPayToCounty],
	[VendorPayToState],
	[VendorPayToZip],
	[VendorPayToCountry],
	[VendorPayToPhone],
	[VendorPayToPhoneExt],
	[VendorPayToFax],
	[VendorPayToFaxExt],
	[VendorPayToEmail],
	[VendorDefaultCategory],
	[VendorOfficeCode],
	[VendorOfficeName],
	[VendorVCCStatus],
	[VendorBankCode],
	[VendorBankName],
	[VendorSpecialTerms],
	[VendorNotes],
	[VendorServiceTaxCode] ,
	[VendorServiceTaxDescription],
	[EmployeeVendor],
	[SubjectToVST],
	[APGLAccountCode],
	[APGLAccountDescription],
	[InvoiceAmount] = SUM([InvoiceAmount]),
	[TaxAmount] = SUM([TaxAmount]),
	[VendorServiceTaxAmount] = SUM([VendorServiceTaxAmount]),
	[APTotalAmount] = SUM([APTotalAmount]),
	[DisbursedClientTotal] = SUM([DisbursedClientTotal]),
	[DisbursedNonClientTotal] = SUM([DisbursedNonClientTotal]),
	[BalanceDue] = SUM([BalanceDue]),
	[APTotalUnpaid] = SUM([APTotalUnpaid]),
	[AbsoluteAmount] = SUM([APTotalUnpaid]) * CASE WHEN SUM([APTotalUnpaid]) < 0 THEN -1 ELSE 1 END,
	[DebitOrCredit] = CASE WHEN SUM([APTotalUnpaid]) > 0 THEN 'Credit' ELSE 'Debit' END,
	[MappedAccount],
	[TargetAccount]
FROM (
	SELECT
			[VendorCode] = H.VN_FRL_EMP_CODE,
			[VendorName],
			[VendorAddress1],
			[VendorAddress2],
			[VendorAddress3],
			[VendorCity],
			[VendorCounty],
			[VendorState],
			[VendorZip],
			[VendorCountry],
			[VendorPhone],
			[VendorPhoneExt],
			[VendorFaxNumber],
			[VendorFaxExt],
			[VendorEmail],
			[VendorPayToCode],
			[VendorPayToName],
			[VendorPayToAddress1],
			[VendorPayToAddress2],
			[VendorPayToAddress3],
			[VendorPayToCity],
			[VendorPayToCounty],
			[VendorPayToState],
			[VendorPayToZip],
			[VendorPayToCountry],
			[VendorPayToPhone],
			[VendorPayToPhoneExt],
			[VendorPayToFax],
			[VendorPayToFaxExt],
			[VendorPayToEmail],
			[VendorDefaultCategory],
			[VendorOfficeCode],
			[VendorOfficeName],
			[VendorVCCStatus],
			[VendorBankCode],
			[VendorBankName],
			[VendorSpecialTerms],
			[VendorNotes],
			[VendorServiceTaxCode] = VST.CODE,
			[VendorServiceTaxDescription] = VST.[DESCRIPTION],
			[EmployeeVendor] = CASE WHEN EMP_VENDOR = 1 THEN 'Yes' ELSE 'No' END,
			[APGLAccountCode] = H.GLACODE,
			[APGLAccountDescription] = G.GLADESC,
			[MappedAccount] = GLAX.SOURCE_GLACODE,
			[TargetAccount] = GLAEX.TARGET_GLACODE,
			[SubjectToVST] = CASE WHEN ISNULL(H.SERVICE_TAX_ENABLED,0) = 0 THEN 'No' ELSE 'Yes' END,
			[InvoiceAmount] = CAST(COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) AS decimal(16,2)),
			[TaxAmount] = CAST(COALESCE(H.AP_SALES_TAX, 0) AS decimal(16,2)),
			[APTotalAmount] = CAST(COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0) AS decimal(16,2)),
			[DisbursedClientTotal] = CAST(COALESCE(Client.SUM_NET_AMT, 0) AS decimal(16,2)),
			[DisbursedNonClientTotal] = CAST(COALESCE(NonClient.DisbursedNonClientTotal, 0) AS decimal(16,2)),
			[VendorServiceTaxAmount] = COALESCE(Payment.VendorServiceTax, 0),
			[BalanceDue] = CAST(COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0) AS decimal(16,2)) - (COALESCE(Payment.TotalPaid, 0) + COALESCE(Payment.VendorServiceTax, 0) + COALESCE(Payment.DiscountTaken, 0)),
			[APTotalUnpaid] = CAST((COALESCE(H.AP_INV_AMT, 0) + COALESCE(H.AP_SHIPPING, 0) + COALESCE(H.AP_SALES_TAX, 0)) - COALESCE(Payment.TotalPaid, 0) - COALESCE(Payment.DiscountTaken, 0) - COALESCE(Payment.VendorServiceTax, 0) AS decimal(16,2))
	FROM dbo.AP_HEADER H
		LEFT OUTER JOIN dbo.VENDOR_SERVICE_TAX VST ON H.VENDOR_SERVICE_TAX_ID = VST.VENDOR_SERVICE_TAX_ID
		LEFT OUTER JOIN dbo.GLACCOUNT G ON H.GLACODE = G.GLACODE 
		INNER JOIN (
					SELECT
							[VendorName] = V.VN_NAME,
							[VendorAddress1] = V.VN_ADDRESS1,
							[VendorAddress2] = V.VN_ADDRESS2,
							[VendorAddress3] = V.VN_ADDRESS3,
							[VendorCity] = V.VN_CITY,
							[VendorCounty] = V.VN_COUNTY,
							[VendorState] = V.VN_STATE,
							[VendorZip] = V.VN_ZIP,
							[VendorCountry] = V.VN_COUNTRY,
							[VendorPhone] = V.VN_PHONE,
							[VendorPhoneExt] = V.VN_PHONE_EXT,
							[VendorFaxNumber] = V.VN_FAX_NUMBER,
							[VendorFaxExt] = V.VN_FAX_EXTENTION,
							[VendorEmail] = V.VN_EMAIL,
							[VendorDefaultCategory] = V.VN_CATEGORY,
							[VendorOfficeCode] = V.OFFICE_CODE,
							[VendorOfficeName] = O.OFFICE_NAME,
							[VendorPayToCode] = V.VN_PAY_TO_CODE,
							V.VN_CODE,
							[VendorPayToName] = V1.VN_PAY_TO_NAME,
							[VendorPayToAddress1] = V1.VN_PAY_TO_ADDRESS1,
							[VendorPayToAddress2] = V1.VN_PAY_TO_ADDRESS2,
							[VendorPayToAddress3] = V1.VN_PAY_TO_ADDRESS3,
							[VendorPayToCity] = V1.VN_PAY_TO_CITY,
							[VendorPayToCounty] = V1.VN_PAY_TO_COUNTY,
							[VendorPayToState] = V1.VN_PAY_TO_STATE,
							[VendorPayToZip] = V1.VN_PAY_TO_ZIP,
							[VendorPayToCountry] = V1.VN_PAY_TO_COUNTRY,
							[VendorPayToPhone] = V1.VN_PAY_TO_PHONE,
							[VendorPayToPhoneExt] = V1.VN_PAY_TO_EXT,
							[VendorPayToFax] = V1.VN_PAY_TO_FAX_NBR,
							[VendorPayToFaxExt] = V1.VN_PAY_TO_FAX_EXT,
							[VendorPayToEmail] = V1.VN_PAY_TO_EMAIL,
							EMP_VENDOR = COALESCE(V.EMP_VENDOR, 0),
							[VendorVCCStatus] = CASE WHEN ISNULL(V.VCC_STATUS, 0) = 0 THEN 'Open'
													 WHEN V.VCC_STATUS = 1 THEN 'Accepted'
													 WHEN V.VCC_STATUS = 2 THEN 'Declined'
												END,
							[VendorBankCode] = V.BK_CODE,
							[VendorBankName] = B.BK_DESCRIPTION,
							[VendorSpecialTerms] = CASE WHEN V.HAS_SPECIAL_TERMS = 1 THEN 'Y' ELSE 'N' END,
							[VendorNotes] = CONVERT(VARCHAR(MAX), V.VN_NOTES)
					FROM dbo.VENDOR V
						LEFT OUTER JOIN dbo.OFFICE O ON V.OFFICE_CODE = O.OFFICE_CODE
						LEFT OUTER JOIN dbo.VENDOR V1 ON V.VN_PAY_TO_CODE = V1.VN_CODE  
						LEFT OUTER JOIN dbo.BANK B ON V.BK_CODE = B.BK_CODE
					) V ON H.VN_FRL_EMP_CODE = V.VN_CODE  
		LEFT OUTER JOIN (
						SELECT [DisbursedNonClientTotal] = SUM(AP_GL_AMT), AP_ID
						FROM dbo.AP_GL_DIST
						GROUP BY AP_ID
						) NonClient ON NonClient.AP_ID = H.AP_ID 
		LEFT OUTER JOIN (
						SELECT	[TotalPaid] = SUM(COALESCE(AP_CHK_AMT, 0)),
							    [VendorServiceTax] = SUM(COALESCE(VENDOR_SERVICE_TAX,0)),
								[DiscountTaken] = SUM(COALESCE(AP_DISC_AMT, 0)),
								AP_ID
						FROM dbo.AP_PMT_HIST
					    WHERE AP_PMT_HIST.POST_PERIOD <= @post_period_to 		
						GROUP BY AP_ID
						) Payment ON Payment.AP_ID = H.AP_ID 
		LEFT OUTER JOIN (
						SELECT SUM(NET) AS SUM_NET_AMT, AP_ID
						FROM (
								SELECT SUM(COALESCE(NET_AMT, 0) + COALESCE(DISCOUNT_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, AP_ID
								FROM dbo.AP_INTERNET
								GROUP BY AP_ID UNION ALL

								SELECT SUM(COALESCE(DISBURSED_AMT, 0)) AS NET, AP_ID
								FROM dbo.AP_MAGAZINE 
								GROUP BY AP_ID UNION ALL

								SELECT SUM(COALESCE(DISBURSED_AMT, 0)) AS NET, AP_ID
								FROM dbo.AP_NEWSPAPER
								GROUP BY AP_ID UNION ALL

								SELECT SUM(COALESCE(NET_AMT, 0) + COALESCE(DISCOUNT_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, AP_ID
								FROM dbo.AP_OUTDOOR
								GROUP BY AP_ID UNION ALL

								SELECT SUM(COALESCE(EXT_NET_AMT, 0) + COALESCE(DISC_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, AP_ID
								FROM dbo.AP_RADIO
								GROUP BY AP_ID UNION ALL

								SELECT SUM(COALESCE(EXT_NET_AMT, 0) + COALESCE(DISC_AMT, 0) + COALESCE(NETCHARGES, 0) + COALESCE(VENDOR_TAX, 0)) AS NET, AP_ID
								FROM dbo.AP_TV
								GROUP BY AP_ID UNION ALL

								SELECT SUM(COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0)) AS NET, AP_ID
								FROM dbo.AP_PRODUCTION APP
								GROUP BY AP_ID
							) ClientTotal
						GROUP BY AP_ID
						) Client ON Client.AP_ID = H.AP_ID
		LEFT OUTER JOIN
			(SELECT 
				GLACODE,
				SOURCE_GLACODE
			 FROM 
				[dbo].[GLACCOUNT_XREF] 
			 WHERE
				GLACCOUNT_XREF_ID IN (SELECT MAX(GLACCOUNT_XREF_ID) FROM [dbo].[GLACCOUNT_XREF] WHERE RECORD_SOURCE_ID = @record_source GROUP BY GLACODE)) AS GLAX ON GLAX.GLACODE = H.GLACODE
		LEFT OUTER JOIN
			(SELECT 
				DTL.GLACODE,
				HDR.TARGET_GLACODE
			 FROM 
				[dbo].[GLACCOUNT_XREF_EXPORT] HDR
			 INNER JOIN	
				[dbo].[GLACCOUNT_XREF_EXPORT_DETAIL] DTL ON HDR.GLACCOUNT_XREF_EXPORT_ID = DTL.GLACCOUNT_XREF_EXPORT_ID  
			 WHERE
				RECORD_SOURCE_ID = @record_source) AS GLAEX ON GLAEX.GLACODE = H.GLACODE
	WHERE
		H.MODIFY_FLAG IS NULL
		AND	H.POST_PERIOD <= @post_period_to
) Results
GROUP BY
	[VendorCode],
	[VendorName],
	[VendorAddress1],
	[VendorAddress2],
	[VendorAddress3],
	[VendorCity],
	[VendorCounty],
	[VendorState],
	[VendorZip],
	[VendorCountry],
	[VendorPhone],
	[VendorPhoneExt],
	[VendorFaxNumber],
	[VendorFaxExt],
	[VendorEmail],
	[VendorPayToCode],
	[VendorPayToName],
	[VendorPayToAddress1],
	[VendorPayToAddress2],
	[VendorPayToAddress3],
	[VendorPayToCity],
	[VendorPayToCounty],
	[VendorPayToState],
	[VendorPayToZip],
	[VendorPayToCountry],
	[VendorPayToPhone],
	[VendorPayToPhoneExt],
	[VendorPayToFax],
	[VendorPayToFaxExt],
	[VendorPayToEmail],
	[VendorDefaultCategory],
	[VendorOfficeCode],
	[VendorOfficeName],
	[VendorVCCStatus],
	[VendorBankCode],
	[VendorBankName],
	[VendorSpecialTerms],
	[VendorNotes],
	[VendorServiceTaxCode] ,
	[VendorServiceTaxDescription],
	[EmployeeVendor],
	[SubjectToVST],
	[APGLAccountCode],
	[APGLAccountDescription],
	[MappedAccount],
	[TargetAccount]
HAVING 
	SUM([APTotalUnpaid]) <> 0

END