Namespace WinForm.Presentation.Controls

    Public Class JobTypeChooserControl
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
        Public ReadOnly Property JobTypeCodeList As Generic.List(Of String)
            Get

                If RadioButtonControl_AllJobTypes.Checked Then

                    JobTypeCodeList = Nothing

                Else

                    JobTypeCodeList = DataGridViewControl_JobTypes.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

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
        Public Sub LoadControl(ParameterDictionary As Generic.Dictionary(Of String, Object))

            'objects
            Dim SelectedCodes As Generic.List(Of String) = Nothing

            LoadJobTypes()

            RadioButtonControl_AllJobTypes.Checked = True

            If ParameterDictionary IsNot Nothing AndAlso ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedJobTypes.ToString) AndAlso
                    IsNothing(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedJobTypes.ToString)) = False AndAlso
                    DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedJobTypes.ToString), Generic.List(Of String)).Count > 0 Then

                RadioButtonControl_ChooseJobTypes.Checked = True

                SelectedCodes = DirectCast(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.SelectedJobTypes.ToString), Generic.List(Of String))

                DataGridViewControl_JobTypes.CurrentView.BeginSelection()

                DataGridViewControl_JobTypes.CurrentView.ClearSelection()

                For Each RowHandlesAndDataBoundItem In DataGridViewControl_JobTypes.GetAllRowsRowHandlesAndDataBoundItems

                    If SelectedCodes.Contains(RowHandlesAndDataBoundItem.Value.Code) Then

                        DataGridViewControl_JobTypes.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                        DataGridViewControl_JobTypes.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridViewControl_JobTypes.CurrentView.EndSelection()

            End If

            EnableOrDisableActions()

        End Sub
        Public Sub LoadControl()

            RadioButtonControl_AllJobTypes.Checked = True

            LoadJobTypes()

            EnableOrDisableActions()

        End Sub
        Public Sub ForceResize()

            DataGridViewControl_JobTypes.Width = Me.Width
            DataGridViewControl_JobTypes.Height = Me.Height - 26

        End Sub
        Private Sub LoadJobTypes()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewControl_JobTypes.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobType.LoadAllActive(DbContext).ToList
                                                           Select [Code] = Entity.Code,
                                                                  [Description] = Entity.Description.ToString
                                                           Distinct).ToList

                DataGridViewControl_JobTypes.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewControl_JobTypes.Enabled = RadioButtonControl_ChooseJobTypes.Checked

        End Sub

#Region "  Control Event Handlers "

        Private Sub AEChooserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub RadioButtonControl_AllJobTypes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllJobTypes.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonControl_ChooseJobTypes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseJobTypes.CheckedChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
