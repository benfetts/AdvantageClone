﻿CREATE TABLE [dbo].[GLTEMPLATE] (
    [GLTNAME]     VARCHAR (20) NOT NULL,
    [GLTBASE]     VARCHAR (30) NOT NULL,
    [GLTNAMEDESC] VARCHAR (40) NOT NULL,
    [GLTDESC]     VARCHAR (75) NOT NULL,
    [GLTTYPE]     VARCHAR (2)  NOT NULL,
    [GLTBALTYPE]  SMALLINT     NOT NULL,
    [GLTCDPREQ]   SMALLINT     NULL
);

