CREATE TABLE [dbo].[ETF_OFFDTLCAT] (
    [ETF_OFFDTLCAT_ID] INT          IDENTITY (1, 1) NOT NULL,
    [ETF_ID]           INT          NOT NULL,
    [ETF_OFFDTL_ID]    INT          NOT NULL,
    [CATEGORY]         VARCHAR (10) NOT NULL
);

