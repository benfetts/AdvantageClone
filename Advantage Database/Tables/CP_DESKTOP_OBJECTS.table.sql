CREATE TABLE [dbo].[CP_DESKTOP_OBJECTS] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [CATEGORY_ID]    INT           NOT NULL,
    [NAME]           VARCHAR (50)  NOT NULL,
    [DESCRIPTION]    VARCHAR (100) NOT NULL,
    [SECURITY_LEVEL] INT           NOT NULL,
    [ACTIVE]         BIT           NOT NULL,
    [ASCX_FILENAME]  VARCHAR (50)  NULL
);

