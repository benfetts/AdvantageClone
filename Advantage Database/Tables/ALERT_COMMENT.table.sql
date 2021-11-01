CREATE TABLE [dbo].[ALERT_COMMENT] (
    [COMMENT_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [ALERT_ID]       INT           NOT NULL,
    [USER_CODE]      VARCHAR (100) NULL,
    [GENERATED_DATE] SMALLDATETIME NULL,
    [COMMENT]        TEXT          NULL,
    [EMAILSENT]      BIT           DEFAULT (0) NOT NULL
);

