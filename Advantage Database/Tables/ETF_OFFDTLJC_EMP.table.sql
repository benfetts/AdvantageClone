CREATE TABLE [dbo].[ETF_OFFDTLJC_EMP] (
    [ETF_OFFDTLJC_EMP_ID] INT            IDENTITY (1, 1) NOT NULL,
    [ETF_ID]              INT            NOT NULL,
    [ETF_OFFDTL_ID]       INT            NOT NULL,
    [ETF_OFFDTLJC_ID]     INT            NOT NULL,
    [ETF_OFFDTLEMP_ID]    INT            NOT NULL,
    [HOURS]               DECIMAL (9, 2) NOT NULL
);

