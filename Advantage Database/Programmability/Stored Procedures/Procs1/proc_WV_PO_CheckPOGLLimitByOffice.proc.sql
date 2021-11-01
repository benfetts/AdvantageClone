





CREATE PROCEDURE [dbo].[proc_WV_PO_CheckPOGLLimitByOffice] 
@EmpCode varchar(6),
@GlaCode varchar(30)
AS
DECLARE @POGLAccountByOffice int, @EmpDefOffice varchar(4)

Select @POGLAccountByOffice = ISNULL(PO_GL_LIMIT_BY_OFFICE,0), @EmpDefOffice = ISNULL(OFFICE_CODE,'')
FROM EMPLOYEE
WHERE EMP_CODE = @EmpCode

if @POGLAccountByOffice = 1
Begin
	if @EmpDefOffice <> ''
		Begin
			if exists(SELECT     GLACCOUNT.GLACODE as code, GLACCOUNT.GLACODE + '-' + GLACCOUNT.GLADESC as description
						FROM       GLACCOUNT INNER JOIN
								   GLOXREF ON GLACCOUNT.GLAOFFICE = GLOXREF.GLOXGLOFFICE
						WHERE      GLACCOUNT.GLPO = 1 AND GLACCOUNT.GLAACTIVE = 'A' AND GLACCOUNT.GLACODE = @GlaCode AND GLOXREF.GLOXOFFICE = @EmpDefOffice)
				SELECT 1
			else
				Begin
				SELECT 0
				End
		End	
	Else
		Begin
			SELECT 0
		End
End
Else
Begin
	SELECT 1
End





















