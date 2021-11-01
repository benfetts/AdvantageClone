CREATE TABLE [dbo].[EVENT_TASK] (
    [EVENT_TASK_ID]      INT             IDENTITY (1, 1) NOT NULL,
    [EVENT_ID]           INT             NOT NULL,
    [TASK_CODE]          VARCHAR (10)    NULL,
    [EMP_CODE]           VARCHAR (6)     NULL,
    [START_DATE]         SMALLDATETIME   NULL,
    [END_DATE]           SMALLDATETIME   NULL,
    [START_TIME]         SMALLDATETIME   NULL,
    [END_TIME]           SMALLDATETIME   NULL,
    [TEMP_COMP_DATE]     SMALLDATETIME   NULL,
    [HOURS_ALLOWED]      DECIMAL (15, 2) NULL,
    [COMMENTS]           TEXT            NULL,
    [COMPLETED_COMMENTS] TEXT            NULL,
    [ROW_TYPE]           TINYINT         NULL,
    [EVENT_TYPE_ID]      SMALLINT        NULL
);

