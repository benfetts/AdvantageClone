CREATE TABLE [dbo].[PRINT_EST_SPOTS] (
    [EST_SPOT_ID]   INT           IDENTITY (1, 1) NOT NULL,
    [EST_NBR]       INT           NOT NULL,
    [EST_LINE_NBR]  SMALLINT      NOT NULL,
    [EST_REV_NBR]   SMALLINT      NOT NULL,
    [EST_SEQ_NBR]   SMALLINT      NOT NULL,
    [EST_LINE_TYPE] VARCHAR (2)   NOT NULL,
    [ACTIVE_REV]    SMALLINT      NOT NULL,
    [MONTH_NBR]     SMALLINT      NOT NULL,
    [YEAR_NBR]      SMALLINT      NOT NULL,
    [DATE1]         SMALLDATETIME NULL,
    [DATE2]         SMALLDATETIME NULL,
    [DATE3]         SMALLDATETIME NULL,
    [DATE4]         SMALLDATETIME NULL,
    [DATE5]         SMALLDATETIME NULL,
    [DATE6]         SMALLDATETIME NULL,
    [DATE7]         SMALLDATETIME NULL,
    [SPOTS1]        SMALLINT      NULL,
    [SPOTS2]        SMALLINT      NULL,
    [SPOTS3]        SMALLINT      NULL,
    [SPOTS4]        SMALLINT      NULL,
    [SPOTS5]        SMALLINT      NULL,
    [SPOTS6]        SMALLINT      NULL,
    [SPOTS7]        SMALLINT      NULL,
    [TOTAL_SPOTS]   INT           NULL
);

