﻿CREATE TABLE [dbo].[TIME_RULE_HDR] (
    [TIME_RULE_ID]       INT          IDENTITY (1, 1) NOT NULL,
    [TIME_RULE_NAME]     VARCHAR (40) NOT NULL,
    [NON_PROD_TYPE]      TINYINT      DEFAULT ((0)) NOT NULL,
    [COUNT_SERVICE_THRU] TINYINT      DEFAULT ((0)) NOT NULL,
    [INCLUDE_HOURS_USED] BIT          DEFAULT ((0)) NOT NULL,
    [APPEND_REPLACE]     TINYINT      DEFAULT ((0)) NOT NULL,
    [EQUAL_QUALIFIES]    BIT          DEFAULT ((0)) NOT NULL,
    [DEFAULT_RULE]       BIT          DEFAULT ((0)) NOT NULL,
    [INACTIVE_FLAG]      BIT          DEFAULT ((0)) NOT NULL,
    UNIQUE NONCLUSTERED ([TIME_RULE_NAME] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
);

