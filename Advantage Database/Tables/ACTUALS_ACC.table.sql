CREATE TABLE [dbo].[ACTUALS_ACC] (
    [CATEGORY_CODE]     VARCHAR (6)     NOT NULL,
    [OFFICE_CODE]       VARCHAR (4)     NOT NULL,
    [CL_CODE]           VARCHAR (6)     NOT NULL,
    [DIV_CODE]          VARCHAR (6)     NOT NULL,
    [PRD_CODE]          VARCHAR (6)     NOT NULL,
    [PPERIOD]           VARCHAR (6)     NOT NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [ACTUALS_TYPE]      VARCHAR (20)    NULL,
    [SC_CODE]           VARCHAR (6)     NULL,
    [FNC_CODE]          VARCHAR (6)     NULL,
    [BILL_PERIOD]       VARCHAR (6)     NULL,
    [AMOUNT]            DECIMAL (18, 2) NULL,
    [ACTUAL_GRP]        SMALLINT        NULL
);

