CREATE TABLE [dbo].[WV_DESK_TMPLT_DTL] (
    [WV_TMPLT_DTL_ID] INT          IDENTITY (1, 1) NOT NULL,
    [WV_TMPLT_HDR_ID] INT          NOT NULL,
    [TABNO]           INT          NOT NULL,
    [NAME]            VARCHAR (50) NOT NULL,
    [STATE]           TEXT         NULL
);

