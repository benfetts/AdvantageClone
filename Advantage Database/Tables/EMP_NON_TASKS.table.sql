CREATE TABLE [dbo].[EMP_NON_TASKS] (
    [NON_TASK_ID]       INT             IDENTITY (1, 1) NOT NULL,
    [TYPE]              VARCHAR (6)     NOT NULL,
    [START_DATE]        SMALLDATETIME   NULL,
    [END_DATE]          SMALLDATETIME   NULL,
    [ALL_DAY]           INT             NULL,
    [NON_TASK_DESC]     VARCHAR (100)   NULL,
    [START_TIME]        DATETIME        NULL,
    [END_TIME]          DATETIME        NULL,
    [HOURS]             DECIMAL (15, 2) NULL,
    [EMP_CODE]          VARCHAR (6)     NULL,
    [CATEGORY]          VARCHAR (10)    NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [FNC_CODE]          VARCHAR (6)     NULL
);

