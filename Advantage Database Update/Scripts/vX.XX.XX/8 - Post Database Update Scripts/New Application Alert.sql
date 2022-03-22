UPDATE dbo.SEC_USER_SETTING 
SET STRING_VALUE = 
'<b>Desktop / Report Writer</b><br></br>
    Broadcast Invoice Detail<br></br>
    Broadcast Invoice Summary<br></br>
    Campaign with Production & Media Summary<br></br>
    Deferred Sales Vs. Open AR<br></br>
    Employee Time Analysis<br></br>
    General Ledger Cross Office<br></br>
<b>Finance & Accounting/Dashboards</b><br></br>
    Employee Utilization By Department<br></br>
    Financial Dashboard<br></br>
<b>Media</b><br></br>
    Comscore Pre-cache<br></br>
<b>Media / Export</b><br></br>
    Broadcast Buy/Invoice<br></br>
<b>Media / Report</b><br></br>
    Broadcast Invoice<br></br>',
NUMERIC_VALUE = 1 
WHERE SETTING_CODE = 'NewAdvantageApplicationsAlert'