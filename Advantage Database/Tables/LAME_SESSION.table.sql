﻿CREATE TABLE [dbo].[LAME_SESSION] (
    [LAME_SESSION_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [SEC_USER_ID]        INT           NOT NULL,
    [SEC_APPLICATION_ID] INT           NOT NULL,
    [SESSION_ID]         VARCHAR (255) NULL,
    [CLIENT_NAME]        VARCHAR (100) NULL,
    [SESSION_START]      SMALLDATETIME NOT NULL
);

