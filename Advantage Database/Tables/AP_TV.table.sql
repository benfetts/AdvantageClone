﻿CREATE TABLE [dbo].[AP_TV] (
    [AP_ID]            INT             NOT NULL,
    [AP_SEQ]           SMALLINT        NOT NULL,
    [ORDER_NBR]        INT             NOT NULL,
    [BRDCAST_MONTH]    VARCHAR (3)     NULL,
    [BRDCAST_YEAR]     SMALLINT        NULL,
    [REV_NBR]          SMALLINT        NOT NULL,
    [CITY_TAX]         DECIMAL (14, 2) NULL,
    [COMM_AMT]         DECIMAL (14, 2) NULL,
    [COUNTY_TAX]       DECIMAL (14, 2) NULL,
    [DELETE_FLAG]      SMALLINT        NULL,
    [DISC_AMT]         DECIMAL (15, 2) NULL,
    [EXT_NET_AMT]      DECIMAL (15, 2) NULL,
    [GLEXACT]          INT             NULL,
    [GLACODE]          VARCHAR (30)    NULL,
    [GLESEQ]           SMALLINT        NULL,
    [LINE_TOTAL]       DECIMAL (15, 2) NULL,
    [NETCHARGES]       DECIMAL (14, 2) NULL,
    [OFFICE_CODE]      VARCHAR (4)     NULL,
    [POST_PERIOD]      VARCHAR (8)     NULL,
    [REBATE_AMT]       DECIMAL (14, 2) NULL,
    [REC_FLAG]         SMALLINT        NULL,
    [STATE_TAX]        DECIMAL (14, 2) NULL,
    [TAX_CODE]         VARCHAR (4)     NULL,
    [TAX_CITY_PCT]     DECIMAL (7, 3)  NULL,
    [TAX_COUNTY_PCT]   DECIMAL (7, 3)  NULL,
    [TAX_STATE_PCT]    DECIMAL (7, 3)  NULL,
    [TAX_RESALE]       SMALLINT        NULL,
    [VENDOR_TAX]       DECIMAL (14, 2) NULL,
    [VOUCHER]          DECIMAL (8)     NULL,
    [TAXAPPLYC]        SMALLINT        NULL,
    [TAXAPPLYLN]       SMALLINT        NULL,
    [TAXAPPLYLND]      SMALLINT        NULL,
    [TAXAPPLYNC]       SMALLINT        NULL,
    [TAXAPPLYR]        SMALLINT        NULL,
    [LINK_ID]          INT             NULL,
    [RECONCILE_FLAG]   SMALLINT        NULL,
    [GLACODE_DUE_FROM] VARCHAR (30)    NULL,
    [GLACODE_DUE_TO]   VARCHAR (30)    NULL,
    [GLESEQ_DUE_FROM]  SMALLINT        NULL,
    [GLESEQ_DUE_TO]    SMALLINT        NULL,
    [MODIFY_DELETE]    SMALLINT        NULL,
    [LINE_NUMBER]      SMALLINT        DEFAULT (0) NOT NULL,
    [TOTAL_SPOTS]      INT             NULL,
    [REWRITE_FLAG]     SMALLINT        NULL,
    [ORDER_LINE_NBR]   SMALLINT        NULL,
    [ORDER_LINE_DATE]  SMALLDATETIME   NULL,
    [COMM_PCT]         DECIMAL (6, 3)  NULL,
    [REBATE_PCT]       DECIMAL (6, 3)  NULL,
    [NET_GROSS]        SMALLINT        NULL,
    [SEQ_NBR]          SMALLINT        NULL,
    [MARKUP_PCT]       DECIMAL (6, 3)  NULL,
	[CREATED_BY]	   VARCHAR(100)	   NULL,
	[CREATE_DATE]	   SMALLDATETIME   NULL,
	[MODIFIED_BY]	   VARCHAR(100)    NULL,
	[MODIFY_DATE]	   SMALLDATETIME   NULL
);

