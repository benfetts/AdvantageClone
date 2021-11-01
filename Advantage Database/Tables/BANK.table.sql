﻿CREATE TABLE [dbo].[BANK] (
    [BK_CODE]              VARCHAR (4)     NOT NULL,
    [BK_DESCRIPTION]       VARCHAR (30)    NULL,
    [BK_ACCOUNT_NO]        VARCHAR (20)    NULL,
    [BK_LAST_CHECK_COMP]   INT             NULL,
    [BK_LAST_CHECK_MAN]    INT             NULL,
    [GLACODE_AR_CASH]      VARCHAR (30)    NOT NULL,
    [GLACODE_AP_CASH]      VARCHAR (30)    NOT NULL,
    [GLACODE_AP_DISC]      VARCHAR (30)    NOT NULL,
    [ENDING_BALANCE]       DECIMAL (15, 2) NULL,
    [GLACODE_IE]           VARCHAR (30)    NULL,
    [GLACODE_SC]           VARCHAR (30)    NULL,
    [IMPORT_FILE_NAME]     VARCHAR (12)    NULL,
    [CHECK_NBR_BEGIN]      SMALLINT        NULL,
    [CHECK_NBR_LENGTH]     SMALLINT        NULL,
    [CHECK_AMT_BEGIN]      SMALLINT        NULL,
    [CHECK_AMT_LENGTH]     SMALLINT        NULL,
    [CHECK_AMT_DEC]        SMALLINT        NULL,
    [OFFICE_CODE]          VARCHAR (4)     NULL,
    [INACTIVE_FLAG]        SMALLINT        NULL,
    [CHECK_FORMAT]         SMALLINT        NULL,
    [WORD_CHECK_AMT]       SMALLINT        NULL,
    [CURRENCY_CODE]        VARCHAR (5)     NULL,
    [CRNCY_GL_AP_CASH]     VARCHAR (30)    NULL,
    [CRNCY_GL_AR_CASH]     VARCHAR (30)    NULL,
    [CRNCY_GL_AP_CASH_FRN] VARCHAR (30)    NULL,
    [CRNCY_GL_AR_CASH_FRN] VARCHAR (30)    NULL,
    [CRNCY_GL_EXCHG]       VARCHAR (30)    NULL,
    [BK_ROUTING_NBR]       BIGINT          NULL,
    [CHK_TEMPLATE_ID]      BIGINT          NULL,
    [ACH_COMPANY_ID]       VARCHAR (10)    NULL,
    [PYMT_MGR]             SMALLINT        NULL,
    [PYMT_MGR_ID]          VARCHAR (10)    NULL,
    [PYMT_MGR_WORD]        VARCHAR (50)    NULL,
    [PYMT_MGR_FTP]         VARCHAR (254)   NULL,
    [PYMT_MGR_DIR]         VARCHAR (100)   NULL,
    [PYMT_MGR_TYPE]        VARCHAR (4)     NULL
);

