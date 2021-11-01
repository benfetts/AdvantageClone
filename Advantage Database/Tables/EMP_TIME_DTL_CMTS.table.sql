CREATE TABLE [dbo].[EMP_TIME_DTL_CMTS] (
    [ET_ID]        INT         NOT NULL,
    [ET_DTL_ID]    SMALLINT    NOT NULL,
    [SEQ_NBR]      SMALLINT    NOT NULL,
    [ET_SOURCE]    VARCHAR (1) NOT NULL,
    [EMP_COMMENT]  TEXT        NULL,
    [ADJ_COMMENTS] TEXT        NULL,
    [START_TIME]   CHAR (4)    NULL,
    [END_TIME]     CHAR (4)    NULL
);

