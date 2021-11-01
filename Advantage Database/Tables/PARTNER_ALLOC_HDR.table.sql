CREATE TABLE [dbo].[PARTNER_ALLOC_HDR] (
    [ORDER_NBR]      INT            NOT NULL,
    [CL_CODE]        VARCHAR (6)    NOT NULL,
    [DIV_CODE]       VARCHAR (6)    NOT NULL,
    [PRD_CODE]       VARCHAR (6)    NOT NULL,
    [MEDIA_TYPE]     VARCHAR (1)    NOT NULL,
    [CMP_CODE]       VARCHAR (6)    NULL,
    [CMP_IDENTIFIER] INT            NULL,
    [CLIENT_PCT]     DECIMAL (7, 3) NOT NULL
);

