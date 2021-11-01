﻿CREATE TABLE [dbo].[NCC_TV_SYSCODE] (
    [NCC_TV_SYSCODE_ID]  INT           IDENTITY (1, 1) NOT NULL,
    [SYSCODE]            SMALLINT      NOT NULL,
    [NCC_TV_MVPD_ID]     INT           NOT NULL,
    [NIELSEN_MARKET_NUM] INT           NOT NULL,
    [SYSTEM_NAME]        VARCHAR (100) NOT NULL,
    [SYSTEM_TYPE]        VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_NCC_TV_SYSCODE] PRIMARY KEY CLUSTERED ([NCC_TV_SYSCODE_ID] ASC),
    CONSTRAINT [FK_NCC_TV_SYSCODE_NCC_TV_MVPD] FOREIGN KEY ([NCC_TV_MVPD_ID]) REFERENCES [dbo].[NCC_TV_MVPD] ([NCC_TV_MVPD_ID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCC_TV_SYSCODE_UNIQUE]
    ON [dbo].[NCC_TV_SYSCODE]([SYSCODE] ASC);

