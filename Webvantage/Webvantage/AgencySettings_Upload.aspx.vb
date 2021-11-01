Public Class AgencySettings_Upload
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "

    Public Enum PageMode

        Agency = 0
        ClientPortal = 1
        User = 2
        EmployeePicture = 3

    End Enum

#End Region

#Region " Variables "

    Private _CurrentPageMode As PageMode = PageMode.Agency
    Private _UploadType As UserThemeSettings.ImageType
    Private _ClientPortalClCode As String = ""
    Private _UserCustomWallpaperUserCode As String = ""
    Private _EmployeePictureEmpCode As String = ""
    Private _EmployeePictureNickName As String = ""

#End Region

#Region " Properties "

    'Private Property _ClientPortalMode As Boolean = False ' this is for the page to run it in 2 different modes; this is NOT the indicator that the entire app is running as client portal

#End Region

#Region " Page Events "

    Private Sub AgencySettings_Upload_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._UploadType = CType(CType(qs.Get("uploadtype"), Integer), UserThemeSettings.ImageType)

        If IsNumeric(qs.Get("pm")) = True Then

            Me._CurrentPageMode = CType(qs.Get("pm"), Integer)

        End If

        Dim HeaderText As String = ""
        Select Case Me._CurrentPageMode
            Case PageMode.Agency

                HeaderText = "Agency"

            Case PageMode.ClientPortal

                HeaderText = "Client Portal"
                Me._ClientPortalClCode = qs.ClientCode

            Case PageMode.User

                HeaderText = "User"
                Me._UserCustomWallpaperUserCode = qs.UserCode

            Case PageMode.EmployeePicture

                HeaderText = "Employee"
                Me._EmployeePictureEmpCode = qs.EmployeeCode
                Me._EmployeePictureNickName = qs.Get("nickname")
                Me._EmployeePictureNickName = Server.HtmlDecode(Me._EmployeePictureNickName)

        End Select

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim m As New DocumentRepository("", True)
            m.SetRadAsyncUpload(Me.RadUploadAgencyImage, False)

            Select Case Me._UploadType

                Case UserThemeSettings.ImageType.Icon

                    Me.LabelHeader.Text = "Upload " & HeaderText & " icon"
                    Me.LabelFilesizeWarning.Text = "* Maximum size: " & CType(UserThemeSettings.IconLimit / 1024, Integer).ToString() & " KB"
                    Me.RadUploadAgencyImage.MaxFileSize = UserThemeSettings.IconLimit

                Case UserThemeSettings.ImageType.Logo

                    Me.LabelHeader.Text = "Upload " & HeaderText & " logo"
                    Me.LabelFilesizeWarning.Text = "* Maximum size: " & CType(UserThemeSettings.LogoLimit / 1024, Integer).ToString() & " KB"
                    Me.RadUploadAgencyImage.MaxFileSize = UserThemeSettings.LogoLimit

                Case UserThemeSettings.ImageType.Custom

                    Me.LabelHeader.Text = "Upload " & HeaderText & " wallpaper"
                    Me.LabelFilesizeWarning.Text = "* Maximum size: " & CType(UserThemeSettings.WallpaperLimit / 1024, Integer).ToString() & " KB"
                    Me.RadUploadAgencyImage.MaxFileSize = UserThemeSettings.WallpaperLimit


                Case UserThemeSettings.ImageType.EmployeePictrue

                    Me.LabelHeader.Text = "Upload Employee picture"
                    Me.LabelFilesizeWarning.Text = "* Maximum size: " & CType(UserThemeSettings.EmployeeLimit / 1024, Integer).ToString() & "KB"
                    Me.RadUploadAgencyImage.MaxFileSize = UserThemeSettings.EmployeeLimit

                Case Else

                    Me.CloseThisWindow()

            End Select

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ButtonUpload_Click(sender As Object, e As System.EventArgs) Handles ButtonUpload.Click

        If Me.RadUploadAgencyImage.UploadedFiles.Count = 0 Then

            Me.ShowMessage("No file selected")
            Exit Sub

        End If

        Select Case Me._CurrentPageMode

            Case PageMode.Agency

                Me.SaveAgency()

            Case PageMode.ClientPortal

                Me.SaveClientPortal()

            Case PageMode.User

                Me.SaveUser()

            Case PageMode.EmployeePicture

                Me.SaveEmployeePicture()

        End Select

    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As System.EventArgs) Handles ButtonCancel.Click

        Me.CloseThisWindow()

    End Sub

#End Region

#Region " Methods "

    Private Sub SaveAgency()

        If Me.RadUploadAgencyImage.UploadedFiles.Count > 0 Then

            If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAgencyImage.UploadedFiles(0)) = False Then

                Me.ShowMessage("Invalid file type.")
                Exit Sub

            End If

            Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Dim cAgency As New cAgency(Session("ConnString"))

            Dim realFilename As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetName
            Dim FileType As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetExtension

            Dim NewFilename As String = ""

            Dim MIMEType As String = ""

            If Not Me.RadUploadAgencyImage.UploadedFiles(0).ContentType Is Nothing Then

                MIMEType = Me.RadUploadAgencyImage.UploadedFiles(0).ContentType

            Else

                MIMEType = ""

            End If

            Dim FileLength As Integer = Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Length

            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                Select Case Me._UploadType
                    Case UserThemeSettings.ImageType.Icon

                        If FileBytes.Length > UserThemeSettings.IconLimit Then

                            Me.ShowMessage("Icon file exceeded the file size limit.")
                            Exit Sub

                        Else

                            If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                                cAgency.SaveBinaryImage("WV_DEFAULT_ICON", "Agency defaulted icon for Webvantage", FileBytes)
                                AgyStg.SettingsDictionary.Add(AdvantageFramework.Agency.Settings.WV_BRND_ICON, realFilename)
                                AgyStg.UpdateValues()

                            End If

                        End If

                    Case UserThemeSettings.ImageType.Logo

                        If FileBytes.Length > UserThemeSettings.LogoLimit Then

                            Me.ShowMessage("Logo file exceeded the file size limit.")
                            Exit Sub

                        Else

                            If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                                cAgency.SaveBinaryImage("WV_DEFAULT_LOGO", "Agency defaulted logo for Webvantage", FileBytes)
                                AgyStg.SettingsDictionary.Add(AdvantageFramework.Agency.Settings.WV_BRND_LOGO, realFilename)
                                AgyStg.UpdateValues()

                            End If

                        End If

                    Case UserThemeSettings.ImageType.Custom

                        If FileBytes.Length > UserThemeSettings.WallpaperLimit Then

                            Me.ShowMessage("Wallpaper file exceeded the file size limit.")
                            Exit Sub

                        Else

                            If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                                cAgency.SaveBinaryImage("WV_DEFAULT_WP", "Agency defaulted wallpaper for Webvantage", FileBytes)

                                AgyStg.SettingsDictionary.Add(AdvantageFramework.Agency.Settings.WV_BRND_BG, realFilename)
                                AgyStg.SettingsDictionary.Add(AdvantageFramework.Agency.Settings.WV_BRND_BG_TYPE, CType(UserThemeSettings.ImageType.Custom, Integer).ToString())
                                AgyStg.UpdateValues()

                            End If

                        End If

                End Select

            End If

        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        Dim URL As String = "AgencySettings.aspx" & qs.ToString()
        Me.CloseThisWindowAndRefreshCaller(URL, True, True)

    End Sub
    Private Sub SaveClientPortal()

        If Me.RadUploadAgencyImage.UploadedFiles.Count > 0 Then

            Dim cAgency As New cAgency(Session("ConnString"))
            Dim ClientPortalTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"), True, Me._ClientPortalClCode)

            Dim realFilename As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetName
            Dim FileType As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetExtension

            Dim NewFilename As String = ""

            Dim MIMEType As String = ""

            If Not Me.RadUploadAgencyImage.UploadedFiles(0).ContentType Is Nothing Then

                MIMEType = Me.RadUploadAgencyImage.UploadedFiles(0).ContentType

            Else

                MIMEType = ""

            End If

            Dim FileLength As Integer = Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Length

            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                Select Case Me._UploadType
                    Case UserThemeSettings.ImageType.Icon

                        If FileBytes.Length > UserThemeSettings.IconLimit Then

                            Me.ShowMessage("Icon file exceeded the file size limit.")
                            Exit Sub

                        Else

                            If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                                cAgency.ClientPortal_SaveBinaryImage(Me._ClientPortalClCode, FileBytes, Me._UploadType)
                                ClientPortalTheme.ClientPortal_UpdateImageSetting(realFilename, Me._UploadType, Me._ClientPortalClCode)

                            End If

                        End If

                    Case UserThemeSettings.ImageType.Logo

                        If FileBytes.Length > UserThemeSettings.LogoLimit Then

                            Me.ShowMessage("Logo file exceeded the file size limit.")
                            Exit Sub

                        Else

                            If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                                cAgency.ClientPortal_SaveBinaryImage(Me._ClientPortalClCode, FileBytes, Me._UploadType)
                                ClientPortalTheme.ClientPortal_UpdateImageSetting(realFilename, Me._UploadType, Me._ClientPortalClCode)

                            End If

                        End If

                    Case UserThemeSettings.ImageType.Custom

                        If FileBytes.Length > UserThemeSettings.WallpaperLimit Then

                            Me.ShowMessage("Wallpaper file exceeded the file size limit.")
                            Exit Sub

                        Else

                            If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                                cAgency.ClientPortal_SaveBinaryImage(Me._ClientPortalClCode, FileBytes, Me._UploadType)
                                ClientPortalTheme.ClientPortal_UpdateImageSetting(realFilename, Me._UploadType, Me._ClientPortalClCode)

                            End If

                        End If

                End Select

            End If

        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        Dim URL As String = "AgencySettings.aspx" & qs.ToString()
        Me.CloseThisWindowAndRefreshCaller(URL, True, True)

    End Sub
    Private Sub SaveUser()

        If Me.RadUploadAgencyImage.UploadedFiles.Count > 0 Then

            Dim cAgency As New cAgency(Session("ConnString"))
            Dim realFilename As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetName
            Dim FileType As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetExtension

            Dim NewFilename As String = ""

            Dim MIMEType As String = ""

            If Not Me.RadUploadAgencyImage.UploadedFiles(0).ContentType Is Nothing Then

                MIMEType = Me.RadUploadAgencyImage.UploadedFiles(0).ContentType

            Else

                MIMEType = ""

            End If

            Dim FileLength As Integer = Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Length

            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                If FileBytes.Length > UserThemeSettings.WallpaperLimit Then

                    Me.ShowMessage("Wallpaper file exceeded the file size limit.")
                    Exit Sub

                Else

                    If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                        If cAgency.User_SaveBinaryImage(Session("EmpCode"), Session("UserCode"), FileBytes, realFilename) = True Then

                            Dim qs As New AdvantageFramework.Web.QueryString()
                            qs = qs.FromCurrent()
                            Dim URL As String = "MySettings.aspx" & qs.ToString()
                            Me.CloseThisWindowAndRefreshCaller(URL, True, True)

                        End If

                    End If

                End If


            End If

        End If

    End Sub
    Private Function SaveEmployeePicture() As String

        Dim ImageName As String = ""

        If Me.RadUploadAgencyImage.UploadedFiles.Count > 0 Then

            Dim realFilename As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetName
            Dim FileType As String = Me.RadUploadAgencyImage.UploadedFiles(0).GetExtension

            Dim NewFilename As String = ""

            Dim MIMEType As String = ""

            If Not Me.RadUploadAgencyImage.UploadedFiles(0).ContentType Is Nothing Then

                MIMEType = Me.RadUploadAgencyImage.UploadedFiles(0).ContentType

            Else

                MIMEType = ""

            End If

            Dim FileLength As Integer = Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Length
            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                If FileBytes.Length > UserThemeSettings.WallpaperLimit Then

                    Me.ShowMessage("Wallpaper file exceeded the file size limit.")
                    Exit Function

                Else

                    If Me.RadUploadAgencyImage.UploadedFiles(0).InputStream.Read(FileBytes, 0, FileLength) Then

                        'Dim Emp As New cEmployee(Session("ConnString"))
                        'Emp.SaveEmployeeProfile(Me._EmployeePictureEmpCode, FileBytes, Me._EmployeePictureNickName, Nothing)

                        Dim cAgency As New cAgency(Session("ConnString"))
                        If cAgency.EmployeePicture_SaveBinaryImage(Session("EmpCode"), FileBytes) = True Then

                            ImageName = realFilename

                        End If

                    End If

                End If


            End If

        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        Dim URL As String = "MySettings.aspx" & qs.ToString()
        Me.CloseThisWindowAndRefreshCaller(URL, True, True)

        Return ImageName

    End Function

#End Region

End Class
