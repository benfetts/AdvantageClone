





















CREATE PROCEDURE [dbo].[usp_wv_validate_coop_billing] 
@CoopBillingCode VarChar(6)
AS
Set NoCount On
 
If Exists(
Select Distinct BILL_COOP_CODE, BILL_COOP_DESC
FROM BILLING_COOP
WHERE (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
AND BILL_COOP_CODE = @CoopBillingCode
)
	 select 1
Else
	select  0





















