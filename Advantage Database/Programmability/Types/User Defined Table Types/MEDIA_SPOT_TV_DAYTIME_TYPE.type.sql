CREATE TYPE [dbo].[MEDIA_SPOT_TV_DAYTIME_TYPE] AS TABLE(
	[ID] [int] NOT NULL,
	[Monday] [bit] NOT NULL,
	[Tuesday] [bit] NOT NULL,
	[Wednesday] [bit] NOT NULL,
	[Thursday] [bit] NOT NULL,
	[Friday] [bit] NOT NULL,
	[Saturday] [bit] NOT NULL,
	[Sunday] [bit] NOT NULL,
	[StartTime] [varchar](10) NOT NULL,
	[EndTime] [varchar](10) NOT NULL,
	[StartHour] [smallint] NOT NULL,
	[EndHour] [smallint] NOT NULL,
	[Days] [varchar](100) NOT NULL,
	[ExactSpotDate] [datetime] NULL
)
GO


