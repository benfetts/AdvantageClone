﻿CREATE TABLE [dbo].[BRD_IMPORT_BUY] (
    [MEDIA]        VARCHAR (2)     NULL,
    [CLIENT]       VARCHAR (4)     NULL,
    [PRODUCT]      VARCHAR (4)     NULL,
    [ESTIMATE]     VARCHAR (30)    NULL,
    [MARKET]       VARCHAR (4)     NULL,
    [STATION]      VARCHAR (5)     NULL,
    [BAND]         VARCHAR (2)     NULL,
    [BUYER]        VARCHAR (8)     NULL,
    [SERVICE]      VARCHAR (1)     NULL,
    [PRJBKS1]      VARCHAR (6)     NULL,
    [PRJBKS2]      VARCHAR (6)     NULL,
    [PRJBKS3]      VARCHAR (6)     NULL,
    [STAT]         VARCHAR (4)     NULL,
    [COST]         DECIMAL (10, 2) NULL,
    [BUYID]        DECIMAL (6)     NULL,
    [BUY_DETID]    INT             NULL,
    [LINE_NBR]     INT             NULL,
    [STARTDATE]    SMALLDATETIME   NULL,
    [ENDDATE]      SMALLDATETIME   NULL,
    [DAYPART]      VARCHAR (2)     NULL,
    [LENGTH]       VARCHAR (3)     NULL,
    [DAYOFWEEK]    VARCHAR (7)     NULL,
    [STARTTIME]    VARCHAR (7)     NULL,
    [ENDTIME]      VARCHAR (7)     NULL,
    [PROGRAM]      VARCHAR (20)    NULL,
    [BUYRATE1]     DECIMAL (10, 2) NULL,
    [BUYRATE2]     DECIMAL (10, 2) NULL,
    [BUYTYPE]      VARCHAR (4)     NULL,
    [SPECREP]      VARCHAR (8)     NULL,
    [STADEALNO]    VARCHAR (6)     NULL,
    [CLIDEALNO]    VARCHAR (6)     NULL,
    [CASHTRADE]    VARCHAR (1)     NULL,
    [NETFACT]      DECIMAL (10, 2) NULL,
    [OUTSIDER]     VARCHAR (8)     NULL,
    [ESTDMVAL1]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL2]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL3]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL4]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL5]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL6]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL7]    DECIMAL (7, 1)  NULL,
    [ESTDMVAL8]    DECIMAL (7, 1)  NULL,
    [WK1]          SMALLINT        NULL,
    [WK2]          SMALLINT        NULL,
    [WK3]          SMALLINT        NULL,
    [WK4]          SMALLINT        NULL,
    [WK5]          SMALLINT        NULL,
    [WK6]          SMALLINT        NULL,
    [WK7]          SMALLINT        NULL,
    [WK8]          SMALLINT        NULL,
    [WK9]          SMALLINT        NULL,
    [WK10]         SMALLINT        NULL,
    [WK11]         SMALLINT        NULL,
    [WK12]         SMALLINT        NULL,
    [WK13]         SMALLINT        NULL,
    [WK14]         SMALLINT        NULL,
    [WKTOT]        SMALLINT        NULL,
    [PT1]          VARCHAR (4)     NULL,
    [PT2]          VARCHAR (4)     NULL,
    [SESSIONID]    INT             NULL,
    [INVDETID]     INT             NULL,
    [CONFIRMED]    VARCHAR (1)     NULL,
    [SOFTDELETE]   VARCHAR (1)     NULL,
    [SPILLLINE]    VARCHAR (1)     NULL,
    [HOLD]         VARCHAR (1)     NULL,
    [STATUS]       VARCHAR (4)     NULL,
    [PROGTYPE]     VARCHAR (8)     NULL,
    [KEEPEST]      VARCHAR (1)     NULL,
    [CLTINT1]      VARCHAR (8)     NULL,
    [CLTINT2]      VARCHAR (8)     NULL,
    [PRODINT1]     VARCHAR (8)     NULL,
    [PRODINT2]     VARCHAR (8)     NULL,
    [ESTINT1]      VARCHAR (8)     NULL,
    [ESTINT2]      VARCHAR (8)     NULL,
    [STNINT1]      VARCHAR (8)     NULL,
    [STNINT2]      VARCHAR (8)     NULL,
    [CLTNAME]      VARCHAR (30)    NULL,
    [PRODNAME]     VARCHAR (30)    NULL,
    [ESTNAME]      VARCHAR (30)    NULL,
    [ESTTYPE]      VARCHAR (10)    NULL,
    [COMMENT1]     VARCHAR (80)    NULL,
    [COMMENT2]     VARCHAR (80)    NULL,
    [COMMENT3]     VARCHAR (80)    NULL,
    [IMPORT_STAT]  VARCHAR (1)     NULL,
    [STAT_DATE]    SMALLDATETIME   DEFAULT (getdate()) NULL,
    [COL_ID]       FLOAT           NULL,
    [WKEXT_14]     SMALLINT        NULL,
    [WKEXT_15]     SMALLINT        NULL,
    [WKEXT_16]     SMALLINT        NULL,
    [WKEXT_17]     SMALLINT        NULL,
    [WKEXT_18]     SMALLINT        NULL,
    [WKEXT_19]     SMALLINT        NULL,
    [WKEXT_20]     SMALLINT        NULL,
    [WKEXT_21]     SMALLINT        NULL,
    [WKEXT_22]     SMALLINT        NULL,
    [WKEXT_23]     SMALLINT        NULL,
    [WKEXT_24]     SMALLINT        NULL,
    [WKEXT_25]     SMALLINT        NULL,
    [WKEXT_26]     SMALLINT        NULL,
    [WKEXT_27]     SMALLINT        NULL,
    [WKEXT_28]     SMALLINT        NULL,
    [WKEXT_29]     SMALLINT        NULL,
    [WKEXT_30]     SMALLINT        NULL,
    [WKEXT_31]     SMALLINT        NULL,
    [WKEXT_32]     SMALLINT        NULL,
    [WKEXT_33]     SMALLINT        NULL,
    [WKEXT_34]     SMALLINT        NULL,
    [WKEXT_35]     SMALLINT        NULL,
    [WKEXT_36]     SMALLINT        NULL,
    [WKEXT_37]     SMALLINT        NULL,
    [WKEXT_38]     SMALLINT        NULL,
    [WKEXT_39]     SMALLINT        NULL,
    [WKEXT_40]     SMALLINT        NULL,
    [WKEXT_41]     SMALLINT        NULL,
    [WKEXT_42]     SMALLINT        NULL,
    [WKEXT_43]     SMALLINT        NULL,
    [WKEXT_44]     SMALLINT        NULL,
    [WKEXT_45]     SMALLINT        NULL,
    [WKEXT_46]     SMALLINT        NULL,
    [WKEXT_47]     SMALLINT        NULL,
    [WKEXT_48]     SMALLINT        NULL,
    [WKEXT_49]     SMALLINT        NULL,
    [WKEXT_50]     SMALLINT        NULL,
    [WKEXT_51]     SMALLINT        NULL,
    [WKEXT_52]     SMALLINT        NULL,
    [SC_TYPE]      VARCHAR (6)     NULL,
    [DELETE_ORDER] SMALLINT        NULL,
    [DELETE_LINE]  SMALLINT        NULL,
    [TAG]          VARCHAR (10)    NULL
);

