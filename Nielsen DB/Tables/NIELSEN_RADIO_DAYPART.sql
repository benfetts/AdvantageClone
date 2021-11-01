CREATE TABLE [dbo].[NIELSEN_RADIO_DAYPART] (
    [NIELSEN_RADIO_DAYPART_ID] INT          IDENTITY (1, 1) NOT NULL,
    [NIELSEN_DAYPART_ID]       SMALLINT     NOT NULL,
    [NAME]                     VARCHAR (30) NOT NULL,
    [NUMBER_QUARTER_HOURS]     SMALLINT     NOT NULL,
    [AQH]                      BIT          NOT NULL,
    [CUME]                     BIT          NOT NULL,
    [EXCLUSIVE_CUME]           BIT          NOT NULL,
    [QUALITATIVE]              BIT          NOT NULL,
    [DIARY_AT_WORK_IN_CAR]     BIT          NOT NULL,
    [PPM_IN_HOME_OUT_OF_HOME]  BIT          NOT NULL,
    [MIL_START_TIME]           SMALLINT     NULL,
    [MIL_END_TIME]             SMALLINT     NULL,
    [START_MINUTE]             SMALLINT     NULL,
    [END_MINUTE]               SMALLINT     NULL,
    [USE_SEGMENT]              BIT          NULL,
    [SUNDAY]                   BIT          NULL,
    [MONDAY]                   BIT          NULL,
    [TUESDAY]                  BIT          NULL,
    [WEDNESDAY]                BIT          NULL,
    [THURSDAY]                 BIT          NULL,
    [FRIDAY]                   BIT          NULL,
    [SATURDAY]                 BIT          NULL,
	[USE_CUME_SEGMENT]         BIT          NULL,
    CONSTRAINT [PK_NIELSEN_RADIO_DAYPART] PRIMARY KEY CLUSTERED ([NIELSEN_RADIO_DAYPART_ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NIELSEN_RADIO_DAYPART_UNIQUE]
    ON [dbo].[NIELSEN_RADIO_DAYPART]([NIELSEN_DAYPART_ID] ASC);

