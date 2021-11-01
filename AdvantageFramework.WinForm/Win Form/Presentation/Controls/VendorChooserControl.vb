Namespace WinForm.Presentation.Controls

    Public Class VendorChooserControl
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
        Public ReadOnly Property VendorCodeList As Generic.List(Of String)
            Get

                If RadioButtonControl_AllVendors.Checked Then

                    VendorCodeList = Nothing

                Else

                    VendorCodeList = DataGridViewControl_Vendors.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

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

            RadioButtonControl_AllVendors.Checked = True

        End Sub
        Public Sub ForceResize()

            DataGridViewControl_Vendors.Width = Me.Width
            DataGridViewControl_Vendors.Height = Me.Height - 26

        End Sub
        Private Sub LoadVendors()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewControl_Vendors.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToList
                                                          Select [Code] = Entity.Code,
                                                                 [Name] = Entity.Name
                                                          Distinct).ToList

                DataGridViewControl_Vendors.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Control Event Handlers "

        Private Sub AEChooserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewControl_Vendors.ShowSelectDeselectAllButtons = True
            DataGridViewControl_Vendors.MultiSelect = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub RadioButtonControl_AllAccountExecutives_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllVendors.CheckedChanged

            If RadioButtonControl_AllVendors.Checked Then

                DataGridViewControl_Vendors.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseAccountExecutives_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseVendors.CheckedChanged

            If RadioButtonControl_ChooseVendors.Checked Then

                LoadVendors()

                DataGridViewControl_Vendors.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
