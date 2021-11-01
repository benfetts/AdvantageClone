IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[V_MEDIA_CURRENT_STATUS]') and OBJECTPROPERTY(id, N'IsView') = 1)
	DROP VIEW [dbo].[V_MEDIA_CURRENT_STATUS]
GO

CREATE VIEW [dbo].[V_MEDIA_CURRENT_STATUS]

-- V_MEDIA_CURRENT_STATUS
-- #00 08/20/12 - initial version
-- #01 10/19/12 - revised REC_TYPE and added BILLED_TYPE_FLAG per jr request
-- #02 10/24/12 - added separate SELECT statement for AP records for old bcst (was dropping records)
-- #03 12/04/12 - changed field names as requested
-- #04 12/06/12 - changed (2) column labels
-- #05 02/20/13 - added separate columns for ordered/billed/AP spots_quantity
-- #06 04/11/13 - fixed join to vendor rep tables in 2nd query - was missing link to VN_CODE

AS

--For all entries except AP entries for old bcst (where LINE_NBR does not exist)
SELECT     
	  dbo.MEDIA_ORDER_HEADER.USER_ID AS [User Code], 
	  dbo.MEDIA_ORDER_HEADER.TYPE AS [Order Type], 
	  dbo.MEDIA_ORDER_HEADER.ORDER_NBR AS [Order Number], 
	  dbo.MEDIA_ORDER_HEADER.REV_NBR AS [Revision Number], 
	  dbo.MEDIA_ORDER_HEADER.OFFICE_CODE AS [Office Code], 
	  dbo.OFFICE.OFFICE_NAME AS [Office Name],
	  dbo.MEDIA_ORDER_HEADER.CL_CODE AS [Client Code], 
	  dbo.CLIENT.CL_NAME AS [Client Name],
	  dbo.MEDIA_ORDER_HEADER.DIV_CODE AS [Division Code],
	  dbo.DIVISION.DIV_NAME AS [Division Name], 
	  dbo.MEDIA_ORDER_HEADER.PRD_CODE AS [Product Code],
	  dbo.PRODUCT.PRD_DESCRIPTION AS [Product Description],  
	  dbo.MEDIA_ORDER_HEADER.ORDER_DESC AS [Order Description], 
	  dbo.MEDIA_ORDER_HEADER.ORDER_COMMENT AS [Order Comment], 
	  dbo.MEDIA_ORDER_HEADER.VN_CODE AS [Vendor Code],
	  dbo.VENDOR.VN_NAME AS [Vendor Name], 
	  dbo.MEDIA_ORDER_HEADER.VR_CODE AS [Vendor Rep Code], 
	  ISNULL(dbo.VEN_REP.VR_FNAME,'') + ' ' + ISNULL(dbo.VEN_REP.VR_LNAME,'') AS [Vendor Rep Name],
	  dbo.MEDIA_ORDER_HEADER.VR_CODE2 AS [Vendor Rep Code2],
	  ISNULL(vr2.VR_FNAME,'') + ' ' + ISNULL(vr2.VR_LNAME,'') AS [Vendor Rep Name2], 
	  dbo.MEDIA_ORDER_HEADER.CMP_CODE AS [Campaign Code], 
	  dbo.MEDIA_ORDER_HEADER.CMP_IDENTIFIER AS [Campaign ID], 
	  dbo.MEDIA_ORDER_HEADER.CMP_NAME AS [Campaign Name], 
	  dbo.MEDIA_ORDER_HEADER.MEDIA_TYPE AS [Media Type], 
	  dbo.MEDIA_ORDER_HEADER.POST_BILL AS [Post Bill Flag], 
	  dbo.MEDIA_ORDER_HEADER.NET_GROSS AS [Net Gross Flag], 
	  dbo.MEDIA_ORDER_HEADER.MARKET_CODE AS [Market Code], 
	  dbo.MEDIA_ORDER_HEADER.MARKET_DESC AS [Market Description], 
	  dbo.MEDIA_ORDER_HEADER.ORDER_DATE AS [Order Date], 
	  dbo.MEDIA_ORDER_HEADER.FLIGHT_FROM AS [Order Flight From], 
	  dbo.MEDIA_ORDER_HEADER.FLIGHT_TO AS [Order Flight To], 
	  dbo.MEDIA_ORDER_HEADER.ORD_PROCESS_CONTRL AS [Order Process Control], 
	  dbo.MEDIA_ORDER_HEADER.BUYER AS [Buyer], 
	  dbo.MEDIA_ORDER_HEADER.CLIENT_PO AS [Client PO], 
	  dbo.MEDIA_ORDER_HEADER.LINK_ID AS [Link ID], 
	  dbo.MEDIA_ORDER_HEADER.ORDER_ACCEPTED AS [Order Accepted], 
	  CASE dbo.MEDIA_ORDER_HEADER.ADVAN_TYPE
		WHEN 1 THEN 0
		ELSE dbo.MEDIA_ORDER_DETAIL.LINE_NBR
	  END AS [Line Number], 
	  dbo.MEDIA_ORDER_DETAIL.REV_NBR AS [Line Revision Number],
	  dbo.MEDIA_ORDER_DETAIL.SEQ_NBR AS [Line Sequence Number], 
	  dbo.MEDIA_ORDER_DETAIL.DATE_TYPE AS [Order Date Type],
	  COALESCE(dbo.MEDIA_ORDER_DETAIL.[YEAR],dbo.MEDIA_ORDER_AMOUNTS.[YEAR]) * 100 +
			COALESCE(dbo.MEDIA_ORDER_DETAIL.[MONTH],dbo.MEDIA_ORDER_AMOUNTS.[MONTH])AS [Order Period], 
	  CASE COALESCE(dbo.MEDIA_ORDER_DETAIL.[MONTH],dbo.MEDIA_ORDER_AMOUNTS.[MONTH])
			WHEN 1 THEN 'Jan'
			WHEN 2 THEN 'Feb'
			WHEN 3 THEN 'Mar'
			WHEN 4 THEN 'Apr'
			WHEN 5 THEN 'May'
			WHEN 6 THEN 'Jun'
			WHEN 7 THEN 'Jul'
			WHEN 8 THEN 'Aug'
			WHEN 9 THEN 'Sep'
			WHEN 10 THEN 'Oct'
			WHEN 11 THEN 'Nov'
			WHEN 12 THEN 'Dec'	  
	  END AS [Order Month], 
	  COALESCE(dbo.MEDIA_ORDER_DETAIL.[YEAR],dbo.MEDIA_ORDER_AMOUNTS.[YEAR]) AS [Order year], 
	  dbo.MEDIA_ORDER_DETAIL.INSERT_DATE [Insertion Date], 
	  dbo.MEDIA_ORDER_DETAIL.END_DATE AS [Order End Date], 
	  dbo.MEDIA_ORDER_DETAIL.DATE_TO_BILL AS [Date To Bill], 
	  dbo.MEDIA_ORDER_DETAIL.CLOSE_DATE AS [Close Date], 
	  dbo.MEDIA_ORDER_DETAIL.MATL_CLOSE_DATE AS [Material Close Date], 
	  dbo.MEDIA_ORDER_DETAIL.LINE_DESC AS [Line Description], 
	  dbo.MEDIA_ORDER_DETAIL.AD_SIZE AS [Ad Size], 
	  dbo.MEDIA_ORDER_DETAIL.EDITION_ISSUE AS [Edition Issue], 
	  dbo.MEDIA_ORDER_DETAIL.SECTION AS [Section], 
	  dbo.MEDIA_ORDER_DETAIL.MATERIAL AS [Material], 
	  dbo.MEDIA_ORDER_DETAIL.REMARKS AS [Remarks], 
	  dbo.MEDIA_ORDER_DETAIL.URL AS [URL], 
	  dbo.MEDIA_ORDER_DETAIL.COPY_AREA AS [Copy Area], 
	  dbo.MEDIA_ORDER_DETAIL.MATL_NOTES AS [Material Notes], 
	  dbo.MEDIA_ORDER_DETAIL.POSITION_INFO AS [Position Info], 
	  dbo.MEDIA_ORDER_DETAIL.MISC_INFO AS [Miscellaneous Info], 
	  dbo.MEDIA_ORDER_DETAIL.JOB_NUMBER AS [Job Number], 
	  dbo.JOB_LOG.JOB_DESC AS [Job Description],
	  dbo.MEDIA_ORDER_DETAIL.JOB_COMPONENT_NBR AS [Job Component Number], 
	  dbo.JOB_COMPONENT.JOB_COMP_DESC AS [Job Component Description],
	  dbo.MEDIA_ORDER_DETAIL.COST_TYPE AS [Cost Type], 
	  dbo.MEDIA_ORDER_DETAIL.RATE_TYPE AS [Rate Type], 
	  dbo.MEDIA_ORDER_DETAIL.PRINT_LINES AS [Print Quantity], 
	  dbo.MEDIA_ORDER_DETAIL.GUARANTEED_IMPRESS AS [Guaranteed Impressions],
	  dbo.MEDIA_ORDER_DETAIL.LINK_ID AS [Line Link ID], 
	  dbo.MEDIA_ORDER_AMOUNTS.ORDER_TYPE AS [Order Entry Type],
	  CASE dbo.MEDIA_ORDER_AMOUNTS.REC_TYPE
		WHEN 'O' THEN 'ORDER'
		WHEN 'B' THEN 'BILLING'
		WHEN 'A' THEN 'AP'
	  END AS [Record Type],
	  --dbo.MEDIA_ORDER_AMOUNTS.SPOTS AS [Spots],  
	  dbo.MEDIA_ORDER_AMOUNTS.EXT_NET_AMT AS [Extended Net Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.NETCHARGES AS [Net Charge Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.DISCOUNTS AS [Discount Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.ADDL_CHARGE AS [Additional Charge Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.COMM_AMT AS [Commission Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.REBATE_AMT AS [Rebate Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.VENDOR_TAX AS [Vendor Tax Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.RESALE_TAX AS [Resale Tax Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.LINE_TOTAL AS [Line Total Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.NET_TOTAL_AMT AS [Net Total Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.VENDOR_NET_AMT AS [Vendor Net Amount],
	  dbo.MEDIA_ORDER_AMOUNTS.BILL_AMT AS [Bill Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.RECNB_BILL_AMT AS [Reconcile No_Bill Bill Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.RECNB_NET_AMT AS [Reconcile No_BILL Net Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.SPOTS_QTY AS [Spots Quantity],				--#05
	  dbo.MEDIA_ORDER_AMOUNTS.NON_BILL_FLAG AS [Non_billable Flag], 
	  dbo.MEDIA_ORDER_AMOUNTS.LINE_CANCELLED AS [Line Cancelled], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILL_TYPE_FLAG AS [Bill Type Flag],
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_EXT_NET_AMT AS [Billed Extended Net Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_DISC_AMT AS [Billed Discount Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_NC_AMT AS [Billed Net Charge Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_VTAX_AMT AS [Billed Vendor Tax Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_NET_AMT AS [Billed Net Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_ADDL_CHARGE AS [Billed Additional Charge Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_COMM_AMT AS [Billed Commission Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_REBATE_AMT AS [Billed Rebate Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_RTAX_AMT AS [Billed Resale Tax Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_BILL_AMT AS [Billed Bill Amount],
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_SPOTS_QTY AS [Billed Spots Quantity],		--#05
	  dbo.MEDIA_ORDER_AMOUNTS.AR_INV_NBR AS [Invoice Number], 
	  dbo.MEDIA_ORDER_AMOUNTS.AR_SEQ AS [Invoice Sequence Number], 
	  dbo.MEDIA_ORDER_AMOUNTS.AR_TYPE AS [Invoice Type], 
	  dbo.MEDIA_ORDER_AMOUNTS.GLXACT_BILL AS [GL Billing Trans Number],				--#04
	  dbo.MEDIA_ORDER_AMOUNTS.AP_NET_AMT AS [AP Net Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_NETCHARGES_AMT AS [AP Net Charge Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_DISC_AMT_AMT AS [AP Discount Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_COMM_AMT AS [AP Commission Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_REBATE_AMT AS [AP Rebate Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_VTAX_AMT AS [AP Vendor Tax Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_RTAX_AMT AS [AP Resale Tax Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_BILL_AMT AS [AP Bill Amount], 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_LINE_TOTAL AS [AP Line Total],
	  dbo.MEDIA_ORDER_AMOUNTS.AP_SPOTS_QTY AS [AP Spots Quantity],			--#05
	  dbo.MEDIA_ORDER_AMOUNTS.AP_INV_NBR AS [AP Invoice Number], 
	  dbo.MEDIA_ORDER_AMOUNTS.GLXACT_AP AS [AP GL Trans Number]			--#04
FROM  dbo.MEDIA_ORDER_HEADER 
INNER JOIN dbo.MEDIA_ORDER_DETAIL 
	ON dbo.MEDIA_ORDER_HEADER.[USER_ID] = dbo.MEDIA_ORDER_DETAIL.[USER_ID]
	AND dbo.MEDIA_ORDER_HEADER.ORDER_NBR = dbo.MEDIA_ORDER_DETAIL.ORDER_NBR 
INNER JOIN dbo.MEDIA_ORDER_AMOUNTS 
	ON dbo.MEDIA_ORDER_HEADER.[USER_ID] = dbo.MEDIA_ORDER_AMOUNTS.[USER_ID]
	AND dbo.MEDIA_ORDER_DETAIL.ORDER_NBR = dbo.MEDIA_ORDER_AMOUNTS.ORDER_NBR 
	AND dbo.MEDIA_ORDER_DETAIL.LINE_NBR = dbo.MEDIA_ORDER_AMOUNTS.LINE_NBR
JOIN dbo.OFFICE
	ON dbo.MEDIA_ORDER_HEADER.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE
INNER JOIN dbo.CLIENT
	ON dbo.MEDIA_ORDER_HEADER.CL_CODE = dbo.CLIENT.CL_CODE	
INNER JOIN dbo.DIVISION
	ON dbo.MEDIA_ORDER_HEADER.CL_CODE = dbo.DIVISION.CL_CODE	
	AND dbo.MEDIA_ORDER_HEADER.DIV_CODE = dbo.DIVISION.DIV_CODE
INNER JOIN dbo.PRODUCT
	ON dbo.MEDIA_ORDER_HEADER.CL_CODE = dbo.PRODUCT.CL_CODE	
	AND dbo.MEDIA_ORDER_HEADER.DIV_CODE = dbo.PRODUCT.DIV_CODE
	AND dbo.MEDIA_ORDER_HEADER.PRD_CODE = dbo.PRODUCT.PRD_CODE
INNER JOIN dbo.VENDOR
	ON dbo.MEDIA_ORDER_HEADER.VN_CODE = dbo.VENDOR.VN_CODE
LEFT JOIN dbo.VEN_REP
	ON dbo.MEDIA_ORDER_HEADER.VN_CODE = dbo.VEN_REP.VN_CODE
	AND dbo.MEDIA_ORDER_HEADER.VR_CODE = dbo.VEN_REP.VR_CODE
LEFT JOIN dbo.VEN_REP AS vr2
	ON dbo.MEDIA_ORDER_HEADER.VN_CODE = vr2.VN_CODE
	AND dbo.MEDIA_ORDER_HEADER.VR_CODE = vr2.VR_CODE	
LEFT JOIN dbo.JOB_LOG
	ON dbo.MEDIA_ORDER_DETAIL.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER
LEFT JOIN dbo.JOB_COMPONENT
	ON dbo.MEDIA_ORDER_DETAIL.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER
	AND dbo.MEDIA_ORDER_DETAIL.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR
WHERE dbo.MEDIA_ORDER_HEADER.[USER_ID] = dbo.fn_AdvanUser()
	AND (dbo.MEDIA_ORDER_HEADER.ADVAN_TYPE = 2	
	OR (dbo.MEDIA_ORDER_HEADER.ADVAN_TYPE = 1 AND dbo.MEDIA_ORDER_AMOUNTS.REC_TYPE <> 'A'  ))	
	
--For all AP entries for old bcst where LINE_NBR does not exist (see WHERE clause)
UNION ALL SELECT     
	  dbo.MEDIA_ORDER_HEADER.USER_ID, 
	  dbo.MEDIA_ORDER_HEADER.TYPE, 
	  dbo.MEDIA_ORDER_HEADER.ORDER_NBR, 
	  dbo.MEDIA_ORDER_HEADER.REV_NBR, 
	  dbo.MEDIA_ORDER_HEADER.OFFICE_CODE, 
	  dbo.OFFICE.OFFICE_NAME, 
	  dbo.MEDIA_ORDER_HEADER.CL_CODE,  
	  dbo.CLIENT.CL_NAME,
	  dbo.MEDIA_ORDER_HEADER.DIV_CODE, 
	  dbo.DIVISION.DIV_NAME,
	  dbo.MEDIA_ORDER_HEADER.PRD_CODE,
	  dbo.PRODUCT.PRD_DESCRIPTION,  
	  dbo.MEDIA_ORDER_HEADER.ORDER_DESC, 
	  dbo.MEDIA_ORDER_HEADER.ORDER_COMMENT, 
	  dbo.MEDIA_ORDER_HEADER.VN_CODE,
	  dbo.VENDOR.VN_NAME, 
	  dbo.MEDIA_ORDER_HEADER.VR_CODE, 
	  ISNULL(dbo.VEN_REP.VR_FNAME,'') + ' ' + ISNULL(dbo.VEN_REP.VR_LNAME,''), 
	  dbo.MEDIA_ORDER_HEADER.VR_CODE2, 
	  ISNULL(vr2.VR_FNAME,'') + ' ' + ISNULL(vr2.VR_LNAME,''),
	  dbo.MEDIA_ORDER_HEADER.CMP_CODE, 
	  dbo.MEDIA_ORDER_HEADER.CMP_IDENTIFIER, 
	  dbo.MEDIA_ORDER_HEADER.CMP_NAME, 
	  dbo.MEDIA_ORDER_HEADER.MEDIA_TYPE, 
	  dbo.MEDIA_ORDER_HEADER.POST_BILL, 
	  dbo.MEDIA_ORDER_HEADER.NET_GROSS, 
	  dbo.MEDIA_ORDER_HEADER.MARKET_CODE, 
	  dbo.MEDIA_ORDER_HEADER.MARKET_DESC, 
	  dbo.MEDIA_ORDER_HEADER.ORDER_DATE, 
	  dbo.MEDIA_ORDER_HEADER.FLIGHT_FROM, 
	  dbo.MEDIA_ORDER_HEADER.FLIGHT_TO, 
	  dbo.MEDIA_ORDER_HEADER.ORD_PROCESS_CONTRL, 
	  dbo.MEDIA_ORDER_HEADER.BUYER, 
	  dbo.MEDIA_ORDER_HEADER.CLIENT_PO, 
	  dbo.MEDIA_ORDER_HEADER.LINK_ID, 
	  dbo.MEDIA_ORDER_HEADER.ORDER_ACCEPTED, 
	  0,		--dbo.MEDIA_ORDER_DETAIL.LINE_NBR, 
	  0,		--dbo.MEDIA_ORDER_DETAIL.REV_NBR AS LINE_REV_NBR,
	  0,		--dbo.MEDIA_ORDER_DETAIL.SEQ_NBR, 
	  'BRD',	--dbo.MEDIA_ORDER_DETAIL.DATE_TYPE,
	  dbo.MEDIA_ORDER_AMOUNTS.[YEAR] * 100 + dbo.MEDIA_ORDER_AMOUNTS.[MONTH], 
	  CASE dbo.MEDIA_ORDER_AMOUNTS.[MONTH]
			WHEN 1 THEN 'Jan'
			WHEN 2 THEN 'Feb'
			WHEN 3 THEN 'Mar'
			WHEN 4 THEN 'Apr'
			WHEN 5 THEN 'May'
			WHEN 6 THEN 'Jun'
			WHEN 7 THEN 'Jul'
			WHEN 8 THEN 'Aug'
			WHEN 9 THEN 'Sep'
			WHEN 10 THEN 'Oct'
			WHEN 11 THEN 'Nov'
			WHEN 12 THEN 'Dec'	  
	  END, 
	  dbo.MEDIA_ORDER_AMOUNTS.[YEAR], 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.INSERT_DATE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.END_DATE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.DATE_TO_BILL, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.CLOSE_DATE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.MATL_CLOSE_DATE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.LINE_DESC, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.AD_SIZE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.EDITION_ISSUE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.SECTION, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.MATERIAL, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.REMARKS, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.URL, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.COPY_AREA, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.MATL_NOTES, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.POSITION_INFO, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.MISC_INFO, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.JOB_NUMBER,
	  NULL,   --dbo.JOB_LOG.JOB_DESC, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.JOB_COMPONENT_NBR, 
	  NULL,   --dbo.JOB_COMPONENT.JOB_COMP_DESC,
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.COST_TYPE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.RATE_TYPE, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.PRINT_LINES, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.GUARANTEED_IMPRESS, 
	  NULL,   --dbo.MEDIA_ORDER_DETAIL.LINK_ID AS LINE_LINK_ID, 
	  dbo.MEDIA_ORDER_AMOUNTS.ORDER_TYPE,
	  CASE dbo.MEDIA_ORDER_AMOUNTS.REC_TYPE
		WHEN 'O' THEN 'ORDER'
		WHEN 'B' THEN 'BILLING'
		WHEN 'A' THEN 'AP'
	  END AS REC_TYPE,
	  --dbo.MEDIA_ORDER_AMOUNTS.SPOTS,  
	  dbo.MEDIA_ORDER_AMOUNTS.EXT_NET_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.NETCHARGES, 
	  dbo.MEDIA_ORDER_AMOUNTS.DISCOUNTS, 
	  dbo.MEDIA_ORDER_AMOUNTS.ADDL_CHARGE, 
	  dbo.MEDIA_ORDER_AMOUNTS.COMM_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.REBATE_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.VENDOR_TAX, 
	  dbo.MEDIA_ORDER_AMOUNTS.RESALE_TAX, 
	  dbo.MEDIA_ORDER_AMOUNTS.LINE_TOTAL, 
	  dbo.MEDIA_ORDER_AMOUNTS.NET_TOTAL_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.VENDOR_NET_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILL_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.RECNB_BILL_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.RECNB_NET_AMT,
	  dbo.MEDIA_ORDER_AMOUNTS.SPOTS_QTY,				--#05
	  dbo.MEDIA_ORDER_AMOUNTS.NON_BILL_FLAG, 
	  dbo.MEDIA_ORDER_AMOUNTS.LINE_CANCELLED, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILL_TYPE_FLAG, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_EXT_NET_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_DISC_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_NC_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_VTAX_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_NET_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_ADDL_CHARGE, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_COMM_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_REBATE_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_RTAX_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_BILL_AMT,
	  dbo.MEDIA_ORDER_AMOUNTS.BILLED_SPOTS_QTY,			--#05  
	  dbo.MEDIA_ORDER_AMOUNTS.AR_INV_NBR, 
	  dbo.MEDIA_ORDER_AMOUNTS.AR_SEQ, 
	  dbo.MEDIA_ORDER_AMOUNTS.AR_TYPE, 
	  dbo.MEDIA_ORDER_AMOUNTS.GLXACT_BILL, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_NET_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_NETCHARGES_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_DISC_AMT_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_COMM_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_REBATE_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_VTAX_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_RTAX_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_BILL_AMT, 
	  dbo.MEDIA_ORDER_AMOUNTS.AP_LINE_TOTAL,	  
	  dbo.MEDIA_ORDER_AMOUNTS.AP_SPOTS_QTY,				--#05  
	  dbo.MEDIA_ORDER_AMOUNTS.AP_INV_NBR,
	  dbo.MEDIA_ORDER_AMOUNTS.GLXACT_AP	  
FROM  dbo.MEDIA_ORDER_HEADER 
INNER JOIN dbo.MEDIA_ORDER_AMOUNTS 
	ON dbo.MEDIA_ORDER_HEADER.[USER_ID] = dbo.MEDIA_ORDER_AMOUNTS.[USER_ID]
	AND dbo.MEDIA_ORDER_HEADER.ORDER_NBR = dbo.MEDIA_ORDER_AMOUNTS.ORDER_NBR 
JOIN dbo.OFFICE
	ON dbo.MEDIA_ORDER_HEADER.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE
INNER JOIN dbo.CLIENT
	ON dbo.MEDIA_ORDER_HEADER.CL_CODE = dbo.CLIENT.CL_CODE	
INNER JOIN dbo.DIVISION
	ON dbo.MEDIA_ORDER_HEADER.CL_CODE = dbo.DIVISION.CL_CODE	
	AND dbo.MEDIA_ORDER_HEADER.DIV_CODE = dbo.DIVISION.DIV_CODE
INNER JOIN dbo.PRODUCT
	ON dbo.MEDIA_ORDER_HEADER.CL_CODE = dbo.PRODUCT.CL_CODE	
	AND dbo.MEDIA_ORDER_HEADER.DIV_CODE = dbo.PRODUCT.DIV_CODE
	AND dbo.MEDIA_ORDER_HEADER.PRD_CODE = dbo.PRODUCT.PRD_CODE
INNER JOIN dbo.VENDOR
	ON dbo.MEDIA_ORDER_HEADER.VN_CODE = dbo.VENDOR.VN_CODE
LEFT JOIN dbo.VEN_REP
	ON dbo.MEDIA_ORDER_HEADER.VN_CODE = dbo.VEN_REP.VN_CODE
	AND dbo.MEDIA_ORDER_HEADER.VR_CODE = dbo.VEN_REP.VR_CODE
LEFT JOIN dbo.VEN_REP AS vr2
	ON dbo.MEDIA_ORDER_HEADER.VN_CODE = vr2.VN_CODE
	AND dbo.MEDIA_ORDER_HEADER.VR_CODE = vr2.VR_CODE	
--LEFT JOIN dbo.JOB_LOG
--	ON dbo.MEDIA_ORDER_DETAIL.JOB_NUMBER = dbo.JOB_LOG.JOB_NUMBER
--LEFT JOIN dbo.JOB_COMPONENT
--	ON dbo.MEDIA_ORDER_DETAIL.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER
--	AND dbo.MEDIA_ORDER_DETAIL.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR
WHERE dbo.MEDIA_ORDER_HEADER.[USER_ID] = dbo.fn_AdvanUser()
	AND dbo.MEDIA_ORDER_HEADER.ADVAN_TYPE = 1	
	AND dbo.MEDIA_ORDER_AMOUNTS.REC_TYPE = 'A'
	  

GO

IF ( @@ERROR = 0 )
	GRANT SELECT ON [V_MEDIA_CURRENT_STATUS] TO PUBLIC AS dbo
GO	

