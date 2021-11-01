CREATE TABLE [dbo].[ETF_OFFDTLJC] (
    [ETF_OFFDTLJC_ID]   INT             IDENTITY (1, 1) NOT NULL,
    [ETF_ID]            INT             NOT NULL,
    [ETF_OFFDTL_ID]     INT             NOT NULL,
    [JOB_NUMBER]        INT             NOT NULL,
    [REV_AMT]           DECIMAL (15, 2) NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT        NOT NULL,
    [CL_CODE]           VARCHAR (6)     NOT NULL,
    [DIV_CODE]          VARCHAR (6)     NOT NULL,
    [PRD_CODE]          VARCHAR (6)     NOT NULL,
    [OFFICE_CODE]       VARCHAR (4)     NOT NULL
);

