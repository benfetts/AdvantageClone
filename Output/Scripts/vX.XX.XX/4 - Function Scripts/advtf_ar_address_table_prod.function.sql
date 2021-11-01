IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advtf_ar_address_table_prod]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advtf_ar_address_table_prod]
END
GO

CREATE FUNCTION [dbo].[advtf_ar_address_table_prod] 
	(@user_id varchar(100) = NULL)
	RETURNS Table
AS

-- =====================================================================
-- V_AR_ADDRESS_TABLE_PROD
-- =====================================================================

--SELECT * FROM V_MEDIA_INV_DEF

RETURN
	SELECT DISTINCT
		s.[USER_ID],
		'PI' AS APP_TYPE,
		cl.CL_CODE, 
		dv.DIV_CODE,
		pr.PRD_CODE,
		'ZZ' PRD_CONTACT,
		cl.CL_NAME,
		CASE
			WHEN (cl.CL_NAME = dv.DIV_NAME) THEN NULL
			ELSE dv.DIV_NAME
		END DIV_NAME,	
		CASE
			WHEN (dv.DIV_NAME = pr.PRD_DESCRIPTION) THEN NULL
			ELSE pr.PRD_DESCRIPTION
		END PRD_DESCRIPTION,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BADDRESS1
			WHEN 2 THEN dv.DIV_BADDRESS1
			WHEN 3 THEN pr.PRD_BILL_ADDRESS1
			WHEN 4 THEN pr.PRD_BILL_ADDRESS1				--#4
		END ADDRESS1,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BADDRESS2
			WHEN 2 THEN dv.DIV_BADDRESS2
			WHEN 3 THEN pr.PRD_BILL_ADDRESS2
			WHEN 4 THEN pr.PRD_BILL_ADDRESS2				--#4
		END ADDRESS2,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BCITY
			WHEN 2 THEN dv.DIV_BCITY
			WHEN 3 THEN pr.PRD_BILL_CITY
			WHEN 4 THEN pr.PRD_BILL_CITY					--#4
		END CITY,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BSTATE
			WHEN 2 THEN dv.DIV_BSTATE
			WHEN 3 THEN pr.PRD_BILL_STATE
			WHEN 4 THEN pr.PRD_BILL_STATE					--#4
		END STATE,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BZIP
			WHEN 2 THEN dv.DIV_BZIP
			WHEN 3 THEN pr.PRD_BILL_ZIP
			WHEN 4 THEN pr.PRD_BILL_ZIP						--#4
		END ZIP,
		CASE s.ADDRESS_BLOCK	
			WHEN 1 THEN cl.CL_ATTENTION
			WHEN 2 THEN dv.DIV_ATTENTION
			WHEN 3 THEN pr.PRD_ATTENTION
			WHEN 4 THEN pr.PRD_ATTENTION					--#4
		END ATTENTION,
		CASE s.ADDRESS_BLOCK	
			WHEN 1 THEN cl.CL_BCOUNTY
			WHEN 2 THEN dv.DIV_BCOUNTY
			WHEN 3 THEN pr.PRD_BILL_COUNTY
			WHEN 4 THEN pr.PRD_BILL_COUNTY					--#4
		END COUNTY,
		CASE s.ADDRESS_BLOCK	
			WHEN 1 THEN cl.CL_BCOUNTRY
			WHEN 2 THEN dv.DIV_BCOUNTRY
			WHEN 3 THEN pr.PRD_BILL_COUNTRY
			WHEN 4 THEN pr.PRD_BILL_COUNTRY					--#4
		END COUNTRY,
		0 CDP_CONTACT_ID	
	FROM [dbo].[advtf_ar_prod_inv_def](@user_id) AS s
	JOIN dbo.CLIENT AS cl 
		ON s.CL_CODE = cl.CL_CODE
	JOIN dbo.DIVISION AS dv
		ON ( cl.CL_CODE = dv.CL_CODE )
	JOIN dbo.PRODUCT AS pr
		ON ( dv.DIV_CODE = pr.DIV_CODE )  
		AND ( dv.CL_CODE = pr.CL_CODE )

	-- When product code is NULL
	UNION ALL SELECT DISTINCT
		s.[USER_ID],
		'PI' AS APP_TYPE,
		cl.CL_CODE,		
		dv.DIV_CODE,
		'ZZ',
		'ZZ',
		cl.CL_NAME,
		CASE
			WHEN (cl.CL_NAME = dv.DIV_NAME) THEN NULL
			ELSE dv.DIV_NAME
		END,
		NULL,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BADDRESS1
			WHEN 2 THEN dv.DIV_BADDRESS1
			WHEN 3 THEN dv.DIV_BADDRESS1
			WHEN 4 THEN dv.DIV_BADDRESS1					--#4
		END,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BADDRESS2
			WHEN 2 THEN dv.DIV_BADDRESS2
			WHEN 3 THEN dv.DIV_BADDRESS2
			WHEN 4 THEN dv.DIV_BADDRESS2					--#4
		END,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BCITY
			WHEN 2 THEN dv.DIV_BCITY
			WHEN 3 THEN dv.DIV_BCITY
			WHEN 4 THEN dv.DIV_BCITY						--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BSTATE
			WHEN 2 THEN dv.DIV_BSTATE
			WHEN 3 THEN dv.DIV_BSTATE
			WHEN 4 THEN dv.DIV_BSTATE						--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BZIP
			WHEN 2 THEN dv.DIV_BZIP
			WHEN 3 THEN dv.DIV_BZIP
			WHEN 4 THEN dv.DIV_BZIP							--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_ATTENTION
			WHEN 2 THEN dv.DIV_ATTENTION
			WHEN 3 THEN dv.DIV_ATTENTION
			WHEN 4 THEN dv.DIV_ATTENTION					--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BCOUNTY
			WHEN 2 THEN dv.DIV_BCOUNTY
			WHEN 3 THEN dv.DIV_BCOUNTY
			WHEN 4 THEN dv.DIV_BCOUNTY						--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BCOUNTRY
			WHEN 2 THEN dv.DIV_BCOUNTRY
			WHEN 3 THEN dv.DIV_BCOUNTRY
			WHEN 4 THEN dv.DIV_BCOUNTRY						--#4
		END,
		0
	FROM [dbo].[advtf_ar_prod_inv_def](@user_id) AS s	
	JOIN dbo.CLIENT AS cl 
		ON s.CL_CODE = cl.CL_CODE
	JOIN dbo.DIVISION AS dv
	   ON ( cl.CL_CODE = dv.CL_CODE )
		
	-- When division and product code are both NULL
	UNION ALL SELECT DISTINCT
		s.[USER_ID],
		'PI' AS APP_TYPE,
		cl.CL_CODE,
		'ZZ',
		'ZZ',
		'ZZ',
		cl.CL_NAME,
		NULL,
		NULL,
		cl.CL_BADDRESS1,
		cl.CL_BADDRESS2,
		cl.CL_BCITY,
		cl.CL_BSTATE,
		cl.CL_BZIP,
		cl.CL_ATTENTION,
		cl.CL_BCOUNTY,
		cl.CL_BCOUNTRY,
		0
	FROM [dbo].[advtf_ar_prod_inv_def](@user_id) AS s	
	JOIN dbo.CLIENT AS cl 
		ON s.CL_CODE = cl.CL_CODE
	
	--Contact addresses			--#03
	UNION ALL SELECT DISTINCT
		s.[USER_ID],
		'PI' AS APP_TYPE,
		cl.CL_CODE,
		dv.DIV_CODE,
		pr.PRD_CODE,
		ch.CONT_CODE,
		cl.CL_NAME, 
		--NULL,
		--NULL,
		CASE
			WHEN (cl.CL_NAME = dv.DIV_NAME) THEN NULL
			ELSE dv.DIV_NAME
		END,	
		CASE
			WHEN (dv.DIV_NAME = pr.PRD_DESCRIPTION) THEN NULL
			ELSE pr.PRD_DESCRIPTION
		END,
		ch.CONT_ADDRESS1,
		ch.CONT_ADDRESS2,
		ch.CONT_CITY,
		ch.CONT_STATE,
		ch.CONT_ZIP,
		ch.CONT_FML,
		ch.CONT_COUNTY,
		ch.CONT_COUNTRY,
		ch.CDP_CONTACT_ID
	FROM [dbo].[advtf_ar_prod_inv_def](@user_id) AS s	
	JOIN dbo.CDP_CONTACT_HDR ch
		ON s.CL_CODE = ch.CL_CODE
	JOIN dbo.CLIENT AS cl
		ON s.CL_CODE = cl.CL_CODE	
	JOIN dbo.DIVISION AS dv
		ON ( ch.CL_CODE = dv.CL_CODE )
	JOIN dbo.PRODUCT AS pr
		ON ( dv.CL_CODE = pr.CL_CODE )  
		AND ( dv.DIV_CODE = pr.DIV_CODE ) 
GO


GRANT SELECT ON [advtf_ar_address_table_prod] TO PUBLIC
GO