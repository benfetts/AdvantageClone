


























create proc usp_mike_2
as

select   a.JOB_NUMBER, a.JOB_COMPONENT_NBR,  

sum(EMP_HOURS) EMP_HOURS, -- sum(EMP_HOURS) MY_EMP_HOURS ,
	

(select  distinct b.JOB_COMP_DESC  from JOB_COMPONENT b 
	where 
	b.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR and b.JOB_NUMBER = 507 )

DESCRIPTION ,c.EMP_DATE
	from EMP_TIME_DTL a  left join EMP_TIME c on a.ET_ID = c.ET_ID


where USER_ID in ( 'MIKHAN' ,'CLAWIL')
and a.JOB_NUMBER = 507
and c.EMP_DATE  BETWEEN '6/30/03' and '11/01/03'

group by a.JOB_NUMBER,  a.JOB_COMPONENT_NBR , c.EMP_DATE 
order by c.EMP_DATE, JOB_COMPONENT_NBR desc 






























