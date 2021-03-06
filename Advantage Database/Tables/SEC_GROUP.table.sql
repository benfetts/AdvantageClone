CREATE TABLE [dbo].[SEC_GROUP] (
    [SEC_GROUP_ID] INT           IDENTITY (1, 1) NOT NULL,
    [NAME]         VARCHAR (50)  NOT NULL,
    [DESCRIPTION]  VARCHAR (100) NOT NULL,
    UNIQUE NONCLUSTERED ([NAME] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
);

