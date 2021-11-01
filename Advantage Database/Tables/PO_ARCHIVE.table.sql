CREATE TABLE [dbo].[PO_ARCHIVE] (
    [PO_NUMBER]     INT             NOT NULL,
    [LINE_NUMBER]   INT             NOT NULL,
    [PO_QTY]        INT             NULL,
    [PO_RATE]       DECIMAL (8, 2)  NULL,
    [PO_EXT_AMOUNT] DECIMAL (14, 2) NULL
);

