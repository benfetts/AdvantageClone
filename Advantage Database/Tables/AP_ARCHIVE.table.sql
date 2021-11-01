CREATE TABLE [dbo].[AP_ARCHIVE] (
    [AP_ID]              INT             NOT NULL,
    [AP_SEQ]             SMALLINT        DEFAULT (0) NOT NULL,
    [LINE_NUMBER]        SMALLINT        NOT NULL,
    [AP_PROD_QUANTITY]   DECIMAL (14, 2) NULL,
    [AP_PROD_RATE]       DECIMAL (14, 2) NULL,
    [AP_PROD_EXT_AMT]    DECIMAL (14, 2) NULL,
    [AP_PROD_NOBILL_FLG] SMALLINT        NULL,
    [LINE_TOTAL]         DECIMAL (14, 2) NULL
);

