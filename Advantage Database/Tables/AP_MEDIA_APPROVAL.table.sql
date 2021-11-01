﻿CREATE TABLE [dbo].[AP_MEDIA_APPROVAL] (
    [AP_ID]      INT           NOT NULL,
    [ORDER_NBR]  INT           NOT NULL,
    [LINE_NBR]   SMALLINT      NOT NULL,
    [REVISION]   SMALLINT      NOT NULL,
    [SOURCE]     VARCHAR (1)   NOT NULL,
    [STATUS]     SMALLINT      NULL,
    [ACTIVE_REV] SMALLINT      NULL,
    [USER_ID]    VARCHAR (100) NULL,
    [DATE]       SMALLDATETIME NULL,
    [COMMENTS]   VARCHAR (254) NULL,
    [APP_SOURCE] VARCHAR (6)   NULL
);

