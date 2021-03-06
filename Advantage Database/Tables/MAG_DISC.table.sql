CREATE TABLE [dbo].[MAG_DISC] (
    [ORDER_NBR]       INT             NOT NULL,
    [LINE_NBR]        SMALLINT        NOT NULL,
    [REV_NBR]         SMALLINT        NOT NULL,
    [SEQ_NBR]         SMALLINT        NOT NULL,
    [DISC1]           DECIMAL (7, 3)  NULL,
    [DISC2]           DECIMAL (7, 3)  NULL,
    [DISC3]           DECIMAL (7, 3)  NULL,
    [DISC4]           DECIMAL (7, 3)  NULL,
    [DISC5]           DECIMAL (7, 3)  NULL,
    [DISC6]           DECIMAL (7, 3)  NULL,
    [DISC7]           DECIMAL (7, 3)  NULL,
    [DISC8]           DECIMAL (7, 3)  NULL,
    [DISC1DESC]       VARCHAR (10)    NULL,
    [DISC2DESC]       VARCHAR (10)    NULL,
    [DISC3DESC]       VARCHAR (10)    NULL,
    [DISC4DESC]       VARCHAR (10)    NULL,
    [DISC5DESC]       VARCHAR (10)    NULL,
    [DISC6DESC]       VARCHAR (10)    NULL,
    [DISC7DESC]       VARCHAR (10)    NULL,
    [DISC8DESC]       VARCHAR (10)    NULL,
    [APPLYLN1]        SMALLINT        NULL,
    [APPLYLN2]        SMALLINT        NULL,
    [APPLYLN3]        SMALLINT        NULL,
    [APPLYLN4]        SMALLINT        NULL,
    [APPLYLN5]        SMALLINT        NULL,
    [APPLYLN6]        SMALLINT        NULL,
    [APPLYLN7]        SMALLINT        NULL,
    [APPLYLN8]        SMALLINT        NULL,
    [APPLYNC1]        SMALLINT        NULL,
    [APPLYNC2]        SMALLINT        NULL,
    [APPLYNC3]        SMALLINT        NULL,
    [APPLYNC4]        SMALLINT        NULL,
    [APPLYNC5]        SMALLINT        NULL,
    [APPLYNC6]        SMALLINT        NULL,
    [APPLYNC7]        SMALLINT        NULL,
    [APPLYNC8]        SMALLINT        NULL,
    [LINE_NET_DISC]   DECIMAL (14, 2) NULL,
    [LINE_GROSS_DISC] DECIMAL (14, 2) NULL,
    [NETCHARGES_DISC] DECIMAL (14, 2) NULL
);

