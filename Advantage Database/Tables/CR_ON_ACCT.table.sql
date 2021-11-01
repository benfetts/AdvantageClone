CREATE TABLE [dbo].[CR_ON_ACCT] (
    [REC_ID]           INT             NOT NULL,
    [SEQ_NBR]          SMALLINT        NOT NULL,
    [REC_ITEM_ID]      SMALLINT        NOT NULL,
    [CL_CODE]          VARCHAR (6)     NULL,
    [DIV_CODE]         VARCHAR (6)     NULL,
    [PRD_CODE]         VARCHAR (6)     NULL,
    [CMP_CODE]         VARCHAR (6)     NULL,
    [CR_OA_AMT]        DECIMAL (14, 2) NOT NULL,
    [GLACODE_OA]       VARCHAR (30)    NOT NULL,
    [GLEXACT]          INT             NOT NULL,
    [GLESEQ]           SMALLINT        NOT NULL,
    [CR_OA_DIST]       VARCHAR (1)     NULL,
    [POST_PERIOD]      VARCHAR (6)     NULL,
    [OFFICE_CODE]      VARCHAR (4)     NULL,
    [GLACODE_DUE_FROM] VARCHAR (30)    NULL,
    [GLACODE_DUE_TO]   VARCHAR (30)    NULL,
    [GLESEQ_DUE_FROM]  SMALLINT        NULL,
    [GLESEQ_DUE_TO]    SMALLINT        NULL,
    [OA_COMMENT]       VARCHAR (254)   NULL
);

