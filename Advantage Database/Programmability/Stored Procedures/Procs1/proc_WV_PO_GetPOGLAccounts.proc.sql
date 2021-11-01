





CREATE PROCEDURE [dbo].[proc_WV_PO_GetPOGLAccounts] 
@EmpCode varchar(6)
AS
DECLARE @POGLAccountByOffice int, @EmpDefOffice varchar(4)

Select @POGLAccountByOffice = ISNULL(PO_GL_LIMIT_BY_OFFICE,0), @EmpDefOffice = ISNULL(OFFICE_CODE,'')
FROM EMPLOYEE
WHERE EMP_CODE = @EmpCode

if @POGLAccountByOffice = 1
Begin
	if @EmpDefOffice <> ''
		Begin
			SELECT     GLACCOUNT.GLACODE as code, GLACCOUNT.GLACODE + '-' + GLACCOUNT.GLADESC as description
			FROM       GLACCOUNT INNER JOIN
                       GLOXREF ON GLACCOUNT.GLAOFFICE = GLOXREF.GLOXGLOFFICE
			WHERE      GLACCOUNT.GLPO = 1 AND GLACCOUNT.GLAACTIVE = 'A' AND GLOXREF.GLOXOFFICE = @EmpDefOffice
		End	
End
Else
Begin
	SELECT     GLACODE as code, GLACODE + '-' + GLADESC as description
	FROM       GLACCOUNT
	WHERE      GLPO = 1 AND GLAACTIVE = 'A'
End























