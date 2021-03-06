CREATE TABLE [dbo].[NIELSEN_RADIO_QUALITATIVE] (
    [NIELSEN_RADIO_QUALITATIVE_ID] INT          IDENTITY (1, 1) NOT NULL,
    [CODE]                         VARCHAR (10) NOT NULL,
    [NAME]                         VARCHAR (40) NOT NULL,
    CONSTRAINT [PK_NIELSEN_RADIO_QUALITATIVE] PRIMARY KEY CLUSTERED ([NIELSEN_RADIO_QUALITATIVE_ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NIELSEN_RADIO_QUALITATIVE_UNIQUE]
    ON [dbo].[NIELSEN_RADIO_QUALITATIVE]([CODE] ASC);

