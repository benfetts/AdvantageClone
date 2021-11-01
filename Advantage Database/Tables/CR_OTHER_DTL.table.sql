CREATE TABLE [dbo].[CR_OTHER_DTL] (
    [REC_ID]      INT             NOT NULL,
    [SEQ_NBR]     SMALLINT        NOT NULL,
    [GLACODE]     VARCHAR (30)    NOT NULL,
    [CR_AMOUNT]   DECIMAL (14, 2) NULL,
    [GLEXACT]     INT             NOT NULL,
    [GLESEQ]      SMALLINT        NOT NULL,
    [POST_PERIOD] VARCHAR (6)     NULL,
    [REC_ITEM_ID] SMALLINT        DEFAULT (0) NOT NULL
);

