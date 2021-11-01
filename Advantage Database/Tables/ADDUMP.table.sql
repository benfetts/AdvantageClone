﻿CREATE TABLE [dbo].[ADDUMP] (
    [VENDOR_CODE]    VARCHAR (6)     NOT NULL,
    [LOG_NBR]        VARCHAR (20)    NULL,
    [LOG_NBR2]       VARCHAR (20)    NULL,
    [CL_NAME]        VARCHAR (40)    NULL,
    [FIELD5]         VARCHAR (1)     NULL,
    [FIELD6]         VARCHAR (1)     NULL,
    [FIELD7]         VARCHAR (1)     NULL,
    [FIELD8]         VARCHAR (1)     NULL,
    [SECTION]        VARCHAR (20)    NULL,
    [SECTION_DESC]   VARCHAR (40)    NULL,
    [ZONE]           VARCHAR (20)    NULL,
    [INSERT_DATES]   VARCHAR (40)    NULL,
    [FIRST_DATE]     VARCHAR (8)     NULL,
    [DAILY_INSERTS]  SMALLINT        NULL,
    [SUNDAY_INSERTS] SMALLINT        NULL,
    [STATUS]         VARCHAR (1)     NULL,
    [FIELD17]        VARCHAR (1)     NULL,
    [DETAIL_DESC]    VARCHAR (40)    NULL,
    [TOTAL_COST]     DECIMAL (15, 2) NULL,
    [AD_SIZE]        SMALLINT        NULL,
    [FIELD21]        VARCHAR (1)     NULL,
    [FIELD22]        VARCHAR (1)     NULL,
    [FIELD23]        VARCHAR (1)     NULL,
    [FIELD24]        VARCHAR (1)     NULL,
    [CL_CODE]        VARCHAR (6)     NULL,
    [RATES]          VARCHAR (20)    NULL,
    [FIELD27]        VARCHAR (1)     NULL,
    [FIELD28]        VARCHAR (1)     NULL,
    [FIELD29]        VARCHAR (1)     NULL,
    [INVALID_INFO]   SMALLINT        NULL
);

