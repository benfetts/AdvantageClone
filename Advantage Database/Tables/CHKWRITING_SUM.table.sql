CREATE TABLE [dbo].[CHKWRITING_SUM] (
    [USER_ID]        VARCHAR (100)   NOT NULL,
    [PAY_TO_CODE]    VARCHAR (6)     NOT NULL,
    [WH_BASE]        DECIMAL (15, 2) NULL,
    [WH_WAIVER]      SMALLINT        NULL,
    [WH_PCT]         DECIMAL (7, 3)  NULL,
    [PAID_YTD]       DECIMAL (15, 2) NULL,
    [VOL_DISC_PCT]   DECIMAL (7, 3)  NULL,
    [CHECK_NBR]      INT             NULL,
    [PAYMENT_AMOUNT] DECIMAL (15, 2) NULL,
    [DISC_AMT]       DECIMAL (14, 2) NULL,
    [WH_AMT]         DECIMAL (14, 2) NULL,
    [VOL_DISC_AMT]   DECIMAL (14, 2) NULL
);

