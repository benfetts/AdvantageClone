UPDATE dbo.SEC_USER_SETTING 
SET STRING_VALUE = 
'<b>Desktop / Report Writer</b><br></br>
	Broadcast Invoice Summary<br></br>
	Employee Time Analysis<br></br>
<b>Finance & Accounting/Dashboards</b><br></br>
	Employee Utilization By Department<br></br>
	Financial Dashboard<br></br>
<b>Media / Export</b><br></br>
	Broadcast Buy/Invoice<br></br>',
NUMERIC_VALUE = 1 
WHERE SETTING_CODE = 'NewAdvantageApplicationsAlert'