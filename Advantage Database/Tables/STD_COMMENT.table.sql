﻿CREATE TABLE [dbo].[STD_COMMENT] (
    [COMMENT_ID]    INT          IDENTITY (1, 1) NOT NULL,
    [CLIENT_CODE]   VARCHAR (6)  NULL,
    [DIVISION_CODE] VARCHAR (6)  NULL,
    [PRODUCT_CODE]  VARCHAR (6)  NULL,
    [VENDOR_CODE]   VARCHAR (6)  NULL,
    [APP_CODE]      VARCHAR (50) NOT NULL,
    [COMMENT_TYPE]  VARCHAR (50) NOT NULL,
    [STD_COMMENT]   TEXT         NOT NULL,
    [FONT_SIZE]     SMALLINT     NULL,
    [OFFICE_CODE]   VARCHAR (4)  NULL
);

