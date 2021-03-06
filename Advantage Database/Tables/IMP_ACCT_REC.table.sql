CREATE TABLE [dbo].[IMP_ACCT_REC] (
    [REC_NBR]           INT             NOT NULL,
    [IMP_AR_INV_NBR]    VARCHAR (40)    NOT NULL,
    [ADVAN_AR_INV_NBR]  INT             NULL,
    [ADVAN_AR_INV_SEQ]  SMALLINT        NULL,
    [ADVAN_AR_TYPE]     VARCHAR (3)     NOT NULL,
    [CL_CODE]           VARCHAR (6)     NOT NULL,
    [DIV_CODE]          VARCHAR (6)     NULL,
    [PRD_CODE]          VARCHAR (6)     NULL,
    [AR_INV_DATE]       CHAR (8)        NOT NULL,
    [AR_INV_AMOUNT]     DECIMAL (13, 2) NOT NULL,
    [AR_SALE_AMT]       DECIMAL (13, 2) NULL,
    [AR_DEF_AMT]        DECIMAL (13, 2) NULL,
    [AR_OFFSET_AMT]     DECIMAL (13, 2) NULL,
    [AR_COS_AMT]        DECIMAL (13, 2) NULL,
    [AR_EMP_TIME]       DECIMAL (13, 2) NULL,
    [AR_IO_AMT]         DECIMAL (13, 2) NULL,
    [AR_COMM_AMT]       DECIMAL (13, 2) NULL,
    [AR_STATE_AMT]      DECIMAL (13, 2) NULL,
    [AR_COUNTY_AMT]     DECIMAL (13, 2) NULL,
    [AR_CITY_AMT]       DECIMAL (13, 2) NULL,
    [GLACODE_AR]        VARCHAR (30)    NULL,
    [GLACODE_SALES]     VARCHAR (30)    NULL,
    [GLACODE_DEF_SALES] VARCHAR (30)    NULL,
    [GLACODE_COS]       VARCHAR (30)    NULL,
    [GLACODE_OFFSET]    VARCHAR (30)    NULL,
    [GLACODE_STATE]     VARCHAR (30)    NULL,
    [GLACODE_COUNTY]    VARCHAR (30)    NULL,
    [GLACODE_CITY]      VARCHAR (30)    NULL,
    [CMP_CODE]          VARCHAR (6)     NULL,
    [SC_CODE]           VARCHAR (6)     NULL,
    [JOB_NUMBER]        INT             NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NULL,
    [PRD_CLI_REF]       VARCHAR (30)    NULL,
    [VOID_FLAG]         SMALLINT        NULL,
    [VOID_DATE]         CHAR (8)        NULL,
    [REC_TYPE]          VARCHAR (1)     NULL,
    [PRIOR_REC_NBR]     INT             NULL,
    [POST_FLAG]         VARCHAR (2)     NULL
);

