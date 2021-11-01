﻿CREATE TABLE [dbo].[NIELSEN_TV_BOOK] (
    [NIELSEN_TV_BOOK_ID] INT           IDENTITY (1, 1) NOT NULL,
    [NIELSEN_MARKET_NUM] INT           NOT NULL,
    [YEAR]               SMALLINT      NOT NULL,
    [MONTH]              SMALLINT      NOT NULL,
    [STREAM]             CHAR (2)      NOT NULL,
    [START_DATETIME]     SMALLDATETIME NOT NULL,
    [END_DATETIME]       SMALLDATETIME NOT NULL,
    [MARKET_TIME_ZONE]   SMALLINT      NOT NULL,
    [MARKET_CLASS_CODE]  CHAR (1)      NOT NULL,
    [IS_DST_MARKET]      BIT           NOT NULL,
    [CREATE_DATE]        SMALLDATETIME NOT NULL,
    [VALIDATED]          BIT           NOT NULL,
	[COLLECTION_METHOD]  VARCHAR (2)   NOT NULL DEFAULT(''),
    CONSTRAINT [PK_NIELSEN_TV_BOOK] PRIMARY KEY CLUSTERED ([NIELSEN_TV_BOOK_ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NIELSEN_TV_BOOK_UNIQUE]
    ON [dbo].[NIELSEN_TV_BOOK]([NIELSEN_MARKET_NUM] ASC, [YEAR] ASC, [MONTH] ASC, [STREAM] ASC);

