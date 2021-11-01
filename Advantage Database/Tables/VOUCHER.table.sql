CREATE TABLE [dbo].[VOUCHER] (
    [VOUCHER]     DECIMAL (8)     NULL,
    [VENDOR]      VARCHAR (8)     NULL,
    [INVNO]       VARCHAR (12)    NULL,
    [AP_ID]       INT             NULL,
    [AP_SEQ]      SMALLINT        NULL,
    [AP_LINE_NBR] SMALLINT        NULL,
    [BUY_DETID]   DECIMAL (8)     NULL,
    [BUY_ID]      DECIMAL (6)     NULL,
    [SPOTS]       DECIMAL (3)     NULL,
    [RATE]        DECIMAL (10, 2) NULL,
    [MEDIA]       VARCHAR (2)     NULL,
    [ORDER_NBR]   INT             NULL,
    [LINE_NBR]    INT             NULL,
    [REV_NBR]     SMALLINT        NULL,
    [WEEK]        SMALLDATETIME   NULL
);

