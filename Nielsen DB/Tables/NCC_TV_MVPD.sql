CREATE TABLE [dbo].[NCC_TV_MVPD] (
    [NCC_TV_MVPD_ID] INT           IDENTITY (1, 1) NOT NULL,
    [MVPD]           VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_NCC_TV_MVPD] PRIMARY KEY CLUSTERED ([NCC_TV_MVPD_ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCC_TV_MVPD_UNIQUE]
    ON [dbo].[NCC_TV_MVPD]([MVPD] ASC);

