﻿SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_cdp_client_contact]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_cdp_client_contact]
GO

CREATE PROCEDURE [dbo].[usp_wv_dd_cdp_client_contact] 
@Client VARCHAR(6)
AS
/*=========== QUERY ===========*/
    SELECT
		CAST(CDP_CONTACT_HDR.CDP_CONTACT_ID AS VARCHAR)+ '|' + CDP_CONTACT_HDR.CONT_CODE AS SplitPK, 
		CDP_CONTACT_HDR.CONT_CODE AS code, 
		CDP_CONTACT_HDR.CONT_CODE AS code2, 
		CDP_CONTACT_HDR.CONT_CODE + ' - ' + CDP_CONTACT_HDR.CONT_FML AS description,
		CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_TELEPHONE, CDP_CONTACT_HDR.CELL_PHONE,
		CDP_CONTACT_HDR.CONT_FAX, CDP_CONTACT_HDR.EMAIL_ADDRESS, CDP_CONTACT_HDR.CONT_EXTENTION, CDP_CONTACT_HDR.CONT_FAX_EXTENTION, ISNULL(CONT_COMMENT, '') AS CONT_COMMENT
	FROM         
		CDP_CONTACT_HDR WITH(NOLOCK)
	WHERE   
		CDP_CONTACT_HDR.CL_CODE = @Client
		AND ((CDP_CONTACT_HDR.INACTIVE_FLAG = 0) OR (CDP_CONTACT_HDR.INACTIVE_FLAG IS NULL))
	ORDER BY 
	    CDP_CONTACT_HDR.CONT_CODE;		
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
	