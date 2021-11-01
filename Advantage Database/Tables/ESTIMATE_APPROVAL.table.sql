﻿CREATE TABLE [dbo].[ESTIMATE_APPROVAL] (
    [JOB_NUMBER]         INT           NOT NULL,
    [JOB_COMPONENT_NBR]  SMALLINT      NOT NULL,
    [ESTIMATE_NUMBER]    INT           NOT NULL,
    [EST_COMPONENT_NBR]  SMALLINT      NOT NULL,
    [EST_QUOTE_NBR]      SMALLINT      NOT NULL,
    [EST_REVISION_NBR]   SMALLINT      NOT NULL,
    [EST_APPR_BY]        VARCHAR (40)  NULL,
    [EST_APPR_DATE]      SMALLDATETIME NULL,
    [EST_APPR_CL_PO_NBR] VARCHAR (20)  NULL,
    [EMP_CODE]           VARCHAR (6)   NULL,
    [APPR_PWD]           VARCHAR (10)  NULL,
    [APPROVAL_PWD]       SMALLINT      NULL,
    [CREATE_USER]        VARCHAR (100) NULL,
    [CREATE_DATE]        SMALLDATETIME NULL,
    [APPR_NOTES]         TEXT          NULL
);

