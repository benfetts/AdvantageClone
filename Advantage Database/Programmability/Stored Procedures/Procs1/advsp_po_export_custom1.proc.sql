CREATE PROCEDURE [dbo].[advsp_po_export_custom1]

	@CREATE_DATE_START smalldatetime,
	@CREATE_DATE_END smalldatetime

AS

BEGIN

	SET NOCOUNT ON
	
	SELECT
		[PONumber] = po.PO_NUMBER,
		[Date] = po.PO_CREATE_DATE,
		[VendorID] = v.VN_PAY_TO_NAME,
		[Name] = v.VN_NAME,
		[LineNumber] = pod.LINE_NUMBER,
		[VendorItem] = jt.JT_DESC,
		[QuantityOrdered] = pod.PO_QTY,
		[UnitCost] = pod.PO_RATE,
		[VendorDescription] = pod.LINE_DESC,
		[SiteID] = jc.UDV2_CODE,
		[ExtendedCost] = pod.PO_EXT_AMOUNT,
		[Company] = jlu1.UDV_DESC,
		[PurchasesAccount] = pod.FNC_CODE + '-' + jl.CL_CODE + '-' + jl.DIV_CODE,
		[RequiredDate] = po.PO_DUE_DATE,
		[CurrentPromisedDate] = po.PO_DUE_DATE,
		[PromisedShipDate] = po.PO_DUE_DATE,
		[RequestedBy] = po.EMP_CODE,
		[ShippingMethod] = jcu1.UDV_DESC
	FROM dbo.PURCHASE_ORDER po
		LEFT OUTER JOIN dbo.VENDOR v ON po.VN_CODE = v.VN_CODE
		INNER JOIN dbo.PURCHASE_ORDER_DET pod ON po.PO_NUMBER = pod.PO_NUMBER 
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON pod.JOB_NUMBER = jc.JOB_NUMBER AND pod.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN dbo.JOB_CMP_UDV1 jcu1 ON jc.UDV1_CODE = jcu1.UDV_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG jl ON pod.JOB_NUMBER = jl.JOB_NUMBER 
		LEFT OUTER JOIN dbo.JOB_LOG_UDV1 jlu1 ON jl.UDV1_CODE = jlu1.UDV_CODE 
		LEFT OUTER JOIN dbo.JOB_TYPE jt ON jc.JT_CODE = jt.JT_CODE 
	WHERE
		po.PO_CREATE_DATE BETWEEN @CREATE_DATE_START AND @CREATE_DATE_END

END

GO