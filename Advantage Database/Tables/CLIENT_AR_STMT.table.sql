CREATE TABLE [dbo].[CLIENT_AR_STMT] (
    [CL_CODE]         VARCHAR (6) NOT NULL,
    [DIST_VIA_EMAIL]  SMALLINT    DEFAULT (0) NOT NULL,
    [DIST_VIA_PRINT]  SMALLINT    DEFAULT (0) NOT NULL,
    [USE_ADDRESS]     SMALLINT    NULL,
    [INCL_ON_ACCT]    SMALLINT    DEFAULT (0) NOT NULL,
    [REPORT_FORMAT]   SMALLINT    NULL,
    [REPORT_TEMPLATE] SMALLINT    NULL,
    [LAST_EMAILED]    DATETIME    NULL,
    [LAST_PRINTED]    DATETIME    NULL,
    [CDP_CONTACT_ID]  INT         NOT NULL,
    [CONT_CODE]       AS          ([dbo].[udf_get_cont_code]([CDP_CONTACT_ID]))
);

