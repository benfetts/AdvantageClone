CREATE TABLE [dbo].[BILL_COMMENTS_DTL] (
    [INV_NBR]           INT          NOT NULL,
    [JOB_NUMBER]        INT          NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT     NOT NULL,
    [FNC_CODE]          VARCHAR (6)  NOT NULL,
    [DTL_COMMENT]       TEXT         NULL,
    [FNC_DESC]          VARCHAR (30) NULL,
    [FNC_DESC_SOURCE]   SMALLINT     NULL,
    [COMMENT_SOURCE]    SMALLINT     NULL
);

