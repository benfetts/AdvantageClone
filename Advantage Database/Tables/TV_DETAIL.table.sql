﻿CREATE TABLE [dbo].[TV_DETAIL] (
    [ORDER_NBR]         INT             NOT NULL,
    [LINE_NBR]          SMALLINT        NOT NULL,
    [REV_NBR]           SMALLINT        NOT NULL,
    [SEQ_NBR]           SMALLINT        NOT NULL,
    [ACTIVE_REV]        SMALLINT        NULL,
    [LINK_DETID]        INT             NULL,
    [BUY_TYPE]          VARCHAR (2)     NULL,
    [START_DATE]        SMALLDATETIME   NULL,
    [END_DATE]          SMALLDATETIME   NULL,
    [MONTH_NBR]         SMALLINT        NOT NULL,
    [YEAR_NBR]          SMALLINT        NOT NULL,
    [CLOSE_DATE]        SMALLDATETIME   NULL,
    [MATL_CLOSE_DATE]   SMALLDATETIME   NULL,
    [EXT_CLOSE_DATE]    SMALLDATETIME   NULL,
    [EXT_MATL_DATE]     SMALLDATETIME   NULL,
    [DATE1]             SMALLDATETIME   NULL,
    [DATE2]             SMALLDATETIME   NULL,
    [DATE3]             SMALLDATETIME   NULL,
    [DATE4]             SMALLDATETIME   NULL,
    [DATE5]             SMALLDATETIME   NULL,
    [DATE6]             SMALLDATETIME   NULL,
    [DATE7]             SMALLDATETIME   NULL,
    [MONDAY]            SMALLINT        NULL,
    [TUESDAY]           SMALLINT        NULL,
    [WEDNESDAY]         SMALLINT        NULL,
    [THURSDAY]          SMALLINT        NULL,
    [FRIDAY]            SMALLINT        NULL,
    [SATURDAY]          SMALLINT        NULL,
    [SUNDAY]            SMALLINT        NULL,
    [SPOTS1]            SMALLINT        NULL,
    [SPOTS2]            SMALLINT        NULL,
    [SPOTS3]            SMALLINT        NULL,
    [SPOTS4]            SMALLINT        NULL,
    [SPOTS5]            SMALLINT        NULL,
    [SPOTS6]            SMALLINT        NULL,
    [SPOTS7]            SMALLINT        NULL,
    [TOTAL_SPOTS]       INT             NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [QUANTITY]          INT             NULL,
    [RATE]              DECIMAL (16, 4) NULL,
    [NET_RATE]          DECIMAL (16, 4) NULL,
    [GROSS_RATE]        DECIMAL (16, 4) NULL,
    [EXT_NET_AMT]       DECIMAL (15, 2) NULL,
    [EXT_GROSS_AMT]     DECIMAL (15, 2) NULL,
    [COMM_AMT]          DECIMAL (14, 2) NULL,
    [REBATE_AMT]        DECIMAL (14, 2) NULL,
    [DISCOUNT_AMT]      DECIMAL (14, 2) NULL,
    [DISCOUNT_DESC]     VARCHAR (30)    NULL,
    [STATE_AMT]         DECIMAL (14, 2) NULL,
    [COUNTY_AMT]        DECIMAL (14, 2) NULL,
    [CITY_AMT]          DECIMAL (14, 2) NULL,
    [NON_RESALE_AMT]    DECIMAL (14, 2) NULL,
    [NETCHARGE]         DECIMAL (14, 2) NULL,
    [NCDESC]            VARCHAR (30)    NULL,
    [ADDL_CHARGE]       DECIMAL (14, 2) NULL,
    [ADDL_CHARGE_DESC]  VARCHAR (30)    NULL,
    [LINE_TOTAL]        DECIMAL (14, 2) NULL,
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
    [BILLING_AMT]       DECIMAL (14, 2) NULL,
    [COST_TYPE]         VARCHAR (3)     NULL,
    [COST_RATE]         DECIMAL (16, 4) NULL,
    [NET_BASE_RATE]     DECIMAL (16, 4) NULL,
    [GROSS_BASE_RATE]   DECIMAL (16, 4) NULL,
    [BILL_CANCELLED]    SMALLINT        NULL,
    [EST_NBR]           INT             NULL,
    [EST_LINE_NBR]      SMALLINT        NULL,
    [EST_REV_NBR]       SMALLINT        NULL,
    [AD_NUMBER]         VARCHAR (30)    NULL,
    [MAT_COMP]          SMALLDATETIME   NULL,
    [PROGRAMMING]       VARCHAR (50)    NULL,
    [START_TIME]        VARCHAR (10)    NULL,
    [END_TIME]          VARCHAR (10)    NULL,
    [LENGTH]            SMALLINT        NULL,
    [REMARKS]           VARCHAR (254)   NULL,
    [TAG]               VARCHAR (10)    NULL
);

