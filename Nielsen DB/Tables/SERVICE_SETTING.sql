﻿CREATE TABLE [dbo].[SERVICE_SETTING] (
    [SERVICE_SETTING_ID] INT           NOT NULL,
    [TV_SPOT_PATH]       VARCHAR (MAX) NOT NULL,
    [TV_NATIONAL_PATH]   VARCHAR (MAX) NOT NULL,
    [RADIO_SPOT_PATH]    VARCHAR (MAX) NOT NULL,
    [TIMER_MINUTES]      INT           NOT NULL,
    [NCC_DATA_PATH] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_SERVICE_SETTING] PRIMARY KEY CLUSTERED ([SERVICE_SETTING_ID] ASC)
);

