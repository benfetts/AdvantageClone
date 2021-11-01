Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingCommentsDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            JobComment
            JobFunctionComment
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumbers As Generic.List(Of Integer) = Nothing
        Private _Type As InvoicePrintingCommentsDialog.Type = Type.JobComment

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(Type As InvoicePrintingCommentsDialog.Type, InvoiceNumbers As Generic.List(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Type = Type
            _InvoiceNumbers = InvoiceNumbers

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Type As InvoicePrintingCommentsDialog.Type, AccountRecievableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)) As System.Windows.Forms.DialogResult

            'objects
            Dim InvoiceNumbers As Generic.List(Of Integer) = Nothing

            InvoiceNumbers = New Generic.List(Of Integer)

            If AccountRecievableInvoices IsNot Nothing Then

                InvoiceNumbers = AccountRecievableInvoices.Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList

            End If

            ShowFormDialog = ShowFormDialog(Type, InvoiceNumbers)

        End Function
        Public Shared Function ShowFormDialog(Type As InvoicePrintingCommentsDialog.Type, InvoiceNumbers As Generic.List(Of Integer)) As System.Windows.Forms.DialogResult

            'objects
            Dim InvoicePrintingCommentsDialog As InvoicePrintingCommentsDialog = Nothing

            InvoicePrintingCommentsDialog = New InvoicePrintingCommentsDialog(Type, InvoiceNumbers)

            ShowFormDialog = InvoicePrintingCommentsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoicePrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim InvoiceJobComments As Generic.List(Of AdvantageFramework.Database.Views.InvoiceJobComment) = Nothing
            Dim InvoiceJobFunctionComments As Generic.List(Of AdvantageFramework.Database.Views.InvoiceJobFunctionComment) = Nothing

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewForm_Comment.ItemDescription = "Comment(s)"
            DataGridViewForm_Comment.OptionsView.ColumnAutoWidth = True
            DataGridViewForm_Comment.OptionsView.BestFitMaxRowCount = -1

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            If _Type = Type.JobComment Then

                Me.Text = "Job Comments"

            ElseIf _Type = Type.JobFunctionComment Then

                Me.Text = "Job Function Comments"

            End If

            If _InvoiceNumbers IsNot Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If _Type = Type.JobComment Then

                            InvoiceJobComments = DbContext.GetQuery(Of AdvantageFramework.Database.Views.InvoiceJobComment).Where(Function(Entity) _InvoiceNumbers.Contains(Entity.InvoiceNumber) = True).ToList

                        ElseIf _Type = Type.JobFunctionComment Then

                            InvoiceJobFunctionComments = DbContext.GetQuery(Of AdvantageFramework.Database.Views.InvoiceJobFunctionComment).Where(Function(Entity) _InvoiceNumbers.Contains(Entity.InvoiceNumber) = True).ToList

                        End If

                    End Using

                Catch ex As Exception

                End Try

            End If

            If _Type = Type.JobComment Then

                If InvoiceJobComments IsNot Nothing Then

                    DataGridViewForm_Comment.DataSource = InvoiceJobComments.Select(Function(Entity) New AdvantageFramework.InvoicePrinting.Classes.BillingJobComment(Entity)).ToList

                Else

                    DataGridViewForm_Comment.DataSource = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.BillingJobComment)

                End If

                'DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.Comment.ToString).MinWidth = 200

            ElseIf _Type = Type.JobFunctionComment Then

                If InvoiceJobFunctionComments IsNot Nothing Then

                    DataGridViewForm_Comment.DataSource = InvoiceJobFunctionComments.Select(Function(Entity) New AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment(Entity)).ToList

                Else

                    DataGridViewForm_Comment.DataSource = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment)

                End If

                'DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.Comment.ToString).MinWidth = 200

            End If

            If _InvoiceNumbers IsNot Nothing AndAlso _InvoiceNumbers.Count = 1 Then

                If _Type = Type.JobComment Then

                    DataGridViewForm_Comment.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.InvoiceNumber.ToString)

                ElseIf _Type = Type.JobFunctionComment Then

                    DataGridViewForm_Comment.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.InvoiceNumber.ToString)

                End If

            Else

                If _Type = Type.JobComment Then

                    DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.InvoiceNumber.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.InvoiceNumber.ToString).GetBestWidth()
                    DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.InvoiceNumber.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.InvoiceNumber.ToString).MaxWidth

                ElseIf _Type = Type.JobFunctionComment Then

                    DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.InvoiceNumber.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.InvoiceNumber.ToString).GetBestWidth()
                    DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.InvoiceNumber.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.InvoiceNumber.ToString).MaxWidth

                End If

            End If

            If _Type = Type.JobComment Then

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponent.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponent.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponent.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponent.ToString).MaxWidth

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobDescription.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobDescription.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobDescription.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobDescription.ToString).MaxWidth

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponentDescription.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponentDescription.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponentDescription.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobComment.Properties.JobComponentDescription.ToString).MaxWidth

            ElseIf _Type = Type.JobFunctionComment Then

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponent.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponent.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponent.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponent.ToString).MaxWidth

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobDescription.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobDescription.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobDescription.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobDescription.ToString).MaxWidth

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponentDescription.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponentDescription.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponentDescription.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.JobComponentDescription.ToString).MaxWidth

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionCode.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionCode.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionCode.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionCode.ToString).MaxWidth

                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionDescription.ToString).MaxWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionDescription.ToString).GetBestWidth()
                DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionDescription.ToString).MinWidth = DataGridViewForm_Comment.Columns(AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment.Properties.FunctionDescription.ToString).MaxWidth

            End If

            DataGridViewForm_Comment.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub InvoicePrintingOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub InvoicePrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim BillingJobComments As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.BillingJobComment) = Nothing
            Dim BillingJobFunctionComments As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment) = Nothing
            Dim ErrorMessage As String = ""
            Dim FunctionSource As Short = -1
            Dim CommentSource As Short = -1
            Dim Functions As Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
            Dim [Function] As AdvantageFramework.Database.Core.Function = Nothing

            If Me.Validator Then

                DataGridViewForm_Comment.CurrentView.CloseEditorForUpdating()

                If _Type = Type.JobComment Then

                    BillingJobComments = DataGridViewForm_Comment.GetAllModifiedRows.OfType(Of AdvantageFramework.InvoicePrinting.Classes.BillingJobComment)().ToList

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each BillingJobComment In BillingJobComments

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[BILL_COMMENTS_JOB] WHERE [INV_NBR] = {0} AND [JOB_NUMBER] = {1} AND [JOB_COMPONENT_NBR] = {2}", BillingJobComment.InvoiceNumber, BillingJobComment.JobNumber, BillingJobComment.JobComponentNumber)).FirstOrDefault = 0 Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[BILL_COMMENTS_JOB]([INV_NBR], [JOB_NUMBER], [JOB_COMPONENT_NBR], [JOB_COMMENT], [COMMENT_SOURCE]) VALUES ({0},{1},{2},{3},0)",
                                                                                    BillingJobComment.InvoiceNumber, BillingJobComment.JobNumber, BillingJobComment.JobComponentNumber,
                                                                                    If(String.IsNullOrWhiteSpace(BillingJobComment.Comment) = False, "'" & BillingJobComment.Comment.Replace("'", "''") & "'", "NULL")))

                                Else

                                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[BILL_COMMENTS_JOB] SET JOB_COMMENT = {0}, COMMENT_SOURCE = 0 WHERE [INV_NBR] = {1} AND [JOB_NUMBER] = {2} AND [JOB_COMPONENT_NBR] = {3}",
                                                                                    If(String.IsNullOrWhiteSpace(BillingJobComment.Comment) = False, "'" & BillingJobComment.Comment.Replace("'", "''") & "'", "NULL"),
                                                                                    BillingJobComment.InvoiceNumber, BillingJobComment.JobNumber, BillingJobComment.JobComponentNumber))

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                ElseIf _Type = Type.JobFunctionComment Then

                    BillingJobFunctionComments = DataGridViewForm_Comment.GetAllModifiedRows.OfType(Of AdvantageFramework.InvoicePrinting.Classes.BillingJobFunctionComment)().ToList

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Functions = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).ToList

                            For Each BillingJobFunctionComment In BillingJobFunctionComments

                                FunctionSource = BillingJobFunctionComment.FunctionSource.GetValueOrDefault(-1)
                                CommentSource = BillingJobFunctionComment.CommentSource.GetValueOrDefault(-1)

                                If BillingJobFunctionComment.HasFunctionDescriptionChanged Then

                                    FunctionSource = 0

                                    Try

                                        [Function] = Functions.SingleOrDefault(Function(Entity) Entity.Code = BillingJobFunctionComment.FunctionCode)

                                    Catch ex As Exception
                                        [Function] = Nothing
                                    End Try

                                    If [Function] IsNot Nothing Then

                                        If [Function].Description = BillingJobFunctionComment.FunctionDescription Then

                                            FunctionSource = 1

                                        End If

                                    End If

                                End If

                                If BillingJobFunctionComment.HasCommentChanged Then

                                    CommentSource = 0

                                End If

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[BILL_COMMENTS_DTL] WHERE [INV_NBR] = {0} AND [JOB_NUMBER] = {1} AND [JOB_COMPONENT_NBR] = {2} AND [FNC_CODE] = '{3}'", BillingJobFunctionComment.InvoiceNumber, BillingJobFunctionComment.JobNumber, BillingJobFunctionComment.JobComponentNumber, BillingJobFunctionComment.FunctionCode)).FirstOrDefault = 0 Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[BILL_COMMENTS_DTL]([INV_NBR], [JOB_NUMBER], [JOB_COMPONENT_NBR], [FNC_CODE], [DTL_COMMENT], [FNC_DESC], [FNC_DESC_SOURCE], [COMMENT_SOURCE]) VALUES ({0},{1},{2},'{3}',{4},{5},{6},{7})",
                                                                                    BillingJobFunctionComment.InvoiceNumber, BillingJobFunctionComment.JobNumber, BillingJobFunctionComment.JobComponentNumber, BillingJobFunctionComment.FunctionCode,
                                                                                    If(String.IsNullOrWhiteSpace(BillingJobFunctionComment.Comment) = False, "'" & BillingJobFunctionComment.Comment.Replace("'", "''") & "'", "NULL"),
                                                                                    If(String.IsNullOrWhiteSpace(BillingJobFunctionComment.FunctionDescription) = False, "'" & BillingJobFunctionComment.FunctionDescription.Replace("'", "''") & "'", "NULL"),
                                                                                    If(FunctionSource = -1, "NULL", FunctionSource), If(CommentSource = -1, "NULL", CommentSource)))

                                Else

                                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[BILL_COMMENTS_DTL] SET DTL_COMMENT = {0}, FNC_DESC = {1}, FNC_DESC_SOURCE = {6}, COMMENT_SOURCE = {7} WHERE [INV_NBR] = {2} AND [JOB_NUMBER] = {3} AND [JOB_COMPONENT_NBR] = {4} AND [FNC_CODE] = '{5}'",
                                                                                    If(String.IsNullOrWhiteSpace(BillingJobFunctionComment.Comment) = False, "'" & BillingJobFunctionComment.Comment.Replace("'", "''") & "'", "NULL"),
                                                                                    If(String.IsNullOrWhiteSpace(BillingJobFunctionComment.FunctionDescription) = False, "'" & BillingJobFunctionComment.FunctionDescription.Replace("'", "''") & "'", "NULL"),
                                                                                    BillingJobFunctionComment.InvoiceNumber, BillingJobFunctionComment.JobNumber, BillingJobFunctionComment.JobComponentNumber, BillingJobFunctionComment.FunctionCode,
                                                                                    If(FunctionSource = -1, "NULL", FunctionSource), If(CommentSource = -1, "NULL", CommentSource)))

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                End If

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace