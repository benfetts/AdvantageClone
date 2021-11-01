IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advtf_ar_prod_inv_def]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advtf_ar_prod_inv_def]
END
GO

CREATE FUNCTION [dbo].[advtf_ar_prod_inv_def] 
	(@user_id varchar(100) = NULL)
	RETURNS Table
AS


-- =====================================================================
-- V_PROD_INV_DEF - was a view

-- #00 02/28/13 - initial version
-- #01 03/04/13 - returns table of Agency Def, Client Def or OTO values based on RPT_RUNTIME_SPEC
-- #02 03/14/13 - various modifications to date
-- #03 08/28/13 - fixed WHERE to o.CLIENT_OR_DEF from AND to OR
-- #04 08/29/13 - changed #03 fix back to the way it was before
-- #05 04/02/14 - set PRT_LOC_PG_FTR_DEF to NULL when PRT_LOC_PG_FTR = 1
-- #06 04/29/14 - fixed #05, was incorrectly setting PRT_LOC_PG_FTR_DEF to Null
-- #07 04/30/14 - fixed CUSTOM_FORMAT to be the same as media

-- RPT_RUNTIME_SPECS.ONE_TIME - 0 = Use Agency/Client Default, 1 = Use One Time Only
-- PROD_INV_DEF.CLIENT_OR_DEF - 0 =One Time Only, 1 = Agency Default, 2 = Client Default Overide
-- =====================================================================

RETURN
(
SELECT 
	UPPER(@user_id) AS [USER_ID], --dbo.78() AS [USER_ID],
	rs.ONE_TIME,
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.CLIENT_OR_DEF, a.CLIENT_OR_DEF)
		ELSE o.CLIENT_OR_DEF
	END AS CLIENT_OR_DEF,	
	cl.CL_CODE ,                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.DTL_BCKUP_RPT_INCL, a.DTL_BCKUP_RPT_INCL)
		ELSE o.DTL_BCKUP_RPT_INCL
	END AS DTL_BCKUP_RPT_INCL,                                                                                                                                                                                                                                            
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.LOGO_BLOCK_INCL, a.LOGO_BLOCK_INCL)
		ELSE o.LOGO_BLOCK_INCL
	END AS LOGO_BLOCK_INCL,                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.LOGO_PATH, a.LOGO_PATH)
		ELSE o.LOGO_PATH
	END AS LOGO_PATH,                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.ADDRESS_BLOCK, a.ADDRESS_BLOCK)
		ELSE o.ADDRESS_BLOCK
	END AS ADDRESS_BLOCK,                                                                                                                                                                                                                                                 
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.NAME_OVERIDE, a.NAME_OVERIDE)
		ELSE o.NAME_OVERIDE
	END AS NAME_OVERIDE,                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_REF_INCL, a.INV_REF_INCL)
		ELSE o.INV_REF_INCL
	END AS INV_REF_INCL,                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_USER_INCL, a.INV_USER_INCL)
		ELSE o.INV_USER_INCL
	END AS INV_USER_INCL,                                                                                                                                                                                                                                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_CL_PO_INCL, a.INV_CL_PO_INCL)
		ELSE o.INV_CL_PO_INCL
	END AS INV_CL_PO_INCL,                                                                                                                                                                                                                                                 
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_AE_INCL, a.INV_AE_INCL)
		ELSE o.INV_AE_INCL
	END AS INV_AE_INCL,                                                                                                                                                                                                                                                    
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_CLASS_INCL, a.INV_CLASS_INCL)
		ELSE o.INV_CLASS_INCL
	END AS INV_CLASS_INCL,                                                                                                                                                                                                                                                 
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BILL_COMM_INV_INCL, a.BILL_COMM_INV_INCL)
		ELSE o.BILL_COMM_INV_INCL
	END AS BILL_COMM_INV_INCL,                                                                                                                                                                                                                                             
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BILL_APPR_CL_COMM_INCL, a.BILL_APPR_CL_COMM_INCL)
		ELSE o.BILL_APPR_CL_COMM_INCL
	END AS BILL_APPR_CL_COMM_INCL,	                                                                                                                                                                                                                                         
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.JOB_COMM_INCL, a.JOB_COMM_INCL)
		ELSE o.JOB_COMM_INCL
	END AS JOB_COMM_INCL,	                                                                                                                                                                                                                                                                                       
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COMP_COMM_INCL, a.COMP_COMM_INCL)
		ELSE o.COMP_COMM_INCL
	END AS COMP_COMM_INCL,	                                                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.EST_COMM_INCL, a.EST_COMM_INCL)
		ELSE o.EST_COMM_INCL
	END AS EST_COMM_INCL,	                                                                                                                                                                                                                                                                                       
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.EST_COMP_COMM_INCL, a.EST_COMP_COMM_INCL)
		ELSE o.EST_COMP_COMM_INCL
	END AS EST_COMP_COMM_INCL,	                                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.EST_QTE_COMM_INCL, a.EST_QTE_COMM_INCL)
		ELSE o.EST_QTE_COMM_INCL
	END AS EST_QTE_COMM_INCL,	                                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.EST_REV_COMM_INCL, a.EST_REV_COMM_INCL)
		ELSE o.EST_REV_COMM_INCL
	END AS EST_REV_COMM_INCL,	                                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPTION, a.COL_OPTION)
		ELSE o.COL_OPTION
	END AS COL_OPTION,	                                                                                                                                                                                                                                                                                       
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPT_HRS, a.COL_OPT_HRS)
		ELSE o.COL_OPT_HRS
	END AS COL_OPT_HRS,	                                                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPT_QTY, a.COL_OPT_QTY)
		ELSE o.COL_OPT_QTY
	END AS COL_OPT_QTY,	                                                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPT_XCHGE_AMTS, a.COL_OPT_XCHGE_AMTS)
		ELSE o.COL_OPT_XCHGE_AMTS
	END AS COL_OPT_XCHGE_AMTS,	                                                                                                                                                                                                                                                                               
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COL_OPT_XCHGE_DEF, a.COL_OPT_XCHGE_DEF)
		ELSE o.COL_OPT_XCHGE_DEF
	END AS COL_OPT_XCHGE_DEF,	                                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.GRP_OPTION, a.GRP_OPTION)
		ELSE o.GRP_OPTION
	END AS GRP_OPTION,	                                                                                                                                                                                                                                                                                       
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.GRP_INSIDE_DESC, a.GRP_INSIDE_DESC)
		ELSE o.GRP_INSIDE_DESC
	END AS GRP_INSIDE_DESC,	                                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.GRP_OUTSIDE_DESC, a.GRP_OUTSIDE_DESC)
		ELSE o.GRP_OUTSIDE_DESC
	END AS GRP_OUTSIDE_DESC,	                                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.FNC_SORT_BY, a.FNC_SORT_BY)
		ELSE o.FNC_SORT_BY
	END AS FNC_SORT_BY,	                                                                                                                                                                                                                                                                                      
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.FNC_FNC_CODE, a.FNC_FNC_CODE)
		ELSE o.FNC_FNC_CODE
	END AS FNC_FNC_CODE,	                                                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.SHOW_FNC_DTL, a.SHOW_FNC_DTL)
		ELSE o.SHOW_FNC_DTL
	END AS SHOW_FNC_DTL,	                                                                                                                                                                                                                                                                                    
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.SHOW_ZERO_FNC, a.SHOW_ZERO_FNC)
		ELSE o.SHOW_ZERO_FNC
	END AS SHOW_ZERO_FNC,	                                                                                                                                                                                                                                                                                    
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.FNC_ET_FNC_COMM, a.FNC_ET_FNC_COMM)
		ELSE o.FNC_ET_FNC_COMM
	END AS FNC_ET_FNC_COMM,	                                                                                                                                                                                                                                                                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.FNC_AP_FNC_COMM, a.FNC_AP_FNC_COMM)
		ELSE o.FNC_AP_FNC_COMM
	END AS FNC_AP_FNC_COMM,	                                                                                                                                                                                                                                                                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.FNC_IO_FNC_COMM, a.FNC_IO_FNC_COMM)
		ELSE o.FNC_IO_FNC_COMM
	END AS FNC_IO_FNC_COMM,	                                                                                                                                                                                                                                                                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.FNC_BILL_APPR_CL_COMM, a.FNC_BILL_APPR_CL_COMM)
		ELSE o.FNC_BILL_APPR_CL_COMM
	END AS FNC_BILL_APPR_CL_COMM,	                                                                                                                                                                                                                                                                            
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_SHOW_COMM, a.TOT_SHOW_COMM)
		ELSE o.TOT_SHOW_COMM
	END AS TOT_SHOW_COMM,	                                                                                                                                                                                                                                                                                    
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_SHOW_TAX, a.TOT_SHOW_TAX)
		ELSE o.TOT_SHOW_TAX
	END AS TOT_SHOW_TAX,	                                                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_SHOW_BILL_HIST, a.TOT_SHOW_BILL_HIST)
		ELSE o.TOT_SHOW_BILL_HIST
	END AS TOT_SHOW_BILL_HIST,	                                                                                                                                                                                                                                                                               
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_PAYMNT_TERMS, a.TOT_PAYMNT_TERMS)
		ELSE o.TOT_PAYMNT_TERMS
	END AS TOT_PAYMNT_TERMS,	                                                                                                                                                                                                                                                                                 
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.TOT_PAYMNT_TERMS_DEF, a.TOT_PAYMNT_TERMS_DEF)
		ELSE o.TOT_PAYMNT_TERMS_DEF
	END AS TOT_PAYMNT_TERMS_DEF,	                                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRT_LOC_PG_FTR, a.PRT_LOC_PG_FTR)
		ELSE o.PRT_LOC_PG_FTR
	END AS PRT_LOC_PG_FTR,	                                                                                                                                                                                                                                                                                    
	CASE																								--#06, #05
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL AND c.PRT_LOC_PG_FTR = 1 THEN NULL
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL AND a.PRT_LOC_PG_FTR = 1 THEN NULL
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL AND c.PRT_LOC_PG_FTR = 2 THEN c.PRT_LOC_PG_FTR_DEF
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL AND a.PRT_LOC_PG_FTR = 2 THEN a.PRT_LOC_PG_FTR_DEF
		WHEN rs.ONE_TIME = 1 THEN o.PRT_LOC_PG_FTR_DEF
	END AS PRT_LOC_PG_FTR_DEF,            		                                                                                                                                                                                                                                                                     
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BACKUP_COL_OPT, a.BACKUP_COL_OPT)
		ELSE o.BACKUP_COL_OPT
	END AS BACKUP_COL_OPT,	                                                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BACKUP_ET_COL_OPT, a.BACKUP_ET_COL_OPT)
		ELSE o.BACKUP_ET_COL_OPT
	END AS BACKUP_ET_COL_OPT,	                                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BACKUP_AP_COL_OPT, a.BACKUP_AP_COL_OPT)
		ELSE o.BACKUP_AP_COL_OPT
	END AS BACKUP_AP_COL_OPT,	                                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BACKUP_IO_COL_OPT, a.BACKUP_IO_COL_OPT)
		ELSE o.BACKUP_IO_COL_OPT
	END AS BACKUP_IO_COL_OPT,	                                                                                                                                                                                                                                                                                
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.BACKUP_BA_CL_FNC_CMT, a.BACKUP_BA_CL_FNC_CMT)
		ELSE o.BACKUP_BA_CL_FNC_CMT
	END AS BACKUP_BA_CL_FNC_CMT,	                                                                                                                                                                                                                                                                             
	--CASE rs.ONE_TIME
	--	WHEN 0 THEN ISNULL(c.CUSTOM_FORMAT, a.CUSTOM_FORMAT)
	--	ELSE o.CUSTOM_FORMAT
	--END AS CUSTOM_FORMAT,	                                                                                                                                                                                                                                                   
	CASE					
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NOT NULL THEN ISNULL(c.CUSTOM_FORMAT, a.CUSTOM_FORMAT)		--#07
		WHEN rs.ONE_TIME = 0 AND c.CL_CODE IS NULL THEN a.CUSTOM_FORMAT
		ELSE o.CUSTOM_FORMAT
	END AS CUSTOM_FORMAT,                                                                                                                                                                                                                                                                           
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRINT_DIV_NAME, a.PRINT_DIV_NAME)
		ELSE o.PRINT_DIV_NAME
	END AS PRINT_DIV_NAME,	                                                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRINT_PRD_DESC, a.PRINT_PRD_DESC)
		ELSE o.PRINT_PRD_DESC
	END AS PRINT_PRD_DESC,	                                                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.COMPONENT_INCL, a.COMPONENT_INCL)
		ELSE o.COMPONENT_INCL
	END AS COMPONENT_INCL,	                                                                                                                                                                                                                                                                                   
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_TITLE, a.INV_TITLE)
		ELSE o.INV_TITLE
	END AS INV_TITLE,	                                                                                                                                                                                                                                                                                        
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.INV_CAT_TITLE, a.INV_CAT_TITLE)
		ELSE o.INV_CAT_TITLE
	END AS INV_CAT_TITLE,	                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRT_DUE_DATE, a.PRT_DUE_DATE)
		ELSE o.PRT_DUE_DATE
	END AS PRT_DUE_DATE,	                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN COALESCE(c.CONTACT_POS, a.CONTACT_POS, 0)
		ELSE ISNULL(o.CONTACT_POS, 0)
	END AS CONTACT_POS,	                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN COALESCE(c.FNC_IND_TAXABLE, a.FNC_IND_TAXABLE, 0)
		ELSE ISNULL(o.FNC_IND_TAXABLE, 0)
	END AS FNC_IND_TAXABLE,	                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN COALESCE(c.FNC_HIDE_TOTALS, a.FNC_HIDE_TOTALS, 0)
		ELSE ISNULL(o.FNC_HIDE_TOTALS, 0)
	END AS FNC_HIDE_TOTALS,	                                  
	CASE rs.ONE_TIME
		WHEN 0 THEN ISNULL(c.PRT_LOC_PG_FTR_2, a.PRT_LOC_PG_FTR_2)
		ELSE o.PRT_LOC_PG_FTR_2
	END AS PRT_LOC_PG_FTR_2	                                  
FROM dbo.RPT_RUNTIME_SPECS AS rs
CROSS JOIN dbo.CLIENT AS cl
LEFT JOIN PROD_INV_DEF AS c
	ON cl.CL_CODE = c.CL_CODE
CROSS JOIN PROD_INV_DEF AS a
CROSS JOIN PROD_INV_DEF AS o
WHERE rs.APP_TYPE = 'PI'
	AND rs.[USER_ID] = UPPER(@user_id) --dbo.fn_AdvanUser()
	AND a.CLIENT_OR_DEF = 1
	AND	o.CLIENT_OR_DEF = 0					--#03	--#04
)	

GO


GRANT SELECT ON [advtf_ar_prod_inv_def] TO PUBLIC
