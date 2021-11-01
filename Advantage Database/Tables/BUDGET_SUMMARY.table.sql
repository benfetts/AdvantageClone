CREATE TABLE [dbo].[BUDGET_SUMMARY] (
    [BUDGET_CODE]    VARCHAR (10)    NOT NULL,
    [REV_NBR]        SMALLINT        NOT NULL,
    [SEQ_NBR]        INT             NOT NULL,
    [LINE_NBR]       INT             NOT NULL,
    [OFFICE_CODE]    VARCHAR (4)     NOT NULL,
    [CL_CODE]        VARCHAR (6)     NOT NULL,
    [DIV_CODE]       VARCHAR (6)     NOT NULL,
    [PRD_CODE]       VARCHAR (6)     NOT NULL,
    [BUDGET_PERIOD]  VARCHAR (6)     NOT NULL,
    [BUDGET_TYPE]    VARCHAR (1)     NULL,
    [SC_CODE]        VARCHAR (6)     NULL,
    [BILLING_AMOUNT] DECIMAL (18, 2) NULL,
    [INCOME_AMOUNT]  DECIMAL (18, 2) NULL
);

