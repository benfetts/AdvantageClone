﻿CREATE TABLE [dbo].[CLIENT_ORDER] (
    [CLIENT_ORDER_ID]       INT           IDENTITY (1, 1) NOT NULL,
    [CLIENT_ID]             INT           NOT NULL,
    [ORDER_TYPE]            CHAR (1)      NOT NULL,
    [ORDER_NUMBER]          INT           NOT NULL,
    [ORDER_DATETIME]        SMALLDATETIME NOT NULL,
    [LAST_CHANGED_DATETIME] SMALLDATETIME NOT NULL,
    [START_YEAR]            SMALLINT      NOT NULL,
    [END_YEAR]              SMALLINT      NOT NULL,
    [ORDER_DURATION]        VARCHAR (100) NULL,
    [REPORT]                VARCHAR (100) NULL,
    [ALL_MARKETS]           BIT           NOT NULL,
    [CLIENT_ALIAS]          VARCHAR (100) NULL,
    [IS_SUSPENDED]          BIT           NOT NULL,
	[CUME]					BIT NOT NULL DEFAULT(0),
    CONSTRAINT [PK_CLIENT_ORDER] PRIMARY KEY CLUSTERED ([CLIENT_ORDER_ID] ASC),
    CONSTRAINT [FK_CLIENT_ORDER_CLIENT] FOREIGN KEY ([CLIENT_ID]) REFERENCES [dbo].[CLIENT] ([CLIENT_ID])
);

