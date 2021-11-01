CREATE TABLE [dbo].[ADVAN_UPDATE] (
    [SOFTWARE]             VARCHAR (20)  NULL,
    [VERSION_ID]           VARCHAR (15)  NULL,
    [DB_UPDATE]            SMALLDATETIME DEFAULT (getdate()) NULL,
    [UPDATE_APP]           SMALLDATETIME NULL,
    [LAST_INV_B4_400]      INT           NULL,
    [WEBVAN_VERSION_ID]    VARCHAR (20)  NULL,
    [MISSING_TIME_VERSION] VARCHAR (20)  NULL,
    [REL_ERROR_NBR]        INT           NULL,
    [REL_ERROR_MSG]        TEXT          NULL
);

