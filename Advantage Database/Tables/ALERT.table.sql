CREATE TABLE [dbo].[ALERT] (
    [ALERT_ID]           INT           NOT NULL,
    [ALERT_TYPE_ID]      INT           NOT NULL,
    [ALERT_CAT_ID]       INT           NOT NULL,
    [SUBJECT]            VARCHAR (254) NULL,
    [BODY]               TEXT          NULL,
    [GENERATED]          SMALLDATETIME DEFAULT (getdate()) NULL,
    [PRIORITY]           SMALLINT      NULL,
    [CL_CODE]            VARCHAR (6)   NULL,
    [DIV_CODE]           VARCHAR (6)   NULL,
    [PRD_CODE]           VARCHAR (6)   NULL,
    [CMP_CODE]           VARCHAR (6)   NULL,
    [JOB_NUMBER]         INT           NULL,
    [JOB_COMPONENT_NBR]  SMALLINT      NULL,
    [ESTIMATE_NUMBER]    INT           NULL,
    [EST_COMPONENT_NBR]  SMALLINT      NULL,
    [EST_QUOTE_NBR]      SMALLINT      NULL,
    [ESTIMATE_REV_NBR]   SMALLINT      NULL,
    [VN_CODE]            VARCHAR (6)   NULL,
    [EMP_CODE]           VARCHAR (6)   NULL,
    [PO_NUMBER]          INT           NULL,
    [PO_REVISION]        SMALLINT      NULL,
    [ORDER_NBR]          INT           NULL,
    [REV_NBR]            SMALLINT      NULL,
    [ALERT_USER]         VARCHAR (100) NULL,
    [TEMP_PDF_PATH]      VARCHAR (254) NULL,
    [ALERT_LEVEL]        VARCHAR (50)  NULL,
    [CMP_IDENTIFIER]     INT           NULL,
    [OFFICE_CODE]        VARCHAR (4)   NULL,
    [BODY_HTML]          TEXT          NULL,
    [CP_ALERT]           SMALLINT      NULL,
    [BA_BATCH_ID]        INT           NULL,
    [TASK_SEQ_NBR]       SMALLINT      NULL,
    [DUE_DATE]           SMALLDATETIME NULL,
    [ALERT_STATE_ID]     INT           NULL,
    [ALRT_NOTIFY_HDR_ID] INT           NULL,
    [TIME_DUE]           VARCHAR (10)  NULL,
    [VER]                VARCHAR (10)  NULL,
    [BUILD]              VARCHAR (10)  NULL,
    [ALERT_SEQ_NBR]      SMALLINT      NULL,
    [SENT]               SMALLDATETIME NULL,
    [LAST_UPDATED]       SMALLDATETIME NULL,
    [VER2]               VARCHAR (10)  NULL,
    [BUILD2]             VARCHAR (10)  NULL
);

