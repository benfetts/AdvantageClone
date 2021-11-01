Namespace Maintenance.Client.Presentation

    Public Class ProductReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _SelectedProductCodes() As String = Nothing
        Private _AvailableProductCodes() As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal AvailableProductCodes() As String, ByVal SelectedProductCodes() As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _SelectedProductCodes = SelectedProductCodes
            _AvailableProductCodes = AvailableProductCodes

        End Sub
        Private Sub LoadGrid()

            Dim ProductCodes() As String = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ProductCodes = (From UserClientDivisionProductAccess In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)
                                    Where UserClientDivisionProductAccess.ClientCode = _ClientCode AndAlso
                                          UserClientDivisionProductAccess.DivisionCode = _DivisionCode
                                    Select [PrdCode] = UserClientDivisionProductAccess.ProductCode).ToList.Select(Function(PrdCode) PrdCode).ToArray

                    If ProductCodes.Any Then

                        DataGridViewForm_Products.DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).Include("Office").Include("Client").Include("Division")
                                                               Where ProductCodes.Contains(Product.Code)
                                                               Select Product

                    Else

                        DataGridViewForm_Products.DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).Include("Office").Include("Client").Include("Division")
                                                               Select Product

                    End If

                    DataGridViewForm_Products.Columns("Client").Visible = False
                    DataGridViewForm_Products.Columns("Division").Visible = False

                    DataGridViewForm_Products.CurrentView.BestFitColumns()

                End Using

            End Using


        End Sub
        Private Sub LoadReports()

            Dim EnumObjectAttributeList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim IsCRMUser As Boolean = False

            ListBoxForm_Reports.DisplayMember = "Description"
            ListBoxForm_Reports.ValueMember = "Code"

            EnumObjectAttributeList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.ProductReportTypes)).ToList

            Try

                IsCRMUser = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.IsCRMUser)

            Catch ex As Exception
                IsCRMUser = False
            End Try

            If IsCRMUser Then

                For Each EnumObjectAttribute In EnumObjectAttributeList.ToList

                    If EnumObjectAttribute.Code = "36" Then

                        EnumObjectAttributeList.Remove(EnumObjectAttribute)
                        Exit For

                    End If

                Next

            End If

            ListBoxForm_Reports.DataSource = EnumObjectAttributeList

        End Sub
        Private Sub SelectGridRows()

            If _SelectedProductCodes IsNot Nothing Then

                DataGridViewForm_Products.CurrentView.BeginSelection()

                DataGridViewForm_Products.CurrentView.ClearSelection()

                For Each ProductCode In _SelectedProductCodes

                    DataGridViewForm_Products.SelectRow(DataGridViewForm_Products.CurrentView.Columns(AdvantageFramework.Database.Entities.Product.Properties.Code.ToString).AbsoluteIndex, ProductCode, False)

                Next

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, ByVal DivisionCode As String, Optional ByVal AvailableProductCodes() As String = Nothing, Optional ByVal SelectedProductCodes() As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ProductReportsDialog As AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog = Nothing

            ProductReportsDialog = New AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog(ClientCode, DivisionCode, AvailableProductCodes, SelectedProductCodes)

            ShowFormDialog = ProductReportsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ListBoxForm_Reports.SelectionMode = Windows.Forms.SelectionMode.One

            Try

                LoadReports()

            Catch ex As Exception

            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                SelectGridRows()

            Catch ex As Exception

            End Try

            DataGridViewForm_Products.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim ProductCodes As String() = Nothing
            Dim ContractList As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing

            If Me.Validator Then

                If DataGridViewForm_Products.HasASelectedRow Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        ProductCodes = (From Entity In DataGridViewForm_Products.GetAllSelectedRowsBookmarkValues().OfType(Of String)()
                                        Select Entity).ToArray

                        Select Case ListBoxForm_Reports.SelectedValue

                            Case Reporting.ProductReportTypes.Detail

                                ReportType = Reporting.ReportTypes.ProductDetail

                                ProductList = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("Office").Include("Client").Include("Division").Include("AccountExecutives")
                                               Where ProductCodes.Contains(Entity.Code) AndAlso
                                                     Entity.ClientCode = _ClientCode AndAlso
                                                     Entity.DivisionCode = _DivisionCode
                                               Select Entity
                                               Order By Entity.Code).ToList

                                If ProductList IsNot Nothing AndAlso ProductList.Count > 0 Then

                                    ParameterList.Add("DataSource", ProductList)

                                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                                End If

                            Case Reporting.ProductReportTypes.CRMDetailedInformation

                                ReportType = Reporting.ReportTypes.CRMDetailedInformation

                                ProductList = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("Client")
                                               Where ProductCodes.Contains(Entity.Code) AndAlso
                                                     Entity.ClientCode = _ClientCode AndAlso
                                                     Entity.DivisionCode = _DivisionCode
                                               Select Entity
                                               Order By Entity.Code).ToList

                                If ProductList IsNot Nothing AndAlso ProductList.Count > 0 Then

                                    ParameterList.Add("DataSource", ProductList)

                                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                                End If

                            Case Reporting.ProductReportTypes.ClientContractAndOpportunityDetail

                                ReportType = Reporting.ReportTypes.ClientContractAndOpportunityDetail

                                ContractList = (From Entity In AdvantageFramework.Database.Procedures.Contract.Load(DbContext).Include("Product").
                                                                                                                                   Include("Product.Client").
                                                                                                                                   Include("ContractFees").
                                                                                                                                   Include("ContractFees.ServiceFeeType").
                                                                                                                                   Include("ContractContacts").
                                                                                                                                   Include("ContractReports").
                                                                                                                                   Include("ContractReports.Cycle").
                                                                                                                                   Include("ContractValueAddeds")
                                                Where ProductCodes.Contains(Entity.ProductCode) AndAlso
                                                      Entity.ClientCode = _ClientCode AndAlso
                                                      Entity.DivisionCode = _DivisionCode
                                                Select Entity
                                                Order By Entity.Code).ToList

                                If ContractList IsNot Nothing AndAlso ContractList.Count > 0 Then

                                    ParameterList.Add("DataSource", ContractList)

                                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                                Else

                                    AdvantageFramework.Navigation.ShowMessageBox("No contracts/opportunities to print.")

                                End If

                        End Select

                    End Using

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one product.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace