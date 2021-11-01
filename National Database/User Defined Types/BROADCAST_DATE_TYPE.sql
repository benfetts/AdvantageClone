CREATE TYPE [dbo].[BROADCAST_DATE_TYPE] AS TABLE(
	[YYYYMM] [varchar](6) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL
);