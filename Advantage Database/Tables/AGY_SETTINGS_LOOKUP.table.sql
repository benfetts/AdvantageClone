﻿CREATE TABLE [dbo].[AGY_SETTINGS_LOOKUP] (
    [LOOKUP_ID]         INT          IDENTITY (1, 1) NOT NULL,
    [AGY_SETTINGS_CODE] VARCHAR (20) NOT NULL,
    [LOOKUP_DISPLAY]    VARCHAR (50) NOT NULL,
    [LOOKUP_VALUE]      SQL_VARIANT  NULL
);

