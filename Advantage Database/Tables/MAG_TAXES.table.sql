CREATE TABLE [dbo].[MAG_TAXES] (
    [ORDER_NBR]      INT             NOT NULL,
    [LINE_NBR]       SMALLINT        NOT NULL,
    [REV_NBR]        SMALLINT        NOT NULL,
    [SEQ_NBR]        SMALLINT        NOT NULL,
    [TAX_CODE]       VARCHAR (4)     NULL,
    [TAX_STATE_PCT]  DECIMAL (7, 4)  NULL,
    [TAX_COUNTY_PCT] DECIMAL (7, 4)  NULL,
    [TAX_CITY_PCT]   DECIMAL (7, 4)  NULL,
    [TAXAPPLYC]      SMALLINT        NULL,
    [TAXAPPLYLN]     SMALLINT        NULL,
    [TAXAPPLYLND]    SMALLINT        NULL,
    [TAXAPPLYNC]     SMALLINT        NULL,
    [TAXAPPLYNCD]    SMALLINT        NULL,
    [TAXAPPLYR]      SMALLINT        NULL,
    [TAX_RESALE]     SMALLINT        NULL,
    [VENDOR_TAX]     DECIMAL (14, 2) NULL,
    [STATE_TAX]      DECIMAL (14, 2) NULL,
    [COUNTY_TAX]     DECIMAL (14, 2) NULL,
    [CITY_TAX]       DECIMAL (14, 2) NULL
);

