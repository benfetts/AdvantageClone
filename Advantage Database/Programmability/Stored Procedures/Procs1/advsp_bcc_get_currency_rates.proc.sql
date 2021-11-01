CREATE PROCEDURE advsp_bcc_get_currency_rates
	@billing_user varchar(100)
AS

DECLARE @CurrencyCodeComparison varchar(5)

SELECT @CurrencyCodeComparison = HOME_CRNCY
FROM dbo.AGENCY

SELECT DISTINCT CurrencyCode = b.CURRENCY_CODE,
				CurrencyCodes = @CurrencyCodeComparison + ' to ' + b.CURRENCY_CODE,
				CurrencyRate = b.CURRENCY_RATE,
				CurrencyCodeComparison = @CurrencyCodeComparison,
				LastestUpdatedDate = cd.EXCHANGE_DATE,
				LastestUpdatedRate = cd.RECIPROCAL_EXCHANGE_RATE  
FROM dbo.W_AR_FUNCTION b
	LEFT OUTER JOIN (
					SELECT cd.*
					FROM CURRENCY_DETAIL cd
					INNER JOIN
						(
						SELECT CURRENCY_CODE, CURRENCY_CODE_COMPARISON, MAX(EXCHANGE_DATE) AS EXCHANGE_DATE
						FROM CURRENCY_DETAIL
						GROUP BY CURRENCY_CODE, CURRENCY_CODE_COMPARISON
						) groupedcd ON cd.CURRENCY_CODE = groupedcd.CURRENCY_CODE 
									AND cd.CURRENCY_CODE_COMPARISON = groupedcd.CURRENCY_CODE_COMPARISON 
									AND cd.EXCHANGE_DATE = groupedcd.EXCHANGE_DATE 
					) cd ON b.CURRENCY_CODE = cd.CURRENCY_CODE AND cd.CURRENCY_CODE_COMPARISON = @CurrencyCodeComparison 
WHERE BILLING_USER = @billing_user
AND b.CURRENCY_CODE IS NOT NULL
GO