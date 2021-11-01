CREATE PROCEDURE [dbo].[advsp_broadcast_audit_export_invoice]  ( 	
	@start_date     smalldatetime,
	@end_date       smalldatetime,
	@cl_code_list   varchar(max)
	)
AS
BEGIN
SET NOCOUNT ON;

SELECT
	[MEDIA] = 'TV',
	[CLIENT] = orders.CL_CODE,
	--[ClientName] = c.CL_NAME,
	--[DivisionCode] = orders.DIV_CODE,
	--[DivisionName] = d.DIV_NAME,
	[PRODUCT] = orders.PRD_CODE,
	--[ProductName] = p.PRD_DESCRIPTION,
	[EST] = MBWMDD.ORDER_NBR,
	[ESTIMATE] = orders.ORDER_DESC,
	--[MarketCode] = orders.MARKET_CODE,
	[MARKET] = m.MARKET_DESC,
	--[VendorCode] = orders.VN_CODE,
	[STATION] = v.VN_NAME,
	[DATE] = spot.RUN_DATE,
	[TIME] = spot.TIME_OF_DAY,
	[LEN] = spot.[LENGTH],
	[InvoiceCost] = ap.AP_INV_AMT,
	[InvoiceNumber] = ap.AP_INV_VCHR,
	[FILM] = spot.AD_NUMBER,
	[SpotsInvoice] = CAST(1 as int)
FROM dbo.AP_TV_BROADCAST_DTL spot
	INNER JOIN (
				SELECT DISTINCT ORDER_NBR, ORDER_LINE_NBR
				FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
				WHERE MBWMDD.[DATE] between @start_date and @end_date
				) MBWMDD ON spot.ORDER_NBR = MBWMDD.ORDER_NBR AND spot.ORDER_LINE_NBR = MBWMDD.ORDER_LINE_NBR 
	INNER JOIN  (
				SELECT ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE, MARKET_CODE, VN_CODE, ORDER_DESC
				FROM dbo.TV_HDR
				WHERE
					(
						(@cl_code_list IS NULL)
							OR 
						(@cl_code_list IS NOT NULL AND CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_list, ',')))
					)
				--AND
				--	(
				--		(@cmp_code_list IS NULL)
				--			OR 
				--		(@cmp_code_list IS NOT NULL AND CMP_CODE IN (SELECT * FROM dbo.udf_split_list(@cmp_code_list, ',')))
				--	)
				) orders on spot.ORDER_NBR = orders.ORDER_NBR
	INNER JOIN dbo.AP_HEADER ap ON spot.AP_ID = ap.AP_ID AND ap.MODIFY_FLAG IS NULL AND ap.DELETE_FLAG IS NULL
	INNER JOIN dbo.CLIENT c ON orders.CL_CODE = c.CL_CODE
	INNER JOIN dbo.DIVISION d ON orders.CL_CODE = d.CL_CODE AND orders.DIV_CODE = d.DIV_CODE
	INNER JOIN dbo.PRODUCT p ON orders.CL_CODE = p.CL_CODE AND orders.DIV_CODE = p.DIV_CODE AND orders.PRD_CODE = p.PRD_CODE 
	INNER JOIN dbo.MARKET m ON orders.MARKET_CODE = m.MARKET_CODE 
	INNER JOIN dbo.VENDOR v ON orders.VN_CODE = v.VN_CODE

UNION

SELECT
	[MEDIA] = 'RADIO',
	[CLIENT] = orders.CL_CODE,
	--[ClientName] = c.CL_NAME,
	--[DivisionCode] = orders.DIV_CODE,
	--[DivisionName] = d.DIV_NAME,
	[PRODUCT] = orders.PRD_CODE,
	--[ProductName] = p.PRD_DESCRIPTION,
	[EST] = MBWMDD.ORDER_NBR,
	[ESTIMATE] = orders.ORDER_DESC,
	--[MarketCode] = orders.MARKET_CODE,
	[MARKET] = m.MARKET_DESC,
	--[VendorCode] = orders.VN_CODE,
	[STATION] = v.VN_NAME,
	[DATE] = spot.RUN_DATE,
	[TIME] = spot.TIME_OF_DAY,
	[LEN] = spot.[LENGTH],
	[InvoiceCost] = ap.AP_INV_AMT,
	[InvoiceNumber] = ap.AP_INV_VCHR,
	[FILM] = spot.AD_NUMBER,
	[SpotsInvoice] = CAST(1 as int)
FROM dbo.AP_RADIO_BROADCAST_DTL spot
	INNER JOIN (
				SELECT DISTINCT ORDER_NBR, ORDER_LINE_NBR
				FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
				WHERE MBWMDD.[DATE] between @start_date and @end_date
				) MBWMDD ON spot.ORDER_NBR = MBWMDD.ORDER_NBR AND spot.ORDER_LINE_NBR = MBWMDD.ORDER_LINE_NBR 
	INNER JOIN  (
				SELECT ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE, MARKET_CODE, VN_CODE, ORDER_DESC
				FROM dbo.RADIO_HDR
				WHERE
					(
						(@cl_code_list IS NULL)
							OR 
						(@cl_code_list IS NOT NULL AND CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_list, ',')))
					)
				--AND
				--	(
				--		(@cmp_code_list IS NULL)
				--			OR 
				--		(@cmp_code_list IS NOT NULL AND CMP_CODE IN (SELECT * FROM dbo.udf_split_list(@cmp_code_list, ',')))
				--	)
				) orders on spot.ORDER_NBR = orders.ORDER_NBR
	INNER JOIN dbo.AP_HEADER ap ON spot.AP_ID = ap.AP_ID AND ap.MODIFY_FLAG IS NULL AND ap.DELETE_FLAG IS NULL
	INNER JOIN dbo.CLIENT c ON orders.CL_CODE = c.CL_CODE
	INNER JOIN dbo.DIVISION d ON orders.CL_CODE = d.CL_CODE AND orders.DIV_CODE = d.DIV_CODE
	INNER JOIN dbo.PRODUCT p ON orders.CL_CODE = p.CL_CODE AND orders.DIV_CODE = p.DIV_CODE AND orders.PRD_CODE = p.PRD_CODE 
	INNER JOIN dbo.MARKET m ON orders.MARKET_CODE = m.MARKET_CODE 
	INNER JOIN dbo.VENDOR v ON orders.VN_CODE = v.VN_CODE

END
GO
