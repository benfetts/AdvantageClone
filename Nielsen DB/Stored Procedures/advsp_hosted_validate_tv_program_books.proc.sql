CREATE PROC [dbo].[advsp_hosted_validate_tv_program_books]
AS

UPDATE h SET h.VALIDATED = 1
FROM NIELSENHOSTED.dbo.NIELSEN_TV_PROGRAM_BOOK h
	INNER JOIN NIELSENDATASTORE.dbo.NIELSEN_TV_PROGRAM_BOOK h2 ON h.NIELSEN_TV_PROGRAM_BOOK_ID = h2.NIELSEN_TV_PROGRAM_BOOK_ID 
WHERE h.VALIDATED = 0
AND NIELSENHOSTED.[dbo].[advfn_nielsen_spot_tv_program_rowcount](h.NIELSEN_TV_PROGRAM_BOOK_ID) = NIELSENDATASTORE.[dbo].[advfn_nielsen_spot_tv_program_rowcount](h.NIELSEN_TV_PROGRAM_BOOK_ID)
GO

GRANT EXEC ON [advsp_hosted_validate_tv_program_books] TO PUBLIC
GO