CREATE TABLE [dbo].[GRID_COLUMN_SETTING] (
    [GRIDCOLUMNSETTING_ID] INT           IDENTITY (1, 1) NOT NULL,
    [GRID_ID]              INT           NOT NULL,
    [GRID_COLUMN_ID]       INT           NOT NULL,
    [USER_CODE]            VARCHAR (100) NOT NULL,
    [IS_VISIBLE]           BIT           NOT NULL
);

