﻿  	CREATE VIEW dbo.V_AP_MEDIA_OOH2 (AP_ID, AR_INV_NBR)  AS    	     SELECT AP_ID, AR_INV_NBR  	       FROM dbo.OUTDOOR_DETAIL RD, dbo.V_AP_MEDIA_OOH AP   	      WHERE AP.ORDER_NBR=RD.ORDER_NBR   		AND AP.ORDER_LINE_NBR=RD.LINE_NBR  		AND RD.AR_INV_NBR IS NOT NULL 