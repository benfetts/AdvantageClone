﻿CREATE TABLE [dbo].[CP_APPLICATIONS_CATEGORY] (
    [CATID]      INT           IDENTITY (1, 1) NOT NULL,
    [CATEGORY]   VARCHAR (50)  NOT NULL,
    [ICONPATH]   VARCHAR (100) NULL,
    [SORT_ORDER] INT           NULL
);

