CREATE TYPE [dbo].[MEDIA_SPOT_TV_RESEARCH_TYPE] AS TABLE (
    [ReportType]          SMALLINT NOT NULL,
    [DominantProgramming] BIT      NOT NULL,
    [ShowProgramName]     BIT      NOT NULL,
    [ShowSpill]           BIT      NOT NULL);

