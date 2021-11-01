Namespace Help.Presentation

    Public Class ContactSupportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim ContactSupportDialog As AdvantageFramework.Help.Presentation.ContactSupportDialog = Nothing

            ContactSupportDialog = New AdvantageFramework.Help.Presentation.ContactSupportDialog()

            ShowFormDialog = ContactSupportDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ContactSupportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            ButtonItemActions_Send.Image = AdvantageFramework.My.Resources.EmailSendImage

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            TextBoxClientInformation_Name.SetDefaultPropertySettings(IsRequired:=True, DisplayName:="Client Name")
            TextBoxClientInformation_EmailAddress.SetDefaultPropertySettings(IsRequired:=True, DisplayName:="Client Email")

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        TextBoxClientInformation_Name.Text = Agency.Name
                        TextBoxClientInformation_Phone.Text = Agency.Phone
                        AddressControlClientInformation_Address.Address = Agency.Address
                        AddressControlClientInformation_Address.Address2 = Agency.Address2
                        AddressControlClientInformation_Address.City = Agency.City
                        AddressControlClientInformation_Address.State = Agency.State
                        AddressControlClientInformation_Address.Zip = Agency.Zip

                    End If

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        TextBoxClientInformation_EmployeeName.Text = Employee.ToString
                        TextBoxClientInformation_EmailAddress.Text = Employee.Email

                    End If

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Send_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Send.Click

            'objects
            Dim MessageSent As Boolean = False
            Dim ContactSupportMessage As AdvantageFramework.Help.Classes.ContactSupportMessage = Nothing
            Dim SupportInformation As String = ""
            Dim ApplicationVersion As String = ""
            Dim DatabaseVersion As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If CheckBoxForm_TechnicalSupport.Checked OrElse CheckBoxForm_SoftwareSupport.Checked Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm("Sending...")

                    Try

                        ContactSupportMessage = New AdvantageFramework.Help.Classes.ContactSupportMessage

                        ContactSupportMessage.ContactTechincalSupport = CheckBoxForm_TechnicalSupport.Checked
                        ContactSupportMessage.ContactSoftwareSupport = CheckBoxForm_SoftwareSupport.Checked
                        ContactSupportMessage.Name = TextBoxClientInformation_Name.Text
                        ContactSupportMessage.PhoneNumber = TextBoxClientInformation_Phone.Text
                        ContactSupportMessage.EmployeeName = TextBoxClientInformation_EmployeeName.Text
                        ContactSupportMessage.EmailAddress = TextBoxClientInformation_EmailAddress.Text
                        ContactSupportMessage.Address = AddressControlClientInformation_Address.Address
                        ContactSupportMessage.Address2 = AddressControlClientInformation_Address.Address2
                        ContactSupportMessage.City = AddressControlClientInformation_Address.City
                        ContactSupportMessage.State = AddressControlClientInformation_Address.State
                        ContactSupportMessage.Zip = AddressControlClientInformation_Address.Zip

                        If RadioButtonIssueType_Bug.Checked Then

                            ContactSupportMessage.IssueType = IssueTypes.Bug

                        ElseIf RadioButtonIssueType_Enhancement.Checked Then

                            ContactSupportMessage.IssueType = IssueTypes.Enhancement

                        ElseIf RadioButtonIssueType_Problem.Checked Then

                            ContactSupportMessage.IssueType = IssueTypes.Problem

                        End If

                        If RadioButtonPriority_High.Checked Then

                            ContactSupportMessage.Priorty = AlertSystem.PriorityLevels.High

                        ElseIf RadioButtonPriority_Medium.Checked Then

                            ContactSupportMessage.Priorty = AlertSystem.PriorityLevels.Normal

                        ElseIf RadioButtonPriority_Low.Checked Then

                            ContactSupportMessage.Priorty = AlertSystem.PriorityLevels.Low

                        End If

                        ContactSupportMessage.Description = TextBoxForm_DescriptionOfIssue.Text

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                ApplicationVersion = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00")
                                DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

                                SupportInformation &= "Application Version: " & ApplicationVersion & "<br></br>"
                                SupportInformation &= "Database Version: " & DatabaseVersion & "<br></br>"

                            End Using

                        Catch ex As Exception
                            SupportInformation = ""
                        End Try

                        ContactSupportMessage.SupportInformation = SupportInformation

                        MessageSent = AdvantageFramework.Help.CreateAndSendSupportMessage(Me.Session, ContactSupportMessage, Nothing, ErrorMessage)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()
                    
                    If MessageSent Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select a support department.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace