CREATE TABLE [dbo].[TEMP_BRDCAST_HDR] (
    [ORDER_NBR]          INT       NOT NULL,
    [BRDCAST_TYPE]       CHAR (5)  NULL,
    [BILL_TYPE_FLAG]     SMALLINT  NULL,
    [MEDIA_TYPE]         CHAR (6)  NULL,
    [REV_NBR]            SMALLINT  NULL,
    [CL_CODE]            CHAR (6)  NULL,
    [DIV_CODE]           CHAR (6)  NULL,
    [PRD_CODE]           CHAR (6)  NULL,
    [ORDER_DESC]         CHAR (40) NULL,
    [VN_CODE]            CHAR (6)  NULL,
    [ORD_PROCESS_CONTRL] SMALLINT  NULL,
    [CLIENT_PO]          CHAR (25) NULL
);

