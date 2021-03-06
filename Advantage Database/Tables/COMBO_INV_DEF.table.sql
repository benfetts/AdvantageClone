CREATE TABLE [dbo].[COMBO_INV_DEF] (
    [COMBO_INV_DEF_ID]   INT             IDENTITY (1, 1) NOT NULL,
    [CLIENT_OR_DEF]      SMALLINT        NULL,
    [CL_CODE]            VARCHAR (6)     NULL,
    [ADDRESS_BLOCK]      SMALLINT        NULL,
    [PRT_LOC_PG_FTR_DEF] VARCHAR (50)    NULL,
    [CUSTOM_FORMAT]      VARCHAR (255)   NULL,
    [COL_OPT_XCHGE_AMTS] SMALLINT        NULL,
    [COL_OPT_XCHGE_DEF]  DECIMAL (10, 4) NULL
);

