CREATE PROCEDURE [dbo].[advsp_bill_select_m_client_po] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,
	CLIENT_PO			varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CLIENT_PO, cc_selected )
	 SELECT DISTINCT CLIENT_PO, 1
	   FROM dbo.V_MEDIA_HDR
	  WHERE BCC_ID = @bcc_id_in
	    AND ( CLIENT_PO IS NOT NULL )
	    AND ( LTRIM( RTRIM( CLIENT_PO )) <> '' )

INSERT INTO @selection ( CLIENT_PO, cc_selected )
	 SELECT DISTINCT CLIENT_PO, 0
	   FROM dbo.V_MEDIA_HDR 
 	  WHERE ( MEDIA_TYPE IS NOT NULL )
	    AND ( ORD_PROCESS_CONTRL IN ( 1, 5 ))
		AND ( BCC_ID IS NULL )
		AND ( CLIENT_PO IS NOT NULL )
		AND ( LTRIM( RTRIM( CLIENT_PO )) <> '' )
		AND ( MEDIA_FROM NOT IN ( 'Mag', 'News' ))
		AND NOT EXISTS ( SELECT * 
						   FROM @selection 
						  WHERE CLIENT_PO = dbo.V_MEDIA_HDR.CLIENT_PO
							AND cc_selected = 1 )  

  SELECT s.CLIENT_PO, s.cc_selected
	FROM @selection s
ORDER BY s.CLIENT_PO
