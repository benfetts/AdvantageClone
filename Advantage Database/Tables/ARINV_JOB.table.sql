CREATE TABLE [dbo].[ARINV_JOB] (
    [AR_INV_NBR]        INT             NOT NULL,
    [AR_INV_SEQ]        SMALLINT        NOT NULL,
    [AR_TYPE]           VARCHAR (3)     NOT NULL,
    [AR_INV_DATE]       SMALLDATETIME   NOT NULL,
    [JOB_NUMBER]        INT             NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NOT NULL,
    [TECH_FEE_AMT]      DECIMAL (14, 2) NULL
);

