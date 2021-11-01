


CREATE PROCEDURE [dbo].[proc_WV_PO_Detail_LoadReportInfo](@ref_id as  integer, @userid varchar(100)) AS

--exec proc_WV_PO_Detail_LoadReportInfo 88, 'SYSADM'

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
declare @hf_citystatezip as varchar(200)

declare @ftr_name as varchar(50)
declare @ftr_addr1 as varchar(50)
declare @ftr_addr2 as varchar(50)
declare @ftr_city as varchar(35)
declare @ftr_state as varchar(10)
declare @ftr_zip as varchar(60)
declare @ftr_fax as varchar(20)
declare @ftr_phone as varchar(20)
declare @ftr_email as varchar(60)


select @hf_name = case when loc.PRT_NAME = 1 and loc.PRT_HEADER=1 then loc.[NAME] else '' end,
            @hf_addr1 = case when loc.PRT_ADDR1=1 and loc.PRT_HEADER=1  then loc.ADDRESS1 else '' end,
            @hf_addr2 = case when loc.PRT_ADDR2=1 and loc.PRT_HEADER=1  then loc.ADDRESS2 else '' end,
            @hf_city = case when loc.PRT_CITY=1  and loc.PRT_HEADER=1 then loc.CITY else '' end,
            @hf_state = case when loc.PRT_STATE=1  and loc.PRT_HEADER=1  then loc.STATE else '' end,
            @hf_zip = case when loc.PRT_ZIP=1  and loc.PRT_HEADER=1 then loc.ZIP else '' end,
            @hf_fax = case when loc.PRT_FAX=1  and loc.PRT_HEADER=1 then loc.FAX else '' end,
            @hf_phone = case when loc.PRT_PHONE=1 and loc.PRT_HEADER=1  then loc.PHONE else '' end,
            @hf_email = case when loc.PRT_EMAIL=1 and loc.PRT_HEADER=1  then loc.EMAIL else '' end
  from LOCATIONS as loc where loc.[ID] = (select min([ID]) from LOCATIONS)

           select @hf_citystatezip = @hf_city + ', ' + @hf_state + '  ' + @hf_zip

select @ftr_name = case when loc.PRT_NAME_FTR = 1 and loc.PRT_FOOTER=1 then loc.[NAME] else '' end,
            @ftr_addr1 = case when loc.PRT_ADDR1_FTR=1 and loc.PRT_FOOTER=1  then loc.ADDRESS1 else '' end,
            @ftr_addr2 = case when loc.PRT_ADDR2_FTR=1 and loc.PRT_FOOTER=1  then loc.ADDRESS2 else '' end,
            @ftr_city = case when loc.PRT_CITY_FTR=1  and loc.PRT_FOOTER=1 then loc.CITY else '' end,
            @ftr_state = case when loc.PRT_STATE_FTR=1  and loc.PRT_FOOTER=1  then loc.STATE else '' end,
            @ftr_zip = case when loc.PRT_ZIP_FTR=1  and loc.PRT_FOOTER=1 then loc.ZIP else '' end,
            @ftr_fax = case when loc.PRT_FAX_FTR =1  and loc.PRT_FOOTER=1 then loc.FAX else '' end,
            @ftr_phone = case when loc.PRT_PHONE_FTR=1 and loc.PRT_FOOTER=1  then loc.PHONE else '' end,
            @ftr_email = case when loc.PRT_EMAIL_FTR=1 and loc.PRT_FOOTER=1  then loc.EMAIL else '' end
 from LOCATIONS as loc where loc.[ID] = (select min([ID]) from LOCATIONS)



print @hf_name
print @hf_addr1
print @hf_phone
print @hf_email
   


select @show_ship = SHP_INSTRUCTION, @show_poinstruct=PO_INSTRUCTION, @show_footer=FOOTER_COMMENT,
  @show_dtl_desc = DETAIL_DESCRIPTION, @show_dtl_instruct = DETAIL_INSTRUCTION, @show_client=CLIENT_NAME,
  @show_product=PRODUCT_NAME, @show_job = JOB_CMP_NBR, @show_job_desc=JOB_DESC
  from PO_PRINT_DEF where UPPER([USER_ID]) = UPPER(@userid)


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
 JOB_DESC = case when @show_job_desc=1 then j.JOB_DESC else''  end,
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
 CL_NAME = case when @show_client=1 then isnull((select CL_NAME from CLIENT as cl where cl.CL_CODE=j.CL_CODE and j.CL_CODE is not null),'') else '' end,
 JOBANDCOMP = case when @show_job = 1 then (
   case when pd.JOB_NUMBER is not null  then Right('00000000' + convert(varchar(6),pd.JOB_NUMBER),6) +
 '-' +  case when pd.JOB_COMPONENT_NBR < 10 then '0' else '' end  + cast(pd.JOB_COMPONENT_NBR as varchar(3)) else '' end) else '' end,
  Right('00000000' + convert(varchar(8),pd.PO_NUMBER),8) as PO_NUMBER,
 ph.PO_DESCRIPTION, 
 VENDOR_INFO = v.VN_NAME + char(10) + ltrim(rtrim(isnull(v.VN_ADDRESS1,'')))
  + CASE WHEN v.VN_ADDRESS2 is not null then char(10) + ltrim(rtrim(v.VN_ADDRESS2)) else '' end
  + char(10) + isnull(VN_CITY,'') + ', ' + isnull(VN_STATE,'') +' ' +  isnull(VN_ZIP,''),
  VENDOR_ATTN = case when @show_vend_contact = 1 then isnull((select isnull(VC_LNAME,'') + ', ' + isnull(VC_FNAME,'') from VEN_CONT as vc
   where vc.VN_CODE = ph.VN_CODE),'') else '' end,
   convert(char(10),ph.PO_DATE,101) as PO_DATE,
   case when ph.PO_DUE_DATE is not null then convert(char(10), ph.PO_DUE_DATE,101) else '' end as PO_DUE_DATE,
   ISSUE_BY =  isnull(emp.EMP_FNAME,'') + ' ' + isnull(emp.EMP_MI,'') + case when emp.EMP_MI is not null then '. ' else '' end +  isnull(emp.EMP_LNAME,''),
   DEL_INSTRUCT = case when @show_ship=1 then DEL_INSTRUCT else '' end,
   PO_MAIN_INSTRUCT = case when @show_poinstruct=1 then PO_MAIN_INSTRUCT else '' end,
   @hf_name as HDR_AGENCY_NAME, @hf_phone as HDR_AGENCY_PHONE, @hf_email as HDR_AGENCY_EMAIL,
   @hf_addr1 as HDR_AGENCY_ADDR1, @hf_addr2 as HDR_AGENCY_ADDR2,
   @hf_citystatezip as HDR_AGENCY_CITYSTATEZIP, @hf_fax as HDR_AGENCY_FAX,
   PO_FOOTER = case when @show_footer=1 then  pf.footer_text else '' end

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





