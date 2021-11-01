﻿CREATE TABLE [dbo].[AP_HEADER_HISTORY] (
    [AP_ID]           INT             NOT NULL,
    [AP_SEQ]          SMALLINT        DEFAULT (0) NOT NULL,
    [AP_SEQ1]         SMALLINT        DEFAULT (0) NOT NULL,
    [AP_TYPE]         VARCHAR (1)     NOT NULL,
    [VN_FRL_EMP_CODE] VARCHAR (6)     NOT NULL,
    [AP_INV_VCHR]     VARCHAR (20)    NOT NULL,
    [AP_DESC]         VARCHAR (30)    NULL,
    [AP_INV_DATE]     SMALLDATETIME   NOT NULL,
    [AP_DATE_PAY]     SMALLDATETIME   NOT NULL,
    [AP_INV_AMT]      DECIMAL (14, 2) NOT NULL,
    [AP_SHIPPING]     DECIMAL (11, 2) NULL,
    [AP_SALES_TAX]    DECIMAL (11, 2) NULL,
    [AP_DISC_PCT]     DECIMAL (6, 3)  NULL,
    [AP_CKWRITING]    SMALLINT        NULL,
    [CHKWRITING_USER] VARCHAR (100)   NULL,
    [PAYMENT_HOLD]    SMALLINT        NULL,
    [GLACODE]         VARCHAR (30)    NOT NULL,
    [CHECK_HOLD_CODE] SMALLINT        NULL,
    [POST_PERIOD]     VARCHAR (6)     NOT NULL,
    [VT_CODE]         VARCHAR (3)     NULL,
    [GLEXACT]         INT             NULL,
    [GLESEQ]          SMALLINT        NULL,
    [DELETE_FLAG]     SMALLINT        NULL,
    [DELETE_DATE]     SMALLDATETIME   NULL,
    [DELETED_BY]      VARCHAR (100)   NULL,
    [MODIFY_FLAG]     SMALLINT        NULL,
    [MODIFY_DATE]     SMALLDATETIME   NULL,
    [MODIFIED_BY]     VARCHAR (100)   NULL,
    [ARCHIVE_FLAG]    SMALLINT        NULL,
    [VOUCHER]         INT             NULL,
    [OFFICE_CODE]     VARCHAR (4)     NULL,
    [FLAG_1099]       SMALLINT        NULL
);

