CREATE FUNCTION [dbo].[advfn_ad_server_placement_name](
	@MarketName varchar(40),
	@VendorName varchar(40),
	@RateType varchar(3),
	@Headline  varchar(60),
	@CreativeSizeDescription varchar(60),
	@InternetTypeDescription varchar(30),
	@Placement varchar(160),
	@TargetAudience varchar(60),
	@OrderNumber int,
	@CampaignName varchar(128),
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@URL varchar(60),
	@Instructions varchar(256),
	@MaterialNotes varchar(256),
	@MiscInfo varchar(256)
)
RETURNS varchar(256)
AS
BEGIN
	DECLARE @placement_name varchar(max)
		
	DECLARE @tt TABLE (
		field_name	varchar(60),
		field_data	varchar(256),
		field_order	int
	)
	DECLARE @NumberRecords int, @RowCount int

	IF NOT EXISTS(SELECT FIELD_CODE FROM dbo.AD_SERVER_PLACEMENT_FIELD)
		INSERT @tt (field_name, field_data, field_order)
		SELECT u.field_name, u.field_data, 1
		FROM 
			(
			SELECT
				[Placement] = COALESCE(CAST(@Placement as varchar(256)),'')
			) tablea
		UNPIVOT
		(
			field_data
			for field_name in ([Placement])
		) u
			
	ELSE
		INSERT @tt (field_name, field_data, field_order)
		SELECT u.field_name, u.field_data, b.FIELD_ORDER
		FROM 
			(
			SELECT
				[MarketName] = COALESCE(CAST(@MarketName as varchar(256)),''),
				[VendorName] = COALESCE(CAST(@VendorName as varchar(256)),''),
				[RateType] = COALESCE(CAST(@RateType as varchar(256)),''),
				[Headline] = COALESCE(CAST(@Headline as varchar(256)),	''),
				[CreativeSizeDescription] = COALESCE(CAST(@CreativeSizeDescription as varchar(256)),''),
				[InternetTypeDescription] = COALESCE(CAST(@InternetTypeDescription as varchar(256)),''),
				[Placement] = COALESCE(CAST(@Placement as varchar(256)),''),
				[TargetAudience] = COALESCE(CAST(@TargetAudience as varchar(256)),''),
				[OrderNumber] = COALESCE(CAST(@OrderNumber as varchar(256)),''),
				[Campaign] = COALESCE(CAST(@CampaignName as varchar(256)),''),
				[StartDate] = COALESCE(CONVERT(varchar(256), @StartDate, 101 ), ''),
				[EndDate] = COALESCE(CONVERT(varchar(256), @EndDate, 101 ), ''),
				[URL] = COALESCE(CAST(@URL as varchar(256)),''),
				[Instructions] = COALESCE(CAST(@Instructions as varchar(256)),''),
				[MaterialNotes] = COALESCE(CAST(@MaterialNotes as varchar(256)),''),
				[MiscInfo] = COALESCE(CAST(@MiscInfo as varchar(256)),'')
			) tablea
		UNPIVOT
		(
			field_data
			for field_name in ([MarketName], [VendorName], [RateType], [Headline], [CreativeSizeDescription], [InternetTypeDescription], [Placement], [TargetAudience], [OrderNumber], [Campaign], [StartDate], [EndDate], [URL], [Instructions], [MaterialNotes], [MiscInfo])
		) u
			INNER JOIN dbo.[AD_SERVER_PLACEMENT_FIELD] b on u.field_name = b.FIELD_CODE
	
	SET @NumberRecords = @@ROWCOUNT
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN
		IF @RowCount = 1
			SELECT @placement_name = COALESCE(field_data,' ') FROM @tt WHERE field_order = @RowCount 
		ELSE
			SELECT @placement_name = @placement_name + '_' + COALESCE(field_data,' ') FROM @tt WHERE field_order = @RowCount 
		SET @RowCount = @RowCount + 1
	END

	WHILE SUBSTRING(@placement_name, LEN(@placement_name), 1) = '_'
	BEGIN
		set @placement_name = SUBSTRING(@placement_name, 1, LEN(@placement_name) - 1)
	END

	RETURN SUBSTRING(@placement_name, 1, 256)
END

GO

