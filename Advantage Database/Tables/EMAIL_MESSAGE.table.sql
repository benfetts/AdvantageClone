CREATE TABLE [dbo].[EMAIL_MESSAGE] (
    [EMAIL_MESSAGE_ID] INT           IDENTITY (1, 1) NOT NULL,
    [EMAIL_USER_ID]    VARCHAR (100) NOT NULL,
    [EMAIL_FROM]       VARCHAR (254) NULL,
    [EMAIL_TO]         TEXT          NOT NULL,
    [EMAIL_CC]         TEXT          NULL,
    [EMAIL_BCC]        TEXT          NULL,
    [EMAIL_SUBJECT]    TEXT          NULL,
    [EMAIL_BODY]       TEXT          NULL
);

