﻿CREATE TABLE [dbo].[CYCLE] (
    [CYCODE]     VARCHAR (6)   NOT NULL,
    [CYNAME]     VARCHAR (30)  NULL,
    [CYMODULE]   VARCHAR (2)   NULL,
    [CYPDATE]    SMALLDATETIME NULL,
    [CYTYPE]     VARCHAR (1)   NULL,
    [CYFREQ]     FLOAT         NULL,
    [CYUSER]     VARCHAR (100) NULL,
    [CYENTDATE]  SMALLDATETIME NULL,
    [CYMODDATE]  SMALLDATETIME NULL,
    [CYMOD]      VARCHAR (1)   NULL,
    [CYINACTIVE] SMALLINT      NULL,
    [ROWID]      INT           IDENTITY (1, 1) NOT NULL
);

