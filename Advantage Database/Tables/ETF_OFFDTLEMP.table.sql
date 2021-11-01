CREATE TABLE [dbo].[ETF_OFFDTLEMP] (
    [ETF_OFFDTLEMP_ID] INT            IDENTITY (1, 1) NOT NULL,
    [ETF_ID]           INT            NOT NULL,
    [ETF_OFFDTL_ID]    INT            NOT NULL,
    [EMP_CODE]         VARCHAR (6)    NOT NULL,
    [BILL_RATE]        DECIMAL (9, 2) NOT NULL,
    [COST_RATE]        DECIMAL (9, 2) NOT NULL
);

