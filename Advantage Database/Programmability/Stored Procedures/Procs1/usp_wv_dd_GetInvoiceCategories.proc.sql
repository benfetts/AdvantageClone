﻿
























CREATE PROCEDURE [dbo].[usp_wv_dd_GetInvoiceCategories] AS

SELECT INV_CAT as Code, ISNULL(INV_CAT_DESC,'') as Description
FROM INVOICE_CATEGORY
WHERE INACTIVE_FLAG is null or INACTIVE_FLAG = 0






















