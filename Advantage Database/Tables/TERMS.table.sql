CREATE TABLE [dbo].[TERMS] (
    [TERMCODE]    INT            NOT NULL,
    [TERMNAME]    VARCHAR (30)   NOT NULL,
    [TERMTYPE]    VARCHAR (1)    NOT NULL,
    [TERMDISDAYS] SMALLINT       NULL,
    [TERMDISRATE] DECIMAL (6, 3) NULL,
    [TERMNET]     SMALLINT       NULL,
    [TERMNETDATE] SMALLDATETIME  NULL,
    [TERMUSER]    VARCHAR (100)  NULL,
    [TERMENTDATE] SMALLDATETIME  NULL,
    [TERMMODDATE] SMALLDATETIME  NULL,
    [TERMMOD]     VARCHAR (1)    NULL
);

