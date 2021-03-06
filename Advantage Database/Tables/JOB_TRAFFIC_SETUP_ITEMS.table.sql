CREATE TABLE [dbo].[JOB_TRAFFIC_SETUP_ITEMS] (
    [ID]                     INT           IDENTITY (1, 1) NOT NULL,
    [COLUMN_NAME]            VARCHAR (254) NOT NULL,
    [COLUMN_LONG_DESC]       VARCHAR (150) NULL,
    [COLUMN_SHORT_DESC]      VARCHAR (75)  NULL,
    [AGENCY_REQ]             TINYINT       NULL,
    [CLIENT_REQ]             TINYINT       NULL,
    [ACTIVE]                 TINYINT       NULL,
    [DEFAULT_SHOW_LONG_DESC] TINYINT       NULL,
    [COLUMN_ORDER]			 SMALLINT      NULL
);

