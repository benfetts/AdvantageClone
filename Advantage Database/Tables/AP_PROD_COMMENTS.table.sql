CREATE TABLE [dbo].[AP_PROD_COMMENTS] (
    [AP_ID]             INT         NOT NULL,
    [LINE_NUMBER]       SMALLINT    NOT NULL,
    [JOB_NUMBER]        INT         NULL,
    [JOB_COMPONENT_NBR] SMALLINT    NULL,
    [FNC_CODE]          VARCHAR (6) NULL,
    [AP_COMMENT]        TEXT        NULL
);

