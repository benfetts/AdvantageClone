CREATE TABLE [dbo].[NIELSEN_RADIO_UNIVERSE] (
    [NIELSEN_RADIO_UNIVERSE_ID]       BIGINT IDENTITY (1, 1) NOT NULL,
    [NIELSEN_RADIO_SEGMENT_PARENT_ID] INT    NOT NULL,
    [FEMALES_6TO11_UE]                INT    NOT NULL,
    [FEMALES_12TO17_UE]               INT    NOT NULL,
    [FEMALES_18TO20_UE]               INT    NOT NULL,
    [FEMALES_18TO24_UE]               INT    NOT NULL,
    [FEMALES_21TO24_UE]               INT    NOT NULL,
    [FEMALES_25TO34_UE]               INT    NOT NULL,
    [FEMALES_35TO44_UE]               INT    NOT NULL,
    [FEMALES_35TO49_UE]               INT    NOT NULL,
    [FEMALES_45TO49_UE]               INT    NOT NULL,
    [FEMALES_50TO54_UE]               INT    NOT NULL,
    [FEMALES_55TO64_UE]               INT    NOT NULL,
    [FEMALES_65PLUS_UE]               INT    NOT NULL,
    [MALES_6TO11_UE]                  INT    NOT NULL,
    [MALES_12TO17_UE]                 INT    NOT NULL,
    [MALES_18TO20_UE]                 INT    NOT NULL,
    [MALES_18TO24_UE]                 INT    NOT NULL,
    [MALES_21TO24_UE]                 INT    NOT NULL,
    [MALES_25TO34_UE]                 INT    NOT NULL,
    [MALES_35TO44_UE]                 INT    NOT NULL,
    [MALES_35TO49_UE]                 INT    NOT NULL,
    [MALES_45TO49_UE]                 INT    NOT NULL,
    [MALES_50TO54_UE]                 INT    NOT NULL,
    [MALES_55TO64_UE]                 INT    NOT NULL,
    [MALES_65PLUS_UE]                 INT    NOT NULL,
    CONSTRAINT [PK_NIELSEN_RADIO_UNIVERSE] PRIMARY KEY CLUSTERED ([NIELSEN_RADIO_UNIVERSE_ID] ASC),
    CONSTRAINT [FK_NIELSEN_RADIO_UNIVERSE_NIELSEN_RADIO_SEGMENT_PARENT] FOREIGN KEY ([NIELSEN_RADIO_SEGMENT_PARENT_ID]) REFERENCES [dbo].[NIELSEN_RADIO_SEGMENT_PARENT] ([NIELSEN_RADIO_SEGMENT_PARENT_ID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NIELSEN_RADIO_UNIVERSE_UNIQUE]
    ON [dbo].[NIELSEN_RADIO_UNIVERSE]([NIELSEN_RADIO_SEGMENT_PARENT_ID] ASC);

