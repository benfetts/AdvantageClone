CREATE FUNCTION [dbo].[advfn_media_mgr_order_footer_comment](
	@office_code varchar(6),			--'o'
	@client_code varchar(6),			--'c'
	@division_code varchar(6),			--'d'
	@product_code varchar(6),			--'p'
	@vn_code varchar(6),				--'v'
	@media_type varchar(1)				--'m'
)
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @app_code varchar(50),
			@comment_type varchar(50),
			@std_comment varchar(MAX)
	
	DECLARE @comment_ocdpvm varchar(MAX),
			@comment_ocdpv varchar(MAX),
			@comment_ocdpm varchar(MAX),
			@comment_ocdp varchar(MAX),
			@comment_ocdm varchar(MAX),
			@comment_ocd varchar(MAX),
			@comment_ocm varchar(MAX),
			@comment_oc varchar(MAX),
			@comment_om varchar(MAX),
			@comment_o varchar(MAX),
			@comment_ocdvm varchar(MAX),
			@comment_ocdv varchar(MAX),
			@comment_ocvm varchar(MAX),
			@comment_ocv varchar(MAX),
			@comment_ovm varchar(MAX),
			@comment_ov varchar(MAX),
			@comment_cdpvm varchar(MAX),
			@comment_cdpv varchar(MAX),
			@comment_cdpm varchar(MAX),
			@comment_cdp varchar(MAX),
			@comment_cdm varchar(MAX),
			@comment_cd varchar(MAX),
			@comment_cm varchar(MAX),
			@comment_c varchar(MAX),
			@comment_cdvm varchar(MAX),
			@comment_cdv varchar(MAX),
			@comment_cvm varchar(MAX),
			@comment_cv varchar(MAX),
			@comment_vm varchar(MAX),
			@comment_v varchar(MAX),
			@comment_m varchar(MAX),
			@comment varchar(MAX)

	set @app_code = 'Media Manager Orders'
	set @comment_type = 'Standard Footer'

	--Comment for OCDPVM
	SELECT @comment_ocdpvm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)		

	--Comment for OCDPV (when a comment exists for the specified, office, client, division and product, vendor)
	SELECT @comment_ocdpv = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)		
	
	--Comment for OCDPM
	SELECT @comment_ocdpm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)		

	--Comment for OCDP
	SELECT @comment_ocdp = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCDM
	SELECT @comment_ocdm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type 
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)

	--Comment for OCD
	SELECT @comment_ocd = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type 
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCM
	SELECT @comment_ocm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)

	--Comment for OC
	SELECT @comment_oc = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OM
	SELECT @comment_om = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)

	--Comment for O
	SELECT @comment_o = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OCDVM
	SELECT @comment_ocdvm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)

	--Comment for OCDV
	SELECT @comment_ocdv = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
			
	--Comment for OCVM
	SELECT @comment_ocvm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OCV
	SELECT @comment_ocv = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for OVM
	SELECT @comment_ovm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for OV
	SELECT @comment_ov = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code 
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDPVM
	SELECT @comment_cdpvm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CDPV
	SELECT @comment_cdpv = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDPM
	SELECT @comment_cdpm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CDP
	SELECT @comment_cdp = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE = @product_code 
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDM
	SELECT @comment_cdm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CD
	SELECT @comment_cd = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CM
	SELECT @comment_cm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for C
	SELECT @comment_c = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CDVM
	SELECT @comment_cdvm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CDV
	SELECT @comment_cdv = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE = @division_code 
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for CVM
	SELECT @comment_cvm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for CV
	SELECT @comment_cv = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code 
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for VM
	SELECT @comment_vm = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE = @media_type 
		)
		
	--Comment for V
	SELECT @comment_v = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE = @vn_code 
		AND MEDIA_TYPE IS NULL
		)
		
	--Comment for m
	SELECT @comment = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE = @media_type 
		)

	--Comment for none
	SELECT @comment = (SELECT STD_COMMENT FROM dbo.STD_COMMENT WHERE APP_CODE = @app_code AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND VENDOR_CODE IS NULL
		AND MEDIA_TYPE IS NULL
		)

	SELECT @std_comment = COALESCE(
		@comment_ocdpvm,
		@comment_ocdpv,
		@comment_ocdpm,
		@comment_ocdp,
		@comment_ocdm,
		@comment_ocd,
		@comment_ocm,
		@comment_oc,
		@comment_om,
		@comment_o,
		@comment_ocdvm,
		@comment_ocdv,
		@comment_ocvm,
		@comment_ocv,
		@comment_ovm,
		@comment_ov,
		@comment_cdpvm,
		@comment_cdpv,
		@comment_cdpm,
		@comment_cdp,
		@comment_cdm,
		@comment_cd,
		@comment_cm,
		@comment_c,
		@comment_cdvm,
		@comment_cdv,
		@comment_cvm,
		@comment_cv,
		@comment_vm,
		@comment_v,
		@comment_m,
		@comment)

	RETURN @std_comment
END

GO
