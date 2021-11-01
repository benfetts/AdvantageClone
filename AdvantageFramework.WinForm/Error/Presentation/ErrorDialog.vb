Namespace [Error].Presentation

    Friend Class ErrorDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Exception As Exception = Nothing

#End Region

#Region " Properties "

        Private WriteOnly Property Exception() As Exception
            Set(ByVal value As Exception)
                _Exception = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.


        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Exception As Exception) As System.Windows.Forms.DialogResult

            'objects
            Dim ErrorDialog As AdvantageFramework.Error.Presentation.ErrorDialog = Nothing
            Dim ShowDialog As Boolean = True

			AdvantageFramework.WinForm.Presentation.CloseWaitForm()

			If Exception IsNot Nothing Then

				If Exception.TargetSite IsNot Nothing AndAlso Exception.TargetSite.Module IsNot Nothing Then

					If Exception.TargetSite.Module.Name = "DevComponents.DotNetBar2.dll" AndAlso Exception.TargetSite.Name = "LeaveHotSubItem" Then

						ShowDialog = False

					ElseIf Exception.TargetSite.Module.Name = "System.Windows.Forms.dll" AndAlso Exception.TargetSite.Name = "CreateHandle" AndAlso
							Exception.Message = "Cannot access a disposed object. Object name: 'Bar'." Then

						ShowDialog = False

					End If

				End If

            End If

            If ShowDialog Then

                ErrorDialog = New AdvantageFramework.Error.Presentation.ErrorDialog

                ErrorDialog.Exception = Exception

                ShowFormDialog = ErrorDialog.ShowDialog()

            Else

                ShowFormDialog = Windows.Forms.DialogResult.OK

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ErrorDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ErrorDetail As String = ""

            If Me.Session IsNot Nothing Then

                ButtonForm_OK.AutoExpandOnClick = True
                ButtonItemOK_CloseWithSendingErrorToSupport.Visible = True
                ButtonItemOK_CloseWithoutSendingErrorToSupport.Visible = True

            Else

                ButtonForm_OK.AutoExpandOnClick = False
                ButtonForm_OK.SubItems.Remove(ButtonItemOK_CloseWithSendingErrorToSupport)
                ButtonForm_OK.SubItems.Remove(ButtonItemOK_CloseWithoutSendingErrorToSupport)

            End If

            If _Exception IsNot Nothing Then

                ErrorDetail = "Assembly: " & _Exception.TargetSite.Module.Assembly.FullName & vbCrLf
                ErrorDetail &= "Module: " & _Exception.TargetSite.Module.Name & vbCrLf
                ErrorDetail &= "Method: " & _Exception.TargetSite.Name & vbCrLf
                ErrorDetail &= "Error Message: " & _Exception.Message & vbCrLf
                ErrorDetail &= "Stack Trace: " & vbCrLf & _Exception.StackTrace

                LabelForm_Message.Text = _Exception.Message
                LabelForm_MessageImage.Image = AdvantageFramework.My.Resources.ErrorImage

            End If

            TextBoxDetails_ErrorDetails.Text = ErrorDetail

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Session Is Nothing Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemOK_CloseWithSendingErrorToSupport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOK_CloseWithSendingErrorToSupport.Click

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ContactSupportMessage As AdvantageFramework.Help.Classes.ContactSupportMessage = Nothing
            Dim ErrorMessage As String = ""
            Dim SupportInformation As String = ""
            Dim Exception As Exception = Nothing
            Dim ScreenShotImages As Generic.List(Of System.Drawing.Image) = Nothing
            Dim ApplicationVersion As String = ""
            Dim DatabaseVersion As String = ""

            If Me.Session IsNot Nothing Then

                Me.FormAction = WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Sending...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ContactSupportMessage = New AdvantageFramework.Help.Classes.ContactSupportMessage

                        ContactSupportMessage.ContactTechincalSupport = True
                        ContactSupportMessage.ContactSoftwareSupport = True

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            ContactSupportMessage.Name = Agency.Name
                            ContactSupportMessage.PhoneNumber = Agency.Phone
                            ContactSupportMessage.Address = Agency.Address
                            ContactSupportMessage.Address2 = Agency.Address2
                            ContactSupportMessage.City = Agency.City
                            ContactSupportMessage.State = Agency.State
                            ContactSupportMessage.Zip = Agency.Zip

                        End If

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                        If Employee IsNot Nothing Then

                            ContactSupportMessage.EmployeeName = Employee.ToString
                            ContactSupportMessage.EmailAddress = Employee.Email

                        End If

                        ContactSupportMessage.IssueType = AdvantageFramework.Help.IssueTypes.Bug

                        ContactSupportMessage.Priorty = AlertSystem.PriorityLevels.Normal

                        ContactSupportMessage.Description = "Auto generated error report for error --> " & _Exception.Message

                        Try

                            Try

                                ApplicationVersion = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00")
                                DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

                                SupportInformation &= "Application Version: " & ApplicationVersion & "<br></br>"
                                SupportInformation &= "Database Version: " & DatabaseVersion & "<br></br>"

                                SupportInformation &= "<br></br>" & "<br></br>" & "<br></br>"

                            Catch ex As Exception

                            End Try

                            Try

                                If _Exception.TargetSite IsNot Nothing Then

                                    SupportInformation &= "Assembly: " & _Exception.TargetSite.Module.Assembly.FullName & "<br></br>"
                                    SupportInformation &= "Module: " & _Exception.TargetSite.Module.Name & "<br></br>"
                                    SupportInformation &= "Method: " & _Exception.TargetSite.Name & "<br></br>"

                                Else

                                    SupportInformation &= "Assembly: " & "<br></br>"
                                    SupportInformation &= "Module:  " & "<br></br>"
                                    SupportInformation &= "Method:  " & "<br></br>"

                                End If

                            Catch ex As Exception

                            End Try

                            SupportInformation &= "Error Message: " & _Exception.Message & "<br></br>"
                            SupportInformation &= "Stack Trace: " & "<br></br>" & If(String.IsNullOrEmpty(_Exception.StackTrace), "", _Exception.StackTrace.Replace(vbCrLf, "<br></br>"))

                            Exception = _Exception

                            Do While Exception.InnerException IsNot Nothing

                                SupportInformation &= "<br></br>" & "<br></br>" & "<br></br>"

                                Try

                                    If Exception.TargetSite IsNot Nothing Then

                                        SupportInformation &= "Assembly: " & Exception.TargetSite.Module.Assembly.FullName & "<br></br>"
                                        SupportInformation &= "Module: " & Exception.TargetSite.Module.Name & "<br></br>"
                                        SupportInformation &= "Method: " & Exception.TargetSite.Name & "<br></br>"

                                    Else

                                        SupportInformation &= "Assembly: " & "<br></br>"
                                        SupportInformation &= "Module:  " & "<br></br>"
                                        SupportInformation &= "Method:  " & "<br></br>"

                                    End If

                                Catch ex As Exception

                                End Try

                                SupportInformation &= "Error Message: " & Exception.Message & "<br></br>"
                                SupportInformation &= "Stack Trace: " & "<br></br>" & If(String.IsNullOrEmpty(Exception.StackTrace), "", Exception.StackTrace.Replace(vbCrLf, "<br></br>"))

                                Exception = Exception.InnerException

                            Loop

                        Catch ex As Exception

                        End Try

                        ContactSupportMessage.SupportInformation = SupportInformation

                        ScreenShotImages = New Generic.List(Of System.Drawing.Image)

                        Try

                            ScreenShotImages.Add(AdvantageFramework.WinForm.Presentation.TakeScreenCapture(Me.Owner, False))

                        Catch ex As Exception

                        End Try

                    End Using

                    AdvantageFramework.Help.CreateAndSendSupportMessage(Me.Session, ContactSupportMessage, ScreenShotImages, ErrorMessage)

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemOK_CloseWithoutSendingErrorToSupport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOK_CloseWithoutSendingErrorToSupport.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace