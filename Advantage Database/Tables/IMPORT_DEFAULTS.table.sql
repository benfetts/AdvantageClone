﻿CREATE TABLE [dbo].[IMPORT_DEFAULTS] (
    [ID]            INT          NOT NULL,
    [TABLE_NAME]    VARCHAR (20) NOT NULL,
    [COLUMN_NAME]   VARCHAR (20) NOT NULL,
    [START_POS]     INT          NOT NULL,
    [DEFAULT_VALUE] VARCHAR (40) NULL
);

