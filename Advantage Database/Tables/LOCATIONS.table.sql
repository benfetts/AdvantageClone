﻿CREATE TABLE [dbo].[LOCATIONS] (
    [ID]             VARCHAR (6)   NULL,
    [NAME]           VARCHAR (50)  NULL,
    [ADDRESS1]       VARCHAR (50)  NULL,
    [ADDRESS2]       VARCHAR (50)  NULL,
    [CITY]           VARCHAR (35)  NULL,
    [STATE]          VARCHAR (10)  NULL,
    [ZIP]            VARCHAR (10)  NULL,
    [PHONE]          VARCHAR (20)  NULL,
    [FAX]            VARCHAR (20)  NULL,
    [EMAIL]          VARCHAR (60)  NULL,
    [LOC_FOOTER]     VARCHAR (254) NULL,
    [LOGO_LOCATION]  VARCHAR (1)   NULL,
    [PRT_HEADER]     SMALLINT      NULL,
    [PRT_NAME]       SMALLINT      NULL,
    [PRT_ADDR1]      SMALLINT      NULL,
    [PRT_ADDR2]      SMALLINT      NULL,
    [PRT_CITY]       SMALLINT      NULL,
    [PRT_STATE]      SMALLINT      NULL,
    [PRT_ZIP]        SMALLINT      NULL,
    [PRT_PHONE]      SMALLINT      NULL,
    [PRT_FAX]        SMALLINT      NULL,
    [PRT_EMAIL]      SMALLINT      NULL,
    [PRT_FOOTER]     SMALLINT      NULL,
    [PRT_NAME_FTR]   SMALLINT      NULL,
    [PRT_ADDR1_FTR]  SMALLINT      NULL,
    [PRT_ADDR2_FTR]  SMALLINT      NULL,
    [PRT_CITY_FTR]   SMALLINT      NULL,
    [PRT_STATE_FTR]  SMALLINT      NULL,
    [PRT_ZIP_FTR]    SMALLINT      NULL,
    [PRT_PHONE_FTR]  SMALLINT      NULL,
    [PRT_FAX_FTR]    SMALLINT      NULL,
    [PRT_EMAIL_FTR]  SMALLINT      NULL,
    [LOGO_PATH]      VARCHAR (254) NULL,
    [LOGO_PATH_LAND] VARCHAR (254) NULL
);

