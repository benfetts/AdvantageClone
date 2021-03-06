IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetAccounts]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetAccounts] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetAccounts]

AS

BEGIN

SELECT DISTINCT AH.GLACODE AS Code, G.GLADESC AS Description 
FROM AP_HEADER AH, GLACCOUNT G  
WHERE AH.GLACODE = G.GLACODE   ORDER BY AH.GLACODE

END


GO
