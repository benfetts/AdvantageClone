Namespace ProjectManagement.Reports.Presentation

    Public Class EstimatePrintingCommentsDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            EstimateComment
            EstimateFunctionComment
        End Enum

#End Region

#Region " Variables "

        Private _EstimateNumbers As Generic.List(Of Integer) = Nothing
        Private _Type As EstimatePrintingCommentsDialog.Type = Type.EstimateComment

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(Type As EstimatePrintingCommentsDialog.Type, EstimateNumbers As Generic.List(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Type = Type
            _EstimateNumbers = EstimateNumbers

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Type As EstimatePrintingCommentsDialog.Type, EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimateNumbers As Generic.List(Of Integer) = Nothing

            EstimateNumbers = New Generic.List(Of Integer)

            If EstimateQuotes IsNot Nothing Then

                EstimateNumbers = EstimateQuotes.Select(Function(Entity) Entity.EstimateNumber).Distinct.ToList

            End If

            ShowFormDialog = ShowFormDialog(Type, EstimateNumbers)

        End Function
        Public Shared Function ShowFormDialog(Type As EstimatePrintingCommentsDialog.Type, EstimateNumbers As Generic.List(Of Integer)) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimatePrintingCommentsDialog As EstimatePrintingCommentsDialog = Nothing

            EstimatePrintingCommentsDialog = New EstimatePrintingCommentsDialog(Type, EstimateNumbers)

            ShowFormDialog = EstimatePrintingCommentsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateQuotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EstimateComments As Generic.List(Of AdvantageFramework.Database.Views.EstimateComment) = Nothing
            Dim EstimateFunctionComments As Generic.List(Of AdvantageFramework.Database.Views.EstimateFunctionComment) = Nothing

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewForm_Comments.ItemDescription = "Comment(s)"

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            If _Type = Type.EstimateComment Then

                Me.Text = "Estimate Comments"

            ElseIf _Type = Type.EstimateFunctionComment Then

                Me.Text = "Estimate Function Comments"

            End If

            If _EstimateNumbers IsNot Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If _Type = Type.EstimateComment Then

                            EstimateComments = DbContext.GetQuery(Of AdvantageFramework.Database.Views.EstimateComment).Where(Function(Entity) _EstimateNumbers.Contains(Entity.EstimateNumber) = True).ToList

                        ElseIf _Type = Type.EstimateFunctionComment Then

                            EstimateFunctionComments = DbContext.GetQuery(Of AdvantageFramework.Database.Views.EstimateFunctionComment).Where(Function(Entity) _EstimateNumbers.Contains(Entity.EstimateNumber) = True).ToList

                        End If

                    End Using

                Catch ex As Exception

                End Try

            End If

            If _Type = Type.EstimateComment Then

                If EstimateComments IsNot Nothing Then

                    DataGridViewForm_Comments.DataSource = EstimateComments.Select(Function(Entity) New AdvantageFramework.Estimate.Printing.Classes.EPEstimateComment(Entity)).ToList

                Else

                    DataGridViewForm_Comments.DataSource = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EPEstimateComment)

                End If

            ElseIf _Type = Type.EstimateFunctionComment Then

                If EstimateFunctionComments IsNot Nothing Then

                    DataGridViewForm_Comments.DataSource = EstimateFunctionComments.Select(Function(Entity) New AdvantageFramework.Estimate.Printing.Classes.EPEstimateFunctionComment(Entity)).ToList

                Else

                    DataGridViewForm_Comments.DataSource = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EPEstimateFunctionComment)

                End If

            End If

            DataGridViewForm_Comments.CurrentView.BestFitColumns()

            If _EstimateNumbers IsNot Nothing AndAlso _EstimateNumbers.Count = 1 Then

                If _Type = Type.EstimateComment Then

                    'DataGridViewForm_Comments.MakeColumnNotVisible(AdvantageFramework.Estimate.Printing.Classes.EstimateComment.Properties.EstimateNumber.ToString)

                ElseIf _Type = Type.EstimateFunctionComment Then

                    'DataGridViewForm_Comments.MakeColumnNotVisible(AdvantageFramework.Estimate.Printing.Classes.EstimateFunctionComment.Properties.EstimateNumber.ToString)

                End If

            End If

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
            Dim EstimateComments As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EPEstimateComment) = Nothing
            Dim EstimateFunctionComments As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EPEstimateFunctionComment) = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                DataGridViewForm_Comments.CurrentView.CloseEditorForUpdating()

                If _Type = Type.EstimateComment Then

                    EstimateComments = DataGridViewForm_Comments.GetAllModifiedRows.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EPEstimateComment)().ToList

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each EstimateComment In EstimateComments


                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_LOG] SET EST_LOG_COMMENT = {0}, EST_LOG_COMMENT_HTML = {0} WHERE [ESTIMATE_NUMBER] = {1}",
                                                                                If(String.IsNullOrWhiteSpace(EstimateComment.Comment) = False, "'" & EstimateComment.Comment.Replace("'", "''") & "'", "NULL"),
                                                                                EstimateComment.EstimateNumber))

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_COMPONENT] SET EST_COMP_COMMENT = {0}, EST_COMP_COMMENT_HTML = {0} WHERE [ESTIMATE_NUMBER] = {1} AND [EST_COMPONENT_NBR] = {2}",
                                                                                If(String.IsNullOrWhiteSpace(EstimateComment.CompComment) = False, "'" & EstimateComment.CompComment.Replace("'", "''") & "'", "NULL"),
                                                                                EstimateComment.EstimateNumber, EstimateComment.EstimateComponentNumber))

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_QUOTE] SET EST_QTE_COMMENT = {0}, EST_QTE_COMMENT_HTML = {0} WHERE [ESTIMATE_NUMBER] = {1} AND [EST_COMPONENT_NBR] = {2} AND [EST_QUOTE_NBR] = {3}",
                                                                               If(String.IsNullOrWhiteSpace(EstimateComment.QuoteComment) = False, "'" & EstimateComment.QuoteComment.Replace("'", "''") & "'", "NULL"),
                                                                               EstimateComment.EstimateNumber, EstimateComment.EstimateComponentNumber, EstimateComment.QuoteNumber))


                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                ElseIf _Type = Type.EstimateFunctionComment Then

                    EstimateFunctionComments = DataGridViewForm_Comments.GetAllModifiedRows.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EPEstimateFunctionComment)().ToList

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each EstimateFunctionComment In EstimateFunctionComments


                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_REV_DET] SET EST_FNC_COMMENT = {0}, EST_FNC_COMMENT_HTML = {0}, EST_REV_SUP_BY_NTE = {1}, EST_REV_SUP_BY_HTML = {1} WHERE [ESTIMATE_NUMBER] = {2} AND [EST_COMPONENT_NBR] = {3} AND [EST_QUOTE_NBR] = {4} AND [EST_REV_NBR] = {5} AND [FNC_CODE] = '{6}'",
                                                                                If(String.IsNullOrWhiteSpace(EstimateFunctionComment.Comment) = False, "'" & EstimateFunctionComment.Comment.Replace("'", "''") & "'", "NULL"),
                                                                                If(String.IsNullOrWhiteSpace(EstimateFunctionComment.SuppliedByNotes) = False, "'" & EstimateFunctionComment.SuppliedByNotes.Replace("'", "''") & "'", "NULL"),
                                                                                EstimateFunctionComment.EstimateNumber, EstimateFunctionComment.EstimateComponentNumber, EstimateFunctionComment.QuoteNumber, EstimateFunctionComment.RevisionNumber, EstimateFunctionComment.FunctionCode))




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