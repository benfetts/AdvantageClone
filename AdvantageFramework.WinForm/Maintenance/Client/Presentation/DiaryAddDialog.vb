Namespace Maintenance.Client.Presentation

    Public Class DiaryAddDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

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

        Private Sub New(ByVal AlertTypeID As Integer, ByVal AlertCategoryID As Integer, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _AlertTypeID = AlertTypeID
            _AlertCategoryID = AlertCategoryID
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            ButtonForm_Update.Visible = False

        End Sub
        Private Sub New(ByVal AlertID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _AlertID = AlertID

            ButtonForm_Add.Visible = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal AlertTypeID As Integer, ByVal AlertCategoryID As Integer, ByVal ClientCode As String, Optional DivisionCode As String = Nothing, Optional ProductCode As String = Nothing) As Windows.Forms.DialogResult

            'objects
            Dim DiaryDialog As Maintenance.Client.Presentation.DiaryAddDialog = Nothing

            DiaryDialog = New AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog(AlertTypeID, AlertCategoryID, ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = DiaryDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(ByVal AlertID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim DiaryDialog As Maintenance.Client.Presentation.DiaryAddDialog = Nothing

            DiaryDialog = New AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog(AlertID)

            ShowFormDialog = DiaryDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DiaryAddDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                TextBoxForm_Subject.SetPropertySettings(AdvantageFramework.Database.Entities.Alert.Properties.Subject)
                TextBoxForm_Subject.SetRequired(True)

                TextBoxForm_Body.SetPropertySettings(AdvantageFramework.Database.Entities.Alert.Properties.Body)

                If _AlertID IsNot Nothing Then

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, _AlertID)

                    If Alert IsNot Nothing Then

                        TextBoxForm_Subject.Text = Alert.Subject
                        TextBoxForm_Body.Text = Alert.Body

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The alert you are trying to edit does not exist.")

                    End If
                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Alert = New AdvantageFramework.Database.Entities.Alert

                    Alert.DbContext = DbContext
                    Alert.AlertTypeID = _AlertTypeID
                    Alert.AlertCategoryID = _AlertCategoryID
                    Alert.Subject = TextBoxForm_Subject.Text
                    Alert.Body = TextBoxForm_Body.Text
                    Alert.GeneratedDate = Now
                    Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.Normal
                    Alert.ClientCode = _ClientCode
                    Alert.DivisionCode = _DivisionCode
                    Alert.ProductCode = _ProductCode
                    Alert.EmailBody = TextBoxForm_Body.Text

                    If _ProductCode IsNot Nothing Then

                        Alert.AlertLevel = "PR"

                    ElseIf _DivisionCode IsNot Nothing Then

                        Alert.AlertLevel = "DI"

                    ElseIf _ClientCode IsNot Nothing Then

                        Alert.AlertLevel = "CL"

                    End If

                    Alert.UserCode = Me.Session.UserCode
                    Alert.EmployeeCode = Me.Session.User.EmployeeCode

                    Inserted = AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert)

                End Using

                If Inserted Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As EventArgs) Handles ButtonForm_Update.Click

            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, _AlertID)

                    Alert.Subject = TextBoxForm_Subject.Text
                    Alert.Body = TextBoxForm_Body.Text
                    Alert.EmailBody = TextBoxForm_Body.Text

                    If AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert) Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                End Using

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace