Imports System.Data
Imports System.Data.Linq.SqlClient
Imports System.Data.SqlClient


Namespace WinForm.Presentation.Controls

    Public Class AEChooserControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False

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
        Public ReadOnly Property AccountExecutiveCodeList As Generic.List(Of String)
            Get

                If RadioButtonControl_AllAccountExecutives.Checked Then

                    AccountExecutiveCodeList = Nothing

                Else

                    AccountExecutiveCodeList = DataGridViewControl_AccountExecutives.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                End If

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

            RadioButtonControl_AllAccountExecutives.Checked = True

        End Sub
        Public Sub LoadControl(ParameterDictionary As Generic.Dictionary(Of String, Object))

            'objects
            Dim SelectedCodes As Generic.List(Of String) = Nothing

            RadioButtonControl_AllAccountExecutives.Checked = True

            If ParameterDictionary IsNot Nothing Then

                If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedAccountExecutives.ToString) AndAlso
                        IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedAccountExecutives.ToString)) = False AndAlso
                        DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedAccountExecutives.ToString), Generic.List(Of String)).Count > 0 Then

                    RadioButtonControl_ChooseAccountExecutives.Checked = True

                    SelectedCodes = DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedAccountExecutives.ToString), Generic.List(Of String))

                    DataGridViewControl_AccountExecutives.CurrentView.BeginSelection()

                    DataGridViewControl_AccountExecutives.CurrentView.ClearSelection()

                    For Each RowHandlesAndDataBoundItem In DataGridViewControl_AccountExecutives.GetAllRowsRowHandlesAndDataBoundItems

                        If SelectedCodes.Contains(DirectCast(RowHandlesAndDataBoundItem.Value, System.Data.DataRowView).Row.ItemArray(0)) Then

                            DataGridViewControl_AccountExecutives.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                            DataGridViewControl_AccountExecutives.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                        End If

                    Next

                    DataGridViewControl_AccountExecutives.CurrentView.EndSelection()

                End If

            End If

        End Sub
        Public Sub ForceResize()

            DataGridViewControl_AccountExecutives.Width = Me.Width
            DataGridViewControl_AccountExecutives.Height = Me.Height - 26

        End Sub
        Private Sub LoadAccountExecutives()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewControl_AccountExecutives.DataSource = LoadAccountExecutiveDataTable()

                'DataGridViewControl_AccountExecutives.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").ToList
                '                                                    Where Entity.IsInactive Is Nothing OrElse
                '                                                          Entity.IsInactive = 0
                '                                                    Select [Code] = Entity.Employee.Code,
                '                                                           [Name] = Entity.Employee.ToString
                '                                                    Distinct).ToList.OrderBy(Function(AE) AE.Code).ToList

                DataGridViewControl_AccountExecutives.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Function LoadAccountExecutiveDataTable() As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "usp_wv_dd_account_executive"

                        SqlCommand.Parameters.AddWithValue("Client", "")
                        SqlCommand.Parameters.AddWithValue("Division", "")
                        SqlCommand.Parameters.AddWithValue("Product", "")
                        SqlCommand.Parameters.AddWithValue("USER_CODE", _Session.User.UserCode)

                        SqlCommand.Connection.Open()

                        Try

                            DataTable.Load(SqlCommand.ExecuteReader)

                        Catch ex As Exception
                            DataTable = Nothing
                        Finally
                            SqlCommand.Connection.Close()
                        End Try

                    End Using

                Catch ex As Exception

                End Try

            End Using

            LoadAccountExecutiveDataTable = DataTable

        End Function

#Region "  Control Event Handlers "

        Private Sub AEChooserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub RadioButtonControl_AllAccountExecutives_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllAccountExecutives.CheckedChanged

            If RadioButtonControl_AllAccountExecutives.Checked Then

                DataGridViewControl_AccountExecutives.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseAccountExecutives_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseAccountExecutives.CheckedChanged

            If RadioButtonControl_ChooseAccountExecutives.Checked Then

                LoadAccountExecutives()

                DataGridViewControl_AccountExecutives.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
