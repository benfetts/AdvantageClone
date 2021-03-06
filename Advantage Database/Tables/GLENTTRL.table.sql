CREATE TABLE [dbo].[GLENTTRL] (
    [GLETXACT]      INT           NOT NULL,
    [GLETSEQ]       SMALLINT      NOT NULL,
    [GLETCODE]      VARCHAR (30)  NOT NULL,
    [GLETAMT]       FLOAT         DEFAULT (0) NOT NULL,
    [GLETFCAMT]     FLOAT         DEFAULT (0) NOT NULL,
    [GLETCUR]       VARCHAR (3)   NULL,
    [GLETQTY]       FLOAT         NULL,
    [GLETREM]       VARCHAR (150) NULL,
    [GLETJOBCOSTID] INT           NULL,
    [GLETSOURCE]    VARCHAR (2)   NULL,
    [GLETCFF1]      VARCHAR (30)  NULL,
    [GLETNFF1]      FLOAT         NULL,
    [GLETDTFF1]     SMALLDATETIME NULL,
    [GLETBASE]      VARCHAR (20)  NULL,
    [GLETOFFICE]    VARCHAR (20)  NULL,
    [GLETDEPT]      VARCHAR (20)  NULL,
    [GLETOTHER]     VARCHAR (20)  NULL,
    [CL_CODE]       VARCHAR (6)   NULL,
    [DIV_CODE]      VARCHAR (6)   NULL,
    [PRD_CODE]      VARCHAR (6)   NULL,
    [ROWID]         INT           IDENTITY (1, 1) NOT NULL,
    [CLEARED]       SMALLINT      NULL,
    [REC_STMT_DATE] SMALLDATETIME NULL,
    [RECON_FLAG]    SMALLINT      NULL,
    [AR_INV_NBR]    INT           NULL
);

