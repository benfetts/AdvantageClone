Namespace WinForm.Presentation.Controls

    Public Class SalesClassChooserControl
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
        Public ReadOnly Property SalesClassCodeList As Generic.List(Of String)
            Get

                If RadioButtonControl_AllSalesClasses.Checked Then

                    SalesClassCodeList = Nothing

                Else

                    SalesClassCodeList = DataGridViewControl_SalesClasses.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

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

            RadioButtonControl_AllSalesClasses.Checked = True

        End Sub
        Public Sub ForceResize()

            DataGridViewControl_SalesClasses.Width = Me.Width
            DataGridViewControl_SalesClasses.Height = Me.Height - 26

        End Sub
        Private Sub LoadSalesClasses()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewControl_SalesClasses.DataSource = From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList
                                                              Select [Code] = Entity.Code,
                                                                     [Description] = Entity.ToString

                DataGridViewControl_SalesClasses.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Control Event Handlers "

        Private Sub AEChooserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewControl_SalesClasses.ShowSelectDeselectAllButtons = True
            DataGridViewControl_SalesClasses.MultiSelect = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub RadioButtonControl_AllSalesClasses_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllSalesClasses.CheckedChanged

            If RadioButtonControl_AllSalesClasses.Checked Then

                DataGridViewControl_SalesClasses.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseSalesClasses_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseSalesClasses.CheckedChanged

            If RadioButtonControl_ChooseSalesClasses.Checked Then

                LoadSalesClasses()

                DataGridViewControl_SalesClasses.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
