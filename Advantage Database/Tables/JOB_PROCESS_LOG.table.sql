CREATE TABLE [dbo].[JOB_PROCESS_LOG] (
    [JOB_NUMBER]         INT           NOT NULL,
    [JOB_COMPONENT_NBR]  SMALLINT      NOT NULL,
    [ORIG_PROCESS_CNTRL] SMALLINT      NULL,
    [NEW_PROCESS_CNTRL]  SMALLINT      NULL,
    [PROCESS_DATE]       SMALLDATETIME DEFAULT (getdate()) NULL,
    [PROCESS_USER]       VARCHAR (100) NULL,
    [PROCESS_COMMENT]    TEXT          NULL,
    [BCC_FLAG]           SMALLINT      DEFAULT ((0)) NULL,
    [JOB_PROCESS_LOG_ID] INT           IDENTITY (1, 1) NOT NULL
);

