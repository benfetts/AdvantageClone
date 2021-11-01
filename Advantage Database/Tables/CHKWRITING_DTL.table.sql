CREATE TABLE [dbo].[CHKWRITING_DTL] (
    [USER_ID]           VARCHAR (100)   NOT NULL,
    [AP_ID]             INT             NOT NULL,
    [AP_SEQ]            SMALLINT        DEFAULT (0) NOT NULL,
    [SUPPLIER]          VARCHAR (6)     NULL,
    [PAYMENT_AMOUNT]    DECIMAL (14, 2) NULL,
    [DISC_AMT]          DECIMAL (14, 2) NULL,
    [CHECK_NBR]         INT             NULL,
    [WH_AMT]            DECIMAL (14, 2) NULL,
    [PAY_TO_CODE]       VARCHAR (6)     NULL,
    [GLACODE]           VARCHAR (30)    NULL,
    [GRP_CHECK_NBR]     INT             NULL,
    [ONE_CHECK_PER_INV] SMALLINT        NULL
);

