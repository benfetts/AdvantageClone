CREATE TABLE [dbo].[SEC_USER_MENU_TAB] (
    [SEC_USER_MENU_TAB_ID] INT           IDENTITY (1, 1) NOT NULL,
    [SEC_USER_ID]          INT           NOT NULL,
    [TAB_NAME]             VARCHAR (100) NOT NULL,
    [ORDER]                INT           NOT NULL,
    [SMALL_ICONS]          BIT           NOT NULL
);

