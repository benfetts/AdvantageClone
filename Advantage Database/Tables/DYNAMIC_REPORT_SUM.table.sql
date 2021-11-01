CREATE TABLE [dbo].[DYNAMIC_REPORT_SUM] (
    [DYNAMIC_REPORT_SUM_ID] INT            IDENTITY (1, 1) NOT NULL,
    [DYNAMIC_REPORT_ID]     INT            NOT NULL,
    [SUM_TYPE]              INT            NOT NULL,
    [FIELD_NAME]            VARCHAR (100)  NOT NULL,
    [COLUMN_NAME]           VARCHAR (100)  NOT NULL,
    [DISPLAY_FORMAT]        VARCHAR (1000) NOT NULL,
    [ON_FOOTER]             BIT            NOT NULL
);

