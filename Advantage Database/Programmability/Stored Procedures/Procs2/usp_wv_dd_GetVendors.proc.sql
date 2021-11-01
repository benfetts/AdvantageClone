












/* CHANGE LOG:
==========================================================
ST, 20060609:
Added the "UPPER"  to wrap around @UserID
Done for filtering lookup on job jacket.

*/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetVendors] 
@UserID VarChar(100),
@MagazineInc Char(1),
@NewspaperInc Char(1),
@InternetInc Char(1),
@OutOfHomeInc Char(1),
@TelevisionInc Char(1),
@RadioInc Char(1)
  
AS
Declare @Restrictions Int

CREATE TABLE #vendor_rows( 	
	Code				varchar(6) NULL,
	Description			varchar(250) NULL)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
Where SEC_CLIENT.USER_ID LIKE UPPER(@UserID+'%')

DECLARE @OfficeRestrictions AS INTEGER	
DECLARE @EMP_CODE AS varchar(6)

SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE


if @MagazineInc = 'Y' 
Begin
	If @OfficeRestrictions > 0
	Begin
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'M'
	End
	Else
	Begin 
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'M'
	End
End
	
if @NewspaperInc = 'Y' 
Begin
	If @OfficeRestrictions > 0
	Begin
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'N'
	End
	Else
	Begin 
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'N'	
	End
End
	
if @InternetInc = 'Y' 
Begin
	If @OfficeRestrictions > 0
	Begin
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'I'
	End
	Else
	Begin 
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'I'
	End
End
	
if @OutOfHomeInc = 'Y' 
Begin
	If @OfficeRestrictions > 0
	Begin
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'O'
	End
	Else
	Begin 
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'O'
	End
End
	
if @RadioInc = 'Y' 
Begin
	If @OfficeRestrictions > 0
	Begin
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'R'
	End
	Else
	Begin 
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'R'
	End
End
	
if @TelevisionInc = 'Y' 
Begin
	If @OfficeRestrictions > 0
	Begin
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'T'	
	End
	Else
	Begin 
		INSERT INTO #vendor_rows
		SELECT     VN_CODE AS Code, VN_CODE + ' - ' + isnull(VN_NAME, '')  AS Description
		FROM         VENDOR 
		WHERE     (VN_ACTIVE_FLAG = 1) AND VN_CATEGORY = 'T'
	End
End
	
SELECT * FROM #vendor_rows ORDER BY Code	


DROP TABLE #vendor_rows	















