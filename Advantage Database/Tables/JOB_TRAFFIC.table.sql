CREATE TABLE [dbo].[JOB_TRAFFIC] (
    [JOB_NUMBER]        INT            NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT       NOT NULL,
    [TRF_CODE]          VARCHAR (10)   NULL,
    [TRF_PRESET_CODE]   VARCHAR (6)    NULL,
    [TRF_COMMENTS]      TEXT           NULL,
    [ASSIGN_1]          VARCHAR (6)    NULL,
    [ASSIGN_2]          VARCHAR (6)    NULL,
    [ASSIGN_3]          VARCHAR (6)    NULL,
    [ASSIGN_4]          VARCHAR (6)    NULL,
    [ASSIGN_5]          VARCHAR (6)    NULL,
    [COMPLETED_DATE]    SMALLDATETIME  NULL,
    [DATE_DELIVERED]    SMALLDATETIME  NULL,
    [DATE_SHIPPED]      SMALLDATETIME  NULL,
    [RECEIVED_BY]       VARCHAR (40)   NULL,
    [REFERENCE]         VARCHAR (150)  NULL,
    [ROWID]             INT            IDENTITY (1, 1) NOT NULL,
    [MGR_EMP_CODE]      AS             ([dbo].[udf_get_traffic_mgr]([JOB_NUMBER], [JOB_COMPONENT_NBR])),
    [LOCK_USER]         VARCHAR (100)  NULL,
    [LOCKED_USER]       VARCHAR (100)  NULL,
    [PERCENT_COMPLETE]  DECIMAL (7, 3) NULL
);

