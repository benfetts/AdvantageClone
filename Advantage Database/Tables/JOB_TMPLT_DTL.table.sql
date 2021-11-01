﻿CREATE TABLE [dbo].[JOB_TMPLT_DTL] (
    [JOB_TMPLT_CODE] VARCHAR (6)  NOT NULL,
    [SEQ_NBR]        SMALLINT     NOT NULL,
    [ITEM_CODE]      VARCHAR (32) NOT NULL,
    [LABEL]          VARCHAR (50) NULL,
    [SECTION_ORDER]  SMALLINT     NULL,
    [ITEM_ORDER]     SMALLINT     NULL,
    [INCLUDE]        TINYINT      DEFAULT (1) NOT NULL,
    [REQUIRED]       TINYINT      DEFAULT (0) NOT NULL
);

