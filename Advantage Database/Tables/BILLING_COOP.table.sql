CREATE TABLE [dbo].[BILLING_COOP] (
    [BILL_COOP_CODE] VARCHAR (6)    NOT NULL,
    [CL_CODE]        VARCHAR (6)    NOT NULL,
    [DIV_CODE]       VARCHAR (6)    NOT NULL,
    [PRD_CODE]       VARCHAR (6)    NOT NULL,
    [BILL_COOP_DESC] VARCHAR (30)   NULL,
    [COOP_PCT]       DECIMAL (7, 3) DEFAULT (0) NOT NULL,
    [INACTIVE_FLAG]  SMALLINT       NULL
);

