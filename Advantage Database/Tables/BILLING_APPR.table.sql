CREATE TABLE [dbo].[BILLING_APPR] (
    [BA_ID]             INT             NOT NULL,
    [JOB_NUMBER]        INT             NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NOT NULL,
    [FNC_CODE]          VARCHAR (6)     NOT NULL,
    [APPROVED_AMT]      DECIMAL (15, 2) NULL,
    [APPROVAL_CODE]     VARCHAR (20)    NOT NULL,
    [APPR_COMMENTS]     TEXT            NULL,
    [FNC_COMMENTS]      TEXT            NULL,
    [ACCT_EXEC]         VARCHAR (6)     NOT NULL,
    [AR_INV_NBR]        INT             NULL,
    [AR_INV_SEQ]        SMALLINT        NULL,
    [AR_TYPE]           VARCHAR (3)     NULL,
    [BILL_HOLD]         SMALLINT        NULL,
    [BILLING_USER]      VARCHAR (100)   NULL,
    [INVOICE_DATE]      SMALLDATETIME   NULL
);

