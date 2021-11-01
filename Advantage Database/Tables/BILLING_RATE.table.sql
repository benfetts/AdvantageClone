CREATE TABLE [dbo].[BILLING_RATE] (
    [BILLING_RATE_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [BILL_RATE_PREC_ID] SMALLINT       NOT NULL,
    [EMP_CODE]          VARCHAR (6)    NULL,
    [FNC_CODE]          VARCHAR (6)    NULL,
    [CL_CODE]           VARCHAR (6)    NULL,
    [DIV_CODE]          VARCHAR (6)    NULL,
    [PRD_CODE]          VARCHAR (6)    NULL,
    [SC_CODE]           VARCHAR (6)    NULL,
    [EFFECTIVE_DATE]    SMALLDATETIME  NULL,
    [BILLING_RATE]      DECIMAL (9, 2) NULL,
    [NOBILL_FLAG]       SMALLINT       NULL,
    [FEE_TIME]          SMALLINT       NULL,
    [TAX_COMM_FLAGS]    SMALLINT       NULL,
    [COMMISSION]        DECIMAL (9, 3) NULL,
    [TAX_FLAG]          SMALLINT       NULL,
    [TAX_CODE]          VARCHAR (6)    NULL,
    [INACTIVE_FLAG]     SMALLINT       NULL,
    [EMPLOYEE_TITLE_ID] INT            NULL
);

