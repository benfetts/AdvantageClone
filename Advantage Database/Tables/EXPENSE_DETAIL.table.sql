CREATE TABLE [dbo].[EXPENSE_DETAIL] (
    [EXPDETAILID]    INT             IDENTITY (1, 1) NOT NULL,
    [INV_NBR]        INT             NOT NULL,
    [LINE_NBR]       INT             NOT NULL,
    [ITEM_DATE]      DATETIME        NULL,
    [ITEM_DESC]      VARCHAR (200)   NULL,
    [CC_FLAG]        BIT             DEFAULT (0) NULL,
    [CL_CODE]        VARCHAR (6)     NULL,
    [DIV_CODE]       VARCHAR (6)     NULL,
    [PRD_CODE]       VARCHAR (6)     NULL,
    [JOB_NBR]        INT             NULL,
    [JOB_COMP_NBR]   SMALLINT        NULL,
    [FNC_CODE]       VARCHAR (6)     NULL,
    [QTY]            INT             NULL,
    [RATE]           DECIMAL (9, 3)  NULL,
    [CC_AMT]         DECIMAL (14, 2) NULL,
    [AMOUNT]         DECIMAL (14, 2) NULL,
    [AP_COMMENT]     VARCHAR (100)   NULL,
    [CREATE_USER_ID] VARCHAR (6)     NULL,
    [MOD_USER_ID]    VARCHAR (6)     NULL,
    [MOD_DATE]       DATETIME        NULL
);

