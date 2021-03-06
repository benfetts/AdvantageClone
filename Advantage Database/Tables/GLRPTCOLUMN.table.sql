CREATE TABLE [dbo].[GLRPTCOLUMN] (
    [COL_FORMAT_NAME] VARCHAR (18) NOT NULL,
    [COL_FORMAT_DESC] VARCHAR (50) NULL,
    [FORMAT_NAME]     VARCHAR (18) NOT NULL,
    [COL_INC_CODES]   SMALLINT     NULL,
    [COL_PAGE_SETUP]  SMALLINT     NULL,
    [REPORT_TYPE]     SMALLINT     NULL,
    [PRINT_FULL_ACCT] SMALLINT     NULL,
    [REPORT_TITLE]    VARCHAR (75) NULL,
    [COLUMN_TITLE1]   VARCHAR (20) NULL,
    [COLUMN_TITLE2]   VARCHAR (20) NULL,
    [COLUMN_TITLE3]   VARCHAR (20) NULL,
    [COLUMN_TITLE4]   VARCHAR (20) NULL,
    [COLUMN_TITLE5]   VARCHAR (20) NULL,
    [COLUMN_TITLE6]   VARCHAR (20) NULL,
    [YTD_ONLY]        SMALLINT     NULL,
    [UNDERLINE_TITLE] SMALLINT     NULL,
    [SUPPRESS_PERIOD] SMALLINT     NULL,
    [ADVAN_STANDARD]  SMALLINT     NULL,
    [SUPPRESS_YTD]    SMALLINT     NULL
);

