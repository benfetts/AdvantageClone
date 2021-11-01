CREATE TABLE [dbo].[SERVICE_FEE_INV] (
    [JOB_NUMBER]        INT           NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT      NOT NULL,
    [IO_ID]             INT           NOT NULL,
    [SEQ_NBR]           SMALLINT      NULL,
    [IO_INV_NBR]        VARCHAR (20)  NULL,
    [FEE_RECONCILED]    SMALLINT      NULL,
    [DATE_CREATED]      SMALLDATETIME NULL,
    [CREATED_BY]        VARCHAR (100) NULL
);

