
/* CHANGE LOG:
==========================================================
ST, 20060517:
	- Added switches:
	SET ANSI_NULLS ON
	SET ANSI_WARNINGS OFF
	SET ARITHABORT OFF
	SET ARITHIGNORE ON
JTG, 20090129:
	- Modified formatting of dots between location sections so no orphan dots at end
JTG, 20090210:
	- Added @CityStateZip to create separately because of various on/off settings
JTG, 20090310:
	- Changed ANSI_NULLS to OFF because using UNICODE
JTG, 20090312
	- Changed unicode dot to char(149) due to being blown away during tranfer of script to ANSI file format.
*/


CREATE PROCEDURE [dbo].[usp_wv_reports_ar_statements_getfooter] 

@Location VarChar(6)

AS

--Creating a temp table to handle a multidimensional array past by the application for ClientID, DivID, ProductID, ContID, OnAccount, AddressUsed, Template

set nocount on

SET ANSI_NULLS OFF
SET ANSI_WARNINGS OFF
SET ARITHABORT OFF
SET ARITHIGNORE ON

declare @Footer as varchar(400)
declare @AgencyName varchar(50)
declare @AgencyAddress1 varchar(50)
declare @AgencyAddress2 varchar(50)
declare @AgencyCity varchar(35)
declare @AgencyState varchar(10)
declare @AgencyZip varchar(10)
declare @CityStateZip varchar(55) 
declare @LogoPath varchar(254)
declare @AgencyPhone varchar(20)
declare @AgencyFax varchar(20)
declare @AgencyEmail varchar(60)
declare @PrtHeader int
declare @PrtAddr1 int
declare @PrtAddr2 int
declare @PrtCity int
declare @PrtState int
declare @PrtZip int
declare @PrtPhone int
declare @PrtFax int
declare @PrtEmail int
declare @PrtFooter int
declare @PrtFtrAddr1 int
declare @PrtFtrAddr2 int
declare @PrtFtrCity int
declare @PrtFtrState int
declare @PrtFtrZip int
declare @PrtFtrPhone int
declare @PrtFtrFax int
declare @PrtFtrEmail int
declare @PrtName int
declare @PrtFtrName int

Select @AgencyName = NAME, @AgencyAddress1 = isnull(ADDRESS1, ''), @AgencyAddress2 = isnull(ADDRESS2, ''), @AgencyCity = isnull(CITY, ''), @AgencyState = isnull(STATE,''), @AgencyZip = isnull(ZIP, ''), 
@AgencyPhone = isnull(PHONE, ''), @AgencyFax = isnull(FAX, ''), @AgencyEmail = isnull(EMAIL, ''), @PrtHeader = PRT_HEADER, @PrtAddr1 = PRT_ADDR1, @PrtAddr2 = PRT_ADDR2,
@PrtCity = PRT_CITY, @PrtState = PRT_STATE, @PrtZip = PRT_ZIP, @PrtPhone = PRT_PHONE, @PrtFax = PRT_FAX, @PrtEmail = PRT_EMAIL,
@PrtFooter = PRT_FOOTER, @PrtFtrAddr1 = PRT_ADDR1_FTR, @PrtFtrAddr2 = PRT_ADDR2_FTR, @PrtFtrCity = PRT_CITY_FTR, @PrtFtrState = PRT_STATE_FTR,
@PrtFtrZip = PRT_ZIP_FTR, @PrtFtrPhone = PRT_PHONE_FTR, @PrtFtrFax = PRT_FAX_FTR, @PrtFtrEmail = PRT_EMAIL_FTR, @PrtName = PRT_NAME,
@PrtFtrName = PRT_NAME_FTR, @LogoPath = LOGO_PATH From LOCATIONS where ID = @Location and LOGO_LOCATION <> 'N'

Set @Footer = ''

If @PrtFooter = 1
BEGIN 

	IF @PrtFtrName = 1 AND @AgencyName <> '' begin
		Set @Footer = @AgencyName  
	end
	IF @PrtFtrAddr1 = 1 AND @AgencyAddress1 <> '' begin
		IF @Footer <> ''
			Set @Footer = @Footer + ' ' + char(149) + ' ' 
		Set @Footer = @Footer + @AgencyAddress1
	end
	IF @PrtFtrAddr2 = 1 AND @AgencyAddress2 <> '' begin
		IF @Footer <> ''
			Set @Footer = @Footer + ' ' + char(149) + ' '
		Set @Footer = @Footer + @AgencyAddress2
	end

	set @CityStateZip = ''
	IF @PrtFtrCity = 1 AND @AgencyCity <> '' begin
		Set @CityStateZip = @AgencyCity
	end
	IF @PrtFtrState = 1 AND @AgencyState <> '' begin
		If @CityStateZip <> '' 
			Set @CityStateZip = @CityStateZip + '  '
		Set @CityStateZip = @CityStateZip + @AgencyState
	end
	IF @PrtFtrZip = 1 AND @AgencyZip <> '' begin
		If @CityStateZip <> '' 
			Set @CityStateZip = @CityStateZip + '  '
		Set @CityStateZip = @CityStateZip + @AgencyZip
	end
	If @CityStateZip <> '' 
	Begin
		IF @Footer <> ''
			Set @Footer = @Footer + ' ' + char(149) + ' '
		Set @Footer = @Footer + @CityStateZip
	End

	IF @PrtFtrPhone = 1 AND @AgencyPhone <> '' begin
		IF @Footer <> ''
			Set @Footer = @Footer + ' ' + char(149) + ' '
		Set @Footer = @Footer + @AgencyPhone  
	end
	IF @PrtFtrFax = 1 AND @AgencyFax <> '' begin
		IF @Footer <> ''
			Set @Footer = @Footer + ' ' + char(149) + ' '
		Set @Footer = @Footer + @AgencyFax + ' Fax ' 
	end
	IF @PrtFtrEmail  = 1 AND @AgencyEmail <> '' begin
		IF @Footer <> ''
			Set @Footer = @Footer + ' ' + char(149) + ' '
		Set @Footer = @Footer + @AgencyEmail
	end
	
END

Select Footer = @Footer




