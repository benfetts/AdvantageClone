CREATE PROCEDURE [dbo].[advsp_ap_export_custom1_mark_as_exported]

	@ap_id_list varchar(max)

AS

BEGIN

	INSERT INTO dbo.AP_EXPORTED
	SELECT *, CONVERT(char(10), getdate(), 101)
	FROM dbo.udf_split_list(@ap_id_list, ',')

END

GO
