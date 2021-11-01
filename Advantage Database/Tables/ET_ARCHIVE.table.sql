CREATE TABLE [dbo].[ET_ARCHIVE] (
    [ET_ID]             INT             NOT NULL,
    [SEQ_NBR]           SMALLINT        DEFAULT (0) NOT NULL,
    [EMP_HOURS]         DECIMAL (6, 3)  NULL,
    [EMP_BILL_RATE]     DECIMAL (14, 2) NULL,
    [EMP_COST_RATE]     DECIMAL (14, 2) NULL,
    [EMP_NON_BILL_FLAG] SMALLINT        NULL,
    [DATE_ENTERED]      SMALLDATETIME   DEFAULT (getdate()) NULL,
    [USER_ID]           VARCHAR (100)   NULL,
    [TOTAL_COST]        DECIMAL (14, 2) NULL,
    [TOTAL_BILL]        DECIMAL (14, 2) NULL,
    [LINE_TOTAL]        DECIMAL (14, 2) NULL
);

