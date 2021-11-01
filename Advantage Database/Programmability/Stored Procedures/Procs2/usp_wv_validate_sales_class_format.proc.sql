






















CREATE PROCEDURE [dbo].[usp_wv_validate_sales_class_format] 
@SalesClassCode VarChar(6),
@SalesClassFormatCode VarChar(8)
AS
Set NoCount On
 
If Exists(
Select Distinct FORMAT_CODE
FROM SC_FORMAT
WHERE ACTIVE = 1
AND FORMAT_CODE = @SalesClassFormatCode
AND SC_CODE = @SalesClassCode
)
	 select 1
Else
	select  0

















