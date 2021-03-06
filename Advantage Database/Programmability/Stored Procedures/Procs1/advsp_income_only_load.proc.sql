CREATE PROCEDURE [dbo].[advsp_income_only_load]	
	@CL_CODE VARCHAR(6) = NULL,
	@DIV_CODE VARCHAR(6) = NULL,
	@PRD_CODE VARCHAR(6) = NULL,
	@JOB_NUMBER INT = 0,
	@JOB_COMP_NBR INT = 0,
	@SHOW_DELETED BIT = 0,
	@ID_LIST VARCHAR(MAX) = NULL,
	@USER_ID VARCHAR(100)
AS
BEGIN

	SELECT  
		[ID] = INCOME_ONLY.IO_ID,
		[SequenceNumber] = INCOME_ONLY.SEQ_NBR,
		[ClientCode] = JOB_LOG.CL_CODE,
		[ClientName] = CLIENT.CL_NAME,
		[DivisionCode] = JOB_LOG.DIV_CODE,
		[DivisionName] = DIVISION.DIV_NAME,
		[ProductCode] = JOB_LOG.PRD_CODE,
		[ProductName] = PRODUCT.PRD_DESCRIPTION,
		[JobNumber] = INCOME_ONLY.JOB_NUMBER,
		[JobDescription] = JOB_LOG.JOB_DESC,
		[JobComponentNumber] = INCOME_ONLY.JOB_COMPONENT_NBR,
		[JobComponentID] = JOB_COMPONENT.ROWID,
		[JobComponentDescription] = JOB_COMPONENT.JOB_COMP_DESC,
		[MediaType] = MO.MediaType,
		[OrderNumber] = MO.OrderNumber,
		[OrderDescription] = MO.[Description],
		[OrderLineNumber] = MO.LineNumber,
		[FunctionCode] = INCOME_ONLY.FNC_CODE,
		[FunctionDescription] = FUNCTIONS.FNC_DESCRIPTION,
		[InvoiceDate] = INCOME_ONLY.IO_INV_DATE,
		[Quantity] = INCOME_ONLY.IO_QTY,
		[Rate] = INCOME_ONLY.IO_RATE,
		[Amount] = INCOME_ONLY.IO_AMOUNT,
		[CommissionPercent] = INCOME_ONLY.IO_COMM_PCT,
		[MarkupAmount] = INCOME_ONLY.EXT_MARKUP_AMT,
		[LineTotal] = INCOME_ONLY.LINE_TOTAL,
		[Description] = INCOME_ONLY.IO_DESC,
		[ReferenceNumber] = INCOME_ONLY.IO_INV_NBR,
		[Comment] = INCOME_ONLY.IO_COMMENT,
		[BillingUser] = INCOME_ONLY.BILLING_USER,
		[TaxCode] = INCOME_ONLY.TAX_CODE, 
		[TaxStatePercent] = INCOME_ONLY.TAX_STATE_PCT, 
		[TaxCountyPercent] = INCOME_ONLY.TAX_COUNTY_PCT, 
		[TaxCityPercent] = INCOME_ONLY.TAX_CITY_PCT,
		[TaxCommission] = INCOME_ONLY.TAX_COMM, 
		[TaxCommissionOnly] = INCOME_ONLY.TAX_COMM_ONLY,
		[CityTaxAmount] = INCOME_ONLY.EXT_CITY_RESALE,
		[CountyTaxAmount] = INCOME_ONLY.EXT_COUNTY_RESALE,
		[StateTaxAmount] = INCOME_ONLY.EXT_STATE_RESALE,
		[TaxResale] = INCOME_ONLY.TAX_RESALE,
		[IsServiceFee] = CONVERT(BIT, ISNULL(INCOME_ONLY.FEE_INVOICE, 0)),
		[IsBilled] = CONVERT(BIT, CASE WHEN INCOME_ONLY.AR_INV_NBR IS NULL THEN 0 ELSE 1 END),
		[NonBillable] = CONVERT(BIT, ISNULL(INCOME_ONLY.NON_BILL_FLAG, 0)),
		[SalesClassCode] = JOB_LOG.SC_CODE,
		[DepartmentTeamCode] = INCOME_ONLY.DP_TM_CODE,
		[IsDeleted] = CONVERT(BIT, ISNULL(INCOME_ONLY.DELETE_FLAG, 0)),
		[JobServiceFeeID] = INCOME_ONLY.JOB_SERVICE_FEE_ID,
		[EverBilled] = CONVERT(BIT, CASE WHEN BILLED_INCOME_ONLY.IO_ID IS NOT NULL THEN 1 ELSE 0 END)
	FROM
		dbo.INCOME_ONLY JOIN
		(SELECT
 			INCOME_ONLY.IO_ID,
 			INCOME_ONLY.SEQ_NBR
		 FROM
 			dbo.INCOME_ONLY
		 WHERE
 			ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0 AND
 			ISNULL(INCOME_ONLY.MODIFY_FLAG, 0) = 0
		 UNION
		 SELECT
 			INCOME_ONLY.IO_ID,
 			INCOME_ONLY.SEQ_NBR
		 FROM
 			dbo.INCOME_ONLY JOIN
 			(SELECT
  				[IO_ID] = INCOME_ONLY.IO_ID,
  				[SEQ_NBR] = MAX(INCOME_ONLY.SEQ_NBR)
 			 FROM
  			 	dbo.INCOME_ONLY
 			 GROUP BY
  			 	INCOME_ONLY.IO_ID) IO_MAX ON INCOME_ONLY.IO_ID = IO_MAX.IO_ID AND
 											 INCOME_ONLY.SEQ_NBR = IO_MAX.SEQ_NBR
		WHERE
 			ISNULL(INCOME_ONLY.MODIFY_FLAG, 0) = 1 AND
 			ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0) IO_CURRENT ON INCOME_ONLY.IO_ID = IO_CURRENT.IO_ID AND
																  INCOME_ONLY.SEQ_NBR = IO_CURRENT.SEQ_NBR LEFT OUTER JOIN
		(SELECT
			INCOME_ONLY.IO_ID
		 FROM
		 	dbo.INCOME_ONLY
		 WHERE 
		 	INCOME_ONLY.AR_INV_NBR IS NOT NULL
		 GROUP BY
			INCOME_ONLY.IO_ID) BILLED_INCOME_ONLY ON INCOME_ONLY.IO_ID = BILLED_INCOME_ONLY.IO_ID JOIN
		dbo.JOB_COMPONENT ON INCOME_ONLY.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND
							 INCOME_ONLY.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR JOIN
		dbo.JOB_LOG ON INCOME_ONLY.JOB_NUMBER = JOB_LOG.JOB_NUMBER JOIN
		dbo.CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE JOIN
		dbo.DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND
						JOB_LOG.DIV_CODE = DIVISION.DIV_CODE JOIN
		dbo.PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND
					   JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND
					   JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE JOIN
		dbo.FUNCTIONS ON INCOME_ONLY.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
		(SELECT 
				[MediaType] = 'M',
				[VendorCode] = H.VN_CODE,
				[ClientCode] = H.CL_CODE,
				[DivisionCode] = H.DIV_CODE,
				[ProductCode] = H.PRD_CODE,
				[OrderNumber] = H.ORDER_NBR,
				[LineNumber] = D.LINE_NBR,
				[Description] = H.ORDER_DESC,
				[LinkID] = H.LINK_ID,
				[ClientPO] = H.CLIENT_PO
			FROM
				[dbo].[MAGAZINE_HEADER] H INNER JOIN 
				[dbo].[MAGAZINE_DETAIL] D ON H.ORDER_NBR = D.ORDER_NBR
			WHERE	
				H.MEDIA_TYPE IS NOT NULL AND		
				COALESCE(H.[STATUS], 0) = 0 AND   	
				H.ORD_PROCESS_CONTRL NOT IN (5,6,12) AND 
				D.ACTIVE_REV = 1 AND  	
				(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0) AND		
				BILL_TYPE_FLAG <> 1 AND
				(ISNULL(@CL_CODE, '') = '' OR H.CL_CODE = @CL_CODE) AND
				(ISNULL(@DIV_CODE, '') = '' OR H.DIV_CODE = @DIV_CODE) AND
				(ISNULL(@PRD_CODE, '') = '' OR H.PRD_CODE = @PRD_CODE) AND
				(ISNULL(@JOB_NUMBER, 0) = 0 OR D.JOB_NUMBER = @JOB_NUMBER) AND
				(ISNULL(@JOB_COMP_NBR, 0) = 0 OR D.JOB_COMPONENT_NBR = @JOB_COMP_NBR)
		
			UNION ALL
	
			SELECT 
				[MediaType] = 'N',
				[VendorCode] = H.VN_CODE,
				[ClientCode] = H.CL_CODE,
				[DivisionCode] = H.DIV_CODE,
				[ProductCode] = H.PRD_CODE,
				[OrderNumber] = H.ORDER_NBR,
				[LineNumber] = D.LINE_NBR,
				[Description] = H.ORDER_DESC,
				[LinkID] = H.LINK_ID,
				[ClientPO] = H.CLIENT_PO
			FROM
				[dbo].[NEWSPAPER_HEADER] H INNER JOIN 
				[dbo].[NEWSPAPER_DETAIL] D ON H.ORDER_NBR = D.ORDER_NBR
			WHERE	
				H.MEDIA_TYPE IS NOT NULL AND		
				COALESCE(H.[STATUS], 0) = 0 AND   	
				H.ORD_PROCESS_CONTRL NOT IN (5,6,12) AND 
				D.ACTIVE_REV = 1 AND  	
				(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0) AND		
				BILL_TYPE_FLAG <> 1 AND
				(ISNULL(@CL_CODE, '') = '' OR H.CL_CODE = @CL_CODE) AND
				(ISNULL(@DIV_CODE, '') = '' OR H.DIV_CODE = @DIV_CODE) AND
				(ISNULL(@PRD_CODE, '') = '' OR H.PRD_CODE = @PRD_CODE) AND
				(ISNULL(@JOB_NUMBER, 0) = 0 OR D.JOB_NUMBER = @JOB_NUMBER) AND
				(ISNULL(@JOB_COMP_NBR, 0) = 0 OR D.JOB_COMPONENT_NBR = @JOB_COMP_NBR)
		
			UNION ALL
	
			SELECT 
				[MediaType] = 'I',
				[VendorCode] = H.VN_CODE,
				[ClientCode] = H.CL_CODE,
				[DivisionCode] = H.DIV_CODE,
				[ProductCode] = H.PRD_CODE,
				[OrderNumber] = H.ORDER_NBR,
				[LineNumber] = D.LINE_NBR,
				[Description] = H.ORDER_DESC,
				[LinkID] = H.LINK_ID,
				[ClientPO] = H.CLIENT_PO
			FROM
				[dbo].[INTERNET_HEADER] H INNER JOIN 
				[dbo].[INTERNET_DETAIL] D ON H.ORDER_NBR = D.ORDER_NBR
			WHERE	
				H.MEDIA_TYPE IS NOT NULL AND		
				COALESCE(H.[STATUS], 0) = 0 AND   	
				H.ORD_PROCESS_CONTRL NOT IN (5,6,12) AND 
				D.ACTIVE_REV = 1 AND  	
				(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0) AND		
				BILL_TYPE_FLAG <> 1 AND
				(ISNULL(@CL_CODE, '') = '' OR H.CL_CODE = @CL_CODE) AND
				(ISNULL(@DIV_CODE, '') = '' OR H.DIV_CODE = @DIV_CODE) AND
				(ISNULL(@PRD_CODE, '') = '' OR H.PRD_CODE = @PRD_CODE) AND
				(ISNULL(@JOB_NUMBER, 0) = 0 OR D.JOB_NUMBER = @JOB_NUMBER) AND
				(ISNULL(@JOB_COMP_NBR, 0) = 0 OR D.JOB_COMPONENT_NBR = @JOB_COMP_NBR)
		
			UNION ALL
	
			SELECT 
				[MediaType] = 'O',
				[VendorCode] = H.VN_CODE,
				[ClientCode] = H.CL_CODE,
				[DivisionCode] = H.DIV_CODE,
				[ProductCode] = H.PRD_CODE,
				[OrderNumber] = H.ORDER_NBR,
				[LineNumber] = D.LINE_NBR,
				[Description] = H.ORDER_DESC,
				[LinkID] = H.LINK_ID,
				[ClientPO] = H.CLIENT_PO
			FROM
				[dbo].[OUTDOOR_HEADER] H INNER JOIN 
				[dbo].[OUTDOOR_DETAIL] D ON H.ORDER_NBR = D.ORDER_NBR
			WHERE	
				H.MEDIA_TYPE IS NOT NULL AND		
				COALESCE(H.[STATUS], 0) = 0 AND   	
				H.ORD_PROCESS_CONTRL NOT IN (5,6,12) AND 
				D.ACTIVE_REV = 1 AND  	
				(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0) AND		
				BILL_TYPE_FLAG <> 1 AND
				(ISNULL(@CL_CODE, '') = '' OR H.CL_CODE = @CL_CODE) AND
				(ISNULL(@DIV_CODE, '') = '' OR H.DIV_CODE = @DIV_CODE) AND
				(ISNULL(@PRD_CODE, '') = '' OR H.PRD_CODE = @PRD_CODE) AND
				(ISNULL(@JOB_NUMBER, 0) = 0 OR D.JOB_NUMBER = @JOB_NUMBER) AND
				(ISNULL(@JOB_COMP_NBR, 0) = 0 OR D.JOB_COMPONENT_NBR = @JOB_COMP_NBR)

			UNION ALL
	
			SELECT 
				[MediaType] = 'R',
				[VendorCode] = H.VN_CODE,
				[ClientCode] = H.CL_CODE,
				[DivisionCode] = H.DIV_CODE,
				[ProductCode] = H.PRD_CODE,
				[OrderNumber] = H.ORDER_NBR,
				[LineNumber] = D.LINE_NBR,
				[Description] = H.ORDER_DESC,
				[LinkID] = H.LINK_ID,
				[ClientPO] = H.CLIENT_PO
			FROM
				[dbo].[RADIO_HDR] H INNER JOIN 
				[dbo].[RADIO_DETAIL] D ON H.ORDER_NBR = D.ORDER_NBR
			WHERE	
				H.MEDIA_TYPE IS NOT NULL AND		
				COALESCE(H.[STATUS], 0) = 0 AND   	
				H.ORD_PROCESS_CONTRL NOT IN (5,6,12) AND 
				D.ACTIVE_REV = 1 AND  	
				(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0) AND		
				BILL_TYPE_FLAG <> 1 AND
				(ISNULL(@CL_CODE, '') = '' OR H.CL_CODE = @CL_CODE) AND
				(ISNULL(@DIV_CODE, '') = '' OR H.DIV_CODE = @DIV_CODE) AND
				(ISNULL(@PRD_CODE, '') = '' OR H.PRD_CODE = @PRD_CODE) AND
				(ISNULL(@JOB_NUMBER, 0) = 0 OR D.JOB_NUMBER = @JOB_NUMBER) AND
				(ISNULL(@JOB_COMP_NBR, 0) = 0 OR D.JOB_COMPONENT_NBR = @JOB_COMP_NBR)

			UNION ALL
	
			SELECT 
				[MediaType] = 'T',
				[VendorCode] = H.VN_CODE,
				[ClientCode] = H.CL_CODE,
				[DivisionCode] = H.DIV_CODE,
				[ProductCode] = H.PRD_CODE,
				[OrderNumber] = H.ORDER_NBR,
				[LineNumber] = D.LINE_NBR,
				[Description] = H.ORDER_DESC,
				[LinkID] = H.LINK_ID,
				[ClientPO] = H.CLIENT_PO
			FROM
				[dbo].[TV_HDR] H INNER JOIN 
				[dbo].[TV_DETAIL] D ON H.ORDER_NBR = D.ORDER_NBR
			WHERE	
				H.MEDIA_TYPE IS NOT NULL AND		
				COALESCE(H.[STATUS], 0) = 0 AND   	
				H.ORD_PROCESS_CONTRL NOT IN (5,6,12) AND 
				D.ACTIVE_REV = 1 AND  	
				(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0) AND		
				BILL_TYPE_FLAG <> 1 AND
				(ISNULL(@CL_CODE, '') = '' OR H.CL_CODE = @CL_CODE) AND
				(ISNULL(@DIV_CODE, '') = '' OR H.DIV_CODE = @DIV_CODE) AND
				(ISNULL(@PRD_CODE, '') = '' OR H.PRD_CODE = @PRD_CODE) AND
				(ISNULL(@JOB_NUMBER, 0) = 0 OR D.JOB_NUMBER = @JOB_NUMBER) AND
				(ISNULL(@JOB_COMP_NBR, 0) = 0 OR D.JOB_COMPONENT_NBR = @JOB_COMP_NBR)) AS MO ON MO.OrderNumber = INCOME_ONLY.ORDER_NBR AND
							   MO.LineNumber = INCOME_ONLY.LINE_NBR INNER JOIN
		dbo.advtf_user_job_limits(@USER_ID) JSEC ON JOB_LOG.JOB_NUMBER = JSEC.JOB_NUMBER
	WHERE 
		JOB_COMPONENT.JOB_PROCESS_CONTRL IN (1, 8, 9, 10, 11) AND
		1 = CASE WHEN @CL_CODE IS NULL OR @CL_CODE = '' THEN 1 WHEN JOB_LOG.CL_CODE = @CL_CODE THEN 1 ELSE 0 END AND
		1 = CASE WHEN @DIV_CODE IS NULL OR @DIV_CODE = '' THEN 1 WHEN JOB_LOG.DIV_CODE = @DIV_CODE THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRD_CODE IS NULL OR @PRD_CODE = '' THEN 1 WHEN JOB_LOG.PRD_CODE = @PRD_CODE THEN 1 ELSE 0 END AND
		1 = CASE WHEN ISNULL(@JOB_NUMBER, 0) = 0 THEN 1 WHEN INCOME_ONLY.JOB_NUMBER = @JOB_NUMBER THEN 1 ELSE 0 END AND
		1 = CASE WHEN ISNULL(@JOB_NUMBER, 0) = 0 OR ISNULL(@JOB_COMP_NBR, 0) = 0 THEN 1 WHEN INCOME_ONLY.JOB_NUMBER = @JOB_NUMBER AND INCOME_ONLY.JOB_COMPONENT_NBR = @JOB_COMP_NBR THEN 1 ELSE 0 END AND
		1 = CASE WHEN @SHOW_DELETED = 1 THEN 1 WHEN ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0 THEN 1 ELSE 0 END AND
		1 = CASE WHEN @ID_LIST IS NULL THEN 1 WHEN INCOME_ONLY.IO_ID IN (SELECT * FROM dbo.udf_split_list(@ID_LIST, ',')) THEN 1 ELSE 0 END
	ORDER BY 
		INCOME_ONLY.JOB_NUMBER DESC,
		INCOME_ONLY.JOB_COMPONENT_NBR ASC

END
GO


