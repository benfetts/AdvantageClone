CREATE TABLE [dbo].[TMP_JTD] (
    [JOB_NUMBER]         INT            NOT NULL,
    [JOB_COMPONENT_NBR]  SMALLINT       NOT NULL,
    [SEQ_NBR]            SMALLINT       NULL,
    [FNC_CODE]           VARCHAR (10)   NULL,
    [TASK_DESCRIPTION]   VARCHAR (40)   NULL,
    [EMP_CODE]           VARCHAR (6)    NULL,
    [JOB_DUE_DATE]       SMALLDATETIME  NULL,
    [JOB_REVISED_DATE]   SMALLDATETIME  NULL,
    [DUE_DATE_LOCK]      SMALLINT       NULL,
    [JOB_COMPLETED_DATE] SMALLDATETIME  NULL,
    [JOB_ORDER]          SMALLINT       NULL,
    [JOB_DAYS]           SMALLINT       NULL,
    [FNC_COMMENTS]       TEXT           NULL,
    [DUE_DATE_COMMENTS]  TEXT           NULL,
    [REV_DATE_COMMENTS]  TEXT           NULL,
    [JOB_HRS]            NUMERIC (8, 2) NULL,
    [DUE_TIME]           VARCHAR (10)   NULL,
    [REVISED_DUE_TIME]   VARCHAR (10)   NULL,
    [RESEQ_FLAG]         SMALLINT       NULL
);

