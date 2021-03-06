CREATE PROCEDURE [dbo].[usp_wv_job_comp_get]
	@JOB_NUMBER int,
	@JOB_COMPONENT_NBR smallint
AS
    SET NOCOUNT ON
    SELECT JOB_COMPONENT.JOB_NUMBER,
           JOB_COMPONENT.JOB_COMPONENT_NBR,
           JOB_COMPONENT.JOB_BILL_HOLD,
           JOB_COMPONENT.EMP_CODE,
           JOB_COMPONENT.JOB_COMP_DATE,
           JOB_COMPONENT.JOB_FIRST_USE_DATE,
           JOB_COMPONENT.START_DATE,
           JOB_COMPONENT.JOB_AD_SIZE,
           JOB_COMPONENT.JOB_SPEC_TYPE,
           JOB_COMPONENT.DP_TM_CODE,
           JOB_COMPONENT.JOB_MARKUP_PCT,
           JOB_COMPONENT.CREATIVE_INSTR,
           JOB_COMPONENT.JOB_LAYOUT_THUMB,
           JOB_COMPONENT.JOB_LAYOUT_ROUGH,
           JOB_COMPONENT.JOB_LAYOUT_COMP,
           JOB_COMPONENT.JOB_LAYOUT_NONE,
           JOB_COMPONENT.JOB_LAYOUT_SPECIAL,
           JOB_COMPONENT.JOB_LAYOUT_SPC_EXP,
           JOB_COMPONENT.JOB_PROCESS_CONTRL,
           JOB_COMPONENT.JOB_COMP_DESC,
           JOB_COMPONENT.JOB_COMP_COMMENTS,
           JOB_COMPONENT.JOB_COMP_BUDGET_AM,
           JOB_COMPONENT.ESTIMATE_NUMBER,
           JOB_COMPONENT.EST_COMPONENT_NBR,
           JOB_COMPONENT.BILLING_USER,
           JOB_COMPONENT.AB_FLAG,   -- Pos: 25
           JOB_COMPONENT.JOB_DEL_INSTRUCT,
           JOB_COMPONENT.JT_CODE,
           JOB_COMPONENT.TAX_FLAG,
           JOB_COMPONENT.TAX_CODE,
           JOB_COMPONENT.NOBILL_FLAG,
           JOB_COMPONENT.EMAIL_GR_CODE,
           JOB_COMPONENT.AD_NBR,
           JOB_COMPONENT.ACCT_NBR,
           JOB_COMPONENT.PRD_AB_INCOME,
           JOB_COMPONENT.MARKET_CODE,
           JOB_COMPONENT.SERVICE_FEE_FLAG,
           JOB_COMPONENT.PRD_CONT_CODE,
           JOB_COMPONENT.ARCHIVE_FLAG,
           JOB_COMPONENT.ROWID,
           JOB_COMPONENT.ADJUST_USER,
           JOB_COMPONENT.TRF_SCHEDULE_BY,
           JOB_COMPONENT.TRF_SCHEDULE_REQ,
           JOB_COMPONENT.JOB_CL_PO_NBR,
           JOB_LOG.CL_CODE,
           JOB_LOG.DIV_CODE,
           JOB_LOG.PRD_CODE,
           ISNULL(EMPLOYEE.EMP_FNAME, '') + ' ' + ISNULL(EMPLOYEE.EMP_MI + '. ', '') 
           + ' ' + ISNULL(EMPLOYEE.EMP_LNAME, ''),
		   CDP_CONTACT_HDR.CONT_FML,
           JOB_TYPE.JT_DESC,
           DEPT_TEAM.DP_TM_DESC,   -- Pos: 50
           AD_NUMBER.AD_NBR_DESC,
           MARKET.MARKET_DESC,
           JOB_COMPONENT.UDV1_CODE,
           JOB_CMP_UDV1.UDV_DESC,
           JOB_COMPONENT.UDV2_CODE,
           JOB_CMP_UDV2.UDV_DESC AS EXPR2,
           JOB_COMPONENT.UDV3_CODE,
           JOB_CMP_UDV3.UDV_DESC AS EXPR3,
           JOB_COMPONENT.UDV4_CODE,
           JOB_CMP_UDV4.UDV_DESC AS EXPR4,
           JOB_COMPONENT.UDV5_CODE,
           JOB_CMP_UDV5.UDV_DESC AS EXPR5,
           ISNULL(ACCT_NUMBER.ACCT_NBR_DESC, '') AS ACCT_NBR_DESC,
           JOB_COMPONENT.BLACKPLT_VER_CODE,
           JOB_COMPONENT.BLACKPLT_VER_DESC,
           JOB_COMPONENT.BLACKPLT_VER2_CODE,
           JOB_COMPONENT.BLACKPLT_VER2_DESC,
           JOB_COMPONENT.JOB_QTY,
           JOB_COMPONENT.FISCAL_PERIOD_CODE,
           JOB_COMPONENT.CDP_CONTACT_ID,   -- Pos: 70
           JOB_COMPONENT.ALRT_NOTIFY_HDR_ID,
           ISNULL(ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,'') AS ALERT_NOTIFY_NAME,
		   JOB_COMPONENT.SERVICE_FEE_TYPE_ID,
		   SERVICE_FEE_TYPE.CODE,
		   SERVICE_FEE_TYPE.DESCRIPTION,
           JOB_COMPONENT.CREATIVE_INSTR_HTML,
		   JOB_COMPONENT.JC_COMMENTS_HTML,
		   JOB_COMPONENT.JOB_DEL_INSTR_HTML
    FROM   JOB_COMPONENT WITH (NOLOCK)
           INNER JOIN JOB_LOG WITH (NOLOCK)
                ON  JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
           LEFT OUTER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK)
                ON  JOB_COMPONENT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID
           LEFT OUTER JOIN ACCT_NUMBER WITH (NOLOCK)
                ON  JOB_COMPONENT.ACCT_NBR = ACCT_NUMBER.ACCT_NBR
           LEFT OUTER JOIN EMPLOYEE WITH (NOLOCK)
                ON  JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
           LEFT OUTER JOIN PRD_CONTACT WITH (NOLOCK)
                ON  JOB_LOG.CL_CODE = PRD_CONTACT.CL_CODE
                    AND JOB_LOG.DIV_CODE = PRD_CONTACT.DIV_CODE
                    AND JOB_LOG.PRD_CODE = PRD_CONTACT.PRD_CODE
                    AND JOB_COMPONENT.PRD_CONT_CODE = PRD_CONTACT.CONT_CODE
           LEFT OUTER JOIN JOB_TYPE WITH (NOLOCK)
                ON  JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
           LEFT OUTER JOIN DEPT_TEAM WITH (NOLOCK)
                ON  JOB_COMPONENT.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
           LEFT OUTER JOIN AD_NUMBER WITH (NOLOCK)
                ON  JOB_COMPONENT.AD_NBR = AD_NUMBER.AD_NBR
           LEFT OUTER JOIN MARKET WITH (NOLOCK)
                ON  JOB_COMPONENT.MARKET_CODE = MARKET.MARKET_CODE
           LEFT OUTER JOIN JOB_CMP_UDV1 WITH (NOLOCK)
                ON  JOB_COMPONENT.UDV1_CODE = JOB_CMP_UDV1.UDV_CODE
           LEFT OUTER JOIN JOB_CMP_UDV2 WITH (NOLOCK)
                ON  JOB_COMPONENT.UDV2_CODE = JOB_CMP_UDV2.UDV_CODE
           LEFT OUTER JOIN JOB_CMP_UDV3 WITH (NOLOCK)
                ON  JOB_COMPONENT.UDV3_CODE = JOB_CMP_UDV3.UDV_CODE
           LEFT OUTER JOIN JOB_CMP_UDV4 WITH (NOLOCK)
                ON  JOB_COMPONENT.UDV4_CODE = JOB_CMP_UDV4.UDV_CODE
           LEFT OUTER JOIN JOB_CMP_UDV5 WITH (NOLOCK)
                ON  JOB_COMPONENT.UDV5_CODE = JOB_CMP_UDV5.UDV_CODE
		   LEFT OUTER JOIN CDP_CONTACT_HDR WITH (NOLOCK)
				ON JOB_COMPONENT.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
		   LEFT OUTER JOIN SERVICE_FEE_TYPE WITH (NOLOCK)
				ON JOB_COMPONENT.SERVICE_FEE_TYPE_ID = SERVICE_FEE_TYPE.SERVICE_FEE_TYPE_ID	
    WHERE  (JOB_COMPONENT.JOB_NUMBER = @JOB_NUMBER)
           AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR);
























