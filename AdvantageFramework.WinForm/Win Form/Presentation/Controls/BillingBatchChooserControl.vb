Namespace WinForm.Presentation.Controls

    Public Class BillingBatchChooserControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event BatchSelected(BillingCommandCenterID As Integer)
        Public Event BatchDeselected()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum BatchType
            Production
            Media
        End Enum

#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _BatchType As BatchType = BatchType.Production

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
        Public ReadOnly Property BillingCommandCenterID As Nullable(Of Integer)
            Get

                If RadioButtonControl_AllBillingBatches.Checked Then

                    BillingCommandCenterID = Nothing

                ElseIf DataGridViewControl_BillingBatches.HasASelectedRow Then

                    BillingCommandCenterID = DataGridViewControl_BillingBatches.GetFirstSelectedRowBookmarkValue(2)

                Else

                    BillingCommandCenterID = Nothing

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
        Public Sub LoadControl(BatchType As BatchType)

            _BatchType = BatchType

            RadioButtonControl_AllBillingBatches.Checked = True

        End Sub
        Public Sub ForceResize()

            DataGridViewControl_BillingBatches.Width = Me.Width
            DataGridViewControl_BillingBatches.Height = Me.Height - 26

        End Sub
        Private Sub LoadBillingBatches()

            Dim BillingCommandCenterIDs As IEnumerable(Of Integer) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContextBCC = New AdvantageFramework.BillingCommandCenter.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _BatchType = BatchType.Production Then

                        BillingCommandCenterIDs = (From JC In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                                   Where JC.BillingCommandCenterID IsNot Nothing
                                                   Select JC.BillingCommandCenterID.Value).ToArray

                    ElseIf _BatchType = BatchType.Media Then

                        BillingCommandCenterIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DISTINCT BCC_ID FROM dbo.BCC_ORDER_LINE").ToArray

                    End If

                    DataGridViewControl_BillingBatches.DataSource = (From Entity In AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Load(DbContextBCC)
                                                                     Where BillingCommandCenterIDs.Contains(Entity.ID)
                                                                     Select New With {.BillingUser = Mid(Entity.BillingUser, 1, Entity.BillingUser.Length - 2),
                                                                                      .BatchName = Entity.BatchName,
                                                                                      .BillingCommandCenterID = Entity.ID}).ToList

                    DataGridViewControl_BillingBatches.Columns("BillingCommandCenterID").Visible = False

                    DataGridViewControl_BillingBatches.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub

#Region "  Control Event Handlers "

        Private Sub BillingBatchChooserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewControl_BillingBatches.ShowSelectDeselectAllButtons = False
            DataGridViewControl_BillingBatches.MultiSelect = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub RadioButtonControl_AllBillingBatches_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllBillingBatches.CheckedChanged

            If RadioButtonControl_AllBillingBatches.Checked Then

                DataGridViewControl_BillingBatches.Enabled = False

                RaiseEvent BatchDeselected()

            End If

        End Sub
        Private Sub RadioButtonControl_SingleBillingBatch_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_SingleBillingBatch.CheckedChanged

            If RadioButtonControl_SingleBillingBatch.Checked Then

                LoadBillingBatches()

                DataGridViewControl_BillingBatches.Enabled = True

                If DataGridViewControl_BillingBatches.HasASelectedRow Then

                    RaiseEvent BatchSelected(DataGridViewControl_BillingBatches.CurrentView.GetRowCellValue(DataGridViewControl_BillingBatches.CurrentView.FocusedRowHandle, "BillingCommandCenterID"))

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_BillingBatches_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_BillingBatches.SelectionChangedEvent

            If DataGridViewControl_BillingBatches.HasASelectedRow Then

                RaiseEvent BatchSelected(DataGridViewControl_BillingBatches.CurrentView.GetRowCellValue(DataGridViewControl_BillingBatches.CurrentView.FocusedRowHandle, "BillingCommandCenterID"))

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
