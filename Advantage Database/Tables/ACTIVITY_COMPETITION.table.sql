--GO
--GO
--GO
CREATE TABLE [dbo].[ACTIVITY_COMPETITION](
	[ACTIVITY_COMPETITION_ID] [int] IDENTITY(1,1) NOT NULL,
	[ACTIVITY_ID] [int] NOT NULL,
	[COMPETITION_ID] [int] NOT NULL,
 CONSTRAINT [PK_ACTIVITY_COMPETITION] PRIMARY KEY CLUSTERED 
(
	[ACTIVITY_COMPETITION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ACTIVITY_COMPETITION] ADD UNIQUE([ACTIVITY_ID], [COMPETITION_ID])
GO

ALTER TABLE [dbo].[ACTIVITY_COMPETITION] ADD CONSTRAINT [FK_ACTIVITY_COMPETITION_ACTIVITY]
	FOREIGN KEY([ACTIVITY_ID]) REFERENCES [dbo].[ACTIVITY] ([ACTIVITY_ID])
GO

ALTER TABLE [dbo].[ACTIVITY_COMPETITION] ADD CONSTRAINT [FK_ACTIVITY_COMPETITION_COMPETITION]
	FOREIGN KEY([COMPETITION_ID]) REFERENCES [dbo].COMPETITION ([COMPETITION_ID])
GO