CREATE TABLE [dbo].[VENDOR_RADIO] (
    [VN_CODE]       VARCHAR (6)     NOT NULL,
    [RATE_CARD]     VARCHAR (10)    NOT NULL,
    [ACTIVE]        SMALLINT        NULL,
    [MARKET_CODE]   VARCHAR (10)    NOT NULL,
    [ALL_MARKETS]   SMALLINT        NULL,
    [DATE_FROM]     SMALLDATETIME   NOT NULL,
    [DATE_TO]       SMALLDATETIME   NOT NULL,
    [WEEK_START]    SMALLINT        NULL,
    [GROSS_RATES]   SMALLINT        NULL,
    [MATL_CLOSE]    SMALLINT        NULL,
    [NET_RATES]     SMALLINT        NULL,
    [SPACE_CLOSE]   SMALLINT        NULL,
    [BLEED_PCT]     DECIMAL (7, 3)  NULL,
    [CLOSING_INFO]  TEXT            NULL,
    [COMM_PCT]      DECIMAL (7, 3)  NULL,
    [MISC_INFO]     TEXT            NULL,
    [POSITION_INFO] TEXT            NULL,
    [POSITION_PCT]  DECIMAL (7, 3)  NULL,
    [RATE_INFO]     TEXT            NULL,
    [RATE_BY]       SMALLINT        NULL,
    [DISC1]         DECIMAL (7, 3)  NULL,
    [DISC2]         DECIMAL (7, 3)  NULL,
    [DISC3]         DECIMAL (7, 3)  NULL,
    [DISC4]         DECIMAL (7, 3)  NULL,
    [DISC5]         DECIMAL (7, 3)  NULL,
    [DISC6]         DECIMAL (7, 3)  NULL,
    [DISC7]         DECIMAL (7, 3)  NULL,
    [DISC8]         DECIMAL (7, 3)  NULL,
    [DISC1DESC]     VARCHAR (10)    NULL,
    [DISC2DESC]     VARCHAR (10)    NULL,
    [DISC3DESC]     VARCHAR (10)    NULL,
    [DISC4DESC]     VARCHAR (10)    NULL,
    [DISC5DESC]     VARCHAR (10)    NULL,
    [DISC6DESC]     VARCHAR (10)    NULL,
    [DISC7DESC]     VARCHAR (10)    NULL,
    [DISC8DESC]     VARCHAR (10)    NULL,
    [RATE1]         DECIMAL (14, 3) NULL,
    [RATE2]         DECIMAL (14, 3) NULL,
    [RATE3]         DECIMAL (14, 3) NULL,
    [RATE4]         DECIMAL (14, 3) NULL,
    [RATE5]         DECIMAL (14, 3) NULL,
    [RATE6]         DECIMAL (14, 3) NULL,
    [RATE7]         DECIMAL (14, 3) NULL,
    [RATE8]         DECIMAL (14, 3) NULL,
    [RATE1DESC]     VARCHAR (10)    NULL,
    [RATE2DESC]     VARCHAR (10)    NULL,
    [RATE3DESC]     VARCHAR (10)    NULL,
    [RATE4DESC]     VARCHAR (10)    NULL,
    [RATE5DESC]     VARCHAR (10)    NULL,
    [RATE6DESC]     VARCHAR (10)    NULL,
    [RATE7DESC]     VARCHAR (10)    NULL,
    [RATE8DESC]     VARCHAR (10)    NULL
);

