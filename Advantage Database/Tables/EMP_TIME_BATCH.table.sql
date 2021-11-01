﻿CREATE TABLE [dbo].[EMP_TIME_BATCH] (
    [EMP_CODE]          VARCHAR (6)     NULL,
    [EMP_DATE]          SMALLDATETIME   NULL,
    [ET_ID]             INT             NULL,
    [ET_DTL_ID]         SMALLINT        NULL,
    [SEQ_NBR]           SMALLINT        NULL,
    [NEW_TIMESHEET]     SMALLINT        NULL,
    [CATEGORY]          VARCHAR (10)    NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [FNC_CODE]          VARCHAR (6)     NULL,
    [EMP_HOURS]         DECIMAL (7, 2)  NULL,
    [EMP_BILL_RATE]     DECIMAL (9, 2)  NULL,
    [EMP_COST_RATE]     DECIMAL (9, 2)  NULL,
    [DP_TM_CODE]        VARCHAR (4)     NULL,
    [TAX_CODE]          VARCHAR (4)     NULL,
    [TAX_STATE_PCT]     DECIMAL (8, 4)  NULL,
    [TAX_COUNTY_PCT]    DECIMAL (8, 4)  NULL,
    [TAX_CITY_PCT]      DECIMAL (8, 4)  NULL,
    [TAX_RESALE]        SMALLINT        NULL,
    [TAX_COMM]          SMALLINT        NULL,
    [TAX_COMM_ONLY]     SMALLINT        NULL,
    [EMP_COMM_PCT]      DECIMAL (7, 3)  NULL,
    [EMP_NON_BILL_FLAG] SMALLINT        NULL,
    [DATE_ENTERED]      SMALLDATETIME   DEFAULT (getdate()) NULL,
    [EMP_COMMENT]       TEXT            NULL,
    [NP_COMMENT]        TEXT            NULL,
    [USER_ID]           VARCHAR (100)   NULL,
    [EMP_RATE_FROM]     VARCHAR (254)   NULL,
    [AB_FLAG]           SMALLINT        NULL,
    [TOTAL_COST]        DECIMAL (14, 2) NULL,
    [TOTAL_BILL]        DECIMAL (14, 2) NULL,
    [EXT_MARKUP_AMT]    DECIMAL (14, 2) NULL,
    [EXT_STATE_RESALE]  DECIMAL (14, 2) NULL,
    [EXT_COUNTY_RESALE] DECIMAL (14, 2) NULL,
    [EXT_CITY_RESALE]   DECIMAL (14, 2) NULL,
    [LINE_TOTAL]        DECIMAL (14, 2) NULL,
    [EDIT_FLAG]         SMALLINT        NULL,
    [ROW_FLAG]          INT             NULL,
    [POSTED]            SMALLINT        NULL,
    [EMP_NOTES]         VARCHAR (254)   NULL,
    [ROWID]             INT             IDENTITY (1, 1) NOT NULL,
    [FEE_TIME]          SMALLINT        NULL,
    [EMPLOYEE_TITLE_ID] INT             NULL,
    [JOB_VER_HDR_ID]    INT             NULL
);

