UPDATE dbo.AGY_SETTINGS
SET AGY_SETTINGS_VALUE = 'sftp2.csipaysystems.com:22999', AGY_SETTINGS_DEF = 'sftp2.csipaysystems.com:22999'
WHERE AGY_SETTINGS_CODE IN ('CSI_CCDATA_FTP','CSI_GVCARD_FTP')


UPDATE 
	[dbo].[AGY_SETTINGS] 
SET 
	AGY_SETTINGS_VALUE = 'transfer.comdata.com:50039', 
	AGY_SETTINGS_DEF = 'transfer.comdata.com:50039' 
WHERE 
	AGY_SETTINGS_CODE = 'CSI_COMDATA_FTP'
