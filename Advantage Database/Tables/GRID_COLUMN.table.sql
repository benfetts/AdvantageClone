CREATE TABLE [dbo].[GRID_COLUMN] (
    [GRID_COLUMN_ID] INT           IDENTITY (1, 1) NOT NULL,
    [GRID_ID]        INT           NOT NULL,
    [NAME]           VARCHAR (100) NOT NULL,
    [IS_EDITABLE]    BIT           NOT NULL
);

