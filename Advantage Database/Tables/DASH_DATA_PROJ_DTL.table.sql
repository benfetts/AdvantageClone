﻿CREATE TABLE [dbo].[DASH_DATA_PROJ_DTL] (
    [REC_SOURCE]          VARCHAR (5)     NULL,
    [JOB_NUMBER]          INT             NULL,
    [JOB_COMPONENT_NBR]   SMALLINT        NULL,
    [FNC_TYPE]            VARCHAR (2)     NULL,
    [FNC_CODE]            VARCHAR (6)     NULL,
    [FNC_DESC]            VARCHAR (30)    NULL,
    [ITEM_ID]             INT             NULL,
    [ITEM_SEQ]            SMALLINT        NULL,
    [DATE]                SMALLDATETIME   NULL,
    [POST_PERIOD]         VARCHAR (6)     NULL,
    [ITEM_CODE]           VARCHAR (6)     NULL,
    [ITEM_DESC]           VARCHAR (60)    NULL,
    [DETAIL_COMMENT]      TEXT            NULL,
    [ITEM_EXTRA1]         VARCHAR (60)    NULL,
    [FEE_TIME]            SMALLINT        NULL,
    [HOURS_QTY]           DECIMAL (15, 2) NULL,
    [TOTAL_BILL]          DECIMAL (15, 2) NULL,
    [BILL_AMT]            DECIMAL (15, 2) NULL,
    [EXT_MARKUP_AMT]      DECIMAL (15, 2) NULL,
    [NONRESALE_TAX]       DECIMAL (15, 2) NULL,
    [RESALE_TAX]          DECIMAL (15, 2) NULL,
    [TOTAL]               DECIMAL (15, 2) NULL,
    [NET_COST]            DECIMAL (15, 2) NULL,
    [AR_POST_PERIOD]      VARCHAR (6)     NULL,
    [AR_INV_NBR]          INT             NULL,
    [AR_TYPE]             VARCHAR (6)     NULL,
    [AB_FLAG]             SMALLINT        NULL,
    [NB_FLAG]             SMALLINT        NULL,
    [GLEXACT_BILL]        INT             NULL,
    [EST_HOURS_QTY]       DECIMAL (15, 2) NULL,
    [EST_TOTAL]           DECIMAL (15, 2) NULL,
    [EST_CONT_AMT]        DECIMAL (15, 2) NULL,
    [EST_NONRESALE_TAX]   DECIMAL (15, 2) NULL,
    [EST_RESALE_TAX]      DECIMAL (15, 2) NULL,
    [EST_MARKUP_AMT]      DECIMAL (15, 2) NULL,
    [EST_NET_COST]        DECIMAL (15, 2) NULL,
    [EST_NB_FLAG]         SMALLINT        NULL,
    [EST_FEE_TIME]        SMALLINT        NULL,
    [APPR_HOURS_QTY]      DECIMAL (15, 2) NULL,
    [APPR_NET_COST]       DECIMAL (15, 2) NULL,
    [APPR_COMMISSION]     DECIMAL (15, 2) NULL,
    [APPR_TOTAL]          DECIMAL (15, 2) NULL,
    [PO_NUMBER]           INT             NULL,
    [OPEN_PO_AMT]         DECIMAL (15, 2) NULL,
    [OPEN_PO_GROSS_AMT]   DECIMAL (15, 2) NULL,
    [BILLED_AMT]          DECIMAL (15, 2) NULL,
    [BILLED_AMT_RESALE]   DECIMAL (15, 2) NULL,
    [BILLED_HRS_QTY]      DECIMAL (15, 2) NULL,
    [FEE_TIME_AMT]        DECIMAL (15, 2) NULL,
    [FEE_TIME_HRS]        DECIMAL (15, 2) NULL,
    [UNBILLED_AMT]        DECIMAL (15, 2) NULL,
    [UNBILLED_AMT_RESALE] DECIMAL (15, 2) NULL,
    [UNBILLED_HRS_QTY]    DECIMAL (15, 2) NULL,
    [NB_AMT]              DECIMAL (15, 2) NULL,
    [NB_QTY]              DECIMAL (15, 2) NULL,
    [NEW_BIZ]             SMALLINT        NULL,
    [AGENCY]              SMALLINT        NULL
);

