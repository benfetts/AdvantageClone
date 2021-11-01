CREATE TABLE [dbo].[JOB_PUB_SPECS] (
    [JOB_NUMBER]        INT          NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT     NOT NULL,
    [JOB_PUB_BLD_TYPE]  SMALLINT     NULL,
    [JOB_PUB_INK]       VARCHAR (40) NULL,
    [PUB_COMMENTS]      TEXT         NULL,
    [ROWID]             INT          IDENTITY (1, 1) NOT NULL
);

