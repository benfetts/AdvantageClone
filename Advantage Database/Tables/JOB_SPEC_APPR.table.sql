﻿CREATE TABLE [dbo].[JOB_SPEC_APPR] (
    [JOB_NUMBER]        INT           NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT      NOT NULL,
    [APPR_SPEC_VER]     INT           NOT NULL,
    [SPEC_APPR_BY]      VARCHAR (40)  NOT NULL,
    [SPEC_APPR_COMMENT] TEXT          NULL,
    [SPEC_APPR_USER_ID] VARCHAR (100) NULL,
    [SPEC_APPR_DATE]    SMALLDATETIME NULL
);

