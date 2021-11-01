
CREATE VIEW dbo.V_RADIO_SPOTS ( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, BRDCAST_YEAR, SPOTS, WEEKNUM, BRD_MONTH, WEEKDATE ) 
AS

 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK1 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK1 IS NOT NULL) AND (bc.weeknum = 1) AND (ts.SPOTS_WK1 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK2 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK2 IS NOT NULL) AND (bc.weeknum = 2) AND (ts.SPOTS_WK2 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK3 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK3 IS NOT NULL) AND (bc.weeknum = 3) AND (ts.SPOTS_WK3 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK4 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK4 IS NOT NULL) AND (bc.weeknum = 4) AND (ts.SPOTS_WK4 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK5 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK5 IS NOT NULL) AND (bc.weeknum = 5) AND (ts.SPOTS_WK5 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK6 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK6 IS NOT NULL) AND (bc.weeknum = 6) AND (ts.SPOTS_WK6 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK7 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK7 IS NOT NULL) AND (bc.weeknum = 7) AND (ts.SPOTS_WK7 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK8 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK8 IS NOT NULL) AND (bc.weeknum = 8) AND (ts.SPOTS_WK8 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK9 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK9 IS NOT NULL) AND (bc.weeknum = 9) AND (ts.SPOTS_WK9 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK10 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK10 IS NOT NULL) AND (bc.weeknum = 10) AND (ts.SPOTS_WK10 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK11 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK11 IS NOT NULL) AND (bc.weeknum = 11) AND (ts.SPOTS_WK11 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK12 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK12 IS NOT NULL) AND (bc.weeknum = 12) AND (ts.SPOTS_WK12 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK13 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK13 IS NOT NULL) AND (bc.weeknum = 13) AND (ts.SPOTS_WK13 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK14 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK14 IS NOT NULL) AND (bc.weeknum = 14) AND (ts.SPOTS_WK14 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK15 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK15 IS NOT NULL) AND (bc.weeknum = 15) AND (ts.SPOTS_WK15 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK16 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK16 IS NOT NULL) AND (bc.weeknum = 16) AND (ts.SPOTS_WK16 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK17 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK17 IS NOT NULL) AND (bc.weeknum = 17) AND (ts.SPOTS_WK17 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK18 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK18 IS NOT NULL) AND (bc.weeknum = 18) AND (ts.SPOTS_WK18 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK19 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK19 IS NOT NULL) AND (bc.weeknum = 19) AND (ts.SPOTS_WK19 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK20 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK20 IS NOT NULL) AND (bc.weeknum = 20) AND (ts.SPOTS_WK20 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK21 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK21 IS NOT NULL) AND (bc.weeknum = 21) AND (ts.SPOTS_WK21 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK22 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK22 IS NOT NULL) AND (bc.weeknum = 22) AND (ts.SPOTS_WK22 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK23 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK23 IS NOT NULL) AND (bc.weeknum = 23) AND (ts.SPOTS_WK23 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK24 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK24 IS NOT NULL) AND (bc.weeknum = 24) AND (ts.SPOTS_WK24 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK25 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK25 IS NOT NULL) AND (bc.weeknum = 25) AND (ts.SPOTS_WK25 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK26 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK26 IS NOT NULL) AND (bc.weeknum = 26) AND (ts.SPOTS_WK26 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK27 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK27 IS NOT NULL) AND (bc.weeknum = 27) AND (ts.SPOTS_WK27 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK28 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK28 IS NOT NULL) AND (bc.weeknum = 28) AND (ts.SPOTS_WK28 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK29 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK29 IS NOT NULL) AND (bc.weeknum = 29) AND (ts.SPOTS_WK29 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK30 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK30 IS NOT NULL) AND (bc.weeknum = 30) AND (ts.SPOTS_WK30 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK31 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK31 IS NOT NULL) AND (bc.weeknum = 31) AND (ts.SPOTS_WK31 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK32 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK32 IS NOT NULL) AND (bc.weeknum = 32) AND (ts.SPOTS_WK32 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK33 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK33 IS NOT NULL) AND (bc.weeknum = 33) AND (ts.SPOTS_WK33 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK34 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK34 IS NOT NULL) AND (bc.weeknum = 34) AND (ts.SPOTS_WK34 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK35 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK35 IS NOT NULL) AND (bc.weeknum = 35) AND (ts.SPOTS_WK35 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK36 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK36 IS NOT NULL) AND (bc.weeknum = 36) AND (ts.SPOTS_WK36 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK37 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK37 IS NOT NULL) AND (bc.weeknum = 37) AND (ts.SPOTS_WK37 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK38 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK38 IS NOT NULL) AND (bc.weeknum = 38) AND (ts.SPOTS_WK38 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK39 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK39 IS NOT NULL) AND (bc.weeknum = 39) AND (ts.SPOTS_WK39 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK40 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK40 IS NOT NULL) AND (bc.weeknum = 40) AND (ts.SPOTS_WK40 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK41 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK41 IS NOT NULL) AND (bc.weeknum = 41) AND (ts.SPOTS_WK41 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK42 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK42 IS NOT NULL) AND (bc.weeknum = 42) AND (ts.SPOTS_WK42 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK43 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK43 IS NOT NULL) AND (bc.weeknum = 43) AND (ts.SPOTS_WK43 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK44 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK44 IS NOT NULL) AND (bc.weeknum = 44) AND (ts.SPOTS_WK44 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK45 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK45 IS NOT NULL) AND (bc.weeknum = 45) AND (ts.SPOTS_WK45 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK46 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK46 IS NOT NULL) AND (bc.weeknum = 46) AND (ts.SPOTS_WK46 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK47 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK47 IS NOT NULL) AND (bc.weeknum = 47) AND (ts.SPOTS_WK47 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK48 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK48 IS NOT NULL) AND (bc.weeknum = 48) AND (ts.SPOTS_WK48 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK49 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK49 IS NOT NULL) AND (bc.weeknum = 49) AND (ts.SPOTS_WK49 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK50 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK50 IS NOT NULL) AND (bc.weeknum = 50) AND (ts.SPOTS_WK50 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK51 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK51 IS NOT NULL) AND (bc.weeknum = 51) AND (ts.SPOTS_WK51 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK52 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK52 IS NOT NULL) AND (bc.weeknum = 52) AND (ts.SPOTS_WK52 <> 0)
UNION ALL
 	SELECT ts.ORDER_NBR, ts.LINE_NBR, ts.REV_NBR, ts.SEQ_NBR, ts.BRDCAST_YEAR, ts.SPOTS_WK53 AS SPOTS, 
			 bc.weeknum, bc.brd_month, bc.weekdate
	  FROM dbo.RADIO_SPOTS AS ts INNER JOIN
          dbo.fn_BroadcastCal() AS bc ON ts.BRDCAST_YEAR = bc.brd_year
	 WHERE (ts.SPOTS_WK53 IS NOT NULL) AND (bc.weeknum = 53) AND (ts.SPOTS_WK53 <> 0)
