
--exec proc_WV_PO_Memos_LoadDefault 'est_log_comment', 89, null,''
--exec proc_WV_PO_Memos_LoadDefault 'est_log_comment', 88, '44', ''

CREATE PROCEDURE [dbo].[proc_WV_PO_Memos_LoadDefault](@funct varchar(25),  @refid integer, @str varchar(25),@reftype char(5), @fn_code varchar(6), @seq_nbr int) AS
create table #T1 (
                             PO_NUMBER integer,
                             JOB_NUMBER integer,
                             JOB_COMPONENT_NBR integer)


--insert into #T1(PO_NUMBER,JOB_NUMBER, JOB_COMPONENT_NBR)
   --select distinct  @refid, JOB_NUMBER, JOB_COMPONENT_NBR, from PURCHASE_ORDER_DET as d
    --where PO_NUMBER = @refid and JOB_NUMBER = @job

declare @job integer
 if isnumeric(@str) = 1
  begin
   select @job= cast(@str as integer)
  end
  else
   begin
   select @job=0
  end
    
if @job <> 0
begin
insert into #T1 (PO_NUMBER,JOB_NUMBER, JOB_COMPONENT_NBR)
select distinct @refid, JOB_NUMBER, JOB_COMPONENT_NBR from JOB_COMPONENT as d
  where JOB_NUMBER = @job
end


if @funct = 'default_po_footer'
 begin
   select isnull(PO_FOOTER,'') as PO_FOOTER  from AGENCY
 end

else if @funct = 'est_log_comment'  -- estimate comment for all approved estimate components related to jobs on PO.
 begin
   
select isnull(EST_LOG_COMMENT,'') as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10))
 from ESTIMATE_APPROVAL as ea 
join ESTIMATE_LOG as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
  where EXISTS (
select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR )
end

else if @funct='est_comp_comment'
begin
select EST_COMP_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
 from ESTIMATE_APPROVAL as ea 
join ESTIMATE_COMPONENT as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
  where EXISTS (
select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR )
end

else if @funct = 'est_qte_comment'
begin
select EST_QTE_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
 from ESTIMATE_APPROVAL as ea 
join ESTIMATE_QUOTE as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR
  where EXISTS (
select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
end

else if @funct = 'est_rev_comment'
begin
select EST_REV_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
 from ESTIMATE_APPROVAL as ea 
join ESTIMATE_REV as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR
  where EXISTS (
select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
end

else if @funct = 'est_funct_comment'
begin
 if @seq_nbr = -1
 Begin
	select EST_FNC_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
	JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
	+ ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
	+ ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE
	from ESTIMATE_APPROVAL as ea 
	join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
	and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code
	  where EXISTS (
	select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
	  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
 End
 Else
 Begin
	select EST_FNC_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
	JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
	+ ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
	+ ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE
	from ESTIMATE_APPROVAL as ea 
	join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
	and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code and el.SEQ_NBR = @seq_nbr
	  where EXISTS (
	select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
	  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
 End
 
end

else if @funct='supply_by_notes'
begin
 if @seq_nbr = -1
 Begin
	select EST_REV_SUP_BY_NTE as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
	 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
	 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
	 + ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE
	 from ESTIMATE_APPROVAL as ea 
	join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
		and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code
	  where EXISTS (
	select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
	  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
 End
 Else
 Begin
	select EST_REV_SUP_BY_NTE as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
	 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
	 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
	 + ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE
	 from ESTIMATE_APPROVAL as ea 
	join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
		and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code and el.SEQ_NBR = @seq_nbr
	  where EXISTS (
	select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
	  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
 End


end

else if @funct='all'
begin
 if @seq_nbr = -1
 Begin
	select isnull(EST_LOG_COMMENT,'') as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)), 'est_log_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_LOG as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR )
		UNION ALL
		select EST_COMP_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10)), 'est_comp_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_COMPONENT as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR )
		UNION ALL
		select EST_QTE_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10)), 'est_qte_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_QUOTE as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		UNION ALL
		select EST_REV_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10)), 'est_rev_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_REV as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		UNION ALL
		 select EST_FNC_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
			JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
			+ ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
			+ ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE, 'est_funct_comment' as type
			from ESTIMATE_APPROVAL as ea 
			join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
			and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code
			  where EXISTS (
			select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
			  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		UNION ALL
		select EST_REV_SUP_BY_NTE as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
		 + ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE, 'supply_by_notes' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
			and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		 End
 Else
 Begin
	select isnull(EST_LOG_COMMENT,'') as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)), 'est_log_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_LOG as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR )
		UNION ALL
		select EST_COMP_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10)), 'est_comp_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_COMPONENT as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR )
		UNION ALL
		select EST_QTE_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10)), 'est_qte_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_QUOTE as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		UNION ALL
		select EST_REV_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10)), 'est_rev_comment' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_REV as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		UNION ALL
		 select EST_FNC_COMMENT as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
			JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
			+ ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
			+ ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE, 'est_funct_comment' as type
			from ESTIMATE_APPROVAL as ea 
			join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
			and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code and el.SEQ_NBR = @seq_nbr
			  where EXISTS (
			select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
			  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
		UNION ALL
		select EST_REV_SUP_BY_NTE as Comment, ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, 
		 JOB_AND_COMP = 'Job: ' + cast(ea.JOB_NUMBER as varchar(15)) + ' Comp: ' + cast(ea.JOB_COMPONENT_NBR as varchar(5))
		 + ' Est. ' + cast(ea.ESTIMATE_NUMBER as varchar(10)) +  ' Est Comp. ' + cast(ea.EST_COMPONENT_NBR as varchar(10))
		 + ' Quote: ' + cast(el.EST_QUOTE_NBR as varchar(10)) + ' Function: ' + el.FNC_CODE, 'supply_by_notes' as type
		 from ESTIMATE_APPROVAL as ea 
		join ESTIMATE_REV_DET as el on el.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER and el.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR 
			and el.EST_QUOTE_NBR = ea.EST_QUOTE_NBR and el.EST_REV_NBR = ea.EST_REVISION_NBR and el.FNC_CODE = @fn_code and el.SEQ_NBR = @seq_nbr
		  where EXISTS (
		select distinct JOB_NUMBER, JOB_COMPONENT_NBR from #T1 as d
		  where PO_NUMBER = @refid and JOB_NUMBER=ea.JOB_NUMBER and ea.JOB_COMPONENT_NBR= d.JOB_COMPONENT_NBR)
 End




end

drop table #T1


