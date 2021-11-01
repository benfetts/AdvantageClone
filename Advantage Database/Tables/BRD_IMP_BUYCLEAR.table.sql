CREATE TABLE [dbo].[BRD_IMP_BUYCLEAR] (
    [BUY_DETID]   DECIMAL (8)     NULL,
    [WEEK]        SMALLDATETIME   NULL,
    [SPOTS]       DECIMAL (3)     NULL,
    [COST]        DECIMAL (10, 2) NULL,
    [VOUCHER]     INT             NULL,
    [IMPORT_STAT] VARCHAR (1)     NULL,
    [STAT_DATE]   SMALLDATETIME   DEFAULT (getdate()) NULL,
    [BUY_ID]      INT             NULL
);

