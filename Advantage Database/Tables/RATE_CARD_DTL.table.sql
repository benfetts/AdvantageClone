CREATE TABLE [dbo].[RATE_CARD_DTL] (
    [RATE_CARD_ID]      INT             NOT NULL,
    [RATE_DTL_ID]       INT             NOT NULL,
    [RATE_DESC]         VARCHAR (60)    NOT NULL,
    [RATE_BY]           SMALLINT        NOT NULL,
    [RATE]              DECIMAL (15, 4) NULL,
    [RATE_TYPE]         SMALLINT        NOT NULL,
    [CONTRACT_QUANTITY] DECIMAL (8, 2)  NULL,
    [RATE_NOTES]        TEXT            NULL
);

