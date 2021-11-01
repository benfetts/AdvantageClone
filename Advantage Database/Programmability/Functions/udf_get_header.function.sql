
CREATE  FUNCTION [dbo].[udf_get_header] ( @Location VarChar(6) )  		  	
RETURNS VARCHAR(400) AS  

BEGIN
declare @Header varchar(400)
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
declare @PrtName int


Select @AgencyName = NAME, @AgencyAddress1 = isnull(ADDRESS1, ''), @AgencyAddress2 = isnull(ADDRESS2, ''), @AgencyCity = isnull(CITY, ''), 
@AgencyState = isnull(STATE,''), @AgencyZip = isnull(ZIP, ''), @AgencyPhone = isnull(PHONE, ''), @AgencyFax = isnull(FAX, ''), 
@AgencyEmail = isnull(EMAIL, ''), @PrtHeader = PRT_HEADER, @PrtAddr1 = PRT_ADDR1, @PrtAddr2 = PRT_ADDR2, @PrtCity = PRT_CITY, 
@PrtState = PRT_STATE, @PrtZip = PRT_ZIP, @PrtPhone = PRT_PHONE, @PrtFax = PRT_FAX, @PrtEmail = PRT_EMAIL,@PrtName = PRT_NAME, 
@LogoPath = LOGO_PATH From LOCATIONS where ID = @Location and LOGO_LOCATION <> 'N'

Set @Header = ''
Set @CityStateZip = ''

IF @PrtName = 1 AND @AgencyName <> '' begin
	Set @Header = @AgencyName  
end
IF @PrtAddr1 = 1 AND @AgencyAddress1 <> '' begin
	IF @Header <> ''
		Set @Header = @Header + ' ' + char(149) + ' ' 
	Set @Header = @Header  + @AgencyAddress1
end
IF @PrtAddr2 = 1 AND @AgencyAddress2 <> '' begin
	IF @Header  <> ''
		Set @Header  = @Header  + ' ' + char(149) + ' '
	Set @Header  = @Header  + @AgencyAddress2
end


IF @PrtCity = 1 AND @AgencyCity <> '' begin
	Set @CityStateZip = @AgencyCity
end
IF @PrtState = 1 AND @AgencyState <> '' begin
	If @CityStateZip <> '' 
		Set @CityStateZip = @CityStateZip + '  '
	Set @CityStateZip = @CityStateZip + @AgencyState
end
IF @PrtZip = 1 AND @AgencyZip <> '' begin
	If @CityStateZip <> '' 
		Set @CityStateZip = @CityStateZip + '  '
	Set @CityStateZip = @CityStateZip + @AgencyZip
end
If @CityStateZip <> '' 
Begin
	IF @Header  <> ''
		Set @Header  = @Header  + ' ' + char(149) + ' '
	Set @Header  = @Header  + @CityStateZip
End

IF @PrtPhone = 1 AND @AgencyPhone <> '' begin
	IF @Header  <> ''
		Set @Header  = @Header  + ' ' + char(149) + ' '
	Set @Header  = @Header  + @AgencyPhone  
end
IF @PrtFax = 1 AND @AgencyFax <> '' begin
	IF @Header  <> ''
		Set @Header  = @Header  + ' ' + char(149) + ' '
	Set @Header  = @Header  + @AgencyFax + ' Fax ' 
end
IF @PrtEmail  = 1 AND @AgencyEmail <> '' begin
	IF @Header  <> ''
		Set @Header  = @Header  + ' ' + char(149) + ' '
	Set @Header  = @Header  + @AgencyEmail
end

Return @Header 
END
