IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_yaypay_customer_export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_yaypay_customer_export]
GO

CREATE PROCEDURE [dbo].[advsp_yaypay_customer_export] 

AS
--Stored procedure to export customer data

BEGIN

	SELECT
		[internalId] = P.CL_CODE + ISNULL(P.DIV_CODE,'') + ISNULL(P.PRD_CODE,''),
		[status] = CASE WHEN ISNULL(P.ACTIVE_FLAG, 0) = 1 THEN 'Active' ELSE 'Inactive' END,
		[companyName] = P.PRD_DESCRIPTION,
		[email] = '',
		[phone] = '',
		[altPhone] = '',
		[webAddress] = '',
		[creditLimit] = ISNULL(C.CL_CREDIT_LIMIT,0),
		[terms] = ISNULL(C.CL_FOOTER,''),
		[parentId] = '',
		[balance] = CAST(0 AS decimal),
		[currency] = 'USD',
		[country] = ISNULL(P.PRD_BILL_COUNTRY,''),
		[city] = ISNULL(P.PRD_BILL_CITY,''),
		[state] = ISNULL(P.PRD_BILL_STATE,''),
		[zip] = ISNULL(P.PRD_BILL_ZIP,''),
		[line_1] = ISNULL(P.PRD_BILL_ADDRESS1,''),
		[line_2] = ISNULL(P.PRD_BILL_ADDRESS2,''),
		[customFields] = '',
		[is_deleted] = '',
		[salesRepEmail] = '',
		[customerSuccessEmail] = '',
		[arManagerEmail] = ''
	FROM PRODUCT P INNER JOIN
		 DIVISION D ON D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE INNER JOIN
		 CLIENT C ON C.CL_CODE = D.CL_CODE
	

END
GO

GRANT ALL ON [advsp_yaypay_customer_export] TO PUBLIC AS dbo
GO