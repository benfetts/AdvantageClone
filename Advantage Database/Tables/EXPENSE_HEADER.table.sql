CREATE TABLE [dbo].[EXPENSE_HEADER] (
    [INV_NBR]        INT             IDENTITY (1000000001, 1) NOT NULL,
    [EMP_CODE]       VARCHAR (6)     NULL,
    [VN_CODE]        VARCHAR (6)     NULL,
    [INV_DATE]       DATETIME        NULL,
    [EXP_DESC]       VARCHAR (30)    NULL,
    [DTL_DESC]       TEXT            NULL,
    [DATE_FROM]      DATETIME        NULL,
    [DATE_TO]        DATETIME        NULL,
    [INV_AMOUNT]     DECIMAL (14, 2) NULL,
    [APPROVED_BY]    VARCHAR (6)     NULL,
    [APPROVED_DATE]  DATETIME        NULL,
    [STATUS]         INT             DEFAULT (0) NULL,
    [APPR_NOTES]     VARCHAR (254)   NULL,
    [SUBMITTED_FLAG] SMALLINT        NULL,
    [APPROVED_FLAG]  SMALLINT        NULL
);

