CREATE TABLE [dbo].[BILL_COMMENT] (
    [BC_ID]             INT         NOT NULL,
    [AR_INV_NBR]        INT         NOT NULL,
    [AR_INV_SEQ]        SMALLINT    NOT NULL,
    [AR_TYPE]           VARCHAR (3) NOT NULL,
    [JOB_NUMBER]        INT         NULL,
    [JOB_COMPONENT_NBR] SMALLINT    NULL,
    [BILL_COMMENT]      TEXT        NULL,
    [CL_CODE]           VARCHAR (6) NULL,
    [DIV_CODE]          VARCHAR (6) NULL,
    [PRD_CODE]          VARCHAR (6) NULL,
    [CMP_CODE]          VARCHAR (6) NULL
);

