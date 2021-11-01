CREATE TABLE [dbo].[ETF_OFFDTLAE] (
    [ETF_OFFDTLAE_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [ETF_ID]            INT            NOT NULL,
    [ETF_OFFDTL_ID]     INT            NOT NULL,
    [EMPLOYEE_TITLE_ID] INT            NOT NULL,
    [DESCRIPTION]       VARCHAR (50)   NOT NULL,
    [OFFICE_CODE]       VARCHAR (4)    NOT NULL,
    [BILL_RATE]         DECIMAL (9, 2) NOT NULL,
    [COST_RATE]         DECIMAL (9, 2) NOT NULL
);

