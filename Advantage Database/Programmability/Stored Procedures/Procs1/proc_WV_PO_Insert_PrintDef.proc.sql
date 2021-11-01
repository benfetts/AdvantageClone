IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[proc_WV_PO_Insert_PrintDef]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[proc_WV_PO_Insert_PrintDef]
GO

CREATE PROCEDURE [dbo].[proc_WV_PO_Insert_PrintDef](@userid varchar(100), @date_to_print smallint,
 @shp_instruction smallint, @po_instruction smallint, @footer_comment smallint,
 @detail_description smallint,  @detail_instruction smallint,
 @vendor_contact smallint, @client_name smallint, @product_name smallint, @job_cmp_nbr smallint,
  @location_id varchar(6), @logo_path varchar(254), @report_format varchar(50), @fnc_description smallint,
  @job_desc smallint, @USE_EMP_SIG smallint, @vendor_code smallint) AS

  -- insert  PO Print definition for User...

if not exists(select [USER_ID] from PO_PRINT_DEF where [USER_ID] = @userid) --user record must be unique.

begin
 insert into PO_PRINT_DEF([USER_ID],DATE_TO_PRINT,SHP_INSTRUCTION,
   PO_INSTRUCTION, FOOTER_COMMENT,
   DETAIL_DESCRIPTION, DETAIL_INSTRUCTION,
   VENDOR_CONTACT, CLIENT_NAME, PRODUCT_NAME, JOB_CMP_NBR,
   LOCATION_ID, LOGO_PATH, REPORT_FORMAT,
   FNC_DESCRIPTION, JOB_DESC, VENDOR_CODE)
   values(
     @userid, @date_to_print, @shp_instruction,
     @po_instruction, @footer_comment,
      @detail_description, @detail_instruction,
      @vendor_contact, @client_name, @product_name, @job_cmp_nbr,
      @location_id, @logo_path, @report_format,
      @fnc_description, @job_desc, @vendor_code)
 end

  return @@error

