﻿CREATE TABLE [dbo].[RADIO_HDR] (
    [ORDER_NBR]          INT           NOT NULL,
    [ORDER_DESC]         VARCHAR (40)  NULL,
    [CL_CODE]            VARCHAR (6)   NOT NULL,
    [DIV_CODE]           VARCHAR (6)   NOT NULL,
    [PRD_CODE]           VARCHAR (6)   NOT NULL,
    [OFFICE_CODE]        VARCHAR (4)   NULL,
    [CMP_CODE]           VARCHAR (6)   NULL,
    [MEDIA_TYPE]         VARCHAR (6)   NULL,
    [VN_CODE]            VARCHAR (6)   NULL,
    [VR_CODE]            VARCHAR (4)   NULL,
    [VR_CODE2]           VARCHAR (4)   NULL,
    [CLIENT_PO]          VARCHAR (25)  NULL,
    [CLIENT_REF]         VARCHAR (60)  NULL,
    [STATUS]             VARCHAR (3)   NULL,
    [ORDER_DATE]         SMALLDATETIME NULL,
    [BUYER]              VARCHAR (40)  NULL,
    [ORDER_COMMENT]      TEXT          NULL,
    [HOUSE_COMMENT]      TEXT          NULL,
    [STATION]            SMALLINT      NULL,
    [REP1]               SMALLINT      NULL,
    [REP2]               SMALLINT      NULL,
    [BILL_COOP_CODE]     VARCHAR (6)   NULL,
    [ORD_PROCESS_CONTRL] SMALLINT      NULL,
    [MARKET_CODE]        VARCHAR (10)  NULL,
    [UNITS]              VARCHAR (2)   NULL,
    [NET_GROSS]          SMALLINT      NULL,
    [CREATE_DATE]        SMALLDATETIME NULL,
    [USER_ID]            VARCHAR (100) NULL,
    [CANCELLED]          SMALLINT      NULL,
    [CANCELLED_BY]       VARCHAR (100) NULL,
    [CANCELLED_DATE]     SMALLDATETIME NULL,
    [MODIFIED_BY]        VARCHAR (100) NULL,
    [MODIFIED_DATE]      SMALLDATETIME NULL,
    [MODIFIED_COMMENTS]  TEXT          NULL,
    [REVISED_FLAG]       SMALLINT      NULL,
    [LINK_ID]            INT           NULL,
    [RECONCILE_FLAG]     SMALLINT      NULL,
    [CMP_IDENTIFIER]     INT           NULL,
    [PRINTED]            SMALLINT      NULL,
    [START_DATE]         SMALLDATETIME NULL,
    [END_DATE]           SMALLDATETIME NULL,
    [ORDER_ACCEPTED]     SMALLINT      NULL,
    [FISCAL_PERIOD_CODE] VARCHAR (6)   NULL,
    [LOCKED]             VARCHAR (1)   NULL,
    [LOCKED_BY]          VARCHAR (100) NULL,
    [BCC_ID]             INT           NULL
);

