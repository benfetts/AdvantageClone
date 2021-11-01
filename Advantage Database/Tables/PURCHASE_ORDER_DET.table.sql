CREATE TABLE [dbo].[PURCHASE_ORDER_DET] (
    [PO_NUMBER]         INT             NOT NULL,
    [LINE_NUMBER]       INT             NOT NULL,
    [DET_DESC]          TEXT            NULL,
    [LINE_DESC]         VARCHAR (40)    NULL,
    [DET_INSTRUCT]      TEXT            NULL,
    [PO_QTY]            INT             NULL,
    [PO_RATE]           DECIMAL (9, 3)  NULL,
    [PO_EXT_AMOUNT]     DECIMAL (14, 2) NULL,
    [PO_TAX_PCT]        DECIMAL (8, 4)  NULL,
    [PO_COMPLETE]       SMALLINT        NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [FNC_CODE]          VARCHAR (6)     NULL,
    [PO_COMM_PCT]       DECIMAL (9, 3)  NULL,
    [EXT_MARKUP_AMT]    DECIMAL (15, 2) NULL,
    [GLACODE]           VARCHAR (30)    NULL,
    [BA_ID]             INT             NULL
);

