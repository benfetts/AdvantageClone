IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetBaseCheckNumbersByPaymentType]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetBaseCheckNumbersByPaymentType] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetBaseCheckNumbersByPaymentType]

@BANK_CODE AS VARCHAR(4)

AS

BEGIN

SELECT PAYMENT_TYPE AS Code, 
	@BANK_CODE AS BANK_CODE, [dbo].udf_get_next_check_nbr (@BANK_CODE, PAYMENT_TYPE, 'EXT') AS BaseCheckNumber
FROM PC_PAYMENT_TYPE WITH (NOLOCK)

END
