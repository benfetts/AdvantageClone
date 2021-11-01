﻿CREATE TABLE [dbo].[AP_RECUR_HDR] (
    [RECUR_ID]        INT             NOT NULL,
    [VENDOR_CODE]     VARCHAR (6)     NOT NULL,
    [INV_NBR]         VARCHAR (15)    NOT NULL,
    [RECURRING_DESC]  VARCHAR (30)    NULL,
    [INV_AMT]         DECIMAL (14, 2) NOT NULL,
    [SHIPPING_AMT]    DECIMAL (11, 2) NULL,
    [SALES_TAX]       DECIMAL (11, 2) NULL,
    [DISC_PCT]        DECIMAL (6, 3)  NULL,
    [GLACODE]         VARCHAR (30)    NOT NULL,
    [VT_CODE]         VARCHAR (3)     NULL,
    [CYCODE]          VARCHAR (6)     NOT NULL,
    [START_PP]        VARCHAR (6)     NOT NULL,
    [NUMBER_TO_POST]  INT             NULL,
    [UNLIMITED]       SMALLINT        NULL,
    [SEQUENCE_BY]     SMALLINT        NOT NULL,
    [OFFICE_CODE]     VARCHAR (4)     NULL,
    [LAST_POSTED]     SMALLDATETIME   NULL,
    [LAST_PP]         VARCHAR (6)     NULL,
    [TOTAL_POSTED]    INT             NULL,
    [INACTIVE_DATE]   SMALLDATETIME   NULL,
    [INACTIVE_SET_BY] VARCHAR (100)   NULL,
    [INACTIVE_FLAG]   SMALLINT        NULL,
    [FLAG_1099]       SMALLINT        NULL
);

