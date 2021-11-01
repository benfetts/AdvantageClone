





















CREATE PROCEDURE [dbo].[usp_wv_dd_job_coop_billing] 

AS
Select Distinct BILL_COOP_CODE as code, BILL_COOP_CODE + ' - ' + BILL_COOP_DESC as description
FROM BILLING_COOP
WHERE (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)





















