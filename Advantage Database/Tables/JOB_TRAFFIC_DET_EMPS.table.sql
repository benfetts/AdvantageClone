﻿CREATE TABLE [dbo].[JOB_TRAFFIC_DET_EMPS] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [JOB_NUMBER]         INT            NOT NULL,
    [JOB_COMPONENT_NBR]  SMALLINT       NOT NULL,
    [SEQ_NBR]            SMALLINT       NOT NULL,
    [EMP_CODE]           VARCHAR (6)    NOT NULL,
    [HOURS_ALLOWED]      DECIMAL (8, 2) NULL,
    [TEMP_COMP_DATE]     SMALLDATETIME  NULL,
    [COMPLETED_COMMENTS] TEXT           NULL,
    [PERCENT_COMPLETE]   DECIMAL (7, 3) NULL
);

