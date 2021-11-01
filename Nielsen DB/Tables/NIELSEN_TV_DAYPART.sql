CREATE TABLE [dbo].[NIELSEN_TV_DAYPART] (
    [NIELSEN_TV_DAYPART_ID] INT          IDENTITY (1, 1) NOT NULL,
    [NIELSEN_DAYPART_ID]    INT          NOT NULL,
    [IS_HISPANIC]           BIT          NOT NULL,
    [TIME_ZONE]             CHAR (1)     NOT NULL,
    [NAME]                  VARCHAR (30) NOT NULL,
    [NUMBER_QUARTER_HOURS]  SMALLINT     NOT NULL,
    [MIL_START_TIME]        SMALLINT     NOT NULL,
    [MIL_END_TIME]          SMALLINT     NOT NULL,
    [START_MINUTE]          SMALLINT     NOT NULL,
    [END_MINUTE]            SMALLINT     NOT NULL,
    [USE_SEGMENT]           BIT          NOT NULL,
    [SUNDAY]                BIT          NOT NULL,
    [MONDAY]                BIT          NOT NULL,
    [TUESDAY]               BIT          NOT NULL,
    [WEDNESDAY]             BIT          NOT NULL,
    [THURSDAY]              BIT          NOT NULL,
    [FRIDAY]                BIT          NOT NULL,
    [SATURDAY]              BIT          NOT NULL,
    [IS_INACTIVE]           BIT          NOT NULL,
    CONSTRAINT [PK_NIELSEN_TV_DAYPART_1] PRIMARY KEY CLUSTERED ([NIELSEN_TV_DAYPART_ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NIELSEN_TV_DAYPART_UNIQUE]
    ON [dbo].[NIELSEN_TV_DAYPART]([NIELSEN_DAYPART_ID] ASC, [IS_HISPANIC] ASC, [TIME_ZONE] ASC);

