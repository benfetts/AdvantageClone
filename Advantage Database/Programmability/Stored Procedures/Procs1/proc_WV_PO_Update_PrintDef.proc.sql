IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[proc_WV_PO_Update_PrintDef]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[proc_WV_PO_Update_PrintDef]
GO

CREATE PROCEDURE [dbo].[proc_WV_PO_Update_PrintDef](@userid varchar(100), @date_to_print smallint,
 @shp_instruction smallint, @po_instruction smallint, @footer_comment smallint,
 @detail_description smallint,  @detail_instruction smallint,
 @vendor_contact smallint, @client_name smallint, @product_name smallint, @job_cmp_nbr smallint,
  @location_id varchar(6), @logo_path varchar(254), @report_format varchar(50), @fnc_description smallint,
  @job_desc smallint, @USE_EMP_SIG smallint, @vendor_code smallint) AS

if exists(select [USER_ID] from PO_PRINT_DEF where UPPER([USER_ID]) = UPPER(@userid))
begin

update PO_PRINT_DEF set 
DATE_TO_PRINT=@date_to_print, 
SHP_INSTRUCTION = @shp_instruction,
PO_INSTRUCTION = @po_instruction,
FOOTER_COMMENT=@footer_comment,
DETAIL_DESCRIPTION=@detail_description,
DETAIL_INSTRUCTION=@detail_instruction,
VENDOR_CONTACT=@vendor_contact,
CLIENT_NAME=@client_name,
PRODUCT_NAME=@product_name,
JOB_CMP_NBR=@job_cmp_nbr,
LOCATION_ID=@location_id,
LOGO_PATH=@logo_path,
REPORT_FORMAT=@report_format,
FNC_DESCRIPTION=@fnc_description,
JOB_DESC=@job_desc,
USE_EMP_SIG=@USE_EMP_SIG,
VENDOR_CODE = @vendor_code
 where UPPER([USER_ID]) = UPPER(@userid)

end

else

begin

-- insert new record for user if it does not exist...
 exec proc_WV_PO_Insert_PrintDef @userid, @date_to_print, @shp_instruction, @po_instruction, @footer_comment,
              @detail_description, @detail_instruction, @vendor_contact, @client_name, @product_name, 
              @job_cmp_nbr, @location_id, @logo_path, @report_format, @fnc_description, @job_desc, @USE_EMP_SIG, @vendor_code
 
end

return @@error



