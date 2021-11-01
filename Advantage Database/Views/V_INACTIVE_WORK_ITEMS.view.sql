CREATE VIEW [dbo].[V_INACTIVE_WORK_ITEMS]
AS
	SELECT * FROM [dbo].[advtf_alert_inactive_work_items]()
