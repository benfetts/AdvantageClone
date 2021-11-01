CREATE TABLE [dbo].[BILL_APPR_BATCH_CDP] (
    [BA_BATCH_CDP_ID] INT         IDENTITY (1, 1) NOT NULL,
    [BA_BATCH_ID]     INT         NOT NULL,
    [CL_CODE]         VARCHAR (6) NOT NULL,
    [DIV_CODE]        VARCHAR (6) NULL,
    [PRD_CODE]        VARCHAR (6) NULL
);

