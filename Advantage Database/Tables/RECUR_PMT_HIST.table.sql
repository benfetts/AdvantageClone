CREATE TABLE [dbo].[RECUR_PMT_HIST] (
    [RP_ID]        INT             NOT NULL,
    [BK_CODE]      VARCHAR (4)     NOT NULL,
    [CHECK_NBR]    INT             NOT NULL,
    [CHECK_DATE]   SMALLDATETIME   NOT NULL,
    [PAY_AMOUNT]   DECIMAL (14, 2) NULL,
    [GLACODE_DB]   VARCHAR (30)    NULL,
    [GLACODE_CASH] VARCHAR (30)    NULL,
    [GLEXACT]      INT             NULL,
    [GLESEQ_DB]    SMALLINT        NULL,
    [GLESEQ_CASH]  SMALLINT        NULL
);

