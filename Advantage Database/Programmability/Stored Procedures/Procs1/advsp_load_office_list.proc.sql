if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_load_office_list]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_load_office_list]
GO


CREATE PROCEDURE [dbo].[advsp_load_office_list]
@load_closed bit,
@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT
	
AS
BEGIN


	SELECT DISTINCT
		OFFICE_CODE AS OfficeCode,
		OFFICE_NAME AS OfficeName,

		GLACODE_AR AS DefaultAR,
		GLACODE_AP AS DefaultAP,
		GLACODE_AP_DISC AS DefaultAP_Discount,
		--GLACODE_AP_WH AS GlacodeApWh,

		PGLACODE_SALES AS ProdSales,
		PGLACODE_COS AS ProdCostOfSales,
		PGLACODE_WIP AS ProdWorkInProgress,
		PGLACODE_DEF_SALES AS ProdDeferredSales,
		PGLACODE_DEF_COS AS ProdDeferredCOS,
		PGLACODE_ACC_COS AS ProdAccruedCOS,
		PGLACODE_ACC_AP AS ProdAccruedAP,
		PGLACODE_ACC_TAX AS ProdAccruedTax,

		MGLACODE_ACC_AP AS MediaDeferredAP, --MediaAccruedAP,
		MGLACODE_ACC_COS AS MediaAccruedCOS,
		MGLACODE_ACC_TAX AS MediaAccruedTax,
		MGLACODE_SALES AS MediaSales,
		MGLACODE_COS AS MediaCostOfSales,
		MGLACODE_WIP AS MediaAccruedAP, --MediaDeferredAP, --wip
		MGLACODE_DEF_COS AS MediaDeferredCOS,
		MGLACODE_DEF_SALES AS MediaDeferredSales,

		GLACODE_SUSPENSE AS DefaultSuspense,
		GLACODE_STATE AS DefaultState,
		GLACODE_COUNTY AS DefaultCounty,
		GLACODE_CITY AS DefaultCity,
		--GLACODE_VOL_DISC AS GlacodeVolDisc, 

		CASE PRD_AB_INCOME WHEN 1 THEN 'Upon Reconciliation' ELSE 'Initial Billing' END AS ProdAdvBillIncomeRecognition,
		CASE MED_AB_INCOME WHEN 1 THEN 'Billing Date' WHEN 2 THEN 'Insertion/Broadcast' ELSE 'Close Date' END AS MediaAdvBillIncomeRecognition,

		INACTIVE_FLAG AS InactiveFlag

	FROM
		dbo.OFFICE
	WHERE
		COALESCE(INACTIVE_FLAG, 0) = 0 OR @load_closed = 1

END

