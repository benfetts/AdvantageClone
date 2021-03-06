IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_expense_get_receipts]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_expense_get_receipts]
GO
CREATE PROCEDURE [dbo].[advsp_expense_get_receipts] /*WITH ENCRYPTION*/
@INV_NBR INT
AS
/*=========== QUERY ===========*/
BEGIN

	SELECT
		A.DOCUMENT_ID
	FROM
		(
			SELECT
				D.DOCUMENT_ID, D.UPLOADED_DATE, 1 AS IS_HEADER_ONLY
			FROM
				EXPENSE_DOCS ED WITH(NOLOCK)
				INNER JOIN DOCUMENTS D WITH(NOLOCK) ON ED.DOCUMENT_ID = D.DOCUMENT_ID
			WHERE
				INV_NBR = @INV_NBR
				AND D.DOCUMENT_ID NOT IN (
					SELECT
						EDD.DOCUMENT_ID
					FROM
						EXPENSE_DETAIL_DOCS EDD WITH(NOLOCK)
						INNER JOIN EXPENSE_DETAIL ED WITH(NOLOCK) ON ED.EXPDETAILID = EDD.EXPDETAILID
					WHERE
						INV_NBR = @INV_NBR
				)
			UNION
			SELECT
				D.DOCUMENT_ID, D.UPLOADED_DATE, 0 AS IS_HEADER_ONLY
			FROM
				EXPENSE_DETAIL_DOCS EDD WITH(NOLOCK)
				INNER JOIN EXPENSE_DETAIL ED WITH(NOLOCK) ON ED.EXPDETAILID = EDD.EXPDETAILID
				INNER JOIN DOCUMENTS D WITH(NOLOCK) ON EDD.DOCUMENT_ID = D.DOCUMENT_ID
			WHERE
				INV_NBR = @INV_NBR
		) AS A
	ORDER BY
		A.IS_HEADER_ONLY DESC, A.UPLOADED_DATE;

END
/*=========== QUERY ===========*/
