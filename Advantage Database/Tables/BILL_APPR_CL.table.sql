CREATE TABLE [dbo].[BILL_APPR_CL] (
    [BA_CL_ID]       INT           IDENTITY (1, 1) NOT NULL,
    [BA_ID]          INT           NOT NULL,
    [CL_CODE]        VARCHAR (6)   NOT NULL,
    [BA_CL_DESC]     VARCHAR (50)  NULL,
    [BA_CL_DATE]     SMALLDATETIME NULL,
    [SENT_DATE]      SMALLDATETIME NULL,
    [APPR_DATE]      SMALLDATETIME NULL,
    [CLIENT_PO]      VARCHAR (40)  NULL,
    [CREATE_USER]    VARCHAR (100) NULL,
    [CDP_CONTACT_ID] INT           NULL,
    [CONT_CODE]      AS            ([dbo].[udf_get_cont_code]([CDP_CONTACT_ID]))
);

