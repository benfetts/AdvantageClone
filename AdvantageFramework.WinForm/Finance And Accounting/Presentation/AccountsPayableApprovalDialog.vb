Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableApprovalDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _AccountPayableID As Integer = Nothing
        Protected _OrderNumber As Integer = Nothing
        Protected _OrderLineNumber As Short = Nothing
        Protected _Status As Nullable(Of Short) = Nothing
        Protected _Comment As String = Nothing
        Protected _IsOnHold As Short = Nothing
        Protected _MediaType As AdvantageFramework.Database.Entities.MediaOrderType = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Status As Nullable(Of Short)
            Get
                Status = _Status
            End Get
        End Property
        Public ReadOnly Property Comment As String
            Get
                Comment = _Comment
            End Get
        End Property
        Public ReadOnly Property IsOnHold As Short
            Get
                IsOnHold = _IsOnHold
            End Get
        End Property
        Public ReadOnly Property MediaType As AdvantageFramework.Database.Entities.MediaOrderType
            Get
                MediaType = _MediaType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal AccountPayableID As Integer, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short, ByVal MediaType As AdvantageFramework.Database.Entities.MediaOrderType, _
                        ByVal Status As Nullable(Of Short), ByVal Comment As String, ByVal IsOnHold As Short)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _AccountPayableID = AccountPayableID
            _OrderNumber = OrderNumber
            _OrderLineNumber = OrderLineNumber
            _Status = Status
            _Comment = Comment
            _IsOnHold = IsOnHold
            _MediaType = MediaType

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal AccountPayableID As Integer, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short, ByVal MediaType As AdvantageFramework.Database.Entities.MediaOrderType, _
                                              ByRef Status As Nullable(Of Short), ByRef Comment As String, ByRef IsOnHold As Short) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableApprovalDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableApprovalDialog = Nothing

            AccountsPayableApprovalDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableApprovalDialog(AccountPayableID, OrderNumber, OrderLineNumber, MediaType, Status, Comment, IsOnHold)

            If IsOnHold = 1 Then

                AccountsPayableApprovalDialog.CheckBoxForm_OnHold.Checked = True

            End If

            ShowFormDialog = AccountsPayableApprovalDialog.ShowDialog()

            Status = AccountsPayableApprovalDialog.Status
            Comment = AccountsPayableApprovalDialog.Comment
            IsOnHold = AccountsPayableApprovalDialog.IsOnHold

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableApprovalDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim AccountPayableMediaApprovalDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMediaApprovalDetail) = Nothing
            Dim MediaCode As String = Nothing

            ComboBoxApproval_Status.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly), GetType(Int16))
            ComboBoxApproval_Status.DisplayMember = "Description"
            ComboBoxApproval_Status.ValueMember = "Code"

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxApproval_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.AccountPayableMediaApproval.Properties.Comments)

                MediaCode = AdvantageFramework.EnumUtilities.LoadEnumObject(_MediaType).Code

                AccountPayableMediaApprovalDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMediaApprovalDetail)

                AccountPayableMediaApprovalDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, _AccountPayableID).ToList
                                                               Where Entity.OrderNumber = _OrderNumber AndAlso
                                                                     Entity.LineNumber = _OrderLineNumber AndAlso
                                                                     Entity.Source = MediaCode
                                                               Order By Entity.Revision Descending
                                                               Select New AdvantageFramework.AccountPayable.Classes.AccountPayableMediaApprovalDetail(DbContext, Entity))

                DataGridViewForm_ApprovalHistory.DataSource = AccountPayableMediaApprovalDetailList

                DataGridViewForm_ApprovalHistory.CurrentView.BestFitColumns()

            End Using

            ComboBoxApproval_Status.SetRequired(True)

            ComboBoxApproval_Status.ByPassUserEntryChanged = True
            CheckBoxForm_OnHold.ByPassUserEntryChanged = True
            TextBoxApproval_Comments.ByPassUserEntryChanged = True

            ComboBoxApproval_Status.SelectedValue = _Status
            TextBoxApproval_Comments.Text = _Comment

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _IsOnHold = If(CheckBoxForm_OnHold.Checked, 1, 0)
                _Status = ComboBoxApproval_Status.SelectedValue
                _Comment = TextBoxApproval_Comments.Text

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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
        Private Sub ComboBoxApproval_Status_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxApproval_Status.SelectedValueChanged

            If ComboBoxApproval_Status.SelectedIndex = 0 Then

                CheckBoxForm_OnHold.Checked = False

            Else

                CheckBoxForm_OnHold.Checked = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace