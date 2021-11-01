CREATE TABLE [dbo].[RECUR_PMT] (
    [RP_ID]       INT             NOT NULL,
    [VN_CODE]     VARCHAR (6)     NOT NULL,
    [OFFICE_CODE] VARCHAR (4)     NOT NULL,
    [REMARK]      VARCHAR (60)    NULL,
    [GLACODE]     VARCHAR (30)    NOT NULL,
    [AMOUNT]      DECIMAL (14, 2) NULL,
    [JANUARY]     SMALLINT        NULL,
    [FEBRUARY]    SMALLINT        NULL,
    [MARCH]       SMALLINT        NULL,
    [APRIL]       SMALLINT        NULL,
    [MAY]         SMALLINT        NULL,
    [JUNE]        SMALLINT        NULL,
    [JULY]        SMALLINT        NULL,
    [AUGUST]      SMALLINT        NULL,
    [SEPTEMBER]   SMALLINT        NULL,
    [OCTOBER]     SMALLINT        NULL,
    [NOVEMBER]    SMALLINT        NULL,
    [DECEMBER]    SMALLINT        NULL
);

