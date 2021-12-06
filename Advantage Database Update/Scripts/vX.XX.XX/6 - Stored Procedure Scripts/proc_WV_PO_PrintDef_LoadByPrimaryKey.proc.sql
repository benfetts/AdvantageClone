IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[proc_WV_PO_PrintDef_LoadByPrimaryKey]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[proc_WV_PO_PrintDef_LoadByPrimaryKey]
GO



CREATE PROCEDURE [dbo].[proc_WV_PO_PrintDef_LoadByPrimaryKey](@userid varchar(100)) AS

-- exec proc_WV_PO_PrintDef_LoadByPrimaryKey 'SYSADM'

select 
isnull(DATE_TO_PRINT,0) as DATE_TO_PRINT, 
isnull(SHP_INSTRUCTION,0) as SHP_INSTRUCTION,
 isnull(PO_INSTRUCTION,0) as PO_INSTRUCTION,
 isnull(FOOTER_COMMENT,0) as FOOTER_COMMENT,
 isnull(DETAIL_DESCRIPTION,0) as DETAIL_DESCRIPTION,
 isnull(DETAIL_INSTRUCTION,0) as DETAIL_INSTRUCTION,
 isnull( VENDOR_CONTACT,0) as VENDOR_CONTACT,
 isnull(CLIENT_NAME,0) as CLIENT_NAME,
 isnull(PRODUCT_NAME,0) as PRODUCT_NAME,
 isnull(JOB_CMP_NBR,0) as JOB_CMP_NBR,
 isnull(LOGO_PATH,'') as LOGO_PATH,
 isnull(REPORT_FORMAT,'') as REPORT_FORMAT,
 isnull(FNC_DESCRIPTION,0) as FNC_DESCRIPTION,
 isnull(JOB_DESC,0) as JOB_DESC,
 isnull( LOCATION_ID,'') as LOCATION_ID,
 isnull(USE_EMP_SIG,0) as USE_EMP_SIG,
 isnull(VENDOR_CODE,0) as VENDOR_CODE,
 isnull(JOB_COMP_DESC,0) as JOB_COMP_DESC,
 isnull(USE_LOCATION_NAME,0) as USE_LOCATION_NAME,
 isnull(USE_CLIENT_NAME,0) as USE_CLIENT_NAME
 from PO_PRINT_DEF where UPPER([USER_ID]) = UPPER(@userid)



