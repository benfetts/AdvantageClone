IF EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = 'MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE')
	DROP TYPE [dbo].[MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE]
GO

CREATE TYPE [dbo].[MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE] AS TABLE (
    [ID]            INT           NOT NULL,
    [Monday]        BIT           NOT NULL,
    [Tuesday]       BIT           NOT NULL,
    [Wednesday]     BIT           NOT NULL,
    [Thursday]      BIT           NOT NULL,
    [Friday]        BIT           NOT NULL,
    [Saturday]      BIT           NOT NULL,
    [Sunday]        BIT           NOT NULL,
    [StartTime]     VARCHAR (10)  NOT NULL,
    [EndTime]       VARCHAR (10)  NOT NULL,
    [StartHour]     SMALLINT      NOT NULL,
    [EndHour]       SMALLINT      NOT NULL,
    [Days]          VARCHAR (100) NOT NULL,
    [ExactSpotDate] DATETIME      NULL);
GO

