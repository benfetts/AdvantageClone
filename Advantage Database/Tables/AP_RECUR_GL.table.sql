CREATE TABLE [dbo].[AP_RECUR_GL] (
    [RECUR_ID]    INT             NOT NULL,
    [LINE_NUMBER] SMALLINT        NOT NULL,
    [GLACODE]     VARCHAR (30)    NOT NULL,
    [OFFICE_CODE] VARCHAR (4)     NULL,
    [GL_AMT]      DECIMAL (15, 2) NOT NULL,
    [COMMENTS]    TEXT            NULL
);

