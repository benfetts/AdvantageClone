CREATE TABLE [dbo].[NIELSEN_TV_CUME_DAYPART_IMPRESSION] (
    [NIELSEN_TV_CUME_DAYPART_IMPRESSION_ID] BIGINT       IDENTITY (1, 1) NOT NULL,
    [ETHNICITY]                             VARCHAR (10) NOT NULL,
    [STATION_CODE]                          INT          NOT NULL,
    [NIELSEN_TV_CUME_BOOK_ID]               INT          NOT NULL,
    [NIELSEN_TV_DAYPART_ID]                 INT          NOT NULL,
    [METROA_HOUSEHOLD]                      INT          NOT NULL,
    [METROB_HOUSEHOLD]                      INT          NOT NULL,
    [HOUSEHOLD]                             INT          NOT NULL,
    [CHILDREN_2TO5]                         INT          NOT NULL,
    [CHILDREN_6TO11]                        INT          NOT NULL,
    [MALES_12TO14]                          INT          NOT NULL,
    [MALES_15TO17]                          INT          NOT NULL,
    [MALES_18TO20]                          INT          NOT NULL,
    [MALES_21TO24]                          INT          NOT NULL,
    [MALES_25TO34]                          INT          NOT NULL,
    [MALES_35TO49]                          INT          NOT NULL,
    [MALES_50TO54]                          INT          NOT NULL,
    [MALES_55TO64]                          INT          NOT NULL,
    [MALES_65PLUS]                          INT          NOT NULL,
    [FEMALES_12TO14]                        INT          NOT NULL,
    [FEMALES_15TO17]                        INT          NOT NULL,
    [FEMALES_18TO20]                        INT          NOT NULL,
    [FEMALES_21TO24]                        INT          NOT NULL,
    [FEMALES_25TO34]                        INT          NOT NULL,
    [FEMALES_35TO49]                        INT          NOT NULL,
    [FEMALES_50TO54]                        INT          NOT NULL,
    [FEMALES_55TO64]                        INT          NOT NULL,
    [FEMALES_65PLUS]                        INT          NOT NULL,
    [WORKING_WOMEN]                         INT          NOT NULL,
    CONSTRAINT [PK_NIELSEN_TV_CUME_DAYPART_IMPRESSION] PRIMARY KEY CLUSTERED ([NIELSEN_TV_CUME_DAYPART_IMPRESSION_ID] ASC),
    CONSTRAINT [FK_NIELSEN_TV_CUME_DAYPART_IMPRESSION_NIELSEN_TV_CUME_BOOK] FOREIGN KEY ([NIELSEN_TV_CUME_BOOK_ID]) REFERENCES [dbo].[NIELSEN_TV_CUME_BOOK] ([NIELSEN_TV_CUME_BOOK_ID]),
    CONSTRAINT [FK_NIELSEN_TV_CUME_DAYPART_IMPRESSION_NIELSEN_TV_DAYPART] FOREIGN KEY ([NIELSEN_TV_DAYPART_ID]) REFERENCES [dbo].[NIELSEN_TV_DAYPART] ([NIELSEN_TV_DAYPART_ID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NIELSEN_TV_CUME_DAYPART_IMPRESSIONS_UNIQUE]
    ON [dbo].[NIELSEN_TV_CUME_DAYPART_IMPRESSION]([STATION_CODE] ASC, [NIELSEN_TV_CUME_BOOK_ID] ASC, [NIELSEN_TV_DAYPART_ID] ASC);

