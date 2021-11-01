


















/*---------------------------------------------------------------------------- */
/*CTB-2006/06/20: Created SP to validate account number added to Job Component */
/*---------------------------------------------------------------------------- */
CREATE PROCEDURE [dbo].[usp_wv_validate_jc_account_number]
@AccountNumber As VARCHAR(30) AS

If Exists( SELECT ACCT_NBR 
             FROM ACCT_NUMBER
            WHERE (ACTIVE   = 1) AND 
                   ACCT_NBR = @AccountNumber 
         )
   SELECT 1
Else
   SELECT 0


















