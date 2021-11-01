

CREATE PROCEDURE [dbo].[usp_wv_dd_GetVendorsByDefaultFunc] 
@FunctionCode varchar(6),
@IncludeMedia smallint,
@UserCode varchar(100)
AS


Set NoCount On

DECLARE @OfficeRestrictions AS INTEGER	
DECLARE @EMP_CODE AS varchar(6)

SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserCode)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

if @IncludeMedia = 1
Begin
	If @OfficeRestrictions > 0
	Begin
		select VN_CODE as Code, VN_CODE + ' - ' + VN_NAME as [Description] 
		from VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		 where VN_ACTIVE_FLAG=1 and DEF_FNC_CODE = @FunctionCode
		order by VN_CODE
	End
	Else
	Begin 
		select VN_CODE as Code, VN_CODE + ' - ' + VN_NAME as [Description] 
		from VENDOR
		  where VN_ACTIVE_FLAG=1 and DEF_FNC_CODE = @FunctionCode
		order by VN_CODE
	End
	
End
Else
Begin
	If @OfficeRestrictions > 0
	Begin
		select VN_CODE as Code, VN_CODE + ' - ' + VN_NAME as [Description] 
		from VENDOR INNER JOIN
			 EMP_OFFICE ON VENDOR.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		 where VN_ACTIVE_FLAG=1 and VN_CATEGORY = 'P' and DEF_FNC_CODE = @FunctionCode
	   order by VN_CODE
	End
	Else
	Begin 
		select VN_CODE as Code, VN_CODE + ' - ' + VN_NAME as [Description] 
		from VENDOR
		  where VN_ACTIVE_FLAG=1 and VN_CATEGORY = 'P' and DEF_FNC_CODE = @FunctionCode
		order by VN_CODE
	End
	
End





