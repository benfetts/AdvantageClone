CREATE TABLE [dbo].[GLRJEHDR] (
    [GLRHCNTRL]    INT           NOT NULL,
    [GLRHDESC]     VARCHAR (45)  NULL,
    [GLRHENTDATE]  SMALLDATETIME NULL,
    [GLRHCYCLE]    VARCHAR (6)   NULL,
    [GLRHREVFLAG]  VARCHAR (1)   NULL,
    [GLRHUSER]     VARCHAR (100) NULL,
    [GLRHLASTPP]   VARCHAR (6)   NULL,
    [GLRHLASTDATE] SMALLDATETIME NULL,
    [GLRHLASTBY]   VARCHAR (100) NULL,
    [GLRHMOD]      VARCHAR (1)   NULL,
    [GLRHMODDATE]  SMALLDATETIME NULL,
    [GLRHINACTIVE] SMALLINT      NULL,
    [GLRJEVOID]    SMALLINT      NULL
);

