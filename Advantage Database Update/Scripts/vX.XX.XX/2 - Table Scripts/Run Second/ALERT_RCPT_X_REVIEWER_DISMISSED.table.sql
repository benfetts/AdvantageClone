IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ALERT_RCPT_X_REVIEWER_DISMISSED') 
BEGIN
   DROP TABLE [dbo].[ALERT_RCPT_X_REVIEWER_DISMISSED];  
END
GO
IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ALERT_RCPT_X_REVIEWER_DISMISSED') 
BEGIN
	CREATE TABLE [dbo].[ALERT_RCPT_X_REVIEWER_DISMISSED](
		ID [INT] IDENTITY,
		[ALERT_ID] [int] NOT NULL,
		[PROOFING_EXTERNAL_REVIEWER_ID] [int] NOT NULL,
		[ALRT_NOTIFY_HDR_ID] [int] NULL,
		[ALERT_STATE_ID] [int] NULL,
		[PROOFING_STATUS_ID] [smallint] NULL,
		[IS_READ] [BIT] NULL,
	 CONSTRAINT [PK_ALERT_RCPT_X_REVIEWER_DISMISSED] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ALERT_RCPT_X_REVIEWER_DISMISSED]  WITH CHECK ADD  CONSTRAINT [FK_ALERT_RCPT_X_REVIEWER_DISMISSED] FOREIGN KEY([ALERT_ID])
	REFERENCES [dbo].[ALERT] ([ALERT_ID])

	ALTER TABLE [dbo].[ALERT_RCPT_X_REVIEWER_DISMISSED] CHECK CONSTRAINT [FK_ALERT_RCPT_X_REVIEWER_DISMISSED]

	ALTER TABLE [dbo].[ALERT_RCPT_X_REVIEWER_DISMISSED]  WITH CHECK ADD  CONSTRAINT [FK_ALERT_RCPT_X_REVIEWER_DISMISSED_PROOFING_X_REVIEWER] FOREIGN KEY([PROOFING_EXTERNAL_REVIEWER_ID])
	REFERENCES [dbo].[PROOFING_X_REVIEWER] ([ID])

	ALTER TABLE [dbo].[ALERT_RCPT_X_REVIEWER_DISMISSED] CHECK CONSTRAINT [FK_ALERT_RCPT_X_REVIEWER_DISMISSED_PROOFING_X_REVIEWER]

END
GO