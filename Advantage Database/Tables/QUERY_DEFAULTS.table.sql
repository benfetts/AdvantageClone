﻿CREATE TABLE [dbo].[QUERY_DEFAULTS] (
    [USERID]      VARCHAR (100) NOT NULL,
    [TABLE_NAME]  VARCHAR (20)  NOT NULL,
    [COLUMN_NAME] VARCHAR (20)  NOT NULL,
    [DISPLAY_SEQ] INT           NOT NULL,
    [QUERY_NAME]  VARCHAR (20)  NULL,
    [SELECTED]    VARCHAR (1)   NULL
);

