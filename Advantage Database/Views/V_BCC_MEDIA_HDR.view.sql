CREATE VIEW [dbo].[V_BCC_MEDIA_HDR]( ORDER_NBR, ORDER_DESC, CL_CODE, DIV_CODE, PRD_CODE, 
		MEDIA_TYPE, VN_CODE, CLIENT_PO, ORDER_DATE, BUYER, BILL_COOP_CODE, ORD_PROCESS_CONTRL, 
		MARKET_CODE, CMP_CODE, CMP_IDENTIFIER, MEDIA_FROM, BCC_ID, LINK_ID, UNITS, [STATUS],
		[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS)
WITH SCHEMABINDING
AS

--Magazine
SELECT h.ORDER_NBR, h.ORDER_DESC, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.MEDIA_TYPE, 
	h.VN_CODE, h.CLIENT_PO, h.ORDER_DATE, h.BUYER, h.BILL_COOP_CODE, h.ORD_PROCESS_CONTRL, 
	h.MARKET_CODE, h.CMP_CODE, h.CMP_IDENTIFIER, 'Mag2', BCC_ID, LINK_ID, NULL, [STATUS],
	[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS
FROM dbo.MAGAZINE_HEADER AS h
WHERE COALESCE(h.ORD_PROCESS_CONTRL, 0) <> 6

--Newspaper
UNION 
SELECT h.ORDER_NBR, h.ORDER_DESC, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.MEDIA_TYPE, 
	h.VN_CODE, h.CLIENT_PO, h.ORDER_DATE, h.BUYER, h.BILL_COOP_CODE, h.ORD_PROCESS_CONTRL, 
	h.MARKET_CODE, h.CMP_CODE, h.CMP_IDENTIFIER, 'News2', BCC_ID, LINK_ID, NULL, [STATUS],
	[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS
FROM dbo.NEWSPAPER_HEADER AS h
WHERE COALESCE(h.ORD_PROCESS_CONTRL, 0) <> 6

--Internet
UNION 
SELECT h.ORDER_NBR, h.ORDER_DESC, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.MEDIA_TYPE, 
	h.VN_CODE, h.CLIENT_PO, h.ORDER_DATE, h.BUYER, h.BILL_COOP_CODE, h.ORD_PROCESS_CONTRL, 
	h.MARKET_CODE, h.CMP_CODE, h.CMP_IDENTIFIER, 'Internet', BCC_ID, LINK_ID, NULL, [STATUS],
	[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS
FROM dbo.INTERNET_HEADER AS h
WHERE COALESCE(h.ORD_PROCESS_CONTRL, 0) <> 6

--Outdoor
UNION 
SELECT h.ORDER_NBR, h.ORDER_DESC, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.MEDIA_TYPE, 
	h.VN_CODE, h.CLIENT_PO, h.ORDER_DATE, h.BUYER, h.BILL_COOP_CODE, h.ORD_PROCESS_CONTRL, 
	h.MARKET_CODE, h.CMP_CODE, h.CMP_IDENTIFIER, 'Outdoor', BCC_ID, LINK_ID, NULL, [STATUS],
	[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS
FROM dbo.OUTDOOR_HEADER AS h
WHERE COALESCE(h.ORD_PROCESS_CONTRL, 0) <> 6

-- Radio (new)
UNION 
SELECT h.ORDER_NBR, h.ORDER_DESC, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.MEDIA_TYPE, 
	h.VN_CODE, h.CLIENT_PO, h.ORDER_DATE, h.BUYER, h.BILL_COOP_CODE, h.ORD_PROCESS_CONTRL, 
	h.MARKET_CODE, h.CMP_CODE, h.CMP_IDENTIFIER, 'Radio2', BCC_ID, LINK_ID, UNITS, [STATUS],
	[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS
FROM dbo.RADIO_HDR AS h
WHERE COALESCE(h.ORD_PROCESS_CONTRL, 0) <> 6

-- Television (new)
UNION 
SELECT h.ORDER_NBR, h.ORDER_DESC, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.MEDIA_TYPE, 
	h.VN_CODE, h.CLIENT_PO, h.ORDER_DATE, h.BUYER, h.BILL_COOP_CODE, h.ORD_PROCESS_CONTRL, 
	h.MARKET_CODE, h.CMP_CODE, h.CMP_IDENTIFIER, 'TV2', BCC_ID, LINK_ID, UNITS, [STATUS],
	[START_DATE], END_DATE, FISCAL_PERIOD_CODE, NET_GROSS
FROM dbo.TV_HDR AS h
WHERE COALESCE(h.ORD_PROCESS_CONTRL, 0) <> 6

GO
