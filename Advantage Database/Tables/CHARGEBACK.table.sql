CREATE TABLE [dbo].[CHARGEBACK] (
    [CB_NBR]         INT             NOT NULL,
    [REV_NBR]        SMALLINT        NOT NULL,
    [STATUS]         VARCHAR (10)    NULL,
    [CB_DATE]        SMALLDATETIME   NULL,
    [GLACODE]        VARCHAR (30)    NULL,
    [VT_CODE]        VARCHAR (3)     NULL,
    [CB_TOTAL]       DECIMAL (15, 2) NULL,
    [CB_DATE_TO_PAY] SMALLDATETIME   NULL,
    [CB_COMMENT]     TEXT            NULL,
    [CB_CREATE_DATE] SMALLDATETIME   NULL,
    [USER_ID]        VARCHAR (100)   NULL,
    [RB_FLAG]        SMALLINT        NULL,
    [VC_CODE]        VARCHAR (4)     NULL,
    [GLACODE_AP]     VARCHAR (30)    NULL,
    [AP_ID]          INT             NULL,
    [RB_AP_ID]       INT             NULL
);

