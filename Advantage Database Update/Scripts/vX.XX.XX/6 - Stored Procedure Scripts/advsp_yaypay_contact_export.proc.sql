IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_yaypay_contact_export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_yaypay_contact_export]
GO

CREATE PROCEDURE [dbo].[advsp_yaypay_contact_export] 

AS
--Stored procedure to export customer data

BEGIN

	SELECT
		[internalId] = '',
        [customerId] = '',
		[firstName] = '',
		[lastName] = '',
		[altPhone] = '',
		[email] = '',
		[phone] = '',
		[mobilePhone] = '',
		[primary] = ''
	FROM
		(SELECT 
			[ID] = NULL) AS A
	WHERE
		A.[ID] IS NOT NULL

END
GO

GRANT ALL ON [advsp_yaypay_contact_export] TO PUBLIC AS dbo
GO