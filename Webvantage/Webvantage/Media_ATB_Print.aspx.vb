Public Class Media_ATB_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ATBNumber As Integer = Nothing
    Private _RevisionNumber As Short = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadLocations()

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            RadComboBox_LocationID.Items.Clear()
            RadComboBox_LocationID.DataTextField = "Description"
            RadComboBox_LocationID.DataValueField = "ID"

            RadComboBox_LocationID.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Location.Load(DataContext) _
                                                 Select Entity.ID, _
                                                        Entity.Name).ToList.Select(Function(Location) New With {.ID = Location.ID, _
                                                                                                                .Description = Location.ID & " - " & Location.Name}).ToList
            RadComboBox_LocationID.DataBind()

            RadComboBox_LocationID.Items.Add(New Telerik.Web.UI.RadComboBoxItem("None", ""))

        End Using

    End Sub
    Private Sub LoadUserSettings()

        'objects
        Dim AppVarList As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
        Dim ReportTitle As String = ""
        Dim SignatureLines As Integer = 0
        Dim LocationID As String = ""
        Dim DefaultReportType As String = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                AppVarList = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, _Session.UserCode, "ATBPrint").ToList

            Catch ex As Exception
                AppVarList = Nothing
            End Try

            ReportTitle = "Authorization to Buy Digital Media"
            SignatureLines = 0
            LocationID = ""
            DefaultReportType = "Form"

            If AppVarList IsNot Nothing Then

                For Each AppVar In AppVarList

                    Try

                        If String.IsNullOrEmpty(AppVar.Value) = False Then

                            Select Case AppVar.Name

                                Case "ReportTitle"

                                    ReportTitle = AppVar.Value

                                Case "SignatureLines"

                                    If IsNumeric(AppVar.Value) AndAlso CInt(AppVar.Value) >= 0 AndAlso CInt(AppVar.Value) <= 4 Then

                                        SignatureLines = CInt(AppVar.Value)

                                    End If

                                Case "LocationID"

                                    LocationID = AppVar.Value

                                Case "DefaultReportType"

                                    DefaultReportType = AppVar.Value

                            End Select

                        End If

                    Catch ex As Exception

                    End Try

                Next

            End If

            RadComboBox_LocationID.SelectedValue = LocationID
            RadComboBox_ReportFormat.SelectedValue = DefaultReportType
            RadComboBox_Signature.SelectedValue = CStr(SignatureLines)
            TextBox_ReportTitle.Text = ReportTitle

        End Using

    End Sub
    Private Sub Print()

        'objects
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim MediaATBRevisionList As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevision) = Nothing
        Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
        Dim Filename As String = Nothing

        Try

            SaveSettings()

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevisionList = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.Load(DbContext).Include("MediaATB").Include("MediaATB.Client").Include("MediaATB.Division").Include("MediaATB.Product").Include("Campaign").Include("SalesClass")
                                        Where Entity.ATBNumber = _ATBNumber AndAlso
                                              Entity.RevisionNumber = _RevisionNumber
                                        Select Entity).ToList

                ParameterDictionary("DataSource") = MediaATBRevisionList
                ParameterDictionary("SignatureLines") = CShort(RadComboBox_Signature.SelectedValue)
                ParameterDictionary("ReportTitle") = TextBox_ReportTitle.Text

                If RadComboBox_LocationID.SelectedValue <> "" Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        ParameterDictionary("Location") = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, RadComboBox_LocationID.SelectedValue)

                    End Using

                Else

                    ParameterDictionary("Location") = Nothing

                End If

                If RadComboBox_ReportFormat.SelectedValue = "Form" Then

                    ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMediaForm

                ElseIf RadComboBox_ReportFormat.SelectedValue = "Report" Then

                    ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMedia

                End If

                XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Filename = "ATB_" & AdvantageFramework.StringUtilities.PadWithCharacter(_ATBNumber.ToString, 6, "0", True) & "_" & AdvantageFramework.StringUtilities.PadWithCharacter(_RevisionNumber.ToString, 3, "0", True)

            End Using

            If XtraReport IsNot Nothing Then

                MemoryStream = New System.IO.MemoryStream

                XtraReport.CreateDocument()

                XtraReport.ExportToPdf(MemoryStream)

                System.Web.HttpContext.Current.Response.Clear()

                System.Web.HttpContext.Current.Response.Buffer = True
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/pdf")
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & Filename & ".pdf")
                System.Web.HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray)

                HttpContext.Current.ApplicationInstance.CompleteRequest()

                Try

                    System.Web.HttpContext.Current.Response.End()

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        'objects
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim ProductCode As String = Nothing
        Dim Mode As Webvantage.BasePrintSendPage.PageMode = Nothing

        Try

            SaveSettings()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, _ATBNumber, _RevisionNumber)

                If MediaATBRevision IsNot Nothing Then

                    ClientCode = MediaATBRevision.MediaATB.ClientCode
                    DivisionCode = MediaATBRevision.MediaATB.DivisionCode
                    ProductCode = MediaATBRevision.MediaATB.ProductCode

                End If

            End Using

            QueryString = New AdvantageFramework.Web.QueryString

            With QueryString

                .Page = "Alert_New.aspx"
                .Add("f", CInt(MiscFN.Source_App.MediaATB).ToString())
                .Add("ATBNum", _ATBNumber.ToString)
                .Add("ATBRev", _RevisionNumber.ToString)
                .Add("cli", ClientCode)
                .Add("div", DivisionCode)
                .Add("prd", ProductCode)
                .Add("assn", If(IsAssignment = True, 1, 0))
                .Add("eml", If(IsAssignment = True, 0, If(AsEmail = True, 1, 0)))
                .Add("send", 1)
                .Add("pagetype", "atb")

            End With

            Dim StrURL As String = String.Empty

            If IsAssignment = True Then

                QueryString.Add("caller", "MediaATBPrint")
                StrURL = QueryString.ToString(True)
                StrURL = StrURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")
                Me.OpenWindow("New Assignment", strURL)

            Else

                QueryString.Add("caller", "mediaatb")
                StrURL = QueryString.ToString(True)

                Me.OpenWindow("New Alert", StrURL)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SaveSettings()

        'objects
        Dim AppVarList As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
        Dim IsNew As Boolean = False

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                AppVarList = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, _Session.UserCode, "ATBPrint").ToList

            Catch ex As Exception
                AppVarList = Nothing
            End Try

            If AppVarList Is Nothing OrElse AppVarList.Count = 0 Then

                IsNew = True

                AppVarList = New Generic.List(Of AdvantageFramework.Database.Entities.AppVars)

                AppVarList.Add(New AdvantageFramework.Database.Entities.AppVars With {.Application = "ATBPrint",
                                                                                      .Name = "ReportTitle",
                                                                                      .Group = "0",
                                                                                      .UserCode = _Session.UserCode})

                AppVarList.Add(New AdvantageFramework.Database.Entities.AppVars With {.Application = "ATBPrint",
                                                                                      .Name = "SignatureLines",
                                                                                      .Group = "0",
                                                                                      .UserCode = _Session.UserCode})

                AppVarList.Add(New AdvantageFramework.Database.Entities.AppVars With {.Application = "ATBPrint",
                                                                                      .Name = "LocationID",
                                                                                      .Group = "0",
                                                                                      .UserCode = _Session.UserCode})

                AppVarList.Add(New AdvantageFramework.Database.Entities.AppVars With {.Application = "ATBPrint",
                                                                                      .Name = "DefaultReportType",
                                                                                      .Group = "0",
                                                                                      .UserCode = _Session.UserCode})


            End If

            For Each AppVar In AppVarList

                Select Case AppVar.Name

                    Case "ReportTitle"

                        AppVar.Value = CStr(TextBox_ReportTitle.Text)
                        AppVar.Type = "String"

                    Case "SignatureLines"

                        AppVar.Value = CInt(RadComboBox_Signature.SelectedValue)
                        AppVar.Type = "Integer"

                    Case "LocationID"

                        AppVar.Value = CStr(RadComboBox_LocationID.SelectedValue)
                        AppVar.Type = "String"

                    Case "DefaultReportType"

                        AppVar.Value = CStr(RadComboBox_ReportFormat.SelectedValue)
                        AppVar.Type = "String"

                End Select

                If IsNew Then

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                Else

                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                End If

            Next

        End Using

    End Sub
    Private Sub EnableOrDisableActions()

        If RadComboBox_ReportFormat.SelectedValue = "Form" Then

            RadComboBox_Signature.Enabled = True

        Else

            RadComboBox_Signature.Enabled = False

        End If

    End Sub
    Private Sub CheckUserRights()

        Dim CanPrint As Boolean = False

        CanPrint = Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

        If CanPrint = False Then

            RadToolbar_ATBPrint.FindItemByValue("Print").Enabled = False

        End If

    End Sub
    Private Function GetHighestRevisionNumber() As Integer

        'objects
        Dim HighestRevisionNumber As Integer = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                HighestRevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumber(DbContext, _ATBNumber)
                                         Select Entity.RevisionNumber).Max

            Catch ex As Exception
                HighestRevisionNumber = _RevisionNumber
            End Try

        End Using

        GetHighestRevisionNumber = HighestRevisionNumber

    End Function

#Region "  Form Event Handlers "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Request.QueryString("RevNbr") IsNot Nothing Then

                _RevisionNumber = CShort(Request.QueryString("RevNbr"))

            End If

        Catch ex As Exception
            _RevisionNumber = -1
        End Try

        Try

            If Request.QueryString("ATBNbr") IsNot Nothing Then

                _ATBNumber = CInt(Request.QueryString("ATBNbr"))

            End If

        Catch ex As Exception
            _ATBNumber = 0
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Print Authorization to Buy Digital Media"

        _RevisionNumber = GetHighestRevisionNumber()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            CheckUserRights()
            LoadLocations()
            LoadUserSettings()
            EnableOrDisableActions()

        End If

    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode

            Case PageMode.Print

                Me.Print()
                Me.CloseThisWindow()

            Case PageMode.SendAlert

                Me.SendAlert()
                Me.CloseThisWindow()

            Case PageMode.SendAssignment

                Me.SendAlert(False, True)
                Me.CloseThisWindow()

            Case PageMode.SendEmail

                Me.SendAlert(True, False)
                Me.CloseThisWindow()

            Case Else

        End Select

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadToolbar_ATBPrint_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbar_ATBPrint.ButtonClick

        Select Case e.Item.Value
            Case "Print"

                Me.Print()

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Save"

                Me.SaveSettings()

        End Select

    End Sub
    Protected Sub RadComboBox_ReportFormat_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox_ReportFormat.SelectedIndexChanged

        EnableOrDisableActions()

    End Sub

#End Region

#End Region

End Class
