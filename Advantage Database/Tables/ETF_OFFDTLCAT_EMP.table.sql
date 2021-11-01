CREATE TABLE [dbo].[ETF_OFFDTLCAT_EMP] (
    [ETF_OFFDTLCAT_EMP_ID] INT            IDENTITY (1, 1) NOT NULL,
    [ETF_ID]               INT            NOT NULL,
    [ETF_OFFDTL_ID]        INT            NOT NULL,
    [ETF_OFFDTLCAT_ID]     INT            NOT NULL,
    [ETF_OFFDTLEMP_ID]     INT            NOT NULL,
    [HOURS]                DECIMAL (9, 2) NOT NULL
);

