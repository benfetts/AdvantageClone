CREATE TABLE [dbo].[MAR_AUTH] (
    [MAR_NUMBER]     INT             NOT NULL,
    [REV_NBR]        SMALLINT        NOT NULL,
    [AUTH_LINE_NBR]  INT             NOT NULL,
    [AUTH_NUMBER]    VARCHAR (30)    NOT NULL,
    [AUTH_SPLIT_AMT] DECIMAL (15, 2) NULL
);

