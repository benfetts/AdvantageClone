Imports System.ComponentModel

Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum PODetailCriteria
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Client/Division/Product")>
            ClientDivisionProduct = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Job/Job Comp")>
            JobAndComponent = 5
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobCompNumber As Short = Nothing
        Private _PODate As System.DateTime = Nothing
        Private _DueDate As System.DateTime = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Public ReadOnly Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        Public ReadOnly Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        Public ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Public ReadOnly Property JobCompNumber As Short
            Get
                JobCompNumber = _JobCompNumber
            End Get
        End Property
        Public ReadOnly Property PODate As System.DateTime
            Get
                PODate = _PODate
            End Get
        End Property
        Public ReadOnly Property DueDate As System.DateTime
            Get
                DueDate = _DueDate
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String,
                        ByRef JobNumber As Integer, ByRef JobCompNumber As Short)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _JobNumber = JobNumber
            _JobCompNumber = JobCompNumber

            ' Add any initialization after the InitializeComponent() call.
            ComboBoxForm_Criteria.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Criteria.ByPassUserEntryChanged = True
            SearchableComboBoxForm_CriteriaLevel2.ByPassUserEntryChanged = True
            SearchableComboBoxForm_CriteriaLevel3.ByPassUserEntryChanged = True

        End Sub
        Private Function SetProperties() As Boolean

            'objects
            Dim Criteria As Integer = 0
            Dim PropertiesSet As Boolean = False

            Try

                If ComboBoxForm_Criteria.SelectedValue IsNot Nothing Then

                    PropertiesSet = True

                    Criteria = CInt(ComboBoxForm_Criteria.GetSelectedValue)

                    Select Case Criteria

                        Case PODetailCriteria.ClientDivisionProduct

                            _ClientCode = SearchableComboBoxForm_Criteria.GetSelectedValue.ToString

                            If SearchableComboBoxForm_CriteriaLevel2.HasASelectedValue Then

                                _DivisionCode = SearchableComboBoxForm_CriteriaLevel2.GetSelectedValue.ToString

                                If SearchableComboBoxForm_CriteriaLevel3.HasASelectedValue Then

                                    _ProductCode = SearchableComboBoxForm_CriteriaLevel3.GetSelectedValue.ToString

                                End If

                            End If

                        Case PODetailCriteria.JobAndComponent

                            _JobNumber = CInt(SearchableComboBoxForm_Criteria.GetSelectedValue)

                            If SearchableComboBoxForm_CriteriaLevel2.HasASelectedValue Then

                                _JobCompNumber = CShort(SearchableComboBoxForm_CriteriaLevel2.GetSelectedValue)

                            End If

                        Case Else

                            PropertiesSet = False

                    End Select

                End If

            Catch ex As Exception
                PropertiesSet = False
            Finally
                SetProperties = PropertiesSet
            End Try

        End Function
        Private Sub FilterCriteriaLevel2()

            'objects
            Dim CriteriaLevel1 As Object = Nothing

            If SearchableComboBoxForm_CriteriaLevel2.Visible Then

                Try

                    CriteriaLevel1 = SearchableComboBoxForm_Criteria.GetSelectedValue()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Select Case SearchableComboBoxForm_CriteriaLevel2.ControlType

                                Case WinForm.Presentation.Controls.SearchableComboBox.Type.Division

                                    SearchableComboBoxForm_CriteriaLevel2.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                                                                        Where Entity.ClientCode = DirectCast(CriteriaLevel1, String)
                                                                                        Select Entity)

                                Case WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent

                                    SearchableComboBoxForm_CriteriaLevel2.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, False)
                                                                                        Where Entity.JobNumber = DirectCast(CriteriaLevel1, Integer)
                                                                                        Select Entity
                                                                                        Order By Entity.Number Descending)

                                Case Else

                                    SearchableComboBoxForm_CriteriaLevel2.DataSource = Nothing

                            End Select

                        End Using

                    End Using

                Catch ex As Exception
                    SearchableComboBoxForm_CriteriaLevel2.DataSource = Nothing
                End Try

            End If

        End Sub
        Private Sub FilterCriteriaLevel3()

            'objects
            Dim CriteriaLevel1 As Object = Nothing
            Dim CriteriaLevel2 As Object = Nothing

            If SearchableComboBoxForm_CriteriaLevel3.Visible Then

                Try

                    CriteriaLevel1 = SearchableComboBoxForm_Criteria.GetSelectedValue
                    CriteriaLevel2 = SearchableComboBoxForm_CriteriaLevel2.GetSelectedValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Select Case SearchableComboBoxForm_CriteriaLevel3.ControlType

                                Case WinForm.Presentation.Controls.SearchableComboBox.Type.Product

                                    SearchableComboBoxForm_CriteriaLevel3.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, False).ToList
                                                                                        Where Entity.ClientCode = DirectCast(CriteriaLevel1, String) AndAlso
                                                                                              Entity.DivisionCode = DirectCast(CriteriaLevel2, String)
                                                                                        Select Entity)

                                Case Else

                                    SearchableComboBoxForm_CriteriaLevel3.DataSource = Nothing

                            End Select

                        End Using

                    End Using

                Catch ex As Exception
                    SearchableComboBoxForm_CriteriaLevel3.DataSource = Nothing
                End Try

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            SearchableComboBoxForm_CriteriaLevel2.Enabled = SearchableComboBoxForm_Criteria.HasASelectedValue
            SearchableComboBoxForm_CriteriaLevel3.Enabled = SearchableComboBoxForm_Criteria.HasASelectedValue AndAlso SearchableComboBoxForm_CriteriaLevel2.HasASelectedValue

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String,
                                              ByRef JobNumber As Integer, ByRef JobCompNumber As Short) As Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderInitialLoadingDialog As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderInitialLoadingDialog = Nothing

            PurchaseOrderInitialLoadingDialog = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderInitialLoadingDialog(ClientCode, DivisionCode, ProductCode, JobNumber, JobCompNumber)

            ShowFormDialog = PurchaseOrderInitialLoadingDialog.ShowDialog()

            ClientCode = PurchaseOrderInitialLoadingDialog.ClientCode
            DivisionCode = PurchaseOrderInitialLoadingDialog.DivisionCode
            ProductCode = PurchaseOrderInitialLoadingDialog.ProductCode
            JobNumber = PurchaseOrderInitialLoadingDialog.JobNumber
            JobCompNumber = PurchaseOrderInitialLoadingDialog.JobCompNumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(PODetailCriteria))

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim PONumbers As Integer() = Nothing
            Dim QueryString As String = ""

            If Me.Validator Then

                If SetProperties() Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("There was an error setting the search criteria.", WinForm.MessageBox.MessageBoxButtons.OK)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Criteria_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Criteria.SelectedValueChanged

            'objects
            Dim Criteria As Integer = Nothing

            If ComboBoxForm_Criteria.HasASelectedValue Then

                Criteria = CInt(ComboBoxForm_Criteria.SelectedValue)

                SearchableComboBoxForm_Criteria.DataSource = Nothing
                SearchableComboBoxForm_CriteriaLevel2.DataSource = Nothing
                SearchableComboBoxForm_CriteriaLevel3.DataSource = Nothing
                SearchableComboBoxForm_Criteria.SelectedValue = Nothing
                SearchableComboBoxForm_CriteriaLevel2.SelectedValue = Nothing
                SearchableComboBoxForm_CriteriaLevel3.SelectedValue = Nothing
                SearchableComboBoxForm_CriteriaLevel2.Enabled = False
                SearchableComboBoxForm_CriteriaLevel3.Enabled = False
                DateTimePickerForm_Date.ValueObject = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case Criteria

                            Case PODetailCriteria.ClientDivisionProduct

                                SearchableComboBoxForm_Criteria.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Client
                                SearchableComboBoxForm_Criteria.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                SearchableComboBoxForm_CriteriaLevel2.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Division
                                SearchableComboBoxForm_CriteriaLevel3.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Product
                                SearchableComboBoxForm_Criteria.Visible = True
                                SearchableComboBoxForm_CriteriaLevel2.Visible = True
                                SearchableComboBoxForm_CriteriaLevel3.Visible = True
                                DateTimePickerForm_Date.Visible = False

                            Case PODetailCriteria.JobAndComponent

                                SearchableComboBoxForm_Criteria.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Job

                                SearchableComboBoxForm_Criteria.DataSource = AdvantageFramework.Database.Procedures.JobView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).OrderByDescending(Function(Job) Job.JobNumber)

                                SearchableComboBoxForm_CriteriaLevel2.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
                                SearchableComboBoxForm_Criteria.Visible = True
                                SearchableComboBoxForm_CriteriaLevel2.Visible = True
                                SearchableComboBoxForm_CriteriaLevel3.Visible = False
                                DateTimePickerForm_Date.Visible = False

                        End Select

                    End Using

                End Using

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Criteria_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Criteria.EditValueChanged

            FilterCriteriaLevel2()
            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxForm_CriteriaLevel2_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_CriteriaLevel2.EditValueChanged

            FilterCriteriaLevel3()
            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxForm_CriteriaLevel2_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchableComboBoxForm_CriteriaLevel2.QueryPopUp

            'objects
            Dim ShowJobNumber As Boolean = True

            If CInt(ComboBoxForm_Criteria.SelectedValue) = PODetailCriteria.JobAndComponent Then

                Try

                    If SearchableComboBoxForm_Criteria.HasASelectedValue AndAlso CInt(SearchableComboBoxForm_Criteria.GetSelectedValue) > 0 Then

                        ShowJobNumber = False

                    End If

                    If SearchableComboBoxForm_CriteriaLevel2.Properties.View.Columns("JobNumber") IsNot Nothing Then

                        SearchableComboBoxForm_CriteriaLevel2.Properties.View.Columns("JobNumber").Visible = ShowJobNumber

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace