CREATE TABLE [dbo].[VENDOR_QTE_DTL] (
    [ESTIMATE_NUMBER]   INT             NOT NULL,
    [EST_COMPONENT_NBR] SMALLINT        NOT NULL,
    [VENDOR_QTE_NBR]    INT             NOT NULL,
    [EST_QUOTE_NBR]     SMALLINT        NOT NULL,
    [EST_REV_NBR]       SMALLINT        NOT NULL,
    [EST_FNC_CODE]      VARCHAR (6)     NOT NULL,
    [VN_CODE]           VARCHAR (6)     NOT NULL,
    [CREATED_BY]        VARCHAR (100)   NULL,
    [CREATE_DATE]       SMALLDATETIME   NULL,
    [REPLY_RATE]        DECIMAL (9, 3)  NULL,
    [REPLY_AMT]         DECIMAL (15, 2) NULL,
    [REPLY_NOTES]       TEXT            NULL,
    [APPROVED_FLAG]     SMALLINT        DEFAULT (0) NOT NULL,
    [APPROVAL_NOTES]    TEXT            NULL,
    [APPROVED_BY]       VARCHAR (100)   NULL,
    [APPROVED_DATE]     SMALLDATETIME   NULL,
    [QTY]               INT             NULL
);

