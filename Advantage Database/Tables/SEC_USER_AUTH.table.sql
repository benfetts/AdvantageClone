CREATE TABLE [dbo].[SEC_USER_AUTH] (
    [SEC_AUTH_ID] INT           IDENTITY (1, 1) NOT NULL,
    [SEC_USER_ID] INT           NOT NULL,
    [PWD_D]       VARCHAR (255) NULL
);

