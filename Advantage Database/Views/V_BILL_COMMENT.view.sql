-- V_BILL_COMMENT
-- #00 08/17/12 - initial version

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO

IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[V_BILL_COMMENT]' ) AND OBJECTPROPERTY( id, N'IsView' ) = 1 )
	DROP VIEW [dbo].[V_BILL_COMMENT]
GO

CREATE VIEW dbo.V_BILL_COMMENT(AR_INV_NBR, AR_INV_SEQ, BILL_COMMENT) 
AS

SELECT 
	bc.AR_INV_NBR,
	bc.AR_INV_SEQ,
	bc.BILL_COMMENT
FROM dbo.BILL_COMMENT AS bc
WHERE bc.BC_ID = (SELECT MAX(bc2.BC_ID) FROM dbo.BILL_COMMENT AS bc2 WHERE bc.AR_INV_NBR = bc2.AR_INV_NBR
	AND bc.AR_INV_SEQ = bc2.AR_INV_SEQ) 

GO

IF ( @@ERROR = 0 )
	GRANT ALL ON [V_BILL_COMMENT] TO PUBLIC AS dbo
GO	
