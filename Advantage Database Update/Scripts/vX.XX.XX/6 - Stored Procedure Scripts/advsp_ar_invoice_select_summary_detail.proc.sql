CREATE PROCEDURE [dbo].[advsp_ar_invoice_select_summary_detail] @ARInvoiceNumber int, @ARSequenceNumber smallint, @ARType varchar(3),
																@ClientCode varchar(6), @DivisionCode varchar(6) = NULL, @ProductCode varchar(6) = NULL,
																@OfficeCode varchar(4) = NULL

AS

BEGIN

	SELECT DISTINCT
		[ARInvoiceNumber] = S.AR_INV_NBR,
		[ARSequenceNumber] = S.AR_INV_SEQ,
		[ARType] = S.AR_TYPE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[JobNumber] = S.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[JobComponentNumber] = S.JOB_COMPONENT_NBR,
		[JobComponentDescription] = JC.JOB_COMP_DESC,
		[FunctionType] = S.FNC_TYPE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[OrderNumber] = S.ORDER_NBR,
		[OrderLineNumber] = S.ORDER_LINE_NBR,
		[SalesTaxCode] = S.TAX_CODE,
		[InvoiceTaxFlag] = S.INV_TAX_FLAG,
		[TotalBill] = COALESCE(S.TOTAL_BILL,0) - (COALESCE(S.STATE_TAX_AMT,0) + COALESCE(S.CITY_TAX_AMT,0) + COALESCE(S.CNTY_TAX_AMT,0)),
		[SalesTax] = COALESCE(S.STATE_TAX_AMT,0) + COALESCE(S.CITY_TAX_AMT,0) + COALESCE(S.CNTY_TAX_AMT,0),
		[TotalWithTax] = S.TOTAL_BILL,
		[DivisionCode] = S.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = S.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[OfficeCode] = S.OFFICE_CODE,
		[OfficeName] = O.OFFICE_NAME,
		[SalesClassCode] = S.SC_CODE,
		[CustomGroup] = 'Division: ' + D.DIV_NAME + ' | Product: ' + P.PRD_DESCRIPTION + ' | Office: ' + O.OFFICE_NAME,
        [OrderDescription] = CAST('' as varchar(40)),
        [MediaType] = S.MEDIA_TYPE
    INTO #qbarinvdtl
	FROM dbo.AR_SUMMARY S LEFT OUTER JOIN
		dbo.SALES_CLASS SC ON S.SC_CODE = SC.SC_CODE LEFT OUTER JOIN
		dbo.FUNCTIONS F ON S.FNC_CODE = F.FNC_CODE LEFT OUTER JOIN
		dbo.JOB_LOG JL ON S.JOB_NUMBER = JL.JOB_NUMBER LEFT OUTER JOIN
		dbo.JOB_COMPONENT JC ON S.JOB_NUMBER = JC.JOB_NUMBER AND S.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR INNER JOIN
		dbo.DIVISION D ON S.CL_CODE = D.CL_CODE AND S.DIV_CODE = D.DIV_CODE INNER JOIN
		dbo.PRODUCT P ON S.CL_CODE = P.CL_CODE AND S.DIV_CODE = P.DIV_CODE AND S.PRD_CODE = P.PRD_CODE INNER JOIN
		dbo.OFFICE O ON S.OFFICE_CODE = O.OFFICE_CODE 
	WHERE
		S.AR_INV_NBR = @ARInvoiceNumber
	AND	S.AR_INV_SEQ = @ARSequenceNumber
	AND S.AR_TYPE = @ARType
	AND S.CL_CODE = @ClientCode
	AND	(@DivisionCode IS NULL OR S.DIV_CODE = @DivisionCode)
	AND	(@ProductCode IS NULL OR S.PRD_CODE = @ProductCode)
	AND	(@OfficeCode IS NULL OR S.OFFICE_CODE = @OfficeCode)

    UPDATE q SET [OrderDescription] = h.ORDER_DESC
    FROM #qbarinvdtl q
        INNER JOIN dbo.INTERNET_HEADER h ON q.[OrderNumber] = h.ORDER_NBR AND q.[MediaType] = 'I'
        
    UPDATE q SET [OrderDescription] = h.ORDER_DESC
    FROM #qbarinvdtl q
        INNER JOIN dbo.MAGAZINE_HEADER h ON q.[OrderNumber] = h.ORDER_NBR AND q.[MediaType] = 'M'

    UPDATE q SET [OrderDescription] = h.ORDER_DESC
    FROM #qbarinvdtl q
        INNER JOIN dbo.NEWSPAPER_HEADER h ON q.[OrderNumber] = h.ORDER_NBR AND q.[MediaType] = 'N'

    UPDATE q SET [OrderDescription] = h.ORDER_DESC
    FROM #qbarinvdtl q
        INNER JOIN dbo.OUTDOOR_HEADER h ON q.[OrderNumber] = h.ORDER_NBR AND q.[MediaType] = 'O'

    UPDATE q SET [OrderDescription] = h.ORDER_DESC
    FROM #qbarinvdtl q
        INNER JOIN dbo.RADIO_HDR h ON q.[OrderNumber] = h.ORDER_NBR AND q.[MediaType] = 'R'

    UPDATE q SET [OrderDescription] = h.ORDER_DESC
    FROM #qbarinvdtl q
        INNER JOIN dbo.TV_HDR h ON q.[OrderNumber] = h.ORDER_NBR AND q.[MediaType] = 'T'

    SELECT * FROM #qbarinvdtl

    DROP TABLE #qbarinvdtl
END
GO
