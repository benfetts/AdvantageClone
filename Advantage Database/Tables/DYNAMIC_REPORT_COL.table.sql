CREATE TABLE [dbo].[DYNAMIC_REPORT_COL] (
    [DYNAMIC_REPORT_COL_ID] INT          IDENTITY (1, 1) NOT NULL,
    [DYNAMIC_REPORT_ID]     INT          NOT NULL,
    [FIELD_NAME]            VARCHAR (50) NOT NULL,
    [HEADER_TEXT]           VARCHAR (50) NOT NULL,
    [IS_VISIBLE]            BIT          NOT NULL,
    [SORT_ORDER]            INT          NOT NULL,
    [SORT_INDEX]            INT          NOT NULL,
    [GROUP_INDEX]           INT          NOT NULL,
    [WIDTH]                 INT          NOT NULL,
    [VISIBLE_INDEX]         INT          NOT NULL
);

