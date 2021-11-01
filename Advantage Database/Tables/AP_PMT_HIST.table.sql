﻿CREATE TABLE [dbo].[AP_PMT_HIST] (
    [AP_ID]             INT             NOT NULL,
    [AP_SEQ]            SMALLINT        DEFAULT (0) NOT NULL,
    [BK_CODE]           VARCHAR (4)     NOT NULL,
    [AP_CHK_NBR]        INT             NOT NULL,
    [CHK_SEQ]           SMALLINT        DEFAULT (0) NOT NULL,
    [AP_CHK_DATE]       SMALLDATETIME   NOT NULL,
    [AP_CHK_AMT]        DECIMAL (14, 2) NULL,
    [AP_DISC_AMT]       DECIMAL (11, 2) NULL,
    [AP_CHK_MAN]        SMALLINT        NULL,
    [AP_CHK_HOLD_FLAG]  SMALLINT        NULL,
    [AP_CHK_MAILED]     SMALLDATETIME   NULL,
    [AP_CHK_CLEAR_FLAG] SMALLINT        NULL,
    [GLACODE_CASH]      VARCHAR (30)    NOT NULL,
    [GLACODE_DISC]      VARCHAR (30)    NULL,
    [GLACODE_AP]        VARCHAR (30)    NOT NULL,
    [GLEXACT]           INT             NOT NULL,
    [GLESEQ_CASH]       SMALLINT        NOT NULL,
    [GLESEQ_DISC]       SMALLINT        NULL,
    [GLESEQ_AP]         SMALLINT        NOT NULL,
    [POST_PERIOD]       VARCHAR (6)     NOT NULL,
    [CREATE_DATE]       SMALLDATETIME   DEFAULT (getdate()) NULL,
    [USERID]            VARCHAR (100)   NULL
);

