﻿  	CREATE VIEW dbo.V_AP_MEDIA_INET2 (AP_ID, AR_INV_NBR) AS    	     SELECT AP_ID, AR_INV_NBR  	       FROM dbo.INTERNET_DETAIL RD, dbo.V_AP_MEDIA_INET AP   	      WHERE AP.ORDER_NBR=RD.ORDER_NBR   		AND AP.ORDER_LINE_NBR=RD.LINE_NBR  		AND RD.AR_INV_NBR IS NOT NULL 