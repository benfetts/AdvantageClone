UPDATE dbo.SEC_USER_SETTING 
SET STRING_VALUE = 
'<b>Desktop / Report Writer</b><br></br>
	Broadcast Invoice Summary<br></br>
	Employee Time Analysis<br></br>
<b>Media / Export</b><br></br>
	Broadcast Buy/Invoice<br></br>',
NUMERIC_VALUE = 1 
WHERE SETTING_CODE = 'NewAdvantageApplicationsAlert'