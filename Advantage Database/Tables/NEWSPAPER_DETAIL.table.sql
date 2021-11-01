﻿CREATE TABLE [dbo].[NEWSPAPER_DETAIL] (
    [ORDER_NBR]         INT             NOT NULL,
    [LINE_NBR]          SMALLINT        NOT NULL,
    [REV_NBR]           SMALLINT        NOT NULL,
    [SEQ_NBR]           SMALLINT        NOT NULL,
    [ACTIVE_REV]        SMALLINT        NULL,
    [LINK_DETID]        INT             NULL,
    [START_DATE]        SMALLDATETIME   NULL,
    [END_DATE]          SMALLDATETIME   NULL,
    [CLOSE_DATE]        SMALLDATETIME   NULL,
    [MATL_CLOSE_DATE]   SMALLDATETIME   NULL,
    [EXT_CLOSE_DATE]    SMALLDATETIME   NULL,
    [EXT_MATL_DATE]     SMALLDATETIME   NULL,
    [SIZE]              VARCHAR (30)    NULL,
    [AD_NUMBER]         VARCHAR (30)    NULL,
    [HEADLINE]          VARCHAR (60)    NULL,
    [MATERIAL]          VARCHAR (60)    NULL,
    [EDITION_ISSUE]     VARCHAR (30)    NULL,
    [SECTION]           VARCHAR (30)    NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [RATE_CARD_ID]      INT             NULL,
    [RATE_DTL_ID]       SMALLINT        NULL,
    [PRINT_COLUMNS]     DECIMAL (6, 2)  NULL,
    [PRINT_INCHES]      DECIMAL (6, 2)  NULL,
    [PRINT_LINES]       DECIMAL (11, 2) NULL,
    [CONTRACT_QTY]      DECIMAL (11, 2) NULL,
    [QUANTITY]          DECIMAL (10, 2) NULL,
    [RATE]              DECIMAL (16, 4) NULL,
    [NET_RATE]          DECIMAL (16, 4) NULL,
    [GROSS_RATE]        DECIMAL (16, 4) NULL,
    [FLAT_NET]          DECIMAL (16, 4) NULL,
    [FLAT_GROSS]        DECIMAL (16, 4) NULL,
    [EXT_NET_AMT]       DECIMAL (15, 2) NULL,
    [EXT_GROSS_AMT]     DECIMAL (15, 2) NULL,
    [COMM_AMT]          DECIMAL (15, 2) NULL,
    [REBATE_AMT]        DECIMAL (14, 2) NULL,
    [DISCOUNT_AMT]      DECIMAL (14, 2) NULL,
    [DISCOUNT_DESC]     VARCHAR (30)    NULL,
    [STATE_AMT]         DECIMAL (14, 2) NULL,
    [COUNTY_AMT]        DECIMAL (14, 2) NULL,
    [CITY_AMT]          DECIMAL (14, 2) NULL,
    [NON_RESALE_AMT]    DECIMAL (14, 2) NULL,
    [NETCHARGE]         DECIMAL (14, 2) NULL,
    [NETCHARGE_DESC]    VARCHAR (60)    NULL,
    [ADDL_CHARGE]       DECIMAL (14, 2) NULL,
    [ADDL_CHARGE_DESC]  VARCHAR (30)    NULL,
    [PROD_CHARGE]       DECIMAL (14, 3) NULL,
    [PROD_DESC]         VARCHAR (30)    NULL,
    [COLOR_CHARGE]      DECIMAL (15, 4) NULL,
    [COLOR_DESC]        VARCHAR (30)    NULL,
    [LINE_TOTAL]        DECIMAL (15, 2) NULL,
    [LINE_CANCELLED]    SMALLINT        NULL,
    [DATE_TO_BILL]      SMALLDATETIME   NULL,
    [BILLING_USER]      VARCHAR (100)   NULL,
    [AR_INV_NBR]        INT             NULL,
    [AR_TYPE]           VARCHAR (2)     NULL,
    [AR_INV_SEQ]        SMALLINT        NULL,
    [GLEXACT]           INT             NULL,
    [GLESEQ_SALES]      SMALLINT        NULL,
    [GLESEQ_COS]        SMALLINT        NULL,
    [GLESEQ_WIP]        SMALLINT        NULL,
    [GLESEQ_STATE]      SMALLINT        NULL,
    [GLESEQ_COUNTY]     SMALLINT        NULL,
    [GLESEQ_CITY]       SMALLINT        NULL,
    [GLEXACT_DEF]       INT             NULL,
    [GLACODE_SALES]     VARCHAR (30)    NULL,
    [GLACODE_COS]       VARCHAR (30)    NULL,
    [GLACODE_WIP]       VARCHAR (30)    NULL,
    [GLACODE_STATE]     VARCHAR (30)    NULL,
    [GLACODE_COUNTY]    VARCHAR (30)    NULL,
    [GLACODE_CITY]      VARCHAR (30)    NULL,
    [NON_BILL_FLAG]     SMALLINT        NULL,
    [MODIFIED_BY]       VARCHAR (100)   NULL,
    [MODIFIED_DATE]     SMALLDATETIME   NULL,
    [MODIFIED_COMMENTS] VARCHAR (254)   NULL,
    [BILL_TYPE_FLAG]    SMALLINT        NULL,
    [COMM_PCT]          DECIMAL (7, 3)  NULL,
    [MARKUP_PCT]        DECIMAL (7, 3)  NULL,
    [REBATE_PCT]        DECIMAL (7, 3)  NULL,
    [DISCOUNT_PCT]      DECIMAL (7, 3)  NULL,
    [TAX_CODE]          VARCHAR (4)     NULL,
    [TAX_CITY_PCT]      DECIMAL (7, 3)  NULL,
    [TAX_COUNTY_PCT]    DECIMAL (7, 3)  NULL,
    [TAX_STATE_PCT]     DECIMAL (7, 3)  NULL,
    [TAX_RESALE]        SMALLINT        NULL,
    [TAXAPPLYC]         SMALLINT        NULL,
    [TAXAPPLYLN]        SMALLINT        NULL,
    [TAXAPPLYND]        SMALLINT        NULL,
    [TAXAPPLYNC]        SMALLINT        NULL,
    [TAXAPPLYR]         SMALLINT        NULL,
    [TAXAPPLYAI]        SMALLINT        NULL,
    [RECONCILE_FLAG]    SMALLINT        NULL,
    [GLESEQ_SALES_DEF]  SMALLINT        NULL,
    [GLESEQ_COS_DEF]    SMALLINT        NULL,
    [GLACODE_SALES_DEF] VARCHAR (30)    NULL,
    [GLACODE_COS_DEF]   VARCHAR (30)    NULL,
    [BILLING_AMT]       DECIMAL (15, 2) NULL,
    [BILL_CANCELLED]    SMALLINT        NULL,
    [EST_NBR]           INT             NULL,
    [EST_LINE_NBR]      SMALLINT        NULL,
    [EST_REV_NBR]       SMALLINT        NULL,
    [FLAT_NETCHARGE]    DECIMAL (15, 2) NULL,
    [FLAT_ADDL_CHARGE]  DECIMAL (15, 2) NULL,
    [FLAT_DISCOUNT_AMT] DECIMAL (15, 2) NULL,
    [PRODUCTION_SIZE]   VARCHAR (30)    NULL,
    [MAT_COMP]          SMALLDATETIME   NULL,
    [SIZE_CODE]         VARCHAR (6)     NULL,
    [COST_TYPE]         VARCHAR (3)     NULL,
    [COST_RATE]         DECIMAL (16, 4) NULL,
    [RATE_TYPE]         VARCHAR (3)     NULL,
    [NP_CIRCULATION]    INT             NULL,
    [PRINT_QUANTITY]    DECIMAL (14, 3) NULL
);

