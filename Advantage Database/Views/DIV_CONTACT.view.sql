﻿  	CREATE VIEW dbo.DIV_CONTACT (   		CL_CODE, DIV_CODE, CONT_CODE, CONT_ADDRESS1, CONT_ADDRESS2,   		CONT_CITY, CONT_COUNTRY, CONT_COUNTY, CONT_EXTENTION, CONT_FAX,   		CONT_FAX_EXTENTION, CONT_FNAME, CONT_LNAME, CONT_MI, CONT_STATE,   		CONT_TELEPHONE, CONT_TITLE, CONT_ZIP, EMAIL_ADDRESS, CONT_FML,   		CONT_LF, INACTIVE_FLAG )   	AS  	 SELECT h.CL_CODE, DIV_CODE, CONT_CODE, CONT_ADDRESS1, CONT_ADDRESS2, CONT_CITY,   		CONT_COUNTRY, CONT_COUNTY, CONT_EXTENTION, CONT_FAX, CONT_FAX_EXTENTION,   		CONT_FNAME, CONT_LNAME, CONT_MI, CONT_STATE, CONT_TELEPHONE, CONT_TITLE,   		CONT_ZIP, EMAIL_ADDRESS, CONT_FML, CONT_LF, INACTIVE_FLAG  	   FROM dbo.CDP_CONTACT_HDR h       INNER JOIN dbo.CDP_CONTACT_DTL d  	     ON h.CDP_CONTACT_ID = d.CDP_CONTACT_ID  	  WHERE ( DIV_CODE IS NOT NULL AND DIV_CODE <> '' )  	    AND ( PRD_CODE IS NULL OR PRD_CODE = '' ) 