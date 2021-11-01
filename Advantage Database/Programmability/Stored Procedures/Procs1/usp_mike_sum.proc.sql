


























create proc usp_mike_sum 

as
(
select   a.JOB_NUMBER, a.JOB_COMPONENT_NBR, sum(EMP_HOURS) MY_EMP_HOURS, 

	(select  distinct b.JOB_COMP_DESC  from JOB_COMPONENT b 
	where 
	b.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR and b.JOB_NUMBER = 507 ) 
	'Description'

  from EMP_TIME_DTL a  left join EMP_TIME c on a.ET_ID = c.ET_ID


where ( UPPER(USER_ID) =   'MIKHAN'  or 
	UPPER(USER_ID) = 'CLAWIL')
and a.JOB_NUMBER = 507
and c.EMP_DATE  BETWEEN '1/1/03' and '11/01/03'

group by a.JOB_NUMBER,  a.JOB_COMPONENT_NBR  
--order by MY_EMP_HOURS desc 
)
union 

( 
select 0, 0,  sum(EMP_HOURS) MY_EMP_HOURS, 'admin'  from 
EMP_TIME_NP x left join EMP_TIME y on x.ET_ID  = y.ET_ID

where 
	(UPPER(USER_ID) = 'MIKHAN' or UPPER(USER_ID) =  'CLAWIL')
	and CATEGORY = 'admin'
	and y.EMP_DATE  BETWEEN '1/1/03' and '11/01/03'

)
order by MY_EMP_HOURS  desc 



























