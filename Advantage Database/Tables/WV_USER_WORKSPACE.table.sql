CREATE TABLE [dbo].[WV_USER_WORKSPACE] (
    [WORKSPACE_ID] INT           IDENTITY (1, 1) NOT NULL,
    [USER_CODE]    VARCHAR (100) NOT NULL,
    [NAME]         VARCHAR (50)  NOT NULL,
    [DESCRIPTION]  VARCHAR (100) NULL,
    [SORT_ORDER]   INT           NULL
);

