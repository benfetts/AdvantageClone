﻿CREATE TABLE [dbo].[NCC_TV_AI_UE_LOG_REVISION] (
    [NCC_TV_AI_UE_LOG_REVISION_ID] INT IDENTITY (1, 1) NOT NULL,
    [OLD_NCC_TV_AI_UE_LOG_ID] INT NOT NULL,
	[NEW_NCC_TV_AI_UE_LOG_ID] INT NOT NULL
    CONSTRAINT [PK_NCC_TV_AI_UE_LOG_REVISION] PRIMARY KEY CLUSTERED ([NCC_TV_AI_UE_LOG_REVISION_ID] ASC)
);