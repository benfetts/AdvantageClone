




















CREATE PROCEDURE [dbo].[usp_wv_required_product_category] 
@Client VarChar(6)
AS

If Exists(Select CL_CODE
From CLIENT WITH (NOLOCK)
Where CL_CODE = @Client
AND REQ_PROD_CAT = 1)

Select 1
Else
Select 0




















