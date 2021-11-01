﻿

CREATE VIEW dbo.V_MAG_DETAIL   (ORDER_NBR , LINE_NBR , REV_NBR , SEQ_NBR , INSERT_DATE , SOURCE,  	CLOSE_DATE , MATL_CLOSE_DATE , EXT_CLOSE_DATE , EXT_MATL_DATE , MATERIAL ,   	ISSUE , AD_SIZE , HEADLINE ,   TAX_CODE,   	TAX_CITY_PCT, TAX_COUNTY_PCT, TAX_STATE_PCT,  	TAXAPPLYC, TAXAPPLYLN, TAXAPPLYLND, TAXAPPLYNC,    	TAXAPPLYR, TAX_RESALE, CITY_TAX,  	COUNTY_TAX, STATE_TAX, VENDOR_TAX, TAXAPPLYNCD,  	RATE , FLAT_NET , NET_GROSS, DISCOUNT_AMT,  	FLAT_GROSS , NET_RATE , GROSS_RATE , COMM_PCT , COMM_AMT ,   	MARKUP_PCT , REBATE_PCT , REBATE_AMT ,    	COLORCHARGE , COLORDESC , COLOR_AMT , BLEED_AMT, POSITION_AMT, PREMIUM_AMT,  	LINE_CANCELLED , JOB_NUMBER , JOB_COMPONENT_NBR ,    	DATE_TO_BILL , BILLING_USER , AR_INV_NBR , AR_TYPE , AR_INV_SEQ ,   	LINE_TOTAL , EXT_NET_AMT , EXT_GROSS_AMT , NETCHARGE ,  	NETCHARGE_DESC , ADDL_CHARGE , ADDL_CHARGE_DESC ,  	LINK_DETID , ACTIVE_REV)  AS  SELECT 	ORDER_NBR , LINE_NBR , REV_NBR , SEQ_NBR , INSERT_DATE , 'OLD' AS SOURCE,  	CLOSE_DATE , MATL_CLOSE_DATE , EXT_CLOSE_DATE , EXT_MATL_DATE , MATERIAL ,   	ISSUE , AD_SIZE , HEADLINE ,   NULL AS TAX_CODE,   	0 AS TAX_CITY_PCT, 0 AS TAX_COUNTY_PCT, 0 AS TAX_STATE_PCT,  	0 AS TAXAPPLYC, 0 AS TAXAPPLYLN, 0 AS TAXAPPLYLND, 0 AS TAXAPPLYNC,    	0 AS TAXAPPLYR, 0 AS TAX_RESALE, 0 AS CITY_TAX,  	0 AS COUNTY_TAX, 0 AS STATE_TAX, 0 AS VENDOR_TAX, 0 AS TAXAPPLYNCD,  	RATE , FLAT_NET , NET_GROSS, 0 AS DISCOUNT_AMT,  	FLAT_GROSS , NET_RATE , GROSS_RATE , COMM_PCT , COMM_AMT ,   	MARKUP_PCT , REBATE_PCT , REBATE_AMT ,    	COLORCHARGE , COLORDESC , COLOR_AMT , BLEED_AMT, POSITION_AMT, PREMIUM_AMT,  	LINE_CANCELLED , JOB_NUMBER , JOB_COMPONENT_NBR ,    	DATE_TO_BILL , BILLING_USER , AR_INV_NBR , AR_TYPE , AR_INV_SEQ ,   	LINE_TOTAL , EXT_NET_AMT , EXT_GROSS_AMT , 0 AS  NETCHARGE ,  	'' AS NETCHARGE_DESC , 0 AS ADDL_CHARGE , '' AS ADDL_CHARGE_DESC ,  	LINK_DETID , 0 AS ACTIVE_REV   FROM 	dbo.MAG_DETAIL  UNION ALL  SELECT 	H.ORDER_NBR , LINE_NBR , REV_NBR , SEQ_NBR , D.START_DATE , 'NEW',  	CLOSE_DATE , MATL_CLOSE_DATE , EXT_CLOSE_DATE , EXT_MATL_DATE , MATERIAL ,   	EDITION_ISSUE , SIZE , HEADLINE , TAX_CODE,  	TAX_CITY_PCT, TAX_COUNTY_PCT, TAX_STATE_PCT,  	TAXAPPLYC, TAXAPPLYLN, TAXAPPLYND, TAXAPPLYNC,    	TAXAPPLYR, TAX_RESALE, CITY_AMT,  	COUNTY_AMT, STATE_AMT, NON_RESALE_AMT, TAXAPPLYNC,  	RATE , FLAT_NET , H.NET_GROSS, DISCOUNT_AMT,  	FLAT_GROSS , NET_RATE , GROSS_RATE , COMM_PCT , COMM_AMT ,   	MARKUP_PCT , REBATE_PCT , REBATE_AMT ,    	COLOR_CHARGE , COLOR_DESC , COLOR_CHARGE , BLEED_AMT, POSITION_AMT, PREMIUM_AMT,  	LINE_CANCELLED , JOB_NUMBER , JOB_COMPONENT_NBR ,    	DATE_TO_BILL , BILLING_USER , AR_INV_NBR , AR_TYPE , AR_INV_SEQ ,   	BILLING_AMT , EXT_NET_AMT , EXT_GROSS_AMT ,  NETCHARGE ,  	NETCHARGE_DESC , ADDL_CHARGE , ADDL_CHARGE_DESC ,  	LINK_DETID , ACTIVE_REV  FROM 	dbo.MAGAZINE_HEADER H, dbo.MAGAZINE_DETAIL D  WHERE	H.ORDER_NBR = D.ORDER_NBR 

