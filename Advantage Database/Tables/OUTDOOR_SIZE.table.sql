CREATE TABLE [dbo].[OUTDOOR_SIZE] (
    [OD_CODE]       VARCHAR (6)  NOT NULL,
    [OD_DESC]       VARCHAR (30) NOT NULL,
    [INACTIVE_FLAG] SMALLINT     DEFAULT (0) NOT NULL,
    [MEDIA_TYPE]    VARCHAR (1)  NULL
);

