Namespace WinForm.Presentation

    Public Class EmailCleanupForm

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

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmailCleanupForm As AdvantageFramework.WinForm.Presentation.EmailCleanupForm = Nothing

            EmailCleanupForm = New AdvantageFramework.WinForm.Presentation.EmailCleanupForm()

            EmailCleanupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmailCleanupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Import_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Import.Click

            'objects
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileLineCounter As Integer = 0
            Dim InternalEmailAddressList As Generic.List(Of InternalEmailAddress) = Nothing

            If Me.Validator Then

                InternalEmailAddressList = New Generic.List(Of InternalEmailAddress)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Try

                            StreamReader = New System.IO.StreamReader(TextBoxForm_EmailFile.Text)

                        Catch ex As Exception
                            StreamReader = Nothing
                        Finally

                            If StreamReader IsNot Nothing Then

                                FileLines = StreamReader.ReadToEnd.Split(vbCrLf)

                                StreamReader.Close()
                                StreamReader.Dispose()

                            End If

                        End Try

                        If FileLines.Count > 0 Then

                            For Each FileLine In FileLines

                                FileLineData = FileLine.Split(",")

                                If FileLineData.Length > 0 Then

                                    If AdvantageFramework.StringUtilities.IsValidEmailAddress(FileLineData(0).Trim) Then

                                        InternalEmailAddressList.Add(New InternalEmailAddress(FileLineData(0).Trim, False))

                                    End If

                                End If

                                FileLineCounter += 1

                            Next

                        End If

                    End Using

                Catch ex As Exception

                End Try

                DataGridViewForm_Emails.DataSource = InternalEmailAddressList

                DataGridViewForm_Emails.CurrentView.BestFitColumns()

                ButtonItemActions_Process.Enabled = DataGridViewForm_Emails.HasRows

            End If

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim InternalEmailAddressList As Generic.List(Of InternalEmailAddress) = Nothing
            Dim ProcessedCount As Integer = 0

            InternalEmailAddressList = DataGridViewForm_Emails.GetAllRowsDataBoundItems.OfType(Of InternalEmailAddress)().ToList

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each InternalEmailAddress In InternalEmailAddressList

                        If InternalEmailAddress.Processed = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CDP_CONTACT_HDR SET CP_USER = 0, CP_ALERTS = 0, EMAIL_RCPT = 0 WHERE EMAIL_ADDRESS = '{0}'", InternalEmailAddress.Email))

                            InternalEmailAddress.Processed = True

                            ProcessedCount += 1

                        End If

                    Next

                End Using

            Catch ex As Exception

            End Try

            Try

                DataGridViewForm_Emails.DataSource = InternalEmailAddressList

                DataGridViewForm_Emails.CurrentView.BestFitColumns()

                ButtonItemActions_Process.Enabled = DataGridViewForm_Emails.HasRows

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            AdvantageFramework.WinForm.MessageBox.Show("Processed " & ProcessedCount)

        End Sub
        Private Sub DataGridViewForm_Emails_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Emails.SelectionChangedEvent

            ButtonItemActions_Process.Enabled = DataGridViewForm_Emails.HasRows

        End Sub

#End Region

#End Region

        Private Class InternalEmailAddress

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

            Private _Email As String = ""
            Private _Processed As Boolean = False

#End Region

#Region " Properties "

            Public Property Email As String
                Get
                    Email = _Email
                End Get
                Set(ByVal value As String)
                    _Email = value
                End Set
            End Property
            Public Property Processed As Boolean
                Get
                    Processed = _Processed
                End Get
                Set(ByVal value As Boolean)
                    _Processed = value
                End Set
            End Property

#End Region

#Region " Methods "

            Public Sub New(ByVal Email As String, ByVal Processed As Boolean)

                _Email = Email
                _Processed = Processed

            End Sub

#End Region

        End Class

    End Class

End Namespace
