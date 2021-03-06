CREATE VIEW dbo.V_AP_MEDIA_OOH
WITH SCHEMABINDING
AS
SELECT AP_ID, ORDER_NBR, ORDER_LINE_NBR
FROM dbo.AP_OUTDOOR AA
GROUP BY AP_ID, ORDER_NBR, ORDER_LINE_NBR
HAVING SUM(COALESCE(NET_AMT, 0.00)) + SUM(COALESCE(VENDOR_TAX, 0.00)) + SUM(COALESCE(NETCHARGES, 0.00)) <> 0 