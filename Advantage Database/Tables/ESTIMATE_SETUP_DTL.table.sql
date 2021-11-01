CREATE TABLE [dbo].[ESTIMATE_SETUP_DTL] (
    [ID]             INT         IDENTITY (1, 1) NOT NULL,
    [HDR_CODE]       VARCHAR (6) NOT NULL,
    [COLUMN_ID]      INT         NOT NULL,
    [SHOW_LONG_DESC] TINYINT     NULL,
    [SEQ]            INT         NULL,
    [DISPLAY_TYPE]   VARCHAR (4) NULL
);

