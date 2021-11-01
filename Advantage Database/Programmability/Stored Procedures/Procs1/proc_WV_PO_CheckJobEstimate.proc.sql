

CREATE PROCEDURE dbo.proc_WV_PO_CheckJobEstimate(@funct integer, @job_number integer, @job_component_nbr integer,
  @ref_id integer, @fnc_code char(6), @line_num integer,
  @est_info varchar(100) OUTPUT, @amt_approved decimal(15,2) OUTPUT, @approved smallint OUTPUT, @used_amt decimal(15,2) OUTPUT) AS
declare @approvals_exist as smallint, @current_amt as decimal(15,2)
  /*
Return estimate approval status, amount approved for specified Job/Component.....

declare @testinfo varchar(100)
declare @amt as decimal(15,2)
declare @approved as smallint

exec proc_WV_PO_CheckJobEstimate 1, 57, 1,1,'film', @testinfo OUTPUT, @amt OUTPUT, @approved OUTPUT
--exec proc_WV_PO_CheckJobEstimate 2, 58, 1,1,'', @testinfo OUTPUT, @amt OUTPUT, @approved OUTPUT

print @testinfo
print @amt
print @approved
*/

select @approvals_exist = 0 

if @funct=1 -- test for approvals AND amount for Job/Comp/Funct combination...
begin
  if exists(select JOB_NUMBER from ESTIMATE_APPROVAL where JOB_NUMBER=@job_number and
     JOB_COMPONENT_NBR=@job_component_nbr)
   begin
     select @approvals_exist=1
       select @amt_approved= sum(ed.EST_REV_EXT_AMT),
            @est_info= 'Estimate: ' + cast(max(a.ESTIMATE_NUMBER) as varchar(10)) +
                                  ', Component: ' + cast(max(a.EST_COMPONENT_NBR) as varchar(10)) +
                                  ', Quote Number: ' + cast(max(a.EST_QUOTE_NBR) as varchar(10)) +
                                  ', Revision Number: ' +cast(max(a.EST_REVISION_NBR) as varchar(10))
            from ESTIMATE_APPROVAL as a
          join ESTIMATE_REV_DET as ed on ed.ESTIMATE_NUMBER=a.ESTIMATE_NUMBER
            and ed.EST_COMPONENT_NBR=a.EST_COMPONENT_NBR
            and ed.EST_QUOTE_NBR=a.EST_QUOTE_NBR
            and ed.EST_REV_NBR=a.EST_REVISION_NBR
            where a.JOB_NUMBER=@job_number and a.JOB_COMPONENT_NBR=@job_component_nbr
              and ed.FNC_CODE = @fnc_code

    -- retrieve amount already used on POs for this Job/Comp/Funct to use for comparison...
      select @used_amt = sum(PURCHASE_ORDER_DET.PO_EXT_AMOUNT) from PURCHASE_ORDER_DET INNER JOIN PURCHASE_ORDER ON PURCHASE_ORDER.PO_NUMBER = PURCHASE_ORDER_DET.PO_NUMBER
			where JOB_NUMBER=@job_number
			and JOB_COMPONENT_NBR=@job_component_nbr and FNC_CODE=@fnc_code and (VOID_FLAG = 0 or VOID_FLAG IS NULL)
			--and PURCHASE_ORDER_DET.PO_NUMBER NOT IN (SELECT PO_NUMBER FROM PURCHASE_ORDER_DET WHERE PO_NUMBER =  @ref_id and PURCHASE_ORDER_DET.LINE_NUMBER = @line_num)

	  select @current_amt = sum(PURCHASE_ORDER_DET.PO_EXT_AMOUNT) from PURCHASE_ORDER_DET INNER JOIN PURCHASE_ORDER ON PURCHASE_ORDER.PO_NUMBER = PURCHASE_ORDER_DET.PO_NUMBER
			where JOB_NUMBER=@job_number
			and JOB_COMPONENT_NBR=@job_component_nbr and FNC_CODE=@fnc_code and (VOID_FLAG = 0 or VOID_FLAG IS NULL)
			and PURCHASE_ORDER_DET.PO_NUMBER = @ref_id and PURCHASE_ORDER_DET.LINE_NUMBER = @line_num	
	  if @used_amt > 0
	  Begin
		set @used_amt = @used_amt - @current_amt
	  End	  		  
		
   end
 
end
else if @funct=2 --check if any approved estimates exist for JOB ...
 begin
     if exists(select JOB_NUMBER from ESTIMATE_APPROVAL where JOB_NUMBER=@job_number and JOB_COMPONENT_NBR=@job_component_nbr)
        begin
           select @approvals_exist=1
              select @est_info = 'Approvals exist.'
        end
       else
         begin
            select @est_info = 'No approved estimates exist for job/comp ' + cast(@job_number as varchar(15)) + '/' + cast(@job_component_nbr as varchar(15)) + '.'
          end
 end

           select @amt_approved = isnull(@amt_approved,0)
           select @est_info = isnull(@est_info,'')
           select @approved= isnull(@approved,0)
           select @used_amt=isnull(@used_amt,0)


select @approved=@approvals_exist

  return @approvals_exist






