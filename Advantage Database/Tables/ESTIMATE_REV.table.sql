CREATE TABLE [dbo].[ESTIMATE_REV] (
    [ESTIMATE_NUMBER]   INT             NOT NULL,
    [EST_COMPONENT_NBR] SMALLINT        NOT NULL,
    [EST_QUOTE_NBR]     SMALLINT        NOT NULL,
    [EST_REV_NBR]       SMALLINT        NOT NULL,
    [EST_REV_COMMENT]   TEXT            NULL,
    [TECHNOLOGY_PCT]    DECIMAL (7, 3)  NULL,
    [TECHNOLOGY_AMT]    DECIMAL (14, 2) NULL,
    [SPEC_VER]          INT             NULL,
    [SPEC_REV]          INT             NULL,
    [SPEC_QTY_SEQ_NBR]  INT             NULL,
    [JOB_QTY]           INT             NULL,
    [SPEC_RTF]          TEXT            NULL,
    [BLENDED_TIME_RATE] DECIMAL (9, 2)  NULL
);

