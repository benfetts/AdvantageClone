CREATE TABLE [dbo].[CLIENT_OOP] (
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [SEQ_NBR]           SMALLINT        NULL,
    [FNC_CODE]          VARCHAR (6)     NULL,
    [INV_NBR]           VARCHAR (20)    NULL,
    [INV_DATE]          SMALLDATETIME   NULL,
    [AMOUNT]            DECIMAL (14, 2) NULL,
    [DESCRIPTION]       VARCHAR (30)    NULL,
    [OOP_ID]            INT             NOT NULL,
    [DP_TM_CODE]        VARCHAR (6)     NULL,
    [DELETE_FLAG]       SMALLINT        NULL,
    [CLEARING_NBR]      VARCHAR (20)    NULL,
    [RECEIPT_DATE]      SMALLDATETIME   NULL,
    [CLEARING_DATE]     SMALLDATETIME   NULL,
    [SENT_DATE]         SMALLDATETIME   NULL,
    [USER_ID]           VARCHAR (100)   NULL,
    [CREATE_DATE]       SMALLDATETIME   NULL
);

