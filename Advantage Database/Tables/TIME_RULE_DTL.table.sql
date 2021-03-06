CREATE TABLE [dbo].[TIME_RULE_DTL] (
    [TIME_RULE_DTL_ID] INT            IDENTITY (1, 1) NOT NULL,
    [TIME_RULE_ID]     INT            NOT NULL,
    [HOURS_TO_APPLY]   DECIMAL (9, 3) NOT NULL,
    [MIN_YEARS]        SMALLINT       NULL,
    [MAXIMUM_HOURS]    DECIMAL (9, 3) NULL,
    [INACTIVE_FLAG]    BIT            DEFAULT ((0)) NOT NULL
);

