IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetBankDetail]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetBankDetail] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetBankDetail]

@BANK_CODE VARCHAR(4)

AS

BEGIN

SELECT BK_CODE AS BankCode, BK_DESCRIPTION AS BankDescription,  GLACODE_AP_CASH AS BankCashAccount, dbo.[advfn_get_gl_account_desc]([GLACODE_AP_CASH])
AS BankCashAccountDescription, 
GLACODE_AP_DISC AS BankDiscountAccount, dbo.[advfn_get_gl_account_desc]([GLACODE_AP_DISC]) as BankDiscountAccountDescription, BK_LAST_CHECK_COMP AS BankLastCheckCompleted 
FROM BANK WITH ( NOLOCK ) WHERE BK_CODE = @BANK_CODE;

END
GO
