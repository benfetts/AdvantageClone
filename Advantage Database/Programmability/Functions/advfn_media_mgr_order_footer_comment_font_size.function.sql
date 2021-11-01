CREATE FUNCTION [dbo].[advfn_media_mgr_order_footer_comment_font_size](
	@office_code varchar(6),			--'o'
	@client_code varchar(6),			--'c'
	@division_code varchar(6),			--'d'
	@product_code varchar(6),			--'p'
	@vn_code varchar(6),				--'v'
	@media_type varchar(1)				--'m'
)
RETURNS smallint
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @app_code varchar(50),
			@comment_type varchar(50),
			@std_font_size smallint
	
	DECLARE @fs_ocdpvm smallint,
			@fs_ocdpv smallint,
			@fs_ocdpm smallint,
			@fs_ocdp smallint,
			@fs_ocdm smallint,
			@fs_ocd smallint,
			@fs_ocm smallint,
			@fs_oc smallint,
			@fs_om smallint,
			@fs_o smallint,
			@fs_ocdvm smallint,
			@fs_ocdv smallint,
			@fs_ocvm smallint,
			@fs_ocv smallint,
			@fs_ovm smallint,
			@fs_ov smallint,
			@fs_cdpvm smallint,
			@fs_cdpv smallint,
			@fs_cdpm smallint,
			@fs_cdp smallint,
			@fs_cdm smallint,
			@fs_cd smallint,
			@fs_cm smallint,
			@fs_c smallint,
			@fs_cdvm smallint,
			@fs_cdv smallint,
			@fs_cvm smallint,
			@fs_cv smallint,
			@fs_vm smallint,
			@fs_v smallint,
			@fs_m smallint,
			@fs smallint

	set @app_code = 'Media Manager Orders'
	set @comment_type = 'Standard Footer'
	
	--Comment for OCDPVM (when a comment exists for the specified, office, client, division and product, vendor)
	SELECT @fs_ocdpvm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)		
		
	--Comment for OCDPV (when a comment exists for the specified, office, client, division and product, vendor)
	SELECT @fs_ocdpv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)		
		
	--Comment for OCDPM
	SELECT @fs_ocdpm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OCDP
	SELECT @fs_ocdp = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCDM
	SELECT @fs_ocdm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type 
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OCD
	SELECT @fs_ocd = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type 
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCM
	SELECT @fs_ocm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OC
	SELECT @fs_oc = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OM
	SELECT @fs_om = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for O
	SELECT @fs_o = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCDVM
	SELECT @fs_ocdv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OCDV
	SELECT @fs_ocdv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCVM
	SELECT @fs_ocvm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OCV
	SELECT @fs_ocv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OVM
	SELECT @fs_ovm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OV
	SELECT @fs_ov = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDPVM
	SELECT @fs_cdpvm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CDPV
	SELECT @fs_cdpv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDPM
	SELECT @fs_cdpm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CDP
	SELECT @fs_cdp = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDM
	SELECT @fs_cdm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CD
	SELECT @fs_cd = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CM
	SELECT @fs_cm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for C
	SELECT @fs_c = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDVM
	SELECT @fs_cdvm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CDV
	SELECT @fs_cdv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CVM
	SELECT @fs_cvm = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CV
	SELECT @fs_cv = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for VM
	SELECT @fs_v = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for V
	SELECT @fs_v = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for M
	SELECT @fs_m = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)

	--Comment for none
	SELECT @fs = (SELECT FONT_SIZE FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)

	SELECT @std_font_size = COALESCE(
		@fs_ocdpvm,
		@fs_ocdpv,
		@fs_ocdpm,
		@fs_ocdp,
		@fs_ocdm,
		@fs_ocd,
		@fs_ocm,
		@fs_oc,
		@fs_om,
		@fs_o,
		@fs_ocdvm,
		@fs_ocdv,
		@fs_ocvm,
		@fs_ocv,
		@fs_ovm,
		@fs_ov,
		@fs_cdpvm,
		@fs_cdpv,
		@fs_cdpm,
		@fs_cdp,
		@fs_cdm,
		@fs_cd,
		@fs_cm,
		@fs_c,
		@fs_cdvm,
		@fs_cdv,
		@fs_cvm,
		@fs_cv,
		@fs_vm,
		@fs_v,
		@fs_m,
		@fs)

	RETURN @std_font_size
END

GO
