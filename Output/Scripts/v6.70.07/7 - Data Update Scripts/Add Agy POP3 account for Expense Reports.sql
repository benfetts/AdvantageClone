IF NOT EXISTS (SELECT AGY.[DESCRIPTION] FROM AGY_POP3_ACCOUNT AGY WITH(NOLOCK) WHERE AGY.[DESCRIPTION] = 'Expense Report Receipts')
BEGIN

	INSERT INTO AGY_POP3_ACCOUNT WITH(ROWLOCK) ([POP3_ACCOUNT_TYPE]
                                              ,[DESCRIPTION]
                                              ,[USERNAME]
                                              ,[PASSWORD]
                                              ,[REPLY_TO]
                                              ,[DELETE_PROCESSED]) 
									VALUES (2, 
											'Expense Report Receipts', 
											NULL, 
											NULL,
                                            NULL,
                                            NULL);

END