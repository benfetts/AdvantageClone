IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_api_load_ar_stmt_product_contacts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_api_load_ar_stmt_product_contacts]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_api_load_ar_stmt_product_contacts] 
		@cl_code varchar(6), @client_level_only_contacts bit, @LoadInactive bit
AS

/* API - LoadARStmtProductContacts - Test Call "EXEC [dbo].[advsp_api_load_ar_stmt_product_contacts] '*', 1, 0" */

SET @cl_code = ISNULL(@cl_code, '')

DECLARE @list TABLE (
	ContactID int,
	SeqNumber int, 
	ClientCode varchar (6),
	DivisionCode varchar (6), 
	ProductCode varchar (6),
	ContactCode varchar (6),
	PoductARContact bit,
	ClientContactIsInactive bit
)

IF @cl_code = '' OR @cl_code IS NULL BEGIN

	SET @cl_code = '*'

END

IF @client_level_only_contacts = 1 BEGIN

	INSERT INTO @list
	SELECT	ContactID = A.CDP_CONTACT_ID,
			SeqNumber = B.SEQ_NBR, 
			ClientCode = A.CL_CODE,
			DivisionCode = B.DIV_CODE, 
			ProductCode = B.PRD_CODE,
			ContactCode = A.CONT_CODE,
			PoductARContact = 0,
			ClientContactIsInactive = A.INACTIVE_FLAG
	FROM CDP_CONTACT_HDR A LEFT JOIN
		CDP_CONTACT_DTL B ON A.CDP_CONTACT_ID = B.CDP_CONTACT_ID
	WHERE B.CDP_CONTACT_ID IS NULL AND 
			(A.INACTIVE_FLAG = @LoadInactive OR @LoadInactive = 1) AND
			(A.CL_CODE = @cl_code OR @cl_code = '*')

END
ELSE BEGIN

	INSERT INTO @list
	SELECT	ContactID = A.CDP_CONTACT_ID,
			SeqNumber = B.SEQ_NBR, 
			ClientCode = A.CL_CODE,
			DivisionCode = B.DIV_CODE, 
			ProductCode = B.PRD_CODE,
			ContactCode = A.CONT_CODE,
			PoductARContact = 0,
			ClientContactIsInactive = A.INACTIVE_FLAG
	FROM CDP_CONTACT_HDR A JOIN
		CDP_CONTACT_DTL B ON A.CDP_CONTACT_ID = B.CDP_CONTACT_ID
	WHERE 	(A.INACTIVE_FLAG = @LoadInactive OR @LoadInactive = 1) AND
			(A.CL_CODE = @cl_code OR @cl_code = '*')
	UNION
	SELECT	ContactID = A.CDP_CONTACT_ID,
			SeqNumber = 0, 
			ClientCode = A.CL_CODE,
			DivisionCode = NULL, 
			ProductCode = NULL,
			ContactCode = A.CONT_CODE,
			PoductARContact = 0,
			ClientContactIsInactive = A.INACTIVE_FLAG
	FROM CDP_CONTACT_HDR A 
	WHERE (A.INACTIVE_FLAG = @LoadInactive OR @LoadInactive = 1) AND
			(A.CL_CODE = @cl_code OR @cl_code = '*') AND
			A.CDP_CONTACT_ID NOT IN (SELECT CDP_CONTACT_ID FROM CDP_CONTACT_DTL)

END

UPDATE A
SET A.PoductARContact = B.Flag
FROM @list A
    INNER JOIN (SELECT
		ContactID,
		SeqNumber, 
		ClientCode,
		DivisionCode, 
		ProductCode,
		ContactCode,
		Flag = 1
FROM @list A JOIN
	PRODUCT_AR_STMT B ON A.ContactID = B.CDP_CONTACT_ID 
						AND A.ClientCode = B.CL_CODE  
						AND A.DivisionCode = B.DIV_CODE  
						AND A.ProductCode = B.PRD_CODE) B ON	A.ContactID = B.ContactID 
																AND A.ClientCode = B.ClientCode  
																AND A.DivisionCode = B.DivisionCode  
																AND A.ProductCode = B.ProductCode

SELECT 	ContactID,
		SeqNumber, 
		ClientCode,
		DivisionCode, 
		ProductCode,
		ContactCode, 
		PoductARContact,
		ClientContactIsInactive
FROM @list

GRANT EXECUTE ON [advsp_api_load_ar_stmt_product_contacts] TO PUBLIC AS dbo
GO