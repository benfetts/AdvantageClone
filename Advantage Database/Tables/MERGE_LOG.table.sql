CREATE TABLE [dbo].[MERGE_LOG] (
    [MERGE_REC_ID]   INT           IDENTITY (1, 1) NOT NULL,
    [MERGE_TYPE]     VARCHAR (25)  NOT NULL,
    [MERGE_USER]     VARCHAR (100) NOT NULL,
    [MERGE_DATETIME] VARCHAR (25)  NOT NULL,
    [MERGE_TABLE]    VARCHAR (25)  NOT NULL,
    [MERGE_ACTION]   TEXT          NULL
);

