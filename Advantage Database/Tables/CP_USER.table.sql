CREATE TABLE [dbo].[CP_USER] (
    [USER_GUID]           UNIQUEIDENTIFIER NOT NULL,
    [USER_NAME]           VARCHAR (100)    NOT NULL,
    [LOWERED_USER_NAME]   VARCHAR (100)    NOT NULL,
    [FULL_NAME]           VARCHAR (100)    NULL,
    [PASSWORD_HASH]       VARCHAR (44)     NOT NULL,
    [LAST_LOGON]          DATETIME         NULL,
    [CREATED_BY]          VARCHAR (6)      NULL,
    [CREATED_TIMESTAMP]   DATETIME         NULL,
    [IS_LOCKED]           BIT              NULL,
    [EMAIL_ADDRESS]       VARCHAR (100)    NULL,
    [LOGIN_TRY_COUNT]     SMALLINT         NOT NULL,
    [UNLOCK_TIME]         DATETIME         NULL,
    [MUST_CHANGE_PASSORD] BIT              NOT NULL,
    [THEME]               VARCHAR (20)     NOT NULL,
    [CDP_CONTACT_ID]      INT              NOT NULL,
    [DESKTOP_TEMPLATE]    INT              NULL,
    [WEB_ID]              VARCHAR (50)     NULL,
    [ADMIN_USER]          BIT              NOT NULL,
    [CL_CODE]             VARCHAR (6)      NOT NULL,
    [ALERT_GROUP_CODE]    VARCHAR (50)     NULL,
    [AGENCY_CONTACT_CODE] VARCHAR (6)      NULL
);

