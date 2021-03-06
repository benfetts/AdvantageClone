SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO

IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[V_AR_ADDRESS_TABLE_PROD]' ) AND OBJECTPROPERTY( id, N'IsView' ) = 1 )
	DROP VIEW [dbo].[V_AR_ADDRESS_TABLE_PROD]
GO

CREATE VIEW dbo.V_AR_ADDRESS_TABLE_PROD([USER_ID], APP_TYPE, CL_CODE, DIV_CODE, PRD_CODE, PRD_CONTACT, CL_NAME, DIV_NAME, PRD_DESCRIPTION, ADDRESS1, ADDRESS2,
	CITY, [STATE], ZIP, ATTENTION, COUNTY, COUNTRY, CDP_CONTACT_ID) 
AS

-- ===================================================================
-- V_AR_ADDRESS_TABLE_PROD
-- #00 08/17/12 - initial version
-- #01 09/01/12 - removed CDP contact info and substituted join to RPT_SEL_NBRS for PROD_INV_DEF
-- #02 05/08/13 - substituted V_PROD_INV_DEF for RPT_RUNTIME_SPECS (incorrect)
-- #03 07/27/13 - added contact addresses
-- #04 04/29/14 - WHEN ADDRESS_BLOCK = 4 info for product data
-- ===================================================================

	SELECT DISTINCT
		s.[USER_ID],
		'PI' AS APP_TYPE,
		cl.CL_CODE, 
		dv.DIV_CODE,
		pr.PRD_CODE,
		'ZZ',
		cl.CL_NAME,
		CASE
			WHEN (cl.CL_NAME = dv.DIV_NAME) THEN NULL
			ELSE dv.DIV_NAME
		END,	
		CASE
			WHEN (dv.DIV_NAME = pr.PRD_DESCRIPTION) THEN NULL
			ELSE pr.PRD_DESCRIPTION
		END,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BADDRESS1
			WHEN 2 THEN dv.DIV_BADDRESS1
			WHEN 3 THEN pr.PRD_BILL_ADDRESS1
			WHEN 4 THEN pr.PRD_BILL_ADDRESS1				--#4
		END,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BADDRESS2
			WHEN 2 THEN dv.DIV_BADDRESS2
			WHEN 3 THEN pr.PRD_BILL_ADDRESS2
			WHEN 4 THEN pr.PRD_BILL_ADDRESS2				--#4
		END,
		CASE s.ADDRESS_BLOCK
			WHEN 1 THEN cl.CL_BCITY
			WHEN 2 THEN dv.DIV_BCITY
			WHEN 3 THEN pr.PRD_BILL_CITY
			WHEN 4 THEN pr.PRD_BILL_CITY					--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BSTATE
			WHEN 2 THEN dv.DIV_BSTATE
			WHEN 3 THEN pr.PRD_BILL_STATE
			WHEN 4 THEN pr.PRD_BILL_STATE					--#4
		END,
		CASE s.ADDRESS_BLOCK		
			WHEN 1 THEN cl.CL_BZIP
			WHEN 2 THEN dv.DIV_BZIP
			WHEN 3 THEN pr.PRD_BILL_ZIP
			WHEN 4 THEN pr.PRD_BILL_ZIP						--#4
		END,
		CASE s.ADDRESS_BLOCK	
			WHEN 1 THEN cl.CL_ATTENTION
			WHEN 2 THEN dv.DIV_ATTENTION
			WHEN 3 THEN pr.PRD_ATTENTION
			WHEN 4 THEN pr.PRD_ATTENTION					--#4
		END,
		CASE s.ADDRESS_BLOCK	
			WHEN 1 THEN cl.CL_BCOUNTY
			WHEN 2 THEN dv.DIV_BCOUNTY
			WHEN 3 THEN pr.PRD_BILL_COUNTY
			WHEN 4 THEN pr.PRD_BILL_COUNTY					--#4
		END,
		CASE s.ADDRESS_BLOCK	
			WHEN 1 THEN cl.CL_BCOUNTRY
			WHEN 2 THEN dv.DIV_BCOUNTRY
			WHEN 3 THEN pr.PRD_BILL_COUNTRY
			WHEN 4 THEN pr.PRD_BILL_COUNTRY					--#4
		END,
		0	
	FROM dbo.V_PROD_INV_DEF AS s
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
	FROM dbo.V_PROD_INV_DEF AS s	
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
	FROM dbo.V_PROD_INV_DEF AS s	
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
	FROM dbo.V_PROD_INV_DEF AS s	
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

IF ( @@ERROR = 0 )
	GRANT ALL ON [V_AR_ADDRESS_TABLE_PROD] TO PUBLIC AS dbo
GO	

