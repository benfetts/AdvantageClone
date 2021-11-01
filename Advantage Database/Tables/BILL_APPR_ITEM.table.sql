CREATE TABLE [dbo].[BILL_APPR_ITEM] (
    [BA_ITEM_ID]      INT             IDENTITY (1, 1) NOT NULL,
    [BA_DTL_ID]       INT             NOT NULL,
    [REC_TYPE]        VARCHAR (1)     NOT NULL,
    [REC_ID]          INT             NULL,
    [APPROVED_AMT]    DECIMAL (15, 2) NULL,
    [ITEM_COMMENTS]   TEXT            NULL,
    [INSTR]           TINYINT         NOT NULL,
    [CLIENT_COMMENTS] TEXT            NULL
);

