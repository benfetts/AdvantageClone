CREATE TABLE [dbo].[ALERT_COMMENTS] (
    [COMMENT_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [ALERT_ID]       INT           NULL,
    [EMPCODE]        VARCHAR (6)   NULL,
    [GENERATED_DATE] DATETIME      NULL,
    [SUBJECT]        VARCHAR (150) NULL,
    [COMMENT]        TEXT          NULL
);

