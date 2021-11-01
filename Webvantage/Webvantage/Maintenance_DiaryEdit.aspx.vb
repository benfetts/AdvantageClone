Public Class Maintenance_DiaryEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _AlertTypeID As Integer = Nothing
    Private _AlertCategoryID As Integer = Nothing
    Private _ClientCode As String = Nothing
    Private _DivisionCode As String = Nothing
    Private _ProductCode As String = Nothing
    Private _AlertID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadAlert()

        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, _AlertID)

            If Alert IsNot Nothing Then

                TextBoxSubject.Text = Alert.Subject
                TextBoxBody.Text = Alert.Body

            Else

                Me.ShowMessage("The alert you are trying to edit does not exist.")

            End If

        End Using

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        TextBoxSubject.CssClass = "RequiredInput"

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Alert.Properties.Subject, TextBoxSubject)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Alert.Properties.Body, TextBoxBody)

    End Sub
    Private Function Insert() As Boolean

        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim ErrorMessage As String = ""
        Dim Inserted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Alert = New AdvantageFramework.Database.Entities.Alert

                Alert.DbContext = DbContext
                Alert.AlertTypeID = _AlertTypeID
                Alert.AlertCategoryID = _AlertCategoryID
                Alert.Subject = TextBoxSubject.Text
                Alert.Body = TextBoxBody.Text
                Alert.GeneratedDate = Now
                Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.Normal
                Alert.ClientCode = _ClientCode
                Alert.DivisionCode = _DivisionCode
                Alert.ProductCode = _ProductCode
                Alert.EmailBody = TextBoxBody.Text

                If _ProductCode IsNot Nothing Then

                    Alert.AlertLevel = "PR"

                ElseIf _DivisionCode IsNot Nothing Then

                    Alert.AlertLevel = "DI"

                ElseIf _ClientCode IsNot Nothing Then

                    Alert.AlertLevel = "CL"

                End If

                Alert.UserCode = _Session.UserCode
                Alert.EmployeeCode = _Session.User.EmployeeCode

                Inserted = AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert)

            End Using

            If Not Inserted Then

                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

            End If

        Catch ex As Exception
            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Insert = Inserted

    End Function
    Private Function Save() As Boolean

        'objects
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim ErrorMessage As String = ""
        Dim Saved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, _AlertID)

                Alert.Subject = TextBoxSubject.Text
                Alert.Body = TextBoxBody.Text
                Alert.EmailBody = TextBoxBody.Text

                Saved = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

            End Using

            If Not Saved Then

                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

            End If

        Catch ex As Exception
            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Save = Saved

    End Function

#Region "  Form Event Handlers "

    Private Sub Maintenance_DiaryEdit_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Request.QueryString("Caller") IsNot Nothing Then

            _Caller = Request.QueryString("Caller").ToString

        End If

        If Request.QueryString("Mode") IsNot Nothing Then

            If Request.QueryString("Mode").ToString = "Add" Then

                If Request.QueryString("AlertTypeID") IsNot Nothing Then

                    _AlertTypeID = Request.QueryString("AlertTypeID").ToString

                End If

                If Request.QueryString("AlertCategoryID") IsNot Nothing Then

                    _AlertCategoryID = Request.QueryString("AlertCategoryID").ToString

                End If

                If Request.QueryString("ClientCode") IsNot Nothing Then

                    _ClientCode = Request.QueryString("ClientCode").ToString

                End If

                If Request.QueryString("DivisionCode") IsNot Nothing Then

                    _DivisionCode = Request.QueryString("DivisionCode").ToString

                End If

                If Request.QueryString("ProductCode") IsNot Nothing Then

                    _ProductCode = Request.QueryString("ProductCode").ToString

                End If

            ElseIf Request.QueryString("Mode").ToString = "Update" Then

                If Request.QueryString("AlertID") IsNot Nothing AndAlso IsNumeric(Request.QueryString("AlertID")) Then

                    _AlertID = Request.QueryString("AlertID")

                End If

            End If

        End If

    End Sub
    Private Sub Maintenance_DiaryEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Diary"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadControlSettings(DbContext)

                If _AlertID IsNot Nothing Then

                    LoadAlert()

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarDiary_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDiary.ButtonClick

        Select Case e.Item.Value

            Case "Save"

                If _AlertID Is Nothing Then

                    If Insert() Then

                        If _Caller = "Desktop_CRMCentral" Then

                            Webvantage.Desktop_CRMCentral.SetGridSelectVariables(_ClientCode, _DivisionCode, _ProductCode)

                        End If

                        Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx")

                    End If

                Else

                    If Save() Then

                        Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx")

                    End If

                End If

            Case Else

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#End Region

End Class
