UPDATE dbo.SEC_USER_SETTING 
SET STRING_VALUE = 
'<b>Desktop / Report Writer</b><br></br>
	Billing Approval<br></br>
	Campaign with Production & Media Summary<br></br>
	Month End Accounts Payable<br></br>
	Month End Accrued Liability<br></br>
	Month End Production WIP<br></br>
	Month End Media WIP<br></br>
	Security Time User Functions<br></br>
	Security User Login Audit<br></br>
	Vendor Spend by EEOC and Minority Detail<br></br>
	Vendor Spend by EEOC and Minority Summary<br></br>
<b>Media</b><br></br>
	Digital Campaign Manager<br></br>
<b>Broadcast Worksheet Actions</b><br></br>
	Spot Matching<br></br>
<b>Media Planning Actions</b><br></br>
	Allow Actualization to Vary from Last Plan<br></br>
<b>Maintenance / Accounting</b><br></br>
	QuickBooks Settings<br></br>
<b>Maintenance / General</b><br></br>
	Email Settings (WV Only)<br></br>
<b>Maintenance / Media</b><br></br>
	Channel<br></br>
	Mix Rate Template<br></br>
	National Universe<br></br>
	Tactic<br></br>
<b>Security</b><br></br>
	CDP Security Groups<br></br>
	Password Policy<br></br>',
NUMERIC_VALUE = 1 
WHERE SETTING_CODE = 'NewAdvantageApplicationsAlert'