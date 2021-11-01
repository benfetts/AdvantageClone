CREATE PROCEDURE [dbo].[advsp_bill_select_m_campaign] 
	@bcc_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	selection_id		integer identity( 1, 1 ) NOT NULL,	
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CMP_IDENTIFIER		integer NOT NULL,
	CMP_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CMP_NAME			varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, cc_selected )
		 SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.PRD_CODE, C.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, 1
		   FROM dbo.CAMPAIGN C 
	 INNER JOIN dbo.V_MEDIA_HDR B ON ( C.CMP_IDENTIFIER = B.CMP_ID )
		  WHERE BCC_ID = @bcc_id_in

INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, cc_selected )
	 SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.PRD_CODE, C.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, 0
	   FROM dbo.CAMPAIGN C 	 
 INNER JOIN dbo.V_MEDIA_HDR B ON ( C.CMP_IDENTIFIER = B.CMP_ID )
 	  WHERE ( C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )
	    AND ( B.MEDIA_TYPE IS NOT NULL )
	    AND ( B.ORD_PROCESS_CONTRL IN ( 1, 5 ))
	    AND ( BCC_ID IS NULL )
	    AND ( B.MEDIA_FROM NOT IN ( 'Mag', 'News' ))
		AND NOT EXISTS ( SELECT * 
						   FROM @selection 
						  WHERE CMP_IDENTIFIER = C.CMP_IDENTIFIER
							AND cc_selected = 1 )  

  SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
        [DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
        [CampaignID] = s.CMP_IDENTIFIER,
        [CampaignCode] = s.CMP_CODE,
        [CampaignName] = s.CMP_NAME,
        [IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
ORDER BY s.CL_CODE ASC, s.DIV_CODE ASC, s.PRD_CODE ASC, s.CMP_CODE ASC   

