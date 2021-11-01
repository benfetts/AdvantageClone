CREATE PROCEDURE [dbo].[advsp_digital_campaign_mgr_estimate_detail]
	@MEDIA_PLAN_DTL_IDs varchar(max)
AS

SELECT 
	RowIndex = MPDLLD.ROW_INDEX,
	[Month] = MONTH(MPDLLD.[START_DATE]),
	[Year] = YEAR(MPDLLD.[START_DATE]),
	CampaignName = Campaign.[DESCRIPTION], --C.CMP_NAME,
    VendorName = MPDLL.[DESCRIPTION],
	[Type] = MPDLL2.[DESCRIPTION],
    [Tactic] = MPDLL3.[DESCRIPTION],
    StartDate = MPDLLD.[START_DATE], 
	EndDate = MPDLLD.END_DATE,
    CostType = CASE WHEN MPD.SC_TYPE <> 'I' THEN 'NA'
               ELSE CASE
                    WHEN MPDLLD.UNITS IS NOT NULL AND MPDLLD.UNITS <> 0 THEN 'CPA'
                    WHEN MPDLLD.CLICKS IS NOT NULL AND MPDLLD.CLICKS <> 0 THEN 'CPC'
                    WHEN MPDLLD.IMPRESSIONS IS NOT NULL AND MPDLLD.IMPRESSIONS <> 0 THEN 'CPI'
                    ELSE 'NA'
                    END
               END,
    PlanImpressions = CASE 
                        WHEN MPDLLD.IMPRESSIONS IS NOT NULL AND MPDLLD.IMPRESSIONS <> 0 THEN MPDLLD.IMPRESSIONS
                        WHEN MPDLLD.CLICKS IS NOT NULL AND MPDLLD.CLICKS <> 0 THEN MPDLLD.CLICKS
                        WHEN MPDLLD.UNITS IS NOT NULL AND MPDLLD.UNITS <> 0 THEN MPDLLD.UNITS
                        ELSE NULL
                        END,
    PlanRate = MPDLLD.RATE,
    PlanSpend = COALESCE(MPDLLD.DOLLARS,0.00),
        --CASE WHEN MPD.IS_ESTIMATE_GROSS = 0 THEN
        --                    COALESCE(MPDLLD.DOLLARS,0.00)
        --                 ELSE
        --                    COALESCE(MPDLLD.DOLLARS,0.00) * .85
        --                 END,
    OrigPlanSpend = COALESCE(MPDLLD.DOLLARS,0.00),
        --CASE WHEN MPD.IS_ESTIMATE_GROSS = 0 THEN
        --                    COALESCE(MPDLLD.DOLLARS,0.00)
        --                 ELSE
        --                    COALESCE(MPDLLD.DOLLARS,0.00) * .85
        --                 END,
    PlanRevenue = COALESCE(MPDLLD.BILL_AMOUNT,0.00),
    PlanNetCharge = COALESCE(MPDLLD.NET_CHARGE,0.00),
	ActualImpressions = COALESCE(AP.ActualImpressions,0.00),
    ActualSpend = CASE WHEN MPD.IS_ESTIMATE_GROSS = 1 THEN COALESCE(AP.NetAmount, 0.00) + (.17647 * COALESCE(AP.NetAmount, 0.00))
                        ELSE COALESCE(AP.NetAmount, 0.00)
                        END,
    ActualRevenue = COALESCE(AP.NetAmount,0.00) + COALESCE(AP.CommTotal, 0.00) + COALESCE(AP.NetCharge, 0.00),
    ActualNetCharge = COALESCE(AP.NetCharge, 0.00),
    OrderNumber = MPDLLD.ORDER_NBR,
	OrderLineNumber = MPDLLD.ORDER_LINE_NBR,
    MediaPlanDetailLevelLineDataID = MPDLLD.MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID,
    IsClicksCPM = CASE 
                    WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND ROW_INDEX = MPDLLD.ROW_INDEX AND IS_CPM = 1) THEN CAST(1 as bit)
                    ELSE CAST(CASE WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_SETTING WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND SETTING = 'IsClicksCPM' AND BOOLEAN_VALUE = 1) THEN 1 ELSE 0 END as bit)
                    END,
    IsImpressionsCPM = CASE
                    WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND ROW_INDEX = MPDLLD.ROW_INDEX AND IS_CPM = 1) THEN CAST(1 as bit)
                    ELSE CAST(CASE WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_SETTING WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND SETTING = 'IsImpressionsCPM' AND BOOLEAN_VALUE = 1) THEN 1 ELSE 0 END as bit)
                    END,
    IsUnitsCPM = CASE
                    WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND ROW_INDEX = MPDLLD.ROW_INDEX AND IS_CPM = 1) THEN CAST(1 as bit)
                    ELSE CAST(CASE WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_SETTING WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND SETTING = 'IsUnitsCPM' AND BOOLEAN_VALUE = 1) THEN 1 ELSE 0 END as bit)
                    END,
    IsEstimateGrossAmount = MPD.IS_ESTIMATE_GROSS,
    SalesClassType = MPD.SC_TYPE,
    SalesClassCode = MPD.SC_CODE,
    ClientCode = MP.CL_CODE,
    DivisionCode = MP.DIV_CODE,
    ProductCode = MP.PRD_CODE,
    AgencyFee = COALESCE(MPDLLD.AGENCY_FEE,0.00),
    VendorCommission = 0.00, --(SELECT TOP 1 VN_COMM FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG WHERE MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID)
    VendorMarkup = CASE WHEN EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG WHERE MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID AND VN_MARKUP IS NOT NULL) THEN
                        (SELECT TOP 1 VN_MARKUP FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG WHERE MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID AND VN_MARKUP IS NOT NULL)
                    ELSE
                        (SELECT TOP 1 NUMERIC_VALUE FROM dbo.MEDIA_PLAN_DTL_SETTING WHERE MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID AND SETTING = 'ProductMarkupAmount')
                    END,
    MediaPlanID = MP.MEDIA_PLAN_ID,
    PlanDescription = MP.[DESCRIPTION],
    MediaPlanDetailID = MPD.MEDIA_PLAN_DTL_ID,
    EstimateName = MPD.[NAME],
    EstimateBuyer = dbo.advfn_get_emp_name(MPD.BUYER_EMP_CODE, 'FML'),
    ClientName = C.CL_NAME,
    DivisionName = D.DIV_NAME,
    ProductName = P.PRD_DESCRIPTION,
    IsGross = MPD.IS_ESTIMATE_GROSS
FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA MPDLLD
	INNER JOIN dbo.MEDIA_PLAN_DTL MPD ON MPD.MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID 
    INNER JOIN dbo.MEDIA_PLAN MP ON MP.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID 
    INNER JOIN dbo.CLIENT C ON MP.CL_CODE = C.CL_CODE
    INNER JOIN dbo.DIVISION D ON MP.CL_CODE = D.CL_CODE AND MP.DIV_CODE = D.DIV_CODE
    INNER JOIN dbo.PRODUCT P ON MP.CL_CODE = P.CL_CODE AND MP.DIV_CODE = P.DIV_CODE AND MP.PRD_CODE = P.PRD_CODE
    LEFT OUTER JOIN (
                    SELECT ROW_INDEX, [DESCRIPTION], MPDLL.MEDIA_PLAN_DTL_ID
                    FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL
	                    INNER JOIN dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLL.MEDIA_PLAN_DTL_ID = MPDLLT.MEDIA_PLAN_DTL_ID AND MPDLLT.CMP_IDENTIFIER IS NOT NULL
														                    AND MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID
                    ) Campaign ON MPDLLD.ROW_INDEX = Campaign.ROW_INDEX AND Campaign.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID
    LEFT OUTER JOIN (
                    SELECT SUM(COALESCE(IMPRESSIONS,0)) as ActualImpressions, SUM(COALESCE(NET_AMT,0)) as NetAmount, SUM(COALESCE(COMM_AMT,0)) as CommTotal, 
                        SUM(COALESCE(NETCHARGES,0)) + SUM(COALESCE(DISCOUNT_AMT,0)) as NetCharge,
						ORDER_NBR, ORDER_LINE_NBR
					FROM dbo.AP_INTERNET 
					GROUP BY ORDER_NBR, ORDER_LINE_NBR

                    UNION 

                    SELECT CAST(0 as int) as ActualImpressions, SUM(COALESCE(NET_AMT,0)) as NetAmount, SUM(COALESCE(COMM_AMT,0)) as CommTotal, 
                            SUM(COALESCE(NETCHARGES,0)) + SUM(COALESCE(COLOR_NET_AMT,0)) + SUM(COALESCE(BLEED_NET_AMT,0)) + SUM(COALESCE(POSITION_NET_AMT,0)) + SUM(COALESCE(PREMIUM_NET_AMT,0)) + 
                            SUM(COALESCE(DISCOUNT_LN,0)) + SUM(COALESCE(DISCOUNT_NC,0)) as NetCharge,
						ORDER_NBR, ORDER_LINE_NBR
					FROM dbo.AP_MAGAZINE
					GROUP BY ORDER_NBR, ORDER_LINE_NBR
                    
                    UNION 

                    SELECT CAST(0 as int) as ActualImpressions, SUM(COALESCE(NET_AMT,0)) as NetAmount, SUM(COALESCE(COMM_AMT,0)) as CommTotal, SUM(COALESCE(NETCHARGES,0)) + SUM(COALESCE(COLOR_NET_AMT,0)) +
                            SUM(COALESCE(DISCOUNT_LN,0)) + SUM(COALESCE(DISCOUNT_NC,0)) as NetCharge,
						ORDER_NBR, ORDER_LINE_NBR
					FROM dbo.AP_NEWSPAPER
					GROUP BY ORDER_NBR, ORDER_LINE_NBR

                    UNION 

                    SELECT CAST(0 as int) as ActualImpressions, SUM(COALESCE(NET_AMT,0)) as NetAmount, SUM(COALESCE(COMM_AMT,0)) as CommTotal, SUM(COALESCE(NETCHARGES,0)) + SUM(COALESCE(DISCOUNT_AMT,0)) as NetCharge,
						ORDER_NBR, ORDER_LINE_NBR
					FROM dbo.AP_OUTDOOR
					GROUP BY ORDER_NBR, ORDER_LINE_NBR

     --               UNION 

     --               SELECT SUM(COALESCE(TOTAL_SPOTS,0)) as ActualImpressions, SUM(EXT_NET_AMT) as NetAmount, SUM(COMM_AMT) as CommTotal, SUM(NETCHARGES) as NetCharge,
					--	ORDER_NBR, ORDER_LINE_NBR
					--FROM dbo.AP_RADIO
					--GROUP BY ORDER_NBR, ORDER_LINE_NBR

     --               UNION 

     --               SELECT SUM(COALESCE(TOTAL_SPOTS,0)) as ActualImpressions, SUM(EXT_NET_AMT) as NetAmount, SUM(COMM_AMT) as CommTotal, SUM(NETCHARGES) as NetCharge,
					--	ORDER_NBR, ORDER_LINE_NBR
					--FROM dbo.AP_TV
					--GROUP BY ORDER_NBR, ORDER_LINE_NBR

                    ) AP ON MPDLLD.ORDER_NBR = AP.ORDER_NBR AND MPDLLD.ORDER_LINE_NBR = AP.ORDER_LINE_NBR 
	LEFT OUTER JOIN dbo.MEDIA_PLAN_DTL_LEVEL MPDL ON MPDL.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND MPDL.TAG_TYPE = 2 --VENDOR
	LEFT OUTER JOIN dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID AND MPDLL.ROW_INDEX = MPDLLD.ROW_INDEX
	--
	LEFT OUTER JOIN dbo.MEDIA_PLAN_DTL_LEVEL MPDL2 ON MPDL2.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND MPDL2.TAG_TYPE = 4 --InternetType
	LEFT OUTER JOIN dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL2 ON MPDLL2.MEDIA_PLAN_DTL_LEVEL_ID = MPDL2.MEDIA_PLAN_DTL_LEVEL_ID AND MPDLL2.ROW_INDEX = MPDLLD.ROW_INDEX
    --
	LEFT OUTER JOIN dbo.MEDIA_PLAN_DTL_LEVEL MPDL3 ON MPDL3.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND MPDL3.TAG_TYPE = 14 --Tactic
	LEFT OUTER JOIN dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL3 ON MPDLL3.MEDIA_PLAN_DTL_LEVEL_ID = MPDL3.MEDIA_PLAN_DTL_LEVEL_ID AND MPDLL3.ROW_INDEX = MPDLLD.ROW_INDEX
WHERE
	MPD.MEDIA_PLAN_DTL_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_PLAN_DTL_IDs, ','))

GO
