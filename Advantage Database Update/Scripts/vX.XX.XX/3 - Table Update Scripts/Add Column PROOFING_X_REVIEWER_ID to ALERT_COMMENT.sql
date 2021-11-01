IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ALERT_COMMENT' AND COLUMN_NAME = 'PROOFING_X_REVIEWER_ID') 
BEGIN
	ALTER TABLE [dbo].[ALERT_COMMENT] ADD [PROOFING_X_REVIEWER_ID] [INT] NULL;	
END
GO