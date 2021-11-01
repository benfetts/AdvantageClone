CREATE TABLE [dbo].[TIME_RULE] (
    [TIME_RULE_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [HOURS]          DECIMAL (9, 3) NULL,
    [FROM_YEAR]      SMALLINT       NULL,
    [TO_YEAR]        SMALLINT       NULL,
    [LOGIC_OP]       VARCHAR (1)    NULL,
    [SPV]            VARCHAR (1)    NULL,
    [REPLACE_APPEND] SMALLINT       NULL,
    [INCLUDE]        SMALLINT       NULL
);

