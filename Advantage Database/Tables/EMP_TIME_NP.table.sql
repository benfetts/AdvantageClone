CREATE TABLE [dbo].[EMP_TIME_NP] (
    [ET_ID]         INT             NOT NULL,
    [ET_DTL_ID]     SMALLINT        NOT NULL,
    [SEQ_NBR]       SMALLINT        NOT NULL,
    [CATEGORY]      VARCHAR (10)    NOT NULL,
    [EMP_HOURS]     DECIMAL (7, 2)  NOT NULL,
    [COST_RATE]     DECIMAL (7, 2)  NULL,
    [DP_TM_CODE]    VARCHAR (4)     NULL,
    [NP_COMMENT]    TEXT            NULL,
    [DATE_ENTERED]  SMALLDATETIME   DEFAULT (getdate()) NULL,
    [USER_ID]       VARCHAR (100)   NULL,
    [TOTAL_COST]    DECIMAL (14, 2) NULL,
    [EDIT_FLAG]     SMALLINT        NULL,
    [EMP_NOTES]     VARCHAR (254)   NULL,
    [ALT_COST_RATE] DECIMAL (9, 2)  NULL,
    [ALT_COST_AMT]  DECIMAL (14, 2) NULL
);

