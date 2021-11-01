CREATE TABLE [dbo].[EXPORT_DEFAULTS] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [EXPORT_SYSTEM] VARCHAR (20)  NOT NULL,
    [ADV_COL_NAME]  VARCHAR (20)  NOT NULL,
    [USER_COL_NAME] VARCHAR (30)  NULL,
    [START_POS]     INT           NOT NULL,
    [MIN_CHAR]      INT           NOT NULL,
    [MAX_CHAR]      INT           NOT NULL,
    [FILE_PATH]     VARCHAR (100) NULL,
    [FILE_NAME]     VARCHAR (50)  NULL
);

