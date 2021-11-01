


























create proc usp_mike_3
as


(
select   a.JOB_NUMBER, a.JOB_COMPONENT_NBR,  

sum(a.EMP_HOURS) EMP_HOURS, -- sum(EMP_HOURS) MY_EMP_HOURS ,
	

	(select  distinct b.JOB_COMP_DESC  from JOB_COMPONENT b 
	where 
	b.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR and b.JOB_NUMBER = 507 )


DESCRIPTION , datepart(mm ,c.EMP_DATE) 'Month'

from EMP_TIME_DTL a  right join EMP_TIME c on a.ET_ID = c.ET_ID



where ( UPPER(a.USER_ID) = 'MIKHAN' 
	or UPPER(a.USER_ID)  = 'CLAWIL')
and a.JOB_NUMBER = 507
and c.EMP_DATE  BETWEEN '1/1/03' and '11/01/03'


group by a.JOB_NUMBER,  a.JOB_COMPONENT_NBR , datepart(mm,c.EMP_DATE)
--order by datepart(mm ,c.EMP_DATE), JOB_COMPONENT_NBR desc 

)
union

( select 0, 0,  sum(EMP_HOURS), 'admin', datepart(mm,y.EMP_DATE)  EMP_DATE from 
EMP_TIME_NP x left join EMP_TIME y on x.ET_ID  = y.ET_ID

where 
	(UPPER(USER_ID) = 'MIKHAN' or UPPER(USER_ID) =  'CLAWIL')
	and CATEGORY = 'admin'

and y.EMP_DATE  BETWEEN '1/1/03' and '11/01/03'
group by  datepart(mm ,y.EMP_DATE)
)

order by datepart(mm ,c.EMP_DATE) -- , JOB_COMPONENT_NBR desc 

 



























