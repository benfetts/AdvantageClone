






CREATE PROCEDURE [dbo].[proc_WV_PO_Insert_PO_Copy](@copy_from_po_num integer, @sys_user_id varchar(100),
  @podate datetime, @duedate datetime, @change_emp_code varchar(6), @copy_memos_flag as smallint, @porulecode as varchar(6), @new_po_num integer OUTPUT)  AS

-- Create a new Purchase Order based on selected existing order...

declare @vn_code varchar(6)
declare @vn_cont_code varchar(4)
declare @emp_code varchar(6)
declare @po_description varchar(40)
declare @newnum integer
declare @instruct varchar(4000)
declare @delivery varchar(4000)
declare @footer varchar(4000)

declare @polimit decimal
declare @user_code varchar(15)
declare @user_name varchar(255)
declare @pototal decimal

select @vn_code=VN_CODE,
            @vn_cont_code= VN_CONT_CODE,
            @emp_code= EMP_CODE,
            @po_description= PO_DESCRIPTION from PURCHASE_ORDER where PO_NUMBER = @copy_from_po_num



-- use new empcode if passed...
  if @change_emp_code <> '' 
   begin
     select @emp_code=@change_emp_code
   end

/*
    exec proc_WV_PO_GetEmpPOLimit @emp_code, @polimit OUTPUT, @user_code OUTPUT, @user_name OUTPUT

    select @pototal = sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET where PO_NUMBER=@copy_from_po_num

  if @pototal > @polimit
   begin
     raiserror('Cannot copy.  Amount exceeds maximum PO Limit for Employee.',16,1)
     return
   end    
*/


-- copy header
exec proc_WV_PO_Insert_Header @sys_user_id,@vn_code, @vn_cont_code,
         @emp_code, @podate, @duedate,
         @po_description, 0, 0, 0, @porulecode, @newnum OUTPUT

--copy details
insert into PURCHASE_ORDER_DET(PO_NUMBER,LINE_NUMBER,DET_DESC, LINE_DESC,PO_QTY,PO_RATE,
  PO_EXT_AMOUNT,PO_TAX_PCT,PO_COMPLETE,JOB_NUMBER,JOB_COMPONENT_NBR,
  FNC_CODE,PO_COMM_PCT,EXT_MARKUP_AMT,DET_INSTRUCT,GLACODE)
select @newnum ,LINE_NUMBER,DET_DESC,LINE_DESC,PO_QTY,PO_RATE,
  PO_EXT_AMOUNT,PO_TAX_PCT,NULL,
  CASE WHEN (SELECT JOB_PROCESS_CONTRL FROM JOB_COMPONENT WHERE JOB_COMPONENT.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				AND JOB_COMPONENT.JOB_COMPONENT_NBR = PURCHASE_ORDER_DET.JOB_COMPONENT_NBR) IN (6,12) THEN NULL ELSE PURCHASE_ORDER_DET.JOB_NUMBER END,
  CASE WHEN(SELECT JOB_PROCESS_CONTRL FROM JOB_COMPONENT WHERE JOB_COMPONENT.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				AND JOB_COMPONENT.JOB_COMPONENT_NBR = PURCHASE_ORDER_DET.JOB_COMPONENT_NBR) IN (6,12) THEN NULL ELSE PURCHASE_ORDER_DET.JOB_COMPONENT_NBR END,
  FNC_CODE,PO_COMM_PCT,EXT_MARKUP_AMT,DET_INSTRUCT,GLACODE
  from PURCHASE_ORDER_DET
   where PO_NUMBER=@copy_from_po_num

select @new_po_num =  @newnum

-- copy footer

select @footer=PO_FOOTER from PURCHASE_ORDER where PO_NUMBER=@copy_from_po_num
update PURCHASE_ORDER set PO_FOOTER=@footer where PO_NUMBER=@newnum 

-- copy instructions if copy memos flag is true
if @copy_memos_flag=1

select @instruct = PO_MAIN_INSTRUCT, @delivery = DEL_INSTRUCT  from PURCHASE_ORDER where PO_NUMBER=@copy_from_po_num
update PURCHASE_ORDER set PO_MAIN_INSTRUCT=@instruct, DEL_INSTRUCT=@delivery where PO_NUMBER=@newnum

return @@error






