
CREATE  FUNCTION [dbo].[udf_get_footer] ( @Location VarChar(6) )  		  	
RETURNS VARCHAR(400) AS  

BEGIN
declare @Footer varchar(400)
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
declare @PrtFooter int
declare @PrtFtrAddr1 int
declare @PrtFtrAddr2 int
declare @PrtFtrCity int
declare @PrtFtrState int
declare @PrtFtrZip int
declare @PrtFtrPhone int
declare @PrtFtrFax int
declare @PrtFtrEmail int

declare @PrtFtrName int

Select @AgencyName = NAME, @AgencyAddress1 = isnull(ADDRESS1, ''), @AgencyAddress2 = isnull(ADDRESS2, ''), 
@AgencyCity = isnull(CITY, ''), @AgencyState = isnull(STATE,''), @AgencyZip = isnull(ZIP, ''), @AgencyPhone = isnull(PHONE, ''), 
@AgencyFax = isnull(FAX, ''), @AgencyEmail = isnull(EMAIL, ''), @PrtFooter = PRT_FOOTER, @PrtFtrAddr1 = PRT_ADDR1_FTR, 
@PrtFtrAddr2 = PRT_ADDR2_FTR, @PrtFtrCity = PRT_CITY_FTR, @PrtFtrState = PRT_STATE_FTR, @PrtFtrZip = PRT_ZIP_FTR, 
@PrtFtrPhone = PRT_PHONE_FTR, @PrtFtrFax = PRT_FAX_FTR, @PrtFtrEmail = PRT_EMAIL_FTR, @PrtFtrName = PRT_NAME_FTR, 
@LogoPath = LOGO_PATH From LOCATIONS where ID = @Location and LOGO_LOCATION <> 'N'

Set @Footer = ''
Set @CityStateZip = ''

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

Return @Footer
END
