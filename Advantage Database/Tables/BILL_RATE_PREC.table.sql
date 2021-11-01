CREATE TABLE [dbo].[BILL_RATE_PREC] (
    [BILL_RATE_PREC_ID] SMALLINT      NOT NULL,
    [FNC_INCL]          SMALLINT      NULL,
    [EMP_INCL]          SMALLINT      NULL,
    [CL_INCL]           SMALLINT      NULL,
    [DIV_INCL]          SMALLINT      NULL,
    [PRD_INCL]          SMALLINT      NULL,
    [SC_INCL]           SMALLINT      NULL,
    [EFF_DT_INCL]       SMALLINT      NULL,
    [BILL_RATE_INCL]    SMALLINT      NULL,
    [NONBILL_INCL]      SMALLINT      NULL,
    [COMM_INCL]         SMALLINT      NULL,
    [TAX_INCL]          SMALLINT      NULL,
    [TAX_COMM_INCL]     SMALLINT      NULL,
    [FEE_TIME_INCL]     SMALLINT      NULL,
    [PRECEDENCE]        INT           NOT NULL,
    [LEVEL_DESC]        VARCHAR (254) NULL,
    [INACTIVE_FLAG]     SMALLINT      NULL,
    [ADV_REQ]           SMALLINT      NULL,
    [TITLE_INCL]        SMALLINT      NULL
);

