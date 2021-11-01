Imports System.Web.Mvc
Imports System.Collections.Generic
Imports System.Web.Routing
Imports System.Drawing
Imports System.Data.SqlClient

Namespace Controllers.Maintenance.General

    <Serializable()>
    Public Class LocationsController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/General/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.General.LocationsController
#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetLogoString(Image As Byte()) As String
            'objects
            Dim ImageBase64Data As String = Nothing
            Dim ImageString As String = Nothing

            Try

                ImageBase64Data = Convert.ToBase64String(Image)
                ImageString = String.Format("data:image/png;base64,{0}", ImageBase64Data)

            Catch ex As Exception

            End Try

            Return ImageString

        End Function
        Private Function LocationMapper(ByRef LocationDetails As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails,
                                        ByRef LocationEntity As AdvantageFramework.Database.Entities.Location)

            If LocationDetails.ID Is "" OrElse LocationDetails.ID Is Nothing Then

                LocationDetails.ID = LocationEntity.ID
                LocationDetails.Name = LocationEntity.Name
                LocationDetails.Email = LocationEntity.Email
                LocationDetails.Phone = LocationEntity.Phone
                LocationDetails.Fax = LocationEntity.Fax
                LocationDetails.Address1 = LocationEntity.Address
                LocationDetails.Address2 = LocationEntity.Address2
                LocationDetails.City = LocationEntity.City
                LocationDetails.State = LocationEntity.State
                LocationDetails.Zip = LocationEntity.Zip

                LocationDetails.PrintHeader = LocationEntity.PrintHeader
                LocationDetails.PrintNameHeader = LocationEntity.PrintNameHeader
                LocationDetails.PrintAddressHeader = LocationEntity.PrintAddressHeader
                LocationDetails.PrintAddress2Header = LocationEntity.PrintAddress2Header
                LocationDetails.PrintCityHeader = LocationEntity.PrintCityHeader
                LocationDetails.PrintStateHeader = LocationEntity.PrintStateHeader
                LocationDetails.PrintZipHeader = LocationEntity.PrintZipHeader
                LocationDetails.PrintFaxHeader = LocationEntity.PrintFaxHeader
                LocationDetails.PrintPhoneHeader = LocationEntity.PrintPhoneHeader
                LocationDetails.PrintEmailHeader = LocationEntity.PrintEmailHeader

                LocationDetails.PrintFooter = LocationEntity.PrintFooter
                LocationDetails.PrintNameFooter = LocationEntity.PrintNameFooter
                LocationDetails.PrintAddressFooter = LocationEntity.PrintAddressFooter
                LocationDetails.PrintAddress2Footer = LocationEntity.PrintAddress2Footer
                LocationDetails.PrintCityFooter = LocationEntity.PrintCityFooter
                LocationDetails.PrintStateFooter = LocationEntity.PrintStateFooter
                LocationDetails.PrintZipFooter = LocationEntity.PrintZipFooter
                LocationDetails.PrintFaxFooter = LocationEntity.PrintFaxFooter
                LocationDetails.PrintPhoneFooter = LocationEntity.PrintPhoneFooter
                LocationDetails.PrintEmailFooter = LocationEntity.PrintEmailFooter

                LocationDetails.LogoLocation = LocationEntity.LogoLocation
                LocationDetails.FooterLogoLocation = LocationEntity.FooterLogoLocation

            Else

                LocationEntity.ID = LocationDetails.ID
                LocationEntity.Name = LocationDetails.Name
                LocationEntity.Email = LocationDetails.Email
                LocationEntity.Phone = LocationDetails.Phone
                LocationEntity.Fax = LocationDetails.Fax
                LocationEntity.Address = LocationDetails.Address1
                LocationEntity.Address2 = LocationDetails.Address2
                LocationEntity.City = LocationDetails.City
                LocationEntity.State = LocationDetails.State
                LocationEntity.Zip = LocationDetails.Zip

                LocationEntity.PrintHeader = Convert.ToInt32(LocationDetails.PrintHeader)
                LocationEntity.PrintNameHeader = Convert.ToInt32(LocationDetails.PrintNameHeader)
                LocationEntity.PrintAddressHeader = Convert.ToInt32(LocationDetails.PrintAddressHeader)
                LocationEntity.PrintAddress2Header = Convert.ToInt32(LocationDetails.PrintAddress2Header)
                LocationEntity.PrintCityHeader = Convert.ToInt32(LocationDetails.PrintCityHeader)
                LocationEntity.PrintStateHeader = Convert.ToInt32(LocationDetails.PrintStateHeader)
                LocationEntity.PrintZipHeader = Convert.ToInt32(LocationDetails.PrintZipHeader)
                LocationEntity.PrintFaxHeader = Convert.ToInt32(LocationDetails.PrintFaxHeader)
                LocationEntity.PrintPhoneHeader = Convert.ToInt32(LocationDetails.PrintPhoneHeader)
                LocationEntity.PrintEmailFooter = Convert.ToInt32(LocationDetails.PrintEmailFooter)

                LocationEntity.PrintFooter = Convert.ToInt32(LocationDetails.PrintFooter)
                LocationEntity.PrintNameFooter = Convert.ToInt32(LocationDetails.PrintNameFooter)
                LocationEntity.PrintAddressFooter = Convert.ToInt32(LocationDetails.PrintAddressFooter)
                LocationEntity.PrintAddress2Footer = Convert.ToInt32(LocationDetails.PrintAddress2Footer)
                LocationEntity.PrintCityFooter = Convert.ToInt32(LocationDetails.PrintCityFooter)
                LocationEntity.PrintStateFooter = Convert.ToInt32(LocationDetails.PrintStateFooter)
                LocationEntity.PrintZipFooter = Convert.ToInt32(LocationDetails.PrintZipFooter)
                LocationEntity.PrintFaxFooter = Convert.ToInt32(LocationDetails.PrintFaxFooter)
                LocationEntity.PrintPhoneFooter = Convert.ToInt32(LocationDetails.PrintPhoneFooter)
                LocationEntity.PrintEmailFooter = Convert.ToInt32(LocationDetails.PrintEmailFooter)

                LocationEntity.LogoLocation = LocationDetails.LogoLocation
                LocationEntity.FooterLogoLocation = LocationDetails.FooterLogoLocation

            End If

        End Function
        Public Function GetLocationID() As String

            Dim LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
            Dim LocationID As String = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                LocationEntity = New AdvantageFramework.Database.Entities.Location

                LocationEntity = DataContext.Locations.FirstOrDefault()

                If LocationEntity Is Nothing Then
                    LocationID = ""
                Else
                    LocationID = LocationEntity.ID
                End If


            End Using

            Return LocationID

        End Function
        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.General.LocationsController(Me.SecuritySession)

        End Sub
        Public Function UploadImage(ByVal Image As Byte(), LocationID As String, LocationLogoTypeID As Integer, EmployeeCode As String,
                                Optional ByRef ErrorMessage As String = "") As Boolean

            Dim LocationIDParameter As SqlParameter = Nothing
            Dim LogoTypeIdParameter As SqlParameter = Nothing
            Dim EmpCodeParameter As SqlParameter = Nothing
            Dim ImageParameter As SqlParameter = Nothing
            Dim SqlCommand As SqlCommand = Nothing

            Try

                Using MyConn As New SqlConnection(Session("ConnString"))

                    SqlCommand = New SqlCommand()

                    With SqlCommand

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_SaveLocationPicture"
                        .Connection = MyConn

                    End With

                    LocationIDParameter = New SqlParameter("@LOCATION_ID", SqlDbType.VarChar, 6)
                    LogoTypeIdParameter = New SqlParameter("@LOGO_TYPE_ID", SqlDbType.Int)
                    EmpCodeParameter = New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 100)

                    LocationIDParameter.Value = LocationID
                    SqlCommand.Parameters.Add(LocationIDParameter)

                    LogoTypeIdParameter.Value = LocationLogoTypeID
                    SqlCommand.Parameters.Add(LogoTypeIdParameter)

                    EmpCodeParameter.Value = EmployeeCode
                    SqlCommand.Parameters.Add(EmpCodeParameter)

                    ImageParameter = New SqlParameter("@IMAGE", SqlDbType.Image)

                    If Image.Length = 0 Then

                        ImageParameter.Value = System.DBNull.Value

                    Else

                        ImageParameter.Value = Image

                    End If

                    SqlCommand.Parameters.Add(ImageParameter)

                    MyConn.Open()

                    SqlCommand.ExecuteNonQuery()

                End Using

                ErrorMessage = ""

                Return True

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                Return False

            End Try

        End Function

#Region " MVC Views "

        <HttpGet>
        Public Function Index(LocationID As String) As System.Web.Mvc.ActionResult

            Dim LocationViewModel As AdvantageFramework.ViewModels.Maintenance.General.LocationViewModel

            LocationViewModel = New AdvantageFramework.ViewModels.Maintenance.General.LocationViewModel()

            LocationViewModel.LocationDetails = New AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails
            LocationViewModel.LocationLogo = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo

            If LocationID Is Nothing Then

                LocationID = GetLocationID()

            End If

            LocationViewModel.LocationDetails = Me.GetLocationDetail(LocationID)
            LocationViewModel.LocationLogo = Me.GetLocationLogoDetail(LocationID)

            LocationViewModel.LocationLogo.ShowHeaderLogo = LocationViewModel.LocationDetails.LogoLocation
            LocationViewModel.LocationLogo.ShowFooterLogo = LocationViewModel.LocationDetails.FooterLogoLocation
            'LocationViewModel.LocationLogo.LocationID = LocationID

            Return View(LocationViewModel)

        End Function
        <HttpGet>
        Public Function _Logos(LocationID As String) As System.Web.Mvc.ActionResult

            Dim LocationLogo As AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo = Nothing

            LocationLogo = GetLocationLogoDetail(LocationID)

            Return PartialView("_Logos", LocationLogo)

        End Function
        <HttpGet>
        Public Function _Location(LocationID As String) As System.Web.Mvc.ActionResult

            Dim LocationDetails As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails

            LocationDetails = GetLocationDetail(LocationID)

            Return PartialView("_Location", LocationDetails)

        End Function

#End Region

#Region " API "

        <HttpPost>
        Public Function DeleteLocationImage(LocationID As String, LocationLogoTypeID As Integer)

            'objects
            Dim LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
            Dim ErrorMessage As String = ""
            Dim DeleteFlag As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    LocationLogo = New AdvantageFramework.Database.Entities.LocationLogo
                    LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, LocationID, LocationLogoTypeID)

                    If LocationLogo IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.LocationLogo.Delete(DbContext, LocationLogo) = False Then

                            ErrorMessage = "The logo is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception

                ErrorMessage = "Failed trying to delete from the database. Please contact software support."

            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Return Json(DeleteFlag)
        End Function
        <HttpPost>
        Public Function DeleteLocation(LocationDetails As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails) As ActionResult

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim ErrorMessage As String = ""
            Dim UpdateFlag As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Location = New AdvantageFramework.Database.Entities.Location
                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, LocationDetails.ID)
                    LocationMapper(LocationDetails, Location)

                    If Location IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Location.Delete(DataContext, Location) = False Then

                            ErrorMessage = "The location is in use and cannot be deleted."
                        Else
                            DeleteLocationImage(LocationDetails.ID, CType(AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait, Integer))
                            DeleteLocationImage(LocationDetails.ID, CType(AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape, Integer))
                            DeleteLocationImage(LocationDetails.ID, CType(AdvantageFramework.Database.Entities.LocationLogoTypes.FooterPortrait, Integer))
                            DeleteLocationImage(LocationDetails.ID, CType(AdvantageFramework.Database.Entities.LocationLogoTypes.FooterLandscape, Integer))
                        End If

                    End If

                End Using

            Catch ex As Exception

                ErrorMessage = "Failed trying to delete from the database. Please contact software support."

            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Return Json(UpdateFlag)

        End Function
        <HttpPost>
        Public Function SaveLocationDetails(LocationDetails As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails) As ActionResult

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim UpdateFlag As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Location = New AdvantageFramework.Database.Entities.Location

                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, LocationDetails.ID)

                    If Location IsNot Nothing Then

                        LocationMapper(LocationDetails, Location)

                        UpdateFlag = AdvantageFramework.Database.Procedures.Location.Update(DataContext, Location)

                    Else

                        Location = New AdvantageFramework.Database.Entities.Location
                        LocationMapper(LocationDetails, Location)

                        UpdateFlag = AdvantageFramework.Database.Procedures.Location.Insert(DataContext, Location)

                    End If

                End Using

            Catch ex As Exception

                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Return Json(UpdateFlag)

        End Function
        <HttpPost>
        Public Function UploadLocationImage(LocationID As String, LocationLogoTypeId As Integer, ByVal PicFile As HttpPostedFileBase) As JsonResult

            'objects
            Dim ErrorMessage As String = Nothing
            Dim FileLength As Integer = 0
            Dim Saved As Boolean = False
            Dim FileBytes() As Byte = Nothing

            FileLength = PicFile.InputStream.Length

            PicFile.InputStream.Seek(0, IO.SeekOrigin.Begin)

            If FileLength > 0 Then

                ReDim FileBytes(FileLength - 1)

                If PicFile.InputStream.Read(FileBytes, 0, FileLength) Then

                    If UploadImage(FileBytes, LocationID, LocationLogoTypeId, Session("UserCode")) = True Then

                        Saved = True

                    End If

                End If

            End If

            If Saved Then

                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function
        <HttpGet>
        Public Function GetLocations() As JsonResult

            'objects
            Dim Locations As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Location.Location) = Nothing
            Dim LocationEntities As Generic.List(Of AdvantageFramework.Database.Entities.Location) = Nothing
            Dim Location As AdvantageFramework.DTO.Maintenance.General.Location.Location = Nothing

            Locations = New Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Location.Location)

            Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                LocationEntities = AdvantageFramework.Database.Procedures.Location.Load(DataContext).ToList

                If LocationEntities IsNot Nothing Then

                    For Each LocationEntity As AdvantageFramework.Database.Entities.Location In LocationEntities

                        Location = New AdvantageFramework.DTO.Maintenance.General.Location.Location

                        Location.LocationID = LocationEntity.ID
                        Location.LocationName = LocationEntity.Name + "|" + LocationEntity.ID

                        Locations.Add(Location)

                        Location = Nothing

                    Next

                End If

            End Using

            Return Json(Locations, JsonRequestBehavior.AllowGet)

        End Function
        '<HttpGet>
        'Public Function GetStates() As JsonResult

        '    'objects
        '    Dim States As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.Location.State) = Nothing
        '    Dim StateEntities As Generic.List(Of AdvantageFramework.Database.Entities.State) = Nothing

        '    States = New List(Of AdvantageFramework.ViewModels.Maintenance.General.Location.State)

        '    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

        '        StateEntities = AdvantageFramework.Database.Procedures.State.LoadStates(DbContext).ToList

        '        If StateEntities IsNot Nothing Then

        '            Dim State As AdvantageFramework.ViewModels.Maintenance.General.Location.State = Nothing

        '            For Each StateEntity As AdvantageFramework.Database.Entities.State In StateEntities

        '                State = New AdvantageFramework.ViewModels.Maintenance.General.Location.State

        '                State.StateCode = StateEntity.StateCode
        '                State.StateName = StateEntity.StateName

        '                States.Add(State)

        '                State = Nothing

        '            Next

        '        End If

        '    End Using

        '    Return Json(States, JsonRequestBehavior.AllowGet)

        'End Function
        <HttpGet>
        Public Function GetLocationDetail(LocationID As String) As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails

            'objects
            Dim LocationDetails As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails = Nothing
            Dim LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing

            If LocationID = "" Then

                LocationDetails = New AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails

            Else

                Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    If LocationID IsNot Nothing Then

                        LocationEntity = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, LocationID)

                    Else

                        LocationEntity = DataContext.Locations.FirstOrDefault()

                    End If


                    If LocationEntity IsNot Nothing Then

                        LocationDetails = New AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails

                        LocationMapper(LocationDetails, LocationEntity)

                    End If

                End Using

            End If

            Return LocationDetails

        End Function
        <HttpGet>
        Public Function GetLocationLogoDetail(LocationID As String) As AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo

            Dim LocationLogo As AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo = Nothing
            Dim LocationLogoEntity As AdvantageFramework.Database.Entities.LocationLogo = Nothing
            Dim LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing

            LocationLogo = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo

            If LocationID = "" Then

                LocationLogo.HeaderPortrait = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails
                LocationLogo.HeaderLandscape = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails
                LocationLogo.FooterPortrait = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails
                LocationLogo.FooterLandscape = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails

            Else

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        'Header Portrait
                        Try
                            LocationLogoEntity = New AdvantageFramework.Database.Entities.LocationLogo

                            LocationLogoEntity = AdvantageFramework.Database.Procedures.LocationLogo.LoadHeaderPortrait(DbContext, LocationID)

                            LocationLogo = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo
                            LocationLogo.HeaderPortrait = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails

                            If LocationLogoEntity IsNot Nothing Then

                                LocationLogo.HeaderPortrait.LocationID = LocationLogoEntity.LocationID
                                LocationLogo.HeaderPortrait.LocationLogoTypeID = LocationLogoEntity.LocationLogoTypeID
                                LocationLogo.HeaderPortrait.Image = GetLogoString(LocationLogoEntity.Image)
                                LocationLogo.HeaderPortrait.Thumbnail = LocationLogoEntity.Thumbnail
                                LocationLogo.HeaderPortrait.IsActive = LocationLogoEntity.IsActive
                                LocationLogo.HeaderPortrait.CreateDate = LocationLogoEntity.CreateDate
                                LocationLogo.HeaderPortrait.UserCode = LocationLogoEntity.UserCode

                            End If

                        Catch ex As Exception

                            LocationLogoEntity = Nothing

                        End Try

                        'Header Landscape
                        Try
                            LocationLogoEntity = New AdvantageFramework.Database.Entities.LocationLogo

                            LocationLogoEntity = AdvantageFramework.Database.Procedures.LocationLogo.LoadHeaderLandscape(DbContext, LocationID)

                            LocationLogo.HeaderLandscape = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails

                            If LocationLogoEntity IsNot Nothing Then

                                LocationLogo.HeaderLandscape.ID = LocationLogoEntity.ID
                                LocationLogo.HeaderLandscape.LocationID = LocationLogoEntity.LocationID
                                LocationLogo.HeaderLandscape.LocationLogoTypeID = LocationLogoEntity.LocationLogoTypeID
                                LocationLogo.HeaderLandscape.Image = GetLogoString(LocationLogoEntity.Image)
                                LocationLogo.HeaderLandscape.Thumbnail = LocationLogoEntity.Thumbnail
                                LocationLogo.HeaderLandscape.IsActive = LocationLogoEntity.IsActive
                                LocationLogo.HeaderLandscape.CreateDate = LocationLogoEntity.CreateDate
                                LocationLogo.HeaderLandscape.UserCode = LocationLogoEntity.UserCode

                            End If

                        Catch ex As Exception

                            LocationLogoEntity = Nothing

                        End Try

                        'Footer Portrait
                        Try
                            LocationLogoEntity = New AdvantageFramework.Database.Entities.LocationLogo

                            LocationLogoEntity = AdvantageFramework.Database.Procedures.LocationLogo.LoadFooterPortrait(DbContext, LocationID)

                            LocationLogo.FooterPortrait = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails

                            If LocationLogoEntity IsNot Nothing Then

                                LocationLogo.FooterPortrait.ID = LocationLogoEntity.ID
                                LocationLogo.FooterPortrait.LocationID = LocationLogoEntity.LocationID
                                LocationLogo.FooterPortrait.LocationLogoTypeID = LocationLogoEntity.LocationLogoTypeID
                                LocationLogo.FooterPortrait.Image = GetLogoString(LocationLogoEntity.Image)
                                LocationLogo.FooterPortrait.Thumbnail = LocationLogoEntity.Thumbnail
                                LocationLogo.FooterPortrait.IsActive = LocationLogoEntity.IsActive
                                LocationLogo.FooterPortrait.CreateDate = LocationLogoEntity.CreateDate
                                LocationLogo.FooterPortrait.UserCode = LocationLogoEntity.UserCode

                            End If

                        Catch ex As Exception

                            LocationLogoEntity = Nothing

                        End Try

                        'Footer Landscape
                        Try
                            LocationLogoEntity = New AdvantageFramework.Database.Entities.LocationLogo

                            LocationLogoEntity = AdvantageFramework.Database.Procedures.LocationLogo.LoadFooterLandscape(DbContext, LocationID)

                            LocationLogo.FooterLandscape = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogoDetails

                            If LocationLogoEntity IsNot Nothing Then

                                LocationLogo.FooterLandscape.ID = LocationLogoEntity.ID
                                LocationLogo.FooterLandscape.LocationID = LocationLogoEntity.LocationID
                                LocationLogo.FooterLandscape.LocationLogoTypeID = LocationLogoEntity.LocationLogoTypeID
                                LocationLogo.FooterLandscape.Image = GetLogoString(LocationLogoEntity.Image)
                                LocationLogo.FooterLandscape.Thumbnail = LocationLogoEntity.Thumbnail
                                LocationLogo.FooterLandscape.IsActive = LocationLogoEntity.IsActive
                                LocationLogo.FooterLandscape.CreateDate = LocationLogoEntity.CreateDate
                                LocationLogo.FooterLandscape.UserCode = LocationLogoEntity.UserCode

                            End If

                        Catch ex As Exception

                            LocationLogoEntity = Nothing

                        End Try


                        LocationEntity = New AdvantageFramework.Database.Entities.Location

                        Try
                            LocationEntity = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, LocationID)

                            If LocationEntity IsNot Nothing Then

                                LocationLogo.ShowHeaderLogo = LocationEntity.LogoLocation
                                LocationLogo.ShowFooterLogo = LocationEntity.FooterLogoLocation

                            End If

                        Catch ex As Exception

                            LocationEntity = Nothing

                        End Try


                    End Using

                End Using

            End If

            LocationLogo.LocationID = LocationID

            Return LocationLogo

        End Function

#End Region


#End Region

    End Class

End Namespace



