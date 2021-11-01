IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_media_inv_def]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_media_inv_def]
GO

CREATE PROCEDURE [dbo].[advsp_ar_media_inv_def] 
	@user_id varchar(100)
AS

/* NOT USED IN .Net AT THIS POINT */

IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END
-- =====================================================================
-- V_MEDIA_INV_DEF

-- #00 03/26/13 - initial version (copied from V_PROD_INV_DEF #02)before
-- #01 04/03/14 - set PRT_LOC_PG_FTR_DEF to NULL when PRT_LOC_PG_FTR = 1
-- #02 04/24/14 - set client default formats to "Client" (allow null, remove ISNULL to "Agency Default")
-- #03 04/30/14 - set PRT_LOC_PG_FTR_DEF to same as production, also fixed CUSTOM_FORMAT (#02)

-- RPT_RUNTIME_SPECS.ONE_TIME - 0 = Use Agency/Client Default, 1 = Use One Time Only
-- PROD_INV_DEF.CLIENT_OR_DEF - 0 = One Time Only, 1 = Agency Default, 2 = Client Default Overide
-- =====================================================================

--SELECT * FROM V_MEDIA_INV_DEF

SELECT 
	@user_id AS [USER_ID],
	rs.ONE_TIME,
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.CLIENT_OR_DEF, a.CLIENT_OR_DEF)
		ELSE o.CLIENT_OR_DEF
	END AS CLIENT_OR_DEF,	
	cl.CL_CODE ,                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.LOCATION_ID, a.LOCATION_ID)
		ELSE o.LOCATION_ID
	END AS LOCATION_ID,	                                                                                                                                                                                                                                             
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.LOGO_PATH, a.LOGO_PATH)
		ELSE o.LOGO_PATH
	END AS LOGO_PATH,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRT_LOC_PG_FTR, a.PRT_LOC_PG_FTR)
		ELSE o.PRT_LOC_PG_FTR
	END AS PRT_LOC_PG_FTR, 	                                                                                                                                                                                                                                                                                   
	--CASE 														
	--	WHEN rs.ONE_TIME = 0 AND ISNULL(c.PRT_LOC_PG_FTR,1) = 1 THEN NULL 				--#01
	--	WHEN rs.ONE_TIME = 0 AND ISNULL(c.PRT_LOC_PG_FTR,1) = 2 THEN ISNULL(c.PRT_LOC_PG_FTR_DEF, a.PRT_LOC_PG_FTR_DEF)
	--	ELSE o.PRT_LOC_PG_FTR_DEF
	--END AS PRT_LOC_PG_FTR_DEF,                                                                                                                                                                                                                                                                                    
	CASE																								--#03, #01
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL AND c.PRT_LOC_PG_FTR = 1 THEN NULL
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL AND a.PRT_LOC_PG_FTR = 1 THEN NULL
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL AND c.PRT_LOC_PG_FTR = 2 THEN c.PRT_LOC_PG_FTR_DEF
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL AND a.PRT_LOC_PG_FTR = 2 THEN a.PRT_LOC_PG_FTR_DEF
		WHEN rs.ONE_TIME = 1 THEN o.PRT_LOC_PG_FTR_DEF
	END AS PRT_LOC_PG_FTR_DEF,                                                                                                                                                                                                                                                               
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.ADDRESS_BLOCK, a.ADDRESS_BLOCK)
		ELSE o.ADDRESS_BLOCK
	END AS ADDRESS_BLOCK,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRINT_DIV_NAME, a.PRINT_DIV_NAME)
		ELSE o.PRINT_DIV_NAME
	END AS PRINT_DIV_NAME,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRINT_PRD_DESC, a.PRINT_PRD_DESC)
		ELSE o.PRINT_PRD_DESC
	END AS PRINT_PRD_DESC,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BILL_COMM_INV_INCL, a.BILL_COMM_INV_INCL)
		ELSE o.BILL_COMM_INV_INCL
	END AS BILL_COMM_INV_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.MEDIA_TYPE_INCL, a.MEDIA_TYPE_INCL)
		ELSE o.MEDIA_TYPE_INCL
	END AS MEDIA_TYPE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_CMP_INCL, a.INV_CMP_INCL)
		ELSE o.INV_CMP_INCL
	END AS INV_CMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_PAYMNT_TERMS, a.TOT_PAYMNT_TERMS)
		ELSE o.TOT_PAYMNT_TERMS
	END AS TOT_PAYMNT_TERMS,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_PAYMNT_TERMS_DEF, a.TOT_PAYMNT_TERMS_DEF)
		ELSE o.TOT_PAYMNT_TERMS_DEF
	END AS TOT_PAYMNT_TERMS_DEF,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPT_XCHGE_AMTS, a.COL_OPT_XCHGE_AMTS)
		ELSE o.COL_OPT_XCHGE_AMTS
	END AS COL_OPT_XCHGE_AMTS,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPT_XCHGE_DEF, a.COL_OPT_XCHGE_DEF)
		ELSE o.COL_OPT_XCHGE_DEF
	END AS COL_OPT_XCHGE_DEF,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.CUSTOM_FORMAT, a.CUSTOM_FORMAT)
		ELSE o.CUSTOM_FORMAT
	END AS CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.CONTACT_POS, a.CONTACT_POS)
		ELSE o.CONTACT_POS
	END AS CONTACT_POS,
	
	--MAGAZINE                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_GROUP_BY_MKT, a.M_GROUP_BY_MKT)
		ELSE o.M_GROUP_BY_MKT
	END AS M_GROUP_BY_MKT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_ORDER_DESC_INCL, a.M_ORDER_DESC_INCL)
		ELSE o.M_ORDER_DESC_INCL
	END AS M_ORDER_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_INV_REF_INCL, a.M_INV_REF_INCL)
		ELSE o.M_INV_REF_INCL
	END AS M_INV_REF_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_INV_CL_PO_INCL, a.M_INV_CL_PO_INCL)
		ELSE o.M_INV_CL_PO_INCL
	END AS M_INV_CL_PO_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_ORDER_COMM_INCL, a.M_ORDER_COMM_INCL)
		ELSE o.M_ORDER_COMM_INCL
	END AS M_ORDER_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_HOUSE_COMM_INCL, a.M_HOUSE_COMM_INCL)
		ELSE o.M_HOUSE_COMM_INCL
	END AS M_HOUSE_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_SHOW_LINE_DTL, a.M_SHOW_LINE_DTL)
		ELSE o.M_SHOW_LINE_DTL
	END AS M_SHOW_LINE_DTL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_ORDER_NBR_INCL, a.M_ORDER_NBR_INCL)
		ELSE o.M_ORDER_NBR_INCL
	END AS M_ORDER_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_VN_NAME_INCL, a.M_VN_NAME_INCL)
		ELSE o.M_VN_NAME_INCL
	END AS M_VN_NAME_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_VN_CODE_INCL, a.M_VN_CODE_INCL)
		ELSE o.M_VN_CODE_INCL
	END AS M_VN_CODE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_MONTHS_INCL, a.M_MONTHS_INCL)
		ELSE o.M_MONTHS_INCL
	END AS M_MONTHS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_PROG_HDLN_INCL, a.M_PROG_HDLN_INCL)
		ELSE o.M_PROG_HDLN_INCL
	END AS M_PROG_HDLN_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_DATES_INCL, a.M_DATES_INCL)
		ELSE o.M_DATES_INCL
	END AS M_DATES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_LGH_MATL_INCL, a.M_LGH_MATL_INCL)
		ELSE o.M_LGH_MATL_INCL
	END AS M_LGH_MATL_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_TAG_AD_NBR_INCL, a.M_TAG_AD_NBR_INCL)
		ELSE o.M_TAG_AD_NBR_INCL
	END AS M_TAG_AD_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_TIME_EDIT_INCL, a.M_TIME_EDIT_INCL)
		ELSE o.M_TIME_EDIT_INCL
	END AS M_TIME_EDIT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_AD_SIZE_INCL, a.M_AD_SIZE_INCL)
		ELSE o.M_AD_SIZE_INCL
	END AS M_AD_SIZE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_JOB_COMP_INCL, a.M_JOB_COMP_INCL)
		ELSE o.M_JOB_COMP_INCL
	END AS M_JOB_COMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_JOB_DESC_INCL, a.M_JOB_DESC_INCL)
		ELSE o.M_JOB_DESC_INCL
	END AS M_JOB_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_COMP_DESC_INCL, a.M_COMP_DESC_INCL)
		ELSE o.M_COMP_DESC_INCL
	END AS M_COMP_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_ORD_DTL_CMT_INCL, a.M_ORD_DTL_CMT_INCL)
		ELSE o.M_ORD_DTL_CMT_INCL
	END AS M_ORD_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_HSE_DTL_CMT_INCL, a.M_HSE_DTL_CMT_INCL)
		ELSE o.M_HSE_DTL_CMT_INCL
	END AS M_HSE_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_SHOW_CHARGES_INCL, a.M_SHOW_CHARGES_INCL)
		ELSE o.M_SHOW_CHARGES_INCL
	END AS M_SHOW_CHARGES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_CUR_NET_AMT_INCL, a.M_CUR_NET_AMT_INCL)
		ELSE o.M_CUR_NET_AMT_INCL
	END AS M_CUR_NET_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_CUR_COMM_AMT_INCL, a.M_CUR_COMM_AMT_INCL)
		ELSE o.M_CUR_COMM_AMT_INCL
	END AS M_CUR_COMM_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_CUR_TAX_AMT_INCL, a.M_CUR_TAX_AMT_INCL)
		ELSE o.M_CUR_TAX_AMT_INCL
	END AS M_CUR_TAX_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_CUR_BILL_AMT_INCL, a.M_CUR_BILL_AMT_INCL)
		ELSE o.M_CUR_BILL_AMT_INCL
	END AS M_CUR_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_PREV_BILL_AMT_INCL, a.M_PREV_BILL_AMT_INCL)
		ELSE o.M_PREV_BILL_AMT_INCL
	END AS M_PREV_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_TOT_BILL_AMT_INCL, a.M_TOT_BILL_AMT_INCL)
		ELSE o.M_TOT_BILL_AMT_INCL
	END AS M_TOT_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_SHOW_COMM, a.M_SHOW_COMM)
		ELSE o.M_SHOW_COMM
	END AS M_SHOW_COMM,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_SHOW_REBATE, a.M_SHOW_REBATE)
		ELSE o.M_SHOW_REBATE
	END AS M_SHOW_REBATE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_SHOW_TAX, a.M_SHOW_TAX)
		ELSE o.M_SHOW_TAX
	END AS M_SHOW_TAX,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_TOT_SHOW_BILL_HIST, a.M_TOT_SHOW_BILL_HIST)
		ELSE o.M_TOT_SHOW_BILL_HIST
	END AS M_TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                                     
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.M_CUSTOM_FORMAT, a.M_CUSTOM_FORMAT)		--#04, #02
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.M_CUSTOM_FORMAT
		ELSE o.M_CUSTOM_FORMAT
	END AS M_CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_INV_TITLE, a.M_INV_TITLE)
		ELSE o.M_INV_TITLE
	END AS M_INV_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_INV_CAT_TITLE, a.M_INV_CAT_TITLE)
		ELSE o.M_INV_CAT_TITLE
	END AS M_INV_CAT_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.M_PRT_DUE_DATE, a.M_PRT_DUE_DATE)
		ELSE o.M_PRT_DUE_DATE
	END AS M_PRT_DUE_DATE,
	
	--NEWSPAPER                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_GROUP_BY_MKT, a.N_GROUP_BY_MKT)
		ELSE o.N_GROUP_BY_MKT
	END AS N_GROUP_BY_MKT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_ORDER_DESC_INCL, a.N_ORDER_DESC_INCL)
		ELSE o.N_ORDER_DESC_INCL
	END AS N_ORDER_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_INV_REF_INCL, a.N_INV_REF_INCL)
		ELSE o.N_INV_REF_INCL
	END AS N_INV_REF_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_INV_CL_PO_INCL, a.N_INV_CL_PO_INCL)
		ELSE o.N_INV_CL_PO_INCL
	END AS N_INV_CL_PO_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_ORDER_COMM_INCL, a.N_ORDER_COMM_INCL)
		ELSE o.N_ORDER_COMM_INCL
	END AS N_ORDER_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_HOUSE_COMM_INCL, a.N_HOUSE_COMM_INCL)
		ELSE o.N_HOUSE_COMM_INCL
	END AS N_HOUSE_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SHOW_LINE_DTL, a.N_SHOW_LINE_DTL)
		ELSE o.N_SHOW_LINE_DTL
	END AS N_SHOW_LINE_DTL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_ORDER_NBR_INCL, a.N_ORDER_NBR_INCL)
		ELSE o.N_ORDER_NBR_INCL
	END AS N_ORDER_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_VN_NAME_INCL, a.N_VN_NAME_INCL)
		ELSE o.N_VN_NAME_INCL
	END AS N_VN_NAME_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_VN_CODE_INCL, a.N_VN_CODE_INCL)
		ELSE o.N_VN_CODE_INCL
	END AS N_VN_CODE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_MONTHS_INCL, a.N_MONTHS_INCL)
		ELSE o.N_MONTHS_INCL
	END AS N_MONTHS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_PROG_HDLN_INCL, a.N_PROG_HDLN_INCL)
		ELSE o.N_PROG_HDLN_INCL
	END AS N_PROG_HDLN_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_DATES_INCL, a.N_DATES_INCL)
		ELSE o.N_DATES_INCL
	END AS N_DATES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_LGH_MATL_INCL, a.N_LGH_MATL_INCL)
		ELSE o.N_LGH_MATL_INCL
	END AS N_LGH_MATL_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_TAG_AD_NBR_INCL, a.N_TAG_AD_NBR_INCL)
		ELSE o.N_TAG_AD_NBR_INCL
	END AS N_TAG_AD_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_TIME_EDIT_INCL, a.N_TIME_EDIT_INCL)
		ELSE o.N_TIME_EDIT_INCL
	END AS N_TIME_EDIT_INCL,                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SECTION_INCL, a.N_SECTION_INCL)
		ELSE o.N_SECTION_INCL
	END AS N_SECTION_INCL,                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SPOTS_QTY_INCL, a.N_SPOTS_QTY_INCL)
		ELSE o.N_SPOTS_QTY_INCL
	END AS N_SPOTS_QTY_INCL,                                                                                                                                                                                                                        
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_AD_SIZE_INCL, a.N_AD_SIZE_INCL)
		ELSE o.N_AD_SIZE_INCL
	END AS N_AD_SIZE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_JOB_COMP_INCL, a.N_JOB_COMP_INCL)
		ELSE o.N_JOB_COMP_INCL
	END AS N_JOB_COMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_JOB_DESC_INCL, a.N_JOB_DESC_INCL)
		ELSE o.N_JOB_DESC_INCL
	END AS N_JOB_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_COMP_DESC_INCL, a.N_COMP_DESC_INCL)
		ELSE o.N_COMP_DESC_INCL
	END AS N_COMP_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_ORD_DTL_CMT_INCL, a.N_ORD_DTL_CMT_INCL)
		ELSE o.N_ORD_DTL_CMT_INCL
	END AS N_ORD_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_HSE_DTL_CMT_INCL, a.N_HSE_DTL_CMT_INCL)
		ELSE o.N_HSE_DTL_CMT_INCL
	END AS N_HSE_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SHOW_CHARGES_INCL, a.N_SHOW_CHARGES_INCL)
		ELSE o.N_SHOW_CHARGES_INCL
	END AS N_SHOW_CHARGES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_CUR_NET_AMT_INCL, a.N_CUR_NET_AMT_INCL)
		ELSE o.N_CUR_NET_AMT_INCL
	END AS N_CUR_NET_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_CUR_COMM_AMT_INCL, a.N_CUR_COMM_AMT_INCL)
		ELSE o.N_CUR_COMM_AMT_INCL
	END AS N_CUR_COMM_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_CUR_TAX_AMT_INCL, a.N_CUR_TAX_AMT_INCL)
		ELSE o.N_CUR_TAX_AMT_INCL
	END AS N_CUR_TAX_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_CUR_BILL_AMT_INCL, a.N_CUR_BILL_AMT_INCL)
		ELSE o.N_CUR_BILL_AMT_INCL
	END AS N_CUR_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_PREV_BILL_AMT_INCL, a.N_PREV_BILL_AMT_INCL)
		ELSE o.N_PREV_BILL_AMT_INCL
	END AS N_PREV_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_TOT_BILL_AMT_INCL, a.N_TOT_BILL_AMT_INCL)
		ELSE o.N_TOT_BILL_AMT_INCL
	END AS N_TOT_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SHOW_COMM, a.N_SHOW_COMM)
		ELSE o.N_SHOW_COMM
	END AS N_SHOW_COMM,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SHOW_REBATE, a.N_SHOW_REBATE)
		ELSE o.N_SHOW_REBATE
	END AS N_SHOW_REBATE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_SHOW_TAX, a.N_SHOW_TAX)
		ELSE o.N_SHOW_TAX
	END AS N_SHOW_TAX,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_TOT_SHOW_BILL_HIST, a.N_TOT_SHOW_BILL_HIST)
		ELSE o.N_TOT_SHOW_BILL_HIST
	END AS N_TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                                     
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.N_CUSTOM_FORMAT, a.N_CUSTOM_FORMAT)		--#04, #02
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.N_CUSTOM_FORMAT
		ELSE o.N_CUSTOM_FORMAT
	END AS N_CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_INV_TITLE, a.N_INV_TITLE)
		ELSE o.N_INV_TITLE
	END AS N_INV_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_INV_CAT_TITLE, a.N_INV_CAT_TITLE)
		ELSE o.N_INV_CAT_TITLE
	END AS N_INV_CAT_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.N_PRT_DUE_DATE, a.N_PRT_DUE_DATE)
		ELSE o.N_PRT_DUE_DATE
	END AS N_PRT_DUE_DATE,
	
	--INTERNET                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_GROUP_BY_MKT, a.I_GROUP_BY_MKT)
		ELSE o.I_GROUP_BY_MKT
	END AS I_GROUP_BY_MKT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_ORDER_DESC_INCL, a.I_ORDER_DESC_INCL)
		ELSE o.I_ORDER_DESC_INCL
	END AS I_ORDER_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_INV_REF_INCL, a.I_INV_REF_INCL)
		ELSE o.I_INV_REF_INCL
	END AS I_INV_REF_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_INV_CL_PO_INCL, a.I_INV_CL_PO_INCL)
		ELSE o.I_INV_CL_PO_INCL
	END AS I_INV_CL_PO_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_ORDER_COMM_INCL, a.I_ORDER_COMM_INCL)
		ELSE o.I_ORDER_COMM_INCL
	END AS I_ORDER_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_HOUSE_COMM_INCL, a.I_HOUSE_COMM_INCL)
		ELSE o.I_HOUSE_COMM_INCL
	END AS I_HOUSE_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_SHOW_LINE_DTL, a.I_SHOW_LINE_DTL)
		ELSE o.I_SHOW_LINE_DTL
	END AS I_SHOW_LINE_DTL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_ORDER_NBR_INCL, a.I_ORDER_NBR_INCL)
		ELSE o.I_ORDER_NBR_INCL
	END AS I_ORDER_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_VN_NAME_INCL, a.I_VN_NAME_INCL)
		ELSE o.I_VN_NAME_INCL
	END AS I_VN_NAME_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_VN_CODE_INCL, a.I_VN_CODE_INCL)
		ELSE o.I_VN_CODE_INCL
	END AS I_VN_CODE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_MONTHS_INCL, a.I_MONTHS_INCL)
		ELSE o.I_MONTHS_INCL
	END AS I_MONTHS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_PROG_HDLN_INCL, a.I_PROG_HDLN_INCL)
		ELSE o.I_PROG_HDLN_INCL
	END AS I_PROG_HDLN_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_DATES_INCL, a.I_DATES_INCL)
		ELSE o.I_DATES_INCL
	END AS I_DATES_INCL,                                                                                                                                                                                                                               
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_START_DATE_INCL, a.I_START_DATE_INCL)
		ELSE o.I_START_DATE_INCL
	END AS I_START_DATE_INCL,                                                                                                                                                                                                                        
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_LGH_MATL_INCL, a.I_LGH_MATL_INCL)
		ELSE o.I_LGH_MATL_INCL
	END AS I_LGH_MATL_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_TAG_AD_NBR_INCL, a.I_TAG_AD_NBR_INCL)
		ELSE o.I_TAG_AD_NBR_INCL
	END AS I_TAG_AD_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_TIME_EDIT_INCL, a.I_TIME_EDIT_INCL)
		ELSE o.I_TIME_EDIT_INCL
	END AS I_TIME_EDIT_INCL,                                                                                                                                                                                                                            
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_SUB_TYPE_INCL, a.I_SUB_TYPE_INCL)
		ELSE o.I_SUB_TYPE_INCL
	END AS I_SUB_TYPE_INCL,                                                                                                                                                                                                                              
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_JOB_COMP_INCL, a.I_JOB_COMP_INCL)
		ELSE o.I_JOB_COMP_INCL
	END AS I_JOB_COMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_JOB_DESC_INCL, a.I_JOB_DESC_INCL)
		ELSE o.I_JOB_DESC_INCL
	END AS I_JOB_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_COMP_DESC_INCL, a.I_COMP_DESC_INCL)
		ELSE o.I_COMP_DESC_INCL
	END AS I_COMP_DESC_INCL,                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_SHOW_CHARGES_INCL, a.I_SHOW_CHARGES_INCL)
		ELSE o.I_SHOW_CHARGES_INCL
	END AS I_SHOW_CHARGES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_CUR_NET_AMT_INCL, a.I_CUR_NET_AMT_INCL)
		ELSE o.I_CUR_NET_AMT_INCL
	END AS I_CUR_NET_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_CUR_COMM_AMT_INCL, a.I_CUR_COMM_AMT_INCL)
		ELSE o.I_CUR_COMM_AMT_INCL
	END AS I_CUR_COMM_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_CUR_TAX_AMT_INCL, a.I_CUR_TAX_AMT_INCL)
		ELSE o.I_CUR_TAX_AMT_INCL
	END AS I_CUR_TAX_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_CUR_BILL_AMT_INCL, a.I_CUR_BILL_AMT_INCL)
		ELSE o.I_CUR_BILL_AMT_INCL
	END AS I_CUR_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_PREV_BILL_AMT_INCL, a.I_PREV_BILL_AMT_INCL)
		ELSE o.I_PREV_BILL_AMT_INCL
	END AS I_PREV_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_TOT_BILL_AMT_INCL, a.I_TOT_BILL_AMT_INCL)
		ELSE o.I_TOT_BILL_AMT_INCL
	END AS I_TOT_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_SHOW_COMM, a.I_SHOW_COMM)
		ELSE o.I_SHOW_COMM
	END AS I_SHOW_COMM,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_SHOW_REBATE, a.I_SHOW_REBATE)
		ELSE o.I_SHOW_REBATE
	END AS I_SHOW_REBATE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_SHOW_TAX, a.I_SHOW_TAX)
		ELSE o.I_SHOW_TAX
	END AS I_SHOW_TAX,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_TOT_SHOW_BILL_HIST, a.I_TOT_SHOW_BILL_HIST)
		ELSE o.I_TOT_SHOW_BILL_HIST
	END AS I_TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                                     
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.I_CUSTOM_FORMAT, a.I_CUSTOM_FORMAT)		--#04, #02
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.I_CUSTOM_FORMAT
		ELSE o.I_CUSTOM_FORMAT
	END AS I_CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_INV_TITLE, a.I_INV_TITLE)
		ELSE o.I_INV_TITLE
	END AS I_INV_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_INV_CAT_TITLE, a.I_INV_CAT_TITLE)
		ELSE o.I_INV_CAT_TITLE
	END AS I_INV_CAT_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.I_PRT_DUE_DATE, a.I_PRT_DUE_DATE)
		ELSE o.I_PRT_DUE_DATE
	END AS I_PRT_DUE_DATE,
	
	--OUTDOOR                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_GROUP_BY_MKT, a.O_GROUP_BY_MKT)
		ELSE o.O_GROUP_BY_MKT
	END AS O_GROUP_BY_MKT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_ORDER_DESC_INCL, a.O_ORDER_DESC_INCL)
		ELSE o.O_ORDER_DESC_INCL
	END AS O_ORDER_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_INV_REF_INCL, a.O_INV_REF_INCL)
		ELSE o.O_INV_REF_INCL
	END AS O_INV_REF_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_INV_CL_PO_INCL, a.O_INV_CL_PO_INCL)
		ELSE o.O_INV_CL_PO_INCL
	END AS O_INV_CL_PO_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_ORDER_COMM_INCL, a.O_ORDER_COMM_INCL)
		ELSE o.O_ORDER_COMM_INCL
	END AS O_ORDER_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_HOUSE_COMM_INCL, a.O_HOUSE_COMM_INCL)
		ELSE o.O_HOUSE_COMM_INCL
	END AS O_HOUSE_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_SHOW_LINE_DTL, a.O_SHOW_LINE_DTL)
		ELSE o.O_SHOW_LINE_DTL
	END AS O_SHOW_LINE_DTL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_ORDER_NBR_INCL, a.O_ORDER_NBR_INCL)
		ELSE o.O_ORDER_NBR_INCL
	END AS O_ORDER_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_VN_NAME_INCL, a.O_VN_NAME_INCL)
		ELSE o.O_VN_NAME_INCL
	END AS O_VN_NAME_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_VN_CODE_INCL, a.O_VN_CODE_INCL)
		ELSE o.O_VN_CODE_INCL
	END AS O_VN_CODE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_MONTHS_INCL, a.O_MONTHS_INCL)
		ELSE o.O_MONTHS_INCL
	END AS O_MONTHS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_PROG_HDLN_INCL, a.O_PROG_HDLN_INCL)
		ELSE o.O_PROG_HDLN_INCL
	END AS O_PROG_HDLN_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_DATES_INCL, a.O_DATES_INCL)
		ELSE o.O_DATES_INCL
	END AS O_DATES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_LGH_MATL_INCL, a.O_LGH_MATL_INCL)
		ELSE o.O_LGH_MATL_INCL
	END AS O_LGH_MATL_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_TAG_AD_NBR_INCL, a.O_TAG_AD_NBR_INCL)
		ELSE o.O_TAG_AD_NBR_INCL
	END AS O_TAG_AD_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_TIME_EDIT_INCL, a.O_TIME_EDIT_INCL)
		ELSE o.O_TIME_EDIT_INCL
	END AS O_TIME_EDIT_INCL,                                                                                                                                                                                                                           
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_SUB_TYPE_INCL, a.O_SUB_TYPE_INCL)
		ELSE o.O_SUB_TYPE_INCL
	END AS O_SUB_TYPE_INCL,                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_AD_SIZE_INCL, a.O_AD_SIZE_INCL)
		ELSE o.O_AD_SIZE_INCL
	END AS O_AD_SIZE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_JOB_COMP_INCL, a.O_JOB_COMP_INCL)
		ELSE o.O_JOB_COMP_INCL
	END AS O_JOB_COMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_JOB_DESC_INCL, a.O_JOB_DESC_INCL)
		ELSE o.O_JOB_DESC_INCL
	END AS O_JOB_DESC_INCL,                                                                                                                                                                                                                                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_COMP_DESC_INCL, a.O_COMP_DESC_INCL)
		ELSE o.O_COMP_DESC_INCL
	END AS O_COMP_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_SHOW_CHARGES_INCL, a.O_SHOW_CHARGES_INCL)
		ELSE o.O_SHOW_CHARGES_INCL
	END AS O_SHOW_CHARGES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_CUR_NET_AMT_INCL, a.O_CUR_NET_AMT_INCL)
		ELSE o.O_CUR_NET_AMT_INCL
	END AS O_CUR_NET_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_CUR_COMM_AMT_INCL, a.O_CUR_COMM_AMT_INCL)
		ELSE o.O_CUR_COMM_AMT_INCL
	END AS O_CUR_COMM_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_CUR_TAX_AMT_INCL, a.O_CUR_TAX_AMT_INCL)
		ELSE o.O_CUR_TAX_AMT_INCL
	END AS O_CUR_TAX_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_CUR_BILL_AMT_INCL, a.O_CUR_BILL_AMT_INCL)
		ELSE o.O_CUR_BILL_AMT_INCL
	END AS O_CUR_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_PREV_BILL_AMT_INCL, a.O_PREV_BILL_AMT_INCL)
		ELSE o.O_PREV_BILL_AMT_INCL
	END AS O_PREV_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_TOT_BILL_AMT_INCL, a.O_TOT_BILL_AMT_INCL)
		ELSE o.O_TOT_BILL_AMT_INCL
	END AS O_TOT_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_SHOW_COMM, a.O_SHOW_COMM)
		ELSE o.O_SHOW_COMM
	END AS O_SHOW_COMM,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_SHOW_REBATE, a.O_SHOW_REBATE)
		ELSE o.O_SHOW_REBATE
	END AS O_SHOW_REBATE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_SHOW_TAX, a.O_SHOW_TAX)
		ELSE o.O_SHOW_TAX
	END AS O_SHOW_TAX,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_TOT_SHOW_BILL_HIST, a.O_TOT_SHOW_BILL_HIST)
		ELSE o.O_TOT_SHOW_BILL_HIST
	END AS O_TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                                     
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.O_CUSTOM_FORMAT, a.O_CUSTOM_FORMAT)		--#04, #02
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.O_CUSTOM_FORMAT
		ELSE o.O_CUSTOM_FORMAT
	END AS O_CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_INV_TITLE, a.O_INV_TITLE)
		ELSE o.O_INV_TITLE
	END AS O_INV_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_INV_CAT_TITLE, a.O_INV_CAT_TITLE)
		ELSE o.O_INV_CAT_TITLE
	END AS O_INV_CAT_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.O_PRT_DUE_DATE, a.O_PRT_DUE_DATE)
		ELSE o.O_PRT_DUE_DATE
	END AS O_PRT_DUE_DATE,
	
	--RADIO                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_GROUP_BY_MKT, a.R_GROUP_BY_MKT)
		ELSE o.R_GROUP_BY_MKT
	END AS R_GROUP_BY_MKT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_ORDER_DESC_INCL, a.R_ORDER_DESC_INCL)
		ELSE o.R_ORDER_DESC_INCL
	END AS R_ORDER_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_INV_REF_INCL, a.R_INV_REF_INCL)
		ELSE o.R_INV_REF_INCL
	END AS R_INV_REF_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_INV_CL_PO_INCL, a.R_INV_CL_PO_INCL)
		ELSE o.R_INV_CL_PO_INCL
	END AS R_INV_CL_PO_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_ORDER_COMM_INCL, a.R_ORDER_COMM_INCL)
		ELSE o.R_ORDER_COMM_INCL
	END AS R_ORDER_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_HOUSE_COMM_INCL, a.R_HOUSE_COMM_INCL)
		ELSE o.R_HOUSE_COMM_INCL
	END AS R_HOUSE_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_SHOW_LINE_DTL, a.R_SHOW_LINE_DTL)
		ELSE o.R_SHOW_LINE_DTL
	END AS R_SHOW_LINE_DTL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_ORDER_NBR_INCL, a.R_ORDER_NBR_INCL)
		ELSE o.R_ORDER_NBR_INCL
	END AS R_ORDER_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_VN_NAME_INCL, a.R_VN_NAME_INCL)
		ELSE o.R_VN_NAME_INCL
	END AS R_VN_NAME_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_VN_CODE_INCL, a.R_VN_CODE_INCL)
		ELSE o.R_VN_CODE_INCL
	END AS R_VN_CODE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_MONTHS_INCL, a.R_MONTHS_INCL)
		ELSE o.R_MONTHS_INCL
	END AS R_MONTHS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_PROG_HDLN_INCL, a.R_PROG_HDLN_INCL)
		ELSE o.R_PROG_HDLN_INCL
	END AS R_PROG_HDLN_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_DATES_INCL, a.R_DATES_INCL)
		ELSE o.R_DATES_INCL
	END AS R_DATES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_LGH_MATL_INCL, a.R_LGH_MATL_INCL)
		ELSE o.R_LGH_MATL_INCL
	END AS R_LGH_MATL_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_TAG_AD_NBR_INCL, a.R_TAG_AD_NBR_INCL)
		ELSE o.R_TAG_AD_NBR_INCL
	END AS R_TAG_AD_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_TIME_EDIT_INCL, a.R_TIME_EDIT_INCL)
		ELSE o.R_TIME_EDIT_INCL
	END AS R_TIME_EDIT_INCL,                                                                                                                                                                                                                         
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_SPOTS_QTY_INCL, a.R_SPOTS_QTY_INCL)
		ELSE o.R_SPOTS_QTY_INCL
	END AS R_SPOTS_QTY_INCL,                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_WEEKS_INCL, a.R_WEEKS_INCL)
		ELSE o.R_WEEKS_INCL
	END AS R_WEEKS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_REMARKS_INCL, a.R_REMARKS_INCL)
		ELSE o.R_REMARKS_INCL
	END AS R_REMARKS_INCL,                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_JOB_COMP_INCL, a.R_JOB_COMP_INCL)
		ELSE o.R_JOB_COMP_INCL
	END AS R_JOB_COMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_JOB_DESC_INCL, a.R_JOB_DESC_INCL)
		ELSE o.R_JOB_DESC_INCL
	END AS R_JOB_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_COMP_DESC_INCL, a.R_COMP_DESC_INCL)
		ELSE o.R_COMP_DESC_INCL
	END AS R_COMP_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_ORD_DTL_CMT_INCL, a.R_ORD_DTL_CMT_INCL)
		ELSE o.R_ORD_DTL_CMT_INCL
	END AS R_ORD_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_HSE_DTL_CMT_INCL, a.R_HSE_DTL_CMT_INCL)
		ELSE o.R_HSE_DTL_CMT_INCL
	END AS R_HSE_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_SHOW_CHARGES_INCL, a.R_SHOW_CHARGES_INCL)
		ELSE o.R_SHOW_CHARGES_INCL
	END AS R_SHOW_CHARGES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_CUR_NET_AMT_INCL, a.R_CUR_NET_AMT_INCL)
		ELSE o.R_CUR_NET_AMT_INCL
	END AS R_CUR_NET_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_CUR_COMM_AMT_INCL, a.R_CUR_COMM_AMT_INCL)
		ELSE o.R_CUR_COMM_AMT_INCL
	END AS R_CUR_COMM_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_CUR_TAX_AMT_INCL, a.R_CUR_TAX_AMT_INCL)
		ELSE o.R_CUR_TAX_AMT_INCL
	END AS R_CUR_TAX_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_CUR_BILL_AMT_INCL, a.R_CUR_BILL_AMT_INCL)
		ELSE o.R_CUR_BILL_AMT_INCL
	END AS R_CUR_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_PREV_BILL_AMT_INCL, a.R_PREV_BILL_AMT_INCL)
		ELSE o.R_PREV_BILL_AMT_INCL
	END AS R_PREV_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_TOT_BILL_AMT_INCL, a.R_TOT_BILL_AMT_INCL)
		ELSE o.R_TOT_BILL_AMT_INCL
	END AS R_TOT_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_SHOW_COMM, a.R_SHOW_COMM)
		ELSE o.R_SHOW_COMM
	END AS R_SHOW_COMM,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_SHOW_REBATE, a.R_SHOW_REBATE)
		ELSE o.R_SHOW_REBATE
	END AS R_SHOW_REBATE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_SHOW_TAX, a.R_SHOW_TAX)
		ELSE o.R_SHOW_TAX
	END AS R_SHOW_TAX,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_TOT_SHOW_BILL_HIST, a.R_TOT_SHOW_BILL_HIST)
		ELSE o.R_TOT_SHOW_BILL_HIST
	END AS R_TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                                     
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.R_CUSTOM_FORMAT, a.R_CUSTOM_FORMAT)		--#04, #02
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.R_CUSTOM_FORMAT
		ELSE o.R_CUSTOM_FORMAT
	END AS R_CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_INV_TITLE, a.R_INV_TITLE)
		ELSE o.R_INV_TITLE
	END AS R_INV_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_INV_CAT_TITLE, a.R_INV_CAT_TITLE)
		ELSE o.R_INV_CAT_TITLE
	END AS R_INV_CAT_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.R_PRT_DUE_DATE, a.R_PRT_DUE_DATE)
		ELSE o.R_PRT_DUE_DATE
	END AS R_PRT_DUE_DATE,
	
	--TELEVISION                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_GROUP_BY_MKT, a.T_GROUP_BY_MKT)
		ELSE o.T_GROUP_BY_MKT
	END AS T_GROUP_BY_MKT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_ORDER_DESC_INCL, a.T_ORDER_DESC_INCL)
		ELSE o.T_ORDER_DESC_INCL
	END AS T_ORDER_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_INV_REF_INCL, a.T_INV_REF_INCL)
		ELSE o.T_INV_REF_INCL
	END AS T_INV_REF_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_INV_CL_PO_INCL, a.T_INV_CL_PO_INCL)
		ELSE o.T_INV_CL_PO_INCL
	END AS T_INV_CL_PO_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_ORDER_COMM_INCL, a.T_ORDER_COMM_INCL)
		ELSE o.T_ORDER_COMM_INCL
	END AS T_ORDER_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_HOUSE_COMM_INCL, a.T_HOUSE_COMM_INCL)
		ELSE o.T_HOUSE_COMM_INCL
	END AS T_HOUSE_COMM_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_SHOW_LINE_DTL, a.T_SHOW_LINE_DTL)
		ELSE o.T_SHOW_LINE_DTL
	END AS T_SHOW_LINE_DTL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_ORDER_NBR_INCL, a.T_ORDER_NBR_INCL)
		ELSE o.T_ORDER_NBR_INCL
	END AS T_ORDER_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_VN_NAME_INCL, a.T_VN_NAME_INCL)
		ELSE o.T_VN_NAME_INCL
	END AS T_VN_NAME_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_VN_CODE_INCL, a.T_VN_CODE_INCL)
		ELSE o.T_VN_CODE_INCL
	END AS T_VN_CODE_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_MONTHS_INCL, a.T_MONTHS_INCL)
		ELSE o.T_MONTHS_INCL
	END AS T_MONTHS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_PROG_HDLN_INCL, a.T_PROG_HDLN_INCL)
		ELSE o.T_PROG_HDLN_INCL
	END AS T_PROG_HDLN_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_DATES_INCL, a.T_DATES_INCL)
		ELSE o.T_DATES_INCL
	END AS T_DATES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_LGH_MATL_INCL, a.T_LGH_MATL_INCL)
		ELSE o.T_LGH_MATL_INCL
	END AS T_LGH_MATL_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_TAG_AD_NBR_INCL, a.T_TAG_AD_NBR_INCL)
		ELSE o.T_TAG_AD_NBR_INCL
	END AS T_TAG_AD_NBR_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_TIME_EDIT_INCL, a.T_TIME_EDIT_INCL)
		ELSE o.T_TIME_EDIT_INCL
	END AS T_TIME_EDIT_INCL,                                                                                                                                                                                                                         
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_SPOTS_QTY_INCL, a.T_SPOTS_QTY_INCL)
		ELSE o.T_SPOTS_QTY_INCL
	END AS T_SPOTS_QTY_INCL,                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_WEEKS_INCL, a.T_WEEKS_INCL)
		ELSE o.T_WEEKS_INCL
	END AS T_WEEKS_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_REMARKS_INCL, a.T_REMARKS_INCL)
		ELSE o.T_REMARKS_INCL
	END AS T_REMARKS_INCL,                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_JOB_COMP_INCL, a.T_JOB_COMP_INCL)
		ELSE o.T_JOB_COMP_INCL
	END AS T_JOB_COMP_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_JOB_DESC_INCL, a.T_JOB_DESC_INCL)
		ELSE o.T_JOB_DESC_INCL
	END AS T_JOB_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_COMP_DESC_INCL, a.T_COMP_DESC_INCL)
		ELSE o.T_COMP_DESC_INCL
	END AS T_COMP_DESC_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_ORD_DTL_CMT_INCL, a.T_ORD_DTL_CMT_INCL)
		ELSE o.T_ORD_DTL_CMT_INCL
	END AS T_ORD_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_HSE_DTL_CMT_INCL, a.T_HSE_DTL_CMT_INCL)
		ELSE o.T_HSE_DTL_CMT_INCL
	END AS T_HSE_DTL_CMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_SHOW_CHARGES_INCL, a.T_SHOW_CHARGES_INCL)
		ELSE o.T_SHOW_CHARGES_INCL
	END AS T_SHOW_CHARGES_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_CUR_NET_AMT_INCL, a.T_CUR_NET_AMT_INCL)
		ELSE o.T_CUR_NET_AMT_INCL
	END AS T_CUR_NET_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_CUR_COMM_AMT_INCL, a.T_CUR_COMM_AMT_INCL)
		ELSE o.T_CUR_COMM_AMT_INCL
	END AS T_CUR_COMM_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_CUR_TAX_AMT_INCL, a.T_CUR_TAX_AMT_INCL)
		ELSE o.T_CUR_TAX_AMT_INCL
	END AS T_CUR_TAX_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_CUR_BILL_AMT_INCL, a.T_CUR_BILL_AMT_INCL)
		ELSE o.T_CUR_BILL_AMT_INCL
	END AS T_CUR_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_PREV_BILL_AMT_INCL, a.T_PREV_BILL_AMT_INCL)
		ELSE o.T_PREV_BILL_AMT_INCL
	END AS T_PREV_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_TOT_BILL_AMT_INCL, a.T_TOT_BILL_AMT_INCL)
		ELSE o.T_TOT_BILL_AMT_INCL
	END AS T_TOT_BILL_AMT_INCL,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_SHOW_COMM, a.T_SHOW_COMM)
		ELSE o.T_SHOW_COMM
	END AS T_SHOW_COMM,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_SHOW_REBATE, a.T_SHOW_REBATE)
		ELSE o.T_SHOW_REBATE
	END AS T_SHOW_REBATE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_SHOW_TAX, a.T_SHOW_TAX)
		ELSE o.T_SHOW_TAX
	END AS T_SHOW_TAX,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_TOT_SHOW_BILL_HIST, a.T_TOT_SHOW_BILL_HIST)
		ELSE o.T_TOT_SHOW_BILL_HIST
	END AS T_TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                                     
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.T_CUSTOM_FORMAT, a.T_CUSTOM_FORMAT)		--#04, #02
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.T_CUSTOM_FORMAT
		ELSE o.T_CUSTOM_FORMAT
	END AS T_CUSTOM_FORMAT,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_INV_TITLE, a.T_INV_TITLE)
		ELSE o.T_INV_TITLE
	END AS T_INV_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_INV_CAT_TITLE, a.T_INV_CAT_TITLE)
		ELSE o.T_INV_CAT_TITLE
	END AS T_INV_CAT_TITLE,                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.T_PRT_DUE_DATE, a.T_PRT_DUE_DATE)
		ELSE o.T_PRT_DUE_DATE
	END AS T_PRT_DUE_DATE        
FROM dbo.RPT_RUNTIME_SPECS AS rs
CROSS JOIN dbo.CLIENT AS cl
LEFT JOIN MEDIA_INV_DEF AS c
	ON cl.CL_CODE = c.CL_CODE
CROSS JOIN MEDIA_INV_DEF AS a
CROSS JOIN MEDIA_INV_DEF AS o
WHERE rs.APP_TYPE = 'MI'
	AND a.CLIENT_OR_DEF = 1
	AND	o.CLIENT_OR_DEF = 0
	AND rs.[USER_ID] = @user_id --dbo.fn_AdvanUser()
GO

GRANT EXECUTE ON [advsp_ar_media_inv_def] TO PUBLIC
GO