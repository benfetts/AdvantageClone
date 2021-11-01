CREATE TABLE [dbo].[GLALTRAILER] (
    [GLALTXACT]       INT           NOT NULL,
    [GLALTCFF1]       VARCHAR (30)  NULL,
    [GLALTNFF1]       FLOAT         NULL,
    [GLALTDTFF1]      SMALLDATETIME NULL,
    [GLALTCODE]       VARCHAR (30)  NOT NULL,
    [GLALTVALUE]      FLOAT         NULL,
    [GLALTALLOCATION] FLOAT         NULL,
    [GLALTAMOUNT]     FLOAT         NULL,
    [CL_CODE]         VARCHAR (6)   NULL,
    [DIV_CODE]        VARCHAR (6)   NULL,
    [PRD_CODE]        VARCHAR (6)   NULL,
    [ROWID]           INT           IDENTITY (1, 1) NOT NULL
);

