CREATE TABLE [dbo].[MISC_HEADER] (
    [ORDER_NBR]     INT           NOT NULL,
    [ORDER_DESC]    VARCHAR (40)  NULL,
    [CL_CODE]       VARCHAR (6)   NOT NULL,
    [DIV_CODE]      VARCHAR (6)   NOT NULL,
    [PRD_CODE]      VARCHAR (6)   NOT NULL,
    [CMP_CODE]      VARCHAR (6)   NULL,
    [MEDIA_TYPE]    VARCHAR (6)   NULL,
    [VN_CODE]       VARCHAR (6)   NULL,
    [VR_CODE]       VARCHAR (4)   NULL,
    [VR_CODE2]      VARCHAR (4)   NULL,
    [CLIENT_PO]     VARCHAR (25)  NULL,
    [STATUS]        VARCHAR (3)   NULL,
    [ORDER_DATE]    SMALLDATETIME NULL,
    [BUYER]         VARCHAR (40)  NULL,
    [ORDER_COMMENT] TEXT          NULL,
    [HOUSE_COMMENT] TEXT          NULL,
    [VENDOR]        SMALLINT      NULL,
    [REP1]          SMALLINT      NULL,
    [REP2]          SMALLINT      NULL,
    [CREATE_DATE]   SMALLDATETIME NULL,
    [USER_ID]       VARCHAR (100) NULL
);

