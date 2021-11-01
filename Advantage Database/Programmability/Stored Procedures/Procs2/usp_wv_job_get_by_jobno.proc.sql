



















/* ST, 060627 - Changed join to sc_format table */
CREATE PROCEDURE [dbo].[usp_wv_job_get_by_jobno]
	@JOB_NUMBER int
AS
DECLARE @TotalBudget DECIMAL(11, 2)

SET NOCOUNT ON

        SELECT @TotalBudget = SUM(JOB_COMP_BUDGET_AM)
        FROM   JOB_COMPONENT
        WHERE  JOB_NUMBER = @JOB_NUMBER

        SELECT TOP 1
               JOB_LOG.[JOB_NUMBER],
               JOB_LOG.[OFFICE_CODE],
               JOB_LOG.[CL_CODE],
               JOB_LOG.[DIV_CODE],
               JOB_LOG.[PRD_CODE],
               JOB_LOG.[CMP_CODE],
               JOB_LOG.[SC_CODE],
               JOB_LOG.[USER_ID],
               JOB_LOG.[CREATE_DATE],
               JOB_LOG.[JOB_DESC],
               JOB_LOG.[JOB_DATE_OPENED],
               JOB_LOG.[JOB_RUSH_CHARGES],
               JOB_LOG.[JOB_ESTIMATE_REQ],
               JOB_LOG.[JOB_COMMENTS],
               JOB_LOG.[JOB_CLI_REF],
               JOB_LOG.[BILL_COOP_CODE],
               JOB_LOG.[FORMAT_SC_CODE],
               JOB_LOG.[FORMAT_CODE],
               JOB_LOG.[COMPLEX_CODE],
               JOB_LOG.[PROMO_CODE],
               JOB_LOG.[CMP_IDENTIFIER],
               JOB_LOG.[CMP_LINE_NBR],
               JOB_LOG.[ROWID],
               JOB_LOG.[JOB_BILL_COMMENT],
               JOB_LOG.[FEE_JOB],
               CLIENT.CL_NAME,
               DIVISION.DIV_NAME,
               PRODUCT.PRD_DESCRIPTION,
               SC_DESCRIPTION,
               CMP_NAME,
               BILL_COOP_DESC,
               SC_FORMAT.FORMAT_DESC,
               COMPLEX_DESC,
               PROMO_DESC,
               JOB_LOG.[UDV1_CODE],
               JOB_LOG_UDV1.UDV_DESC,
               JOB_LOG.[UDV2_CODE],
               JOB_LOG_UDV2.UDV_DESC,
               JOB_LOG.[UDV3_CODE],
               JOB_LOG_UDV3.UDV_DESC,
               JOB_LOG.[UDV4_CODE],
               JOB_LOG_UDV4.UDV_DESC,
               JOB_LOG.[UDV5_CODE],
               JOB_LOG_UDV5.UDV_DESC,
               @TotalBudget,
               JOB_LOG.[JOB_COMMENTS_HTML]
        FROM   JOB_LOG WITH(NOLOCK)
               INNER JOIN CLIENT WITH(NOLOCK)
                    ON  JOB_LOG.CL_CODE = CLIENT.CL_CODE
               INNER JOIN DIVISION WITH(NOLOCK)
                    ON  JOB_LOG.CL_CODE = DIVISION.CL_CODE
                        AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE
               INNER JOIN PRODUCT WITH(NOLOCK)
                    ON  JOB_LOG.CL_CODE = PRODUCT.CL_CODE
                        AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE
                        AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE
               LEFT OUTER JOIN SC_FORMAT WITH(NOLOCK)
                    ON  JOB_LOG.SC_CODE = SC_FORMAT.SC_CODE
                        AND JOB_LOG.FORMAT_CODE = SC_FORMAT.FORMAT_CODE
               LEFT OUTER JOIN SALES_CLASS WITH(NOLOCK)
                    ON  JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE
               LEFT OUTER JOIN CAMPAIGN WITH(NOLOCK)
                    ON  JOB_LOG.CMP_CODE = CAMPAIGN.CMP_CODE
                        AND JOB_LOG.CL_CODE = CAMPAIGN.CL_CODE
                        AND JOB_LOG.DIV_CODE = CAMPAIGN.DIV_CODE
                        AND JOB_LOG.PRD_CODE = CAMPAIGN.PRD_CODE
               LEFT OUTER JOIN BILLING_COOP WITH(NOLOCK)
                    ON  JOB_LOG.BILL_COOP_CODE = BILLING_COOP.BILL_COOP_CODE
               LEFT OUTER JOIN COMPLEXITY WITH(NOLOCK)
                    ON  JOB_LOG.COMPLEX_CODE = COMPLEXITY.COMPLEX_CODE
               LEFT OUTER JOIN PROMO_TYPE WITH(NOLOCK)
                    ON  JOB_LOG.PROMO_CODE = PROMO_TYPE.PROMO_CODE
               LEFT OUTER JOIN JOB_LOG_UDV1 WITH(NOLOCK)
                    ON  JOB_LOG.UDV1_CODE = JOB_LOG_UDV1.UDV_CODE
               LEFT OUTER JOIN JOB_LOG_UDV2 WITH(NOLOCK)
                    ON  JOB_LOG.UDV2_CODE = JOB_LOG_UDV2.UDV_CODE
               LEFT OUTER JOIN JOB_LOG_UDV3 WITH(NOLOCK)
                    ON  JOB_LOG.UDV3_CODE = JOB_LOG_UDV3.UDV_CODE
               LEFT OUTER JOIN JOB_LOG_UDV4 WITH(NOLOCK)
                    ON  JOB_LOG.UDV4_CODE = JOB_LOG_UDV4.UDV_CODE
               LEFT OUTER JOIN JOB_LOG_UDV5 WITH(NOLOCK)
                    ON  JOB_LOG.UDV5_CODE = JOB_LOG_UDV5.UDV_CODE
        WHERE  JOB_LOG.[JOB_NUMBER] = @JOB_NUMBER;


















