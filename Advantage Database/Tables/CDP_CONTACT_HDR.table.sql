CREATE TABLE [dbo].[CDP_CONTACT_HDR] (
    [CDP_CONTACT_ID]     INT          IDENTITY (1, 1) NOT NULL,
    [CONT_CODE]          VARCHAR (6)  NOT NULL,
    [CL_CODE]            VARCHAR (6)  NOT NULL,
    [EMAIL_ADDRESS]      VARCHAR (50) NULL,
    [CONT_FNAME]         VARCHAR (30) NULL,
    [CONT_LNAME]         VARCHAR (30) NULL,
    [CONT_MI]            VARCHAR (1)  NULL,
    [CONT_TITLE]         VARCHAR (40) NULL,
    [CONT_ADDRESS1]      VARCHAR (40) NULL,
    [CONT_ADDRESS2]      VARCHAR (40) NULL,
    [CONT_CITY]          VARCHAR (20) NULL,
    [CONT_COUNTY]        VARCHAR (20) NULL,
    [CONT_STATE]         VARCHAR (10) NULL,
    [CONT_COUNTRY]       VARCHAR (20) NULL,
    [CONT_ZIP]           VARCHAR (10) NULL,
    [CONT_TELEPHONE]     VARCHAR (13) NULL,
    [CONT_EXTENTION]     VARCHAR (5)  NULL,
    [CONT_FAX]           VARCHAR (13) NULL,
    [CONT_FAX_EXTENTION] VARCHAR (5)  NULL,
    [SCHEDULE_USER]      SMALLINT     NULL,
    [DEFAULT_TASK]       VARCHAR (10) NULL,
    [CP_USER]            SMALLINT     NULL,
    [CP_ALERTS]          SMALLINT     NULL,
    [EMAIL_RCPT]         SMALLINT     NULL,
    [TASK_PRIMARY]       SMALLINT     NULL,
    [INACTIVE_FLAG]      SMALLINT     NULL,
    [CONT_LF]            AS           (coalesce(([CONT_LNAME] + ', '),'') + coalesce((rtrim([CONT_FNAME])),'')),
    [CONT_FML]           AS           (coalesce((rtrim([CONT_FNAME]) + ' '),' ') + coalesce((ltrim(rtrim([CONT_MI]))),'') + case when (datalength(ltrim(rtrim([CONT_MI]))) = 0) then '' when (datalength(ltrim(rtrim([CONT_MI]))) is null) then '' else '. ' end + coalesce([CONT_LNAME],'')),
    [CELL_PHONE]         VARCHAR (13) NULL,
    [CONT_COMMENT]       TEXT         NULL
);

