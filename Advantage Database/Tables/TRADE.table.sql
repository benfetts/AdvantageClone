CREATE TABLE [dbo].[TRADE] (
    [TRADECODE]    VARCHAR (10)  NOT NULL,
    [TRADENAME]    VARCHAR (30)  NOT NULL,
    [TRADEUSER]    VARCHAR (100) NULL,
    [TRADEENTDATE] SMALLDATETIME NULL,
    [TRADEMODDATE] SMALLDATETIME NULL,
    [TRADEMOD]     VARCHAR (1)   NULL
);

