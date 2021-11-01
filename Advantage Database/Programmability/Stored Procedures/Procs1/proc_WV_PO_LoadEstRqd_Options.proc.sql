


CREATE PROCEDURE [dbo].[proc_WV_PO_LoadEstRqd_Options](@funct as integer, @empcode char(6), @job integer,
  @allow_wo_estimate as smallint OUTPUT,
  @allow_exceed_estimate as smallint OUTPUT, @op2 as smallint OUTPUT, @op4 as smallint OUTPUT,
  @display_msg varchar(100) OUTPUT) AS

 -- return info on whether user can submit a PO related to a job without an estimate and exceed estimate limit.
-- empcode for future use...

/*
declare @allow_wo_est as smallint
declare @allow_exceed_est as smallint
declare @o1 as smallint
declare @o2 as smallint
declare @msg as varchar(100)

 exec proc_WV_PO_LoadEstRqd_Options 1, 'ama', 56, @allow_wo_est OUTPUT, @allow_exceed_est OUTPUT,
          @o1 OUTPUT, @o2 OUTPUT, @msg OUTPUT

  print @allow_wo_est
*/


declare @tempallow as smallint
declare @finalallow as smallint

select @op2=0 --init
select @op4=0

if @funct=1
begin

  select  @tempallow =  ALLOW_PROCESSING from EST_REQ_OPT where EST_REQ_OPT_DESC='Purchase Orders'
        if @tempallow=0

           begin 
             -- if estimate required on job level, do not allow
             select  @finalallow= case when (select count(JOB_ESTIMATE_REQ) from JOB_LOG where JOB_NUMBER=@job 
               and JOB_ESTIMATE_REQ=1)=1 then 0 else 1 end
           end
         else
           begin
               select @finalallow=@tempallow
           end


  select @allow_wo_estimate= @finalallow,
              @allow_exceed_estimate = EXCEED_OPTION, 
              @display_msg=DISPLAY_MSG from EST_REQ_OPT
               where EST_REQ_OPT_DESC='Purchase Orders'
end



