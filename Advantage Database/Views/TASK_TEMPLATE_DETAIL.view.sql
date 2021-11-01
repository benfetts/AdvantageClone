
-- View
CREATE VIEW [dbo].[TASK_TEMPLATE_DETAIL] /*WITH ENCRYPTION*/
AS
/*=========== QUERY ===========*/
      SELECT 
            [ROWID] = [ttd].[ROWID], 
            [TRF_PRESET_CODE] = [ttd].[TRF_PRESET_CODE], 
            [TRAFFIC_PHASE_ID] = ISNULL([ttd].[TRAFFIC_PHASE_ID], 0), 
            [PHASE_DESC] = ISNULL([tp].[PHASE_DESC], ''),
            [FNC_CODE] = [ttd].[FNC_CODE], 
            [TRF_DESC] = ISNULL([t].[TRF_DESC], ''), 
            [TRF_PRESET_ORDER] = ISNULL([ttd].[TRF_PRESET_ORDER], 0), 
            [TRF_PRESET_DAYS] = ISNULL([ttd].[TRF_PRESET_DAYS], 0), 
            [TRF_PRESET_HRS] = ISNULL([ttd].[TRF_PRESET_HRS], 0), 
            [RUSH_DAYS] = ISNULL([ttd].[RUSH_DAYS], 0), 
            [RUSH_HOURS] = ISNULL([ttd].[RUSH_HOURS], 0), 
            [MILESTONE] = ISNULL([ttd].[MILESTONE], 0), 
            [DEFAULT_EMP] = ISNULL([ttd].[DEFAULT_EMP], ''), 
            [DEFAULT_EMP_NAME] = ISNULL(RTRIM(LTRIM([e].[EMP_FNAME] + ' ' + [e].[EMP_LNAME])), ''),  
            [EST_FNC_CODE] = ISNULL([ttd].[EST_FNC_CODE], ''),  
            [FNC_DESCRIPTION] = ISNULL([f].[FNC_DESCRIPTION], '')
      FROM 
            [dbo].[TRF_PRESET_DTL] AS [ttd] LEFT OUTER JOIN 
            [dbo].[TRAFFIC_PHASE] AS [tp] ON [tp].[TRAFFIC_PHASE_ID] = [ttd].[TRAFFIC_PHASE_ID] LEFT OUTER JOIN 
            [dbo].[TRAFFIC_FNC] AS [t] ON [t].[TRF_CODE] = [ttd].[FNC_CODE] LEFT OUTER JOIN 
            [dbo].[EMPLOYEE] AS [e] ON [e].[EMP_CODE] = [ttd].[DEFAULT_EMP] LEFT OUTER JOIN 
            [dbo].[FUNCTIONS] AS [f] ON [f].[FNC_CODE] = [ttd].[EST_FNC_CODE] 



/*=========== QUERY ===========*/
