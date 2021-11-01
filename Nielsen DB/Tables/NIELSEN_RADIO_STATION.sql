CREATE TABLE [dbo].[NIELSEN_RADIO_STATION] (
    [NIELSEN_RADIO_STATION_ID]    INT          IDENTITY (1, 1) NOT NULL,
    [NIELSEN_RADIO_MARKET_NUMBER] INT          NOT NULL,
    [COMBO_ID]                    INT          NOT NULL,
    [NAME]                        VARCHAR (30) NOT NULL,
    [CALL_LETTERS]                VARCHAR (4)  NOT NULL,
    [BAND]                        VARCHAR (2)  NOT NULL,
    [FREQUENCY]                   VARCHAR (5)  NOT NULL,
    [COMBO_TYPE]                  SMALLINT     NOT NULL,
    [NIELSEN_RADIO_FORMAT_CODE]   VARCHAR (4)  NOT NULL,
    [IS_SPILLIN]                  BIT          NOT NULL,
	[SOURCE] [smallint] NOT NULL DEFAULT ((0)),
    CONSTRAINT [PK_NIELSEN_RADIO_STATION] PRIMARY KEY CLUSTERED ([NIELSEN_RADIO_STATION_ID] ASC)
);

