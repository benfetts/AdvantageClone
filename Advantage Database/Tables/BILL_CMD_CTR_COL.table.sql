CREATE TABLE [dbo].[BILL_CMD_CTR_COL] (
    [BCCC_ID]       SMALLINT     NOT NULL,
    [BCCC_DESC]     VARCHAR (50) NOT NULL,
    [BCCC_DW_COL]   VARCHAR (32) NULL,
    [DEF_INCLUDE]   BIT          NOT NULL,
    [DEF_TAB_ORDER] SMALLINT     NOT NULL,
    [DEF_COL_WIDTH] SMALLINT     NOT NULL,
    [REQUIRED]      BIT          NOT NULL,
    [BCCG_ID]       SMALLINT     NULL
);

