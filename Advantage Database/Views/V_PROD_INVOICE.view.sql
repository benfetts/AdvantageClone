IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[V_PROD_INVOICE]' ) AND OBJECTPROPERTY( id, N'IsView' ) = 1 )
	DROP VIEW [dbo].[V_PROD_INVOICE]
GO

CREATE VIEW dbo.V_PROD_INVOICE
AS

-- ========================================================================================
-- V_PROD_INVOICE
-- #00 08/17/12 - initial version
-- #01 09/01/12 - substituted new join to V_AR_ADDRESS_TABLE_PROD and separate join to CDP contact info
-- #02 02/13/13 - added exchange rate calculations
-- #03 03/14/13 - various modifications to date
-- #04 03/31/13 - use OCDP codes from PROD_BILLING_DATA
-- #05 05/06/13 - changed reference from 's' to 'def' for address info
-- ========================================================================================

	SELECT
		s.[USER_ID],
		s.APP_TYPE,
		s.PRINT_DATE AS INV_PRINT_DATE,
		d.INVOICE_NUMBER AS INV_INVOICE_NBR,
		d.INVOICE_DATE AS INV_INVOICE_DATE,
		d.OFFICE_CODE AS INV_OFFICE_CODE,
		d.CL_CODE AS INV_CLIENT_CODE,
		d.DIV_CODE AS INV_DIVISION_CODE,
		d.PRD_CODE AS INV_PRODUCT_CODE,
		dd.AR_INV_DUE_DATE AS INV_DUE_DATE,
		dd.INV_CAT_DESC as INV_CATEGORY,
		cb.BILL_COMMENT AS INV_BILLING_COMMENT,
		RIGHT('000000' + CAST(d.JOB_NUMBER AS varchar),6) AS INV_JOB_NUMBER,
		RIGHT('00' + CAST(d.JOB_COMPONENT_NBR AS varchar), 2) AS INV_JOB_COMP_NUMBER,
		d.FNC_CODE_TYPE AS INV_FNC_CODE_TYPE,
		d.FNC_CODE AS INV_FNC_CODE,
		d.ITEM_TYPE AS INV_DTL_TYPE,
		d.ITEM_ID AS INV_DTL_ID_NBR,
		d.ITEM_LINE_NBR AS INV_DTL_LINE_NBR,
		d.ITEM AS INV_DTL_DESC,
		d.ITEM_DATE AS INV_DTL_DATE,
		d.ITEM_CODE AS INV_DTL_CODE,
		d.ITEM_DETAIL AS INV_DTL_INV_NBR,
		CASE f.FNC_TYPE
			WHEN 'V' THEN apc.AP_COMMENT
			WHEN 'E' THEN etc.EMP_COMMENT
			WHEN 'I' THEN ioc.IO_COMMENT
		END AS INV_DTL_COMMENT,
		d.AP_DESC AS INV_DTL_AP_DESC,
		et.EMPLOYEE_TITLE AS INV_DTL_EMP_TITLE,
		d.REC_TYPE AS INV_AMT_REC_TYPE,
		def.TOT_SHOW_COMM AS SHOW_COMM,
		def.TOT_SHOW_TAX AS SHOW_TAX,
		def.COL_OPT_XCHGE_AMTS AS USE_EXCHANGE_RATE,
		def.COL_OPT_XCHGE_DEF AS EXCHANGE_RATE,
		d.HOURS_QTY AS INV_AMT_CUR_HRS_QTY,
		d.RATE AS INV_AMT_CUR_RATE,
		dbo.advfn_xchge_net_amt(d.NET,d.COMMISSION,def.TOT_SHOW_COMM,
			d.EXT_CITY_RESALE + d.EXT_COUNTY_RESALE + d.EXT_STATE_RESALE + d.EXT_NONRESALE_TAX,
			def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_CUR_NET,
		dbo.advfn_xchge_commission_amt(d.COMMISSION,def.TOT_SHOW_COMM,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_CUR_COMMISSION,
		dbo.advfn_xchge_tax_amt(d.EXT_NONRESALE_TAX,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_CUR_VENDOR_TAX,
		dbo.advfn_xchge_tax_amt(d.EXT_CITY_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_CUR_CITY_TAX,
		dbo.advfn_xchge_tax_amt(d.EXT_COUNTY_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_CUR_COUNTY_TAX,
		dbo.advfn_xchge_tax_amt(d.EXT_STATE_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_CUR_STATE_TAX,
		dbo.advfn_xchge_tax_amt(d.EXT_CITY_RESALE + d.EXT_COUNTY_RESALE + d.EXT_STATE_RESALE + d.EXT_NONRESALE_TAX,
			def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_CUR_TOTAL_TAX,
		dbo.advfn_xchge_total_amt(d.LINE_TOTAL,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_CUR_LINE_TOTAL,
		d.PRIOR_HOURS_QTY AS INV_AMT_PRIOR_HRS_QTY,
		d.PRIOR_RATE AS INV_AMT_PRIOR_RATE,
		dbo.advfn_xchge_net_amt(d.PRIOR_NET,d.PRIOR_COMMISSION,def.TOT_SHOW_COMM,
			d.PRIOR_EXT_CITY_RESALE + d.PRIOR_EXT_COUNTY_RESALE + d.PRIOR_EXT_STATE_RESALE + d.PRIOR_EXT_NONRESALE_TAX,
			def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_PRIOR_NET,
		dbo.advfn_xchge_commission_amt(d.PRIOR_COMMISSION,def.TOT_SHOW_COMM,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_PRIOR_COMMISSION,
		dbo.advfn_xchge_tax_amt(d.PRIOR_EXT_NONRESALE_TAX,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_PRIOR_VENDOR_TAX,
		dbo.advfn_xchge_tax_amt(d.PRIOR_EXT_CITY_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_PRIOR_CITY_TAX,
		dbo.advfn_xchge_tax_amt(d.PRIOR_EXT_COUNTY_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_PRIOR_COUNTY_TAX,
		dbo.advfn_xchge_tax_amt(d.PRIOR_EXT_STATE_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_PRIOR_STATE_TAX,
		dbo.advfn_xchge_tax_amt(d.PRIOR_EXT_CITY_RESALE + d.PRIOR_EXT_COUNTY_RESALE + d.PRIOR_EXT_STATE_RESALE + d.PRIOR_EXT_NONRESALE_TAX,
			def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_PRIOR_TOTAL_TAX,
		dbo.advfn_xchge_total_amt(d.PRIOR_LINE_TOTAL,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_PRIOR_LINE_TOTAL,
		d.PRIOR_INV_NBR AS INV_AMT_PRIOR_INVOICE_NBR,
		d.PRIOR_INV_DATE AS INV_AMT_PRIOR_INV_DATE,
		d.EST_QTY AS INV_AMT_EST_QUANTITY,
		dbo.advfn_xchge_net_amt(d.EST_NET,d.EST_COMM,def.TOT_SHOW_COMM,
			d.EST_EXT_CITY_RESALE + d.EST_EXT_COUNTY_RESALE + d.EST_EXT_STATE_RESALE + d.EST_EXT_NONRESALE_TAX,
			def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_EST_NET,
		dbo.advfn_xchge_commission_amt(d.EST_COMM,def.TOT_SHOW_COMM,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_EST_COMMISSION,
		dbo.advfn_xchge_tax_amt(d.EST_EXT_NONRESALE_TAX,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_EST_VENDOR_TAX,
		dbo.advfn_xchge_tax_amt(d.EST_EXT_CITY_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_EST_CITY_TAX,
		dbo.advfn_xchge_tax_amt(d.EST_EXT_COUNTY_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_EST_COUNTY_TAX,
		dbo.advfn_xchge_tax_amt(d.EST_EXT_STATE_RESALE,def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) 
			AS INV_AMT_EST_STATE_TAX,
		dbo.advfn_xchge_tax_amt(d.EST_EXT_CITY_RESALE + d.EST_EXT_COUNTY_RESALE + d.EST_EXT_STATE_RESALE + d.EST_EXT_NONRESALE_TAX,
			def.TOT_SHOW_TAX,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_EST_TOTAL_TAX,
		dbo.advfn_xchge_total_amt(d.EST_LINE_TOTAL,def.COL_OPT_XCHGE_AMTS,def.COL_OPT_XCHGE_DEF) AS INV_AMT_EST_LINE_TOTAL,
		f.FNC_TYPE AS FUNC_TYPE,
		f.FNC_ORDER AS FUNC_ORDER,
		COALESCE(cd.FNC_DESC, f.FNC_DESCRIPTION) AS FUNC_DESCRIPTION,
		fh.FNC_HEADING_DESC AS FUNC_HEADING_DESC,
		fh.FNC_HEADING_SEQ AS FUNC_HEADING_SEQ,
		NULL AS CONSOL_FNC_CODE,		--ISNULL(f.FNC_CONSOLIDATION, f.FNC_CODE) AS CONSOL_FNC_CODE,
		NULL AS CONSOL_FUNC_DESC,		--ISNULL(f2.FNC_DESCRIPTION, f.FNC_DESCRIPTION) AS CONSOL_FUNC_DESC,
		'not used' AS FUNC_IN_OUT_DESC,
		cd.DTL_COMMENT AS FUNC_BILLING_COMMENT,
		bad.CLIENT_FNC_COMMENTS AS FUNC_BA_CLIENT_COMMENT,
		CASE def.FNC_IND_TAXABLE
			WHEN 0 THEN NULL
			ELSE ti.CUR_TAX_IND 
		END	AS FUNC_CUR_AMT_TAX_IND,
		CASE def.FNC_IND_TAXABLE
			WHEN 0 THEN NULL
			ELSE ti.TTD_TAX_IND 
		END	AS FUNC_TTD_AMT_TAX_IND,
		CASE def.FNC_IND_TAXABLE
			WHEN 0 THEN NULL
			ELSE ti.EPCT_TAX_IND 
		END	AS FUNC_EPCT_AMT_TAX_IND,
		h.CL_CODE AS JOB_CLIENT_CODE,
		h.DIV_CODE AS JOB_DIVISION_CODE,
		h.PRD_CODE AS JOB_PRODUCT_CODE,
		h.JOB_DESC AS JOB_DESCRIPTION,
		h.SC_CODE AS JOB_SALES_CLASS_CODE,
		h.SC_DESCRIPTION AS JOB_SALES_CLASS_DESC,
		h.CMP_IDENTIFIER AS JOB_CAMPAIGN_ID,
		h.CMP_CODE AS CMP_CODE,
		h.CMP_NAME AS JOB_CAMPAIGN_DESC,
		h.JOB_BILL_COMMENT AS JOB_COMMENT,
		h.JOB_CLI_REF AS JOB_CLIENT_REFERENCE,
		h.COMPLEX_CODE AS JOB_COMPLEXITY_CODE,
		h.PROMO_CODE AS JOB_PROMO_CODE,
		h.JOB_COMP_DESC AS JOB_COMP_DESCRIPTION,
		h.JOB_AD_SIZE AS JOB_COMP_AD_SIZE,
		h.JOB_COMP_COMMENTS AS JOB_COMP_COMMENT,
		h.ACCT_NBR AS JOB_COMP_ACCT_NBR,
		h.MARKET_DESC AS JOB_COMP_MARKET_DESC,
		h.JOB_CL_PO_NBR AS JOB_COMP_CLIENT_PO_NBR,
		h.CDP_CONTACT_ID AS JOB_COMP_CONTACT_ID,
		h.EMPLOYEE AS JOB_COMP_EMPLOYEE,
		h.UDV1_CODE AS JOB_COMP_UDV1_CODE,
		h.UDV2_CODE AS JOB_COMP_UDV2_CODE,
		h.UDV3_CODE AS JOB_COMP_UDV3_CODE,
		h.UDV4_CODE AS JOB_COMP_UDV4_CODE,
		h.UDV5_CODE AS JOB_COMP_UDV5_CODE,
		cj.JOB_COMMENT AS JOB_COMP_BILLING_COMMENT,
		bah.CLIENT_COMMENTS AS JOB_COMP_BA_CLIENT_COMMENT,
		h.EST_LOG_COMMENT AS JOB_EST_COMMENT,
		h.EST_COMP_COMMENT AS JOB_EST_COMP_COMMENT,
		h.EST_QTE_COMMENT AS JOB_EST_QUOTE_COMMENT,
		h.EST_REV_COMMENT AS JOB_EST_REVISION_COMMENT,
		def.ADDRESS_BLOCK AS ADDR_OPT,
		def.CONTACT_POS AS CONTACT_POS,
		a.CL_CODE AS ADDR_CLIENT_CODE,
		a.DIV_CODE AS ADDR_DIVISION_CODE,
		a.PRD_CODE AS ADDR_PRODUCT_CODE,
		a.CL_NAME AS ADDR_CLIENT_NAME,
		a.DIV_NAME AS ADDR_DIVISION_NAME,
		a.PRD_DESCRIPTION AS ADDR_PRODUCT_NAME,	
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_ADDRESS1
			ELSE a.ADDRESS1
		END AS ADDR_ADDRESS_LINE1,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_ADDRESS2
			ELSE a.ADDRESS2
		END AS ADDR_ADDRESS_LINE2,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_CITY
			ELSE a.CITY
		END AS ADDR_CITY,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_STATE
			ELSE a.[STATE] 
		END AS ADDR_STATE,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_ZIP
			ELSE a.ZIP
		END AS ADDR_ZIP,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ISNULL(ch.CONT_CITY,'') + ', ' + ISNULL(ch.CONT_STATE,'') + ' ' + ISNULL(ch.CONT_ZIP,'')
			ELSE ISNULL(a.CITY,'') + ', ' + ISNULL(a.[STATE],'') + ' ' + ISNULL(a.ZIP,'')
		END AS ADDR_CSZ,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ISNULL(ch.CONT_FNAME,'') + ' ' + ISNULL(ch.CONT_MI,'') + ' ' + ISNULL(ch.CONT_LNAME,'')
			ELSE a.ATTENTION
		END AS ADDR_ATTENTION,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_COUNTY
			ELSE a.COUNTY
		END AS ADDR_COUNTY,
		CASE def.ADDRESS_BLOCK
			WHEN 4 THEN	ch.CONT_COUNTRY
			ELSE a.COUNTRY
		END AS ADDR_COUNTRY,
		CASE
			WHEN def.PRT_LOC_PG_FTR = 2 AND l.PRT_HDR = 1 THEN l.LOC_HDR 
			ELSE NULL
		END	AS LOCATION_ADDR_HEADER,
		CASE
			WHEN def.PRT_LOC_PG_FTR = 2 AND l.PRT_FTR = 1 THEN l.LOC_FTR 
			ELSE NULL
		END AS LOCATION_ADDR_FOOTER,
		l.DFLT_LOGO_PATH AS LOCATION_LOGO_HDR_PATH,
		l.DFLT_LOGO_PATH_2 AS LOCATION_IMAGE_FTR_PATH,
		ISNULL(dbo.advfn_std_comment_comment('Invoices', 'Standard Footer', d.OFFICE_CODE, d.CL_CODE, d.DIV_CODE, d.PRD_CODE),
			c.CL_FOOTER) AS INV_STD_FTR_COMMENT,
		ISNULL(dbo.advfn_std_comment_font_size('Invoices', 'Standard Footer', d.OFFICE_CODE, d.CL_CODE, d.DIV_CODE, d.PRD_CODE),
			10) AS INV_STD_COMMENT_FONT_SIZE
		
	FROM dbo.PROD_BILLING_DATA AS d
	JOIN dbo.RPT_RUNTIME_SPECS AS s
		ON d.[USER_ID] = s.[USER_ID]
		AND d.APP_TYPE =s.APP_TYPE	
	JOIN dbo.V_PROD_INV_DEF AS def
		ON d.CL_CODE = def.CL_CODE
	LEFT JOIN dbo.advtf_location_query() AS l
		ON def.PRT_LOC_PG_FTR_DEF = l.LOC_ID
	JOIN dbo.V_AR_INVOICE_DUE_DATES AS dd
		ON d.AR_INV_NBR = dd.AR_INV_NBR
		AND d.AR_TYPE = dd.AR_TYPE
	JOIN dbo.FUNCTIONS AS f
		ON d.FNC_CODE = f.FNC_CODE
	LEFT JOIN dbo.FUNCTIONS AS f2
		ON f.FNC_CONSOLIDATION = f2.FNC_CODE
	LEFT JOIN dbo.FNC_HEADING fh 
		ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID
	JOIN dbo.V_JOB_COMP_EST_HDR_INFO AS h
		ON d.JOB_NUMBER = h.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = h.JOB_COMPONENT_NBR
	LEFT JOIN dbo.V_BILL_COMMENT AS cb
		ON d.AR_INV_NBR = cb.AR_INV_NBR
	LEFT JOIN dbo.BILL_COMMENTS_JOB AS cj
		ON d.AR_INV_NBR = cj.INV_NBR
		AND d.JOB_NUMBER = cj.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = cj.JOB_COMPONENT_NBR	
	LEFT JOIN dbo.BILL_COMMENTS_DTL AS cd
		ON d.AR_INV_NBR = cd.INV_NBR
		AND d.JOB_NUMBER = cd.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = cd.JOB_COMPONENT_NBR
		AND d.STD_FNC_CODE = cd.FNC_CODE
	LEFT JOIN dbo.V_BA_COMMENT_HDR AS bah
		ON d.AR_INV_NBR = bah.AR_INV_NBR
		AND d.JOB_NUMBER = bah.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = bah.JOB_COMPONENT_NBR	
	LEFT JOIN dbo.V_BA_COMMENT_DTL AS bad
		ON d.AR_INV_NBR = bad.AR_INV_NBR
		AND d.JOB_NUMBER = bad.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = bad.JOB_COMPONENT_NBR
		AND d.STD_FNC_CODE = bad.FNC_CODE
	JOIN dbo.V_PROD_BILLING_DATA_TAX_IND AS ti
		ON d.[USER_ID] = ti.[USER_ID]
		AND d.INVOICE_NUMBER = ti.INVOICE_NUMBER
		AND d.STD_FNC_CODE = ti.FNC_CODE
	JOIN dbo.V_PROD_BILLING_DATA_ZERO_AMT AS z
		ON d.[USER_ID] = z.[USER_ID]
		AND d.INVOICE_NUMBER = z.INVOICE_NUMBER
		AND d.JOB_NUMBER = z.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = z.JOB_COMPONENT_NBR
		AND d.STD_FNC_CODE = z.FNC_CODE	
	LEFT JOIN dbo.V_DTL_COMMENT_AP AS apc
		ON d.ITEM_ID = apc.AP_ID
		AND d.ITEM_LINE_NBR = apc.LINE_NUMBER
	LEFT JOIN dbo.V_DTL_COMMENT_ET AS etc
		ON d.JOB_NUMBER = etc.JOB_NUMBER
		AND d.JOB_COMPONENT_NBR = etc.JOB_COMPONENT_NBR		
		AND d.STD_FNC_CODE = etc.FNC_CODE
		AND d.ITEM_CODE = etc.EMP_CODE
		AND d.ITEM_DATE = etc.EMP_DATE	
	LEFT JOIN dbo.V_DTL_COMMENT_IO AS ioc
		ON d.ITEM_ID = ioc.IO_ID
	JOIN dbo.V_AR_ADDRESS_TABLE_PROD AS a
		ON d.CL_CODE = a.CL_CODE
		AND d.DIV_CODE = a.DIV_CODE
		AND d.PRD_CODE = a.PRD_CODE
	LEFT JOIN dbo.CDP_CONTACT_HDR AS ch
		ON h.CDP_CONTACT_ID = ch.CDP_CONTACT_ID
	LEFT JOIN dbo.EMPLOYEE_TITLE AS et
		ON d.EMPLOYEE_TITLE_ID = et.EMPLOYEE_TITLE_ID
	JOIN dbo.CLIENT AS c
		ON	d.CL_CODE = c.CL_CODE
	WHERE dbo.fn_AdvanUser() = def.[USER_ID]	
GO

