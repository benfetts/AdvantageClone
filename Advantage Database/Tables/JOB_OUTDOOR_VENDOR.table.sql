CREATE TABLE [dbo].[JOB_OUTDOOR_VENDOR] (
    [JOB_NUMBER]        INT          NOT NULL,
    [JOB_COMPONENT_NBR] SMALLINT     NOT NULL,
    [SPEC_ID]           SMALLINT     NOT NULL,
    [VN_CODE]           VARCHAR (6)  NOT NULL,
    [JOB_OUT_COPY_AREA] VARCHAR (40) NULL,
    [JOB_OUT_LOCATION]  VARCHAR (40) NULL,
    [JOB_OUT_OVR_SIZE]  VARCHAR (40) NULL,
    [AD_SIZE]           VARCHAR (6)  NULL
);

