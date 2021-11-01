




















CREATE PROCEDURE [dbo].[usp_wv_visible_product_category] 
AS

Declare @ThisReturn as integer

Select @ThisReturn = 0

Select @ThisReturn = USE_PROD_CAT 
FROM AGENCY WITH (NOLOCK)
Where USE_PROD_CAT is not null

Select @ThisReturn




















