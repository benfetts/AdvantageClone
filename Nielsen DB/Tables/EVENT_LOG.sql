﻿CREATE TABLE [dbo].[EVENT_LOG] (
    [EVENT_LOG_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [EVENT_DATETIME] DATETIME       NOT NULL,
    [EVENT_MESSAGE]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_EVENT_LOG] PRIMARY KEY CLUSTERED ([EVENT_LOG_ID] ASC)
);

