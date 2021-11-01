CREATE TABLE [dbo].[AP_IMPORT_TRAN] (
    [VENDOR]        VARCHAR (6)    NULL,
    [INV_NUMBER]    VARCHAR (40)   NULL,
    [INV_DATE]      SMALLDATETIME  NULL,
    [DESCRIPTION]   VARCHAR (30)   NULL,
    [INV_AMT]       DECIMAL (7, 2) NULL,
    [JOB_NUMBER]    INT            NULL,
    [FNC_CODE]      VARCHAR (6)    NULL,
    [GL_ACCT]       VARCHAR (30)   NULL,
    [NET_AMT]       DECIMAL (7, 2) NULL,
    [LINE_NBR]      INT            NULL,
    [IMPORT_STAT]   VARCHAR (1)    NULL,
    [JOB_COMPONENT] SMALLINT       NULL
);

