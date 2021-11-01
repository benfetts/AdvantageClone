IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[proc_WV_PO_Detail_LoadReportInfo_Ops]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[proc_WV_PO_Detail_LoadReportInfo_Ops]
GO

CREATE PROCEDURE [dbo].[proc_WV_PO_Detail_LoadReportInfo_Ops](@ref_id integer, @userid varchar(100), @ops varchar(200),@LocationID varchar(6)) AS

--exec proc_WV_PO_Detail_LoadReportInfo 88, 'SYSADM'
--exec proc_WV_PO_Detail_LoadReportInfo_Ops @ref_id = 89, @userid = 'SYSADM', @ops = '1;1;1;1;1;1;1;0;1;0;0'
--exec proc_WV_PO_Detail_LoadReportInfo_Ops @ref_id = 89, @userid = 'SYSADM', @ops = ''
 
SET ANSI_NULLS OFF
SET ANSI_WARNINGS OFF
SET ARITHABORT OFF
SET ARITHIGNORE ON                        

if @ops <> ''
begin
  select listpos as POS, cast(vstr as smallint) as value into #T1 from  dbo.charlist_to_table( @ops, ';') 
--select * from #T1     
end  


declare @show_ship as tinyint 
declare @show_poinstruct as tinyint
declare @show_footer as tinyint
declare @show_dtl_desc as tinyint
declare @show_dtl_instruct as tinyint
declare @show_vend_contact as tinyint
declare @show_client as tinyint
declare @show_product as tinyint --?used
declare @show_job as tinyint 
declare @show_fnc_descrip as tinyint
declare @show_job_desc as tinyint
declare @show_job_comp_desc as tinyint
declare @show_vend_code as tinyint

declare @rcount as integer

declare @hf_name as varchar(50)
declare @hf_addr1 as varchar(50)
declare @hf_addr2 as varchar(50)
declare @hf_city as varchar(35)
declare @hf_state as varchar(10)
declare @hf_zip as varchar(60)
declare @hf_fax as varchar(20)
declare @hf_phone as varchar(20)
declare @hf_email as varchar(60)
declare @hf_citystatezip as varchar(110)
declare @hf_full_header as varchar(500)

declare @ftr_name as varchar(50)
declare @ftr_addr1 as varchar(50)
declare @ftr_addr2 as varchar(50)
declare @ftr_city as varchar(35)
declare @ftr_state as varchar(10)
declare @ftr_zip as varchar(60)
declare @ftr_fax as varchar(20)
declare @ftr_phone as varchar(20)
declare @ftr_email as varchar(60)
declare @ftr_citystatezip as varchar(110)
declare @ftr_full_footer as varchar(500)
declare @agency_name as varchar(60)

SELECT @agency_name = NAME FROM AGENCY

select @hf_name = case when loc.PRT_NAME = 1 and loc.PRT_HEADER=1 then loc.[NAME] else '' end,
            @hf_addr1 = case when loc.PRT_ADDR1=1 and loc.PRT_HEADER=1  then ISNULL(loc.ADDRESS1,'') else '' end,
            @hf_addr2 = case when loc.PRT_ADDR2=1 and loc.PRT_HEADER=1  then ISNULL(loc.ADDRESS2,'') else '' end,
            @hf_city = case when loc.PRT_CITY=1  and loc.PRT_HEADER=1 then ISNULL(loc.CITY,'') else '' end,
            @hf_state = case when loc.PRT_STATE=1  and loc.PRT_HEADER=1  then loc.STATE else '' end,
            @hf_zip = case when loc.PRT_ZIP=1  and loc.PRT_HEADER=1 then ISNULL(loc.ZIP,'') else '' end,
            @hf_fax = case when loc.PRT_FAX=1  and loc.PRT_HEADER=1 then ISNULL(loc.FAX,'') else '' end,
            @hf_phone = case when loc.PRT_PHONE=1 and loc.PRT_HEADER=1  then ISNULL(loc.PHONE,'') else '' end,
            @hf_email = case when loc.PRT_EMAIL=1 and loc.PRT_HEADER=1  then ISNULL(loc.EMAIL,'') else '' end
  from LOCATIONS as loc where loc.[ID] = @LocationID
SET @hf_full_header = ''

IF @hf_addr1 <> ''
	Set @hf_full_header = @hf_addr1

IF @hf_addr2 <> ''
Begin
	If @hf_full_header <> ''
		Set @hf_full_header = @hf_full_header + ' ' + char(149) + ' '
  	SET  @hf_full_header = @hf_full_header + @hf_addr2 
End
  	
select @hf_citystatezip = @hf_city + ' ' + @hf_state + ' ' + @hf_zip
If @hf_citystatezip <> ''
Begin
	If @hf_full_header <> ''
		Set @hf_full_header = @hf_full_header + ' ' + char(149) + ' '
	Set @hf_full_header = @hf_full_header + @hf_citystatezip
End
  	
IF @hf_phone <> ''
Begin
	If @hf_full_header <> ''
		Set @hf_full_header = @hf_full_header + ' ' + char(149) + ' '	
  	SET  @hf_full_header =  @hf_full_header + @hf_phone 
End

IF @hf_fax <> ''
Begin
	If @hf_full_header <> ''
		Set @hf_full_header = @hf_full_header + ' ' + char(149) + ' '	
  	SET  @hf_full_header =  @hf_full_header + @hf_fax + ' Fax ' 
End

IF @hf_email <> ''
Begin
	If @hf_full_header <> ''
		Set @hf_full_header = @hf_full_header + ' ' + char(149) + ' '
  	SET  @hf_full_header = @hf_full_header + @hf_email
End
  	
-- select @hf_full_header = @hf_addr1 + @hf_addr2 + @hf_citystatezip + @hf_phone + @hf_fax + @hf_email

select @ftr_name = case when loc.PRT_NAME_FTR = 1 and loc.PRT_FOOTER=1 then loc.[NAME] else '' end,
            @ftr_addr1 = case when loc.PRT_ADDR1_FTR=1 and loc.PRT_FOOTER=1  then ISNULL(loc.ADDRESS1,'') else '' end,
            @ftr_addr2 = case when loc.PRT_ADDR2_FTR=1 and loc.PRT_FOOTER=1  then ISNULL(loc.ADDRESS2,'') else '' end,
            @ftr_city = case when loc.PRT_CITY_FTR=1  and loc.PRT_FOOTER=1 then ISNULL(loc.CITY,'') else '' end,
            @ftr_state = case when loc.PRT_STATE_FTR=1  and loc.PRT_FOOTER=1  then ISNULL(loc.STATE,'') else '' end,
            @ftr_zip = case when loc.PRT_ZIP_FTR=1  and loc.PRT_FOOTER=1 then ISNULL(loc.ZIP,'') else '' end,
            @ftr_fax = case when loc.PRT_FAX_FTR =1  and loc.PRT_FOOTER=1 then ISNULL(loc.FAX,'') else '' end,
            @ftr_phone = case when loc.PRT_PHONE_FTR=1 and loc.PRT_FOOTER=1  then ISNULL(loc.PHONE,'') else '' end,
            @ftr_email = case when loc.PRT_EMAIL_FTR=1 and loc.PRT_FOOTER=1  then ISNULL(loc.EMAIL,'') else '' end
 from LOCATIONS as loc where loc.[ID] = @LocationID

SET  @ftr_full_footer = ''

IF @ftr_name <> ''
  	SET  @ftr_full_footer = @ftr_name 
  	
IF @ftr_addr1 <> ''
Begin
	If @ftr_full_footer <> ''
		Set @ftr_full_footer = @ftr_full_footer + ' ' + char(149) + ' '
  	SET  @ftr_full_footer = @ftr_full_footer + @ftr_addr1 
End
 
IF @ftr_addr2 <> ''
Begin
	If @ftr_full_footer <> ''
		Set @ftr_full_footer = @ftr_full_footer + ' ' + char(149) + ' '
  	SET  @ftr_full_footer = @ftr_full_footer + @ftr_addr2 
End
  	
  	
select @ftr_citystatezip = @ftr_city + ' ' + @ftr_state + ' ' + @ftr_zip
If @ftr_citystatezip <> ''
Begin
	If @ftr_full_footer <> ''
		Set @ftr_full_footer = @ftr_full_footer + ' ' + char(149) + ' '
  	SET  @ftr_full_footer = @ftr_full_footer + @ftr_citystatezip 
End
	
IF @ftr_phone <> ''
Begin
	If @ftr_full_footer <> ''
		Set @ftr_full_footer = @ftr_full_footer + ' ' + char(149) + ' '
  	SET  @ftr_full_footer = @ftr_full_footer + @ftr_phone 
End

IF @ftr_fax <> ''
Begin
	If @ftr_full_footer <> ''
		Set @ftr_full_footer = @ftr_full_footer + ' ' + char(149) + ' '
  	SET  @ftr_full_footer = @ftr_full_footer + @ftr_fax + ' Fax ' 
End

IF @ftr_email <> ''
Begin
	If @ftr_full_footer <> ''
		Set @ftr_full_footer = @ftr_full_footer + ' ' + char(149) + ' '
  	SET  @ftr_full_footer = @ftr_full_footer + @ftr_email
End

--select @ftr_full_footer = @ftr_name + @ftr_addr1 + @ftr_addr2 + @ftr_citystatezip + @ftr_phone + @ftr_fax  + @ftr_email 

if @ops = '' or @ops is null
begin
select @show_ship = SHP_INSTRUCTION, @show_poinstruct=PO_INSTRUCTION, @show_footer=FOOTER_COMMENT,
  @show_dtl_desc = DETAIL_DESCRIPTION, @show_dtl_instruct = DETAIL_INSTRUCTION, @show_client=CLIENT_NAME,
  @show_product=PRODUCT_NAME, @show_job = JOB_CMP_NBR, @show_job_desc=JOB_DESC, @show_vend_code = VENDOR_CODE, @show_job_comp_desc=JOB_COMP_DESC
  from PO_PRINT_DEF where UPPER([USER_ID]) = UPPER(@userid) 
end
else
begin
  select @show_ship = value from #T1 where POS = 1
  select @show_poinstruct= value from #T1 where POS=2
  select @show_footer= value from #T1 where POS=3
  select @show_dtl_desc= value from #T1 where POS=4
  select @show_dtl_instruct= value from #T1 where POS=5
  select @show_vend_contact= value from #T1 where POS=6
  select @show_client= value from #T1 where POS=7
  select @show_product= value from #T1 where POS=8
  select @show_job= value from #T1 where POS=9
  select @show_fnc_descrip= value from #T1 where POS=10
  select @show_job_desc= value from #T1 where POS=11
  select @show_vend_code= value from #T1 where POS=13
  select @show_job_comp_desc= value from #T1 where POS=15


end

-- populate po footer with custom text if it exists on the po header, and the default in the agency table
-- if po header text is null....


create table #pofoot(
                                     po_number integer,
                                     footer_text  ntext
                                  )



  insert into #pofoot(po_number, footer_text)
  select @ref_id, PO_FOOTER from PURCHASE_ORDER where PO_NUMBER = @ref_id and (PO_FOOTER is not null)

 select @rcount =  count(po_number) from #pofoot

if @rcount=0

begin
  insert into #pofoot(po_number, footer_text)
     select @ref_id, PO_FOOTER  from AGENCY
end


select pd.PO_NUMBER + LINE_NUMBER as REF_ID,
 pd.LINE_NUMBER, isnull(pd.LINE_DESC,f.FNC_DESCRIPTION) as LINE_DESC, 
 DET_DESC = case when @show_dtl_desc=1 then  pd.DET_DESC else '' end,
 DET_INSTRUCT = case when @show_dtl_instruct=1 then  pd.DET_INSTRUCT else '' end,
 pd.JOB_NUMBER, pd.JOB_COMPONENT_NBR, pd.FNC_CODE,
 FNC_DESCRIPTION = case when  @show_fnc_descrip=1 then f.FNC_DESCRIPTION else '' end,
 JOB_DESC = case when @show_job_desc=1 then j.JOB_DESC else '' end,
 pd.PO_RATE, pd.PO_QTY, pd.PO_EXT_AMOUNT,
 pd.PO_COMM_PCT,
 pd.EXT_MARKUP_AMT,
 LINE_TOTAL = isnull(pd.PO_EXT_AMOUNT,0) + isnull(pd.EXT_MARKUP_AMT,0),
 pd.PO_COMPLETE,
 j.CL_CODE, j.DIV_CODE, j.PRD_CODE,
 ATTACHED_TO_AP = (select count(prod.AP_ID) FROM AP_PRODUCTION as prod WHERE
  prod.PO_NUMBER=pd.PO_NUMBER and prod.PO_LINE_NUMBER=pd.LINE_NUMBER
  and prod.DELETE_FLAG is null),
 USE_CPM = case when f.FNC_CPM_FLAG=1 then 1 else 0 end,
 CL_NAME = case when @show_client=1 then isnull((select min(CL_NAME) from CLIENT as cl where cl.CL_CODE=j.CL_CODE and j.CL_CODE is not null),'') else '' end,
 PRD_NAME = case when @show_product=1 then isnull((select min(PRD_DESCRIPTION) from PRODUCT as pd where pd.PRD_CODE=j.PRD_CODE and pd.DIV_CODE=j.DIV_CODE and pd.CL_CODE=j.CL_CODE and j.PRD_CODE is not null),'') else '' end,
 JOBANDCOMP = case when @show_job = 1 then (
   case when pd.JOB_NUMBER is not null  then Right('00000000' + convert(varchar(6),pd.JOB_NUMBER),6) +
 '-' +  Right('00000000' + convert(varchar(3),pd.JOB_COMPONENT_NBR),3) else '' end) else '' end,
  Right('00000000' + convert(varchar(8),pd.PO_NUMBER),8) as PO_NUMBER,
 ph.PO_DESCRIPTION, 
 VENDOR_INFO = case when @show_vend_code = 1 then 'vendor: ' + ph.VN_CODE + char(10) else '' END
  + v.VN_NAME + char(10) + ltrim(rtrim(isnull(v.VN_ADDRESS1,'')))
  + CASE WHEN v.VN_ADDRESS2 is not null AND v.VN_ADDRESS2 <> '' then char(10) + ltrim(rtrim(v.VN_ADDRESS2)) else '' end
  + char(10) + isnull(VN_CITY,'') + ', ' + isnull(VN_STATE,'') +' ' +  isnull(VN_ZIP,'') + CASE WHEN v.VN_PHONE is not null AND v.VN_PHONE <> '' then char(10) + v.VN_PHONE else '' end
  + CASE WHEN v.VN_PHONE_EXT is not null AND v.VN_PHONE_EXT <> '' then ' ext ' + VN_PHONE_EXT else '' end + CASE WHEN v.VN_FAX_NUMBER is not null AND v.VN_FAX_NUMBER <> '' then char(10) + v.VN_FAX_NUMBER + ' Fax ' else '' end
  + CASE WHEN v.VN_FAX_EXTENTION is not null AND v.VN_FAX_EXTENTION <> '' then ' ext ' + VN_FAX_EXTENTION else '' end,
  VENDOR_ATTN = case when @show_vend_contact = 1 then isnull((select isnull(VC_FNAME,'') + ' ' + isnull(VC_LNAME,'') from VEN_CONT as vc
   where vc.VN_CODE = ph.VN_CODE and vc.VC_CODE = ph.VN_CONT_CODE),'') else '' end,
   ph.PO_DATE,
   ph.PO_DUE_DATE,
   ISSUE_BY =  isnull(emp.EMP_FNAME,'') + ' ' + isnull(emp.EMP_MI,'') + case when emp.EMP_MI is not null then '. ' else '' end +  isnull(emp.EMP_LNAME,''),
   @hf_name as HDR_AGENCY_NAME, @hf_phone as HDR_AGENCY_PHONE, @hf_email as HDR_AGENCY_EMAIL,
   @hf_addr1 as HDR_AGENCY_ADDR1, @hf_addr2 as HDR_AGENCY_ADDR2,
   @hf_citystatezip as HDR_AGENCY_CITYSTATEZIP, @hf_fax as HDR_AGENCY_FAX,
   @hf_full_header as AGENCY_FULL_HEADER, @ftr_full_footer as AGENCY_FULL_FOOTER,
   @ftr_name as FTR_AGENCY_NAME,
   DEL_INSTRUCT = case when @show_ship=1 then ISNULL(DEL_INSTRUCT, '-') else '-' end,
   PO_MAIN_INSTRUCT = case when @show_poinstruct=1 then ISNULL(PO_MAIN_INSTRUCT, '-') else '-' end,
   PO_FOOTER = case when @show_footer=1 then  pf.footer_text else '' end, ISNULL(ph.PO_REVISION,0) AS PO_REVISION, @agency_name AS AGENCY_NAME,
   JOB_COMP_DESC = case when @show_job_comp_desc=1 then jc.JOB_COMP_DESC else '' end
 from PURCHASE_ORDER as ph
 join PURCHASE_ORDER_DET as pd on pd.PO_NUMBER = ph.PO_NUMBER
 left join [FUNCTIONS] as f on f.FNC_CODE=pd.FNC_CODE
 left  join JOB_LOG as j on j.JOB_NUMBER = pd.JOB_NUMBER 
 left join JOB_COMPONENT as jc on jc.JOB_COMPONENT_NBR = pd.JOB_COMPONENT_NBR 
      and jc.JOB_NUMBER = pd.JOB_NUMBER
 join VENDOR as v on v.VN_CODE=ph.VN_CODE
 join EMPLOYEE as emp on emp.EMP_CODE = ph.EMP_CODE
 left join #pofoot as pf on pf.po_number = ph.PO_NUMBER
  where pd.PO_NUMBER = @ref_id --and  f.FNC_CODE = 'V'
 order by pd.LINE_NUMBER


drop table #pofoot



