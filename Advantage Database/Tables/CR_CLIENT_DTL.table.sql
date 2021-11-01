CREATE TABLE [dbo].[CR_CLIENT_DTL] (
    [REC_ID]           INT             NOT NULL,
    [SEQ_NBR]          SMALLINT        NOT NULL,
    [REC_ITEM_ID]      SMALLINT        NOT NULL,
    [DIV_CODE]         VARCHAR (6)     NULL,
    [PRD_CODE]         VARCHAR (6)     NULL,
    [AR_INV_NBR]       INT             NULL,
    [AR_INV_SEQ]       SMALLINT        NULL,
    [AR_TYPE]          VARCHAR (3)     NULL,
    [CR_PAY_AMT]       DECIMAL (14, 2) NULL,
    [CR_ADJ_AMT]       DECIMAL (14, 2) NULL,
    [GLACODE_AR]       VARCHAR (30)    NULL,
    [GLACODE_ADJ]      VARCHAR (30)    NULL,
    [GLEXACT]          INT             NULL,
    [GLESEQ_AR]        SMALLINT        NULL,
    [GLESEQ_ADJ]       SMALLINT        NULL,
    [POST_PERIOD]      VARCHAR (6)     NULL,
    [GLACODE_DUE_FROM] VARCHAR (30)    NULL,
    [GLACODE_DUE_TO]   VARCHAR (30)    NULL,
    [GLESEQ_DUE_FROM]  SMALLINT        NULL,
    [GLESEQ_DUE_TO]    SMALLINT        NULL
);

