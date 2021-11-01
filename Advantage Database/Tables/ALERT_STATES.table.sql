CREATE TABLE [dbo].[ALERT_STATES] (
    [ALERT_STATE_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [ALERT_STATE_NAME]  VARCHAR (100) NOT NULL,
    [SORT_ORDER]        INT           NULL,
    [ACTIVE_FLAG]       BIT           NULL,
    [DFLT_ALERT_CAT_ID] INT           NULL
);

