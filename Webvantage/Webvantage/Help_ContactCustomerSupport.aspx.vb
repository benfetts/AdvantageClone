Public Class Help_ContactCustomerSupport
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Form Event Handlers "

    Private Sub Help_ContactCustomerSupport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Me.PageTitle = "Contact Customer Support"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        TextBoxClientInformationName.Text = Agency.Name
                        TextBoxClientInformationPhone.Text = Agency.Phone
                        TextBoxAddress.Text = Agency.Address
                        TextBoxAddress2.Text = Agency.Address2
                        TextBoxCity.Text = Agency.City
                        TextBoxState.Text = Agency.State
                        TextBoxZip.Text = Agency.Zip

                    End If

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        TextBoxClientInformationEmployeeName.Text = Employee.ToString
                        TextBoxClientInformationEmailAddress.Text = Employee.Email

                    End If

                End Using

            Catch ex As Exception

            End Try

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarContactCustomerSupport_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarContactCustomerSupport.ButtonClick

        'objects
        Dim MessageSent As Boolean = False
        Dim ContactSupportMessage As AdvantageFramework.Help.Classes.ContactSupportMessage = Nothing
        Dim SupportInformation As String = ""
        Dim ApplicationVersion As String = ""
        Dim DatabaseVersion As String = ""
        Dim ErrorMessage As String = ""
        Dim Application As cApplication = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSend.Value

                If TextBoxClientInformationName.Text <> "" Then

                    If TextBoxClientInformationEmailAddress.Text <> "" Then

                        If CheckBoxTechnicalSupport.Checked OrElse CheckBoxSoftwareSupport.Checked Then

                            Try

                                ContactSupportMessage = New AdvantageFramework.Help.Classes.ContactSupportMessage

                                ContactSupportMessage.ContactTechincalSupport = CheckBoxTechnicalSupport.Checked
                                ContactSupportMessage.ContactSoftwareSupport = CheckBoxSoftwareSupport.Checked
                                ContactSupportMessage.Name = TextBoxClientInformationName.Text
                                ContactSupportMessage.EmployeeName = TextBoxClientInformationEmployeeName.Text
                                ContactSupportMessage.PhoneNumber = TextBoxClientInformationPhone.Text
                                ContactSupportMessage.EmailAddress = TextBoxClientInformationEmailAddress.Text
                                ContactSupportMessage.Address = TextBoxAddress.Text
                                ContactSupportMessage.Address2 = TextBoxAddress2.Text
                                ContactSupportMessage.City = TextBoxCity.Text
                                ContactSupportMessage.State = TextBoxState.Text
                                ContactSupportMessage.Zip = TextBoxZip.Text

                                If RadioButtonIssueTypeBug.Checked Then

                                    ContactSupportMessage.IssueType = AdvantageFramework.Help.IssueTypes.Bug

                                ElseIf RadioButtonIssueTypeEnhancement.Checked Then

                                    ContactSupportMessage.IssueType = AdvantageFramework.Help.IssueTypes.Enhancement

                                ElseIf RadioButtonIssueTypeProblem.Checked Then

                                    ContactSupportMessage.IssueType = AdvantageFramework.Help.IssueTypes.Problem

                                End If

                                If RadioButtonPriorityHigh.Checked Then

                                    ContactSupportMessage.Priorty = AdvantageFramework.AlertSystem.PriorityLevels.High

                                ElseIf RadioButtonPriorityMedium.Checked Then

                                    ContactSupportMessage.Priorty = AdvantageFramework.AlertSystem.PriorityLevels.Normal

                                ElseIf RadioButtonPriorityLow.Checked Then

                                    ContactSupportMessage.Priorty = AdvantageFramework.AlertSystem.PriorityLevels.Low

                                End If

                                ContactSupportMessage.Description = RadTextBoxDescriptionOfIssue.Text

                                Try

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Application = New cApplication(CStr(Session("ConnString")))

                                        ApplicationVersion = Application.GetWebvantageVersion
                                        DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

                                        SupportInformation &= "WV Application Version: " & ApplicationVersion & "<br></br>"
                                        SupportInformation &= "Database Version: " & DatabaseVersion & "<br></br>"

                                    End Using

                                Catch ex As Exception
                                    SupportInformation = ""
                                End Try

                                ContactSupportMessage.SupportInformation = SupportInformation

                                MessageSent = AdvantageFramework.Help.CreateAndSendSupportMessage(_Session, ContactSupportMessage, Nothing, ErrorMessage)

                            Catch ex As Exception

                            End Try

                            If MessageSent Then

                                Me.CloseThisWindow()

                            Else

                                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                            End If

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("Please select a support department.")

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a client email address.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please enter a client name.")

                End If

        End Select

    End Sub

#End Region

#End Region

End Class