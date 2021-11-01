CREATE TABLE [dbo].[FUNCTIONS] (
    [FNC_CODE]           VARCHAR (6)  NOT NULL,
    [FNC_DESCRIPTION]    VARCHAR (30) NULL,
    [FNC_TYPE]           VARCHAR (1)  NOT NULL,
    [DP_TM_CODE]         VARCHAR (4)  NULL,
    [FNC_CONSOLIDATION]  VARCHAR (6)  NULL,
    [FNC_CPM_FLAG]       SMALLINT     NULL,
    [FNC_ORDER]          SMALLINT     NULL,
    [FNC_INACTIVE]       SMALLINT     NULL,
    [FNC_FEE_RECONCILE]  SMALLINT     NULL,
    [FNC_HEADING_ID]     INT          NULL,
    [EX_FLAG]            SMALLINT     NULL,
    [NONBILL_CLI_GLACCT] VARCHAR (30) NULL,
    [OVERHEAD_GLACCT]    VARCHAR (30) NULL,
    [FNC_FEE_FLAG]       SMALLINT     NULL,
    [FNC_BILLING_RATE]   AS           ([dbo].[udf_get_fnc_bill_rate]([FNC_CODE])),
    [TAX_COMM]           AS           ([dbo].[udf_get_fnc_tax_comm]([FNC_CODE])),
    [TAX_COMM_ONLY]      AS           ([dbo].[udf_get_fnc_tax_comm_only]([FNC_CODE])),
    [FNC_NONBILL_FLAG]   AS           ([dbo].[udf_get_fnc_nobill_flag]([FNC_CODE])),
    [FNC_TAX_FLAG]       AS           ([dbo].[udf_get_fnc_tax_flag]([FNC_CODE])),
    [FNC_COMM_FLAG]      AS           ([dbo].[udf_get_fnc_comm_flag]([FNC_CODE]))
);

