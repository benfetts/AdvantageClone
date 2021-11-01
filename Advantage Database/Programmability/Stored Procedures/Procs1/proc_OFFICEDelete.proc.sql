



























CREATE PROCEDURE [dbo].[proc_OFFICEDelete]
(
	@OFFICE_CODE varchar(4)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [OFFICE]
	WHERE
		[OFFICE_CODE] = @OFFICE_CODE
	SET @Err = @@Error

	RETURN @Err
END



























