﻿CREATE TABLE [dbo].[CRTV_BRF_DTL] (
    [CRTV_BRF_DTL_ID]   INT           NOT NULL,
    [CRTV_BRF_DTL_DESC] TEXT          NULL,
    [JOB_NUMBER]        INT           NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT      NOT NULL,
    [CRTV_BRF_LVL3_ID]  SMALLINT      NOT NULL,
    [DTL_ORDER]         INT           NULL,
    [CREATED_BY]        VARCHAR (100) NULL,
    [CREATE_DATE]       SMALLDATETIME NULL
);

