CREATE TABLE [dbo].[VENDOR_COMMENTS] (
    [VN_CODE]        VARCHAR (6)   NOT NULL,
    [MATL_NOTES]     TEXT          NULL,
    [CLOSE_INFO]     TEXT          NULL,
    [RATE_INFO]      TEXT          NULL,
    [MISC_INFO]      TEXT          NULL,
    [POSITION_INFO]  TEXT          NULL,
    [INSTRUCTIONS]   TEXT          NULL,
    [FOOTER_INFO]    TEXT          NULL,
    [USE_FOOTER]     SMALLINT      NULL,
    [DLVRY_GEN_INFO] TEXT          NULL,
    [ACCEPTED_MEDIA] VARCHAR (250) NULL,
    [PREF_MATL]      VARCHAR (250) NULL,
    [EFILE_INFO]     VARCHAR (250) NULL,
    [FTP_USER]       VARCHAR (100) NULL,
    [FTP_PW]         VARCHAR (100) NULL,
    [FTP_DIR]        VARCHAR (100) NULL
);

