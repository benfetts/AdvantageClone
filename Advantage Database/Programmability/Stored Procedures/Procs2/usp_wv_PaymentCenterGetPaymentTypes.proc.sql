IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetPaymentTypes]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetPaymentTypes]
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetPaymentTypes]

AS

BEGIN

    SELECT PAYMENT_TYPE AS Code, PAYMENT_TYPE_DESC AS Description 
	FROM PC_PAYMENT_TYPE WITH (NOLOCK)	
	ORDER BY PAYMENT_TYPE_DESC

END
GO
