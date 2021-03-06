CREATE PROCEDURE [dbo].[advsp_load_drpt_client_contact]

AS
BEGIN

	DELETE FROM [dbo].[DRPT_CLIENT_CONTACT]
	
	DBCC CHECKIDENT (DRPT_CLIENT_CONTACT, reseed, 0)
	
	INSERT INTO [dbo].[DRPT_CLIENT_CONTACT]
	SELECT 
		[ClientCode] = C.CL_CODE,
		[Client] = C.CL_NAME,
		[Address] = C.CL_ADDRESS1,
		[Address2] = C.CL_ADDRESS2,
		[City] = C.CL_CITY,
		[County] = C.CL_COUNTY,
		[State] = C.CL_STATE,
		[Country] = C.CL_COUNTRY,
		[Zip] = C.CL_ZIP,
		[Attention] = C.CL_ATTENTION,
		[BillingAddress] = C.CL_BADDRESS1,
		[BillingAddress2] = C.CL_BADDRESS2,
		[BillingCity] = C.CL_BCITY,
		[BillingCounty] = C.CL_BCOUNTY,
		[BillingState] = C.CL_BSTATE,
		[BillingCountry] = C.CL_BCOUNTRY,
		[BillingZip] = C.CL_BZIP,
		[StreetAddress] = C.CL_SADDRESS1,
		[StreetAddress2] = C.CL_SADDRESS2,
		[StreetCity] = C.CL_SCITY,
		[StreetCounty] = C.CL_SCOUNTY,
		[StreetState] = C.CL_SSTATE,
		[StreetCountry] = C.CL_SCOUNTRY,
		[StreetZip] = C.CL_SZIP,
		[Footer] = C.CL_FOOTER,
		[MediaAttention] = C.CL_MATTENTION,
		[MediaFooter] = C.CL_MFOOTER,
		[IsActive] = CASE WHEN C.ACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
		[IsNewBusiness] = CASE WHEN C.NEW_BUSINESS = 1 THEN 'Yes' ELSE 'No' END,
		[ClientContactID] = CCH.CDP_CONTACT_ID,
		[ClientContactCode] = CCH.CONT_CODE,
		[ClientContactClientCode] = CCH.CL_CODE,
		[ClientContactEmail] = CCH.EMAIL_ADDRESS,
		[ClientContactFirstName] = CCH.CONT_FNAME,
		[ClientContactLastName] = CCH.CONT_LNAME,
		[ClientContactMiddleInitial] = CCH.CONT_MI,
		[ClientContactTitle] = CCH.CONT_TITLE,
		[ClientContactAddress] = CCH.CONT_ADDRESS1,
		[ClientContactAddress2] = CCH.CONT_ADDRESS2,
		[ClientContactCity] = CCH.CONT_CITY,
		[ClientContactCounty] = CCH.CONT_COUNTY,
		[ClientContactState] = CCH.CONT_STATE,
		[ClientContactCountry] = CCH.CONT_COUNTRY,
		[ClientContactZip] = CCH.CONT_ZIP,
		[ClientContactPhoneNumber] = CCH.CONT_TELEPHONE,
		[ClientContactExtention] = CCH.CONT_EXTENTION,
		[ClientContactFaxNumber] = CCH.CONT_FAX,
		[ClientContactFaxExtention] = CCH.CONT_FAX_EXTENTION,
		[ScheduleUser] = CASE WHEN CCH.SCHEDULE_USER = 1 THEN 'Yes' ELSE 'No' END,
		[CPUser] = CASE WHEN CCH.CP_USER = 1 THEN 'Yes' ELSE 'No' END,
		[ReceivesAlerts] = CASE WHEN CCH.CP_ALERTS = 1 THEN 'Yes' ELSE 'No' END,
		[ReceivesEmails] = CASE WHEN CCH.EMAIL_RCPT = 1 THEN 'Yes' ELSE 'No' END,
		[IsClientContactInactive] = CASE WHEN CCH.INACTIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
		[Name] = CCH.CONT_LF,
		[FullName] = CCH.CONT_FML,
		[ClientContactCellPhoneNumber] = CCH.CELL_PHONE,
		[Comment] = CCH.CONT_COMMENT,
		[DivisionCode] = CCD.DIV_CODE,
		[ProductCode] = CCD.PRD_CODE
	FROM 
		[dbo].[CLIENT] AS C LEFT OUTER JOIN 
		[dbo].[CDP_CONTACT_HDR] AS CCH ON CCH.CL_CODE = C.CL_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_DTL] AS CCD ON CCD.CDP_CONTACT_ID = CCH.CDP_CONTACT_ID

END	

