CREATE TABLE [dbo].[ALERT_NOTIFY_STATES] (
    [ALRT_NOTIFY_HDR_ID] INT         NOT NULL,
    [ALERT_STATE_ID]     INT         NOT NULL,
    [SORT_ORDER]         INT         NULL,
    [DFLT_EMP_CODE]      VARCHAR (6) NULL,
    [IS_DFLT]            BIT         NULL,
    [IS_COMPLETED]       BIT         NULL
);

