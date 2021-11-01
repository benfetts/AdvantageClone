CREATE TABLE [dbo].[WV_WORKSPACE_OBJECT] (
    [ID]                INT          IDENTITY (1, 1) NOT NULL,
    [WORKSPACE_ID]      INT          NOT NULL,
    [DESKTOP_OBJECT_ID] INT          NOT NULL,
    [ZONE_ID]           VARCHAR (20) NOT NULL,
    [HEIGHT]            INT          NULL,
    [WIDTH]             INT          NULL,
    [TOP_COORD]         INT          NULL,
    [LEFT_COORD]        INT          NULL,
    [SORT_ORDER]        INT          NULL
);

