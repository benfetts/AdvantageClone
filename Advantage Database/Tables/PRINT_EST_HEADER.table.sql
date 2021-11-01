CREATE TABLE [dbo].[PRINT_EST_HEADER] (
    [EST_NBR]           INT           NOT NULL,
    [EST_DESC]          VARCHAR (40)  NULL,
    [CL_CODE]           VARCHAR (6)   NOT NULL,
    [DIV_CODE]          VARCHAR (6)   NOT NULL,
    [PRD_CODE]          VARCHAR (6)   NOT NULL,
    [OFFICE_CODE]       VARCHAR (4)   NULL,
    [CLIENT_REF]        VARCHAR (60)  NULL,
    [EST_DATE]          SMALLDATETIME NULL,
    [BUYER]             VARCHAR (40)  NULL,
    [CREATE_DATE]       SMALLDATETIME NULL,
    [USER_ID]           VARCHAR (100) NULL,
    [MODIFIED_BY]       VARCHAR (100) NULL,
    [MODIFIED_DATE]     SMALLDATETIME NULL,
    [MODIFIED_COMMENTS] TEXT          NULL,
    [REVISED_FLAG]      SMALLINT      NULL,
    [EST_COMMENT]       TEXT          NULL,
    [ACTIVE_FLAG]       SMALLINT      NULL,
    [CDP_CONTACT_ID]    INT           NULL,
    [PRD_CONTACT]       AS            ([dbo].[udf_get_cont_code]([CDP_CONTACT_ID]))
);

