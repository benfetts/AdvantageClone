CREATE TABLE [dbo].[TIME_RULE_ITEM_LOG] (
    [TIME_RULE_ITEM_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [ITEM_DATETIME_STAMP] DATETIME       DEFAULT (getdate()) NOT NULL,
    [TIME_RULE_LOG_ID]    INT            NOT NULL,
    [TIME_RULE_ID]        INT            NOT NULL,
    [TIME_RULE_DTL_ID]    INT            NOT NULL,
    [EMP_CODE]            VARCHAR (6)    NOT NULL,
    [HOURS_BEFORE]        DECIMAL (9, 3) NOT NULL,
    [HOURS_AFTER]         DECIMAL (9, 3) NOT NULL,
    [HOURS_USED]          DECIMAL (9, 3) NULL
);

