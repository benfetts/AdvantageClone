CREATE PROCEDURE [dbo].[advsp_pto_import_load_batch]
	@batch_name varchar(50)
AS
BEGIN
	
	SELECT
		[ImportID] = i.IMPORT_ID,
        [IsOnHold] = i.ON_HOLD,
        [EmployeeCode] = i.EMP_CODE,
        [EmployeeName] = COALESCE((RTRIM(e.EMP_FNAME) + ' '),'') + COALESCE((e.EMP_MI + '. '),'') + COALESCE(e.EMP_LNAME,''),
        [EmployeeOffice] = e.OFFICE_CODE,
        [Category] = i.CATEGORY,
        [Description] = i.[DESCRIPTION],
        [ActivityStart] = i.ACTIVITY_START,
        [Duration] = i.DURATION,
        [Status] = CAST(CASE 
							WHEN UPPER(i.[STATUS]) = 'A' OR UPPER(i.[STATUS]) = 'APPROVED' THEN 1
							WHEN UPPER(i.[STATUS]) = 'C' OR UPPER(i.[STATUS]) = 'CANCELED' OR UPPER(i.[STATUS]) = 'CANCELLED' THEN 2
							ELSE 0
						END as smallint),
		[EmployeeEmail] = e.EMP_EMAIL
	FROM dbo.IMP_PTO_STAGING i
		LEFT OUTER JOIN dbo.EMPLOYEE e ON i.EMP_CODE = e.EMP_CODE
	WHERE BATCH_NAME = @batch_name
	ORDER BY
		i.IMPORT_ID
END
GO