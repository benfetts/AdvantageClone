CREATE TABLE [dbo].[PO_APPR_RULE_DTL] (
    [PO_APPR_RULE_CODE] VARCHAR (6)     NOT NULL,
    [SEQ_NBR]           SMALLINT        NOT NULL,
    [APPR_MIN]          DECIMAL (15, 2) NULL,
    [APPR_MAX]          DECIMAL (15, 2) NULL,
    [INACTIVE_FLAG]     SMALLINT        NULL
);

