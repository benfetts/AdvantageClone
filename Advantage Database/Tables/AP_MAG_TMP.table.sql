﻿CREATE TABLE [dbo].[AP_MAG_TMP] (
    [AP_ID]             INT             NOT NULL,
    [AP_SEQ]            SMALLINT        NOT NULL,
    [LINE_NUMBER]       SMALLINT        NOT NULL,
    [ORDER_NBR]         INT             NOT NULL,
    [ORDER_LINE_NBR]    SMALLINT        NOT NULL,
    [REV_NBR]           SMALLINT        NOT NULL,
    [SEQ_NBR]           SMALLINT        NOT NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [OFFICE_CODE]       VARCHAR (4)     NULL,
    [RATE_CARD]         VARCHAR (10)    NULL,
    [RATE_DESC]         VARCHAR (30)    NULL,
    [RATE]              NUMERIC (14, 2) NULL,
    [NET_GROSS]         SMALLINT        NULL,
    [NET_RATE]          NUMERIC (14, 4) NULL,
    [GROSS_RATE]        NUMERIC (14, 4) NULL,
    [FLAT_NET]          NUMERIC (14, 4) NULL,
    [FLAT_GROSS]        NUMERIC (14, 4) NULL,
    [EXTENDED_AMT]      NUMERIC (14, 2) NULL,
    [COMM_PCT]          NUMERIC (6, 3)  NULL,
    [MARKUP_PCT]        NUMERIC (6, 3)  NULL,
    [REBATE_PCT]        NUMERIC (6, 3)  NULL,
    [BLEED_PCT]         NUMERIC (6, 3)  NULL,
    [COLORCHARGE]       NUMERIC (14, 2) NULL,
    [COLORDESC]         VARCHAR (10)    NULL,
    [COLOR_TYPE]        SMALLINT        NULL,
    [POSITION_PCT]      NUMERIC (14, 2) NULL,
    [PREMIUM_PCT]       NUMERIC (14, 2) NULL,
    [USE_BLEED]         SMALLINT        NULL,
    [USE_COLOR]         SMALLINT        NULL,
    [USE_POSITION]      SMALLINT        NULL,
    [USE_PREMIUM]       SMALLINT        NULL,
    [NCDESC1]           VARCHAR (10)    NULL,
    [NCDESC2]           VARCHAR (10)    NULL,
    [NCDESC3]           VARCHAR (10)    NULL,
    [NCDESC4]           VARCHAR (10)    NULL,
    [NCDESC5]           VARCHAR (10)    NULL,
    [NCDESC6]           VARCHAR (10)    NULL,
    [NETCHARGES1]       NUMERIC (14, 2) NULL,
    [NETCHARGES2]       NUMERIC (14, 2) NULL,
    [NETCHARGES3]       NUMERIC (14, 2) NULL,
    [NETCHARGES4]       NUMERIC (14, 2) NULL,
    [NETCHARGES5]       NUMERIC (14, 2) NULL,
    [NETCHARGES6]       NUMERIC (14, 2) NULL,
    [DISC1]             NUMERIC (6, 3)  NULL,
    [DISC2]             NUMERIC (6, 3)  NULL,
    [DISC3]             NUMERIC (6, 3)  NULL,
    [DISC4]             NUMERIC (6, 3)  NULL,
    [DISC5]             NUMERIC (6, 3)  NULL,
    [DISC6]             NUMERIC (6, 3)  NULL,
    [DISC7]             NUMERIC (6, 3)  NULL,
    [DISC8]             NUMERIC (6, 3)  NULL,
    [APPLYLN1]          SMALLINT        NULL,
    [APPLYNC1]          SMALLINT        NULL,
    [APPLYLN2]          SMALLINT        NULL,
    [APPLYNC2]          SMALLINT        NULL,
    [APPLYLN3]          SMALLINT        NULL,
    [APPLYNC3]          SMALLINT        NULL,
    [APPLYLN4]          SMALLINT        NULL,
    [APPLYNC4]          SMALLINT        NULL,
    [APPLYLN5]          SMALLINT        NULL,
    [APPLYNC5]          SMALLINT        NULL,
    [APPLYLN6]          SMALLINT        NULL,
    [APPLYNC6]          SMALLINT        NULL,
    [APPLYLN7]          SMALLINT        NULL,
    [APPLYNC7]          SMALLINT        NULL,
    [APPLYLN8]          SMALLINT        NULL,
    [APPLYNC8]          SMALLINT        NULL,
    [TAX_CODE]          VARCHAR (4)     NULL,
    [TAX_STATE_PCT]     NUMERIC (7, 4)  NULL,
    [TAX_COUNTY_PCT]    NUMERIC (7, 4)  NULL,
    [TAX_CITY_PCT]      NUMERIC (7, 4)  NULL,
    [TAXAPPLYC]         SMALLINT        NULL,
    [TAXAPPLYLN]        SMALLINT        NULL,
    [TAXAPPLYLND]       SMALLINT        NULL,
    [TAXAPPLYNC]        SMALLINT        NULL,
    [TAXAPPLYNCD]       SMALLINT        NULL,
    [TAXAPPLYR]         SMALLINT        NULL,
    [TAX_RESALE]        SMALLINT        NULL,
    [AR_INV_NBR]        INT             NULL,
    [AR_INV_SEQ]        SMALLINT        NULL,
    [AR_TYPE]           VARCHAR (3)     NULL,
    [GLACODE]           VARCHAR (30)    NOT NULL,
    [GLEXACT]           INT             NULL,
    [GLESEQ]            SMALLINT        NULL,
    [BILLING_USER]      VARCHAR (10)    NULL,
    [GLEXACT_BILL]      INT             NULL,
    [GLESEQ_SALES]      SMALLINT        NULL,
    [GLESEQ_COS]        SMALLINT        NULL,
    [GLESEQ_STATE]      SMALLINT        NULL,
    [GLESEQ_CNTY]       SMALLINT        NULL,
    [GLESEQ_CITY]       SMALLINT        NULL,
    [GLESEQ_WIP]        SMALLINT        NULL,
    [GLACODE_SALES]     VARCHAR (30)    NULL,
    [GLACODE_COS]       VARCHAR (30)    NULL,
    [GLACODE_STATE]     VARCHAR (30)    NULL,
    [GLACODE_CNTY]      VARCHAR (30)    NULL,
    [GLACODE_CITY]      VARCHAR (30)    NULL,
    [EXT_COMM_AMT]      NUMERIC (14, 2) NULL,
    [EXT_NONRESALE_TAX] NUMERIC (14, 2) NULL,
    [EXT_STATE_RESALE]  NUMERIC (14, 2) NULL,
    [EXT_COUNTY_RESALE] NUMERIC (14, 2) NULL,
    [EXT_CITY_RESALE]   NUMERIC (14, 2) NULL,
    [LINE_TOTAL]        NUMERIC (14, 2) NULL,
    [POST_PERIOD]       VARCHAR (8)     NULL,
    [DELETE_FLAG]       SMALLINT        NULL,
    [REC_FLAG]          SMALLINT        NULL,
    [BLEED_AMT]         NUMERIC (14, 2) NULL,
    [COLOR_AMT]         NUMERIC (14, 2) NULL,
    [POSITION_AMT]      NUMERIC (14, 2) NULL,
    [PREMIUM_AMT]       NUMERIC (14, 2) NULL,
    [REBATE_AMT]        NUMERIC (14, 2) NULL,
    [TOTAL_DISC_LG]     NUMERIC (14, 2) NULL,
    [TOTAL_DISC_LN]     NUMERIC (14, 2) NULL,
    [TOTAL_DISC_NC]     NUMERIC (14, 2) NULL,
    [LINE_NET]          NUMERIC (14, 2) NULL,
    [LINE_GROSS]        NUMERIC (14, 2) NULL
);

