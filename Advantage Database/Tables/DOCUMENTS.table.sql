CREATE TABLE [dbo].[DOCUMENTS] (
    [DOCUMENT_ID]         INT           IDENTITY (1, 1) NOT NULL,
    [FILENAME]            VARCHAR (100) NULL,
    [REPOSITORY_FILENAME] VARCHAR (200) NOT NULL,
    [MIME_TYPE]           VARCHAR (255) NOT NULL,
    [DESCRIPTION]         VARCHAR (200) NULL,
    [KEYWORDS]            VARCHAR (255) NULL,
    [UPLOADED_DATE]       DATETIME      NOT NULL,
    [USER_CODE]           VARCHAR (100) NULL,
    [FILE_SIZE]           INT           NOT NULL,
    [PRIVATE_FLAG]        INT           NULL,
    [DOCUMENT_TYPE_ID]    INT           NULL
);

