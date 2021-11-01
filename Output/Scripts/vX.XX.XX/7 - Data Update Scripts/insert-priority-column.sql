IF NOT EXISTS (SELECT [COLUMN_NAME] FROM [dbo].[JOB_TRAFFIC_SETUP_ITEMS] WITH(NOLOCK) WHERE [COLUMN_NAME] = 'Priority')
BEGIN
    INSERT INTO [dbo].[JOB_TRAFFIC_SETUP_ITEMS]
               ([COLUMN_NAME]
               ,[COLUMN_LONG_DESC]
               ,[COLUMN_SHORT_DESC]
               ,[AGENCY_REQ]
               ,[CLIENT_REQ]
               ,[ACTIVE]
               ,[DEFAULT_SHOW_LONG_DESC]
               ,[COLUMN_ORDER])
         VALUES
               ('Priority',	'Task Priority',	'Priority',	0,	0,	1,	0,	37)
END



