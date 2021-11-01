Public Class LocationOverride
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "

    Public Enum OverrideFromApp
        PurchaseOrder = 0
        JobForecast = 1
    End Enum

#End Region

#Region " Variables "

    Private _ShowFooterOptions As Boolean = True
    Private _ShowHeaderOptions As Boolean = True

#End Region

#Region " Properties "

    Private ReadOnly Property LocationSessionKey As String
        Get

            Dim Key As String = Nothing

            If Not String.IsNullOrWhiteSpace(Request.QueryString("App")) Then

                Select Case CInt(Request.QueryString("App"))

                    Case OverrideFromApp.PurchaseOrder

                        Key = "LocationOverride"

                    Case OverrideFromApp.JobForecast

                        Key = "JF_LocationOverride"

                    Case Else

                        Key = "LocationOverride"

                End Select

            Else

                Key = "LocationOverride"

            End If

            Return Key

        End Get
    End Property
    Private Property LocationToOverride As AdvantageFramework.Database.Entities.Location
        Get
            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Database.Entities.Location)(Session(Me.LocationSessionKey))
        End Get
        Set(value As AdvantageFramework.Database.Entities.Location)
            Session(Me.LocationSessionKey) = Newtonsoft.Json.JsonConvert.SerializeObject(value)
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub LoadLocationInformation()

        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        Location = Me.LocationToOverride

        If Location IsNot Nothing Then

            LabelLocationName.Text = Location.ID & " - " & Location.Name

            If Location.LogoLocation = "N" Then

                RadioButtonHideLogo.Checked = True
                RadioButtonShowLogo.Checked = False

            Else

                RadioButtonHideLogo.Checked = False
                RadioButtonShowLogo.Checked = True

            End If

            If _ShowHeaderOptions Then

                CheckBoxLocationHeader.Checked = CBool(Location.PrintHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderName.Checked = CBool(Location.PrintNameHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderAddress1.Checked = CBool(Location.PrintAddressHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderAddress2.Checked = CBool(Location.PrintAddress2Header.GetValueOrDefault(0))
                CheckBoxLocationHeaderCity.Checked = CBool(Location.PrintCityHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderState.Checked = CBool(Location.PrintStateHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderZip.Checked = CBool(Location.PrintZipHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderPhone.Checked = CBool(Location.PrintPhoneHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderFax.Checked = CBool(Location.PrintFaxHeader.GetValueOrDefault(0))
                CheckBoxLocationHeaderEmail.Checked = CBool(Location.PrintEmailHeader.GetValueOrDefault(0))

            End If

            If _ShowFooterOptions Then

                CheckBoxLocationFooter.Checked = CBool(Location.PrintFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterName.Checked = CBool(Location.PrintNameFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterAddress1.Checked = CBool(Location.PrintAddressFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterAddress2.Checked = CBool(Location.PrintAddress2Footer.GetValueOrDefault(0))
                CheckBoxLocationFooterCity.Checked = CBool(Location.PrintCityFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterState.Checked = CBool(Location.PrintStateFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterZip.Checked = CBool(Location.PrintZipFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterPhone.Checked = CBool(Location.PrintPhoneFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterFax.Checked = CBool(Location.PrintFaxFooter.GetValueOrDefault(0))
                CheckBoxLocationFooterEmail.Checked = CBool(Location.PrintEmailFooter.GetValueOrDefault(0))

            End If

        Else

            LabelLocationName.Text = ""

            CheckBoxLocationHeader.Checked = False
            CheckBoxLocationHeaderName.Checked = False
            CheckBoxLocationHeaderAddress1.Checked = False
            CheckBoxLocationHeaderAddress2.Checked = False
            CheckBoxLocationHeaderCity.Checked = False
            CheckBoxLocationHeaderState.Checked = False
            CheckBoxLocationHeaderZip.Checked = False
            CheckBoxLocationHeaderPhone.Checked = False
            CheckBoxLocationHeaderFax.Checked = False
            CheckBoxLocationHeaderEmail.Checked = False

            CheckBoxLocationFooter.Checked = False
            CheckBoxLocationFooterName.Checked = False
            CheckBoxLocationFooterAddress1.Checked = False
            CheckBoxLocationFooterAddress2.Checked = False
            CheckBoxLocationFooterCity.Checked = False
            CheckBoxLocationFooterState.Checked = False
            CheckBoxLocationFooterZip.Checked = False
            CheckBoxLocationFooterPhone.Checked = False
            CheckBoxLocationFooterFax.Checked = False
            CheckBoxLocationFooterEmail.Checked = False

        End If

    End Sub
    Private Sub FillLocationEntity(ByRef Location As AdvantageFramework.Database.Entities.Location)

        If Location IsNot Nothing Then

            If RadioButtonHideLogo.Checked Then

                Location.LogoLocation = "N"

            Else

                Location.LogoLocation = "C"

            End If

            Location.PrintHeader = Convert.ToInt64(CheckBoxLocationHeader.Checked)
            Location.PrintNameHeader = Convert.ToInt64(CheckBoxLocationHeaderName.Checked)
            Location.PrintAddressHeader = Convert.ToInt64(CheckBoxLocationHeaderAddress1.Checked)
            Location.PrintAddress2Header = Convert.ToInt64(CheckBoxLocationHeaderAddress2.Checked)
            Location.PrintCityHeader = Convert.ToInt64(CheckBoxLocationHeaderCity.Checked)
            Location.PrintStateHeader = Convert.ToInt64(CheckBoxLocationHeaderState.Checked)
            Location.PrintZipHeader = Convert.ToInt64(CheckBoxLocationHeaderZip.Checked)
            Location.PrintPhoneHeader = Convert.ToInt64(CheckBoxLocationHeaderPhone.Checked)
            Location.PrintFaxHeader = Convert.ToInt64(CheckBoxLocationHeaderFax.Checked)
            Location.PrintEmailHeader = Convert.ToInt64(CheckBoxLocationHeaderEmail.Checked)

            Location.PrintFooter = Convert.ToInt64(CheckBoxLocationFooter.Checked)
            Location.PrintNameFooter = Convert.ToInt64(CheckBoxLocationFooterName.Checked)
            Location.PrintAddressFooter = Convert.ToInt64(CheckBoxLocationFooterAddress1.Checked)
            Location.PrintAddress2Footer = Convert.ToInt64(CheckBoxLocationFooterAddress2.Checked)
            Location.PrintCityFooter = Convert.ToInt64(CheckBoxLocationFooterCity.Checked)
            Location.PrintStateFooter = Convert.ToInt64(CheckBoxLocationFooterState.Checked)
            Location.PrintZipFooter = Convert.ToInt64(CheckBoxLocationFooterZip.Checked)
            Location.PrintPhoneFooter = Convert.ToInt64(CheckBoxLocationFooterPhone.Checked)
            Location.PrintFaxFooter = Convert.ToInt64(CheckBoxLocationFooterFax.Checked)
            Location.PrintEmailFooter = Convert.ToInt64(CheckBoxLocationFooterEmail.Checked)

        End If

    End Sub

#Region "  Page Methods "

    Private Sub LocationOverride_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not String.IsNullOrEmpty(Request.QueryString("Footer")) Then

            Try

                _ShowFooterOptions = CBool(CInt(Request.QueryString("Footer")))

            Catch ex As Exception
                _ShowFooterOptions = True
            End Try

        End If

        If Not String.IsNullOrEmpty(Request.QueryString("Header")) Then

            Try

                _ShowHeaderOptions = CBool(CInt(Request.QueryString("Header")))

            Catch ex As Exception
                _ShowHeaderOptions = True
            End Try

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "Location Defaults - Location Override"

        If Me.LocationToOverride IsNot Nothing Then

            HeaderOptionsDiv.Visible = _ShowHeaderOptions
            FooterOptionsDiv.Visible = _ShowFooterOptions

            If Not Me.IsPostBack Then

                LoadLocationInformation()

            End If

        Else

            Me.CloseThisWindow()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadButtonLocationOK_Click(sender As Object, e As EventArgs) Handles RadButtonLocationOK.Click

        'objects
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        Location = Me.LocationToOverride

        FillLocationEntity(Location)

        Me.LocationToOverride = Location

        Me.CloseThisWindow()

    End Sub
    Private Sub RadButtonLocationCancel_Click(sender As Object, e As EventArgs) Handles RadButtonLocationCancel.Click

        Me.CloseThisWindow()

    End Sub

#End Region

#End Region

End Class