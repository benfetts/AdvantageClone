if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proc_WV_PO_Validation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[proc_WV_PO_Validation]
GO



CREATE PROCEDURE [dbo].[proc_WV_PO_Validation](@check integer, @job_number varchar(25), @component_nbr varchar(10),
 @fnc_code varchar(6), @emp_code char(6), @vn_code char(6), @vc_code char(4), @gla_code varchar(30), @msg varchar(2000) OUTPUT, @errorcount integer OUTPUT) AS

declare @ecount integer
declare @error_msg varchar(2000)

/*
declare @tm varchar(2000)
declare @cnt integer
exec proc_WV_PO_Validation 1, '3', '1', 'printss','','','',@tm output, @cnt output
print @tm
print @cnt


declare @tm varchar(2000)
declare @cnt integer
exec proc_WV_PO_Validation 2, '', '', '','ama','bobbin','1',@tm output, @cnt output
print @tm
print @cnt

*/


select @error_msg=''
select @ecount=0

if @check=1 -- po detail check
begin

--if not exists(select FNC_CODE from [FUNCTIONS] where FNC_CODE=@fnc_code)
-- and @fnc_code <> ''
--begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Invalid Function Code'
--       select @ecount=@ecount+1
--end

--if not exists(select GLACODE from [GLACCOUNT] where GLACODE=@gla_code)
-- and @gla_code <> ''
--begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Invalid GL Account Code'
--       select @ecount=@ecount+1
--end

--if (isnumeric(@job_number)<>1 and @job_number <> '' ) 

-- begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Invalid Job Number'
--    select @ecount=@ecount+1
--end

--if  isnumeric(@job_number)=1 and isnumeric(@component_nbr) <> 1  
-- begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Job must have a numeric Component Number'
--          select @ecount=@ecount+1
--end


--if (isnumeric(@job_number)=1) and not exists (select JOB_NUMBER from JOB_LOG
-- where JOB_NUMBER = cast(@job_number as integer))

-- begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Job does not exist'
--    select @ecount=@ecount+1
--end


--if 
-- isnumeric(@job_number)=1 and isnumeric(@component_nbr)=1 and
-- not exists(SELECT JOB_NUMBER from JOB_COMPONENT where JOB_NUMBER=cast(@job_number as integer) and
--  JOB_COMPONENT_NBR = cast(@component_nbr as integer))
-- begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Invalid Component Number for selected Job' 
--    select @ecount=@ecount+1
--end

if  isnumeric(@job_number)=1 and isnumeric(@component_nbr)=1
begin
declare @cnt as integer
 select @cnt =  count(JOB_PROCESS_CONTRL) from JOB_COMPONENT where JOB_NUMBER=@job_number 
 and JOB_COMPONENT_NBR=@component_nbr and JOB_PROCESS_CONTRL in (1,3,4,8,9,13)
 if @cnt = 0
  begin
  if @error_msg <> ''
  begin
   select @error_msg=@error_msg + '<br>'
  end
       --select @error_msg= @error_msg + 'Job: ' + @job_number +  ', Component: ' + @component_nbr + ' closed or archived.' 
       select @error_msg = @error_msg + 'Job/Comp process control does not allow access.'
    select @ecount=@ecount+1
  end
end --isnumeric..


end --end 1

if @check=2 --PO header check
begin

--if not exists(select EMP_CODE from EMPLOYEE where EMP_CODE=@emp_code and EMP_TERM_DATE is null)
-- begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Invalid Employee Code.' 
--    select @ecount=@ecount+1
--end

if not exists(select VN_CODE from VENDOR where VN_CODE=@vn_code and VN_ACTIVE_FLAG in(1,null))
 begin
  if @error_msg <> ''
  begin
   select @error_msg=@error_msg + '<br>'
  end
       select @error_msg= @error_msg + 'Invalid Vendor Code.' 
    select @ecount=@ecount+1
end

if
 @vc_code <> '' and
 (not exists(select VC_CODE from VEN_CONT where ltrim(rtrim(VC_CODE))=ltrim(rtrim(@vc_code)) and (VC_INACTIVE_FLAG is null
  or VC_INACTIVE_FLAG=0) ) or
not exists(select VC_CODE from VEN_CONT where VC_CODE=@vc_code and  VN_CODE=@vn_code) )
 begin
  if @error_msg <> ''
  begin
   select @error_msg=@error_msg + '<br>'
  end
       select @error_msg= @error_msg + 'Invalid Vendor Contact Code.' 
    select @ecount=@ecount+1
end


--if @vc_code <> '' and
-- not exists(select VC_CODE from VEN_CONT where VC_CODE=@vc_code and  VN_CODE=@vn_code)
-- begin
--  if @error_msg <> ''
--  begin
--   select @error_msg=@error_msg + '<br>'
--  end
--       select @error_msg= @error_msg + 'Invalid Vendor Contact Code for selected Vendor' 
--    select @ecount=@ecount+1
--end


end -- end check2



select @msg=@error_msg
select @errorcount= @ecount






SET QUOTED_IDENTIFIER ON 
