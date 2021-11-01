-- V_AR_INVOICE_DUE_DATES
-- #00 08/17/12 - initial version

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO

IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[V_AR_INVOICE_DUE_DATES]' ) AND OBJECTPROPERTY( id, N'IsView' ) = 1 )
	DROP VIEW [dbo].[V_AR_INVOICE_DUE_DATES]
GO

CREATE VIEW dbo.V_AR_INVOICE_DUE_DATES
AS

	SELECT	
		a.AR_INV_NBR, 
		a.AR_TYPE, 
		a.AR_INV_DATE,
		CASE
			WHEN a.DUE_DATE IS NOT NULL THEN a.DUE_DATE
			WHEN a.DUE_DATE IS NULL AND a.REC_TYPE IN ( 'P','S' ) THEN DATEADD( Day,ISNULL( c.CL_P_PAYDAYS, 0 ), a.AR_INV_DATE )
			ELSE DATEADD( Day, ISNULL( c.CL_M_PAYDAYS, 0 ), a.AR_INV_DATE )
		END	AS AR_INV_DUE_DATE,
		a.AR_POST_PERIOD, 
		a.INV_CAT, 
		cat.INV_CAT_DESC
	FROM dbo.ACCT_REC AS a
	JOIN dbo.CLIENT AS c
	 ON a.CL_CODE = c.CL_CODE
	LEFT JOIN dbo.INVOICE_CATEGORY AS cat
	 ON a.INV_CAT = cat.INV_CAT	
	WHERE a.AR_TYPE = 'IN' 
	AND a.AR_INV_SEQ IN( 0, 99 )

GO

IF ( @@ERROR = 0 )
	GRANT ALL ON [V_AR_INVOICE_DUE_DATES] TO PUBLIC AS dbo
GO	

