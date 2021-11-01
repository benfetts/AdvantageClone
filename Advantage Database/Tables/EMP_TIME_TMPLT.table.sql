CREATE TABLE [dbo].[EMP_TIME_TMPLT] (
    [EMP_TIME_TMPLT_ID] INT            IDENTITY (1, 1) NOT NULL,
    [EMP_CODE]          VARCHAR (6)    NOT NULL,
    [JOB_NUMBER]        INT            NULL,
    [JOB_COMPONENT_NBR] SMALLINT       NULL,
    [FNC_CODE]          VARCHAR (10)   NOT NULL,
    [DFLT_COMMENT]      TEXT           NULL,
    [DP_TM_CODE]        VARCHAR (4)    NULL,
    [PROD_CAT_CODE]     VARCHAR (10)   NULL,
    [EMP_HOURS]         DECIMAL (7, 2) NULL,
    [APPLY_TO_DAYS]     VARCHAR (30)   NULL
);

