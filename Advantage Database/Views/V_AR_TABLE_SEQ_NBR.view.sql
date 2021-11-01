-- V_AR_TABLE_SEQ_NBR
-- #00 08/17/12 - initial version

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO

IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[V_AR_TABLE_SEQ_NBR]' ) AND OBJECTPROPERTY( id, N'IsView' ) = 1 )
	DROP VIEW [dbo].[V_AR_TABLE_SEQ_NBR]
GO

CREATE VIEW dbo.V_AR_TABLE_SEQ_NBR
AS

SELECT DISTINCT
		ar.AR_INV_NBR,
		CONVERT( varchar(12), ar.AR_INV_NBR ) AS AR_INV_NBR_STR, 
		ar.AR_INV_SEQ, 
		ar.AR_TYPE,
		CASE
			WHEN s.ADDRESS_BLOCK <> 4 OR ar.AR_INV_SEQ <> 0 THEN ar.CL_CODE		--ACCT_REC.CL_CODE is NOT NULL  or CO-OP
			ELSE jl.CL_CODE														--ADDRESS_BLOCK = 4
		END AS CL_CODE,
		CASE 
			WHEN s.ADDRESS_BLOCK <> 4 OR ar.AR_INV_SEQ <> 0 THEN COALESCE(ar.DIV_CODE, 'ZZ')
			--WHEN s.ADDRESS_BLOCK = 4 AND ar.AR_INV_SEQ = 0 THEN 'ZZ'
			ELSE 'ZZ'
		END AS DIV_CODE,
		CASE
			WHEN s.ADDRESS_BLOCK <> 4 OR ar.AR_INV_SEQ <> 0 THEN COALESCE(ar.PRD_CODE, 'ZZ')
			--WHEN s.ADDRESS_BLOCK = 4 AND ar.AR_INV_SEQ = 0 THEN 'ZZ'
			ELSE 'ZZ'
		END AS PRD_CODE,
		CASE
			WHEN s.ADDRESS_BLOCK <> 4 OR ar.AR_INV_SEQ <> 0 THEN 'ZZ' 
			--WHEN s.ADDRESS_BLOCK = 4 AND ar.AR_INV_SEQ = 0 THEN COALESCE(jc.PRD_CONT_CODE, 'ZZ')
			ELSE COALESCE(jc.PRD_CONT_CODE, 'ZZ')
		END AS PRD_CONT_CODE,
		CASE 
			WHEN s.ADDRESS_BLOCK <> 4 OR ar.AR_INV_SEQ <> 0 THEN 0
			WHEN s.ADDRESS_BLOCK = 4 AND ar.AR_INV_SEQ = 0 THEN COALESCE(jc.CDP_CONTACT_ID, 0)
			ELSE COALESCE(jc.CDP_CONTACT_ID, 0)
		END AS CDP_CONTACT_ID,
		s.ADDRESS_BLOCK
	FROM dbo.ACCT_REC ar 
	JOIN V_AR_INV_MIN_JOB mj 
		ON ar.AR_INV_NBR = mj.AR_INV_NBR 
	JOIN dbo.JOB_COMPONENT jc 
		ON mj.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		AND mj.JOB_NUMBER = jc.JOB_NUMBER 
	JOIN dbo.JOB_LOG jl 
		ON jc.JOB_NUMBER = jl.JOB_NUMBER
	LEFT JOIN V_PROD_INV_DEF s
		ON ar.CL_CODE = s.CL_CODE 
	--LEFT JOIN dbo.advtf_prod_inv_def() s2
	--	ON jl.CL_CODE = s2.CL_CODE			
	WHERE ISNULL(ar.MANUAL_INV,0) = 0 AND ar.AR_TYPE = 'IN'

GO

IF ( @@ERROR = 0 )
	GRANT ALL ON [V_AR_TABLE_SEQ_NBR] TO PUBLIC AS dbo
GO	

