CREATE PROCEDURE [dbo].[advsp_load_drpt_income_only]
	@CRITERIA SMALLINT,
	@FROM_DATE SMALLDATETIME,
	@TO_DATE SMALLDATETIME
AS
BEGIN

/*

CRITERIA
-------------
Invoice Date = 0
Modify/Create Date = 1

*/

	SELECT
		[ID] = NEWID(),
		[OfficeCode] = IncomeOnly.OfficeCode,
		[OfficeName] = IncomeOnly.OfficeName,
		[ClientCode] = IncomeOnly.ClientCode,
		[ClientName] = IncomeOnly.ClientName,
		[DivisionCode] = IncomeOnly.DivisionCode,
		[DivisionName] = IncomeOnly.DivisionName,
		[ProductCode] = IncomeOnly.ProductCode,
		[ProductName] = IncomeOnly.ProductName,
		[CampaignID] = IncomeOnly.CampaignID,
		[CampaignCode] = IncomeOnly.CampaignCode,
		[CampaignName] = IncomeOnly.CampaignName,
		[JobNumber] = IncomeOnly.JobNumber,
		[JobDescription] = IncomeOnly.JobDescription,
		[JobComponentNumber] = IncomeOnly.JobComponentNumber,
		[JobComponentDescription] = IncomeOnly.JobComponentDescription,
		[SalesClassCode] = IncomeOnly.SalesClassCode,
		[SalesClassDescription] = IncomeOnly.SalesClassDescription,
		[ReferenceNumber] = IncomeOnly.ReferenceNumber,
		[InvoiceDate] = IncomeOnly.InvoiceDate,
		[Description] = IncomeOnly.[Description],
		[FunctionCode] = IncomeOnly.FunctionCode,
		[FunctionDescription] = IncomeOnly.FunctionDescription,
		[Quantity] = IncomeOnly.Quantity,
		[Rate] = IncomeOnly.Rate,
		[Amount] = IncomeOnly.Amount,
		[MarkupAmount] = IncomeOnly.MarkupAmount,
		[Total] = IncomeOnly.Total,
		[ResaleTaxAmount] = IncomeOnly.ResaleTaxAmount,
		[TotalWithResaleTax] = IncomeOnly.ResaleTaxAmount + IncomeOnly.Total,
		[Comments] = IncomeOnly.Comments,
		[ARInvoiceNumber] = IncomeOnly.ARInvoiceNumber,
		[ARInvoiceType] = IncomeOnly.ARInvoiceType,
		[ARInvoiceDate] = IncomeOnly.ARInvoiceDate,
		[BillingUserCode] = IncomeOnly.BillingUserCode,
		[GLTransactionBill] = IncomeOnly.GLTransactionBill,
		[GLAccountSales] = IncomeOnly.GLAccountSales,
		[GLAccountSalesDescription] = IncomeOnly.GLAccountSalesDescription,
		[NonBillFlag] = IncomeOnly.NonBillFlag,
		[BillHoldFlag] = IncomeOnly.BillHoldFlag,
		[ModifiedByUserCode] = IncomeOnly.ModifiedByUserCode,
		[ModifiedDate] = IncomeOnly.ModifiedDate
	FROM
		(SELECT
			[OfficeCode] = JOB_LOG.OFFICE_CODE,
			[OfficeName] = OFFICE.OFFICE_NAME,
			[ClientCode] = JOB_LOG.CL_CODE,
			[ClientName] = CLIENT.CL_NAME,
			[DivisionCode] = JOB_LOG.DIV_CODE,
			[DivisionName] = DIVISION.DIV_NAME,
			[ProductCode] = JOB_LOG.PRD_CODE,
			[ProductName] = PRODUCT.PRD_DESCRIPTION,
			[CampaignID] = JOB_LOG.CMP_IDENTIFIER,
			[CampaignCode] = CAMPAIGN.CMP_CODE,
			[CampaignName] = CAMPAIGN.CMP_NAME,
			[JobNumber] = INCOME_ONLY.JOB_NUMBER,
			[JobDescription] = JOB_LOG.JOB_DESC,
			[JobComponentNumber] = INCOME_ONLY.JOB_COMPONENT_NBR,
			[JobComponentDescription] = JOB_COMPONENT.JOB_COMP_DESC,
			[SalesClassCode] = JOB_LOG.SC_CODE,
			[SalesClassDescription] = SALES_CLASS.SC_DESCRIPTION,
			[ReferenceNumber] = INCOME_ONLY.IO_INV_NBR,
			[InvoiceDate] = INCOME_ONLY.IO_INV_DATE,
			[Description] = INCOME_ONLY.IO_DESC,
			[FunctionCode] = INCOME_ONLY.FNC_CODE,
			[FunctionDescription] = FUNCTIONS.FNC_DESCRIPTION,
			[Quantity] = INCOME_ONLY.IO_QTY,
			[Rate] = INCOME_ONLY.IO_RATE,
			[Amount] = INCOME_ONLY.IO_AMOUNT,
			[MarkupAmount] = INCOME_ONLY.EXT_MARKUP_AMT,
			[Total] = ISNULL(INCOME_ONLY.LINE_TOTAL, 0),
			[ResaleTaxAmount] = ISNULL(ISNULL(INCOME_ONLY.EXT_CITY_RESALE, 0) + ISNULL(INCOME_ONLY.EXT_COUNTY_RESALE, 0) + ISNULL(INCOME_ONLY.EXT_STATE_RESALE, 0), 0),
			[Comments] = INCOME_ONLY.IO_COMMENT,
			[ARInvoiceNumber] = INCOME_ONLY.AR_INV_NBR,
			[ARInvoiceType] = INCOME_ONLY.AR_TYPE,
			[ARInvoiceDate] = ACCT_REC.AR_INV_DATE,
			[BillingUserCode] = INCOME_ONLY.BILLING_USER,
			[GLTransactionBill] = INCOME_ONLY.GLEXACT_BILL,
			[GLAccountSales] = INCOME_ONLY.GLACODE_SALES,
			[GLAccountSalesDescription] = GLACCOUNT.GLADESC,
			[NonBillFlag] = CASE WHEN INCOME_ONLY.NON_BILL_FLAG = 1 THEN 'Y' ELSE 'N' END,
			[BillHoldFlag] = CASE WHEN ISNULL(INCOME_ONLY.BILL_HOLD_FLAG, 0) = 0 THEN 'N' ELSE 'Y' END,
			[ModifiedByUserCode] = INCOME_ONLY.MODIFIED_BY,
			[ModifiedDate] = INCOME_ONLY.MODIFY_DATE
		FROM
			dbo.INCOME_ONLY JOIN
			dbo.JOB_LOG ON INCOME_ONLY.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
			dbo.OFFICE ON JOB_LOG.OFFICE_CODE = OFFICE.OFFICE_CODE JOIN
			dbo.CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE JOIN
			dbo.DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND
							JOB_LOG.DIV_CODE = DIVISION.DIV_CODE JOIN
			dbo.PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND
						   JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE  AND
						   JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE LEFT OUTER JOIN
			dbo.CAMPAIGN ON JOB_LOG.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER JOIN
			dbo.JOB_COMPONENT ON INCOME_ONLY.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND
								 INCOME_ONLY.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
			dbo.SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE JOIN
			dbo.FUNCTIONS ON INCOME_ONLY.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
			dbo.ACCT_REC ON INCOME_ONLY.AR_INV_NBR = ACCT_REC.AR_INV_NBR AND
							INCOME_ONLY.AR_TYPE = ACCT_REC.AR_TYPE AND
							INCOME_ONLY.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ LEFT OUTER JOIN
			dbo.GLACCOUNT ON INCOME_ONLY.GLACODE_SALES = GLACCOUNT.GLACODE
		WHERE
			1 = CASE 
					WHEN @CRITERIA = 0 THEN
						CASE 
							WHEN INCOME_ONLY.IO_INV_DATE >= @FROM_DATE AND INCOME_ONLY.IO_INV_DATE <= @TO_DATE THEN 1
							ELSE 0 
						END
					WHEN @CRITERIA = 1 THEN 
						CASE 
							WHEN INCOME_ONLY.MODIFY_DATE >= @FROM_DATE AND INCOME_ONLY.MODIFY_DATE <= @TO_DATE THEN 1 
							ELSE 0 
						END 
					ELSE 0 
				END) IncomeOnly

END