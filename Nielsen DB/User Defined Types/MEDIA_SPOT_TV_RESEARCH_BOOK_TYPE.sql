CREATE TYPE [dbo].[MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE] AS TABLE (
    [ID]           INT      NOT NULL,
    [UseLatest]    BIT      NOT NULL,
    [LatestStream] CHAR (2) NULL,
    [ShareBookID]  INT      NULL,
    [HPUTBookID]   INT      NULL);

