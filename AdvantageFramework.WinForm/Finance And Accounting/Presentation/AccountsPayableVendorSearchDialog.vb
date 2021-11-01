Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableVendorSearchDialog

#Region " Constants "



#End Region

#Region " Enum "

        

#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal VendorCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            RadioButtonForm_MediaOrder.ByPassUserEntryChanged = True
            RadioButtonForm_PurchaseOrder.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Criteria.ByPassUserEntryChanged = True

            _VendorCode = VendorCode

        End Sub
        Private Sub LoadComboBox()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim CanUserCustom1 As Boolean = False
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim VendorCategories As IEnumerable(Of String) = Nothing
            Dim AccountPayableVendorSearchOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableVendorSearchOrders) = Nothing

            VendorCategories = {"I", "M", "N", "O", "R", "T"}

            If Me.Session IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BindingSource = New System.Windows.Forms.BindingSource

                    If RadioButtonForm_PurchaseOrder.Checked Then

                        CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

                        VendorCodes = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Me.Session).Include("Office").Include("Market")
                                       Where Not CanUserCustom1 OrElse
                                                 (CanUserCustom1 AndAlso
                                                  (VendorCategories.Contains(Vendor.VendorCategory) OrElse
                                                   Vendor.InternetCategory = 1 OrElse Vendor.MagazineCategory = 1 OrElse Vendor.NewspaperCategory = 1 OrElse
                                                   Vendor.OutOfHomeCategory = 1 OrElse Vendor.RadioCategory = 1 OrElse Vendor.TVCategory = 1))
                                       Select Vendor.Code).ToArray

                        AccountPayableVendorSearchOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableVendorSearchOrders) _
                                (String.Format("exec advsp_ap_vendor_search_purchase_orders")).ToList

                        BindingSource.DataSource = (From Entity In AccountPayableVendorSearchOrders
                                                    Where VendorCodes.Contains(Entity.VendorCode)
                                                    Select Entity).ToList

                        SearchableComboBoxForm_Criteria.Properties.NullText = "Select Purchase Order"
                        SearchableComboBoxForm_Criteria.DisplayName = "Purchase Order"

                    ElseIf RadioButtonForm_MediaOrder.Checked Then

                        BindingSource.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableVendorSearchOrders) _
                                (String.Format("exec advsp_ap_vendor_search_media_orders")).ToList

                        SearchableComboBoxForm_Criteria.Properties.NullText = "Select Media Order"
                        SearchableComboBoxForm_Criteria.DisplayName = "Media Order"

                    End If

                    SearchableComboBoxForm_Criteria.EditValue = ""
                    SearchableComboBoxForm_Criteria.Text = Nothing
                    SearchableComboBoxForm_Criteria.Properties.DisplayMember = "VendorName"
                    SearchableComboBoxForm_Criteria.Properties.ValueMember = "Number"
                    SearchableComboBoxForm_Criteria.DataSource = BindingSource

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef VendorCode As String) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableVendorSearchDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableVendorSearchDialog = Nothing

            AccountsPayableVendorSearchDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableVendorSearchDialog(VendorCode)

            ShowFormDialog = AccountsPayableVendorSearchDialog.ShowDialog()

            VendorCode = AccountsPayableVendorSearchDialog.VendorCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableVendorSearchDialog_Load(sender As Object, e As EventArgs) Handles Me.Load



        End Sub
        Private Sub AccountsPayableVendorSearchDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadComboBox()

            SearchableComboBoxViewCriteria_Criteria.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = Nothing
            Dim AccountPayableVendorSearchOrder As AdvantageFramework.AccountPayable.Classes.AccountPayableVendorSearchOrders = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim AccountPayableVendorSearchOrders As System.Linq.EnumerableQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableVendorSearchOrders) = Nothing

            If SearchableComboBoxForm_Criteria.HasASelectedValue Then

                BindingSource = CType(SearchableComboBoxForm_Criteria.DataSource, System.Windows.Forms.BindingSource)

                AccountPayableVendorSearchOrders = DirectCast(DirectCast(BindingSource.List, System.Windows.Forms.BindingSource).List.AsQueryable, System.Linq.EnumerableQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableVendorSearchOrders))

                Try
                    AccountPayableVendorSearchOrder = AccountPayableVendorSearchOrders.Where(Function(Entity) Entity.Number = SearchableComboBoxForm_Criteria.SelectedValue).FirstOrDefault
                Catch ex As Exception
                    AccountPayableVendorSearchOrder = Nothing
                End Try

                If AccountPayableVendorSearchOrder IsNot Nothing Then

                    _VendorCode = AccountPayableVendorSearchOrder.VendorCode

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                If RadioButtonForm_MediaOrder.Checked Then

                    ErrorMessage = "Please select a valid Media Order."

                Else

                    ErrorMessage = "Please select a valid Purchase Order."

                End If

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonForm_MediaOrder_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_MediaOrder.CheckedChanged

            If Me.FormShown Then

                LoadComboBox()

            End If

        End Sub
        Private Sub RadioButtonForm_PurchaseOrder_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_PurchaseOrder.CheckedChanged

            If Me.FormShown Then

                LoadComboBox()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace