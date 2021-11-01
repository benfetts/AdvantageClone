CREATE TABLE [dbo].[EMP_TIME] (
    [ET_ID]        INT           NOT NULL,
    [EMP_CODE]     VARCHAR (6)   NOT NULL,
    [EMP_DATE]     SMALLDATETIME NOT NULL,
    [PPPERIOD]     VARCHAR (6)   NULL,
    [ARCHIVE_FLAG] SMALLINT      NULL,
    [FREELANCE]    SMALLINT      NULL,
    [OFFICE_CODE]  CHAR (4)      NULL,
    [APPR_USER]    VARCHAR (100) NULL,
    [APPR_DATE]    SMALLDATETIME NULL,
    [APPR_PENDING] SMALLINT      NULL,
    [APPR_FLAG]    SMALLINT      NULL,
    [APPR_NOTES]   VARCHAR (254) NULL,
    [EMP_DTL_HRS]  AS            ([dbo].[advfn_emp_time_dtl_hrs]([ET_ID])),
    [EMP_NP_HRS]   AS            ([dbo].[advfn_emp_time_np_hrs]([ET_ID])),
    [EMP_TOT_HRS]  AS            ([dbo].[advfn_emp_time_tot_hrs]([ET_ID])),
    [ALERT_ID]     INT           NULL
);

