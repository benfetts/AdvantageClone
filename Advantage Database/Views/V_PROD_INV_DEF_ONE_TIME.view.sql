-- V_PROD_INV_DEF_ONE_TIME
-- #00 08/17/12 - initial version

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO

IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[V_PROD_INV_DEF_ONE_TIME]' ) AND OBJECTPROPERTY( id, N'IsView' ) = 1 )
	DROP VIEW [dbo].[V_PROD_INV_DEF_ONE_TIME]
GO

CREATE VIEW dbo.V_PROD_INV_DEF_ONE_TIME
AS

SELECT
	1 AS LINK_ID,                                                                                                                                                                                                                                                 
	CLIENT_OR_DEF,                                                                                                                                                                                                                                                  
	CL_CODE,                                                                                                                                                                                                                                                        
	DTL_BCKUP_RPT_INCL,                                                                                                                                                                                                                                             
	LOGO_BLOCK_INCL,                                                                                                                                                                                                                                                
	LOGO_PATH,                                                                                                                                                                                                                                                      
	ADDRESS_BLOCK,                                                                                                                                                                                                                                                  
	NAME_OVERIDE,                                                                                                                                                                                                                                                   
	INV_REF_INCL,                                                                                                                                                                                                                                                   
	INV_USER_INCL,                                                                                                                                                                                                                                                  
	INV_CL_PO_INCL,                                                                                                                                                                                                                                                 
	INV_AE_INCL,                                                                                                                                                                                                                                                    
	INV_CLASS_INCL,                                                                                                                                                                                                                                                 
	BILL_COMM_INV_INCL,                                                                                                                                                                                                                                             
	BILL_APPR_CL_COMM_INCL,                                                                                                                                                                                                                                         
	JOB_COMM_INCL,                                                                                                                                                                                                                                                  
	COMP_COMM_INCL,                                                                                                                                                                                                                                                 
	EST_COMM_INCL,                                                                                                                                                                                                                                                  
	EST_COMP_COMM_INCL,                                                                                                                                                                                                                                             
	EST_QTE_COMM_INCL,                                                                                                                                                                                                                                              
	EST_REV_COMM_INCL,                                                                                                                                                                                                                                              
	COL_OPTION,                                                                                                                                                                                                                                                     
	COL_OPT_HRS,                                                                                                                                                                                                                                                    
	COL_OPT_QTY,                                                                                                                                                                                                                                                   
	COL_OPT_XCHGE_AMTS,                                                                                                                                                                                                                                             
	COL_OPT_XCHGE_DEF,                                                                                                                                                                                                                                              
	GRP_OPTION,                                                                                                                                                                                                                                                     
	GRP_INSIDE_DESC,                                                                                                                                                                                                                                                
	GRP_OUTSIDE_DESC,                                                                                                                                                                                                                                               
	FNC_SORT_BY,                                                                                                                                                                                                                                                    
	FNC_FNC_CODE,                                                                                                                                                                                                                                                   
	SHOW_FNC_DTL,                                                                                                                                                                                                                                                   
	SHOW_ZERO_FNC,                                                                                                                                                                                                                                                  
	FNC_ET_FNC_COMM,                                                                                                                                                                                                                                                
	FNC_AP_FNC_COMM,                                                                                                                                                                                                                                                
	FNC_IO_FNC_COMM,                                                                                                                                                                                                                                                
	FNC_BILL_APPR_CL_COMM,                                                                                                                                                                                                                                          
	TOT_SHOW_COMM,                                                                                                                                                                                                                                                  
	TOT_SHOW_TAX,                                                                                                                                                                                                                                                   
	TOT_SHOW_BILL_HIST,                                                                                                                                                                                                                                             
	TOT_PAYMNT_TERMS,                                                                                                                                                                                                                                               
	TOT_PAYMNT_TERMS_DEF,                                                                                                                                                                                                                                           
	PRT_LOC_PG_FTR,                                                                                                                                                                                                                                          
	PRT_LOC_PG_FTR_DEF,                                                                                                                                                                                                                                             
	BACKUP_COL_OPT,                                                                                                                                                                                                                                            
	BACKUP_ET_COL_OPT,                                                                                                                                                                                                                                              
	BACKUP_AP_COL_OPT,                                                                                                                                                                                                                                             
	BACKUP_IO_COL_OPT,                                                                                                                                                                                                                                             
	BACKUP_BA_CL_FNC_CMT,                                                                                                                                                                                                                                           
	CUSTOM_FORMAT,                                                                                                                                                                                                                                          
	PRINT_DIV_NAME,                                                                                                                                                                                                                                                 
	PRINT_PRD_DESC,                                                                                                                                                                                                                                                
	COMPONENT_INCL,                                                                                                                                                                                                                                                 
	INV_TITLE,                                                                                                                                                                                                                                                
	INV_CAT_TITLE
FROM dbo.PROD_INV_DEF
WHERE CLIENT_OR_DEF = 0	 

GO

IF ( @@ERROR = 0 )
	GRANT ALL ON [V_PROD_INV_DEF_ONE_TIME] TO PUBLIC AS dbo
GO	
