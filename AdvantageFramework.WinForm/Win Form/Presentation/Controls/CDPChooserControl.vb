Namespace WinForm.Presentation.Controls

    Public Class CDPChooserControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event DataGridViewSelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _SelectedCDPChooserDetails As Generic.List(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property
        Public ReadOnly Property ClientCodeList As Generic.List(Of String)
            Get
                Dim CodeList As Generic.List(Of String) = Nothing

                If RadioButtonControl_AllClients.Checked Then

                    CodeList = Nothing

                Else

                    If RadioButtonControl_ChooseClients.Checked Then

                        CodeList = LoadSelectedClientsCodeList()

                    ElseIf RadioButtonControl_ChooseClientDivisions.Checked Then

                        CodeList = Nothing

                    ElseIf RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                        CodeList = Nothing

                    End If

                End If

                ClientCodeList = CodeList

            End Get
        End Property
        Public ReadOnly Property DivisionCodeList As Generic.List(Of String)
            Get
                Dim CodeList As Generic.List(Of String) = Nothing

                If RadioButtonControl_AllClients.Checked Then

                    CodeList = Nothing

                Else

                    If RadioButtonControl_ChooseClients.Checked Then

                        CodeList = Nothing

                    ElseIf RadioButtonControl_ChooseClientDivisions.Checked Then

                        CodeList = LoadSelectedClientsCodeList()

                    ElseIf RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                        CodeList = Nothing

                    End If

                End If

                DivisionCodeList = CodeList

            End Get
        End Property
        Public ReadOnly Property ProductCodeList As Generic.List(Of String)
            Get
                Dim CodeList As Generic.List(Of String) = Nothing

                If RadioButtonControl_AllClients.Checked Then

                    CodeList = Nothing

                Else

                    If RadioButtonControl_ChooseClients.Checked Then

                        CodeList = Nothing

                    ElseIf RadioButtonControl_ChooseClientDivisions.Checked Then

                        CodeList = Nothing

                    ElseIf RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                        CodeList = LoadSelectedClientsCodeList()

                    End If

                End If

                ProductCodeList = CodeList

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub LoadControl()

            RadioButtonControl_AllClients.Checked = True

        End Sub
        Public Sub LoadControl(ParameterDictionary As Generic.Dictionary(Of String, Object))

            'objects
            Dim SelectedCodes As Generic.List(Of String) = Nothing
            Dim CDPChooserDetail As AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail = Nothing

            RadioButtonControl_AllClients.Checked = True

            If ParameterDictionary IsNot Nothing Then

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedClients.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedClients.ToString)) = False AndAlso
                        DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedClients.ToString), Generic.List(Of String)).Count > 0 Then

                    Me.RadioButtonControl_ChooseClients.Checked = True

                    SelectedCodes = DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedClients.ToString), Generic.List(Of String))

                    DataGridViewControl_Clients.CurrentView.BeginSelection()

                    DataGridViewControl_Clients.CurrentView.ClearSelection()

                    For Each RowHandlesAndDataBoundItem In DataGridViewControl_Clients.GetAllRowsRowHandlesAndDataBoundItems

                        CDPChooserDetail = RowHandlesAndDataBoundItem.Value

                        If CDPChooserDetail IsNot Nothing AndAlso SelectedCodes.Contains(CDPChooserDetail.ClientCode) Then

                            DataGridViewControl_Clients.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                            DataGridViewControl_Clients.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                        End If

                    Next

                    DataGridViewControl_Clients.CurrentView.EndSelection()

                ElseIf ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedDivisions.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedDivisions.ToString)) = False AndAlso
                        DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedDivisions.ToString), Generic.List(Of String)).Count > 0 Then

                    Me.RadioButtonControl_ChooseClientDivisions.Checked = True

                    SelectedCodes = DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedDivisions.ToString), Generic.List(Of String))

                    DataGridViewControl_Clients.CurrentView.BeginSelection()

                    DataGridViewControl_Clients.CurrentView.ClearSelection()

                    For Each RowHandlesAndDataBoundItem In DataGridViewControl_Clients.GetAllRowsRowHandlesAndDataBoundItems

                        CDPChooserDetail = RowHandlesAndDataBoundItem.Value

                        If CDPChooserDetail IsNot Nothing AndAlso SelectedCodes.Contains(CDPChooserDetail.ClientCode & "|" & CDPChooserDetail.DivisionCode) Then

                            DataGridViewControl_Clients.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                            DataGridViewControl_Clients.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                        End If

                    Next

                    DataGridViewControl_Clients.CurrentView.EndSelection()

                ElseIf ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedProducts.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedProducts.ToString)) = False AndAlso
                        DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedProducts.ToString), Generic.List(Of String)).Count > 0 Then

                    Me.RadioButtonControl_ChooseClientDivisionProducts.Checked = True

                    SelectedCodes = DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedProducts.ToString), Generic.List(Of String))

                    DataGridViewControl_Clients.CurrentView.BeginSelection()

                    DataGridViewControl_Clients.CurrentView.ClearSelection()

                    For Each RowHandlesAndDataBoundItem In DataGridViewControl_Clients.GetAllRowsRowHandlesAndDataBoundItems

                        CDPChooserDetail = RowHandlesAndDataBoundItem.Value

                        If CDPChooserDetail IsNot Nothing AndAlso SelectedCodes.Contains(CDPChooserDetail.ClientCode & "|" & CDPChooserDetail.DivisionCode & "|" & CDPChooserDetail.ProductCode) Then

                            DataGridViewControl_Clients.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                            DataGridViewControl_Clients.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                        End If

                    Next

                    DataGridViewControl_Clients.CurrentView.EndSelection()

                End If

            End If

        End Sub
        Private Sub SetSelectedRows(ClientLevel As Boolean)

            'objects
            Dim SelectedCodes As IEnumerable(Of String) = Nothing
            Dim CDPChooserDetail As AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail = Nothing

            If _SelectedCDPChooserDetails IsNot Nothing Then

                If Not ClientLevel AndAlso _SelectedCDPChooserDetails.Any(Function(CDP) CDP.DivisionCode IsNot Nothing) Then

                    SelectedCodes = (From Entity In _SelectedCDPChooserDetails
                                     Select Entity.ClientCode & "|" & Entity.DivisionCode).Distinct.ToArray

                    If SelectedCodes IsNot Nothing AndAlso SelectedCodes.Count > 0 Then

                        DataGridViewControl_Clients.CurrentView.BeginSelection()

                        DataGridViewControl_Clients.CurrentView.ClearSelection()

                        For Each RowHandlesAndDataBoundItem In DataGridViewControl_Clients.GetAllRowsRowHandlesAndDataBoundItems

                            Try

                                CDPChooserDetail = RowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                CDPChooserDetail = Nothing
                            End Try

                            If CDPChooserDetail IsNot Nothing AndAlso SelectedCodes.Contains(CDPChooserDetail.ClientCode & "|" & CDPChooserDetail.DivisionCode) Then

                                DataGridViewControl_Clients.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                                DataGridViewControl_Clients.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                            End If

                        Next

                        DataGridViewControl_Clients.CurrentView.EndSelection()

                    End If

                Else

                    SelectedCodes = (From Entity In _SelectedCDPChooserDetails
                                     Select Entity.ClientCode).Distinct.ToArray

                    If SelectedCodes IsNot Nothing AndAlso SelectedCodes.Count > 0 Then

                        DataGridViewControl_Clients.CurrentView.BeginSelection()

                        DataGridViewControl_Clients.CurrentView.ClearSelection()

                        For Each RowHandlesAndDataBoundItem In DataGridViewControl_Clients.GetAllRowsRowHandlesAndDataBoundItems

                            Try

                                CDPChooserDetail = RowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                CDPChooserDetail = Nothing
                            End Try

                            If CDPChooserDetail IsNot Nothing AndAlso SelectedCodes.Contains(CDPChooserDetail.ClientCode) Then

                                DataGridViewControl_Clients.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                                DataGridViewControl_Clients.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                            End If

                        Next

                        DataGridViewControl_Clients.CurrentView.EndSelection()

                    End If

                End If

            End If

        End Sub
        Private Sub LoadClients()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewControl_Clients.ClearGridCustomization()

                    If RadioButtonControl_ChooseClients.Checked Then

                        DataGridViewControl_Clients.ItemDescription = "Client(s)"

                        DataGridViewControl_Clients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList
                                                                  Select New AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail(Entity.Code, Entity.Name)).ToList

                        SetSelectedRows(True)

                        For Each GridColumn In DataGridViewControl_Clients.CurrentView.Columns

                            If GridColumn.FieldName = AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail.Properties.Division.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail.Properties.Product.ToString Then

                                GridColumn.Visible = False

                            End If

                        Next

                    ElseIf RadioButtonControl_ChooseClientDivisions.Checked Then

                        DataGridViewControl_Clients.ItemDescription = "Division(s)"

                        DataGridViewControl_Clients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DivisionView.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList
                                                                  Where Entity.ClientActiveFlag = 1
                                                                  Select New AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail(Entity.ClientCode, Entity.ClientName, Entity.DivisionCode, Entity.DivisionName)).ToList

                        SetSelectedRows(False)

                        For Each GridColumn In DataGridViewControl_Clients.CurrentView.Columns

                            If GridColumn.FieldName = AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail.Properties.Product.ToString Then

                                GridColumn.Visible = False

                            End If

                        Next

                    ElseIf RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                        DataGridViewControl_Clients.ItemDescription = "Product(s)"

                        DataGridViewControl_Clients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ProductView.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList
                                                                  Where Entity.ClientActiveFlag = 1 AndAlso
                                                                        Entity.DivisionActiveFlag = 1
                                                                  Select New AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail(Entity.ClientCode, Entity.ClientName, Entity.DivisionCode, Entity.DivisionName, Entity.ProductCode, Entity.ProductDescription)).ToList

                        SetSelectedRows(False)

                    End If

                    DataGridViewControl_Clients.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Public Sub ForceResize()

            DataGridViewControl_Clients.Width = Me.Width
            DataGridViewControl_Clients.Height = Me.Height - 26

        End Sub
        Private Function LoadSelectedClientsCodeList() As Generic.List(Of String)

            'objects
            Dim CodeColumns As String() = Nothing
            Dim CodeList As Generic.List(Of String) = Nothing
            Dim SelectedCodeList As Generic.List(Of String) = Nothing

            SelectedCodeList = New Generic.List(Of String)

            If RadioButtonControl_ChooseClients.Checked Then

                CodeColumns = {"ClientCode"}

            ElseIf RadioButtonControl_ChooseClientDivisions.Checked Then

                CodeColumns = {"ClientCode", "DivisionCode"}

            ElseIf RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                CodeColumns = {"ClientCode", "DivisionCode", "ProductCode"}

            End If

            For Each SelectedRowHandle In DataGridViewControl_Clients.CurrentView.GetSelectedRows

                CodeList = New Generic.List(Of String)

                For Each CodeColumn In CodeColumns

                    CodeList.Add(DataGridViewControl_Clients.CurrentView.GetRowCellValue(SelectedRowHandle, CodeColumn))

                Next

                SelectedCodeList.Add(String.Join("|", CodeList))

            Next

            LoadSelectedClientsCodeList = SelectedCodeList

        End Function

#Region "  Control Event Handlers "

        Private Sub CDPChooserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewControl_Clients.ShowSelectDeselectAllButtons = True
            DataGridViewControl_Clients.MultiSelect = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_Clients_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Clients.SelectionChangedEvent

            RaiseEvent DataGridViewSelectionChangedEvent()

        End Sub
        Private Sub RadioButtonControl_AllClients_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllClients.CheckedChanged

            If RadioButtonControl_AllClients.Checked Then

                DataGridViewControl_Clients.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseClients_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseClients.CheckedChanged

            If RadioButtonControl_ChooseClients.Checked Then

                LoadClients()

                DataGridViewControl_Clients.Enabled = True

            Else

                _SelectedCDPChooserDetails = (From Entity In DataGridViewControl_Clients.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail)
                                              Select Entity).ToList

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseClientDivisions_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseClientDivisions.CheckedChanged

            If RadioButtonControl_ChooseClientDivisions.Checked Then

                LoadClients()

                DataGridViewControl_Clients.Enabled = True

            Else

                _SelectedCDPChooserDetails = (From Entity In DataGridViewControl_Clients.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail)
                                              Select Entity).ToList

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseClientDivisionProducts_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseClientDivisionProducts.CheckedChanged

            If RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                LoadClients()

                DataGridViewControl_Clients.Enabled = True

            Else

                _SelectedCDPChooserDetails = (From Entity In DataGridViewControl_Clients.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.CDPChooserDetail)
                                              Select Entity).ToList

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
