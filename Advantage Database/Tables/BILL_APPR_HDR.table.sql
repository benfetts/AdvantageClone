CREATE TABLE [dbo].[BILL_APPR_HDR] (
    [BA_HDR_ID]         INT             IDENTITY (1, 1) NOT NULL,
    [BA_ID]             INT             NOT NULL,
    [JOB_NUMBER]        INT             NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NOT NULL,
    [ACCT_EXEC]         VARCHAR (6)     NOT NULL,
    [APPROVED_AMT]      DECIMAL (15, 2) NULL,
    [APPR_COMMENTS]     TEXT            NULL,
    [CLIENT_COMMENTS]   TEXT            NULL,
    [CREATE_DATE]       SMALLDATETIME   NULL,
    [CREATE_USER]       VARCHAR (100)   NULL,
    [AR_INV_NBR]        INT             NULL,
    [INVOICE_DATE]      SMALLDATETIME   NULL,
    [BILL_TYPE]         TINYINT         NULL,
    [ADJUSTED]          BIT             NULL,
    [APPR_STATUS]       SMALLINT        NULL
);

